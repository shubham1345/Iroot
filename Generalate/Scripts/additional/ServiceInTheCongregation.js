
//Load Data in Table when documents is ready 
$(document).ready(function () {
    loadData();
    //loadDataListItems();
    loadServiceDataListItems();

    $('#printbtn').click(function () {
        window.open('../ServiceInTheCongregation/ServiceReport');
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
                tr.append("<td hidden='hidden'>" + json[i].ServiceId + "</td>");
                tr.append('<td><a href=ViewProfile/' + json[i].ServiceId + '>' + json[i].Name + '</a></td>');
                tr.append("<td>" + json[i].MemberID + "</td>");
                tr.append("<td>" + json[i].FromDate + "</td>");
                tr.append("<td>" + json[i].ToDate + "</td>");
                tr.append("<td>" + json[i].Community + "</td>");
                tr.append("<td>" + json[i].EmailId + "</td>");
                tr.append("<td>" + json[i].superiorName + "</td>");
                tr.append('<td><a href="#" onclick="return getbyID(' + json[i].ServiceId + ')">Edit</a> | <a href="#" onclick="Delele(' + json[i].ServiceId + ')">Delete</a></td>')
                $('table').append(tr);

            }
            $('#EmpInfo').DataTable();
        });
}

//function loadDataListItems() {
//    $.ajax({
//        url: "../CommonDataListItems/GetDatalistItemsByModuleName/?DlistName=General",
//        type: "GET",
//        contentType: "application/json;charset=utf-8",
//        //data : { "DlistName"},
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

function loadServiceDataListItems() {
    $.ajax({
        url: "../CommonDataListItems/GetDatalistItemsByModuleName/?DlistName=Service",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        //data : { "DlistName"},
        dataType: "json",
        success: function (result) {
            $("#Servicelst").empty();
            for (var i = 0; i < result.length; i++) {
                $("#Servicelst").append("<option value='" + result[i].DataListItemName + "'></option>");
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
            ServiceId: $('#ServiceId').val(),
            MemberID: $('#MemberID').val(),
            Name: $('#Name').val(),
            FromDate: $('#FromDate').val(),
            ToDate: $('#ToDate').val(),
            Address: $('#Address').val(),
            Community: $('#Community').val(),
            Office: $('#Office').val(),
            Other: $('#Other').val(),
            superiorName: $('#superiorName').val(),
            EmailId: $('#EmailId').val()
        };

    $.ajax({
        url: "../ServiceInTheCongregation/Add",
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
        url: "../ServiceInTheCongregation/GetById/" + GId1,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            
            $('#ServiceId').val(result.ServiceId);
            $('#MemberID').val(result.MemberID)
            $('#Name').val(result.Name);
            $('#FromDate').val(result.FromDate);
            $('#ToDate').val(result.ToDate);
            $('#Address').val(result.Address);
            $('#Community').val(result.Community);
            $('#Office').val(result.Office);
            $('#Other').val(result.Other);
            $('#superiorName').val(result.superiorName);
            $('#EmailId').val(result.EmailId);

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
            ServiceId: $('#ServiceId').val(),
            MemberID: $('#MemberID').val(),
            Name: $('#Name').val(),
            FromDate: $('#FromDate').val(),
            ToDate: $('#ToDate').val(),
            Address: $('#Address').val(),
            Community: $('#Community').val(),
            Office: $('#Office').val(),
            Other: $('#Other').val(),
            superiorName: $('#superiorName').val(),
            EmailId: $('#EmailId').val()
        };

    $.ajax({
        url: "../ServiceInTheCongregation/Update",
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
            url: "../ServiceInTheCongregation/Delete/" + ID,
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

    $('#ServiceId').val("");
    $('#MemberID').val("");
    $('#Name').val("");
    $('#FromDate').val("");
    $('#ToDate').val("");
    $('#Address').val("");
    $('#Community').val("");
    $('#Office').val("");
    $('#Other').val("");
    $('#superiorName').val("");
    $('#EmailId').val("");


    $('#btnUpdate').hide();
    $('#btnAdd').show();

    $('#ServiceId').css('border-color', 'lightgrey');
    $('#MemberID').css('border-color', 'lightgrey');
    $('#Name').css('border-color', 'lightgrey');
    $('#FromDate').css('border-color', 'lightgrey');
    $('#ToDate').css('border-color', 'lightgrey');
    $('#Address').css('border-color', 'lightgrey');
    $('#Community').css('border-color', 'lightgrey');
    $('#Office').css('border-color', 'lightgrey');
    $('#Other').css('border-color', 'lightgrey');
    $('#superiorName').css('border-color', 'lightgrey');
    $('#EmailId').css('border-color', 'lightgrey');
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