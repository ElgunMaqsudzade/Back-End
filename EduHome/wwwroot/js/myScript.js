$(function () {
    function TakeData() {
        let name;
        let email;
        let subject;
        let message;
        let myCard;
        let count;
        $(document).on("click", ".reply-button", function (e) {
            name = $("#name").val();
            email = $("#email").val();
            subject = $("#subject").val();
            message = $("#message").val();
            if () {

            }
            else {

            }
            count = Number($(".reply-count").text())
            e.preventDefault();
            $.ajax({
                url: "/Blog/Comment",
                type: "POST",
                data: {
                    "name": name,
                    "email": email,
                    "subject": subject,
                    "message": message
                },
                success: function (res) {
                    myCard = document.querySelector(".message-field")
                    console.log(count)
                    $(".reply-count").text(`${count + 1}`);
                    $(".message-field").prepend(res);
                    myCard.scrollIntoView({
                        behavior: "smooth",
                        block: "center"
                    });
                }
            });
        });
    } TakeData();



});