
//Load Data in Table when documents is ready 
$(document).ready(function () {
    loadData();
    loadDataListItems();

    $('#printbtn').click(function () {
        window.open('../Seminar/SeminarReport');
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
                tr.append("<td hidden='hidden'>" + json[i].SeminarId + "</td>");
                tr.append('<td><a href=ViewProfile/' + json[i].SeminarId + '>' + json[i].Name + '</a></td>');
                tr.append("<td>" + json[i].MemberID + "</td>");
                //tr.append("<td>" + json[i].Community + "</td>");
                tr.append("<td>" + json[i].FromDate + "</td>");
                tr.append("<td>" + json[i].ToDate + "</td>");
                tr.append("<td>" + json[i].SeminarName + "</td>");
                tr.append("<td>" + json[i].Place + "</td>");
                tr.append("<td>" + json[i].Institute + "</td>");
                tr.append('<td><a href="#" onclick="return getbyID(' + json[i].SeminarId + ')">Edit</a> | <a href="#" onclick="Delele(' + json[i].SeminarId + ')">Delete</a></td>')
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
            SeminarId: $('#SeminarId').val(),
            Name: $('#Name').val(),
            //MemberID: $('#MemberID').val(),
            MemberID: $("#tbl_PersonalDetails option:selected").text(),
            Name: $('#Name').val(),
            Community: $('#Community').val(),
            FromDate: $('#FromDate').val(),
            ToDate: $('#ToDate').val(),
            SeminarName: $('#SeminarName').val(),
            Place: $('#Place').val(),
            Institute: $('#Institute').val()
        };

    $.ajax({
        url: "../Seminar/Add",
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
        url: "../Seminar/GetById/" + GId1,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            
            $('#SeminarId').val(result.SeminarId);
            $('#Name').val(result.Name);
            //$('#MemberID').val(result.MemberID);
            $('#tbl_PersonalDetails option:selected').val(result.MemberID);
            $('#Community').val(result.Community);
            $('#FromDate').val(result.FromDate);
            $('#ToDate').val(result.ToDate);
            $('#SeminarName').val(result.SeminarName);
            $('#Place').val(result.Place);
            $('#Institute').val(result.Institute);


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
            SeminarId: $('#SeminarId').val(),
            //Name: $('#Name').val(),
            MemberID: $("#tbl_PersonalDetails option:selected").text(),
            Name: $('#Name').val(),
            Community: $('#Community').val(),
            FromDate: $('#FromDate').val(),
            ToDate: $('#ToDate').val(),
            SeminarName: $('#SeminarName').val(),
            Place: $('#Place').val(),
            Institute: $('#Institute').val()

        };

    $.ajax({
        url: "../Seminar/Update",
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
            url: "../Seminar/Delete/" + ID,
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

    $('#SeminarId').val("");
    $('#Name').val("");
    $('#MemberID').val("");
    $('#Community').val("");
    $('#FromDate').val("");
    $('#ToDate').val("");
    $('#SeminarName').val("");
    $('#Place').val("");
    $('#Institute').val("");

    $('#btnUpdate').hide();
    $('#btnAdd').show();

    $('#SeminarId').css('border-color', 'lightgrey');
    $('#Name').css('border-color', 'lightgrey');
    $('#MemberID').css('border-color', 'lightgrey');
    $('#Community').css('border-color', 'lightgrey');
    $('#FromDate').css('border-color', 'lightgrey');
    $('#ToDate').css('border-color', 'lightgrey');
    $('#SeminarName').css('border-color', 'lightgrey');
    $('#Place').css('border-color', 'lightgrey');
    $('#Institute').css('border-color', 'lightgrey');
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