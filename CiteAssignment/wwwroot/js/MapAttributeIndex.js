$(document).ready(function () {
    var selectedvalue = $("#myselect option:selected").attr("id");



    $("#ButtonSubmit").attr("href", "/Customer/Map/GetEmployeesUponAttribute/" + selectedvalue);

    $("#myselect").on("change", function () {

        var selectedvalue = $("#myselect option:selected").attr("id");
        $("#ButtonSubmit").attr("href", "/Customer/Map/GetEmployeesUponAttribute/" + selectedvalue);


    });
});   