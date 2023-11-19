$(document).ready(function () {

    
    var weburl = "";
    if (!weburl) weburl = window.location.href
    var array = weburl.split('/');
    var scholarno = array[array.length - 1];
    if (scholarno != "" & scholarno.length > 0)
    {
        LoadStudentDetails(scholarno);
    }
});


function LoadStudentDetails(no) {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "Student.asmx/getStudentDetailsByRegNo",
        data: "{'RegNo' : '" + no + "'}",
        dataType: "json",
        success: function (data) {

            $("#StudentId").val(data.d[0].StudentId);
            $("#Course").val(data.d[0].Course);
            $("#Year").val(data.d[0].Years);
            $("#Batch").val(data.d[0].Batch);
            $("#Specialization").val(data.d[0].Specialization);
            $("#ScholarNo").val(data.d[0].ScholarNo);
            $("#Category").val(data.d[0].Category);
            $("#FacultyMentor").val(data.d[0].FacultyMentor);
            $("#DOB").val(data.d[0].DateofBirth);
            $("#Age").val(data.d[0].Age);
            $("#ResidenceLocation").val(data.d[0].ResidenceLocation);
            $("#Mobile").val(data.d[0].MobileNo);
            $("#Email").val(data.d[0].EmailId);
            $("#Native").val(data.d[0].NativePlace);
            $("#CorrespondenceAddress").val(data.d[0].CorrespondenceAddress);


            $("#FatherName").val(data.d[0].FatherName);
            $("#MotherName").val(data.d[0].MotherName);
            $("#FathenProfession").val(data.d[0].FatherProfession);
            $("#MotherProfession").val(data.d[0].MotherProfession);
            $("#FatherMobile").val(data.d[0].FatherMobileNo);
            $("#MotherMobile").val(data.d[0].MotherMobileNo);
            $("#FatherEmail").val(data.d[0].FatherEmailId);
            $("#MotherEmail").val(data.d[0].MotherEmailId);
            $("#FatherCompany").val(data.d[0].FatherCompanyName);
            $("#MotherCompany").val(data.d[0].MotherCompanyName);
            $("#Sibiling1").val(data.d[0].Sibiling1);
            $("#Sibiling2").val(data.d[0].Sibiling2);
            $("#Sibiling3").val(data.d[0].Sibiling3);
                    
            var outstn = data.d[0].OutStationStudent;
            if (outstn == "Yes")
                $("#OutStationYesChkbox").prop("checked", true);
            else
                $("#OutStationNoChkbox").prop("checked", true);

            var hostalite = data.d[0].Hostalite;
            if (hostalite == "Yes")
                $("#HostaliteYesChkbox").prop("checked", true);
            else
                $("#HostaliteNoChkbox").prop("checked", true);
                    
            var gen = data.d[0].Gender;
            if (gen == "Male")
                $("#Malechkbox").prop("checked", true);
            else
                $("#FeMalechkbox").prop("checked", true);

            var scholarno = $("#ScholarNo").val();
            LoadDeclarationDetails(scholarno);
            LoadInternshipDetails(scholarno);

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
        url: "Student.asmx/getDeclarationDetailsByRegNo",
        data: "{'RegNo' : '" + no + "'}",
        dataType: "json",
        success: function (data) {
            
            var inter = data.d[0].Interesterd;
            var reason = data.d[0].NotInterested;
            var stdname = data.d[0].StudentName;
            var DeclarationId = data.d[0].DeclarationId;

            $("#interestedtxt").text(inter);
            $("#Dec_ReasonforNo").val(reason);
            $("#Dec_StudnetName").val(stdname);
            $("#DeclarationId").val(DeclarationId);

            var agree = data.d[0].Agree;
            if (agree == "Yes")
                $("#Dec_AgreeChkbox").prop("checked", true);
            else
                $("#Dec_DisagreeChkbox").prop("checked", true);

            var Interesterd = data.d[0].Interesterd;
            if (Interesterd == "Yes")
                $("#Dec_interestedinFinalPlacementYesChkbox").prop("checked", true);
            else
                $("#Dec_interestedinFinalPlacementNoChkbox").prop("checked", true);

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
        url: "Student.asmx/getInternshipDetailsByRegNo",
        data: "{'RegNo' : '" + no + "'}",
        dataType: "json",
        success: function (data) {
            $("#SummerInternshipId").val(data.d[0].SummerInternshipId);
            $("#Intern_CompanyName").val(data.d[0].CompanyName);
            $("#Intern_StartDate").val(data.d[0].StartDate);
            $("#Intern_Mobile").val(data.d[0].MobileNo);
            $("#Intern_EndDate").val(data.d[0].EndDate);
            $("#Intern_ProjectTitle").val(data.d[0].ProjectTitle);
            $("#Intern_FacultyProjectGuide").val(data.d[0].FacultyProjectGuide);
            $("#Intern_FacultyGuideMobile").val(data.d[0].FacultyGuideMobileNo);
            $("#Intern_IndustryGuideName").val(data.d[0].IndustryGuideName);
            $("#Intern_IndustryGuideDesignation").val(data.d[0].IndustryGuideDesignation);
            $("#Intern_IndustryGuideTelNo").val(data.d[0].IndustryGuideTelNo);
            $("#Intern_IndustryGuideMobile").val(data.d[0].IndustryGuideMobileNo);
            $("#Intern_IndustryGuideEmail").val(data.d[0].IndustryGuideEmail);
            $("#Intern_Stipend").val(data.d[0].StipendinThousands);
            $("#Intern_ProjectDescription").val(data.d[0].ProjectDescription);
            $("#Intern_ReasonforNoSubmission").val(data.d[0].ReasonforNoSubmission);
            $("#Intern_Feedback").val(data.d[0].Feedback);

            var projsub = data.d[0].ProjectSubmission;
            if (projsub == "Yes")
                $("#Intern_ProjectSubmissionYesChkbox").prop("checked", true);
            else
                $("#Intern_ProjectSubmissionNoChkbox").prop("checked", false);

            var placementrec = data.d[0].PrePlacementOfferReceived;
            if (placementrec == "Yes")
                $("#Intern_Pre_PlacementOfferReceivedYesChkbox").prop("checked", true);
            else
                $("#Intern_Pre_PlacementOfferReceivedNoChkbox").prop("checked", false);


        },
        error: function (result) {
            alert("Error");
        }
    });
}