$(document).ready(function () {

    
    var weburl = "";
    if (!weburl) weburl = window.location.href
    var array = weburl.split('/');
    var no = array[array.length - 1];
    var update = array[array.length - 2];

    if (no != "JobSheetMain.aspx") {
        if (update != "Update") {
            $("#Job_Add_btn").hide();
            $("#Job_Update_btn").hide();
            $("#jobsheetheader").text(" JobSheet Details");
        }
        else {
            $("#Job_Add_btn").hide();
            $("#Job_Update_btn").show();
            $("#jobsheetheader").text(" Update JobSheet");
        }


        LoadJobsheetDetailsById(no);
    }

    else {
        $("#Job_Update_btn").hide();
        $("#Job_Add_btn").show();
        $("#jobsheetheader").text(" Add JobSheet");
    }

});


// Add ChageofSpecialization details

$(function () {
    $('#Job_Add_btn').click(function () {
        

        var carrier =
        {
            JobSheetId: $("#JobSheetId").val(),
            ScholarNumber: $("#Job_RegisterNo").val(),
            FromDate: $("#Job_DurationFrom").val(),
            ToDate: $("#Job_DurationTo").val(),
            Batch: $("#Job_Batch").val(),
            StudentName: $("#Job_StudentName").val(),
            Class: $("#Job_Class").val(),
            FacultyGuideName: $("#Job_FacultyGuideName").val(),
            StartDate: $("#Job_startdate").val(),
            EndDate: $("#Job_Enddate").val(),
            CompanyGuide: $("#Job_ComapnyName").val(),
            IndustryGuideName: $("#Job_IndustryGuideName").val(),
            Designation: $("#Job_Designation").val(),
            ContactNo: $("#Job_Contact").val(),
            CellNo: $("#Job_Mobile").val(),
            EmailId: $("#Job_Email").val(),
            Specialization: $("#Job_Specialization").val()
        };

        $.ajax({
            type: "POST",
            url: "Student.asmx/AddJobSheet",
            data: JSON.stringify({ 'JobSheet': carrier }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                Clearjobsheet();
                window.location.href = "ManageJobSheet.aspx";


            }
        });
    });
});


function Clearjobsheet() {

    //$("#JobSheetId").val("");
    $("#Job_RegisterNo").val("");
    $("#Job_DurationFrom").val("");
    $("#Job_DurationTo").val("");
    $("#Job_Batch").val("");
    $("#Job_StudentName").val("");
    $("#Job_Class").val("");
    $("#Job_FacultyGuideName").val("");
    $("#Job_startdate").val("");
    $("#Job_Enddate").val("");
    $("#Job_ComapnyName").val("");
    $("#Job_IndustryGuideName").val("");
    $("#Job_Designation").val("");
    $("#Job_Contact").val("");
    $("#Job_Mobile").val("");
    $("#Job_Email").val("");
    $("#Job_Specialization").val("");
}

// Add JobSheet Assignment details
$(function () {
    $('#JobSub_Save_btn').click(function () {
        

        var carrier =
        {
            ScholarNumber: $("#Job_RegisterNo").val(),
            StudentName: $("#JobSub_Studnet").val(),
            FacultyGuide: $("#JobSub_FacultyGuide").val(),
            IndustryGuide: $("#JobSub_IndustryGuide").val(),
            Assignment: $("#JobSub_Assignment").val(),
            Date: $("#JobSub_Date").val(),
            Week: $("#JobSub_weekddl").val()
        };

        $.ajax({
            type: "POST",
            url: "Student.asmx/AddJobSheetDetails",
            data: JSON.stringify({ 'JobSheet': carrier }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                
                GetAllJobsheetSubDetails();

                $("#JobSub_ID").val("");
                $("#JobSub_Studnet").val("");
                $("#JobSub_FacultyGuide").val("");
                $("#JobSub_IndustryGuide").val("");
                $("#JobSub_Assignment").val("");
                $("#JobSub_Date").val("");
                $("#JobSub_weekddl").val("");
                //window.location.href = "Carrier.aspx";


            }
        });
    });
});

