$(document).ready(function () {
    
    var weburl = "";
    if (!weburl) weburl = window.location.href
    var array = weburl.split('/');
    var no = getUrlVars()["id"];

    getallstudentplacementdetails1(no);

});
function getUrlVars() {
    var vars = [], hash;
    var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < hashes.length; i++) {
        hash = hashes[i].split('=');
        vars.push(hash[0]);
        vars[hash[0]] = hash[1];
    }
    return vars;
}

function getallstudentplacementdetails1(no) {
    
   
    $.ajax({
        url: "Student.asmx/GetCommunicationById",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        data: "{'id' : '" + no + "'}",
        success: function (data) {
            for (var i = 0; i < data.d.length; i++) 
                if (parseInt(no) == data.d[i].CommunictionId) {
                    var record = data.d[i];
                   

                        $("#placement1").append("<tr><td><b>start date</b><td>" + record.startDate + "</td colspan='2'><td ><b>end date</b></td><td>" + record.endDate + "</td></tr>"
                                           + "<tr><td><b>Batch</b><td>" + record.Batch + "</td><td><b>Year</b><td>" + record.Year + "</td></tr>"
                                           + "<tr><td><b>company code</b><td>" + record.companycode + "</td><td><b>job code</b></td><td>" + record.jobcode + "</td></tr>"
                                           + "<tr><td><b>sector </b><td>" + record.sector + "</td><td><b>jd recvd on</b></td><td>" + record.jdrecievedon + "</td></tr>"
                                           + "<tr><td><b>Selection Date </b><td>" + record.SelectionDate + "</td><td><b>Profile</b></td><td>" + record.Profile + "</td></tr>"
                                           + "<tr><td><b>pkg / stipend </b><td>" + record.Package + "</td><td><b>placement type summer/final/projects</b></td><td>" + record.PlacementType + "</td></tr>"
                                           + "<tr><td><b>in / off campus</b><td>" + record.Campus + "</td><td><b>selection criteria</b></td><td>" + record.SelectionCriteria + "</td></tr>"
                                           + "<tr><td><b>last date of registration</b><td>" + record.LastRegistrationDate + "</td><td><b>detailed jd</b></td><td>" + record.LatestBy + "</td></tr>"
                                           + "<tr><td><b>selection procedure</b></td><td>" + record.SelectionProcedure + "</td></tr>");

                    
               
        }
    },
        error: function (result) {
        alert("error");
    }
    });
    }

