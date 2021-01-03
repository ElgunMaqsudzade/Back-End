
$(function () {
    let person = {
        myrole: "",
        myusername: "",
    }
    $(".change-role-btn").click(function () {
        $(".rol-btn-holder").css({ "top": `${$(this).offset().top - $(document).scrollTop() + 50}px`, "left": `${$(this).offset().left + 20}px` })
        $(".role-modal").removeClass("d-none");
        $("body").css({ "overflow-y": "hidden" })
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

    //++++++++++++++++++++++++++++++++
    //Course Simple Delete Action modal
    //++++++++++++++++++++++++++++++++
    function Modal() {
        let url;
        $(".delete").click(function () {
            url = this.dataset.url;
            let box = $(this).parents(".text-center");
            $(".modal-box").css("display", "block");
            $("body").css({ "height": "100vh", "overflow-y": "hidden" })
            $.ajax({
                type: "GET",
                url: `/Admin/${url}/Delete`,
                data: { "id": this.dataset.delete },
                success: function (res) {
                    $(".inner-img").attr("src", `/img/${url.toLowerCase()}/${res.image}`)
                    if (url == "Teacher") {
                        $(".modal-body").text(res.fullname)
                    } else {
                        $(".modal-body").text(res.title)
                    }
                    $(".modal-delete").click(function () {
                        $.ajax({
                            type: "Get",
                            url: `/Admin/${url}/DeletePost`,
                            data: { "id": res.id },
                            success: function () {
                                $(".modal-box").css("display", "none");
                                $("body").css({ "height": "auto", "overflow-y": "auto" })
                                box.remove();
                            }
                        })
                    })
                }
            })
        })

        $(".modal-box").click(function () {
            $(".modal-box").css("display", "none");
            $("body").css({ "height": "auto", "overflow-y": "auto" })
        });
        $(".modal-back").click(function () {
            $(".modal-box").css("display", "none");
            $("body").css({ "height": "auto", "overflow-y": "auto" })
        });
        $(".inner-box").click(function (e) {
            e.stopPropagation();
        })
    } Modal();

    //++++++++++++++++++++++++++++++++

    let count = 10;
    let num;
    $(document).on('click', '.amkButtonu', function () {
        $.ajax({
            url: 'Teacher/LoadMore/?skip=' + count,
            type: 'GET',
            success: function (res) {
                console.log(res)
                $(".body").append(res);
                count += 10;
                if ($("#count").val() <= count) {
                    $(".btn-holder").remove();
                };
            },
            error: function myfunction() {
                console.log("sea")
            }
        })
    })
})

