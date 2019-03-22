var TeamEditPostBackURL = '/Admin/Edit';
var TeamDeletePostBackURL = '/Admin/Delete';
var TeamDetailPostBackURL = '/Admin/Details';

$(function () {
    $(".anchorDetail").click(function () {
        var $buttonClicked = $(this);
        var id = $buttonClicked.attr('data-id');
        var options = { "backdrop": "static", keyboard: true };
        $.ajax({
            type: "GET",
            url: TeamDetailPostBackURL,
            contentType: "application/json; charset=utf-8",
            data: { "Id": id },
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

    $(".anchorEdit").click(function () {
        var $buttonClicked = $(this);
        var id = $buttonClicked.attr('data-id');
        var options = { "backdrop": "static", keyboard: true };
        $.ajax({
            type: "GET",
            url: TeamEditPostBackURL,
            contentType: "application/json; charset=utf-8",
            data: { "Id": id },
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

    $(".anchorDelete").click(function () {
        var $buttonClicked = $(this);
        var id = $buttonClicked.attr('data-id');
        var options = { "backdrop": "static", keyboard: true };
        $.ajax({
            type: "GET",
            url: TeamDeletePostBackURL,
            contentType: "application/json; charset=utf-8",
            data: { "Id": id },
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