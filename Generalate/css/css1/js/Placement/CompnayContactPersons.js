$(document).ready(function () {


   // var weburl = "";
    //if (!weburl) weburl = window.location.href
    //var array = weburl.split('=');
    //var no = array[array.length - 1];
    var RegNo = $('#Jobcode').val();
    if (RegNo != "") {
        GetContactPersonDetailsByCompanyId(RegNo);
        GetFollowUpDetailsByCompanyId(RegNo);
    }


});

//Get All AcademicDetail By RegNo
function GetContactPersonDetailsByCompanyId(RegstrNo) {
    var tb = document.getElementById('Contactpersontbl');
    while (tb.rows.length > 1) {
        tb.deleteRow(1);
    }

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "Student.asmx/getAllContactPersonDetailsByID",
        data: "{'CompanyId' : '" + RegstrNo + "'}",
        dataType: "json",
        success: function (data) {
            for (var i = 0; i < data.d.length; i++) {
                $("#Contactpersontbl").append("<tr><td hidden='hidden'>" + data.d[i].ContactPersonId + "</td><td>" + data.d[i].ContactPerson + "</td><td>" + data.d[i].Title
                    + "</td><td>" + data.d[i].Name + "</td><td>" + data.d[i].Designation + "</td><td>" + data.d[i].DirectNo + "</td><td>" + data.d[i].Mobile + "</td><td>" + data.d[i].Email + "</td><td>"
                    + '<a href="#" onclick="return GetAcademicDetailsByID(' + data.d[i].ContactPersonId + ')">Edit</a> | <a href="#" onclick="Delele(' + data.d[i].ContactPersonId + ')">Delete</a></td><tr>');
            }

        },
        error: function (result) {
            alert("Error");
        }
    });
}

