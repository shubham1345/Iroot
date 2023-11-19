
//Load Data in Table when documents is ready 
$(document).ready(function () {
    loadData();
    loadDataListItems();

    $('#printbtn').click(function () {
        window.open('../EntryLife/EntryLifeReport');
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
                tr.append("<td hidden='hidden'>" + json[i].EntryLifeId + "</td>");
                // tr.append('<td><a href=ViewProfile/' + json[i].EntryLifeId + '>' + json[i].MemberID + '</a></td>');
                tr.append('<td style=display:none;><a href="#"/' + json[i].EntryLifeId + '>' + json[i].MemberID + '</a></td>');
                tr.append("<td>" + json[i].SirName + "</td>");
                tr.append("<td>" + json[i].Name + "</td>");
                //TODO Rajesh
               
                tr.append("<td>" + json[i].ColName + "</td>");
                tr.append("<td>" + json[i].EntryDate + "</td>");
                tr.append("<td>" + json[i].Place + "</td>");
                tr.append("<td>" + json[i].Director + "</td>");
                tr.append("<td>" + json[i].Minister + "</td>");
                tr.append("<td>" + json[i].OngoingFormation + "</td>");
                tr.append('<td><a href="#" onclick="return getbyID(' + json[i].EntryLifeId + ')">Edit</a> | <a href="#" onclick="Delele(' + json[i].EntryLifeId + ')">Delete</a></td>')
                $('table').append(tr);

            }
            $('#EmpInfo').DataTable();
        });
}

function loadDataListItems() {
    $.ajax({
        url: "../CommonDataListItems/GetDatalistItemsByModuleName/?DlistName=Formation",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        //data : { "DlistColName"},
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
            EntryLifeId: $('#EntryLifeId').val(),
            ColName: $('#ColName').val(),
            // MemberID: $('#MemberID').val(),
             SirName: $("#SirName option:selected").text(),

            //  $("#SelectedCountryId option:selected").text()

             Name: $('#Name').val(),
            //TODO Rajesh
             MemberID: $('#MemberID').val(),

            Minister: $('#Minister').val(),
            EntryDate: $('#EntryDate').val(),
            Place: $('#Place').val(),
            Director: $('#Director').val(),
            OngoingFormation: $('#OngoingFormation').val()
        };

    $.ajax({
        url: "../EntryLife/Add",
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
        url: "../EntryLife/GetById/" + GId1,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            
            $('#EntryLifeId').val(result.EntryLifeId);
            $('#ColName').val(result.ColName);
            $("#MemberID").val(result.MemberID);
            //TODO Rajesh
            //$('#Name').val(result.Name);
            //TODO Rajesh
            $("#SirName").val(result.SirName);
            $("#SirName select").val(result.SirName);
            $("#Name").val(result.Name);
            $('#Minister').val(result.Minister);
            $('#EntryDate').val(result.EntryDate);
            $('#Place').val(result.Place);
            $('#Director').val(result.Director);
            $('#OngoingFormation').val(result.OngoingFormation);


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
            EntryLifeId: $('#EntryLifeId').val(),
            ColName: $('#ColName').val(),
            //MemberID: $('#MemberID').val(),
        SirName: $("#SirName option:selected").text(),

        Name: $('#Name').val(),
            //TODO Rajesh
        MemberID: $('#MemberID').val(),
            Minister: $('#Minister').val(),
            EntryDate: $('#EntryDate').val(),
            Place: $('#Place').val(),
            Director: $('#Director').val(),
            OngoingFormation: $('#OngoingFormation').val()

        };

    $.ajax({
        url: "../EntryLife/Update",
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
            url: "../EntryLife/Delete/" + ID,
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

    $('#EntryLifeId').val("");
    $('#ColName').val("");
    $('#MemberID').val("");
    $('#Minister').val("");
    $('#EntryDate').val("");
    $('#Place').val("");
    $('#Director').val("");
    $('#OngoingFormation').val("");
    $('#Name').val("");

    $('#btnUpdate').hide();
    $('#btnAdd').show();

    $('#EntryLifeId').css('border-color', 'lightgrey');
    $('#ColName').css('border-color', 'lightgrey');
    $('#MemberID').css('border-color', 'lightgrey');
    $('#Minister').css('border-color', 'lightgrey');
    $('#EntryDate').css('border-color', 'lightgrey');
    $('#Place').css('border-color', 'lightgrey');
    $('#Director').css('border-color', 'lightgrey');
    $('#OngoingFormation').css('border-color', 'lightgrey');
}

//Valdidation using jquery 
function validate() {
    var isValid = true;
    //if ($('#ColName').val().trim() == "") {
    //    $('#ColName').css('border-color', 'Red'); isValid = false;
    //}
    //else {
    //    $('#ColName').css('border-color', 'lightgrey');
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