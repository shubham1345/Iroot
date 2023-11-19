﻿
//Load Data in Table when documents is ready 
$(document).ready(function () {
    loadData();
    
    loadDataListItems();

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
                tr.append("<td hidden='hidden'>" + json[i].CDLId + "</td>");
                tr.append("<td>" + json[i].DataListName + "</td>");
                tr.append("<td>" + json[i].Status + "</td>");
                tr.append('<td><a href="#" onclick="return getbyID(' + json[i].CDLId + ')">Edit</a> | <a href="#" onclick="Delele(' + json[i].CDLId + ')">Delete</a></td>')
                $('table').append(tr);

            }
            $('#EmpInfo').DataTable();
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
            CDLITId: $('#CDLId').val(),
            DataListName: $('#DataListName').val(),
            Status: $('#Status').val()
        };

    $.ajax({
        url: "../CommonDataList/Add",
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
        url: "../CommonDataList/GetById/" + GId1,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            
            $('#CDLId').val(result.CDLId);
            $('#DataListName').val(result.DataListName);
            $('#Status').val(result.Status);

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
            CDLId: $('#CDLId').val(),
            DataListName: $('#DataListName').val(),
            Status: $('#Status').val()
        };

    $.ajax({
        url: "../CommonDataList/Update",
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
            url: "../CommonDataList/Delete/" + ID,
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

    $('#CDLId').val("");
    $('#DataListName').val("");
    $('#Status').val("");

    $('#btnUpdate').hide();
    $('#btnAdd').show();

    $('#CDLId').css('border-color', 'lightgrey');
    $('#DataListName').css('border-color', 'lightgrey');
    $('#Status').css('border-color', 'lightgrey');
}

//Valdidation using jquery 
function validate() {
    var isValid = true;
    if ($('#DataListName').val().trim() == "") {
        $('#DataListName').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#DataListName').css('border-color', 'lightgrey');
    }
    if ($('#Status').val().trim() == "") {
        $('#Status').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#Status').css('border-color', 'lightgrey');
    }
    return isValid;
}