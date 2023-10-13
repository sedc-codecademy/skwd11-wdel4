$(document).ready(function () {
    loadDataTable()
});

function loadDataTable() {
    $('#categoryTable').DataTable({
        "ajax": { url: '/productCategory/getall' },
        "columns": [
            { data: 'name', "width": "50" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                        <a class="btn btn-primary mx-2"  href="/productCategory/details?id=${data}">Details</a>
                        <a class="btn btn-warning mx-2" href="/productCategory/edit?id=${data}">Edit</a>
                        <a class="btn btn-danger mx-2" href="/productCategory/delete?id=${data}">Delete</a>
                    </div>`
                },
                "width": "50%"
            }
        ]
    });
}