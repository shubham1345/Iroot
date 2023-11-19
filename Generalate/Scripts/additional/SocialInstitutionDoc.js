//Load Data in Table when documents is ready 
$(document).ready(function () {
    loadData();
    loadDataListItems();

    $('#printbtn').click(function () {
        window.open('../SocialInstitutionDoc/SocialInstitutionDoc1Report');
    });

});


function loadData() {
    var tb = document.getElementById('EmpInfo');
    while (tb.rows.length > 1) {
        tb.deleteRow(1);
    }

    $.getJSON("GetAll",
        function (json) {
            var tr;

            //Append each row to html table
            for (var i = 0; i < json.length; i++) {
                
                tr = $('<tr />');
                tr.append("<td hidden='hidden'>" + json[i].SocialInstitutionId + "</td>");
                //tr.append('<td><a href=ViewProfile/' + json[i].SocialInstitutionId + '>' + json[i].CommunitiesSocialCentresDoc + '</a></td>');
                tr.append("<td>" + json[i].CommunityName + "</td>");
                tr.append("<td>" + json[i].InstitutionName + "</td>");
                tr.append("<td>" + json[i].EstablishDate + "</td>");
                tr.append("<td>" + json[i].Place + "</td>");
                tr.append("<td>" + json[i].Address + "</td>");
                tr.append("<td>" + json[i].ContactNumber + "</td>");
                tr.append("<td>" + json[i].Website + "</td>");
                tr.append("<td> <a href=/Images/SocialInstitutionDoc/" + json[i].File + " download>Download</a></td>");
                tr.append("<td> <a href=/Images/SocialInstitutionDoc/" + json[i].File + " view>Download</a></td>");
                tr.append('<td><a href="#" onclick="return getbyID(' + json[i].SocialInstitutionId + ')">Edit</a> | <a href="#" onclick="Delele(' + json[i].SocialInstitutionId + ')">Delete</a></td>')
                $('table').append(tr);

            }
            $('SocialInstitutionDocInfo').DataTable();
        });
}

function loadDataListItems() {
    $.ajax({
        url: "../CommonDataListItems/GetDatalistItemsByModuleName/?DlistName=Social Institution",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        //data : { "DlistName"},
        dataType: "json",
        success: function (result) {
            $("#generalst").empty();
            for (var i = 0; i < result.length; i++) {
                $("#generalst").append("<option value='" + result[i].DataListItemName + "'></option>");
            }

        },

        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    });

}

