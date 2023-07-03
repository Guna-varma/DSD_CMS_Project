//$(document).ready(function () {
//    localDataTable();
//});

//function localDataTable() {
//    var dataTable = $('#dealersData').DataTable({
//        "ajax": {
//            url: '/Customer/Dealers/getAll',
//            error: function (xhr, error, thrown) {
//                console.log("Data retrieval error:", error);
//                console.log("Thrown error:", thrown);
//            }
//        },
//        "columns": [
//            { data: 'dealerName', "width": "20%" },
//            { data: 'dealerLocation', "width": "20%" },
//            { data: 'contactNo', "width": "20%" },
//            {
//                data: 'id',
//                "render": function (data) {
//                    return `<div class="w-75 btn-group" role="group">
//                                <a href="/Customer/Dealers/upsert?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i>Edit</a>
//                                <a onClick="Delete('/Customer/Dealers/delete/${data}')"" class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i>Delete</a>
//                            </div>`;
//                },
//                "width": "40%"
//            }
//        ]
//    });
//}

//function Delete(url) {
//    Swal.fire({
//        title: 'Are you sure?',
//        text: "You won't be able to revert this!",
//        icon: 'warning',
//        showCancelButton: true,
//        confirmButtonColor: '#3085d6',
//        cancelButtonColor: '#d33',
//        confirmButtonText: 'Yes, delete it!'
//    }).then((result) => {
//        if (result.isConfirmed) {
//            $.ajax({
//                url: url,
//                type: 'DELETE',
//                success: function (data) {
//                    dataTable.ajax.reload();
//                    toastr.success(data.message);
//                },
//                error: function (xhr, error, thrown) {
//                    console.log("Delete request error:", error);
//                    console.log("Thrown error:", thrown);
//                }
//            });
//        }
//    });
//}



$(document).ready(function () {
    localDataTable();
});

function localDataTable() {
    dataTable = $('#dealersData').DataTable({
        "ajax": { url: '/Customer/Dealers/getAll' },
        "columns": [
            { data: 'dealerName', "width": "20%" },
            { data: 'dealerLocation', "width": "20%" },
            { data: 'contactNo', "width": "20%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                                    <a href="/Customer/Dealers/upsert?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i>Edit</a>
                                    <a onClick=Delete('/Customer/Dealers/delete/${data}') class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i>Delete</a>
                                </div>`
                },
                "width": "40%"
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