//$("#FamilyEmergencyContact").css("display", "none");

//$("#chkEmergencyContact").on("change", function () {
//    if ($(this).is(':checked')) {
//        $("#FamilyEmergencyContact").css("display", "block");

//    } else {
//        $("#FamilyEmergencyContact").css("display", "none");
//        $("#FamilyEmergencyContact").val("");
//    }
//});
//update records
$(document.body).on('click', '.FamilyEdit', function () {
    $(".commonGrid").hide();
    $(".membrDetails").show();
    $('#formFamily').attr('action', '/Member/FamilyUpdate');
    var AppID = $(this).attr("data-val");
    $("#btnAddFamily").text("Update");
    $(".panel-body").scrollTop(0);
    GetFamilyById(AppID);
});

function GetFamilyById(AppID) {
    $.ajax({
        url: "/Member/GetFamilyById?id=" + AppID,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result != null) {
                $("#FamilyId").val(result.Id);
                $("#FamilyMemberID").val(result.MemberId);
                $("#FamilyName").val(result.Name);
                $("#Country").val(result.Country);
                //$("#Nationality option:selected").val(result.Nationality);
                //$("#Nationality option:selected").text(result.Nationality);
                $('#Nationality option[value="' + result.Nationality + '"]').attr("selected", "selected");
                $('#Nationality').val(result.Nationality).change();
                //$("#Nationality").val(result.Nationality);
                $("#MemberName").val(result.MemberName);
                $("#FamilyRelationship").val(result.Relationship);
                $("#FamilyYearOfBirth").val(result.YearOfBirth);
                $("#FamilyYearOfDeath").val(result.YearOfDeath);
                $("#FamilyMobile").val(result.Mobile);
                $("#FamilyEmail").val(result.Email);
                $("#FamilyAddress").val(result.Address);
                $('#ProvinceName').val(result.ProvinceName);
                $('#FamilyNationality').val(result.FamilyNationality);
                $('#FamilyProfession').val(result.FamilyProfession);
                $('#FamilyRemarks').val(result.FamilyRemarks);
                if (result.EmergencyContact != "Yes") {
                    $("#FamilyEmergencyContact").attr('checked', true);
                    //  $("#FamilyEmergencyContact").css("display", "block");
                    // $("#FamilyEmergencyContact").val(result.EmergencyContact);
                }
                else {
                    $("#FamilyEmergencyContact").attr('checked', false);
                }
                var valuedata = result.LangSpocken.split(",");
                    $('#LangSpocken').multipleSelect('setSelects', valuedata);
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
$(document.body).on('click', '.FamilyDelete', function () {
var AppID = $(this).attr("data-val");
    if (confirm("Do you want to delete ?")) {
        window.location.href = "/Member/FamilyDelete?id=" + AppID;
    }
});
