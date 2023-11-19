$(document).ready(function () {

    GetAllJobPostDetails();
});

//Get All COS
function GetAllJobPostDetails() {
    var tb = document.getElementById('Studenttbl');
    while (tb.rows.length > 1) {
        tb.deleteRow(1);
    }

    $("#jobpost").empty();

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "Student.asmx/GetAllJobPost",
        //data: "{'RegNo' : '" + RegstrNo + "'}",
        dataType: "json",
        success: function (data) {
            for (var i = 0; i < data.d.length; i++) {
                $("#Studenttbl").append("<tr><td hidden='hidden'>" + data.d[i].JobId + "</td><td>" + data.d[i].Title + "</td><td>" + data.d[i].CompanyName
                    + "</td><td>" + data.d[i].Keyskills + "</td><td>" + data.d[i].JobDescription + "</td><td>" + data.d[i].Postedby + "</td><td>" + data.d[i].Postedtime + "</td><td>"
                    + '<a href="PostJobs.aspx/' + data.d[i].JobId + '">View</a> | <a href="PostJobs.aspx/Update/' + data.d[i].JobId + '">Edit</a> | <a href="#" onclick="DeleleJobsheet(' + data.d[i].JobId + ')">Delete</a></td><tr>');
            }

        },
        error: function (result) {
            alert("Error");
        }
    });
}

//Interested
function DeleleJobsPosts(ID) {
    

    $.ajax({
        url: "Student.asmx/DeleteJobPost",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        data: "{id:'" + ID + "'}",
        success: function (result) {
            GetAllJobsheetDetails();

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}