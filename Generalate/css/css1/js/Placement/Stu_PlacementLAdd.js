$(document).ready(function () {
    GetAllPlacementDetails();
   // LoadPlacementDetailsById(no);
    
    //var weburl = "";
    //if (!weburl) weburl = window.location.href
    //var array = weburl.split('/');
    //var no = array[array.length - 1];
    //var update = array[array.length - 2];

    //if (no != "PlacementLeader.aspx") {
    //    if (update != "Update") {
    //        $("#PlacementSave_btn").hide();
    //        $("#PlacementUpdate_btn").hide();
    //        $("#place_headertext").text("PlacementLeader Details");
    //    }
    //    else {
    //        $("#PlacementSave_btn").hide();
    //        $("#PlacementUpdate_btn").show();
    //        $("#place_headertext").text("Update PlacementLeader");
    //    }

    //    LoadPlacementDetailsById(no);
    //}

    //else {
    //    $("#PlacementUpdate_btn").hide();
    //    $("#PlacementSave_btn").show();
    //    $("#place_headertext").text("Add PlacementLeader");
    //}

});



function GetAllPlacementDetails() {
    var tb = document.getElementById('Studenttbl');
    //while (tb.rows.length > 1) {
    //    tb.deleteRow(1);
    //}

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "Student.asmx/GetAllPlacementLeader",
        //data: "{'RegNo' : '" + RegstrNo + "'}",
        dataType: "json",
        success: function (data) {
            for (var i = 0; i < data.d.length; i++) {
                $("#Studenttbl").append("<tr><td>" + data.d[i].PlacementLeaderId + "</td><td hidden='hidden'>" + data.d[i].RegisterNumber + "</td><td>" + " <a href='Stu_PlacementLeaderFullView.aspx/Stu_placementlederView'>" + data.d[i].StudentName
                     + "<a/></td><td>" + data.d[i].Course + "</td><td>" + data.d[i].Batch + "</td><td>" + data.d[i].Specialization + "" + "</td><tr>'");


            }

        },
        error: function (result) {
            alert("Error");
        }
    });
}

// Add ChageofSpecialization details

$(function () {
    $('#PlacementSave_btn').click(function () {
        
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
            Activities: $("#Plmntldr_Activities").val()
          //  Authorized: $("#Plmntldr_Authorized").val(),
          //  PlacementDate: $("#datepicker").val()

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
  //  $("#Plmntldr_Activities").val("");
  //  $("#Plmntldr_Authorized").val("");
    $("#datepicker").val("");

}