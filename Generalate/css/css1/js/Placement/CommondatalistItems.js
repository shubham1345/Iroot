
//Load Data in Table when documents is ready 
$(document).ready(function () {
    
    //loadDataListItems();
    GetAllSDatalistItems();
});


//Get All Student Details
function GetAllSDatalistItems() {
    //var tb = document.getElementById('Studenttbl');
    //while (tb.rows.length > 1) {
    //    tb.deleteRow(1);
    //}

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "Student.asmx/GetAllDataList",
        //data: "{'RegNo' : '" + RegstrNo + "'}",
        dataType: "json",
        success: function (data) {
            for (var i = 0; i < data.d.length; i++) {
                $("#EmpInfo").append("<tr><td hidden='hidden'>" + data.d[i].DatalistId + "</td><td>" + data.d[i].DataListName + "</td><td>" + data.d[i].DataListItemName
                    + "</td><td>" + data.d[i].Status + "</td><td>"
                    + '<a href="UpdateDataList.aspx?Action=View&Id=' + data.d[i].DatalistId + '">View</a> | <a href="UpdateDataList.aspx?Action=Update&Id=' + data.d[i].DatalistId + '">Edit</a> | <a href="#" onclick="DeleteDatalist(' + data.d[i].DatalistId + ')">Delete</a></td><tr>');
            }

        },
        error: function (result) {
            alert("Error");
        }
    });
}

function loadData() {
    var tb = document.getElementById('EmpInfo');
    while (tb.rows.length > 1) {
        tb.deleteRow(1);
    }

    $.getJSON("Student.asmx/GetAllDataList",
        function (data) {
            var tr;
            
            //Append each row to html table
            for (var i = 0; i < json.length; i++) {
                tr = $('<tr />');
                tr.append("<td hidden='hidden'>" + json[i].DatalistId + "</td>");
                tr.append("<td>" + json[i].DataListName + "</td>");
                tr.append("<td>" + json[i].DataListItemName + "</td>");
                tr.append("<td>" + json[i].Status + "</td>");
                tr.append('<td><a href="#" onclick="return getbyID(' + json[i].DatalistId + ')">Edit</a> | <a href="#" onclick="Delele(' + json[i].DatalistId + ')">Delete</a></td>')
                $('table').append(tr);

            }
            $('#EmpInfo').DataTable();
        });
}

function loadDataListItems() {
    $.ajax({
        url: "../CommonDataListItems/GetDatalistName",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        //data : { "DlistName"},
        dataType: "json",
        success: function (result) {
            $("#generalst").empty();
            for (var i = 0; i < result.length; i++) {
                $("#generalst").append("<option value='" + result[i].DataListName + "'></option>");
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
            //DatalistId: $('#DatalistId').val(),
            DataListName: $('#DataListName').val(),
            DataListItemName: $('#DataListItemName').val(),
            Status: $('#Status').val()
        };

    $.ajax({
        url: "Student.asmx/AddDataList",
        //data: JSON.stringify(general),
        data: JSON.stringify({ 'profile': general }),
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
        url: "../CommonDataListItems/GetById/" + GId1,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            
            $('#DatalistId').val(result.DatalistId);
            $('#DataListName').val(result.DataListName);
            $('#DataListItemName').val(result.DataListItemName);
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
            DatalistId: $('#DatalistId').val(),
            DataListName: $('#DataListName').val(),
            DataListItemName: $('#DataListItemName').val(),
            Status: $('#Status').val()
        };

    $.ajax({
        url: "../CommonDataListItems/Update",
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
function DeleteDatalist(ID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "Student.asmx/DeleteDataList",
            type: "POST",
            data: "{'id' : '" + ID + "'}",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                $(this).closest('tr').remove()
                GetAllSDatalistItems();

            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

//Function for clearing the textboxes 
function clearTextBox() {

    $('#DatalistId').val("");
    $('#DataListName').val("");
    $('#DataListItemName').val("");
    $('#Status').val("");

    $('#btnUpdate').hide();
    $('#btnAdd').show();

    $('#DatalistId').css('border-color', 'lightgrey');
    $('#DataListName').css('border-color', 'lightgrey');
    $('#DataListItemName').css('border-color', 'lightgrey');
    $('#Status').css('border-color', 'lightgrey');
}

//Valdidation using jquery 
function validate() {
    var isValid = true;
    if ($('#DataListName').val() == "") {
        $('#DataListName').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#DataListName').css('border-color', 'lightgrey');
    }
    if ($('#DataListItemName').val() == "") {
        $('#DataListItemName').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#DataListItemName').css('border-color', 'lightgrey');
    }
    if ($('#Status').val() == "") {
        $('#Status').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#Status').css('border-color', 'lightgrey');
    }
    return isValid;
}