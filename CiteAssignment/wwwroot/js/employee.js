var dataTable;



function loadDataTable() {
    dataTable = $("#tblData").DataTable({
        "ajax": {
            "url": "/Customer/Employee/GetAll"
        },
        "columns": [
            { "data": "name", "width": "20%" },
            {
                "data": "birthDate",
                "render": function (data) {
                    return `
                           ${moment(data).format('D/M/YYYY')}
                             `
             
            }, "width": "20%"   },
            
            { "data": "hasCar", "width": "20%" },
            { "data": "streetAddress", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a href="/Customer/Employee/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
                                    <i class="fas fa-edit"></i>
                                </a>
                                <a onclick=Delete("/Customer/Employee/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer">
                                    <i class="fas fa-trash-alt"></i>
                                </a>
                            </div>
                            `
                }, "width": "60%"
            }
        ]
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