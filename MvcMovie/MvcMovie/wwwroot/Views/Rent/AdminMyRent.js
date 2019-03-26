var TeamEditOrderPostBackURL = '/Admin/EditOrder';



$(function () {
       

        $(".anchorEditOrder").click(function () {
        var $buttonClicked = $(this);
        
        var id = $buttonClicked.attr('data-id');
        var options = { "backdrop": "static", keyboard: true };
        $.ajax({
            type: "GET",
            url: TeamEditOrderPostBackURL,
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
    $('#rents').DataTable({
        "stateSave": true,
        "stateDuration": -1,

        "infoFiltered": false,
        "dom": '<"top"fi>rt<"bottom"lp><"clear">',
        "columns": [
            null,
            null,
            null,
            null,
            null,
            null,
            { "orderable": false }
        ]
    });
});