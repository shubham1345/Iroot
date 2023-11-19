
$(document).ready(function () {
    var weburl = "";
    if (!weburl) weburl = window.location.href
    var array = weburl.split('/');
    var no = array[array.length - 1];
    var sRole = '<%= Session["role"] %>';
    LoadStudentDetails(no);
    GetAcademicDetailsView(no);
    GetWorkExperience(no);
    LoadInternshipDetails(no);
    LoadDeclarationDetails(no);
    GetSemmisterDetailsView(no);
    GetSkillsView(no);
});



function LoadStudentDetails(no) {

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../Student.asmx/getStudentDetailsByRegNo",
        data: "{'RegNo' : '" + no + "'}",
        dataType: "json",
        success: function (data) {
            
            
            // $("#txtdateon").val(data.d[0].Dateon);
            //   $('#lblDateon').val(data.d[0].DateOn);
           $("#viewstudent").append("<tr><td><b>ScholarNumber</b><td>" + data.d[0].ScholarNumber + "</td><td><b>Student Name</b></td><td>" + data.d[0].StudentName + "</td></tr>"
                                   + "<tr><td><b>Course</b><td>" + data.d[0].Course + "</td><td><b>Year</b></td><td>" + data.d[0].Years + "</td></tr>"
                                   + "<tr><td><b>Batch</b><td>" + data.d[0].Batch + "</td><td><b>Specialization</b></td><td>" + data.d[0].Specialization + "</td></tr>"
                                   + "<tr><td><b>Category</b></td><td>" + data.d[0].Category + "</td></tr>"
                                   + "<tr><td><b>Faculty Mentor</b><td>" + data.d[0].FacultyMentor + "</td><td><b>Date of Birth</b></td><td>" + data.d[0].DateofBirth + "</td></tr>"
                                   + "<tr><td><b>Age</b><td>" + data.d[0].Age + "</td><td><b>Gender</b></td><td>" + data.d[0].Gender + "</td></tr>"
                                   + "<tr><td><b>Residence Location in Mumbai</b><td>" + data.d[0].ResidenceLocation + "</td><td><b>Mobile Number</b></td><td>" + data.d[0].MobileNo + "</td></tr>"
                                   + "<tr><td><b>Email ID</b><td>" + data.d[0].EmailId + "</td><td><b>OutStation Student</b></td><td>" + data.d[0].OutStationStudent + "</td></tr>"
                                   + "<tr><td><b>Native Place</b><td>" + data.d[0].NativePlace + "</td><td><b>Hostalite</b></td><td>" + data.d[0].Hostalite + "</td></tr>"
                                   + "<tr><td><b>Father Name</b><td>" + data.d[0].FatherName + "</td><td><b>Mother Name</b></td><td>" + data.d[0].MotherName + "</td></tr>"
                                   + "<tr><td><b>Father Profession</b><td>" + data.d[0].FatherProfession + "</td><td><b>Mother Profession</b></td><td>" + data.d[0].MotherProfession + "</td></tr>"
                                   + "<tr><td><b>Father Mobile Number</b><td>" + data.d[0].FatherMobileNo + "</td><td><b>Mother Mobile Number</b></td><td>" + data.d[0].MotherMobileNo + "</td></tr>"
                                   + "<tr><td><b>Father Email ID</b><td>" + data.d[0].FatherEmailId + "</td><td><b>Mother Email ID</b></td><td>" + data.d[0].MotherEmailId + "</td></tr>"
                                   + "<tr><td><b>Father Company Name</b><td>" + data.d[0].FatherCompanyName + "</td><td><b>Mother Company Name</b></td><td>" + data.d[0].MotherCompanyName + "</td></tr>");
            //+ "<tr><td><b>Date on</b><td>" + data.d[0].DateOn + "</td></tr>");


            //var date = data.d[0].DateOn;
            //$("#lblDateon").text(date);
            //  $('#Wrk_CompanyDuration').val(result.d[0].FromDate);
            // getStudentById();



            if (data.d[0].Sibiling1 && data.d[0].Sibiling2 && data.d[0].Sibiling3 && data.d[0].Sibiling4 && data.d[0].Sibiling5) {
                $("#sibilings").append("<tr><td><b>Sibiling1</b><td>" + data.d[0].Sibiling1 + "</td><td><b>Sibiling2</b><td>" + data.d[0].Sibiling2 + "</td></tr>"
                    + "<tr><td><b>Sibiling3</b><td>" + data.d[0].Sibiling3 + "</td><td><b>Sibiling4</b><td>" + data.d[0].Sibiling4 + "</td></tr>"
                    + "<tr><td><b>Sibiling5</b><td>" + data.d[0].Sibiling5 + "</td></tr>");
            }
            else if (data.d[0].Sibiling1 && data.d[0].Sibiling2 && data.d[0].Sibiling3 && data.d[0].Sibiling4) {
                $("#sibilings").append("<tr><td><b>Sibiling1</b><td>" + data.d[0].Sibiling1 + "</td><td><b>Sibiling2</b><td>" + data.d[0].Sibiling2 + "</td></tr>"
                    + "<tr><td><b>Sibiling3</b><td>" + data.d[0].Sibiling3 + "</td><td><b>Sibiling4</b><td>" + data.d[0].Sibiling4 + "</td></tr>");
            }
            else if (data.d[0].Sibiling1 && data.d[0].Sibiling2 && data.d[0].Sibiling3) {
                $("#sibilings").append("<tr><td><b>Sibiling1</b><td>" + data.d[0].Sibiling1 + "</td><td><b>Sibiling2</b><td>" + data.d[0].Sibiling2 + "</td></tr>"
                   + "<tr><td><b>Sibiling3</b><td>" + data.d[0].Sibiling3 + "</td></tr>");
            }
            else if (data.d[0].Sibiling1 && data.d[0].Sibiling2) {
                $("#sibilings").append("<tr><td><b>Sibiling1</b><td>" + data.d[0].Sibiling1 + "</td><td><b>Sibiling2</b><td>" + data.d[0].Sibiling2 + "</td></tr>");
            }
            else if (data.d[0].Sibiling1) {
                $("#sibilings").append("<tr><td><b>Sibiling1</b><td>" + data.d[0].Sibiling1 + "</td></tr>");
            }

            if (data.d[0].Spare1 != undefined && data.d[0].Spare1 != null && data.d[0].Spare1 != "") {
                $("#checkselected").prop("checked", true);
                $("#checknotselected").prop("checked", false);
                $("#checkselected").attr('disabled', true);
                $("#checknotselected").attr('disabled', true);

                $("#ContentPlaceHolder1_stdntstatusupdate").hide();

            }
            else {
                $("#checkselected").prop("checked", false);
                $("#checknotselected").prop("checked", true);
                $("#checkselected").attr('disabled', false);
                $("#checknotselected").attr('disabled', false);
            }


            //if (data.d[0].Spare1 != undefined && data.d[0].Spare1 != null && data.d[0].Spare1 != "") {
            //    $("#checkselected").prop("Enabled", false);
            //    $("#checknotselected").prop("Enabled", false);


            //}
            //else {

            //    $.ajax({
            //        type: "POST",
            //        contentType: "application/json; charset=utf-8",
            //        url: "../Student.asmx/CheckUser",
            //        dataType: "json",
            //        success: function (data) {
            //            if (data) {
            //                $("#checknotselected").prop("Enabled", true);
            //                $("#checkselected").prop("Enabled", true);
            //            }
            //            else {
            //                $("#checknotselected").prop("Enabled", false);
            //                $("#checkselected").prop("Enabled", false);
            //            }
            //        }
            //    });

            //}
            //$("#ddlStdReg_Authorized").val(data.d[0].Spare1);
            //$("#txtdateforoffice").val(data.d[0].Spare2);
            document.getElementById('ddlStdReg_Authorized').innerHTML = data.d[0].Spare1;
            document.getElementById('txtdateforoffice').innerHTML = data.d[0].Spare2;

            if (data.d[0].Spare3 == "Selected") {
                $("#checkselected").attr('checked', 'checked');
            }
            else {
                $("#checknotselected").attr('checked', 'checked');
            }



            $("#").val(data.d[0].Spare3);

            if (data.d[0].Years != undefined && data.d[0].Years == "I") {
                $("#summerinterndiv").hide();
            }

        },
        error: function (result) {
            alert("Error");
        }
    });
}