function getJobsheetDetailsbyID(ID)
{
    var tb = document.getElementById('JobsheetDetails');
    while (tb.rows.length > 1) {
        tb.deleteRow(1);
    }

    

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "Student.asmx/getJobSheetDetailsById",
        data: "{'id' : '" + ID + "'}",
        dataType: "json",
        success: function (data) {
            $("#JobSheetDetailId").val(ID);
            //$("#Job_RegisterNo").val(data.d[0].ScholarNumber_josh);
            $("#JobSub_Studnet").val(data.d[0].StudentName);
            $("#JobSub_FacultyGuide").val(data.d[0].FacultyGuide);
            $("#JobSub_IndustryGuide").val(data.d[0].IndustryGuide);
            $("#JobSub_Assignment").val(data.d[0].Assignment);
            $("#JobSub_Date").val(data.d[0].Date);
            $("#JobSub_weekddl").val(data.d[0].Week);

        },
        error: function (result) {
        }
    });
}

// Update JobSheet Assignment details
$(function () {
    $('#JobSub_Update_btn').click(function () {
        

        var carrier =
        {
            JobSheetDetailId: $("#JobSheetDetailId").val(),
            ScholarNumber: $("#Job_RegisterNo").val(),
            StudentName: $("#JobSub_Studnet").val(),
            FacultyGuide: $("#JobSub_FacultyGuide").val(),
            IndustryGuide: $("#JobSub_IndustryGuide").val(),
            Assignment: $("#JobSub_Assignment").val(),
            Date: $("#JobSub_Date").val(),
            Week: $("#JobSub_weekddl").val()
        };

        $.ajax({
            type: "POST",
            url: "Student.asmx/UpdateJobSheetDetails",
            data: JSON.stringify({ 'JobSheet': carrier }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                
                GetAllJobsheetSubDetails();

                $("#JobSub_ID").val("");
                $("#JobSub_Studnet").val("");
                $("#JobSub_FacultyGuide").val("");
                $("#JobSub_IndustryGuide").val("");
                $("#JobSub_Assignment").val("");
                $("#JobSub_Date").val("");
                $("#JobSub_weekddl").val("");
                //window.location.href = "Carrier.aspx";


            }
        });
    });
});

function GetAllJobsheetSubDetails() {
    var tb = document.getElementById('JobsheetDetails');
    while (tb.rows.length > 1) {
        tb.deleteRow(1);
    }

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "Student.asmx/GetAllJobSheetDetails",
        //data: "{'RegNo' : '" + RegstrNo + "'}",
        dataType: "json",
        success: function (data) {
            for (var i = 0; i < data.d.length; i++) {
                $("#JobsheetDetails").append("<tr><td hidden='hidden'>" + data.d[i].JobSheetDetailId + "</td><td>" + data.d[i].Week + "</td><td>" + data.d[i].Date
                    + "</td><td>" + data.d[i].Assignment + "</td><td>" + data.d[i].IndustryGuide + "</td><td>" + data.d[i].StudentName + "</td><td>" + data.d[i].FacultyGuide + "</td><td>"
                    + '<a href="#" onclick="getJobsheetDetailsbyID(' + data.d[i].JobSheetDetailId + ')">Edit</a> | <a href="#" onclick="DeleleJobsheetDetails(' + data.d[i].JobSheetDetailId + ')">Delete</a></td><tr>');
            }

        },
        error: function (result) {
            alert("Error");
        }
    });
}

//Delete AcademicDetail
function DeleleJobsheetDetails(ID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "Student.asmx/DeleteJobSheeDetailst",
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            data: "{id:'" + ID + "'}",
            success: function (result) {
                GetAllJobsheetSubDetails();

            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

Clear()
{
    $("#JobSub_ID").val("");
    $("#JobSub_Studnet").val("");
    $("#JobSub_FacultyGuide").val("");
    $("#JobSub_IndustryGuide").val("");
    $("#JobSub_Assignment").val("");
    $("#JobSub_Date").val("");
    $("#JobSub_weekddl").val("");
}