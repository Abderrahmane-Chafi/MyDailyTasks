var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable(filter) {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/AdminData/GetAll"
        },
        "columns": [
            { "data": "firstName", "widht": "70%" },
            { "data": "lastName", "widht": "70%" },
            { "data": "country", "widht": "70%" }
        ]
    });
}
