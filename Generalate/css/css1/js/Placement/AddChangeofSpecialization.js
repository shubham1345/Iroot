﻿$(document).ready(function () {

  
    var weburl = "";
    if (!weburl) weburl = window.location.href
    var array = weburl.split('/');
    var no = array[array.length - 1];
    var update = array[array.length - 2];

    if (no != "ChangeofSpecialization.aspx") {
        if (update != "Update") {
            $("#CosSave_btn").hide();
            $("#CosUpdate_btn").hide();
            $("#cos_headertext").text(" Change of Specialization Details");
        }
        else {
            $("#CosSave_btn").hide();
            $("#CosUpdate_btn").show();
            $("#cos_headertext").text(" Add Change Specialization Request");
        }


        LoadCOSDetailsById(no);
    }

    else {
        $("#CosUpdate_btn").hide();
        $("#CosSave_btn").show();
        $("#cos_headertext").text(" Add Change Specialization Request");
         }
          
});


// Add ChageofSpecialization details





$(function () {
    $('#CosSave_btn').click(function () {
      
        //var verchk = $('#checkselected').is(':checked');
        //var nonverchk = $('#checknotselected').is(':checked');
        //var status = "";

        //if (verchk == false && nonverchk == false) {
        //    status = "";
        //}
        //else {

        //    if (verchk == true) {
        //        status = "verified";
        //    }
        //    else {
        //        status = "notverified";
        //    }
        //}
        var status = "";
        var carrier =
        {
            COSDate: $("#cos_Date").val(),
            RegisterNumber: $("#cos_RegisterNo").val(),
            StudentName: $("#cos_StudentName").val(),
            Batch: $("#cos_Batch").val(),
            //RollNo: $("#cos_RollNo").val(),
            CurrentSpecialization: $("#cos_From").val(),
            Changingspecialization: $("#cos_Toddl").val(),
            Reason: $("#cos_Reason").val(),
            CMCRemarks: "",
            //Authorized: $("#ddlcc_Authorized").val(),
            //Spare1: $("#dateon").val(),
            Spare2: status

        };

        $.ajax({
            type: "POST",
            url: "Student.asmx/AddCOS",
            data: JSON.stringify({ 'Change': carrier }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                ClearCOS();
                window.location.href = "ManageChangeofSpecialization.aspx";


            }
        });
    });
});


function ClearCOS() {
    $("#cos_ID").val("");
    $("#cos_Date").val("");
    $("#cos_RegisterNo").val("");
    $("#cos_StudentName").val("");
    $("#cos_Batch").val("");
    $("#cos_RollNo").val("");
    $("#cos_From").val("");
    $("#cos_To").val("");
    $("#cos_Reason").val("");
}