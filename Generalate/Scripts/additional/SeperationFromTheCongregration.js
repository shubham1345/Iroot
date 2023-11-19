﻿
//Load Data in Table when documents is ready 
$(document).ready(function () {
    loadData();
    loadDataListItems();

    $('#printbtn').click(function () {
        window.open('../SeperationFromTheCongregation/SeperationReport');
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
                tr.append("<td hidden='hidden'>" + json[i].SeperationId + "</td>");
                tr.append('<td><a href=ViewProfile/' + json[i].SeperationId + '>' + json[i].Name + '</a></td>');
                tr.append("<td>" + json[i].MemberID + "</td>");
                tr.append("<td>" + json[i].SeperationDate + "</td>");
                tr.append("<td>" + json[i].Purpose + "</td>");
                tr.append("<td>" + json[i].NatureOfSeperation + "</td>");
                tr.append('<td><a href="#" onclick="return getbyID(' + json[i].SeperationId + ')">Edit</a> | <a href="#" onclick="Delele(' + json[i].SeperationId + ')">Delete</a></td>')
                $('table').append(tr);

            }
            $('#EmpInfo').DataTable();
        });
}

function loadDataListItems() {
    $.ajax({
        url: "../CommonDataListItems/GetDatalistItemsByModuleName/?DlistName=General",
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
            SeperationId: $('#SeperationId').val(),
            MemberID: $('#MemberID').val(),
            Name: $('#Name').val(),
            SeperationDate: $('#SeperationDate').val(),
            Purpose: $('#Purpose').val(),
            NatureOfSeperation: $('#NatureOfSeperation').val()
        };

    $.ajax({
        url: "../SeperationFromTheCongregation/Add",
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
        url: "../SeperationFromTheCongregation/GetById/" + GId1,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            
            $('#SeperationId').val(result.SeperationId);
            $('#tbl_PersonalDetails option:selected').val(result.MemberID);
            $('#Name').val(result.Name);
            $('#SeperationDate').val(result.SeperationDate);
            $('#Purpose').val(result.Purpose);
            $('#NatureOfSeperation').val(result.NatureOfSeperation);
           

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
           SeperationId: $('#SeperationId').val(),
           MemberID: $("#tbl_PersonalDetails option:selected").text(),
           Name: $('#Name').val(),
           SeperationDate: $('#SeperationDate').val(),
           Purpose: $('#Purpose').val(),
           NatureOfSeperation: $('#NatureOfSeperation').val()
         


       };
    //var empObj =
    //    {
    //        SeperationId: $('#SeperationId').val(),
    //        $('#tbl_PersonalDetails option:selected').val(result.MemberID),
    //            Name: $('#Name').val(),
    //            SeperationDate: $('#SeperationDate').val(),
    //            Purpose: $('#Purpose').val(),
    //            NatureOfSeperation: $('#NatureOfSeperation').val()
           
    //        };

    $.ajax({
        url: "../SeperationFromTheCongregation/Update",
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
            url: "../SeperationFromTheCongregation/Delete/" + ID,
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

    $('#SeperationId').val("");
    $('#MemberID').val("");
    $('#Name').val("");
    $('#SeperationDate').val("");
    $('#Purpose').val("");
    $('#NatureOfSeperation').val("");
    


    $('#btnUpdate').hide();
    $('#btnAdd').show();

    $('#SeperationId').css('border-color', 'lightgrey');
    $('#MemberID').css('border-color', 'lightgrey');
    $('#Name').css('border-color', 'lightgrey');
    $('#SeperationDate').css('border-color', 'lightgrey');
    $('#Purpose').css('border-color', 'lightgrey');
    $('#NatureOfSeperation').css('border-color', 'lightgrey');
   
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