$(document).ready(function () {

    
    var weburl = "";
    if (!weburl) weburl = window.location.href
    var array = weburl.split('/');
    var no = array[array.length - 1];
    var update = array[array.length - 2];

    //if (no != "AddCarrierCounselling.aspx") {
    //    if (update != "Update") {
    //        $("#CarrierCouncellingSave_btn").hide();
    //        $("#CarrierCouncellingUpdate_btn").hide();
    //        $("#headertext").text("Carrier Councelling Details");
    //    }
    //    else {
    //        $("#CarrierCouncellingSave_btn").hide();
    //        $("#CarrierCouncellingUpdate_btn").show();
    //        $("#headertext").text(" Update Carrier Councelling Details");
    //    }


    //    LoadCarrierCouncellingDetailsById(no);
    //}

    //else {
    //    $("#CarrierCouncellingUpdate_btn").hide();
    //    $("#CarrierCouncellingSave_btn").show();
    //    $("#headertext").text(" Add Carrier Councelling Details");
    //}

});


// Add CarrierCouncelling details

$(function () {
    $('#CarrierCouncellingSave_btn').click(function () {
        

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
            Sibiling: $("#cc_Siblings").val(),
            Strength: $("#cc_Strengths").val(),
            Weakness: $("#cc_Weaknesses").val(),
            StudentQuery: $("#cc_studentsQuery").val(),
            CMCRemarks: $("#cc_CMCRemarks").val(),
            Authorized: $("#ddlcc_Authorized").val()
        };

        $.ajax({
            type: "POST",
            url: "Student.asmx/AddCarrierCouncelling",
            data: JSON.stringify({ 'Career': carrier }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                ClearCarrierCounselling();
                window.location.href = "Carrier.aspx";


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
    $("#cc_Strengths").val("");
    $("#cc_Weaknesses").val("");
    $("#cc_studentsQuery").val("");
    $("#cc_CMCRemarks").val("");
    $("#ddlcc_Authorized").val("");
}


