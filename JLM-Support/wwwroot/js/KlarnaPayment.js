var dataTable;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/klarnaPayments/getall",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [

            { "data": "isBooked", "width": "5%" },
            { "data": "capturedAt", "width": "20%" },
            { "data": "orderId", "width": "40%" },
            { "data": "errors", "width": "10%" },
            { "data": "merchantReference1", "width": "10%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/klarnapayments/edit?id=${data}" class='btn btn-success text-white' style='cursor:pointer; width:70px;'>
                        Edit
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