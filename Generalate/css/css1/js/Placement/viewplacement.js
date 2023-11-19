$(document).ready(function () {
    var weburl = "";
    if (!weburl) weburl = window.location.href
    var array = weburl.split('/');
    var no = array[array.length - 1];
    var sRole = '<%= Session["role"] %>';
    GetAllStudentPlacementDetails(no);
    GetAllStudentInterviewDetails(no);
    GetAllStudentTrainingDetails(no);
    //GetAllStudentcompanyDetails(no);
    //hashNoHistory(link);
   // hashNoHistory1(link);

});


function GetCommunicationById(id)
{
    location.href = "/UX/Viewcompanydetails.aspx?id="+id;
}
function GetCommunicationById1(id)
{
    location.href = "/UX/Viewcompanydetails1.aspx?id="+id;
}
function GetCommunicationById2(id)
{
    location.href = "/UX/Viewcompanydetails2.aspx?id="+id;
}



function GetAllStudentPlacementDetails(no) {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "Student.asmx/GetAllCommunicationDetails",
        dataType: "json",
        success: function (data){
           
            for (var i = 0; i < data.d.length; i++) {
                if (data.d[i].MessageType == "1") {
                    
                    $("#placement").append("<tr><td>" + '<p>Placement</p>' + "</td><td>" + data.d[i].CommunictionId  + "</td><td >" + data.d[i].startDate + "</td><td>" + data.d[i].Batch + "</td><td>" + data.d[i].Course + "</td><td>" + data.d[i].Specialization
                     + "</td><td>" + '<a href="Viewcompanydetails.aspx" onclick="GetCommunicationById(' + data.d[i].CommunictionId + ')">click me</a>'
                     + "</td><td>" + data.d[i].LastRegistrationDate + "</td><td>" + data.d[i].LatestBy
                     + "</td><td>" + '<a href="ViewStudentcomm.aspx" onclick="return GetCommunicationById(' + data.d[i].CommunictionId + ')">Apply</a>'
                     + "</td><td>" + data.d[i].user + "</td></tr>");
                }
            }

        },
        error: function (result) {
            alert("Error");
        }
    });
}

function GetAllStudentInterviewDetails(no) {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "Student.asmx/GetAllCommunicationDetails",
        dataType: "json",
        success: function (data) {
            for (var i = 0; i < data.d.length; i++) {
                if (data.d[i].MessageType == "2") {
                    $("#interview").append("<tr><td>" + '<p>Interview</p>' + "</td><td>" + data.d[i].CommunictionId + "</td><td >" + data.d[i].interviewDate + "</td><td>" + data.d[i].Interviewtime
                     + "</td><td>" + '<a href="Viewcompanydetails.aspx" onclick="GetCommunicationById(' + data.d[i].CommunictionId + ')">Get Details</a>'
                     + "</td><td>" + data.d[i].Batch + "</td><td>" + data.d[i].Course
                     + "</td><td>" + data.d[i].Specialization
                     + "</td><td>" + data.d[i].user + "</td></tr>");
                }
            }

        },
        error: function (result) {
            alert("Error");
        }
    });
}

function GetAllStudentTrainingDetails(no) {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "Student.asmx/GetAllCommunicationDetails",
        dataType: "json",
        success: function (data) {
            for (var i = 0; i < data.d.length; i++) {
                if (data.d[i].MessageType == "3") {
                    $("#training").append("<tr><td>" + '<p>Training Session</p>' + "</td><td>" + data.d[i].CommunictionId + "</td><td >" + data.d[i].startDate + "</td><td>" + data.d[i].Batch
                     + "</td><td>" + data.d[i].Course + "</td><td>" + data.d[i].Specialization
                     + "</td><td>" + '<a href="Viewcompanydetails2.aspx" onclick="GetCommunicationById(' + data.d[i].CommunictionId + ')">Get Details</a>'
                     + "</td><td>" + data.d[i].ILastRegistrationDate
                     + "</td><td>" + data.d[i].user + "</td></tr>");
                }
            }

        },
        error: function (result) {
            alert("Error");
        }
    });
}




