//Load Data in Table when documents is ready 
$(document).ready(function () {
    loadData();
    loadDataListItems();

    $('#printbtn').click(function () {
        window.open('../VocationalTrainingDoc/VocationalTrainingDoc1Report');
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
                tr.append("<td hidden='hidden'>" + json[i].VocationalTrainingId + "</td>");
                //tr.append('<td><a href=ViewProfile/' + json[i].VocationalTrainingId + '>' + json[i].VocationalTrainingId + '</a></td>');
                tr.append("<td>" + json[i].DoccumentName + "</td>");
                tr.append("<td>" + json[i].Title + "</td>");
                tr.append("<td>" + json[i].Date + "</td>");
                tr.append("<td>" + json[i].Phonenumber + "</td>");
                tr.append("<td>" + json[i].Activities + "</td>");
                tr.append("<td> <a href=/Images/VocationalTrainingDoc/" + json[i].File + " download>Download</a></td>");
                tr.append("<td> <a href=/Images/VocationalTrainingDoc/" + json[i].File + " view>View</a></td>");
                tr.append('<td><a href="#" onclick="return getbyID(' + json[i].VocationalTrainingId + ')">Edit</a> | <a href="#" onclick="Delele(' + json[i].VocationalTrainingId + ')">Delete</a></td>')
                $('table').append(tr);

            }
            $('VocationalTrainingDocInfo').DataTable();
        });
}

function loadDataListItems() {
    $.ajax({
        url: "../CommonDataListItems/GetDatalistItemsByModuleName/?DlistName=Vocational Training",
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
            VocationalTrainingId: $('#VocationalTrainingId').val(),
            // DoccumentName: $('#DoccumentName').val(),
            // DoccumentName: $("#tbl_VocationalTrainingDoc option:selected").text(),

            DoccumentName: $('#DoccumentName').val(),
            Title: $('#Title').val(),
            Date: $('#Date').val(),
            Phonenumber: $('#Phonenumber').val(),
            Activities: $('#Activities').val(),
            File: $('#File').val()
        };
    
    $.ajax({
        url: "../VocationalTrainingDoc/Add",
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
        url: "../VocationalTrainingDoc/GetById/" + GId1,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            
            $('#VocationalTrainingId').val(result.VocationalTrainingId);
            // $('#tbl_VocationalTrainingDoc option:selected').val(result.VocationalTrainingId)
            $('#DoccumentName').val(result.DoccumentName);
            $('#Title').val(result.Title);
            $('#Date').val(result.Date);
            $('#Phonenumber').val(result.Phonenumber);
            $('#Activities').val(result.Activities);
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
            VocationalTrainingId: $('#VocationalTrainingId').val(),
            //  DoccumentName: $('#DoccumentName').val(),
            // VocationalTrainingId: $("#tbl_VocationalTrainingDoc option:selected").text(),
            DoccumentName: $('#DoccumentName').val(),
            Title: $('#Title').val(),
            Date: $('#Date').val(),
            Phonenumber: $('#Phonenumber').val(),
            Activities: $('#Activities').val(),
            File: $('#File').val(),
        };

    $.ajax({
        url: "../VocationalTrainingDoc/Update",
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
            url: "../VocationalTrainingDoc/Delete/" + ID,
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
        url: "/VocationalTrainingDoc/UploadFile",
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

    $('#VocationalTrainingId').val("");
    $('#DoccumentName').val("");
    $('#Title').val("");
    $('#Date').val("");
    $('#Phonenumber').val("");
    $('#Activities').val("");
    $('#File').val("");

    $('#btnUpdate').hide();
    $('#btnAdd').show();

    $('#VocationalTrainingId').css('border-color', 'lightgrey');
    $('#DoccumentName').css('border-color', 'lightgrey');
    $('#Title').css('border-color', 'lightgrey');
    $('#Date').css('border-color', 'lightgrey');
    $('#Phonenumber').css('border-color', 'lightgrey');
    $('#Activities').css('border-color', 'lightgrey');
    $('#File').css('border-color', 'lightgrey');
}

//Valdidation using jquery 
function validate() {
    var isValid = true;
    if ($('#VocationalTrainingId').val().trim() == "") {
        $('#VocationalTrainingId').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#VocationalTrainingId').css('border-color', 'lightgrey');
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
    if ($('#Activities').val().trim() == "") {
        $('#Activities').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#Activities').css('border-color', 'lightgrey');
    }
    if ($('#File').val().trim() == "") {
        $('#File').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#File').css('border-color', 'lightgrey');
    }
    //if ($('#Mobile').val().trim() == "") {
    //    $('#Mobile').css('border-color', 'Red'); isValid = false;
    //}
    //else {
    //    $('#Mobile').css('border-color', 'lightgrey');
    //}
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