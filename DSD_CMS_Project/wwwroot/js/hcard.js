$(document).ready(function () {
    localDataTable();
});

function localDataTable() {
    dataTable = $('#hcdata').DataTable({
        "ajax": { url: '/Customer/HealthCard/getAll' },
        "columns": [
            { data: 'sr', "width": "10%" },
            { data: 'customer', "width": "20%" },
            { data: 'mileage', "width": "10%" },
            { data: 'treadDepth', "width": "20%" },
            { data: 'breakpad', "width": "15%" },
            { data: 'breakDisc', "width": "15%" },
            { data: 'battery', "width": "10%" }
        ]
    });
}