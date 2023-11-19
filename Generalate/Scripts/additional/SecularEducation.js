
//Load Data in Table when documents is ready 
$(document).ready(function () {
    loadData();
    //loadDataListItems();

    $('#printbtn').click(function () {
        window.open('../SecularEducation/SecularReport');

    });


    var memid = $("#MemberID").val();
    $("#ImageCertificate").change(function () {
        
        var data = new FormData();
        var files = $("#ImageCertificate").get(0).files;
        if (files.length > 0) {
            data.append("MyImages", files[0]);
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
                $("#Certificate").val(response);
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
                tr.append("<td hidden='hidden'>" + json[i].SecularId + "</td>");
                tr.append('<td><a href="ViewProfile"/' + json[i].SecularId + '>' + json[i].MemberID + '</a></td>');
                tr.append("<td>" + json[i].Name + "</td>");
                tr.append("<td>" + json[i].DegreeName + "</td>");
                tr.append("<td>" + json[i].FromDate + "</td>");
                tr.append("<td>" + json[i].ToDate + "</td>");
                tr.append("<td>" + json[i].University + "</td>");
                tr.append("<td hidden='hidden'>" + json[i].Address + "</td>");
                tr.append("<td>" + json[i].ClassObtained + "</td>");
                tr.append("<td>" + json[i].Medium + "</td>");
                tr.append('<td><a href="#" onclick="return getbyID(' + json[i].SecularId + ')">Edit</a> | <a href="#" onclick="Delele(' + json[i].SecularId + ')">Delete</a></td>')
                $('table').append(tr);

            }
            $('#EmpInfo').DataTable();
        });
}

function loadDataListItems() {
    $.ajax({
        url: "../CommonDataListItems/GetDatalistItemsByModuleDegreeName/?DlistName=General",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        //data : { "DlistDegreeName"},
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
        SecularId: $('#SecularId').val(),
        DegreeName: $('#DegreeName').val(),
        MemberID: $("#tbl_PersonalDetails option:selected").text(),

        //  $("#SelectedCountryId option:selected").text()

        Name: $('#Name').val(),
        Address: $('#Address').val(),
        FromDate: $('#FromDate').val(),
        ToDate: $('#ToDate').val(),
        University: $('#University').val(),
        Medium: $('#Medium').val(),
        ClassObtained: $('#ClassObtained').val(),
        Remarks: $('#Remarks').val(),
        Certificate: $('#Certificate').val()
        //obituary: $('#obituary').val()
    };

    $.ajax({
        url: "../SecularEducation/Add",
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
        url: "../SecularEducation/GetById/" + GId1,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            
            $('#SecularId').val(result.SecularId);
            $('#DegreeName').val(result.DegreeName);
            //$('#MemberID').val(result.MemberID);
            $('#tbl_PersonalDetails option:selected').val(result.MemberID);

            $('#Name').val(result.Name);
            $('#Address').val(result.Address);
            $('#FromDate').val(result.FromDate);
            $('#ToDate').val(result.ToDate);
            $('#University').val(result.University);
            $('#Medium').val(result.Medium);
            $('#ClassObtained').val(result.ClassObtained);
            $('#Remarks').val(result.Remarks)


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
        SecularId: $('#SecularId').val(),
        DegreeName: $('#DegreeName').val(),
        //  MemberID: $('#MemberID').val(),
        MemberID: $("#tbl_PersonalDetails option:selected").text(),
        Name: $('#Name').val(),
        Address: $('#Address').val(),
        FromDate: $('#FromDate').val(),
        ToDate: $('#ToDate').val(),
        University: $('#University').val(),
        Medium: $('#Medium').val(),
        ClassObtained: $('#ClassObtained').val(),
        Remarks: $('#Remarks').val()

    };

    $.ajax({
        url: "../SecularEducation/Update",
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
            url: "../SecularEducation/Delete/" + ID,
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

    $('#SecularId').val("");
    $('#DegreeName').val("");
    $('#MemberID').val("");
    $('#Address').val("");
    $('#FromDate').val("");
    $('#ToDate').val("");
    $('#University').val("");
    $('#Medium').val("");
    $('#ClassObtained').val("");
    $('#Remarks').val("");

    $('#btnUpdate').hide();
    $('#btnAdd').show();

    $('#SecularId').css('border-color', 'lightgrey');
    $('#DegreeName').css('border-color', 'lightgrey');
    $('#MemberID').css('border-color', 'lightgrey');
    $('#Address').css('border-color', 'lightgrey');
    $('#FromDate').css('border-color', 'lightgrey');
    $('#ToDate').css('border-color', 'lightgrey');
    $('#University').css('border-color', 'lightgrey');
    $('#Medium').css('border-color', 'lightgrey');
    $('#ClassObtained').css('border-color', 'lightgrey');
    $('#Remarks').css('border-color', 'lightgrey');
}

//Valdidation using jquery 
function validate() {
    var isValid = true;
    //if ($('#DegreeName').val().trim() == "") {
    //    $('#DegreeName').css('border-color', 'Red'); isValid = false;
    //}
    //else {
    //    $('#DegreeName').css('border-color', 'lightgrey');
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
    //if ($('#Medium').val().trim() == "") {
    //    $('#Medium').css('border-color', 'Red'); isValid = false;
    //}
    //else {
    //    $('#Medium').css('border-color', 'lightgrey');
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