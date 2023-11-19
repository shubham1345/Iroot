$(document).ready(function () {
    var weburl = "";
    if (!weburl) weburl = window.location.href
    var array = weburl.split('=');
    var no = array[array.length - 1];
    var sRole = '<%= Session["role"] %>';
    LoadCommunicationDetails(no);
});






function LoadCommunicationDetails(no) {
   
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "Student.asmx/GetAllCommunicationbyid",
        data: "{'id' : '" + no + "'}",
        dataType: "json",
        success: function (data) {
            for (var i = 0; i < data.d.length; i++) {
                if (no == data.d[i].CommunictionId) {
                    var record = data.d[i];
                    if (data.d[i].MessageType == "1") {


                        var docIURL = "<a target='_blank' href='" + record.filepath + "' download>" + record.DetailedJd + "</a>";


                        $("#viewcommunication1").append("<tr><td><b>Start Date</b><td>" + record.startDate + "</td><td><b>End Date</b></td><td>" + record.endDate + "</td></tr>"
                                           + "<tr><td><b>Batch</b><td>" + record.Batch + "</td><td><b>Course</b></td><td>" + record.Course + "</td></tr>"
                                           + "<tr><td><b>Specialization</b><td>" + record.Specialization + "</td><td><b>Year</b></td><td>" + record.Year + "</td></tr>"
                                           + "<tr><td><b>Message Type</b><td>" + record.MessageType + "</td><td><b>Message Subject</b></td><td>" + record.MessageSubject + "</td></tr>"
                                           + "<tr><td><b>Remark if any</b><td>" + record.Remark + "</td><td><b>By</b></td><td>" + record.By + "</td></tr>"
                                           + "<tr><td><b>Company Name</b><td>" + record.CompanyName + "</td><td><b>Job Code</b></td><td>" + record.jobcode + "</td></tr>"
                                           + "<tr><td><b>Sector </b><td>" + record.Sector + "</td><td><b>JD Recvd On</b></td><td>" + record.jdRecievedOn + "</td></tr>"
                                           + "<tr><td><b>Selection Date </b><td>" + record.SelectionDate + "</td><td><b>Profile</b></td><td>" + record.Profile + "</td></tr>"
                                           + "<tr><td><b>Pkg / Stipend </b><td>" + record.Package + "</td><td><b>Placement Type Summer/Final/Projects</b></td><td>" + record.PlacementType + "</td></tr>"
                                           + "<tr><td><b>In / Off Campus</b><td>" + record.Campus + "</td><td><b>Selection Criteria</b></td><td>" + record.SelectionCriteria + "</td></tr>"
                                           + "<tr><td><b>Last date of Registration</b><td>" + record.LastRegistrationDate + "</td><td><b>Detailed JD</b></td><td>" + record.filepath + "</td></tr>"
                                           + "<tr><td><b>Latest By</b><td>" + record.LatestBy + "</td><td><b>Selection Procedure</b></td><td>" + record.SelectionProcedure + "</td></tr>");
                    }






                    if (data.d[i].MessageType == "2")
                    {


                        $("#viewcommunication1").append("<tr><td><b>Start Date</b><td>" + data.d[i].startDate + "</td><td><b>End Date</b></td><td>" + data.d[i].endDate + "</td></tr>"
                                                + "<tr><td><b>Batch</b><td>" + data.d[i].Batch + "</td><td><b>Course</b></td><td>" + data.d[i].Course + "</td></tr>"
                                                + "<tr><td><b>Specialization</b><td>" + data.d[i].Specialization + "</td><td><b>Year</b></td><td>" + data.d[i].Year + "</td></tr>"
                                                + "<tr><td><b>Message Type</b><td>" + data.d[i].MessageType + "</td><td><b>Message Subject</b></td><td>" + data.d[i].MessageSubject + "</td></tr>"
                                                + "<tr><td><b>Remark if any</b><td>" + data.d[i].Remark + "</td><td><b>Contact Detail</b></td><td>" + data.d[i].ContactDetails + "</td></tr>"
                                                + "<tr><td><b>Company Name</b><td>" + data.d[i].CompanyName + "</td><td><b>Interview Date</b></td><td>" + data.d[i].interviewDate + "</td></tr>"
                                                + "<tr><td><b>Interview Time </b><td>" + data.d[i].Interviewtime + "</td><td><b>Venue</b></td><td>" + data.d[i].Venue + "</td></tr>"
                                                + "<tr><td><b>Students Name </b><td>" + data.d[i].StudentsName + "</td><td><b>Contact Person</b></td><td>" + data.d[i].ContactPerson + "</td></tr>"
                                                + "<tr><td><b>General Instructions</b><td>" + data.d[i].GeneralInstructions + "</td><td><b>Placement Type Summer/Final/Projects</b></td><td>" + data.d[i].PlacementType + "</td></tr>");


                    }
                    if (data.d[i].MessageType == "3")
                    {
                        $("#viewcommunication1").append("<tr><td><b>Start Date</b><td>" + data.d[i].startDate + "</td><td><b>End Date</b></td><td>" + data.d[i].endDate + "</td></tr>"
                                            + "<tr><td><b>Batch</b><td>" + data.d[i].Batch + "</td><td><b>Course</b></td><td>" + data.d[0].Course + "</td></tr>"
                                            + "<tr><td><b>Specialization</b><td>" + data.d[i].Specialization + "</td><td><b>Year</b></td><td>" + data.d[i].Year + "</td></tr>"
                                            + "<tr><td><b>Message Type</b><td>" + data.d[i].MessageType + "</td><td><b>Message Subject</b></td><td>" + data.d[i].MessageSubject + "</td></tr>"
                                            + "<tr><td><b>Remark if any</b><td>" + data.d[i].Remark + "</td><td><b>By</b></td><td>" + data.d[i].By + "</td></tr>"
                                            + "<tr><td><b>Company Name</b><td>" + data.d[i].CompanyName + "</td><td><b>Session Time</b></td><td>" + data.d[i].SessionTime + "</td></tr>"
                                            + "<tr><td><b>Session Type</b><td>" + data.d[i].SessionType + "</td><td><b>Venue</b></td><td>" + data.d[i].IVenue + "</td></tr>"
                                            + "<tr><td><b>Speaker Name</b><td>" + data.d[i].SpeakerName + "</td><td><b>Co-ordinated By</b></td><td>" + data.d[i].CoordinatedBy + "</td></tr>"
                                            + "<tr><td><b>Speaker Type </b><td>" + data.d[i].SpeakerType + "</td><td><b>Session Details</b></td><td>" + data.d[i].SessionDetails + "</td></tr>"
                                            + "<tr><td><b>Speaker Company</b><td>" + data.d[i].SpeakerCompany + "</td><td><b>Last date of Registration</b></td><td>" + data.d[i].ILastRegistrationDate + "</td></tr>"
                                            + "<tr><td><b>Speaker Designation</b><td>" + data.d[i].SpeakerDesignation + "</td><td><b>Latest By </b></td><td>" + data.d[i].LatestBy + "</td></tr>"
                                            + "<tr><td><b>Session Date</b><td>" + data.d[i].SessionDate + "</td></tr>");

                    

                    }
                }
                }     
                },
                error: function (result) {
                    alert("Error");
                }
            });
        }
   
    

