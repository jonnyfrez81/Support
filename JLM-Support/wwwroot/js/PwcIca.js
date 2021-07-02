var dataTable;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/pwcIcaTblSettings/getall",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [

            { "data": "companyname", "width": "10%" },
            { "data": "moms25", "width": "10%" },
            { "data": "moms12", "width": "10%" },
            { "data": "moms6", "width": "10%" },
            { "data": "moms0", "width": "10%" },
            { "data": "active", "width": "10%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/pwcIcaTblSettings/edit?id=${data}" class='btn btn-success text-white' style='cursor:pointer; width:70px;'>
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