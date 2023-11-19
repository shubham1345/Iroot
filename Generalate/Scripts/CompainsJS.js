
function Add() {
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
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
$(".DeleteComplain").on('click', function () {
    var id = $(this).attr("data-val");
    if (confirm("Do you want to delete ?")) {
        window.location.href = "/Complain/DeleteComplain?id=" + id;
    }
});

$(".EditComplain").on('click', function () {
  //debugger;
    $('#FormComplain').attr('action', '/EntryLife/ComplainUpdate');
    var id = $(this).attr("data-val");
    $('#btnCompainSave').text("Update");
    $(".panel-body").scrollTop(0);
    GetComplainById(id);
});
function GetComplainById(id) {
    $.ajax({
        url: "/Complain/GetCompainById?id=" + id ,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
          //debugger;
            if (result != null) {
                $("#DateComp").val(result.MyDate);
                $("#Id").val(result.Id);
                $("#Title1").val(result.Title);
                $("#Discription").val(result.Discription);
                $("#NatureofTheComplaint").val(result.NatureofTheComplaint);
                $("#ComplaintReceived").val(result.ComplaintReceived);
                $("#Decision").val(result.Decision);
                $("#InvolvedIn").val(result.InvolvedIn);
                $("#CompFils111").text(result.FileName);
                $("#MemberId").val(result.MemberId);
                $("#MemberName").val(result.MemberName);
                $("#ProvinceName").val(result.ProvinceName);

                var values4 = result.InvolvedIn;
                if (values4 != null || values4 != undefined) {
                    var values4data = result.InvolvedIn.split(",");
                    $('#select').multipleSelect('setSelects', values4data);
                }
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);

        }
    });
}

function Update() {
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
        window.location.reload();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
            window.location.reload();
        }
    });
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

$("#btnUpdate").on("click", function () {
    $("#btnUpdate").css("display", "block");
    var parisID = $(this).attr("data-val")
    Update(parisID);
})

///Paris Doc List
$(".EditParisDoc").on('click', function () {
    $('#ParisLand').attr('action', '/Paris/UpdateParisLand');
    var parisLandID = $(this).attr("data-val")
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
//Print 
function printdiv(printpage) {
    alert("sdf")
    var headstr = "<html><head><title></title></head><body>";
    var footstr = "</body>";
    var newstr = document.all.item(printpage).innerHTML;
    var oldstr = document.body.innerHTML;
    document.body.innerHTML = headstr + newstr + footstr;
    window.print();
    document.body.innerHTML = oldstr;
    return false;
}