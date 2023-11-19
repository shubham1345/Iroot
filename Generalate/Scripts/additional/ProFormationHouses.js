
//Load Data in Table when documents is ready 
$(document).ready(function () {
    loadData();
    loadDataListItems();
    getCommunityNames();
    getProvinceNames();

    $('#printbtn').click(function () {
        window.open('../ProFormationHouses/FormationReport');
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
                tr.append("<td hidden='hidden'>" + json[i].PFHId + "</td>");
                tr.append('<td><a href=ViewProfile/' + json[i].PFHId + '>' + json[i].InstitutionName + '</a></td>');
                tr.append("<td>" + json[i].CommunityName + "</td>");
                tr.append("<td>" + json[i].VarPFHId + "</td>");
                tr.append("<td>" + json[i].Address + "</td>");
                tr.append("<td>" + json[i].Email + "</td>");
                tr.append("<td>" + json[i].Mobile + "</td>");
                tr.append("<td>" + json[i].Website + "</td>");
                tr.append('<td><a href="#" onclick="return getbyID(' + json[i].PFHId + ')">Edit</a> | <a href="#" onclick="Delele(' + json[i].PFHId + ')">Delete</a></td>')
                $('table').append(tr);

            }
            $('#EmpInfo').DataTable();
        });
}

function loadDataListItems() {
    $.ajax({
        url: "../CommonDataListItems/GetDatalistItemsByModuleName/?DlistName=ProInstitution",
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
        //data : { "DlistName"},
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

//function getCommunityNames() {
//    $.ajax({
//        url: "../ProCommunityHouses/GetCommunityNames",
//        type: "GET",
//        contentType: "application/json;charset=utf-8",
//        //data : { "DlistName"},
//        dataType: "json",
//        success: function (result) {
//            $("#communitylist").empty();
//            for (var i = 0; i < result.length; i++) {
//                $("#communitylist").append("<option value='" + result[i].VarPCHId + "'></option>");
//            }

//        },

//        error: function (errormessage) {
//            alert(errormessage.responseText);
//        }

//    });

//}

function getCommunityNames() {
    $.ajax({
        url: "../CommonDataListItems/GetDatalistItemsByModuleName/?DlistName=ProCommunityHouses",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            $("#communitylist").empty();
            for (var i = 0; i < result.length; i++) {
                $("#communitylist").append("<option value='" + result[i].DataListItemName + "'></option>");
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
            PFHId: $('#PFHId').val(),
            VarPFHId: $('#VarPFHId').val(),
            InstitutionName: $('#InstitutionName').val(),
            Address: $('#Address').val(),
            Email: $('#Email').val(),
            Mobile: $('#Mobile').val(),
            Website: $('#Website').val(),
            CommunityName: $('#CommunityName').val(),

        };

    $.ajax({
        url: "../ProFormationHouses/Add",
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
        url: "../ProFormationHouses/GetById/" + GId1,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#PFHId').val(result.PFHId);
            $('#InstitutionName').val(result.InstitutionName);
            $('#CommunityName').val(result.CommunityName);
            $('#Website').val(result.Website);
            $('#Email').val(result.Email);
            $('#Mobile').val(result.Mobile);
            $('#VarPFHId').val(result.VarPFHId);
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
            PFHId: $('#PFHId').val(),
            VarPFHId: $('#VarPFHId').val(),
            InstitutionName: $('#InstitutionName').val(),
            CommunityName: $('#CommunityName').val(),
            Address: $('#Address').val(),
            Email: $('#Email').val(),
            Mobile: $('#Mobile').val(),
            Website: $('#Website').val()
        };

    $.ajax({
        url: "../ProFormationHouses/Update",
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
            url: "../ProFormationHouses/Delete/" + ID,
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

    $('#PFHId').val(""),
    $('#VarPFHId').val(""),
    $('#InstitutionName').val(""),
    $('#CommunityName').val(""),
    $('#Address').val(""),
    $('#Email').val(""),
    $('#Mobile').val(""),
    $('#Website').val("")

    $('#btnUpdate').hide();
    $('#btnAdd').show();

    $('#PFHId').css('border-color', 'lightgrey');
    $('#VarPFHId').css('border-color', 'lightgrey');
    $('#InstitutionName').css('border-color', 'lightgrey');
    $('#CommunityName').css('border-color', 'lightgrey');
    $('#Address').css('border-color', 'lightgrey');
    $('#Email').css('border-color', 'lightgrey');
    $('#Mobile').css('border-color', 'lightgrey');
    $('#Website').css('border-color', 'lightgrey');
}

//Valdidation using jquery 
function validate() {
    var isValid = true;
   
    if ($('#InstitutionName').val().trim() == "") {
        $('#InstitutionName').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#InstitutionName').css('border-color', 'lightgrey');
    }
    if ($('#CommunityName').val().trim() == "") {
        $('#CommunityName').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#CommunityName').css('border-color', 'lightgrey');
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

    return isValid;
}