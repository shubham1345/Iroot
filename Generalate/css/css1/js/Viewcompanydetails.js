$(document).ready(function () {
    
    var weburl = "";
    if (!weburl) weburl = window.location.href
    var array = weburl.split('/');
    var no = getUrlVars()["id"];
    getallstudentplacementdetails1(no);
    //getdowmload(no);

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
                    var docIURL = record.filepath
                    if (record.MessageType == "1") {

                        //var docIURL = "<a target='_blank' href='" + record.filepath + "' download>" + record.DetailedJd + "</a>";
                        


                        $("#placement").append("<tr><td><b>start date</b><td>" + record.startDate + "</td colspan='2'><td ><b>end date</b></td><td>" + record.endDate + "</td></tr>"
                                           + "<tr><td><b>Batch</b><td>" + record.Batch + "</td><td><b>CompanyId</b><td>" + record.CommunictionId + "</td></tr>"
                                           + "<tr><td><b>Company Name</b><td>" + record.CompanyCode + "</td><td><b>job code</b></td><td>" + record.jobcode + "</td></tr>"
                                           + "<tr><td><b>sector </b><td>" + record.sector + "</td><td><b>jd recvd on</b></td><td>" + record.jdrecievedon + "</td></tr>"
                                           + "<tr><td><b>Selection Date </b><td>" + record.SelectionDate + "</td><td><b>Profile</b></td><td>" + record.Profile + "</td></tr>"
                                           + "<tr><td><b>pkg / stipend </b><td>" + record.Package + "</td><td><b>placement type summer/final/projects</b></td><td>" + record.PlacementType + "</td></tr>"
                                           + "<tr><td><b>in / off campus</b><td>" + record.Campus + "</td><td><b>selection criteria</b></td><td>" + record.SelectionCriteria + "</td></tr>"
                                           + "<tr><td><b>last date of registration</b><td>" + record.LastRegistrationDate + "</td><td><b>detailed jd</b></td><td>" + record.filepath + "</td></tr>"
                                           + "<tr><td><b>selection procedure</b></td><td>" + record.SelectionProcedure + "</td><td><b>Year</b><td>" + record.Year + "</td></tr>");

                        



                    }


                    if (record.MessageType == "2") {

                        $("#placement").append("<tr><td><b>start date</b><td>" + record.startDate + "</td colspan='2'><td ><b>end date</b></td><td>" + record.endDate + "</td></tr>"
                                            + "<tr><td><b>Batch</b><td>" + record.Batch + "</td><td><b>Year</b><td>" + record.Year + "</td></tr>"
                                            + "<tr><td><b>Company Code</b><td>" + record.CompanyCode + "</td><td><b>job code</b></td><td>" + record.jobcode + "</td></tr>"
                                            + "<tr><td><b>sector </b><td>" + record.sector + "</td><td><b>jd recvd on</b></td><td>" + record.jdrecievedon + "</td></tr>"
                                            + "<tr><td><b>Selection Date </b><td>" + record.SelectionDate + "</td><td><b>Profile</b></td><td>" + record.Profile + "</td></tr>"
                                            + "<tr><td><b>Interview Date</b><td>" + record.interviewDate + "</td><td><b>Interview Time</b></td><td>" + record.Interviewtime + "</td></tr>"
                                            + "<tr><td><b>Venue</b><td>" + record.Venue + "</td><td><b>Students Name</b></td><td>" + record.StudentsName + "</td></tr>"
                                            + "<tr><td><b>Contact Person</b><td>" + record.ContactPerson + "</td><td><b>General Instructions</b></td><td>" + record.GeneralInstructions + "</td></tr>");

                          $("#demo").hide();

                    }

                    if (record.MessageType == "3") {

                        $("#placement").append("<tr><td><b>Start Date</b><td>" + record.startDate + "</td><td><b>End Date</b></td><td>" + record.endDate + "</td></tr>"
                                            + "<tr><td><b>Batch</b><td>" + record.Batch + "</td><td><b>Course</b></td><td>" + data.d[0].Course + "</td></tr>"
                                            + "<tr><td><b>Specialization</b><td>" + record.Specialization + "</td><td><b>Year</b></td><td>" + record.Year + "</td></tr>"
                                            + "<tr><td><b>Message Type</b><td>" + record.MessageType + "</td><td><b>Message Subject</b></td><td>" + record.MessageSubject + "</td></tr>"
                                            + "<tr><td><b>Remark if any</b><td>" + record.Remark + "</td><td><b>By</b></td><td>" + record.By + "</td></tr>"
                                            + "<tr><td><b>Company Name</b><td>" + record.CompanyName + "</td><td><b>Session Time</b></td><td>" + record.SessionTime + "</td></tr>"
                                            + "<tr><td><b>Session Type</b><td>" + record.SessionType + "</td><td><b>Venue</b></td><td>" + record.IVenue + "</td></tr>"
                                            + "<tr><td><b>Speaker Name</b><td>" + record.SpeakerName + "</td><td><b>Co-ordinated By</b></td><td>" + record.CoordinatedBy + "</td></tr>"
                                            + "<tr><td><b>Speaker Type </b><td>" + record.SpeakerType + "</td><td><b>Session Details</b></td><td>" + record.SessionDetails + "</td></tr>"
                                            + "<tr><td><b>Speaker Company</b><td>" + record.SpeakerCompany + "</td><td><b>Last date of Registration</b></td><td>" + record.ILastRegistrationDate + "</td></tr>"
                                            + "<tr><td><b>Speaker Designation</b><td>" + record.SpeakerDesignation + "</td><td><b>Latest By </b></td><td>" + record.LatestBy + "</td></tr>"
                                            + "<tr><td><b>Session Date</b><td>" + record.SessionDate + "</td></tr>");

                        $("#demo").hide();
                    }


                }
        },
        error: function (result) {
            alert("error");
        }
    });
}

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
            ScholarNumber: $("#scholarNumbertxt").val(),
            StudentName: $("#sname").val(),
            MobileNo: $("#mobno").val(),
            Specialization: $("#special").val(),
            ApplyDate: $("#applydate").val(),
            CompanyCode: $("#companycode").val(),
            CompanyId: $("#CompanyId").val(),
            Applystatus: status,
            
        }; 

        $.ajax({
            type: "POST",
            url: "Student.asmx/Addstatus",
            data: JSON.stringify({ 'status': carrier }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                //ClearPlacement();
                window.location.href = "ViewStudentcomm.aspx";
            }
        });
    });
});

//function getdowmload(no) {
    
   
//      $.ajax({
//        url: "Student.asmx/GetCommunicationById",
//        type: "POST",
//        contentType: "application/json;charset=UTF-8",
//        dataType: "json",
//        data: "{'id' : '" + no + "'}",
//        success: function (data) {






