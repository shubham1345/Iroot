
//Load Data in Table when documents is ready 
$(document).ready(function () {
    loadData();
     loadDataListItems();

    $('#printbtn').click(function () {
        window.open('../Entry/EntryReport');
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
                tr.append("<td hidden='hidden'>" + json[i].EntryId + "</td>");
                tr.append('<td><a href=ViewProfile/' + json[i].EntryId + '>' + json[i].MemberID + '</a></td>');
                tr.append("<td>" + json[i].Name + "</td>");
                tr.append("<td>" + json[i].ChurchName1 + "</td>");
                tr.append("<td>" + json[i].DateOfBaptism + "</td>");
                tr.append("<td>" + json[i].Minister1 + "</td>");
                tr.append("<td>" + json[i].Place1 + "</td>");
                //tr.append("<td>" + json[i].ChurchName2 + "</td>");
                //  tr.append("<td hidden='hidden'>" + json[i].DateOfConfirmation + "</td>");

                tr.append("<td hidden='hidden'>" + json[i].Minister2 + "</td>");
                tr.append("<td hidden='hidden'>" + json[i].Place2 + "</td>");
                tr.append('<td><a href="#" onclick="return getbyID(' + json[i].EntryId + ')">Edit</a> | <a href="#" onclick="Delele(' + json[i].EntryId + ')">Delete</a></td>')
                $('table').append(tr);

            }
            $('#EmpInfo').DataTable();
        });
}

