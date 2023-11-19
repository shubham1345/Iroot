//Load Data in Table when documents is ready 
$(document).ready(function () {
    loadData();
    loadDataListItems();

    $('#printbtn').click(function () {
        window.open('../PersonalDetails/PersonalDetailReport');
    });

    $('#addbtnclickevent').click(function () {
        AutoGeneratreMemberId();
    });

    $("#Image").change(function () {
        
        var memid = $("#MemberID").val();
        var data = new FormData();
        var files = $("#Image").get(0).files;
        if (files.length > 0) {
            data.append("MyImages", files[0]);
            data.append("Memid", memid);
            data.append("FolderName", "PertionalDetails");
        }

        $.ajax({
            url: "../PersonalDetails/UploadFile",
            type: "POST",
            processData: false,
            contentType: false,
            data: data,
            success: function (response) {
                alert("File Upload Successfully.");
                //code after success
                $("#Spare2").val(response);
            },
            error: function (er) {
                
                alert(er);
            }

        });
    });

    $("#Image1").change(function () {
        

        var memid = $("#MemberID").val();
        var data = new FormData();
        var files = $("#Image1").get(0).files;
        if (files.length > 0) {
            data.append("MyImages", files[0]);
            data.append("Memid", memid);
        }

        $.ajax({
            url: "../PersonalDetails/UploadFiles",
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

function DisplayWill(FilePath) {
    
    $("#Willdialouge").empty();
    $("#Willdialouge").html('<iframe src=http://localhost:8089/Documents/Will' + FilePath + ' style="width: 900px; height: 900px;"></iframe>');
    $("#Willdialouge").dialog({
        autoOpen: true,
        modal: true,
        height: 800,
        width: 700,
        title: "Document",

    });
}
function DisplayObituary(FileNo) {
    
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

$(this).change(function () {
       var memid = $("#MemberID").val();

   var data = new FormData();
    var files = $("#Image1").get(0).files;
    if (files.length > 0) {
      data.append("MyImages", files[0]);
       data.append("Memid", memid);
   }

    $.ajax({
      url: "../PersonalDetails/WillUploadFiles",
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
                tr.append("<td hidden='hidden'>" + json[i].PersonalDetailsId + "</td>");
                tr.append("<td>" + json[i].SirName + "</td>"); 
                tr.append('<td><a href=ViewProfile/' + json[i].PersonalDetailsId + '>' + json[i].Name + '</a></td>');
                tr.append("<td>" + json[i].NameBaptismial + "</td>");
                tr.append("<td>" + json[i].Spare1 + "</td>");
                             
                tr.append("<td>" + json[i].DOB + "</td>");
                tr.append("<td>" + json[i].FeastDays + "</td>");
                tr.append("<td>" + json[i].EmailID + "</td>");
                tr.append("<td>" + json[i].Mobile + "</td>");
                tr.append("<td>" + json[i].AadharNo + "</td>");               
               // tr.append("<td>" + json[i].AadharNo + "</td>");
               
               // var documentname = "";
               // if (json[i].Spare3 !== null && json[i].Spare3 !== undefined) {
                   // documentname = "Download";
                //}
             //   tr.append('<td><a href="#" onclick="DisplayWill(\'' + json[i].Spare3 + '\')"></a> | <a href="#" onclick="DisplayObituary(\'' + json[i].Spare3 + '\')">Will</a></td>')

            // tr.append('<td> <a href="#" onclick="DisplayWill(\'' + json[i].Spare3 + '\')">Will</a></td>')

               // tr.append('<td><a  href=../Images/Will/' + json[i].Spare3 + ' title=Will  download=Will' + json[i].spare3 + '>'+ '<img src=../Images/Will.png height=20px width=50px> </img>' + '</a></td>');

                tr.append('<td><a href="#" onclick="return getbyID(' + json[i].PersonalDetailsId + ')">Edit</a> | <a href="#" onclick="Delele(' + json[i].PersonalDetailsId + ')">Delete</a></td>')
                $('table').append(tr);

            }
            $('#EmpInfo').DataTable();
        });
}


//function loadDataListItems() {
//    $.ajax({
//        url: "../PersonalDetails/GetProvincial",
//        type: "GET",
//        contentType: "application/json;charset=utf-8",
//        //data : { "DlistName"},
//        dataType: "json",
//        success: function (result) {
//            $("#generalst").empty();
//            for (var i = 0; i < result.length; i++) {
//                $("#generalst").append("<option value='" + result[i].Name + "'></option>");
//            }

//        },

//        error: function (errormessage) {
//            alert(errormessage.responseText);
//        }

//    });

//}

function loadDataListItems() {
    $.ajax({
        url: "../CommonDataListItems/GetDatalistItemsByModuleName/?DlistName=Province",
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


function AutoGeneratreMemberId() {
    
    var membrid;
    $.ajax({
        url: "../PersonalDetails/GetAutoGeneratedMemberId",
        type: "POST",
        contentType: "application/json;charset=utf-8",
        //data : { "DlistName"},
        dataType: "json",
        success: function (result) {
            // result = "HSM" + result;
            result = "CPB" + result;

            $("#MemberID").val(result);
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
            PersonalDetailsId: $('#PersonalDetailsId').val(),
            MemberID: $('#MemberID').val(),
            Name: $('#Name').val(),
            NameBaptismial: $('#NameBaptismial').val(),
            EmailID: $('#EmailID').val(),
            SirName: $('#SirName').val(),
            //Image: $('#Image').val(),
            MotherTongue: $('#MotherTongue').val(),
            Mobile: $('#Mobile').val(),
            BloodGroup: $('#BloodGroup').val(),
            DOB: $('#DOB').val(),
            FeastDays: $('#FeastDays').val(),
            VillageTown: $('#VillageTown').val(),
            District: $('#District').val(),
            State: $('#State').val(),
            Country: $('#Country').val(),
            Pincode: $('#Pincode').val(),
            AadharNo: $('#AadharNo').val(),
            NameasinAadharCard: $('#NameasinAadharCard').val(),
            FatherName: $('#FatherName').val(),
            FBaptism:$('#FBaptism').val(),
            FMobile: $('#FMobile').val(),
            MotherName: $('#MotherName').val(),
            MBaptism: $('#MBaptism').val(),
            MMobile: $('#MMobile').val(),
            NoOfBrother: $('#NoOfBrother').val(),
            NoOfSister: $('#NoOfSister').val(),
            PlaceintheFamily: $('#PlaceintheFamily').val(),
            Spare1: $('#Spare1').val(),
            Spare2: $('#Spare2').val(),
            Will: $('#Will').val(),
            Parish1:$('#Parish').val(),
            //  MemberID: $("#tbl_PersonalDetails option:selected").text(),
            // Will: $("#Will option:selected").text(),
            // Will: $("#generalst option:selected").text(),
           // Will: $("#Will option:selected").text(),
            Spare3: $('#Spare3').val()

        };

    $.ajax({
        url: "../PersonalDetails/Add",
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
        url: "../PersonalDetails/GetById/" + GId1,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            
            $('#PersonalDetailsId').val(result.PersonalDetailsId);
            $('#MemberID').val(result.MemberID);
            $('#Name').val(result.Name);
            $('#NameBaptismial').val(result.NameBaptismial);
            $('#EmailID').val(result.EmailID);
            $('#SirName').val(result.SirName);
            //$('#Image').val(result.Image);
            $('#MotherTongue').val(result.MotherTongue);
            $('#Mobile').val(result.Mobile);
            $('#BloodGroup').val(result.BloodGroup);
            $('#DOB').val(result.DOB);
            $('#FeastDays').val(result.FeastDays);
            $('#VillageTown').val(result.VillageTown);
            $('#District').val(result.District);
            $('#State').val(result.State);
            $('#Country').val(result.Country);
            $('#Pincode').val(result.Pincode);
            $('#AadharNo').val(result.AadharNo);
            $('#NameasinAadharCard').val(result.NameasinAadharCard);
            $('#FatherName').val(result.FatherName);
            $('#FBaptism').val(result.FBaptism);
            $('#FMobile').val(result.FMobile);
            $('#MotherName').val(result.MotherName);
            $('#MBaptism').val(result.MBaptism);
            $('#MMobile').val(result.MMobile);
            $('#NoOfBrother').val(result.NoOfBrother);
            $('#NoOfSister').val(result.NoOfSister);
            $('#PlaceintheFamily').val(result.PlaceintheFamily);
            $('#Spare1').val(result.Spare1);
            $('#Spare2').val(result.Spare2);
            $('#Spare3').val(result.Spare3);
            $('#Will').val(result.Will);
            $('#Parish1').val(result.Parish1);
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
            PersonalDetailsId: $('#PersonalDetailsId').val(),
            MemberID: $('#MemberID').val(),
            Name: $('#Name').val(),
            NameBaptismial: $('#NameBaptismial').val(),
            EmailID: $('#EmailID').val(),
            SirName: $('#SirName').val(),
            //Image: $('#Image').val('null'),
            MotherTongue: $('#MotherTongue').val(),
            Mobile: $('#Mobile').val(),
            BloodGroup: $('#BloodGroup').val(),
            DOB: $('#DOB').val(),
            FeastDays: $('#FeastDays').val(),
            VillageTown: $('#VillageTown').val(),
            District: $('#District').val(),
            State: $('#State').val(),
            Country: $('#Country').val(),
            Pincode: $('#Pincode').val(),
            AadharNo: $('#AadharNo').val(),
            NameasinAadharCard: $('#NameasinAadharCard').val(),
            FatherName: $('#FatherName').val(),
            FBaptism:$('FBaptism').val(),
            FMobile: $('#FMobile').val(),
            MotherName: $('#MotherName').val(),
            MBaptism: $('#MBaptism').val(),
            MMobile: $('#MMobile').val(),
            NoOfBrother: $('#NoOfBrother').val(),
            NoOfSister: $('#NoOfSister').val(),
            PlaceintheFamily: $('#PlaceintheFamily').val(),
            Parish1: $('#Parish1').val(),
            Spare1: $('#Spare1').val(),
            Spare2: $('#Spare2').val(),
            Will: $('#Will').val(),
            Spare3: $('#Spare3').val(),
        };

    $.ajax({
        url: "../PersonalDetails/Update",
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
            url: "../PersonalDetails/Delete/" + ID,
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

    $('#PersonalDetailsId').val(""),
    $('#MemberID').val(""),
    $('#Name').val(""),
    $('#SirName').val(""),
    $('#NameBaptismial').val(""),
    $('#EmailID').val(""),    
    //$('#Image').val(""),
    $('#MotherTongue').val(""),
    $('#Mobile').val(""),
    $('#BloodGroup').val(""),
    $('#DOB').val(""),
    $('#FeastDays').val(""),
    $('#VillageTown').val(""),
    $('#District').val(""),
    $('#State').val(""),
    $('#Country').val(""),
    $('#Pincode').val(""),
    $('#AadharNo').val(""),
    $('#NameasinAadharCard').val(""),
    $('#FatherName').val(""),
    $('#FBaptism').val(),
    $('#FMobile').val(""),
    $('#MotherName').val(""),
    $('#MBaptism').val(""),
    $('#MMobile').val(""),
    $('#NoOfBrother').val(""),
    $('#NoOfSister').val(""),
    $('#PlaceintheFamily').val(""),
    $('#Parish1').val(""),
    $('#Spare1').val(""),
    $('#Spare2').val(""),
    $('#Will').val(),



    $('#btnUpdate').hide();
    $('#btnAdd').show();

    $('#PersonalDetailsId').css('border-color', 'lightgrey');
    $('#MemberID').css('border-color', 'lightgrey');
    $('#Name').css('border-color', 'lightgrey');
    $('#NameBaptismial').css('border-color', 'lightgrey');
    $('#EmailID').css('border-color', 'lightgrey');
    $('#SirName').css('border-color', 'lightgrey');
    //$('#Image').css('border-color', 'lightgrey');
    $('#MotherTongue').css('border-color', 'lightgrey');
    $('#Mobile').css('border-color', 'lightgrey');
    $('#BloodGroup').css('border-color', 'lightgrey');
    $('#DOB').css('border-color', 'lightgrey');
    $('#FeastDays').css('border-color', 'lightgrey');
    $('#VillageTown').css('border-color', 'lightgrey');
    $('#District').css('border-color', 'lightgrey');
    $('#State').css('border-color', 'lightgrey');
    $('#Country').css('border-color', 'lightgrey');
    $('#Pincode').css('border-color', 'lightgrey');
    $('#AadharNo').css('border-color', 'lightgrey');
    $('#NameasinAadharCard').css('border-color', 'lightgrey');
    $('#FatherName').css('border-color', 'lightgrey');
    $('#FBaptism').css('border-color', 'lightgrey');
    $('#FMobile').css('border-color', 'lightgrey');
    $('#MotherName').css('border-color', 'lightgrey');
    $('#MBaptism').css('border-color', 'lightgrey');
    $('#MMobile').css('border-color', 'lightgrey');
    $('#NoOfBrother').css('border-color', 'lightgrey');
    $('#NoOfSister').css('border-color', 'lightgrey');
    $('#PlaceintheFamily').css('border-color', 'lightgrey');
    $('#Parish1').css('border-color', 'lightgrey');
    $('#Spare1').css('border-color', 'lightgrey');
    $('#Spare2').css('border-color', 'lightgrey');
    $('#Will').css('border-color', 'lightgrey');
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

