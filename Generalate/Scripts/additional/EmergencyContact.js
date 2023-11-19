//Load Data in Table when documents is ready 
$(document).ready(function () {
    loadData();

    loadDataListItems();

    $('#printbtn').click(function () {
        window.open('../EmergencyContact/ContactReport');
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
                tr.append("<td hidden='hidden'>" + json[i].EmergencyContactId + "</td>");
                tr.append('<td style=display:none;><a href="#"/' + json[i].GId + '>' + json[i].MemberID + '</a></td>');
                tr.append("<td>" + json[i].SirName + "</td>");

                tr.append("<td>" + json[i].Name + "</td>");
                tr.append("<td>" + json[i].Relationship + "</td>");
                tr.append("<td>" + json[i].Mobile + "</td>");
                tr.append("<td>" + json[i].Landline + "</td>");
                tr.append("<td>" + json[i].EmailID + "</td>");
                tr.append("<td>" + json[i].Address + "</td>");
                tr.append('<td><a href="#" onclick="return getbyID(' + json[i].EmergencyContactId + ')">Edit</a> | <a href="#" onclick="Delele(' + json[i].EmergencyContactId + ')">Delete</a></td>')
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
            EmergencyContactId: $('#EmergencyContactId').val(),
        SirName: $("#SirName option:selected").text(),
            //  $("#SelectedCountryId option:selected").text()
            Name: $('#Name').val(),
        MemberID: $('#MemberID').val(),
            Relationship: $('#Relationship').val(),
            Mobile: $('#Mobile').val(),
            Landline: $('#Landline').val(),
            EmailID: $('#EmailID').val(),
            Address: $('#Address').val()
    };
    
    $.ajax({
        url: "../EmergencyContact/Add",
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
        url: "../EmergencyContact/GetById/" + GId1,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            
            $('#EmergencyContactId').val(result.EmergencyContactId);
            //$('#tbl_PersonalDetails option:selected').val(result.MemberID);
            //TODO Rajesh
            //$("#SirName  option:selected").val(result.SirName);
            //$('#SirName option[value='+ result.SirName +']').attr('selected', 'selected');
            $("#SirName").val(result.SirName);
            $("#SirName select").val(result.SirName);
            
            $("#Name").val(result.Name);
            $("#MemberID").val(result.MemberID);
            $('#Relationship').val(result.Relationship);
            $('#Mobile').val(result.Mobile);
            $('#Landline').val(result.Landline);
            $('#EmailID').val(result.EmailID);
            $('#Address').val(result.Address);

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

            EmergencyContactId: $('#EmergencyContactId').val(),
            SirName: $('#SirName option:selected').text(),
            Name: $("#Name").val(),
            MemberID: $("#MemberID").val(),
            Relationship: $('#Relationship').val(),
            Mobile: $('#Mobile').val(),
            Landline: $('#Landline').val(),
            EmailID: $('#EmailID').val(),
            Address: $('#Address').val()
    };
    
    $.ajax({
        url: "../EmergencyContact/Update",
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
            url: "../EmergencyContact/Delete/" + ID,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                $(this).closest('tr').remove();
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

    $('#EmergencyContactId').val("");
    $('#MemberID').val("");
    $('#Name').val("");
    
    $('#Relationship').val("");
    $('#Mobile').val("");
    $('#Landline').val("");
    $('#EmailID').val("");
    $('#Address').val("");
    $().val();

    $('#btnUpdate').hide();
    $('#btnAdd').show();

    $('#EmergencyContactId').css('border-color', 'lightgrey');
    $('#MemberID').css('border-color', 'lightgrey');
    $('#Relationship').css('border-color', 'lightgrey');
    $('#Mobile').css('border-color', 'lightgrey');
    $('#Landline').css('border-color', 'lightgrey');
    $('#EmailID').css('border-color', 'lightgrey');
    $('#Address').css('border-color', 'lightgrey');
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