$(document).ready(function () {

    GetAllJobPostDetails();
});

//Get All COS
function GetAllJobPostDetails() {
    //var tb = document.getElementById('Studenttbl');
    //while (tb.rows.length > 1) {
    //    tb.deleteRow(1);
    //}

    $("#jobpost").empty();

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "Student.asmx/GetAllJobPost",
        //data: "{'RegNo' : '" + RegstrNo + "'}",
        dataType: "json",
        success: function (data) {
            for (var i = 0; i < data.d.length; i++) {
                //$("#Studenttbl").append("<tr><td hidden='hidden'>" + data.d[i].Id + "</td><td><span style='background-color:lavender'>" + data.d[i].Title + "<hr/></span>" + data.d[i].Description
                //    + "<br/><br/>" + data.d[i].Postedby + "<br/><br/>" + data.d[i].Postedtime + "<br/>"
                //    + '<a href="#" onclick="DeleleJobsheet(' + data.d[i].FId + ')">Interested</a> | <a href="#" onclick="DeleleJobsheet(' + data.d[i].FId + ')">NotInterested</a></td><tr>');

                $("#jobpost").append("<h3 style='color:#09c;'>" + data.d[i].Title + "</h3><hr/>");
                $("#jobpost").append("<h6><b>Company Name &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</b>" + data.d[i].CompanyName + "</h6>");
                $("#jobpost").append("<h6><b>Interview Date&Time &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</b>" + data.d[i].InterviewDateTime + "</h6>");
                $("#jobpost").append("<h6><b>Venue &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</b>" + data.d[i].Venue + "</h6>");
                $("#jobpost").append("<h6><b>Experience &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</b>" + data.d[i].Experience + "</h6>");
                $("#jobpost").append("<h6><b>Keyskills &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</b>" + data.d[i].Keyskills + "</h6>");
                $("#jobpost").append("<h6><b>JobDescription &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</b>" + data.d[i].JobDescription + "</h6>");
                $("#jobpost").append("<h6><b>JobLocation &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</b>" + data.d[i].JobLocation + "</h6>");
                $("#jobpost").append("<h6><b>Salary &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</b>" + data.d[i].Salary + "</h6>");
                $("#jobpost").append("<h6><b>Postedby &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</b>" + data.d[i].Postedby + "</h6>");
                $("#jobpost").append("<h6><b>Posted Date&Time &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</b>" + data.d[i].Postedtime + "</h6>");
                $("#jobpost").append('<input type="button" value="Interested" class="btn btn-info btn-sm" onclick="Interested(' + data.d[i].JobId + ')"></button> <input type="button" class="btn btn-info btn-sm" value="NotInterested" onclick="NotInterested(' + data.d[i].JobId + ')"></button><hr/>');
            }

        },
        error: function (result) {
            alert("Error");
        }
    });
}

//NotInterested
function NotInterested(ID) {
    
        $.ajax({
            url: "Student.asmx/NotInterested",
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

//Interested
function Interested(ID) {
    
    
        $.ajax({
            url: "Student.asmx/Interested",
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