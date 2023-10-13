$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    $('#usersTable').DataTable({
        "ajax": { url: '/user/getall' },
        "columns": [
            { data: 'fullName', "width": "30%" },
            { data: 'email', "width": "30%" },
            { data: 'city', "width": "15%" },
            { data: 'role.name', "width": "5%" },
            { data: 'emailConfirmed', "width": "5%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                        <a class="btn btn-warning mx-2" href="/user/edit?id=${data}">Edit</a>
                        <a class="btn btn-danger mx-2" href="/user/delete?id=${data}">Delete</a>
                    </div>`
                },
                "width": "10%"
            }
        ]
    });
}