$(document).ready(function () {


    var table = $('.dataTable-examples').DataTable({
        pageLength: 5,
        responsive: true,
        dom: 'Bfrtip',
        "order": [[0, "desc"]],
        buttons: [
            {
                extend: 'copy'
            },
            {
                extend: 'excel',
                title: 'CoinJar',
                exportOptions: {
                    columns: ':not(.notexport)'
                }
            },
            {
                extend: 'print',
                customize: function (win) {
                    $(win.document.body).addClass('white-bg');
                    $(win.document.body).css('font-size', '10px');

                    $(win.document.body).find('table')
                        .addClass('compact')
                        .css('font-size', 'inherit');
                },
                exportOptions: {
                    columns: ':not(.notexport)'
                }
            }
        ]
    });

    $(document).on('click', '.dataTable .getmoney', function () {
        $.ajax({
            type: "GET",
            url: "/Home/GetAmountDetails",
            dataType: "json",
            beforeSend: function () {
                $("#showProgressSpin").css("display", "block");
            },
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                $.alert({
                    title: 'Success!',
                    content: data,
                });
            },
            complete: function () {
                $("#showProgressSpin").css("display", "none");
            }
        });
    });

    $(document).on('click', '.dataTable .restdetails', function () {

        $.confirm({
            title: 'Rest Coin',
            content: 'Are you sure that you want to reset the coin?',
            buttons: {
                somethingElse: {
                    text: 'Reset',
                    btnClass: 'btn-blue',
                    keys: ['enter', 'shift'],
                    action: function () {

                        $.ajax({
                            type: "POST",
                            url: "/Home/RestCoin",
                            dataType: "json",
                            beforeSend: function () {
                                $("#showProgressSpin").css("display", "block");
                            },
                            contentType: 'application/json; charset=utf-8',
                            success: function (data) {
                                $.alert({
                                    title: 'Success!',
                                    content: 'Reset successful',
                                });
                                location.reload();
                            },
                            complete: function () {
                                $("#showProgressSpin").css("display", "none");
                            }
                        });
                    }
                },
                cancel: function () {
                    $.alert('Operation canceled!');
                }
            }
        });
    });

});

function LoadAddCoinJar() {
    $("#showProgressSpin").css("display", "block");
}