//Get All AcademicDetail By Id
function GetAcademicDetailsView(no) {
    
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../Student.asmx/getAllAcademicDetailsByRegNo",
        data: "{'RegNo' : '" + no + "'}",
        dataType: "json",
        success: function (data) {

            for (var i = 0; i < data.d.length; i++) {
                $("#Academic").append("<tr><td hidden='hidden'>" + data.d[i].AcademicDetailId + "</td><td>" + data.d[i].AcademicYear + "</td><td>" + data.d[i].Qualification
                    + "</td><td>" + data.d[i].Stream + "</td><td>" + data.d[i].Institution + "</td><td>" + data.d[i].University + "</td><td>" +  data.d[i].Percentage.toFixed(2) + "</td></tr>");
                //+ '<a href="#" onclick="return GetAcademicDetailsByID(' + data.d[i].AcademicDetailId + ')">Edit</a> | <a href="#" onclick="Delele(' + data.d[i].AcademicDetailId + ')">Delele</a></td><tr>');
            }

        },
        error: function (result) {
            alert("Error");
        }
    });
}

function GetSkillsView(no) {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../Student.asmx/GetAllSkillsetByRegNo",
        data: "{'RegNo' : '" + no + "'}",
        dataType: "json",
        success: function (data) {
            for (var i = 0; i < data.d.length; i++) {

                if (data.d[i].Problemsolving == "Yes") {
                    $("#mgtskills").append("<tr><td>Problem solving</td><tr>");
                }
                if (data.d[i].Initiative == "Yes") {
                    $("#mgtskills").append("<tr><td>Initiative</td><tr>");
                }
                if (data.d[i].Adaptabilitytochange == "Yes") {
                    $("#mgtskills").append("<tr><td>Adaptabilitytochange</td><tr>");
                }
                if (data.d[i].Interpersonalskills == "Yes") {
                    $("#mgtskills").append("<tr><td>Interpersonalskills</td><tr>");
                }
                if (data.d[i].Strategicthinking == "Yes") {
                    $("#mgtskills").append("<tr><td>Strategicthinking</td><tr>");
                }
                if (data.d[i].Timemanagement == "Yes") {
                    $("#mgtskills").append("<tr><td>Time management</td><tr>");
                }
                if (data.d[i].Communication == "Yes") {
                    $("#mgtskills").append("<tr><td>Communication</td><tr>");
                }
                if (data.d[i].Leadership == "Yes") {
                    $("#mgtskills").append("<tr><td>Leadership</td><tr>");
                }
                if (data.d[i].Teamwork == "Yes") {
                    $("#mgtskills").append("<tr><td>Teamwork</td><tr>");
                }

                if (data.d[i].Dancing == "Yes") {
                    $("#additionalskill").append("<tr><td>Dancing</td><tr>");
                }
                if (data.d[i].Singing == "Yes") {
                    $("#additionalskill").append("<tr><td>Singing</td><tr>");
                }
                if (data.d[i].Compering == "Yes") {
                    $("#additionalskill").append("<tr><td>Compering</td><tr>");
                }
                if (data.d[i].Creative == "Yes") {
                    $("#additionalskill").append("<tr><td>Creative</td><tr>");
                }
                if (data.d[i].Contentwriting == "Yes") {
                    $("#additionalskill").append("<tr><td>Contentwriting</td><tr>");
                }
                if (data.d[i].CoralDraw == "Yes") {
                    $("#additionalskill").append("<tr><td>CoralDraw</td><tr>");
                }
                if (data.d[i].Photoshop == "Yes") {
                    $("#additionalskill").append("<tr><td>Photoshop</td><tr>");
                }
                if (data.d[i].Drawing == "Yes") {
                    $("#additionalskill").append("<tr><td>Drawing</td><tr>");
                }

            }

        },
        error: function (result) {
            alert("Error");
        }
    });
}




