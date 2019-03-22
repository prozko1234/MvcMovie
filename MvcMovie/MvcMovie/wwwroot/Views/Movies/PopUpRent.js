var TeamRentPostBackURL = '/Rent/Index';
$(function () {
    $(".anchorRent").click(function () {
        var $buttonClicked = $(this);
        var id = $buttonClicked.attr('data-id');
        var options = { "backdrop": "static", keyboard: true };
        $.ajax({
            type: "GET",
            url: TeamRentPostBackURL + '?movieId=' + id,
            contentType: "application/json; charset=utf-8",
            datatype: "json",
            success: function (data) {
                $('#myModalContent').html(data);
                $('#myModal').modal(options);
                $('#myModal').modal('show');
            },
            error: function () {
                alert("Dynamic content load failed.");
            }
        });
    });
    $("#closebtn").on('click', function () {
        $('#myModal').modal('hide');

        //$("#closbtn").click(function () {
        //    $('#myModal').modal('hide');
    });
});