
//Load Data in Table when documents is ready 
$(document).ready(function () {
    loadData();
    loadDataListItems();
    getProvinceNames();

    $('#printbtn').click(function () {
        window.open('../ProCommunityHouses/CommunityReport');
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
                tr.append("<td hidden='hidden'>" + json[i].PCHId + "</td>");
                tr.append('<td><a href=ViewProfile/' + json[i].PCHId + '>' + json[i].InstitutionName + '</a></td>');
                tr.append("<td>" + json[i].VarPCHId + "</td>");
                tr.append("<td hidden='hidden'>" + json[i].Address + "</td>");
                tr.append("<td>" + json[i].Activities + "</td>");
                tr.append("<td>" + json[i].Email + "</td>");
                tr.append("<td>" + json[i].Mobile + "</td>");
                tr.append("<td hidden='hidden'>" + json[i].Wesite + "</td>");
                tr.append("<td hidden='hidden'>" + json[i].CommunityProfile + "</td>");
                tr.append('<td><a href="#" onclick="return getbyID(' + json[i].PCHId + ')">Edit</a> | <a href="#" onclick="Delele(' + json[i].PCHId + ')">Delete</a></td>')
                $('table').append(tr);

            }
            $('#EmpInfo').DataTable();
        });
}

function loadDataListItems() {
    $.ajax({
        url: "../CommonDataListItems/GetDatalistItemsByModuleName/?DlistName=ProCommunityHouses",
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

function getProvinceNames() {
    $.ajax({
        url: "../Provincial/GetDistinctProvinceNames",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            $("#provincelist").empty();
            for (var i = 0; i < result.length; i++) {
                $("#provincelist").append("<option value='" + result[i].Name + "'></option>");
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
            PCHId: $('#PCHId').val(),
            VarPCHId: $('#VarPCHId').val(),
            InstitutionName: $('#InstitutionName').val(),
            Address: $('#Address').val(),
            Email: $('#Email').val(),
            Mobile: $('#Mobile').val(),
            Wesite: $('#Website').val(),
            Activities: $('#Activities').val(),
            CommunityProfile: $('#CommunityProfile').val()

        };

    $.ajax({
        url: "../ProCommunityHouses/Add",
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
        url: "../ProCommunityHouses/GetById/" + GId1,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#PCHId').val(result.PCHId);
            $('#InstitutionName').val(result.InstitutionName);
            $('#Website').val(result.Wesite);
            $('#Email').val(result.Email);
            $('#Mobile').val(result.Mobile);
            $('#VarPCHId').val(result.VarPCHId);
            $('#Address').val(result.Address);
            $('#Activities').val(result.Activities);
            $('#CommunityProfile').val(result.CommunityProfile);
            
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
            PCHId: $('#PCHId').val(),
            VarPCHId: $('#VarPCHId').val(),
            InstitutionName: $('#InstitutionName').val(),
            Address: $('#Address').val(),
            Email: $('#Email').val(),
            Mobile: $('#Mobile').val(),
            Wesite: $('#Website').val(),
            Activities: $('#Activities').val(),
            CommunityProfile: $('#CommunityProfile').val()
        };

    $.ajax({
        url: "../ProCommunityHouses/Update",
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
            url: "../ProCommunityHouses/Delete/" + ID,
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

    $('#PCHId').val(""),
    $('#VarPCHId').val(""),
    $('#InstitutionName').val(""),
    $('#Address').val(""),
    $('#Email').val(""),
    $('#Mobile').val(""),
    $('#Website').val(""),
    $('#CommunityProfile').val(""),
    $('#Activities').val("")
    

    $('#btnUpdate').hide();
    $('#btnAdd').show();

    $('#PCHId').css('border-color', 'lightgrey');
    $('#VarPCHId').css('border-color', 'lightgrey');
    $('#InstitutionName').css('border-color', 'lightgrey');
    $('#Address').css('border-color', 'lightgrey');
    $('#Email').css('border-color', 'lightgrey');
    $('#Mobile').css('border-color', 'lightgrey');
    $('#CommunityProfile').css('border-color', 'lightgrey');
    $('#Website').css('border-color', 'lightgrey');
    $('#Activities').css('border-color', 'lightgrey');
    
}

//Valdidation using jquery 
function validate() {
    var isValid = true;
    
    if ($('#VarPCHId').val().trim() == "") {
        $('#VarPCHId').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#VarPCHId').css('border-color', 'lightgrey');
    }
    if ($('#InstitutionName').val().trim() == "") {
        $('#InstitutionName').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#InstitutionName').css('border-color', 'lightgrey');
    }
    
    if ($('#Address').val().trim() == "") {
        $('#Address').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#Address').css('border-color', 'lightgrey');
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
    
    if ($('#Website').val().trim() == "") {
        $('#Website').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#Website').css('border-color', 'lightgrey');
    }
    if ($('#Activities').val().trim() == "") {
        $('#Activities').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#Activities').css('border-color', 'lightgrey');
    }
    

    return isValid;
}