$(document).ready(function () {
    GetAllMember();
});

function GetAllMember() {
  //debugger;
    $.ajax({
        url: "/Member/GetAllMember",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response1) {
            if (response1.length > 0) {
                var allDate1 = [];
                var omObj1 = {};
                $('#Name').html('').select2({ data: [{ id: '', text: '' }] });
                allDate1.push({ id: '0', text: '-- Select Name --' });
                for (var i = 0; i < response1.length; i++) {
                    allDate1.push({ id: response1[i].Name, text: response1[i].Name });
                }
                $("#Name").html('').select2({
                    data: allDate1
                });
            }
        },
        error: function (er) {
            
        }
    });
}

//function loadData() {
//    var tb = document.getElementById('EmpInfo');
//    while (tb.rows.length > 1) {
//        tb.deleteRow(1);
//    }
//    $.getJSON("GetAll",
//        function (json) {
//            var tr;
//            for (var i = 0; i < json.length; i++) {
//                tr = $('<tr />');
//                tr.append("<td hidden='hidden'>" + json[i].PassedId + "</td>");
//                tr.append("<td style='display: none'>" + json[i].MemberID + "</td>");
//                tr.append("<td>" + json[i].SirName + "</td>");
//                tr.append('<td><a href=ViewProfile/' + json[i].PassedId + '>' + json[i].Name + '</a></td>');
//                tr.append("<td>" + json[i].LastCommunity + "</td>");
//                tr.append("<td>" + json[i].Cause + "</td>");
//                tr.append("<td>" + json[i].Date + "</td>");
//                tr.append("<td>" + json[i].Time + "</td>");
//                tr.append("<td>" + json[i].InstitutionPlace + "</td>");
//                tr.append("<td> <a href=/Images/PassedImages/" + json[i].obituary + " view>View</a></td>");
//                tr.append('<td><a href="#" onclick="return getbyID(' + json[i].PassedId + ')">Edit</a> | <a href="#" onclick="Delele(' + json[i].PassedId + ')">Delete</a></td>')
//                $('table').append(tr);
//            }
//            $('#EmpInfo').DataTable();
//        });
//}

//function DisplayWill(FilePath) {
    
//    $("#Willdialouge").empty();
//    $("#Willdialouge").html('<iframe src=http://localhost:8089/Documents/' + FilePath + ' style="width: 900px; height: 900px;"></iframe>');
//    $("#Willdialouge").dialog({
//        autoOpen: true,
//        modal: true,
//        height: 800,
//        width: 700,
//    });
//}

//function DisplayObituary(FileNo) {
//    $("#obituarydialouge").empty();
//    $("#obituarydialouge").html('<iframe src=http://localhost:8089/Documents/' + FileNo + ' style="width: 900px; height: 900px;"></iframe>');
//    $("#obituarydialouge").dialog({
//        autoOpen: true,
//        modal: true,
//        height: 800,
//        width: 700,
//    });
//}

//function loadDataListItems() {
//    $.ajax({
//        url: "../CommonDataListItems/GetDatalistItemsByModuleName/?DlistName=General",
//        type: "GET",
//        contentType: "application/json;charset=utf-8",
//        dataType: "json",
//        success: function (result) {
//            $("#generalst").empty();
//            for (var i = 0; i < result.length; i++) {
//                $("#generalst").append("<option value='" + result[i].DataListItemName + "'></option>");
//            }
//        },
//        error: function (errormessage) {
//            alert(errormessage.responseText);
//        }
//    });
//}

//Add Data Function 
//function Add() {
//    var res = validate();
//    if (res == false) {
//        return false;
//    }
//    var datenow = new Date();
//    var general =
//        {
//            PassedId: $('#PassedId').val(),
//            Name: $('#Name').val(),
//            MemberID: $('#MemberID').val(),
//            ProvinceName: $('#ProvinceName').val(),
//            SirName: $("#SirName option:selected").text(),
//            LastCommunity: $('#LastCommunity').val(),
//            Cause: $('#Cause').val(),
//            Date: $('#Date').val(),
//            Time: $('#Time').val(),
//            InstitutionPlace: $('#InstitutionPlace').val(),
//            LastNatureRites: $('#LastNatureRites').val(),
//            LastPlaceRites: $('#LastPlaceRites').val(),
//            ville: $('#ville').val(),
//            obituary: $('#obituary').val()
//        };

//    $.ajax({
//        url: "../Passed/Add",
//        data: JSON.stringify(general),
//        type: "POST",
//        contentType: "application/json;charset=utf-8",
//        dataType: "json",
//        success: function (result) {
//            loadData();
//            clearTextBox();
//            $('#myModal').modal('hide');
//        },
//        error: function (errormessage) {
//            alert(errormessage.responseText);
//        }
//    });
//}


//function Update() {
//    var res = validate();
//    if (res == false) {
//        return false;
//    }

//    var datenow = new Date();
//    var empObj =
//        {
//            PassedId: $('#PassedId').val(),
//            Name: $('#Name').val(),
//            SirName: $('#SirName').val(),
//            MemberID: $("#MemberID option:selected").text(),
//            LastCommunity: $('#LastCommunity').val(),
//            Cause: $('#Cause').val(),
//            Date: $('#Date').val(),
//            Time: $('#Time').val(),
//            InstitutionPlace: $('#InstitutionPlace').val(),
//            LastNatureRites: $('#LastNatureRites').val(),
//            LastPlaceRites: $('#LastPlaceRites').val(),
//            ville: $('#ville').val(),
//            obituary: $('#obituary').val()
//        };

//    $.ajax({
//        url: "../Member/Update",
//        data: JSON.stringify(empObj),
//        type: "POST",
//        contentType: "application/json;charset=utf-8",
//        dataType: "json",
//        success: function (result) {
//            loadData();
//            $('#myModal').modal('hide');
//        },
//        error: function (errormessage) {
//            alert(errormessage.responseText);
//        }
//    });
//}



//Function for clearing the textboxes 
function clearTextBox() {

    $('#PassedId').val("");
    $('#Name').val("");
    $('#MemberID').val("");
    $('#LastCommunity').val("");
    $('#Cause').val("");
    $('#Date').val("");
    $('#Time').val("");
    $('#InstitutionPlace').val("");
    $('#LastNatureRites').val("");
    $('#LastPlaceRites').val("");
    $('#ville').val("");
    $('#obituary').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#PassedId').css('border-color', 'lightgrey');
    $('#Name').css('border-color', 'lightgrey');
    $('#MemberID').css('border-color', 'lightgrey');
    $('#LastCommunity').css('border-color', 'lightgrey');
    $('#Cause').css('border-color', 'lightgrey');
    $('#Date').css('border-color', 'lightgrey');
    $('#Time').css('border-color', 'lightgrey');
    $('#InstitutionPlace').css('border-color', 'lightgrey');
    $('#LastNatureRites').css('border-color', 'lightgrey');
    $('#LastPlaceRites').css('border-color', 'lightgrey');
}

//Valdidation using jquery 
function validate() {
    var isValid = true;
    return isValid;
}
