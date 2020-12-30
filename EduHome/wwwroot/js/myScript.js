$(function () {
    //Validation starts
    function ValidateEmail(email) {
        var mailformat = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
        if (email.match(mailformat)) {
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
        if (text.length != 0) {
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
                if (ValidateName(name) && ValidateSubject(subject) && ValidateMessage(message)) {
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
    }
    TakeData();
});