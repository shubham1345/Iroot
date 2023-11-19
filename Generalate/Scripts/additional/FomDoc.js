//Load Data in Table when documents is ready 
$(document).ready(function () {
    loadData();
    loadDataListItems();

    $('#printbtn').click(function () {
        window.open('../FomDoc/FomDoc1Report');
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
                tr.append("<td hidden='hidden'>" + json[i].FormationDocId + "</td>");
                //tr.append('<td><a href=ViewProfile/' + json[i].FormationDocId + '>' + json[i].FormationDocId + '</a></td>');
                tr.append("<td>" + json[i].DoccumentName + "</td>");
                tr.append("<td>" + json[i].Title + "</td>");
                tr.append("<td>" + json[i].Date + "</td>");
                tr.append("<td> <a href=/Images/FomDoc/" + json[i].File + " download>Download</a></td>");
                tr.append("<td> <a href=/Images/FomDoc/" + json[i].File + " view>View</a></td>");
                
                
                
                tr.append('<td><a href="#" onclick="return getbyID(' + json[i].FormationDocId + ')">Edit</a> | <a href="#" onclick="Delele(' + json[i].FormationDocId + ')">Delete</a></td>')
                $('table').append(tr);

            }
            $('FomDocInfo').DataTable();
        });
}

function loadDataListItems() {
    $.ajax({
        url: "../CommonDataListItems/GetDatalistItemsByModuleName/?DlistName=Formation",
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
    //var res = validate();
    //if (res == false) {
    //    return false;
    //}

    var datenow = new Date();

    var general =
        {
            FormationDocId: $('#FormationDocId').val(),
            // DoccumentName: $('#DoccumentName').val(),
            // DoccumentName: $("#tbl_FomDoc option:selected").text(),
            DoccumentName: $('#DoccumentName').val(),
            Title: $('#Title').val(),
            Date: $('#Date').val(),
            File: $('#File').val()
        };
    
    $.ajax({
        url: "../FomDoc/Add",
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
        url: "../FomDoc/GetById/" + GId1,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            
            $('#FormationDocId').val(result.FormationDocId);
            // $('#tbl_FomDoc option:selected').val(result.FormationDocId)
            $('#DoccumentName').val(result.DoccumentName);
            $('#Title').val(result.Title);
            $('#Date').val(result.Date);
            $('#File').val(result.File);

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
    
    //var res = validate();
    //if (res == false) {
    //    return false;
    //}

    var datenow = new Date();

    var empObj =
        {
            FormationDocId: $('#FormationDocId').val(),
            //  DoccumentName: $('#DoccumentName').val(),
            // FormationDocId: $("#tbl_FomDoc option:selected").text(),
            DoccumentName: $('#DoccumentName').val(),
            Title: $('#Title').val(),
            Date: $('#Date').val(),
            File: $('#File').val(),
        };

    $.ajax({
        url: "../FomDoc/Update",
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
            url: "../FomDoc/Delete/" + ID,
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

//File Upload here
$("#FileUpload").change(function () {

    var memid = $("#MemberID").val();
    var data = new FormData();
    var files = $("#FileUpload").get(0).files;
    if (files.length > 0) {
        data.append("MyImages", files[0]);
        data.append("Memid", memid);
    }
    
    $.ajax({
        url: "/FomDoc/UploadFile",
        type: "POST",
        processData: false,
        contentType: false,
        data: data,
        success: function (response) {
            //code after success
            $("#File").val(response);
            alert("File Save Successfully");
        },
        error: function (er) {
            alert(er);
        }

    });
});
function ViewPDF(Id) {
    $.ajax({
        url: "../FomDoc/ViewPDF/" + Id,
        type: "GET",
        dataType: 'html',
        success: function (result) {

            $('#pimageviewer').html(result);
        }
    });
}

//Function for clearing the textboxes 
function clearTextBox() {

    $('#FormationDocId').val("");
    $('#DoccumentName').val("");
    $('#Title').val("");
    $('#Date').val("");
    $('#File').val("");

    $('#btnUpdate').hide();
    $('#btnAdd').show();

    $('#FormationDocId').css('border-color', 'lightgrey');
    $('#DoccumentName').css('border-color', 'lightgrey');
    $('#Title').css('border-color', 'lightgrey');
    $('#Date').css('border-color', 'lightgrey');
    $('#File').css('border-color', 'lightgrey');
}

//Valdidation using jquery 
function validate() {
    var isValid = true;
    if ($('#FormationDocId').val().trim() == "") {
        $('#FormationDocId').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#FormationDocId').css('border-color', 'lightgrey');
    }
    if ($('#DoccumentName').val().trim() == "") {
        $('#DoccumentName').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#DoccumentName').css('border-color', 'lightgrey');
    }
    if ($('#Title').val().trim() == "") {
        $('#Title').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#Title').css('border-color', 'lightgrey');
    }
    if ($('#Date').val().trim() == "") {
        $('#Date').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#Date').css('border-color', 'lightgrey');
    }
    if ($('#File').val().trim() == "") {
        $('#File').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#File').css('border-color', 'lightgrey');
    }
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
