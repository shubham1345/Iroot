$(document).on("click", ".Edit", function () {
  //debugger;
    var id = $(this).attr("data-val");
    GetInstitutionById(id);
    $('#FormInstitution').attr('action', '/Institution/Update');
    $("#btnAddInstitution1").text("Update");
});
function GetInstitutionById(id) {
    $.ajax({
        url: "/Institution/GetInstitutionById?id=" + id,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
          //debugger;
            $("#ID").val(result.Id);
            $("#MyID").val(result.MyId);
            $("#Tial").val(result.Tial);
            $("#Date").val(result.Date);
            $("#Description").val(result.Description);
            $("#file").val(result.FileName);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    }); return false;
}
$(document).on('click', '.Delete', function () {
  //debugger;
    var id = $(this).attr("data-val");
    if (window.confirm('Do You want To Delete?')) {
        DeleteInstitution(id);
    };
});
function DeleteInstitution(id)
{
    $.ajax({
        url: "/IdGenerate/DeleteInstitution?id" + id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
          //debugger;
            if (result == "Success") {
                location.reload();
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
