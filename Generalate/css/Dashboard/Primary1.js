$(document).ready(function () {
    $("#btnPrimarySave").on("click", function () {
        Add();
    });
    $("#btnPrimaryUpdate").css("display", "none");

});


$(document).on('click', '.Edit', function () {
    var formationId = $(this).attr("data-val");
    GetFormationById(formationId);
});

$(document).on('click', '.Delete', function () {
    var formationId = $(this).attr("data-val");
    if (window.confirm('Do You want To Delete?')) {
        PrimaryDelete(formationId);
    };

});
$(document).on('click', '#btnClear', function () {
    $("#btnFormationSave").css("display", "block");
    clearall();

});


//Add Data Function
function Add() {
    //var res = validate();
    //if (res == false) {
    //    return false;
    //}

    var datenow = new Date();
    var formationViewModel =
    {
        Name: $('#PName').text(),
        SirName: $('#PSirName').text(),
        MemberId: $('#PMemberId').text(),
        Knowname: $('#Description').val(),
        Baptismialname: $('#StageOfFormation').val(),
        DOB: $("#DateYear").val(),
        DOB1: $('#Place').val(),
        Feastday: $('#Superior').val(),
        Bloodgroup: $('#Formator').val(),
        emailid: $('#Minister').val(),
        mobilenumber: $('#File').val(),
        whatsappnumber: $('#File').val(),
        facebookid: $('#File').val(),
        twitterid: $('#File').val(),
        blog: $('#File').val(),
        house: $('#File').val(),
        city: $('#File').val(),
        district: $('#File').val(),
        state: $('#File').val(),
        pin: $('#File').val(),
        adhar: $('#File').val(),
        pan: $('#File').val(),
        nameonadhar: $('#File').val(),
        nameonpan: $('#File').val(),
        File1: $('#File').val(),
        File2: $('#File').val()
    }

    $.ajax({
        url: "/EntryLife/AddFormation",
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        data: JSON.stringify(formationViewModel),
        success: function (result) {
            if (result == "Success") {
                location.reload();
            }
            //loadData();
            //clearTextBox();
            //$('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
function GetFormationById(id) {
    $.ajax({
        url: "/EntryLife/GetFormationById/" + id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            clearall();

            if (result != null) {
                $("#Description").val(result.Spare3);
                $("#StageOfFormation").val(result.OngoingFormation);
                $("#DateYear").val(result.EntryDate);
                $("#Place").val(result.Place);
                $("#Superior").val(result.Director);
                $("#Formator").val(result.ColName);
                $("#Minister").val(result.Minister);

                $("#btnFormationSave").css("display", "none");
                $("#btnFormationUpdate").css("display", "block");
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
function Update() {
    //var res = validate();
    //if (res == false) {
    //    return false;
    //}

    var datenow = new Date();

    var empObj =
        {
            Name: $('#PName').text(),
            SirName: $('#PSirName').text(),
            MemberId: $('#PMemberId').text(),
            Description: $('#Description').val(),
            StageOfFormation: $('#StageOfFormation').val(),
            Date_Year: $("#DateYear").val(),
            Place: $('#Place').val(),
            Superior: $('#Superior').val(),
            Formator: $('#Formator').val(),
            Minister: $('#Minister').val(),
            File: $('#File').val()
        };

    $.ajax({
        url: "/EntryLife/UpdateFormation",
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        data: JSON.stringify(formationViewModel),
        success: function (result) {
            if (result == "Success") {
                location.reload();
            }
            //loadData();
            //clearTextBox();
            //$('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
function DeleteFormationById(id) {
    $.ajax({
        url: "/EntryLife/DeleteFormationById/" + id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

            if (result == "Success") {
                location.reload();
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function EditFormationById(id) {

}
function clearall() {
    $("#Description").val("");
    $("#StageOfFormation").val("");
    $("#DateYear").val("");
    $("#Place").val("");
    $("#Superior").val("");
    $("#Formator").val("");
    $("#Minister").val("");
}
