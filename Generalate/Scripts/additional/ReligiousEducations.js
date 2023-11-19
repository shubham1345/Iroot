
//Load Data in Table when documents is ready 
$(document).ready(function () {
    loadData();
    //loadDataListItems();

    $('#printbtn').click(function () {
        window.open('../ReligiousEducation/ReligiousReport');
    });
    $("#ImageReligiousCertificate").change(function () {
        
        var memid = $("#MemberID").val();
        if (memid == "") {
            alert("Please Select SirName");
            $("#ImageReligiousCertificate").val(null);
            return false;
        }

        var data = new FormData();
        var files = $("#ImageReligiousCertificate").get(0).files;
        if (files.length > 0) {
            data.append("MyImages", files[0]);
            data.append("Memid", memid);
            //data.append("FileName", "SecularCertificate");
        }

        $.ajax({
            url: "../ReligiousEducation/UploadFile",
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
                tr.append("<td hidden='hidden'>" + json[i].ReligiousId + "</td>");
                tr.append('<td style=display:none;><a href="ViewProfile"/' + json[i].ReligiousId + '>' + json[i].MemberID + '</a></td>');
                tr.append("<td>" + json[i].SirName + "</td>");

                tr.append("<td>" + json[i].Name + "</td>");
                //TODO Rajesh

                tr.append("<td>" + json[i].DegreeName + "</td>");
                tr.append("<td>" + json[i].FromDate + "</td>");
                tr.append("<td>" + json[i].ToDate + "</td>");
                tr.append("<td>" + json[i].University + "</td>");
                tr.append("<td hidden='hidden'>" + json[i].Address + "</td>");
                tr.append("<td>" + json[i].ClassObtained + "</td>");
                tr.append('<td><a href="#" onclick="return getbyID(' + json[i].ReligiousId + ')">Edit</a> | <a href="#" onclick="Delele(' + json[i].ReligiousId + ')">Delete</a></td>')
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
    var SirName = $("#SirName option:selected").text();
    if (SirName == "Select" || SirName == "" ) {
        alert("Please Select SirName");
        return false;
    }

    var res = validate();
    if (res == false) {
        return false;
    }

    var datenow = new Date();

    var general =
    {
        ReligiousId: $('#ReligiousId').val(),
        DegreeName: $('#DegreeName').val(),
        // MemberID: $('#MemberID').val(),
        SirName: $("#SirName option:selected").text(),

        //  $("#SelectedCountryId option:selected").text()

            Name: $('#Name').val(),
            MemberID: $("#MemberID").val(),
            Address: $('#Address').val(),
            FromDate: $('#FromDate').val(),
            ToDate: $('#ToDate').val(),
            University: $('#University').val(),
            ClassObtained: $('#ClassObtained').val(),
            Remarks: $('#Remarks').val(),
            Certificate: $("#Certificate").val()
        };

    $.ajax({
        url: "../ReligiousEducation/Add",
        data: JSON.stringify(general),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            clearTextBox();
            $("#ImageReligiousCertificate").val(null);
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
        url: "../ReligiousEducation/GetById/" + GId1,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            
            $('#ReligiousId').val(result.ReligiousId);
            $('#DegreeName').val(result.DegreeName);
            //TODO Rajesh
            $('#MemberID').val(result.MemberID);
            $('#Name').val(result.Name);
            //TODO Rajesh
            $('#SirName').val(result.SirName);
            $("#SirName select").val(result.SirName);
            $('#Address').val(result.Address);
            $('#FromDate').val(result.FromDate);
            $('#ToDate').val(result.ToDate);
            $('#University').val(result.University);
            $('#ClassObtained').val(result.ClassObtained);
            $('#Remarks').val(result.Remarks);
            $('#Certificate').val(result.Certificate);


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
            ReligiousId: $('#ReligiousId').val(),
            DegreeName: $('#DegreeName').val(),
            // MemberID: $('#MemberID').val(),
            //TODO Rajesh
        SirName: $("#SirName option:selected").text(),
            Name: $('#Name').val(),
            //TODO Rajesh
        MemberID: $('#MemberID').val(),

            Address: $('#Address').val(),
            FromDate: $('#FromDate').val(),
            ToDate: $('#ToDate').val(),
            University: $('#University').val(),
            ClassObtained: $('#ClassObtained').val(),
            Remarks: $('#Remarks').val(),
            Certificate: $('#Certificate').val()

        };

    $.ajax({
        url: "../ReligiousEducation/Update",
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
            url: "../ReligiousEducation/Delete/" + ID,
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

    $('#ReligiousId').val("");
    $('#DegreeName').val("");
    $('#MemberID').val("");
    $('#Address').val("");
    $('#FromDate').val("");
    $('#ToDate').val("");
    $('#University').val("");
    $('#ClassObtained').val("");
    $('#Remarks').val("");
    $('#Name').val("");
    $('#SirName').val("");

    $('#btnUpdate').hide();
    $('#btnAdd').show();

    $('#ReligiousId').css('border-color', 'lightgrey');
    $('#DegreeName').css('border-color', 'lightgrey');
    $('#MemberID').css('border-color', 'lightgrey');
    $('#Address').css('border-color', 'lightgrey');
    $('#FromDate').css('border-color', 'lightgrey');
    $('#ToDate').css('border-color', 'lightgrey');
    $('#University').css('border-color', 'lightgrey');
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