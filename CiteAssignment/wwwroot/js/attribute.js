﻿var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $("#tblData").DataTable({
        "ajax": {
            "url": "/Customer/Attribute/GetAll"
        },
        "columns": [
            { "data": "attR_Name", "width": "20%" },
            { "data": "attR_Value", "width": "20%" },
            {
                "data": "attR_ID",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a href="/Customer/Attribute/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
                                    <i class="fas fa-edit"></i>
                                </a>
                                <a onclick=Delete("/Customer/Attribute/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer">
                                    <i class="fas fa-trash-alt"></i>
                                </a>
                            </div>
                            `
                }, "width": "20%"
            }
        ],
        "columnDefs": [{
            "targets": 2,
            "orderable": false,
        }]
    });
}


function Delete(url) {
    swal({
        title: "Are you sure you want to Delete",
        text: "You will not be able to restore the data!",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "Delete",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();

                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });

        }
    });
}