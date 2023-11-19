
//Load Data in Table when documents is ready 
$(document).ready(function () {
    loadData();
    loadDataListItems();

    $('#printbtn').click(function () {
        window.open('../ProFormationTeam/FormationTeamReport');
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
                tr.append("<td hidden='hidden'>" + json[i].PFTId + "</td>");
                tr.append('<td><a href=ViewProfile/' + json[i].PFTId + '>' + json[i].Name + '</a></td>');
                tr.append("<td>" + json[i].CommencementDate + "</td>");
                tr.append("<td>" + json[i].CompletionDate + "</td>");
                tr.append("<td>" + json[i].Place + "</td>");
                tr.append("<td>" + json[i].Mobile + "</td>");
                tr.append("<td>" + json[i].Email + "</td>");
                tr.append("<td>" + json[i].Designation + "</td>");
                tr.append("<td hidden='hidden'>" + json[i].Portfolio + "</td>");
                tr.append('<td><a href="#" onclick="return getbyID(' + json[i].PFTId + ')">Edit</a> | <a href="#" onclick="Delele(' + json[i].PFTId + ')">Delete</a></td>')
                $('table').append(tr);

            }
            $('#EmpInfo').DataTable();
        });
}

function loadDataListItems() {
    $.ajax({
        url: "../CommonDataListItems/GetDatalistItemsByModuleName/?DlistName=ProFormationTeam",
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
            PFTId: $('#PFTId').val(),
            VarPFTId: $('#VarPFTId').val(),
            Name: $('#Name').val(),
            CommencementDate: $('#CommencementDate').val(),
            CompletionDate: $('#CompletionDate').val(),
            Place: $('#Place').val(),
            Email: $('#Email').val(),
            Mobile: $('#Mobile').val(),
            Designation: $('#Designation').val(),
            Portfolio: $('#Portfolio').val()
        };

    $.ajax({
        url: "../ProFormationTeam/Add",
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
        url: "../ProFormationTeam/GetById/" + GId1,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            
            $('#PFTId').val(result.PFTId);
            $('#Name').val(result.Name);
            $('#CommencementDate').val(result.CommencementDate);
            $('#CompletionDate').val(result.CompletionDate);
            $('#Place').val(result.Place);
            $('#Email').val(result.Email);
            $('#Mobile').val(result.Mobile);
            $('#Designation').val(result.Designation);
            $('#Portfolio').val(result.Portfolio);
            $('#VarPFTId').val(result.VarPFTId);

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
            PFTId: $('#PFTId').val(),
            Name: $('#Name').val(),
            CommencementDate: $('#CommencementDate').val(),
            CompletionDate: $('#CompletionDate').val(),
            Place: $('#Place').val(),
            Email: $('#Email').val(),
            Mobile: $('#Mobile').val(),
            Designation: $('#Designation').val(),
            Portfolio: $('#Portfolio').val(),
            VarPFTId: $('#VarPFTId').val()
        };

    $.ajax({
        url: "../ProFormationTeam/Update",
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
            url: "../ProFormationTeam/Delete/" + ID,
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

    $('#PFTId').val("");
    $('#Name').val("");
    $('#CommencementDate').val("");
    $('#CompletionDate').val("");
    $('#Place').val("");
    $('#Email').val("");
    $('#Mobile').val("");
    $('#Designation').val("");
    $('#Portfolio').val("");
    $('#VarPFTId').val("");


    $('#btnUpdate').hide();
    $('#btnAdd').show();

    $('#PFTId').css('border-color', 'lightgrey');
    $('#Name').css('border-color', 'lightgrey');
    $('#CommencementDate').css('border-color', 'lightgrey');
    $('#CompletionDate').css('border-color', 'lightgrey');
    $('#Place').css('border-color', 'lightgrey');
    $('#Email').css('border-color', 'lightgrey');
    $('#Mobile').css('border-color', 'lightgrey');
    $('#Designation').css('border-color', 'lightgrey');
    $('#Portfolio').css('border-color', 'lightgrey');
    $('#VarPFTId').css('border-color', 'lightgrey');
}

//Valdidation using jquery 
function validate() {
    var isValid = true;
    if ($('#Name').val().trim() == "") {
        $('#Name').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#Name').css('border-color', 'lightgrey');
    }
    if ($('#CommencementDate').val().trim() == "") {
        $('#CommencementDate').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#CommencementDate').css('border-color', 'lightgrey');
    }
    if ($('#CompletionDate').val().trim() == "") {
        $('#CompletionDate').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#CompletionDate').css('border-color', 'lightgrey');
    }
    if ($('#Place').val().trim() == "") {
        $('#Place').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#Place').css('border-color', 'lightgrey');
    }
    if ($('#Email').val().trim() == "") {
        $('#Email').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#Email').css('border-color', 'lightgrey');
    }
    if ($('#Mobile').val().trim() == "") {
        $('#Mobile').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#Mobile').css('border-color', 'lightgrey');
    }
    if ($('#Designation').val().trim() == "") {
        $('#Designation').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#Designation').css('border-color', 'lightgrey');
    }
    if ($('#Portfolio').val().trim() == "") {
        $('#Portfolio').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#Portfolio').css('border-color', 'lightgrey');
    }
    if ($('#VarPFTId').val().trim() == "") {
        $('#VarPFTId').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#VarPFTId').css('border-color', 'lightgrey');
    }
    return isValid;
}