function DeleleCommunication(id) {

    var ans = confirm("Are you sure you want to delete communication record?");
    if (ans) {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "Student.asmx/DeleteCommunication",
            data: "{'id' : '" + id + "'}",
            dataType: "json",
            success: function (data) {

                var nTotalRecords = $('#selectNumberRecords').val();
                var searchKeyword = $.trim($('#txtSearchBox').val());
                GenerateGridHtml(nTotalRecords, 1, 0, 0, 1, "", "");
                $('#ImgCourse').attr('src', '/img/sort_asc.png');


                //LoadCommunicationDetails();

            },
            error: function (result) {
                alert("Error");
            }
        });
    }
}



////Get All AcademicDetail By Id
//function GetAcademicDetailsView(no) {
//    $.ajax({
//        type: "POST",
//        contentType: "application/json; charset=utf-8",
//        url: "../Student.asmx/getAllAcademicDetailsByRegNo",
//        data: "{'RegNo' : '" + no + "'}",
//        dataType: "json",
//        success: function (data) {

//            for (var i = 0; i < data.d.length; i++) {
//                $("#Academic").append("<tr><td hidden='hidden'>" + data.d[i].AcademicDetailId + "</td><td>" + data.d[i].AcademicYear + "</td><td>" + data.d[i].Qualification
//                    + "</td><td>" + data.d[i].Stream + "</td><td>" + data.d[i].Institution + "</td><td>" + data.d[i].University + "</td><td>" + data.d[i].Percentage + "</td></tr>");
//                //+ '<a href="#" onclick="return GetAcademicDetailsByID(' + data.d[i].AcademicDetailId + ')">Edit</a> | <a href="#" onclick="Delele(' + data.d[i].AcademicDetailId + ')">Delele</a></td><tr>');
//            }