//Get All AcademicDetail By Id
function GetSemmisterDetailsView(no) {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../Student.asmx/getAllSemDetailsByRegNo",
        data: "{'RegNo' : '" + no + "'}",
        dataType: "json",
        success: function (data) {

            for (var i = 0; i < data.d.length; i++) {
                $("#tblSemisterDetails").append("<tr><td hidden='hidden'>" + data.d[i].SemesterId + "</td><td>" + data.d[i].Year + "</td><td>" + data.d[i].Sem
                    + "</td><td>" + data.d[i].Persentagegrade + "</td></tr>");
            }

        },
        error: function (result) {
            alert("Error");
        }
    });
}

//Get All WorkExperience By Id
function GetWorkExperience(no) {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../Student.asmx/GetAllWorkExpDetailsByRegNo",
        data: "{'RegNo' : '" + no + "'}",
        dataType: "json",
        success: function (data) {
            var totalexp = 0;
            for (var i = 0; i < data.d.length; i++) {
                if (data.d[i].FromDate != undefined && data.d[i].FromDate != "") {
                    totalexp += parseInt(data.d[0].FromDate);
                }
                $("#workexpern").append("<tr><td hidden='hidden'>" + data.d[i].WorkExperienceId + "</td><td>" + data.d[i].CompanyName

                    + "</td><td>" + data.d[i].Designation + "</td><td>" + data.d[i].FromDate + "</td><td>" + data.d[i].CompanyProfile + "</td><tr>");
            }

            $("#ContentPlaceHolder1_lbltotaWorkExperince").html(totalexp);

            //var a = data.d[i].FromDate;

            //for (var i = 0; i < data.d.length;i++)
            //{
            //    $("#workexpern").append("<label>"+data.d[i].FromDate+"</label>");
            //}

        },
        error: function (result) {
            alert("Error");
        }
    });
}

