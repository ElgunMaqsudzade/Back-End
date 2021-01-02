$(function () {
    //Validation starts
    function ValidateEmail(email) {
        var mailformat = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
        if ($("#comment-form").hasClass("authorized")) {
            return true;
        }
        else if (email.match(mailformat)) {
            return true;
        }
        else {
            $("#email").css("border-color", "red")
            $("#email").after(`<span class="text-danger text-sm validate-text">You have entered an invalid email address!</span>`)
            setTimeout(function () {
                $("#email").css("border-color", "#E1E1E1");
                $(".validate-text").remove();
            }, 2000)
            $("#email")[0].scrollIntoView({
                behavior: "smooth",
                block: "center"
            });
            return false;
        }
    }
    function ValidateName(text) {
        if ($("#comment-form").hasClass("authorized")) {
            return true;
        }
        else if (text.length != 0) {
            return true;
        }
        else {
            $("#name").css("border-color", "red")
            setTimeout(function () {
                $("#name").css("border-color", "#E1E1E1");
            }, 2000);
            $("#name")[0].scrollIntoView({
                behavior: "smooth",
                block: "center"
            });
            return false;
        }
    }
    function ValidateSubject(text) {
        if (text.length != 0) {
            return true;
        }
        else {
            $("#subject").css("border-color", "red")
            setTimeout(function () {
                $("#subject").css("border-color", "#E1E1E1");
            }, 2000);
            $("#subject")[0].scrollIntoView({
                behavior: "smooth",
                block: "center"
            });
            return false;
        }
    }
    function ValidateMessage(text) {
        if (text.length != 0) {
            return true;
        }
        else {
            $("#message").css("border-color", "red")
            setTimeout(function () {
                $("#message").css("border-color", "#E1E1E1");
            }, 2000);
            $("#message")[0].scrollIntoView({
                behavior: "smooth",
                block: "center"
            });
            return false;
        }
    }
    //Validation ends
    //Bring comment from back


    let BlogUrl = "/Blog/";
    let CourseUrl = "/Course/";
    let EventUrl = "/Event/";
    function TakeData() {
        let name;
        let dbid;
        let email;
        let subject;
        let message;
        let myCard;
        let count;
        $(document).on("click", ".reply-button", function (e) {
            e.preventDefault();
            dbid = $("#db-id").val();
            name = $("#name").val();
            email = $("#email").val();
            subject = $("#subject").val();
            message = $("#message").val();
            if (ValidateEmail(email)) {
                if (ValidateName(name) && ValidateMessage(message)) {
                    count = Number($(".reply-count").text())
                    $.ajax({
                        url: `${this.dataset.url}Comment`,
                        type: "POST",
                        data: {
                            "dbid": dbid,
                            "name": name,
                            "email": email,
                            "subject": subject,
                            "message": message
                        },
                        success: function (res) {
                            myCard = document.createElement("div");
                            $(myCard).prepend(res)
                            $(".reply-count").text(`${count + 1}`);
                            $(".message-field").prepend(myCard);
                            myCard.scrollIntoView({
                                behavior: "smooth",
                                block: "center"
                            });
                            $("#name").val("");
                            $("#email").val("");
                            $("#subject").val("");
                            $("#message").val("");
                        }
                    });
                }
            }
        });
        //variables
        $(document).on("click", ".com-reply-btn", function (e) {
            e.preventDefault();
            if ($(this).hasClass("disabled") && !$(this).parents(".message-card").next().hasClass("error")) {
                let error = $(this).parents(".message-card").after(
                    "<div style='font-size: 13px;transform:translate(107px,-40px);' class='text-danger error' >You must login before commenting something</div>"
                )
                setTimeout((e) => {
                    error.next().remove();
                }, 2000)
                return;
            }
        });
        let id;
        let url;
        let replyInputCard;
        let primaryCard;
        $(document).on("click", ".com-reply-btn", function () {
            primaryCard = $(this).parents(".comment");
            replyInputCard = $(this).parents(".message-card").next(".reply-input");
            let replyInput;
            id = this.dataset.take;
            url = document.querySelector(".reply-button").dataset.url;
            $.ajax({
                url: `${url}Reply`,
                type: "POST",
                data: {
                    "id": id,
                },
                success: function (res) {
                    if (!replyInputCard.hasClass("collapsed")) {
                        replyInputCard.prop("hidden", false);
                        replyInputCard.append(res);
                        replyInputCard.addClass("collapsed");
                        replyInput = replyInputCard.find(".reply-inp");
                        replyInput.focus();
                    } else {
                        replyInput = replyInputCard.find(".reply-inp");
                        replyInput.focus();
                    }
                    replyInput = replyInputCard.find(".reply-inp");
                }
            });

        })

        $(document).on("keyup", ".reply-inp", function () {
            if (!($(this).val() == 0)) {
                $(this).next().find(".rp-send").addClass("btnActive");
                $(this).next().find(".rp-send").prop("disabled", false);
            } else {
                $(this).next().find(".rp-send").removeClass("btnActive");
            }
        });


        $(document).on("click", ".rp-cancel", function () {
            $(this).parents(".com-card").remove();
            replyInputCard.removeClass("collapsed");
        });


        let replycard;
        $(document).on("click", ".rp-send", function () {
            let message = $(this).parent().prev(".reply-inp").val();
            replycard = $(this).parents(".reply-input").next(".reply-card")
            $.ajax({
                url: `${url}ReplyComment`,
                type: "POST",
                data: {
                    "message": message,
                    "id": id,
                },
                success: function (res) {
                    replyInputCard.removeClass("collapsed");
                    replyInputCard.empty();
                    primaryCard.find(".reply-card-ul").append(res);
                    primaryCard.find(".reply-card-ul").prop("hidden", false);
                    primaryCard.addClass("added");
                }
            });

        });
        $(document).on("click", ".load-btn", function () {
            if ($(this).next(".reply-card-ul").prop("hidden")) {
                $(this).next(".reply-card-ul").prop("hidden", false)
                $(this).find(".fa-caret-down").css("transform", "rotate(180deg)")
            } else {
                $(this).next(".reply-card-ul").prop("hidden", true);
                $(this).find(".fa-caret-down").css("transform", "rotate(0deg)");
            }
        });
    }
    TakeData();
    //search
    function Search() {
        let search;
        let isUl = false;
        $(document).on("keyup", "#search-inp", function () {
            $(".search-ul").empty();
            search = $("#search-inp").val();
            $.ajax({
                url: `${$("#mycont").val()}Search`,
                type: "GET",
                data: {
                    "word": search
                },
                success: function (res) {
                    $(".search-ul").append(res);
                }
            })
        })
        $(document).on("blur", "#search-inp", function () {

            if (!isUl) {
                $(".search-ul").css("display", "none");
            }
        })
        $(document).on("focus", "#search-inp", function () {
            console.log("dafe")
            $(".search-ul").css("display", "block");
        })
        $(document).on("mouseenter", ".search-ul", function () {
            isUl = true;
        })
        $(document).on("mouseleave", ".search-ul", function () {
            isUl = false;
        })
    } Search();
    //search for all input configuration
    function SearchAll() {
        $(document).on("keyup", ".search-btn", function () {
            if ($(".search-input").val() != 0) {
                $(".search-btn").prop("disabled", false);
            }
            else {
                $(".search-btn").prop("disabled", true);
            }
        })

    } SearchAll();
    //yoxla
    //user page configuring with ajax
    function UserPageModel() {

        let person = {
            myrole: "",
            myusername: "",
        }
        $(".change-role-btn").click(function () {
            $(".rol-btn-holder").css({ "top": `${$(this).offset().top - $(document).scrollTop() + 50}px`, "left": `${$(this).offset().left + 20}px` })
            $(".role-modal").removeClass("d-none");
            $("body").css({ "height": "100vh", "overflow-y": "hidden" })
            for (var item of $(this).parent().siblings()) {
                for (var role of $(".role-btn")) {
                    if ($(item).text() == $(role).text()) {
                        $(".role-btn").addClass("btn-light")
                        $(".role-btn").removeClass("btn-success")
                        $(".role-btn").removeClass("active")
                        $(role).addClass("btn-success");
                        $(role).removeClass("btn-light");
                        $(role).addClass("active");
                        $(role).addClass("initial");
                    }
                }
                for (var username of $(".username-column")) {
                    if ($(username).text() == $(item).text()) {
                        person.myusername = $(username).text();
                    }
                }
            }

        });
        $(".role-btn").click(function () {
            if (!$(this).hasClass("active")) {
                $(".role-btn").addClass("btn-light")
                $(".role-btn").removeClass("btn-success")
                $(".role-btn").removeClass("active")
                $(this).removeClass("btn-light");
                $(this).addClass("active");
                $(this).addClass("btn-success");
            }
            if ($(this).hasClass("initial")) {
                $(".role-save-btn").removeClass("btn-primary")
                $(".role-save-btn").removeClass("active")
                $(".role-save-btn").css("cursor", "not-allowed")
            } else {
                $(".role-save-btn").addClass("btn-primary")
                $(".role-save-btn").addClass("active")
                $(".role-save-btn").css("cursor", "pointer")
            }
        });
        $(".role-save-btn").click(function () {
            for (var item of $(".role-btn")) {
                if ($(item).hasClass("active")) {
                    person.myrole = $(item).text();
                }
            }
            if ($(this).hasClass("active")) {
                $.ajax({
                    type: "GET",
                    url: '/Admin/User/ChangeRole',
                    data: { username: person.myusername, role: person.myrole },
                    dataType: "text",
                    success: function (res) {
                        for (var username of $(".username-column")) {
                            for (var role of $(".role-column")) {
                                if ($(username).text() == person.myusername) {
                                    for (var sib of $(username).siblings()) {
                                        if ($(sib).text() == $(role).text()) {
                                            $(role).text(res);
                                        }
                                    }
                                }
                            }
                        }
                        if ($(".role-save-btn").hasClass("active")) {
                            $(".role-btn").removeClass("initial")
                            $(".role-save-btn").removeClass("btn-primary")
                            $(".role-save-btn").removeClass("active")
                            $(".role-save-btn").css("cursor", "not-allowed")
                            $(".role-modal").addClass("d-none");
                            $("body").css({ "height": "initial", "overflow-y": "initial" })
                        }
                    }
                });
            }
        });


        $(".role-cancel-btn").click(function () {
            $(".role-modal").addClass("d-none");
            $("body").css({ "height": "initial", "overflow-y": "initial" })
        });


        $(".role-modal").click(function () {
            $(".role-modal").addClass("d-none");
            $("body").css({ "height": "initial", "overflow-y": "initial" })
        });
        $(".rol-btn-holder").click(function (e) {
            e.stopPropagation();
        })
    } UserPageModel();



    //user profile
    function UserProfile() {
        let name = $("#name").val();
        let username = $("#username").val();
        let email = $("#email").val();
        let image = $("#Photo").val();

        $(".profile-image").click(function () {
            $(".modal-box").css("display", "block");
            $("body").css({ "height": "100vh", "overflow-y": "hidden" })
        })

        $(".modal-box").click(function () {
            $(".modal-box").css("display", "none");
            $("body").css({ "height": "initial", "overflow-y": "initial" })
        });
        $(".input-holder").click(function (e) {
            e.stopPropagation();
        })

        $(".edit-btn").click(function () {
            if (!$(this).hasClass("show")) {
                $(`#${this.dataset.set}`).css("display", "block");
                $(`.${this.dataset.set}`).css("display", "none");
                $(this).addClass("show")
            } else {
                $(`#${this.dataset.set}`).css("display", "none");
                $(`.${this.dataset.set}`).css("display", "block");
                $(this).removeClass("show")
                $(`.text-${this.dataset.set}`).text($(`#${this.dataset.set}`).val());
            }
        })
        $(document).on("keyup", ".profile-inp", function () {
            if ($("#name").val() != name || $("#username").val() != username || $("#email").val() != email || $("#Photo").val() != "") {
                $(".save-btn").addClass("btnActive");
                $(".save-btn").prop("disabled", false);
            }
            if ($("#name").val() == name && $("#username").val() == username && $("#email").val() == email && $("#Photo").val() == image) {
                $(".save-btn").removeClass("btnActive");
                $(".save-btn").prop("disabled", true);
            }
            if ($("#name").val() == 0 || $("#username").val() == 0 || $("#email").val() == 0) {
                $(".save-btn").removeClass("btnActive");
                $(".save-btn").prop("disabled", true);
            }
        })
        $(document).on("change", ".profile-form", function () {
            if ($("#Photo").val() != "") {
                $(".save-btn").addClass("btnActive");
                $(".save-btn").prop("disabled", false);
            }
        })
    } UserProfile();

});