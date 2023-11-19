$(document).ready(function () {
    $("#btnFormationSave1").on("click", function () {
        Adds();
    });
    $("#btnFormationUpdate").css("display", "none");
});

$(document).on('click', '.Edit', function () {
    var formationId = $(this).attr("data-val");
    GetFormationById(formationId);
});

$(document).on('click', '.Delete', function () {
    var formationId = $(this).attr("data-val");
    if (window.confirm('Do You want To Delete?')) {
        DeleteFormationById(formationId);
    };

});
$(document).on('click', '#btnClear', function () {
    $("#btnFormationSave1").css("display", "block");
    clearall();

});
function Adds() {
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
        Course: $('#Course').text(),
        Title: $('#Title').val(),
        DegreeObtained: $('#DegreeObtained').val(),
        Univercity: $("#Univercity").val(),
        Fromdate: $('#Fromdate').val(),
        ToDate: $('#ToDate').val(),
        ClassObtained: $('#ClassObtained').val(),
        Medium: $('#Medium').val(),
        Address: $('#Address').val(),
        Remarks: $('#Remarks').val(),
        file1: $('#file1').val()
    }

    $.ajax({
        url: "/Secular/AddFormation",
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
        url: "/Secular/GetFormationById/" + id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            clearall();

            if (result != null) {
                $("#Course").val(result.Certificate);
                $("#Title").val(result.Spare1);
                $("#DegreeObtained").val(result.DegreeName);
                $("#Univercity").val(result.University);
                $("#Fromdate").val(result.FromDate);
                $("#ToDate").val(result.ToDate);
                $("#ClassObtained").val(result.ClassObtained);
                $("#Medium").val(result.Medium);
                $("#Address").val(result.Address);
                $("#Remarks").val(result.Remarks);
                $("#file1").val(result.Spare2);

                $("#btnFormationSave1").css("display", "none");
                $("#btnFormationUpdate").css("display", "block");
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}


function DeleteFormationById(id) {
    $.ajax({
        url: "/Secular/DeleteFormationById/" + id,
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
    $("#Course").val("");
    $("#Title").val("");
    $("#DegreeObtained").val("");
    $("#Univercity").val("");
    $("#Fromdate").val("");
    $("#ToDate").val("");
    $("#ClassObtained").val("");
    $("#Medium").val("");
    $("#Address").val("");
    $("#Remarks").val("");
    $("#file1 ").val("");
}
