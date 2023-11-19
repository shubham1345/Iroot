﻿$(document).ready(function () {

    
    var weburl = "";
    if (!weburl) weburl = window.location.href
    var array = weburl.split('/');
    var no = array[array.length - 1];
    var update = array[array.length - 2];

    if (no != "PlacementLeader.aspx") {
        if (update != "Update") {
            $("#PlacementSave_btn").hide();
            $("#PlacementLeaderUpdate_btn").hide();
            $("#place_headertext").text("PlacementLeader Details");
        }
        else {
            $("#PlacementSave_btn").hide();
            $("#PlacementLeaderUpdate_btn").show();
            $("#place_headertext").text(" Update PlacementLeader");
        }

        LoadPlacementDetailsById(no);
    }

    else {
        $("#PlacementLeaderUpdate_btn").hide();
        $("#PlacementSave_btn").show();
        $("#place_headertext").text(" Add PlacementLeader");
    }

});


// Add Placement Leader details

$(function () {
    $('#PlacementSave_btn').click(function () {
       
        var verchk = $('#checkselected').is(':checked');
        var nonverchk = $('#checknotselected').is(':checked');
        var status = "";
        if (verchk == false && nonverchk == false) {
            status = "";
        }
        else {

            if (verchk == true) {
                status = "verified";
            }
            else {
                status = "notverified";
            }
        }

        
        var carrier =
        {
            RegisterNumber: $("#Placement_ScholarNumber").val(),
            Batch: $("#Plmntldr_Batch").val(),
            Course: $("#Plmntldr_Course").val(),
            Specialization: $("#Plmntldr_Specialization").val(),
            StudentName: $("#Plmntldr_StudentName").val(),
            MobileNo: $("#Plmntldr_Mobile").val(),
            ResidenceLocation: $("#Plmntldr_ResidenceLocation").val(),
            Strengths: $("#Plmntldr_Strengths").val(),
            Weaknesses: $("#Plmntldr_Weaknesses").val(),
            ReasontobePlacementLeader: $("#Plmntldr_ReasontobePlacementLeaders").val(),
            Activities: $("#Plmntldr_Activities").val(),
            CMCRemarks: $("#pl_CMCRemarks").val(),
            //Authorized: $("#ddlPlmntldr_Authorized").val(),
            //PlacementDate: $("#datepicker").val(),
            Spare1: status,



        };

        $.ajax({
            type: "POST",
            url: "Student.asmx/AddPlacementLeader",
            data: JSON.stringify({ 'placementLeader': carrier }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                ClearPlacement();
                window.location.href = "ManagePlacementLeader.aspx";
            }
        });
    });
});




function ClearPlacement() {

    $("#PlacementId").val("");
    $("#Placement_ScholarNumber").val("");
    $("#Plmntldr_Batch").val("");
    $("#Plmntldr_Course").val("");
    $("#Plmntldr_Specialization").val("");
    $("#Plmntldr_StudentName").val("");
    $("#Plmntldr_Mobile").val("");
    $("#Plmntldr_ResidenceLocation").val("");
    $("#Plmntldr_Strengths").val("");
    $("#Plmntldr_Weaknesses").val("");
    $("#Plmntldr_ReasontobePlacementLeaders").val("");
    $("#Plmntldr_Activities").val("");
    $("#Plmntldr_Authorized").val("");
    $("#datepicker").val("");

}