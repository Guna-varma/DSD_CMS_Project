$(document).ready(function () {
    localDataTable();
});

function localDataTable() {
    dataTable = $('#settingsData').DataTable({
        "ajax": { url: '/customer/settings/getAll' },
        "columns": [
            { data: 'propertyName', "width": "15%" },
            { data: 'propertyValue', "width": "75%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                                    <a href="/customer/settings/upsert?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i>Edit</a>
                                </div>`
                },
                "width": "10%"
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            });
        }
    });
}


//<a onClick=Delete('/customer/settings/delete/${data}') class="btn btn-danger mx-2" > <i class="bi bi-trash-fill"></i>Delete</a >