function loadDataListItems() {
    $.ajax({
        url: "../CommonDataListItems/GetDatalistItemsByModuleName/?DlistName=Sacrament",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        //data : { "DlistDateOfBaptism"},
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
            EntryId: $('#EntryId').val(),
            DateOfBaptism: $('#DOB').val(),
            MemberID: $("#MemberID option:selected").text(),
            Name: $('#Name').val(),
           // MemberID: $('#MemberID').val(),
            ChurchName1: $('#ChurchName1').val(),
            DateOfConfirmation: $('#DateOfConfirmation').val(),

            Minister1: $('#Minister1').val(),
            Place1: $('#Place1').val(),
            Minister2: $('#Minister2').val(),
            ChurchName2: $('#ChurchName2').val(),
            Place2: $('#Place2').val()
        };

    $.ajax({
        url: "../Entry/Add",
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
        url: "../Entry/GetById/" + GId1,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            
            $('#EntryId').val(result.EntryId);
            $('#DOB').val(result.DateOfBaptism);
            $('#MemberID').val(result.MemberID);
            $('#Name').val(result.Name);
            $('#ChurchName1').val(result.ChurchName1);
            $('#DateOfConfirmation').val(result.DateOfConfirmation);

            $('#Minister1').val(result.Minister1);
            $('#Place1').val(result.Place1);
            $('#Minister2').val(result.Minister2);
            $('#ChurchName2').val(result.ChurchName2);
            $('#Place2').val(result.Place2);


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
            EntryId: $('#EntryId').val(),
            DateOfBaptism: $('#DOB').val(),
            MemberID: $('#MemberID').val(),
            Name:$('#Name').val(),
            ChurchName1: $('#ChurchName1').val(),
            DateOfConfirmation: $('#DateOfConfirmation').val(),

            Minister1: $('#Minister1').val(),
            Place1: $('#Place1').val(),
            Minister2: $('#Minister2').val(),
            ChurchName2: $('#ChurchName2').val(),
            Place2: $('#Place2').val(),

        };

    $.ajax({
        url: "../Entry/Update",
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
            url: "../Entry/Delete/" + ID,
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

    $('#EntryId').val("");
    $('#DOB').val("");
    $('#MemberID').val("");
    $('#DateOfConfirmation').val("");
    $('#ChurchName1').val("");
    $('#Minister1').val("");
    $('#Place1').val("");
    $('#Minister2').val("");
    $('#ChurchName2').val("");
    $('#Place2').val("");

    $('#btnUpdate').hide();
    $('#btnAdd').show();

    $('#EntryId').css('border-color', 'lightgrey');
    $('#DOB').css('border-color', 'lightgrey');
    $('#MemberID').css('border-color', 'lightgrey');
    $('#DateOfConfirmation').css('border-color', 'lightgrey');
    $('#ChurchName1').css('border-color', 'lightgrey');
    $('#Minister1').css('border-color', 'lightgrey');
    $('#Place1').css('border-color', 'lightgrey');
    $('#Minister2').css('border-color', 'lightgrey');
    $('#ChurchName2').css('border-color', 'lightgrey');
    $('#Place2').css('border-color', 'lightgrey');
}

//Valdidation using jquery 
function validate() {
    var isValid = true;
    //if ($('#DateOfBaptism').val().trim() == "") {
    //    $('#DateOfBaptism').css('border-color', 'Red'); isValid = false;
    //}
    //else {
    //    $('#DateOfBaptism').css('border-color', 'lightgrey');
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
    //if ($('#Minister2').val().trim() == "") {
    //    $('#Minister2').css('border-color', 'Red'); isValid = false;
    //}
    //else {
    //    $('#Minister2').css('border-color', 'lightgrey');
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
////Load Data in Table when documents is ready 
//$(document).ready(function () {
//    loadData();
//    //loadDataListItems();

//    $('#printbtn').click(function () {
//        window.open('../Entry/EntryReport');
//    });

//});


//function loadData() {
//    var tb = document.getElementById('EmpInfo');
//    while (tb.rows.length > 1) {
//        tb.deleteRow(1);
//    }

//    $.getJSON("GetAll",
//        function (json) {
//            var tr;

//            //Append each row to html table
//            for (var i = 0; i < json.length; i++) {
//                tr = $('<tr />');
//                tr.append("<td hidden='hidden'>" + json[i].EntryId + "</td>");
//                tr.append('<td><a href=ViewProfile/' + json[i].EntryId + '>' + json[i].MemberID + '</a></td>');
//                tr.append("<td>" + json[i].DateOfBaptism + "</td>");
//                tr.append("<td>" + json[i].ChurchName1 + "</td>");
//                tr.append("<td>" + json[i].Minister1 + "</td>");
//                tr.append("<td>" + json[i].Place1 + "</td>");
//                tr.append("<td>" + json[i].DateOfConfirmation + "</td>");
//                tr.append("<td hidden='hidden'>" + json[i].ChurchName2 + "</td>");
//                tr.append("<td hidden='hidden'>" + json[i].Minister2 + "</td>");
//                tr.append("<td hidden='hidden'>" + json[i].Place2 + "</td>");
//                tr.append('<td><a href="#" onclick="return getbyID(' + json[i].EntryId + ')">Edit</a> | <a href="#" onclick="Delele(' + json[i].EntryId + ')">Delete</a></td>')
//                $('table').append(tr);

//            }
//            $('#EmpInfo').DataTable();
//        });
//}

//function loadDataListItems() {
//    $.ajax({
//        url: "../CommonDataListItems/GetDatalistItemsByModuleDateOfBaptism/?DlistName=General",
//        type: "GET",
//        contentType: "application/json;charset=utf-8",
//        //data : { "DlistDateOfBaptism"},
//        dataType: "json",
//        success: function (result) {
//            $("#generalst").empty();
//            for (var i = 0; i < result.length; i++) {
//                $("#generalst").append("<option value='" + result[i].DataListItemName + "'></option>");
//            }

//        },

//        error: function (errormessage) {
//            alert(errormessage.responseText);
//        }

//    });

//}

////Add Data Function 
//function Add() {
//    var res = validate();
//    if (res == false) {
//        return false;
//    }

//    var datenow = new Date();

//    var general =
//        {
//            EntryId: $('#EntryId').val(),
//            DateOfBaptism: $('#DateOfBaptism').val(),
//            MemberID: $('#MemberID').val(),
//            DateOfConfirmation: $('#DateOfConfirmation').val(),
//            ChurchName1: $('#ChurchName1').val(),
//            Minister1: $('#Minister1').val(),
//            Place1: $('#Place1').val(),
//            Minister2: $('#Minister2').val(),
//            ChurchName2: $('#ChurchName2').val(),
//            Place2: $('#Place2').val()
//        };

//    $.ajax({
//        url: "../Entry/Add",
//        data: JSON.stringify(general),
//        type: "POST",
//        contentType: "application/json;charset=utf-8",
//        dataType: "json",
//        success: function (result) {
//            loadData();
//            clearTextBox();
//            $('#myModal').modal('hide');
//        },
//        error: function (errormessage) {
//            alert(errormessage.responseText);
//        }
//    });
//}

////Function for getting the Data Based upon Employee ID 
//function getbyID(GId1) {
//    $.ajax({
//        url: "../Entry/GetById/" + GId1,
//        type: "GET",
//        contentType: "application/json;charset=UTF-8",
//        dataType: "json",
//        success: function (result) {
//            
//            $('#EntryId').val(result.EntryId);
//            $('#DateOfBaptism').val(result.DateOfBaptism);
//            $('#MemberID').val(result.MemberID);
//            $('#DateOfConfirmation').val(result.DateOfConfirmation);
//            $('#ChurchName1').val(result.ChurchName1);
//            $('#Minister1').val(result.Minister1);
//            $('#Place1').val(result.Place1);
//            $('#Minister2').val(result.Minister2);
//            $('#ChurchName2').val(result.ChurchName2);
//            $('#Place2').val(result.Place2);


//            $('#myModal').modal('show');
//            $('#btnUpdate').show();
//            $('#btnAdd').hide();
//        },
//        error: function (errormessage) {
//            alert(errormessage.responseText);
//        }
//    }); return false;
//}

////function for updating General's record 
//function Update() {
//    var res = validate();
//    if (res == false) {
//        return false;
//    }

//    var datenow = new Date();

//    var empObj =
//        {
//            EntryId: $('#EntryId').val(),
//            DateOfBaptism: $('#DateOfBaptism').val(),
//            MemberID: $('#MemberID').val(),
//            DateOfConfirmation: $('#DateOfConfirmation').val(),
//            ChurchName1: $('#ChurchName1').val(),
//            Minister1: $('#Minister1').val(),
//            Place1: $('#Place1').val(),
//            Minister2: $('#Minister2').val(),
//            ChurchName2: $('#ChurchName2').val(),
//            Place2: $('#Place2').val(),

//        };

//    $.ajax({
//        url: "../Entry/Update",
//        data: JSON.stringify(empObj),
//        type: "POST",
//        contentType: "application/json;charset=utf-8",
//        dataType: "json",
//        success: function (result) {
//            loadData();
//            $('#myModal').modal('hide');
//        },
//        error: function (errormessage) {
//            alert(errormessage.responseText);
//        }
//    });
//}

////function for deleting employee's record 
//function Delele(ID) {
//    var ans = confirm("Are you sure you want to delete this Record?");
//    if (ans) {
//        $.ajax({
//            url: "../Entry/Delete/" + ID,
//            type: "POST",
//            contentType: "application/json;charset=UTF-8",
//            dataType: "json",
//            success: function (result) {
//                $(this).closest('tr').remove()
//                loadData();

//            },
//            error: function (errormessage) {
//                alert(errormessage.responseText);
//            }
//        });
//    }
//}

////Function for clearing the textboxes 
//function clearTextBox() {

//    $('#EntryId').val("");
//    $('#DateOfBaptism').val("");
//    $('#MemberID').val("");
//    $('#DateOfConfirmation').val("");
//    $('#ChurchName1').val("");
//    $('#Minister1').val("");
//    $('#Place1').val("");
//    $('#Minister2').val("");
//    $('#ChurchName2').val("");
//    $('#Place2').val("");

//    $('#btnUpdate').hide();
//    $('#btnAdd').show();

//    $('#EntryId').css('border-color', 'lightgrey');
//    $('#DateOfBaptism').css('border-color', 'lightgrey');
//    $('#MemberID').css('border-color', 'lightgrey');
//    $('#DateOfConfirmation').css('border-color', 'lightgrey');
//    $('#ChurchName1').css('border-color', 'lightgrey');
//    $('#Minister1').css('border-color', 'lightgrey');
//    $('#Place1').css('border-color', 'lightgrey');
//    $('#Minister2').css('border-color', 'lightgrey');
//    $('#ChurchName2').css('border-color', 'lightgrey');
//    $('#Place2').css('border-color', 'lightgrey');
//}

////Valdidation using jquery 
//function validate() {
//    var isValid = true;
//    //if ($('#DateOfBaptism').val().trim() == "") {
//    //    $('#DateOfBaptism').css('border-color', 'Red'); isValid = false;
//    //}
//    //else {
//    //    $('#DateOfBaptism').css('border-color', 'lightgrey');
//    //}
//    //if ($('#CommencementDate').val().trim() == "") {
//    //    $('#CommencementDate').css('border-color', 'Red'); isValid = false;
//    //}
//    //else {
//    //    $('#CommencementDate').css('border-color', 'lightgrey');
//    //}
//    //if ($('#CompletionDate').val().trim() == "") {
//    //    $('#CompletionDate').css('border-color', 'Red'); isValid = false;
//    //}
//    //else {
//    //    $('#CompletionDate').css('border-color', 'lightgrey');
//    //}
//    //if ($('#Minister2').val().trim() == "") {
//    //    $('#Minister2').css('border-color', 'Red'); isValid = false;
//    //}
//    //else {
//    //    $('#Minister2').css('border-color', 'lightgrey');
//    //}
//    //if ($('#Email').val().trim() == "") {
//    //    $('#Email').css('border-color', 'Red'); isValid = false;
//    //}
//    //else {
//    //    $('#Email').css('border-color', 'lightgrey');
//    //}
//    //if ($('#Mobile').val().trim() == "") {
//    //    $('#Mobile').css('border-color', 'Red'); isValid = false;
//    //}
//    //else {
//    //    $('#Mobile').css('border-color', 'lightgrey');
//    //}
//    //if ($('#Designation').val().trim() == "") {
//    //    $('#Designation').css('border-color', 'Red'); isValid = false;
//    //}
//    //else {
//    //    $('#Designation').css('border-color', 'lightgrey');
//    //}
//    //if ($('#Portfolio').val().trim() == "") {
//    //    $('#Portfolio').css('border-color', 'Red'); isValid = false;
//    //}
//    //else {
//    //    $('#Portfolio').css('border-color', 'lightgrey');
//    //}
//    //if ($('#VarGId').val().trim() == "") {
//    //    $('#VarGId').css('border-color', 'Red'); isValid = false;
//    //}
//    //else {
//    //    $('#VarGId').css('border-color', 'lightgrey');
//    //}
//    return isValid;
//}