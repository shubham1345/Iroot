$(document).ready(function () {

    $.ajax({
        url: "/Home/GetTotalDetails",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            //clearAppoinmentall();

            if (result != null) {

                $("#").val(result.Id);
                $("#FamilyMemberID").val(result.MemberId);
                $("#FamilyName").val(result.Name);
                $("#FamilyRelationship").val(result.Relationship);
                $("#FamilyYearOfBirth").val(result.YearOfBirth);
                $("#FamilyYearOfDeath").val(result.YearOfDeath);
                $("#FamilyMobile").val(result.Mobile);
                $("#FamilyEmail").val(result.Email);
                $("#FamilyAddress").val(result.Address);
                $("#EmergencyContact").val(result.EmergencyContact);
                if (result.EmergencyContact != "" || result.EmergencyContact != null) {
                    $("#chkEmergencyContact").attr('checked', true);
                    $("#FamilyEmergencyContact").css("display", "block");
                    $("#FamilyEmergencyContact").val(result.EmergencyContact);
                }


            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);

        }



});