//        },
//        error: function (result) {
//            alert("Error");
//        }
//    });
//}




////Get All AcademicDetail By Id
//function GetSemmisterDetailsView(no) {
//    $.ajax({
//        type: "POST",
//        contentType: "application/json; charset=utf-8",
//        url: "../Student.asmx/getAllSemDetailsByRegNo",
//        data: "{'RegNo' : '" + no + "'}",
//        dataType: "json",
//        success: function (data) {

//            for (var i = 0; i < data.d.length; i++) {
//                $("#tblSemisterDetails").append("<tr><td hidden='hidden'>" + data.d[i].SemesterId + "</td><td>" + data.d[i].Year + "</td><td>" + data.d[i].Sem
//                    + "</td><td>" + data.d[i].Persentagegrade + "</td></tr>");
//            }

//        },
//        error: function (result) {
//            alert("Error");
//        }
//    });
//}

////Get All WorkExperience By Id
//function GetWorkExperience(no) {

//    $.ajax({
//        type: "POST",
//        contentType: "application/json; charset=utf-8",
//        url: "../Student.asmx/GetAllWorkExpDetailsByRegNo",
//        data: "{'RegNo' : '" + no + "'}",
//        dataType: "json",
//        success: function (data) {
//            var totalexp = 0;
//            for (var i = 0; i < data.d.length; i++) {
//                if (data.d[i].FromDate != undefined && data.d[i].FromDate != "") {
//                    totalexp += parseInt(data.d[i].FromDate);
//                }
//                $("#workexpern").append("<tr><td hidden='hidden'>" + data.d[i].WorkExperienceId + "</td><td>" + data.d[i].CompanyName

//                    + "</td><td>" + data.d[i].Designation + "</td><td>" + data.d[i].FromDate + "</td><td>" + data.d[i].CompanyProfile + "</td><tr>");
//            }

//            $("#ContentPlaceHolder1_lbltotaWorkExperince").html(totalexp);

//            //var a = data.d[i].FromDate;

//            //for (var i = 0; i < data.d.length;i++)
//            //{
//            //    $("#workexpern").append("<label>"+data.d[i].FromDate+"</label>");
//            //}

//        },
//        error: function (result) {
//            alert("Error");
//        }
//    });
//}

//function LoadDeclarationDetails(no) {
//    $.ajax({
//        type: "POST",
//        contentType: "application/json; charset=utf-8",
//        url: "../Student.asmx/getDeclarationDetailsByRegNo",
//        data: "{'RegNo' : '" + no + "'}",
//        dataType: "json",
//        success: function (data) {

//            var inter = data.d[i].Interesterd;
//            var reason = data.d[0].NotInterested;
//            var stdname = data.d[0].StudentName;

//            if (inter == "No") {
//                //hide declaration div.
//                $("#agreementdiv").hide();
//            }

//            //if (data.d[0].Spare1 != undefined && data.d[0].Spare1 != null && data.d[0].Spare1 != "") {
//            //    $("#checkselected").prop("checked", true);
//            //    $("#checknotselected").prop("checked", false);

//            //}
//            //else {
//            //    $("#checkselected").prop("checked", false);
//            //    $("#checknotselected").prop("checked", true);
//            //}

//            $("#interestedtxt").text(inter);
//            $("#reasontxt").text(reason);
//            $("#stdname").text(stdname);

//            var agree = data.d[0].Agree;
//            if (agree == "Yes")
//                $("#agreechkbox").prop("checked", true);
//            else
//                $("#agreechkbox").prop("checked", false);


//        },
//        error: function (result) {
//            alert("Error");
//        }
//    });
//}

//function LoadInternshipDetails(no) {
//    $.ajax({
//        type: "POST",
//        contentType: "application/json; charset=utf-8",
//        url: "../Student.asmx/getInternshipDetailsByRegNo",
//        data: "{'RegNo' : '" + no + "'}",
//        dataType: "json",
//        success: function (data) {

