
$(function () {
    let person;
    let roleText;
    $(".change-role-btn").click(function () {
        $(".rol-btn-holder").css({ "top": `${$(this).offset().top - $(document).scrollTop() + 50}px`, "left": `${$(this).offset().left + 20}px` })
        $(".role-modal").removeClass("d-none");
        $("body").css({ "height": "100vh", "overflow-y": "hidden" })
        person = this.dataset.username;
        $.ajax({
            type: "GET",
            url: `/Admin/User/ChangeRole`,
            data: { "username": this.dataset.username },
            success: function (res) {
                for (var btn of $(".role-btn")) {
                    if (btn.innerText == res) {
                        btn.classList.add("btn-success");
                        btn.classList.remove("btn-light");
                    }
                };
            }

        })
    });
    $(".role-btn").on("click", function () {
        if ($(this).hasClass("btn-success")) {
            $(".role-btn").removeClass("btn-success")
            $(this).addClass("btn-light")
        } else {
            $(".role-btn").removeClass("btn-success")
            $(this).addClass("btn-success")
            $(this).removeClass("btn-light")
            $(".role-save-btn").css("cursor", "pointer");
            $(".role-save-btn").addClass("btn-primary")
            $(".role-save-btn").prop("disabled", false);
        }
    });
    $(".role-save-btn").click(function () {
        for (var role of $(".role-btn")) {
            if (role.classList.contains("btn-success")) {
                roleText = role.innerText;
            }
        }
        $.ajax({
            type: "GET",
            url: `/Admin/User/ChangeRolePost`,
            data: {
                "username": person,
                "role": roleText
            },
            success: function (res) {
                $(`.${person}`).text(`${res}`);
                $(".role-btn").removeClass("btn-success");
                $(".role-btn").addClass("btn-light");
                $(".role-modal").addClass("d-none");
                $("body").css({ "height": "initial", "overflow-y": "initial" })
            }
        })
    })



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
        $(document).on("click", ".delete", function () {
            url = this.dataset.url;
            let box = $(this).parents(".text-center");
            $(".modal-box").css("display", "block");
            $("body").css({ "height": "100vh", "overflow-y": "hidden" })
            $.ajax({
                type: "GET",
                url: `/Admin/${url}/Delete`,
                data: { "id": this.dataset.delete },
                success: function (res) {
                    if (res.image != null && url.toLowerCase() != "speaker") {
                        $(".inner-img").attr("src", `/img/${url.toLowerCase()}/${res.image}`)
                    } else if (url.toLowerCase() == "speaker") {
                        $(".inner-img").attr("src", `/img/event/${res.image}`)
                        $(".inner-img").css("width", "95px")
                        $(".inner-img").addClass("img-fluid")
                    }
                    if (res.fullname != null) {
                        $(".modal-body").text(res.fullname)
                    } else if (res.title != null) {
                        $(".modal-body").text(res.title)
                    }
                    else if (res.name != null) {
                        $(".modal-body").text(res.name)
                    }
                    else {
                        $(".modal-body").text(res.descriptioon)
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
    if ($("#count").val() <= count) {
        $(".btn-holder").remove();
    };
    $(document).on('click', '.loadButton', function () {
        $.ajax({
            url: `${this.dataset.set}/LoadMore/?skip=` + count,
            type: 'GET',
            success: function (res) {
                $(".body").append(res);
                count += 10;
                if ($("#count").val() <= count) {
                    $(".btn-holder").remove();
                };
            }
        })
    })
})
