$(document).ready(function () {
    localDataTable();
});

function localDataTable() {
    dataTable = $('#devicesData').DataTable({
        "ajax": { url: '/customer/devices/getAll' },
        "columns": [
            { data: 'dealer.dealerName', "width": "50px" },
            { data: 'showroom.showroomName', "width": "50px" },
            { data: 'deviceName', "width": "50px" },
            { data: 'deviceUDID', "width": "50px" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                                    <a href="/customer/devices/upsert?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i>Edit</a>
                                    <a onClick=Delete('/customer/devices/delete/${data}') class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i>Delete</a>
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