$(document).ready(function () {
    localDataTable();
});

function localDataTable() {
    dataTable = $('#variantData').DataTable({
        "ajax": { url: '/customer/variant/getAll' },
        "columns": [
            { data: 'carModel.modelName', "width": "20%" },
            { data: 'variantName', "width": "20%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                                    <a href="/customer/variant/upsert?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i>Edit</a>
                                    <a onClick=Delete('/customer/variant/delete/${data}') class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i>Delete</a>
                                </div>`
                },
                "width": "20%"
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