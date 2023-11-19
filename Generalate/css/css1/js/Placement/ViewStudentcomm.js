
//$(document).ready(function () {
//    alert("Error");

//    var weburl = "";
//    if (!weburl) weburl = window.location.href
//    var array = weburl.split('/');
//    var no = array[array.length - 1];
//    var sRole = '<%= Session["role"] %>';
//    GetAllStudentPlacementDetails();
//    GetAllStudentInterviewDetails();
//    GetAllStudentTrainingDetails();



//});

alert("hello");
$(document).ready(function () {
    alert("rgdsuhyuil");
    var weburl = "";
    if (!weburl) weburl = window.location.href
    var array = weburl.split('/');
    var no = array[array.length - 1];
    var sRole = '<%= Session["role"] %>';
    //LoadCommunicationDetails(no);
});


//Get All COS
function GetAllStudentPlacementDetails() {
    var tb = document.getElementById('Studenttbl');
    while (tb.rows.length > 1) {
        tb.deleteRow(1);
    }
    var html = "";

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "Student.asmx/GetAllCommunicationDetails",
        //data: "{'RegNo' : '" + RegstrNo + "'}",
        dataType: "json",
        success: function (data){
            for (var i = 0; i < data.d.length; i++) {
                $("#placement").append("<tr><td hidden='hidden'>" + data.d[i].StartDate + "</td><td>" + data.d[i].Batch + "</td><td>" + data.d[i].Course
                     + "</td><td>" + data.d[i].Specialization + "</td><td>" + data.d[i].CompanyName + "</td><td>" + data.d[i].LastRegistrationDate + "</td><td>" + data.d[i].LatestBy + "</td><td>"
                     + '<a href="ViewPlacementLeader.aspx/' + data.d[i].PlacementLeaderId + '">View</a> | <a href="PlacementLeader.aspx/Update/' + data.d[i].PlacementLeaderId + '">Edit</a> | <a href="#" onclick="DelelePlacement(' + data.d[i].PlacementLeaderId + ')">Delete</a></td><tr>');

                //+ '<a href="PlacementLeader.aspx/' + data.d[i].PlacementLeaderId + '">View</a> | <a href="PlacementLeader.aspx/Update/' + data.d[i].PlacementLeaderId + '">Edit</a> | <a href="#" onclick="DelelePlacement(' + data.d[i].PlacementLeaderId + ')">Delele</a></td><tr>');


            }

            for (var i = 0; i < data.d.length; i++) {
                html += "<tr>";
                html += "<td hidden='hidden'>" + data.d[i].StartDate + "</td>";
                html += "<td>" + data.d[i].Batch + "</td>";
                html += "<td>" + data.d[i].Course + "</td>";
                html += "<td>" + data.d[i].Specialization + "</td>";
                html += "<td>" + data.d[i].CompanyName + "</td>";
                html += "<td>" + data.d[i].LastRegistrationDate + "</td>";
                html += "<td>" + data.d[i].LatestBy + "</td>";
                html += "<td>" + data.d[i].Authorized + "</td>";
                html += "<td>" + data.d[i].PlacementDate + "</td>";
                html += "<td>";
                html += '<a href="ViewPlacementLeader.aspx/' + data.d[i].PlacementLeaderId + '">View</a>&nbsp&nbsp;<a href="PlacementLeader.aspx/Update/' + data.d[i].PlacementLeaderId + '">Edit</a>&nbsp&nbsp;<a href="#" onclick="DelelePlacement(' + data.d[i].PlacementLeaderId + ')">Delete</a>';
                html += "</td>";
                html += "</tr>";
            }
            
            

            //Delete AcademicDetail
            function DelelePlacement(ID) {
                var ans = confirm("Are you sure you want to delete this Record?");
                if (ans) {
                    $.ajax({
                        url: "Student.asmx/DeletePlacementLeader",
                        type: "POST",
                        contentType: "application/json;charset=UTF-8",
                        dataType: "json",
                        data: "{id:'" + ID + "'}",
                        success: function (result) {
                            //GetAllPlacementDetails();
                            window.location.href = "/UX/ManagePlacementLeader.aspx";
                        },
                        error: function (errormessage) {
                            alert(errormessage.responseText);
                        }
                    });
                }
            };
        }
    }