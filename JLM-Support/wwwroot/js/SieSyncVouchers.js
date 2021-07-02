var dataTable;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/siesyncvouchers/getall",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [


            { "data": "created", "width": "10%" },
            { "data": "company", "width": "10%" },
            { "data": "email", "width": "10%" },
            { "data": "fileName", "width": "10%" },
            { "data": "voucherNumber", "width": "10%" },

            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/siesyncvouchers/edit?id=${data}" class='btn btn-success text-white' style='cursor:pointer; width:70px;'>
                        Detail
                        </a>                   
                        </div>`;
                }, "width": "10%"

            }

        ],
        "language": {
            "EmptyTable": "no data found"
        },
        "width": "100%"
    });
}

function Delete(url) {
    swal({
        title: "Are you sure?",
        text: "Once deleted, you will not be able to revocer",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}