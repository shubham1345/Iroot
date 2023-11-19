//Load Data in Table when documents is ready 
$(document).ready(function () {

    $("input").each(function () {
        $(this).val("");
    });

   // loadData();
    // loadDataListItems();

    $('#printbtn').click(function () {
        window.open('../Complaint/ComplaintsReport');
    });
    //$("#Document").change(function () {
    //    
    //    var memid = $("#MemberID").val();

    //    var data = new FormData();
    //    var files = $("#Image").get(0).files;
    //    if (files.length > 0) {
    //        data.append("MyImages", files[0]);
    //        data.append("Memid", memid);
    //    }

    //    $.ajax({
    //        url: "../Complaint/FileUpload",
    //        type: "POST",
    //        processData: false,
    //        contentType: false,
    //        data: data,
    //        success: function (response) {
    //            //code after success
    //            $("#Document").val(response);
    //        },
    //        error: function (er) {
    //            alert(er);
    //        }

    //    });
    //});

    $("#searchDocument").change(function () {
        

        var memid = $("#MemberID").val();
        var data = new FormData();
        var files = $("#searchDocument").get(0).files;
        if (files.length > 0) {
            data.append("MyImages", files[0]);
            data.append("Memid", memid);
        }

        $.ajax({
            url: "../Complaint/UploadFile",
            type: "POST",
            processData: false,
            contentType: false,
            data: data,
            success: function (response) {
                //code after success
                $("#Spare3").val(response);
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
                tr.append("<td hidden='hidden'>" + json[i].ComplaintID + "</td>");
                tr.append('<td><a href="#"/' + json[i].ComplaintID + '>' + json[i].Name + '</a></td>');
                tr.append("<td>" + json[i].MemberID + "</td>");
                tr.append("<td>" + json[i].ComplaintFrom + "</td>");
                tr.append("<td>" + json[i].ComplaintDATE + "</td>");
                tr.append("<td>" + json[i].ComplaintNATURE + "</td>");
                tr.append("<td>" + json[i].Decesion + "</td>");
                tr.append('<td><a href="#" onclick="DisplayDoc(\'' + json[i].Spare3+ '\')"></a> | <a href="#" onclick="DisplayDocument(\'' + json[i].Spare3 + '\')">Details</a></td>')

                //        tr.append('<td><a href="#" onclick="return getbyID(' + json[i].ComplaintID + ')">Edit</a> | <a href="#" onclick="DisplayDoc(\'' + json[i].Document + '\')">Details</a> | <a href="#" onclick="Delele(' + json[i].ComplaintID + ')">Delete</a></td>')
                tr.append('<td><a href="#" onclick="return getbyID(' + json[i].ComplaintID + ')">Edit</a> | <a href="#" onclick="Delele(' + json[i].ComplaintID + ')">Delete</a></td>')

                $('table').append(tr);

            }
            $('#EmpInfo').DataTable();
        });
}
function DisplayDoc(FilePath) {
    
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

function DisplayDocument(FileNo) {
    
    $("#obituarydialouge").empty();
    $("#obituarydialouge").html('<iframe src=http://localhost:8089/Documents/' + FileNo + ' style="width: 900px; height: 900px;"></iframe>');
    $("#obituarydialouge").dialog({
        autoOpen: true,
        modal: true,
        height: 800,
        width: 700,
        //title: "Document",

    });
}
//function DisplayDoc(FilePath) {
//    
//    //FilePath = "http://localhost/Generalate/Documents/sample_CMSF1.docx";
//    $("#Documentdialouge").empty();
//    //$("#Documentdialouge").html('<iframe src="@Url.Action("ShowDocument", "DocViewUpload", new { FilePath = "_FilePath" }) "'.replace("_FilePath", FilePath) + ' style="width: 98%; height: 98%" ></iframe>');
//    $("#Documentdialouge").html('<iframe src=http://localhost:8089/Documents/' + FilePath + ' style="width: 900px; height: 900px;"></iframe>');
//    $("#Documentdialouge").dialog({
//        autoOpen: true,
//        modal: true,
//        height: 800,
//        width: 700,
//        //title: "Document",

//    });
//}


//Add Data Function 
//function Add() {
//    var res = validate();
//    if (res == false) {
//        return false;
//    }
//    
//    var datenow = new Date();

//    var general =
//        {
//            ComplaintID: $('#ComplaintID').val(),
//            //  MemberID: $('#MemberID').val(),
//            MemberID: $("#tbl_PersonalDetails option:selected").text(),
//            Name: $('#Name').val(),
//            ComplaintFrom: $('#ComplaintFrom').val(),
//            ComplaintDATE: $('#ComplaintDATE').val(),
//            ComplaintNATURE: $('#ComplaintNATURE').val(),
//            Decesion: $('#Decesion').val()
//            //Document: $('#Document').val()
//        };

//    $.ajax({
//        url: "../Complaint/Add",
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
//            //alert(errormessage.responseText);
//        }
//    });
//}

//Function for getting the Data Based upon Employee ID 
function getbyID(GId1) {
    
    $.ajax({
        url: "../Complaint/GetById/" + GId1,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            
            $('#ComplaintID').val(result.ComplaintID);
            $('tbl_PersonalDetails option:selected').val(result.MemberID);
            $('#Name').val(result.Name);
            $('#ComplaintFrom').val(result.ComplaintFrom);
            $('#ComplaintDATE').val(result.ComplaintDATE);
            $('#ComplaintNATURE').val(result.ComplaintNATURE);
            $('#Decesion').val(result.Decesion);
            //$('#Document').val(result.Document);



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

    

    var empObj =
        {
            ComplaintID: $('#ComplaintID').val(),
            //  MemberID: $('#MemberID').val(),
            MemberID: $("#tbl_PersonalDetails option:selected").text(),
            Name: $('#Name').val(),
            ComplaintFrom: $('#ComplaintFrom').val(),
            ComplaintDATE: $('#ComplaintDATE').val(),
            ComplaintNATURE: $('#ComplaintNATURE').val(),
            Decesion: $('#Decesion').val()
            //Document: $('#Document').val()

        };

    $.ajax({
        url: "../Complaint/Update",
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
            url: "../Complaint/Delete/" + ID,
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

    $('#ComplaintID').val(""),
    $('#MemberID').val(""),
    $('#Name').val(""),
    $('#ComplaintFrom').val(""),
    $('#ComplaintDATE').val(""),
    $('#ComplaintNATURE').val(""),
    $('#Document').val("")




    $('#btnUpdate').hide();
    $('#btnAdd').show();

    $('#ComplaintID').css('border-color', 'lightgrey');
    $('#MemberID').css('border-color', 'lightgrey');
    $('#Name').css('border-color', 'lightgrey');
    $('#ComplaintFrom').css('border-color', 'lightgrey');
    $('#ComplaintDATE').css('border-color', 'lightgrey');
    $('#ComplaintNATURE').css('border-color', 'lightgrey');
    $('#Document').css('border-color', 'lightgrey');

}

//Valdidation using jquery 
function validate() {
    var isValid = true;
    
  //  isValid = document.getElementById("Document").required;


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