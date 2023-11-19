$(document.body).on('click', '.HealthEdit', function () {
    $(".commonGrid").hide();
    $(".membrDetails").show();
  //debugger;
    $('#HealthForm').attr('action', '/Member/UpdateHealthDetail');
    var HealthID = $(this).attr("data-val");
    $("#btnSaveHealth").text("Update");
    $(".panel-body").scrollTop(0);
    GetHealthById(HealthID);
});
function GetHealthById(HealthId) {
    $.ajax({
        url: "/Member/GetHealthById?id=" + HealthId,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $("#Title").val(result.Title);
            $("#HealthId").val(result.HealthId);
            $("#SirName select").val(result.SirName);
            $("#Name").val(result.Name);
            $("#MemberID").val(result.MemberID);
            $("#FromDate").val(result.FromDate);
            $("#ToDate").val(result.ToDate);
            $("#Complaint").val(result.Complaint);
            $("#Diagnosis").val(result.Diagnosis);
            $("#Doctor").val(result.Doctor);
            $("#Hospital").val(result.Hospital);
            $("#HealthDescription").val(HealthDescription);
            $('#ProvinceName').val(result.ProvinceName);
            $("#healthfile").text(result.Spare1);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    }); return false;
}

function loadDataListItems() {
    $.ajax({
        url: "../CommonDataListItems/GetDatalistItemsByModuleName/?DlistName=General",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            $("#generalst").empty();
            for (var i = 0; i < result.length; i++) {
                $("#generalst").append("<option value='" + result[i].DataListItemName + "'></option>");
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

$(document.body).on('click', '.HealthDelete', function () {
  //debugger;
    var HealthId = $(this).attr("data-val");
    if (confirm("Do you want to delete ?")) {
              window.location.href = "/Member/HealthDelete?id=" + HealthId;
    }
});