//Add Data Function 
function Add() {
    //var res = validate();
    //if (res == false) {
    //    return false;
    //}

    var datenow = new Date();

    var general =
        {
            SocialInstitutionId: $('#SocialInstitutionId').val(),
            // DoccumentName: $('#DoccumentName').val(),
            // DoccumentName: $("#tbl_SocialInstitutionDoc option:selected").text(),
            CommunityName: $('#CommunityName').val(),
            InstitutionName: $('#InstitutionName').val(),
            EstablishDate: $('#EstablishDate').val(),
            Place: $('#Place').val(),
            Address: $('#Address').val(),
            ContactNumbe: $('#ContactNumbe').val(),
            Website: $('#Website').val(),
            File: $('#File').val(),
        };
    
    $.ajax({
        url: "../SocialInstitutionDoc/Add",
        data: JSON.stringify(general),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            clearTextBox();
            $('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Function for getting the Data Based upon Employee ID 
function getbyID(GId1) {
    $.ajax({
        url: "../SocialInstitutionDoc/GetById/" + GId1,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            
            $('#SocialInstitutionId').val(result.SocialInstitutionId);
            // $('#tbl_SocialInstitutionDoc option:selected').val(result.CommunityId)
            $('#CommunityName').val(result.CommunityName);
            $('#InstitutionName').val(result.InstitutionName);
            $('#EstablishDate').val(result.EstablishDate);
            $('#Place').val(result.Place);
            $('#Address').val(result.Address);
            $('#ContactNumber').val(result.ContactNumber);
            $('#Website').val(result.Website);
            $('#File').val(result.File);

            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    }); return false;
}

//function for updating General's record 
function Update() {
    
    //var res = validate();
    //if (res == false) {
    //    return false;
    //}

    var datenow = new Date();

    var empObj =
        {
            SocialInstitutionId: $('#SocialInstitutionId').val(),
            //  DoccumentName: $('#DoccumentName').val(),
            // CommunityId: $("#tbl_MinistryDoc option:selected").text(),
            CommunityName: $('#CommunityName').val(),
            InstitutionName: $('#InstitutionName').val(),
            EstablishDate: $('#EstablishDate').val(),
            Place: $('#Place').val(),
            Address: $('#Address').val(),
            ContactNumber: $('#ContactNumber').val(),
            Website: $('#Website').val(),
            File: $('#File').val(),
        };

    $.ajax({
        url: "../SocialInstitutionDoc/Update",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//function for deleting employee's record 
function Delele(ID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "../SocialInstitutionDoc/Delete/" + ID,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                $(this).closest('tr').remove()
                loadData();

            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

//File Upload here
$("#FileUpload").change(function () {

    var memid = $("#MemberID").val();
    var data = new FormData();
    var files = $("#FileUpload").get(0).files;
    if (files.length > 0) {
        data.append("MyImages", files[0]);
        data.append("Memid", memid);
    }
    
    $.ajax({
        url: "/SocialInstitutionDoc/UploadFile",
        type: "POST",
        processData: false,
        contentType: false,
        data: data,
        success: function (response) {
            //code after success
            $("#File").val(response);
            alert("File Save Successfully");
        },
        error: function (er) {
            alert(er);
        }

    });
});


//Function for clearing the textboxes 
function clearTextBox() {

    $('#SocialInstitutionId').val("");
    $('#CommunityName').val("");
    $('#InstitutionName').val("");
    $('#EstablishDate').val("");
    $('#Place').val("");
    $('#Address').val("");
    $('#ContactNumber').val("");
    $('#Website').val("");
    $('#File').val("");

    $('#btnUpdate').hide();
    $('#btnAdd').show();

    $('#SocialInstitutionId').css('border-color', 'lightgrey');
    $('#CommunityName').css('border-color', 'lightgrey');
    $('#InstitutionName').css('border-color', 'lightgrey');
    $('#EstablishDate').css('border-color', 'lightgrey');
    $('#Place').css('border-color', 'lightgrey');
    $('#Address').css('border-color', 'lightgrey');
    $('#ContactNumber').css('border-color', 'lightgrey');
    $('#Website').css('border-color', 'lightgrey');
    $('#File').css('border-color', 'lightgrey');
}

//Valdidation using jquery 
function validate() {
    var isValid = true;
    if ($('#SocialInstitutionId').val().trim() == "") {
        $('#SocialInstitutionId').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#SocialInstitutionId').css('border-color', 'lightgrey');
    }
    if ($('#CommunityName').val().trim() == "") {
        $('#CommunityName').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#CommunityName').css('border-color', 'lightgrey');
    }
    if ($('#InstitutionName').val().trim() == "") {
        $('#InstitutionName').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#InstitutionName').css('border-color', 'lightgrey');
    }
    if ($('#EstablishDate').val().trim() == "") {
        $('#EstablishDate').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#EstablishDate').css('border-color', 'lightgrey');
    }
    if ($('#Place').val().trim() == "") {
        $('#Place').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#Place').css('border-color', 'lightgrey');
    }
    if ($('#Address').val().trim() == "") {
        $('#Address').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#Address').css('border-color', 'lightgrey');
    }
    if ($('#ContactNumber').val().trim() == "") {
        $('#ContactNumber').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#ContactNumber').css('border-color', 'lightgrey');
    }
    if ($('#Website').val().trim() == "") {
        $('#Website').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#Website').css('border-color', 'lightgrey');
    }
    if ($('#File').val().trim() == "") {
        $('#File').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#File').css('border-color', 'lightgrey');
    }
    //if ($('#Designation').val().trim() == "") {
    //    $('#Designation').css('border-color', 'Red'); isValid = false;
    //}
    //else {
    //    $('#Designation').css('border-color', 'lightgrey');
    //}
    //if ($('#Portfolio').val().trim() == "") {
    //    $('#Portfolio').css('border-color', 'Red'); isValid = false;
    //}
    //else {
    //    $('#Portfolio').css('border-color', 'lightgrey');
    //}
    //if ($('#VarGId').val().trim() == "") {
    //    $('#VarGId').css('border-color', 'Red'); isValid = false;
    //}
    //else {
    //    $('#VarGId').css('border-color', 'lightgrey');
    //}
    return isValid;
}