$(document).ready(function () {
    localDataTable();
});

var dataTable;

function localDataTable() {
    dataTable = $('#inventoryData').DataTable({
        "ajax": { url: '/customer/insideInventory/getAll' },
        "columns": [
            { data: 'insideInventoryName', "width": "20%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                                    <a href="/customer/insideInventory/upsert?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i>Edit</a>
                                    <button onClick="deleteItem(${data})" class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i>Delete</button>
                                </div>`;
                },
                "width": "20%"
            }
        ]
    });
}

function deleteItem(id) {
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
                url: '/customer/insideInventory/delete/' + id,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                },
                error: function () {
                    toastr.error('An error occurred while deleting the item.');
                }
            });
        }
    });
}
