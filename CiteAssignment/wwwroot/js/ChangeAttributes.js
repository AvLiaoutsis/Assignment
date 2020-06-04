$("#Check").click(function () {
    var selectedattributes = [];

    var i;
    for (i = 0; i < document.getElementById('NumDropDowns').value; i++) {
        var option = $("#dropdown-" + i + " option:selected")[0].getAttribute("data-id");
        selectedattributes.push(option);

    }
    var personid = document.getElementById('PersonId').value

    var combo = { EmployeeId: personid, AttributeIds: selectedattributes }
    var combojson = JSON.stringify(combo);

    $.ajax({
        type: "POST",
        url: "/Customer/Employee/ChangeAttributes",
        data: combojson,
        contentType: "application/json; charset=utf-8",
        success: function () {
            toastr.success('New Attributes have been Added');
        },
        error: function () {
            toastr.error('Sorry, something bad happened');
        }
    });

});