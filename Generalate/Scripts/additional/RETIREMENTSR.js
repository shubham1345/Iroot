
//Load Data in Table when documents is ready 
$(document).ready(function () {
    loadData();
    loadDataListItems();

    $('#printbtn').click(function () {
        window.open('../Retirement/RetirementReport');
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
                tr.append("<td hidden='hidden'>" + json[i].RetirementId + "</td>");
                tr.append("<td style=display:none;>" + json[i].MemberID + "</td>");
                tr.append("<td>" + json[i].SirName + "</td>");
                tr.append('<td><a href=ViewProfile/' + json[i].RetirementId + '>' + json[i].Name + '</a></td>');
               
                tr.append("<td>" + json[i].DOR + "</td>");
                tr.append("<td>" + json[i].Age + "</td>");
                tr.append("<td>" + json[i].Reason + "</td>");
                tr.append("<td>" + json[i].Community + "</td>");
                tr.append("<td>" + json[i].Remarks + "</td>");
                tr.append('<td><a href="#" onclick="return getbyID(' + json[i].RetirementId + ')">Edit</a> | <a href="#" onclick="Delele(' + json[i].RetirementId + ')">Delete</a></td>')
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
        //data : { "DlistDOR"},
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
            RetirementId: $('#RetirementId').val(),
            DOR: $('#DOR').val(),
            // MemberID: $('#MemberID').val(),
            SirName: $("#SirName option:selected").text(),
            Remarks: $('#Remarks').val(),
            Age: $('#Age').val(),
            Reason: $('#Reason').val(),
            Name: $('#Name').val(),
            MemberID: $('#MemberID').val(),
            Community: $('#Community').val()
        };

    $.ajax({
        url: "../Retirement/Add",
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
        url: "../Retirement/GetById/" + GId1,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            
            $('#MemberID').val(result.RetirementId);
            $('#DOR').val(result.DOR);
            $('#MemberID').val(result.MemberID);
            $('#Remarks').val(result.Remarks);
            $('#Age').val(result.Age);
            $('#Reason').val(result.Reason);
            $('#Community').val(result.Community);
            $('#Name').val(result.Name);
            $('#SirName').val(result.SirName);
            $("#SirName select").val(result.SirName);

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
            RetirementId: $('#RetirementId').val(),
            DOR: $('#DOR').val(),
            //   MemberID: $('#MemberID').val(),
            SirName: $("#SirName option:selected").text(),
            Remarks: $('#Remarks').val(),
            Age: $('#Age').val(),
            Reason: $('#Reason').val(),
            Community: $('#Community').val(),
            Name: $('#Name').val(),
            MemberID: $('#MemberID').val()


        };

    $.ajax({
        url: "../Retirement/Update",
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
            url: "../Retirement/Delete/" + ID,
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

    $('#RetirementId').val("");
    $('#DOR').val("");
    $('#MemberID').val("");
    $('#Remarks').val("");
    $('#Age').val("");
    $('#Reason').val("");
    $('#Community').val("");
    $('#Name').val("");


    $('#btnUpdate').hide();
    $('#btnAdd').show();

    $('#RetirementId').css('border-color', 'lightgrey');
    $('#DOR').css('border-color', 'lightgrey');
    $('#MemberID').css('border-color', 'lightgrey');
    $('#Remarks').css('border-color', 'lightgrey');
    $('#Age').css('border-color', 'lightgrey');
    $('#Reason').css('border-color', 'lightgrey');
    $('#Community').css('border-color', 'lightgrey');
    $('#Name').css('border-color', 'lightgrey');

}

//Valdidation using jquery 
function validate() {
    var isValid = true;
    //if ($('#DOR').val().trim() == "") {
    //    $('#DOR').css('border-color', 'Red'); isValid = false;
    //}
    //else {
    //    $('#DOR').css('border-color', 'lightgrey');
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
    //if ($('#Medium').val().trim() == "") {
    //    $('#Medium').css('border-color', 'Red'); isValid = false;
    //}
    //else {
    //    $('#Medium').css('border-color', 'lightgrey');
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