//            $("#Internshiptbl").append("<tr><td><b>Company Name</b><td>" + data.d[0].CompanyName + "</td><td><b>Start Date</b></td><td>" + data.d[0].StartDate + "</td></tr>"
//                                   + "<tr><td><b>Mobile No</b><td>" + data.d[0].MobileNo + "</td><td><b>EndDate</b></td><td>" + data.d[0].EndDate + "</td></tr>"
//                                   + "<tr><td><b>Project Title</b><td>" + data.d[0].ProjectTitle + "</td><td><b>Faculty Project Guide Name</b></td><td>" + data.d[0].FacultyProjectGuide + "</td></tr>"
//                                   + "<tr><td><b>Faculty Guide Mobile No</b><td>" + data.d[0].FacultyGuideMobileNo + "</td><td><b>Industry Guide Name</b></td><td>" + data.d[0].IndustryGuideName + "</td></tr>"
//                                   + "<tr><td><b>Industry Guide Designation</b><td>" + data.d[0].IndustryGuideDesignation + "</td><td><b>Industry Guide TelNo</b></td><td>" + data.d[0].IndustryGuideTelNo + "</td></tr>"
//                                   + "<tr><td><b>Industry Guide Mobile No</b><td>" + data.d[0].IndustryGuideMobileNo + "</td><td><b>Industry Guide Email</b></td><td>" + data.d[0].IndustryGuideEmail + "</td></tr>"
//                                   + "<tr><td><b>Stipend in Thousands</b><td>" + data.d[0].StipendinThousands + "</td><td><b>Project Description</b></td><td>" + data.d[0].ProjectDescription + "</td></tr>"
//                                   + "<tr><td><b>Project Submission</b><td>" + data.d[0].ProjectSubmission + "</td><td><b>Reason for NoSubmission</b></td><td>" + data.d[0].ReasonforNoSubmission + "</td></tr>"
//                                   + "<tr><td><b>Pre Placement Offer Received</b><td>" + data.d[0].PrePlacementOfferReceived + "</td><td><b>Feedback</b></td><td>" + data.d[0].Feedback + "</td></tr>");




//        },
//        error: function (result) {
//            alert("Error");
//        }
//    });
//}


//$(document).ready(function () {

//    var nTotalRecords = $('#selectNumberRecords').val();
//    var searchKeyword = $.trim($('#txtSearchBox').val());
//    GenerateGridHtml(nTotalRecords, 1, 0, 0, 1, "", "");
//    $('#ImgCourse').attr('src', '/img/sort_asc.png');

//});


////for no of Pages
//$(document).ready(function () {
//    $("#selectNumberRecords").change(function () {
//        var nTotalRecords = $("#selectNumberRecords").val();
//        var sSortKey = $("#hdnSortKey").val();
//        var sSortOrder = $("#hdnSortOrder").val();
//        var searchKeyword = $.trim($('#txtSearchBox').val());
//        GenerateGridHtml(nTotalRecords, 1, 0, 0, sSortKey, sSortOrder, searchKeyword);
//    });
//});


////Function to search with keyword
//function SearchwithKeyword() {
//    var nTotalRecords = $("#selectNumberRecords").val();
//    var searchKeyword = $.trim($('#txtSearchBox').val());
//    if (searchKeyword.length > 0) {
//        GenerateGridHtml(nTotalRecords, 1, 0, 0, 1, "", searchKeyword);
//    }
//    else {
//        GenerateGridHtml(nTotalRecords, 1, 0, 0, 1, "", "");
//    }
//}

////Function to get the nextPage
//function GetPageNo(object) {
//    var nTotalRecords = $("#selectNumberRecords").val();
//    var PageNo = $("#" + object.id).html();
//    var minPage = $("#hdnMinPageVal").val();
//    var maxPage = $("#hdnMaxPageVal").val();
//    var sSortKey = $("#hdnSortKey").val();
//    var sSortOrder = $("#hdnSortOrder").val();
//    var searchKeyword = $.trim($('#txtSearchBox').val());
//    GenerateGridHtml(nTotalRecords, PageNo, minPage, maxPage, sSortKey, sSortOrder, searchKeyword);
//}
//function GetNextPage() {
//    var nTotalRecords = $("#selectNumberRecords").val();
//    var CurrentPageNo = $("#hdnCurrentPageNo").val();
//    var pageNo = parseInt(CurrentPageNo) + parseInt(1);
//    var minPage = $("#hdnMinPageVal").val();
//    var maxPage = $("#hdnMaxPageVal").val();
//    var sSortKey = $("#hdnSortKey").val();
//    var sSortOrder = $("#hdnSortOrder").val();
//    var searchKeyword = $.trim($('#txtSearchBox').val());
//    GenerateGridHtml(nTotalRecords, pageNo, minPage, maxPage, sSortKey, sSortOrder, searchKeyword);
//}

