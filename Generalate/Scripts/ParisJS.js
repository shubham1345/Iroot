//Add Data Function
//$("#btnUpdate").css("display", "none");
function Add() {
    //var res = validate();
    //if (res == false) {
    //    return false;
    //}
    var ParisData =
    {
        MyId: $('#MyID').val(),
        YearOfEstablacement: $('#YearOfEstablacement').val(),
        ParisName: $('#ParisName').val(),
        Place: $('#Place').val(),
        Address: $('#Address').val(),
        Tial: $("#Tial").val(),
        Date: $('#Date').val(),
        Description: $('#Description').val(),
        FileName: $('#FileName').val()
    }
    
    
    $.ajax({
        url: "/Institution/AddParis",
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        data: JSON.stringify(ParisData),
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
function GetParisById(id) {
    $.ajax({
        url: "/Paris/GetParisById?id=" + id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            clearall();

            if (result != null) {
                
                $("#YearOfEstablacement").val(result.YearOfEstablacement);
                $("#ParisName").val(result.ParisName);
                $("#Place").val(result.Place);
                $("#Address").val(result.Address);
                $("#Tial").val(result.Tial);
                $("#Date").val(result.Date);
                $("#Description").val(result.Description);
                $("#ID").val(result.Id);
                
                //$("#btnParisSave").css("display", "none");
                //$("#btnParisUpdate").css("display", "block");
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
        YearOfEstablacement: $('#YearOfEstablacement').val(),
        ParisName: $('#ParisName').val(),
        Place: $('#Place').val(),
        Address: $('#Address').val(),
        Tial: $('#Tial').val(),
        Date: $("#Date").val(),
        Description: $('#Description').val(),
        MyId: $('#MyID').val(),
        Id: $("#ID").val()
    };

    $.ajax({
        url: "/Paris/Update",
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        data: JSON.stringify(empObj),
        success: function (result) {
            
            //if (result == "Success") {
            //    window.location.reload();
            //}
            window.location.reload();
            //loadData();
            //clearTextBox();
            //$('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
            window.location.reload();
        }
    });
}
function DeleteParisById(id) {
    
    $.ajax({
        url: "/Paris/Delete?Id=" + id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result == "Success") {
                location.reload();
            }
        },
        error: function (errormessage) {
            location.reload();
        }
    });
}

function EditFormationById(id) {

}
function clearall() {
    $("#YearOfEstablacement").val("");
    $("#ParisName").val("");
    $("#Place").val("");
    $("#Address").val("");
    $("#Tial").val("");
    $("#Date").val("");
    $("#Description").val("");
}

//update records 
$(".Edit").on('click', function () {
    
    $('#FormParis').attr('action', '/Paris/Update');
    var parisID = $(this).attr("data-val")
    $("#btnFormationSave1").text("Update")  
    GetParisById(parisID);

});

$("#btnUpdate").on("click", function () {
     
    $("#btnUpdate").css("display", "block");
    var parisID = $(this).attr("data-val")
    Update(parisID);
})
$(".Delete").on('click', function () {
    
    if (confirm("Are you sure?")) {
        var parisID = $(this).attr("data-val")
        DeleteParisById(parisID);
    }
    return false;
});


///Paris Doc List
$(".EditParisDoc").on('click', function () {
    
    $('#ParisLand').attr('action', '/Paris/UpdateParisLand');
    var parisLandID = $(this).attr("data-val")
    //$("#btnFormationSave").css("display", "none");
    //$("#btnUpdate").css("display", "block");
    $("#BtnSaveParisLandDocuments").text("Update")

    GetParisLandDocById(parisLandID);
});
$(".DeleteParisDoc").on('click', function () {
    
    if (confirm("Are you sure?")) {
        var parisID = $(this).attr("data-val")
        DeleteParisLandDocById(parisID);
    }
    return false;
});
function GetParisLandDocById(id) {
    $.ajax({
        url: "/Paris/GetParisLandDocById?id=" + id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            clearall();

            if (result != null) {
                
                $("#LandYear").val(result.Year);
                $("#LandParisInstitutionName").val(result.ParisInstitutionName);
                $("#LandDocumentCategory").val(result.DocumentCategory);
                $("#LandSubCategory").val(result.SubCategory);
                $("#LandKhasara").val(result.Khasara);
                $("#LandSurveyNo").val(result.SurveyNo);
                $("#LandDate").val(result.Date);
                $("#LandID").val(result.Id);
                $("#LandPlace").val(result.Place);
                $("#LandDescription").val(result.Description);
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);

        }
    });
}
function DeleteParisLandDocById(id) {
    
    $.ajax({
        url: "/Paris/DeleteParisLandDocById?Id=" + id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result == "Success") {
                location.reload();
            }
        },
        error: function (errormessage) {
            location.reload();
        }
    });
}
