
$(function () {
    let person;

    $(".change-role-btn").click(function () {
        $(".rol-btn-holder").css({ "top": `${$(this).offset().top - $(document).scrollTop() + 50}px`, "left": `${$(this).offset().left + 20}px` })
        $(".role-modal").removeClass("d-none");
        $("body").css({ "overflow-y": "hidden" })
        $.ajax({
            type: "GET",
            url: `/Admin/User/ChangeRole`,
            data: { "username": this.dataset.username },
            success: function (res) {
                console.log(res)
            }

        })
        //$(document).on("click", ".role-btn"){
        //    $(this).
        //}



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

