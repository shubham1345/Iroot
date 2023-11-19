//Load Data in Table when documents is ready 
$(document).ready(function () {
    loadData();
    loadDataListItems();

    $('#printbtn').click(function () {
        window.open('../FinancialGuidelineDoc/FinancialGuidelineDoc1Report');
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
                tr.append("<td hidden='hidden'>" + json[i].FinancialDocId + "</td>");
                //tr.append('<td><a href=ViewProfile/' + json[i].MinistryDocId + '>' + json[i].MinistryDoc + '</a></td>');
                tr.append("<td>" + json[i].DoccumentName + "</td>");
               
                tr.append("<td>" + json[i].Title + "</td>");
                tr.append("<td>" + json[i].Date + "</td>");
                tr.append("<td>" + json[i].Phonenumber + "</td>");
                tr.append("<td>" + json[i].Address + "</td>");
                tr.append("<td>" + json[i].Email + "</td>");
                tr.append("<td> <a href=/Images/FinancialGuidelineDoc/" + json[i].File + " download>Download</a></td>");
                tr.append("<td> <a href=/Images/FinancialGuidelineDoc/" + json[i].File + " view>View</a></td>");
                tr.append("<td> <a href=/Images/FinancialGuidelineDoc1/" + json[i].Photo + " download>download</a></td>");
                tr.append('<td><a href="#" onclick="return getbyID(' + json[i].FinancialDocId + ')">Edit</a> | <a href="#" onclick="Delele(' + json[i].FinancialDocId + ')">Delete</a></td>')
                $('table').append(tr);

            }
            $('MinistryDocInfo').DataTable();
        });
}

function loadDataListItems() {
    $.ajax({
        url: "../CommonDataListItems/GetDatalistItemsByModuleName/?DlistName=Ministry",
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
            FinancialDocId: $('#FinancialDocId').val(),
            // DoccumentName: $('#DoccumentName').val(),
            // DoccumentName: $("#tbl_MinistryDoc option:selected").text(),
            DoccumentName: $('#DoccumentName').val(),
            
            Title: $('#Title').val(),
            Date: $('#Date').val(),
            Phonenumber: $('#Phonenumber').val(),
            Address: $('#Address').val(),
            Email: $('#Email').val(),
            File: $('#File').val(),
            Photo: $('#Photo').val(),
        };
    
    $.ajax({
        url: "../FinancialGuidelineDoc/Add",
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
        url: "../FinancialGuidelineDoc/GetById/" + GId1,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            
            $('#FinancialDocId').val(result.FinancialDocId);
            // $('#tbl_MinistryDoc option:selected').val(result.FormationDocId)
            $('#DoccumentName').val(result.DoccumentName);
           
            $('#Title').val(result.Title);
            $('#Date').val(result.Date);
            $('#Phonenumber').val(result.Phonenumber);
            $('#Address').val(result.Address);
            $('#Email').val(result.Address);
            $('#File').val(result.File);
            $('#Photo').val(result.Photo);

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
            FinancialDocId: $('#FinancialDocId').val(),
            //  DoccumentName: $('#DoccumentName').val(),
            // FormationDocId: $("#tbl_MinistryDoc option:selected").text(),
            DoccumentName: $('#DoccumentName').val(),
            
            Title: $('#Title').val(),
            Date: $('#Date').val(),
            Phonenumber: $('#Phonenumber').val(),
            Address: $('#Address').val(),
            Email: $('#Email').val(),
            File: $('#File').val(),
            Photo: $('#Photo').val(),
        };

    $.ajax({
        url: "../FinancialGuidelineDoc/Update",
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
            url: "../FinancialGuidelineDoc/Delete/" + ID,
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
        url: "/FinancialGuidelineDoc/UploadFile",
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
// Photo Upload Here
$("#PhotoUpload").change(function () {

    var memid = $("#MemberID").val();
    var data = new FormData();
    var files = $("#PhotoUpload").get(0).files;
    if (files.length > 0) {
        data.append("MyImages", files[0]);
        data.append("Memid", memid);
    }
    
    $.ajax({
        url: "/FinancialGuidelineDoc/UploadPhoto",
        type: "POST",
        processData: false,
        contentType: false,
        data: data,
        success: function (response) {
            //code after success
            $("#Photo").val(response);
            alert("Photo Upload Successfully");
        },
        error: function (er) {
            alert(er);
        }

    });
});

//Function for clearing the textboxes 
function clearTextBox() {

    $('#FinancialDocId').val("");
    $('#DoccumentName').val("");
   
    $('#Title').val("");
    $('#Date').val("");
    $('#Phonenumber').val("");
    $('#Address').val("");
    $('#Email').val("");
    $('#File').val("");
    $('#Photo').val("");

    $('#btnUpdate').hide();
    $('#btnAdd').show();

    $('#FinancialDocId').css('border-color', 'lightgrey');
    $('#DoccumentName').css('border-color', 'lightgrey');
    
    $('#Title').css('border-color', 'lightgrey');
    $('#Date').css('border-color', 'lightgrey');
    $('#Phonenumber').css('border-color', 'lightgrey');
    $('#Address').css('border-color', 'lightgrey');
    $('#Email').css('border-color', 'lightgrey');
    $('#File').css('border-color', 'lightgrey');
    $('#Photo').css('border-color', 'lightgrey');
}

//Valdidation using jquery 
function validate() {
    var isValid = true;
    if ($('#FinancialDocId').val().trim() == "") {
        $('#FinancialDocId').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#FinancialDocId').css('border-color', 'lightgrey');
    }
    if ($('#DoccumentName').val().trim() == "") {
        $('#DoccumentName').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#DoccumentName').css('border-color', 'lightgrey');
    }
    
    if ($('#Title').val().trim() == "") {
        $('#Title').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#Title').css('border-color', 'lightgrey');
    }
    if ($('#Date').val().trim() == "") {
        $('#Date').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#Date').css('border-color', 'lightgrey');
    }
    if ($('#Phonenumber').val().trim() == "") {
        $('#Phonenumber').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#Phonenumber').css('border-color', 'lightgrey');
    }
    if ($('#Address').val().trim() == "") {
        $('#Address').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#Address').css('border-color', 'lightgrey');
    }
    if ($('#Email').val().trim() == "") {
        $('#Email').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#Email').css('border-color', 'lightgrey');
    }
    if ($('#File').val().trim() == "") {
        $('#File').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#File').css('border-color', 'lightgrey');
    }
    if ($('#Photo').val().trim() == "") {
        $('#Photo').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#Photo').css('border-color', 'lightgrey');
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