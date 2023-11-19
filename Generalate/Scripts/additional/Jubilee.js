
//Load Data in Table when documents is ready 
$(document).ready(function () {
    loadData();
    //loadDataListItems();

    $('#printbtn').click(function () {
        window.open('../Jubilee/JubileeReport');
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
                tr.append("<td hidden='hidden'>" + json[i].JubileeID + "</td>");
                tr.append('<td><a href="ViewProfile"/' + json[i].JubileeID + '>' + json[i].Name + '</a></td>');
                tr.append("<td>" + json[i].MemberID + "</td>");
                //tr.append("<td>" + json[i].FirstProffession + "</td>");
                tr.append("<td>" + json[i].FirstProfession + "</td>");
                tr.append("<td>" + json[i].SilverJubilee + "</td>");
                tr.append("<td>" + json[i].GoldenJubilee + "</td>");
                tr.append("<td>" + json[i].PlatinumJubilee + "</td>");
                tr.append('<td><a href="#" onclick="return getbyID(' + json[i].JubileeID + ')">Edit</a> | <a href="#" onclick="Delele(' + json[i].JubileeID + ')">Delete</a></td>')
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
            JubileeID: $('#JubileeID').val(),
            // MemberID: $('#MemberID').val(),
            MemberID: $("#tbl_PersonalDetails option:selected").text(),
            Name: $('#Name').val(),
            Profession: $('#Profession').val(),
            SilverJubilee: $('#SilverJubilee').val(),
            GoldenJubilee: $('#GoldenJubilee').val(),
            PlatinumJubilee: $('#PlatinumJubilee').val(),
            DiamondJubilee: $('#DiamondJubilee').val(),
            FPPlace: $('#FPPlace').val(),
            SJPlace: $('#SJPlace').val(),
            GJPlace: $('#GJPlace').val(),
            PJPlace: $('#PJPlace').val(),
            FirstProfession: $('#FirstProfession').val(),
            DJPlace: $('#DJPlace').val()

        };

    $.ajax({
        url: "../Jubilee/Add",
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
        url: "../Jubilee/GetById/" + GId1,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            
            $('#JubileeID').val(result.JubileeID);
            $('#tbl_PersonalDetails option:selected').val(result.MemberID)
            $('#Profession').val(result.Profession);
            $('#SilverJubilee').val(result.SilverJubilee);
            $('#GoldenJubilee').val(result.GoldenJubilee);
            $('#Name').val(result.Name),
            $('#PlatinumJubilee').val(result.PlatinumJubilee);
            $('#DiamondJubilee').val(result.DiamondJubilee);
            $('#FPPlace').val(result.FPPlace);
            $('#SJPlace').val(result.SJPlace);
            $('#GJPlace').val(result.GJPlace);
            $('#PJPlace').val(result.PJPlace);
            $('#DJPlace').val(result.DJPlace);
            $('#FirstProfession').val(result.FirstProfession);

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
            JubileeID: $('#JubileeID').val(),
            // MemberID: $('#MemberID').val(),
            MemberID: $("#tbl_PersonalDetails option:selected").text(),
            Profession: $('#Profession').val(),
            SilverJubilee: $('#SilverJubilee').val(),
            Name: $('#Name').val(),
            GoldenJubilee: $('#GoldenJubilee').val(),
            PlatinumJubilee: $('#PlatinumJubilee').val(),
            DiamondJubilee: $('#DiamondJubilee').val(),
            FPPlace: $('#FPPlace').val(),
            SJPlace: $('#SJPlace').val(),
            GJPlace: $('#GJPlace').val(),
            PJPlace: $('#PJPlace').val(),
            FirstProfession: $('#FirstProfession').val(),
            DJPlace: $('#DJPlace').val()


        };

    $.ajax({
        url: "../Jubilee/Update",
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
            url: "../Jubilee/Delete/" + ID,
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

    $('#JubileeID').val("");
    $('#MemberID').val("");
    $('#Profession').val("");
    $('#GoldenJubilee').val("");
    $('#SilverJubilee').val("");
    $('#Name').val(""),
    $('#PlatinumJubilee').val("");
    $('#DiamondJubilee').val("");
    $('#FPPlace').val("");
    $('#SJPlace').val("");
    $('#GJPlace').val("");
    $('#PJPlace').val("");
    $('#DJPlace').val("");
    $('#FirstProfession').val("");

    $('#btnUpdate').hide();
    $('#btnAdd').show();

    $('#JubileeID').css('border-color', 'lightgrey');
    $('#MemberID').css('border-color', 'lightgrey');
    $('#Profession').css('border-color', 'lightgrey');
    $('#GoldenJubilee').css('border-color', 'lightgrey');
    $('#SilverJubilee').css('border-color', 'lightgrey');
    $('#Name').css('border-color', 'lightgrey');
    $('#PlatinumJubilee').css('border-color', 'lightgrey');
    $('#DiamondJubilee').css('border-color', 'lightgrey');
    $('#FPPlace').css('border-color', 'lightgrey');
    $('#SJPlace').css('border-color', 'lightgrey');
    $('#GJPlace').css('border-color', 'lightgrey');
    $('#PJPlace').css('border-color', 'lightgrey');
    $('#DJPlace').css('border-color', 'lightgrey');
    $('#FirstProfession').css('border-color', 'lightgrey');

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

function jubileeDateCalculation() {
    
    var firstprofessiondate = $('#FirstProfession').val();//document.getElementById("FirstProfession").va;
    var monthNdate = firstprofessiondate.split("/");
    var month = monthNdate[0];
    var day = monthNdate[1];

    monthNdate = monthNdate[0] + "/" + monthNdate[1];


    var year = firstprofessiondate.split("/");
    year = year[2];

    var c = new Date(firstprofessiondate);
    c = c.getFullYear();

    var d = (c + 25);
    var SilverJubilee = monthNdate + "/" + d;
    //document.getElementById("SilverJubilee").innerHTML = SilverJubilee.toString();
    $('#SilverJubilee').val(SilverJubilee);


    d = (c + 50);
    var GoldenJubilee = monthNdate + "/" + d;
    //document.getElementById("GoldenJubilee").innerHTML = GoldenJubilee.toString();
    $('#GoldenJubilee').val(GoldenJubilee);

    d = (c + 75);
    var PlatinumJubilee = monthNdate + "/" + d;
    //document.getElementById("PlatinumJubilee").innerHTML = PlatinumJubilee.toString();
    $('#PlatinumJubilee').val(PlatinumJubilee);

    d = (c + 100);
    var DiamondJubilee = monthNdate + "/" + d;
    $('#DiamondJubilee').val(DiamondJubilee);
    //document.getElementById("DiamondJubilee").innerHTML = DiamondJubilee.toString();
}