//Get Academic details by AcademicId
function GetAcademicDetailsByID(AcademicId) {

    $.ajax({
        url: "Student.asmx/getContactPersonDetailsById",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        data: "{id:'" + AcademicId + "'}",
        success: function (result) {

            $('#ContactPersonId').val(result.d[0].ContactPersonId);
            $('#ContactPerson').val(result.d[0].ContactPerson);
            $('#Name').val(result.d[0].Name);
            $('#Designation').val(result.d[0].Designation);
            $('#DirectNo').val(result.d[0].DirectNo);
            $('#Mobile').val(result.d[0].Mobile);
            $('#Email').val(result.d[0].Email);

            var title = result.d[0].Title;

            if (title == "Mr.")
                $('#Mrchkbox').prop('checked', true);

            else
                $('#Mschkbox').prop('checked', false);

            $("#ContactPersonAdd").prop("disabled", true);
            //$('#myModal').modal('show');
            //$('#btnUpdate').show();
            //$('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    }); return false;
}

// Add AcademicDetail

$(function () {
    $('#ContactPersonAdd').click(function () {


      
        var RegNo = $('#Jobcode').val();
        var title = "";

        if ($('#Mrchkbox').prop('checked')) {
            title = "Mr.";
        } else {
            title = "Ms.";
        }

        var general =
        {
            ContactPerson: $('#ContactPerson').val(),
            Name: $('#Name').val(),
            Designation: $('#Designation').val(),
            DirectNo: $('#DirectNo').val(),
            Mobile: $('#Mobile').val(),
            Email: $('#Email').val(),
            CompanyId: $('#Jobcode').val(),
            Title: title

        };


        var msg = "";

        if (general['ContactPerson'] == "") {
            msg += "Contact Person cannot be blank\r";
        }

        if (general['Name'] == "") {
            msg += "Name cannot be blank\r";
        }

        if (general['Designation'] == "") {
            msg += "Designation cannot be blank\r";
        }
        if (general['DirectNo'] == "") {
            msg += "DirectNo cannot be blank\r";
        }
        if (general['Mobile'] == "") {
            msg += "Mobile cannot be blank\r";
        }
        if (general['Email'] == "") {
            msg += "Email cannot be blank\r";
        }

        if (msg != "") {
            alert("Please refer to the following error(s) :\r" + msg);
            return false;
        }
        else {

            $.ajax({
                type: "POST",
                url: "Student.asmx/AddContactPerson",
                data: JSON.stringify({ 'ContactPerson': general }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    ClearAcademicDetails();
                    GetContactPersonDetailsByCompanyId(RegNo);

                }
            });
        }






    });
});


// Update AcademicDetail
$(function () {
    $('#ContactPersonUpdate').click(function () {


        var RegNo = $('#Jobcode').val();

        var title = "";

        if ($('#Mrchkbox').prop('checked')) {
            title = "Mr.";
        } else {
            title = "Ms.";
        }


        var general =
        {
            ContactPerson: $('#ContactPerson').val(),
            Name: $('#Name').val(),
            Designation: $('#Designation').val(),
            DirectNo: $('#DirectNo').val(),
            Mobile: $('#Mobile').val(),
            Email: $('#Email').val(),
            ContactPersonId: $('#ContactPersonId').val(),
            CompanyId: $('#Jobcode').val(),
            Title: title
        };


        var msg = "";

        if (general['ContactPerson'] == "") {
            msg += "Contact Person cannot be blank\r";
        }

        if (general['Name'] == "") {
            msg += "Name cannot be blank\r";
        }

        if (general['Designation'] == "") {
            msg += "Designation cannot be blank\r";
        }
        if (general['DirectNo'] == "") {
            msg += "DirectNo cannot be blank\r";
        }
        if (general['Mobile'] == "") {
            msg += "Mobile cannot be blank\r";
        }
        if (general['Email'] == "") {
            msg += "Email cannot be blank\r";
        }

        if (msg != "") {
            alert("Please refer to the following error(s) :\r" + msg);
            return false;
        }
        else {
            $.ajax({
                type: "POST",
                url: "Student.asmx/UpdateContactPerson",
                data: JSON.stringify({ 'ContactPerson': general }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    ClearAcademicDetails();
                    GetContactPersonDetailsByCompanyId(RegNo);
                    $("#ContactPersonAdd").prop("disabled", false);
                }
            });
        }


    });
});


//Delete AcademicDetail
function Delele(ID) {
    var RegNo = $('#Jobcode').val();
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "Student.asmx/DeleteContactPerson",
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            data: "{id:'" + ID + "'}",
            success: function (result) {
                $(this).closest('tr').remove()
                GetContactPersonDetailsByCompanyId(RegNo);

            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

function ClearAcademicDetails() {
    $('#ContactPerson').val("");
    $('#Name').val("");
    $('#Designation').val("");
    $('#DirectNo').val("");
    $('#Mobile').val("");
    $('#Email').val("");
    $('#ContactPersonId').val("");
    $('#Mrchkbox').prop('checked', false);
    $('#Mschkbox').prop('checked', false);
}


//FollowUp

//Get All FollowUp By RegNo
function GetFollowUpDetailsByCompanyId(RegstrNo) {
    var tb = document.getElementById('followuptbl');
    while (tb.rows.length > 1) {
        tb.deleteRow(1);
    }

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "Student.asmx/getAllFollowUpDetailsByCompanyID",
        data: "{'CompanyId' : '" + RegstrNo + "'}",
        dataType: "json",
        success: function (data) {for (var i = 0; i < data.d.length; i++) {

                var udateddate = "-";
                if (data.d[i].Updatedon != null && data.d[i].Updatedon != undefined)
                {
                    udateddate = data.d[i].Updatedon.toString();
                }

                $("#followuptbl").append("<tr><td hidden='hidden'>" + data.d[i].FollowUpId + "</td><td>" + data.d[i].FollowUpDate + "</td><td>" + data.d[i].FollowUpRemark
                    + "</td><td>" + data.d[i].FollowUpRemainderDate + "</td><td>" + data.d[i].RemainderRemark + "</td><td>" + udateddate + "</td><td>"
                    + '<a href="#" onclick="return GetFollowUpDetailsByID(' + data.d[i].FollowUpId + ')">Edit</a> | <a href="#" onclick="DeleleFollowup(' + data.d[i].FollowUpId + ')">Delete</a></td><tr>');
            }

        },
        error: function (result) {
            alert("Error");
        }
    });
}

//Get FollowUp details by AcademicId
function GetFollowUpDetailsByID(AcademicId) {

    $.ajax({
        url: "Student.asmx/getFollowUpDetailsById",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        data: "{id:'" + AcademicId + "'}",
        success: function (result) {

            $('#FDate').val(result.d[0].FollowUpDate);
            $('#FRemark').val(result.d[0].FollowUpRemark);
            $('#FRemainderDate').val(result.d[0].FollowUpRemainderDate);
            $('#RemainderRemark').val(result.d[0].RemainderRemark);
            $('#FollowUpId').val(result.d[0].FollowUpId);

            $("#FollowupAdd").prop("disabled", true);

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    }); return false;
}

// Add FollowUp

$(function () {
    $('#FollowupAdd').click(function () {



        var RegNo = $('#Jobcode').val();

        var general =
        {
            CompanyId: $("#Jobcode").val(),
            FollowUpDate: $("#FDate").val(),
            FollowUpRemark: $("#FRemark").val(),
            FollowUpRemainderDate: $("#FRemainderDate").val(),
            RemainderRemark: $("#RemainderRemark").val(),
            //DateUpdated: $("#DateUpdated").val()
        };

        var msg = "";

        if (general['FollowUpDate'] == "") {
            msg += "FollowUp Date cannot be blank\r";
        }

        if (general['FollowUpRemark'] == "") {
            msg += "FollowUp Remark cannot be blank\r";
        }

        if (general['FollowUpRemainderDate'] == "") {
            msg += "FollowUp Remainder Date cannot be blank\r";
        }
        if (general['RemainderRemark'] == "") {
            msg += "Reminder Remark cannot be blank\r";
        }
        //if (general['DateUpdated'] == "") {
        //    msg += "Date Updated cannot be blank\r";
        //}

        if (msg != "") {
            alert("Please refer to the following error(s) :\r" + msg);
            return false;
        }
        else {
            $.ajax({
                type: "POST",
                url: "Student.asmx/AddFollowUp",
                data: JSON.stringify({ 'ContactPerson': general }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    ClearFollowupDetails();
                    GetFollowUpDetailsByCompanyId(RegNo);

                }
            });
        }

    });
});


// Update FollowUp
$(function () {
    $('#FollowupUpdate').click(function () {


        var RegNo = $('#Jobcode').val();


        var general =
        {
            CompanyId: $("#Jobcode").val(),
            FollowUpDate: $("#FDate").val(),
            FollowUpRemark: $("#FRemark").val(),
            FollowUpRemainderDate: $("#FRemainderDate").val(),
            RemainderRemark: $("#RemainderRemark").val(),
            FollowUpId: $("#FollowUpId").val()
        };


        var msg = "";

        if (general['FollowUpDate'] == "") {
            msg += "FollowUp Date cannot be blank\r";
        }

        if (general['FollowUpRemark'] == "") {
            msg += "FollowUp Remark cannot be blank\r";
        }

        if (general['FollowUpRemainderDate'] == "") {
            msg += "FollowUp Remainder Date cannot be blank\r";
        }
        if (general['RemainderRemark'] == "") {
            msg += "Remainder Remark cannot be blank\r";
        }
        //if (general['DateUpdated'] == "") {
        //    msg += "Date Updated cannot be blank\r";
        //}

        if (msg != "") {
            alert("Please refer to the following error(s) :\r" + msg);
            return false;
        }
        else {
            $.ajax({
                type: "POST",
                url: "Student.asmx/UpdateFollowUp",
                data: JSON.stringify({ 'ContactPerson': general }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    ClearFollowupDetails();
                    GetFollowUpDetailsByCompanyId(RegNo);
                    $("#FollowupAdd").prop("disabled", false);
                }
            });
        }


    });
});


//Delete FollowUp
function DeleleFollowup(ID) {
    var RegNo = $('#Jobcode').val();
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "Student.asmx/DeleteFollowUp",
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            data: "{id:'" + ID + "'}",
            success: function (result) {
                $(this).closest('tr').remove()
                GetFollowUpDetailsByCompanyId(RegNo);

            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

function ClearFollowupDetails() {
    $('#FDate').val("");
    $('#FRemark').val("");
    $('#FRemainderDate').val("");
    $('#RemainderRemark').val("");
    $('#FollowUpId').val("");
}