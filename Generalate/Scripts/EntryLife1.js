$(document).ready(function () {
    loadData();
    loadDataListItems();

    $('#printbtn').click(function () {
        window.open('../EntryLife/EntryLifeReport');
    });

});



function loadData() {
    var tb = document.getElementById('EmpInfo1');
    while (tb.rows.length > 1) {
        tb.deleteRow(1);
    }

    $.getJSON("GetAllEL",
        function (json) {
            var tr;

            //Append each row to html table
            for (var i = 0; i < json.length; i++) {
                tr = $('<tr />');
                tr.append("<td hidden='hidden'>" + json[i].EntryLifeId + "</td>");
                tr.append('<td><a href=ViewProfile/' + json[i].EntryLifeId + '>' + json[i].MemberID + '</a></td>');
                tr.append("<td>" + json[i].ColName + "</td>");
                tr.append("<td>" + json[i].EntryDate + "</td>");
                tr.append("<td>" + json[i].Place + "</td>");
                tr.append("<td>" + json[i].Director + "</td>");
                tr.append("<td>" + json[i].Minister + "</td>");
                tr.append("<td>" + json[i].OngoingFormation + "</td>");
             //   tr.append('<td><a href="#" onclick="return getbyID(' + json[i].EntryLifeId + ')">Edit</a> | <a href="#" onclick="Delele(' + json[i].EntryLifeId + ')">Delete</a></td>')
                tr.append('<td><a href="#" onclick="return getbyID(' + json[i].EntryLifeId + ')">Edit</a> | <a href="#" onclick="Delele(' + json[i].EntryLifeId + ')">Delete</a></td>')

                $('table').append(tr);

            }
            $('#EmpInfo').DataTable();
        });
}

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
            MemberID: $('#MemberID').val(),
            Minister: $('#Minister').val(),
            EntryDate: $('#EntryDate').val(),
            Place: $('#Place').val(),
            Director: $('#Director').val(),
            OngoingFormation: $('#OngoingFormation').val()
        };

    $.ajax({
        url: "../EntryLife/AddEL1",
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

function getbyID(GId2) {
    $.ajax({
        url: "../EntryLife/GetByIdEL/" + GId2,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            
            $('#EntryLifeId').val(result.EntryLifeId);
            $('#ColName').val(result.ColName);
            $('#MemberID').val(result.MemberID);
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
            MemberID: $('#MemberID').val(),
            Minister: $('#Minister').val(),
            EntryDate: $('#EntryDate').val(),
            Place: $('#Place').val(),
            Director: $('#Director').val(),
            OngoingFormation: $('#OngoingFormation').val()

        };

    $.ajax({
        url: "../EntryLife/UpdateEL1",
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


function Delele(ID1) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "../EntryLife/DeleteEL1/" + ID1,
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


function loadDataListItems() {
    $.ajax({
        url: "../CommonDataListItems/GetDatalistItemsByModuleName/?DlistName=Ongoing Formation Term",
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



function clearTextBox() {

    $('#EntryLifeId').val("");
    $('#ColName').val("");
    $('#MemberID').val("");
    $('#Minister').val("");
    $('#EntryDate').val("");
    $('#Place').val("");
    $('#Director').val("");
    $('#OngoingFormation').val("");

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
function validate() {
    var isValid = true;
    return isValid;
}

