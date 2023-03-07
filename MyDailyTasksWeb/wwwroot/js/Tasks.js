var dataTable;

$(document).ready(function () {
    var url = window.location.search;

    if (url.includes("Done")) {
        loadDataTable("Done");
    }
    else {
        if (url.includes("Undone")) {
            loadDataTable("Undone");
        }
        else {
            loadDataTable();
        }
    }
});

function loadDataTable(filter) {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Customer/Tasks/GetAll?filter=" + filter
        },
        "columns": [
            { "data": "name", "widht": "70%" },
            { "data": "date", "widht": "70%" },
            { "data": "status", "widht": "70%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                    <div class="w-75 btn-group" role="group">
                        <a href="/Customer/Tasks/Upsert?id=${data}" class="btn btn-primary mx-2">
                            <i class="bi bi-pencil-square"></i>Edit
                        </a>
                        <a onClick=Delete('/Customer/Tasks/Delete/${data}')
                           class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i>Delete
                        </a>
                    </div>
                    `
                },
                "widht": "30%"
            },

        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You will not be able to go back!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete!',
        cancelButtonText: 'Cancel'
    }).then((result) => {
        if (result.isConfirmed) {
            //We will have to make an ajax request to hit the endpoint for delete
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        //Reload datatable
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}