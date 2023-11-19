$(document).ready(function () {

    
    var weburl = "";
    if (!weburl) weburl = window.location.href
    var array = weburl.split('/');
    var no = array[array.length - 1];
    var update = array[array.length - 2];

    if (no != "AnalyseProfile.aspx") {
        if (update != "Update") {
            $("#CCSave_btn").hide();
            $("#CCUpdate_btn").hide();
            $("#headertext").text(" Profile Analysis Details");
        }
        else {
            $("#CCSave_btn").hide();
            $("#CCUpdate_btn").show();
            $("#headertext").text(" Update Profile Analysis Details");
        }


        LoadCarrierCouncellingDetailsById(no);
    }

    else {
        $("#CCUpdate_btn").hide();
        $("#CCSave_btn").show();
        $("#headertext").text(" Add Profile Analysis Details");
    }

});


// Add CarrierCouncelling details

$(function () {
    $('#CCSave_btn').click(function () {
        
        var a = $('#checkselected').is(':checked');
        var b = $('#checknotselected').is(':checked');
        if (a == true) {

           a = "selected"
        }
        if (b == true) {
           a = "Not selected";

        }
        var carrier =
        {
            RegisterNumber: $("#cc_RegisterNo").val(),
            Batch: $("#cc_Batch").val(),
            Course: $("#cc_Course").val(),
            StudentName: $("#cc_StudentName").val(),
            MobileNo: $("#cc_CellNo").val(),
            Specialization: $("#cc_Specialization").val(),
            Degree: $("#cc_Degree").val(),
            Father: $("#cc_Father").val(),
            Mother: $("#cc_Mother").val(),
            Siblings: $("#cc_Siblings").val(),
            Strength: $("#cc_Strength").val(),
            Weakness: $("#cc_Weakness").val(),
            StudentQuery: $("#cc_studentsQuery").val(),
            CMCRemarks: $("#cc_CMCRemarks").val(),
            //Authorized: $("#ddlcc_Authorizedby").val(),
            //Spare1: $("#dateon").val(),
            Spare2:a
        };

        $.ajax({
            type: "POST",
            url: "Student.asmx/AddProfileAnalysis",
            data: JSON.stringify({ 'profile': carrier }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                ClearCarrierCounselling();
                window.location.href = "ManageProfileAnalysis.aspx";


            }
        });
    });
});





function ClearCarrierCounselling() {
    $("#cc_RegisterNo").val("");
    $("#cc_Batch").val("");
    $("#cc_Course").val("");
    $("#cc_StudentName").val("");
    $("#cc_CellNo").val("");
    $("#cc_Specialization").val("");
    $("#cc_Degree").val("");
    $("#cc_Father").val("");
    $("#cc_Mother").val("");
    $("#cc_Siblings").val("");
    $("#cc_Strength").val("");
    $("#cc_Weakness").val("");
    $("#cc_studentsQuery").val("");
    $("#cc_CMCRemarks").val("");
}