//function GetLastPage() {
//    var nTotalRecords = $("#selectNumberRecords").val();
//    var minPage = $("#hdnMinPageVal").val();
//    var maxPage = $("#hdnMaxPageVal").val();
//    var sSortKey = $("#hdnSortKey").val();
//    var sSortOrder = $("#hdnSortOrder").val();
//    var searchKeyword = $.trim($('#txtSearchBox').val());
//    GenerateGridHtml(nTotalRecords, 0, minPage, maxPage, sSortKey, sSortOrder, searchKeyword);
//}

//function GetPreviousPage() {
//    var nTotalRecords = $("#selectNumberRecords").val();
//    var CurrentPageNo = $("#hdnCurrentPageNo").val();
//    var minPage = $("#hdnMinPageVal").val();
//    var maxPage = $("#hdnMaxPageVal").val();
//    var sSortKey = $("#hdnSortKey").val();
//    var sSortOrder = $("#hdnSortOrder").val();

//    var searchKeyword = $.trim($('#txtSearchBox').val());
//    if (CurrentPageNo > 1) {
//        var pageNo = parseInt(CurrentPageNo) - parseInt(1);

//    }
//    else {
//        pageNo = CurrentPageNo;
//    }
//    GenerateGridHtml(nTotalRecords, pageNo, minPage, maxPage, sSortKey, sSortOrder, searchKeyword);
//}

//function GetToFirstPage() {
//    var nTotalRecords = $('#selectNumberRecords').val();
//    var searchKeyword = $.trim($('#txtSearchBox').val());
//    GenerateGridHtml(nTotalRecords, 1, 0, 0, 1, "", searchKeyword);
//    $('#ImgCourse').attr('src', '/img/sort_asc.png');
//}

////Function to Sort
//function SortBy(sKeyName, AncId, ImgID) {
//    var nTotalRecords = $("#selectNumberRecords").val();
//    var pageNo = $("#hdnCurrentPageNo").val();
//    var minPage = $("#hdnMinPageVal").val();
//    var maxPage = $("#hdnMaxPageVal").val();
//    var sSortKey = $("#hdnSortKey").val();
//    var sSortOrder = $("#hdnSortOrder").val();
//    var AncObject = $("#" + AncId);
//    var ImgObject = $("#" + ImgID);
//    var searchKeyword = $.trim($('#txtSearchBox').val());

//    ////////////////////////////////////

//    $("#ImgBatch").attr("src", "/img/sort_both.png");
//    $("#ImgCourse").attr("src", "/img/sort_both.png");
//    $("#ImgSpecialization").attr("src", "/img/sort_both.png");
//    $("#ImgBatch").attr("src", "/img/sort_both.png");
//    $("#ImgYear").attr("src", "/img/sort_both.png");
//    $("#ImgMessageType").attr("src", "/img/sort_both.png");
//    $("#ImgCompanyName").attr("src", "/img/sort_both.png");

//    ///////////////////////////////////

//    //sort Key selection is same
//    if (sKeyName == sSortKey) {
//        if (sSortOrder == "Asc") {
//            sSortOrder = "Desc"
//            $("#" + ImgID).attr("src", "/img/sort_desc.png");
//        }
//        else {
//            sSortOrder = "Asc"
//            $("#" + ImgID).attr("src", "/img/sort_asc.png");
//        }
//    }
//    else {
//        sSortKey = sKeyName;
//        sSortOrder = "Asc";
//        $("#" + ImgID).attr("src", "/img/sort_asc.png");

//    }
//    GenerateGridHtml(nTotalRecords, pageNo, minPage, maxPage, sSortKey, sSortOrder, searchKeyword);
//}

//function GenerateGridHtml(nTotalRecords, PageNo, nMinPageVal, nMaxPageVal, sSortCol, sSortOrder, sSearchKey) {
//    //alert(nTotalRecords + " " + PageNo + " " + nMinPageVal + " " +  nMaxPageVal + " " +  sSortCol +  " " +  sSortOrder + " " + sSearchKey);
//    var items = "";
//    try {

//        var request =
//        {
//            nTotalRecords: nTotalRecords,
//            PageNo: PageNo,
//            nPrevMinPage: nMinPageVal,
//            nPrevMaxPage: nMaxPageVal,
//            sSortCol: sSortCol,
//            sSortOrder: sSortOrder,
//            sSerachKey: sSearchKey
//        };


