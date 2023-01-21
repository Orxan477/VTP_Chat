$(document).ready(function () {
    $(document).on("submit", "#enterGroup", function (ev) {
        ev.preventDefault();
        var number = $("#group :selected").val();
        $.ajax({
            url: "/Home/Index",
            data: {
                num: number
            },
            type: "GET",
            success: function (result) {
                alert("yes")
            }
        })
    })
})