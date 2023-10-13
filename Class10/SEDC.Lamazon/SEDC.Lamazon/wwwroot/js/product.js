$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    $('#productsTable').DataTable({
        "ajax": { url: '/product/getall' },
        "columns": [
            { data: 'name', "width": "40%" },
            { data: 'productCategory.name', "width": "40%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                        <a class="btn btn-primary mx-2"  href="/product/productDetails?id=${data}">Details</a>
                        <a class="btn btn-warning mx-2" href="/product/edit?id=${data}">Edit</a>
                        <a class="btn btn-danger mx-2" href="/product/delete?id=${data}">Delete</a>
                    </div>`
                }
            }
        ]

    });
}