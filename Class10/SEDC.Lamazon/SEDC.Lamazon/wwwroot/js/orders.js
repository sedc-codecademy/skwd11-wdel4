$(document).ready(function () {
    var urlParams = new URLSearchParams(window.location.search);

    var status = urlParams.get('status');
    if (status == null) {
        loadDataTable("All");
    }
    else {
        loadDataTable(status);
    }

});

var orderStatusName = {
    1: "Pending",
    2: "Accepted",
    3: "Rejected",
    4: "Proccesing",
    5: "Shipped",
    6: "Cancelled",
    7: "Refunded"
};

function loadDataTable(status) {
    $('#ordersTable').DataTable({
        "ajax": { url: `/order/getall?status=${status}` },
        "columns": [
            { data: 'id', "width": "5%" },
            { data: 'name', "width": "25%" },
            { data: 'phoneNumber', "width": "20%" },
            { data: 'user.email', "width": "20%" },
            {
                data: 'orderStatus',
                "render": function (data) {
                    return orderStatusName[data] || 'Unkown'
                },
                "width": "10%"
            },
            { data: 'totalPrice', "width": "10%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                        <a class="btn btn-warning mx-2" href="/order/details?id=${data}">Details</a>
                    </div>`
                },
                "width": "10%"
            }
        ]
    });
}