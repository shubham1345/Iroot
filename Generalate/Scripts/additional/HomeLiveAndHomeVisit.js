
//Load Data in Table when documents is ready 
$(document).ready(function () {
    loadData();
    loadDataListItems();

    $('#printbtn').click(function () {
        window.open('../HomeLiveAndHomeVisit/HomeLiveReport');

    });
        $("#ImageObituary").change(function () {
            


            var data = new FormData();
            var files = $("#ImageObituary").get(0).files;
            if (files.length > 0) {
                data.append("Images", files[0]);
                data.append("Memid", memid);
            }

            $.ajax({
                url: "../Passed/UploadFile",
                type: "POST",
                processData: false,
                contentType: false,
                data: data,
                success: function (response) {
                    //code after success
                    $("#obituary").val(response);
                },
                error: function (er) {
                    alert(er);
                }

            });
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
                tr.append("<td hidden='hidden'>" + json[i].HomeliveId + "</td>");
                tr.append('<td><a href=ViewProfile/' + json[i].HomeliveId + '>' + json[i].Name + '</a></td>');
                tr.append("<td>" + json[i].MemberID + "</td>");
                tr.append("<td>" + json[i].DepartureDate + "</td>");
                tr.append("<td>" + json[i].ArrivalDate + "</td>");
                tr.append("<td>" + json[i].Spare3 + "</td>");
                tr.append("<td>" + json[i].ColName + "</td>");
                tr.append("<td>" + json[i].Purpose + "</td>");
                tr.append("<td>" + json[i].Place + "</td>");
                tr.append("<td> <a href=/Images/TransferLetter/" + json[i].File + " view>View</a></td>");
                tr.append('<td><a href="#" onclick="return getbyID(' + json[i].HomeliveId + ')">Edit</a> | <a href="#" onclick="Delele(' + json[i].HomeliveId + ')">Delete</a></td>')
                $('table').append(tr);

            }
            $('#EmpInfo').DataTable();
        });
}



function DisplayWill(FilePath) {
    
    $("#Willdialouge").empty();
    $("#Willdialouge").html('<iframe src=http://localhost:8089/Documents/' + FilePath + ' style="width: 900px; height: 900px;"></iframe>');
    $("#Willdialouge").dialog({
        autoOpen: true,
        modal: true,
        height: 800,
        width: 700,
        //title: "Document",

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
            HomeliveId: $('#HomeliveId').val(),
            //MemberID: $('#MemberID').val(),
            MemberID: $("#tbl_PersonalDetails option:selected").text(),
            Name: $('#Name').val(),
           
            DepartureDate: $('#DepartureDate').val(),
            ArrivalDate: $('#ArrivalDate').val(),
            Place: $('#Place').val(),
            Spare3: $('Spare3').val(),
            NoOfDays: $('#NoOfDays').val(),
            Purpose: $('#Purpose').val(),
            TransferLetter : $('#TransferLetter ').val()

        };

    $.ajax({
        url: "../HomeLiveAndHomeVisit/Add",
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
        url: "../HomeLiveAndHomeVisit/GetById/" + GId1,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            
            $('#HomeliveId').val(result.HomeliveId);
            $('#tbl_PersonalDetails option:selected').val(result.MemberID)
            $('#Name').val(result.Name);
            $('#DepartureDate').val(result.DepartureDate);
            $('#ArrivalDate').val(result.ArrivalDate);
            $('#Spare3').val(result.Spare3);
            $('#Place').val(result.Place);
            $('#Purpose').val(result.Purpose);
            $('#NoOfDays').val(result.NoOfDays);

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
            HomeliveId: $('#HomeliveId').val(),
            MemberID: $("#tbl_PersonalDetails option:selected").text(),
            Name: $('#Name').val(),
            DepartureDate: $('#DepartureDate').val(),
            ArrivalDate: $('#ArrivalDate').val(),
            Spare3: $('#Spare3').val(),
            Place: $('#Place').val(),
            Purpose: $('#Purpose').val(),
            NoOfDays: $('#NoOfDays').val(),
            TransferLetter : $('#TransferLetter ').val()


        };

    $.ajax({
        url: "../HomeLiveAndHomeVisit/Update",
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
            url: "../HomeLiveAndHomeVisit/Delete/" + ID,
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

    $('#HomeliveId').val("");
    $('#MemberID').val("");
    $('#Name').val("");
    $('#DepartureDate').val("");
    $('#Spare3').val("");
    $('#Purpose').val("");
    $('#ArrivalDate').val("");
    $('#Place').val("");
    $('#NoOfDays').val("");

    $('#btnUpdate').hide();
    $('#btnAdd').show();

    $('#HomeliveId').css('border-color', 'lightgrey');
    $('#MemberID').css('border-color', 'lightgrey');
    $('#Name').css('border-color', 'lightgrey');
    $('#DepartureDate').css('border-color', 'lightgrey');
    $('#Spare3').css('border-color', 'lightgrey');
    $('#Purpose').css('border-color', 'lightgrey');
    $('#ArrivalDate').css('border-color', 'lightgrey');
    $('#Place').css('border-color', 'lightgrey');
    $('#NoOfDays').css('border-color', 'lightgrey');
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