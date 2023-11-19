﻿
//Load Data in Table when documents is ready 
$(document).ready(function () {
    loadData();
    loadDataListItems();
    loadDataListItemsbylanguages()
    $('#printbtn').click(function () {
        window.open('../KnownLanguages/KnownLanguagesReport');
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
                tr.append("<td hidden='hidden'>" + json[i].KnownLanguagesId + "</td>");
                tr.append('<td><a href=ViewProfile/' + json[i].KnownLanguagesId + '>' + json[i].MemberID + '</a></td>');
                tr.append("<td>" + json[i].LanguageName + "</td>");
                tr.append("<td>" + json[i].ToRead + "</td>");
                tr.append("<td>" + json[i].ToWrite + "</td>");
                tr.append("<td>" + json[i].ToSpeak + "</td>");
                tr.append('<td><a href="#" onclick="return getbyID(' + json[i].KnownLanguagesId + ')">Edit</a> | <a href="#" onclick="Delele(' + json[i].KnownLanguagesId + ')">Delete</a></td>')
                $('table').append(tr);

            }
            $('#EmpInfo').DataTable();
        });
}
function loadDataListItems() {
    $.ajax({
        url: "../CommonDataListItems/GetDatalistItemsByModuleName/?DlistName=Province",
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


function loadDataListItemsbylanguages() {
    $.ajax({
        url: "../CommonDataListItems/GetDatalistItemsByModuleName/?DlistName=Province",
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
    var res = validate();
    if (res == false) {
        return false;
    }

    var datenow = new Date();

    var general =
        {
            KnownLanguagesId: $('#KnownLanguagesId').val(),
            MemberID: $('#MemberID').val(),
            LanguageName: $('#LanguageName').val(),
            ToRead: $('#ToRead').val(),
            ToWrite: $('#ToWrite').val(),
            ToSpeak: $('#ToSpeak').val()

        };

    $.ajax({
        url: "../KnownLanguages/Add",
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
        url: "../KnownLanguages/GetById/" + GId1,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            
            $('#KnownLanguagesId').val(result.KnownLanguagesId);
            $('#MemberID').val(result.MemberID)
            $('#ToRead').val(result.ToRead);
            $('#ToWrite').val(result.ToWrite);
            $('#ToSpeak').val(result.ToSpeak);
            $('#LanguageName').val(result.LanguageName),


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
    var res = validate();
    if (res == false) {
        return false;
    }

    var datenow = new Date();

    var empObj =
        {
            KnownLanguagesId: $('#KnownLanguagesId').val(),
            MemberID: $('#MemberID').val(),
            ToRead: $('#ToRead').val(),
            ToWrite: $('#ToWrite').val(),
            LanguageName: $('#LanguageName').val(),
            ToSpeak: $('#ToSpeak').val()


        };

    $.ajax({
        url: "../KnownLanguages/Update",
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
            url: "../KnownLanguages/Delete/" + ID,
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

//Function for clearing the textboxes 
function clearTextBox() {

    $('#KnownLanguagesId').val("");
    $('#MemberID').val("");
    $('#ToRead').val("");
    $('#ToSpeak').val("");
    $('#ToWrite').val("");
    $('#LanguageName').val(""),

    $('#btnUpdate').hide();
    $('#btnAdd').show();

    $('#KnownLanguagesId').css('border-color', 'lightgrey');
    $('#MemberID').css('border-color', 'lightgrey');
    $('#ToRead').css('border-color', 'lightgrey');
    $('#ToSpeak').css('border-color', 'lightgrey');
    $('#ToWrite').css('border-color', 'lightgrey');
    $('#LanguageName').css('border-color', 'lightgrey');
}

//Valdidation using jquery 
function validate() {
    var isValid = true;
    //if ($('#Name').val().trim() == "") {
    //    $('#Name').css('border-color', 'Red'); isValid = false;
    //}
    //else {
    //    $('#Name').css('border-color', 'lightgrey');
    //}
    //if ($('#CommencementDate').val().trim() == "") {
    //    $('#CommencementDate').css('border-color', 'Red'); isValid = false;
    //}
    //else {
    //    $('#CommencementDate').css('border-color', 'lightgrey');
    //}
    //if ($('#CompletionDate').val().trim() == "") {
    //    $('#CompletionDate').css('border-color', 'Red'); isValid = false;
    //}
    //else {
    //    $('#CompletionDate').css('border-color', 'lightgrey');
    //}
    //if ($('#Place').val().trim() == "") {
    //    $('#Place').css('border-color', 'Red'); isValid = false;
    //}
    //else {
    //    $('#Place').css('border-color', 'lightgrey');
    //}
    //if ($('#Email').val().trim() == "") {
    //    $('#Email').css('border-color', 'Red'); isValid = false;
    //}
    //else {
    //    $('#Email').css('border-color', 'lightgrey');
    //}
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