function LoadDeclarationDetails(no) {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../Student.asmx/getDeclarationDetailsByRegNo",
        data: "{'RegNo' : '" + no + "'}",
        dataType: "json",
        success: function (data) {

            var inter = data.d[0].Interesterd;
            var reason = data.d[0].NotInterested;
            var stdname = data.d[0].StudentName;

            if (inter == "No") {
                //hide declaration div.
                $("#agreementdiv").hide();
            }

            //if (data.d[0].Spare1 != undefined && data.d[0].Spare1 != null && data.d[0].Spare1 != "") {
            //    $("#checkselected").prop("checked", true);
            //    $("#checknotselected").prop("checked", false);

            //}
            //else {
            //    $("#checkselected").prop("checked", false);
            //    $("#checknotselected").prop("checked", true);
            //}

            $("#interestedtxt").text(inter);
            $("#reasontxt").text(reason);
            $("#stdname").text(stdname);

            var agree = data.d[0].Agree;
            if (agree == "Yes") {
                $("#agreechkbox").prop("checked", true);
                document.getElementById("agreechkbox").disabled = true;
            }
            else {
                $("#agreechkbox").prop("checked", false);
            }


        },
        error: function (result) {
            alert("Error");
        }
    });
}

function LoadInternshipDetails(no) {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../Student.asmx/getInternshipDetailsByRegNo",
        data: "{'RegNo' : '" + no + "'}",
        dataType: "json",
        success: function (data) {

            $("#Internshiptbl").append("<tr><td><b>Company Name</b><td>" + data.d[0].CompanyName + "</td><td><b>Start Date</b></td><td>" + data.d[0].StartDate + "</td></tr>"
                                   + "<tr><td><b>Mobile No</b><td>" + data.d[0].MobileNo + "</td><td><b>EndDate</b></td><td>" + data.d[0].EndDate + "</td></tr>"
                                   + "<tr><td><b>Project Title</b><td>" + data.d[0].ProjectTitle + "</td><td><b>Faculty Project Guide Name</b></td><td>" + data.d[0].FacultyProjectGuide + "</td></tr>"
                                   + "<tr><td><b>Faculty Guide Mobile No</b><td>" + data.d[0].FacultyGuideMobileNo + "</td><td><b>Industry Guide Name</b></td><td>" + data.d[0].IndustryGuideName + "</td></tr>"
                                   + "<tr><td><b>Industry Guide Designation</b><td>" + data.d[0].IndustryGuideDesignation + "</td><td><b>Industry Guide TelNo</b></td><td>" + data.d[0].IndustryGuideTelNo + "</td></tr>"
                                   + "<tr><td><b>Industry Guide Mobile No</b><td>" + data.d[0].IndustryGuideMobileNo + "</td><td><b>Industry Guide Email</b></td><td>" + data.d[0].IndustryGuideEmail + "</td></tr>"
                                   + "<tr><td><b>Stipend in Thousands</b><td>" + data.d[0].StipendinThousands + "</td><td><b>Project Description</b></td><td>" + data.d[0].ProjectDescription + "</td></tr>"
                                   + "<tr><td><b>Project Submission</b><td>" + data.d[0].ProjectSubmission + "</td><td><b>Reason for NoSubmission</b></td><td>" + data.d[0].ReasonforNoSubmission + "</td></tr>"
                                   + "<tr><td><b>Pre Placement Offer Received</b><td>" + data.d[0].PrePlacementOfferReceived + "</td><td><b>Feedback</b></td><td>" + data.d[0].Feedback + "</td></tr>");




        },
        error: function (result) {
            alert("Error");
        }
    });
}