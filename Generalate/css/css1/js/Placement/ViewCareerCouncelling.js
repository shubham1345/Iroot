$(document).ready(function () {

    var weburl = "";
    if (!weburl) weburl = window.location.href
    var array = weburl.split('/');
    var no = array[array.length - 1];
    var update = array[array.length - 2];

    LoadCareerDetails(no)
}
);

function LoadCareerDetails(no) {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../Student.asmx/getCarrierCouncellingNewById",
        data: "{'id' : '" + no + "'}",
        dataType: "json",
        success: function (data) {
            $("#viewcareercouncelling").append("<tr><td><b>Scholar Number</b><td>" + data.d.career.RegisterNumber + "</td><td><b>Batch</b></td><td>" + data.d.career.Batch + "</td></tr>"
                                 + "<tr><td><b>Course</b><td>" + data.d.career.Course + "</td><td><b>Student Name</b></td><td>" + data.d.career.StudentName + "</td></tr>"
                                 + "<tr><td><b>Mobile No</b><td>" + data.d.career.MobileNo + "</td><td><b>Specialization</b></td><td>" + data.d.career.Specialization + "</td></tr>"
                                 + "<tr><td><b>Degree</b><td>" + data.d.career.Degree + "</td><td><b>Father</b></td><td>" + data.d.student.FatherProfession + "</td></tr>"
                                 + "<tr><td><b>Mother</b><td>" + data.d.student.MotherProfession + "</td><td><b>Weakness</b><td>" + data.d.career.Weakness + "</td></tr>"
                                 + "<tr><td><b>Strength</b><td>" + data.d.career.Strength + "</td><td><b>Student  Query</b><td>" + data.d.career.StudentQuery + "</td></tr>");
            // 


            $("#pl_CMCRemarks").val(data.d.career.CMCRemarks);

            

            var sib1 = data.d.student.Sibiling1;
            var sib2 = data.d.student.Sibiling2;
            var sib3 = data.d.student.Sibiling3;
            var sib4 = data.d.student.Sibiling4;
            var sib5 = data.d.student.Sibiling5;

            var str = "";

            if (sib1 != null && sib1 != "")
            {
                str += "<tr><td><b>Sibiling1</b></td><td>"+ sib1+"</td></tr>";
            }
            if (sib2 != null && sib2 != "") {
                str += "<tr><td><b>Sibiling2</b></td><td>" + sib2 + "</td></tr>";
            }
            if (sib3 != null && sib3 != "") {
                str += "<tr><td><b>Sibiling3</b></td><td>" + sib3 + "</td></tr>";
            }
            if (sib4 != null && sib4 != "") {
                str += "<tr><td><b>Sibiling4</b></td><td>" + sib4 + "</td></tr>";
            }
            if (sib5 != null && sib5 != "") {
                str += "<tr><td><b>Sibiling5</b></td><td>" + sib5 + "</td></tr>";
            }
            $("#viewsiblings").html("");
            $("#viewsiblings").html(str);

            var html = "";
            for(var i=0; i< data.d.lstExperience.length; i++)
            {
                var compname = data.d.lstExperience[i].CompanyName;
                var designation = data.d.lstExperience[i].Designation;
                var duration = data.d.lstExperience[i].FromDate;
                var profile = data.d.lstExperience[i].CompanyProfile;

                html+="<tr><td>"+compname+"</td><td>"+designation+"</td><td>"+duration+"</td><td>"+profile+"</td></tr>";
            }

            $("#viewworkExp").html("");
            $("#viewworkExp").html(html);

            //$("#viewworkExp").append("<tr><td><b>Scholar Number</b><td>" + data.d.career.RegisterNumber + "</td><td><b>Batch</b></td><td>" + data.d.career.Batch + "</td></tr>"
            




            
            //if (data.d[0].Spare2 == "verified") {
            //    $("#checkselected").prop("checked", true);
            //    $("#checknotselected").prop("checked", false);
            //    $("#ContentPlaceHolder1_cocstatusupdate").hide();
            //    document.getElementById("OfficeUse").style.visibility = "visible";
            //    $("#checkselected").attr('disabled', true);
            //    $("#checknotselected").attr('disabled', true);

            //}
            //else if (data.d[0].Spare2 == "notverified") {
            //    $("#checkselected").prop("checked", false);
            //    $("#checknotselected").prop("checked", true);
            //}
            //else {

            //    $("#checkselected").prop("checked", false);
            //    $("#checknotselected").prop("checked", false);
            //}
           
            if (data.d.career.CMCRemarks != undefined && data.d.career.CMCRemarks != null && data.d.career.CMCRemarks != "")
            {
                document.getElementById("OfficeUse").style.visibility = "visible";
                document.getElementById('ddlPlmntldr_Authorized').innerHTML = data.d.career.Authorized;
                document.getElementById('datepicker').innerHTML = data.d.career.Spare1;
                $("#ContentPlaceHolder1_cocstatusupdate").hide();

            }
            
            



        },
        error: function (result) {
            alert("Error");
        }
    })
}