//        //var sHtml = "<tr><td colspan='11'><div style='width:100%;text-align:center;'><img src='/images/287.gif' alt='' /></div></td></tr>";
//        //$("#tbodyDataTable").html(sHtml);
//        // SetInProgressContent('tbodyDataTable', 10);
//        $.ajax({
//            type: "POST",
//            contentType: "application/json; charset=utf-8",
//            url: "Student.asmx/GetCommunicationListHtmlForTable",
//            data: JSON.stringify(request), //{ nTotalRecords: nTotalRecords, PageNo: PageNo, nPrevMinPage: nMinPageVal, nPrevMaxPage: nMaxPageVal, sSortCol: sSortCol, sSortOrder: sSortOrder, sSerachKey: sSearchKey },
//            dataType: "json",

//            success: function (result) {


//                var item = result.d.split('~');

//                var count = $('#selectNumberRecords').val();
//                $("#tbodyDataTable").html(item[0].toString());
//                $('#DataTable_info').css("display", "block");
//                $('#DataTable_paginate').html(item[1].toString());
//                $('#DataTable_info').html(item[2].toString());
//                //$("#HotelDetails").html(item[3].toString());
//            },
//            error: function (result) {

//                alert("Error");
//            }
//        });
//    } catch (e) {
//        //ShowOperationNotCompleted();
//    }
//}



////////earlier changes

//$(document).ready(function () {

//    var weburl = "";
//    if (!weburl) weburl = window.location.href
//    var array = weburl.split('/');
//    var no = array[array.length - 1];
//    var update = array[array.length - 2];

//    LoadCommunicationDetails(no)
//}
//);

//function LoadCommunicationDetails(no) {
//    $.ajax({
//        type: "POST",
//        contentType: "application/json; charset=utf-8",
//        url: "../Student.asmx/GetCommunicationById",
//        data: "{'id' : '" + no + "'}",
//        dataType: "json",
//        success: function (data) {
//            $("#viewcommunication1").append("<tr><td><b>Start Date</b><td>" + data.d[0].StartDate + "</td><td><b>End Date</b></td><td>" + data.d[0].endDate + "</td></tr>"
//                                 + "<tr><td><b>Batch</b><td>" + data.d[0].Batch + "</td><td><b>Course</b></td><td>" + data.d[0].Course + "</td></tr>"
//                                 + "<tr><td><b>Specialization</b><td>" + data.d[0].Specialization + "</td><td><b>Year</b></td><td>" + data.d[0].Year + "</td></tr>"
//                                 + "<tr><td><b>Message Type</b><td>" + data.d[0].MessageType + "</td><td><b>Message Subject</b></td><td>" + data.d[0].MessageSubject + "</td></tr>"
//                                 + "<tr><td><b>Remark if any</b><td>" + data.d[0].Remark + "</td><td><b>By</b><td>" + data.d[0].By + "</td></tr>"
//                                 + "<tr><td><b>Company Name</b><td>" + + "</td><td><b>Job Code :</b><td>" + data.d[0].jobcode + "</td></tr>"
//                                 + "<tr><td><b>Company Code</b><td>" + data.d[0].student.CompanyCode + "</td><td><b>Sector</b><td>" + data.d[0].Sector + "</td></tr>"
//                                 + "<tr><td><b>JD Recvd On</b><td>" + data.d[0].jdRecievedOn + "</td><td><b>Selection Date</b><td>" + data.d[0].SelectionDate + "</td></tr>"
//                                 + "<tr><td><b>Profile </b><td>" + data.d[0].Profile + "</td><td><b>Pkg / Stipend</b><td>" + data.d[0].Package + "</td></tr>"
//                                 + "<tr><td><b>Placement Type Summer/Final/Projects </b><td>" + data.d[0].Strength + "</td><td><b>In / Off Campus</b><td>" + data.d[0].StudentQuery + "</td></tr>"
//                                 + "<tr><td><b>Selection Criteria </b><td>" + data.d[0].SelectionCriteria + "</td><td><b>Last date of Registration</b><td>" + data.d[0].StudentQuery + "</td></tr>"
//                                 + "<tr><td><b>Detailed JD </b><td>" + data.d[0].Strength + "</td><td><b>Latest By</b><td>" + data.d[0].StudentQuery + "</td></tr>"
//                                  + "<tr><td><b>Selection Procedure</b><td>" + data.d[0].Strength + "</td><td><b></b><td>" + "&nbsp" + "</td></tr>");
//            // 


            




//        },
//        error: function (result) {
//            alert("Error");
//        }
//    })
//}



