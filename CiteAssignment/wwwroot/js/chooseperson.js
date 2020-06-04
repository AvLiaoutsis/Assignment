$(document).ready(function () {
    var selecteduser;

    selecteduser = $("#myselect option:selected").attr("id");

    document.getElementById("ChosenId").value = selecteduser;

    $("#myselect").change(function () {
        selecteduser = $("#myselect option:selected").attr("id");

        document.getElementById("ChosenId").value = selecteduser;
        console.log("mpike");


    });

});