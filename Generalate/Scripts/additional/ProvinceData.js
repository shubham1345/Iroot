$(".EditSociert").on('click', function () {
  //debugger;
    $('#SociertForm').attr('action', '/Home/UpdateSociert');
    var id = $(this).attr("data-val");
    $("#btnAddSociert").text("Update");
    GetSociertById(id);
});

function GetSociertById(id) {
    $.ajax({
        url: "/Home/GetSocietyInfoById?id=" + id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result != null) {
              //debugger;
                $("#Tital").val(result.other1);
                $("#id").val(result.id);
                $("#Date").val(result.Date);
                $("#Description").val(result.Description);
                $("#file1").val(result.File1);
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
$(document).on('click', '.DeleteSociert', function () {
  //debugger;
    var id = $(this).attr("data-val");
    if (window.confirm('Do You want To Delete?')) {
        DeleteSociertById(id);
    };

});
function DeleteCongrationData(id) {
    $.ajax({
        url: "/Home/DeleteCongrationData?id=" + id,
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
$('#btnClear').on('click', function () {
    clearall();
});
function clearall() {
    $("#Description").val("");
    $("#Date").val("");
    $("#Title").val("");
    $("#file1").val("");
    $("#id").val("");


}
$(".EditCong").on('click', function () {
  //debugger;
    $('#CongForm').attr('action', '/Home/UpdateCong');
    var id = $(this).attr("data-val");
    $("#btnAddCong").text("Update");
    GetCongById(id);
});

$(".DeleteProvinceData").on('click', function () {
    var DataID = $(this).attr("data-val");
    if (confirm("Do you want to delete ?")) {
        window.location.href = "/Home/DeleteProvinceData?id=" + DataID;
    }
});

$(".EditProvinceData").on('click', function () {
  //debugger;
    var id = $(this).attr("data-val");
    $(".brd-panel").scrollTop(0);
    GetProvinceDataById(id);
});
function GetProvinceDataById(id) {
    $.ajax({
        url: "/Home/GetProvinceDataById?id=" + id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result != null) {
              //debugger;
                $('#ProvinceDataForm').attr('action', '/Home/UpdateProvinceData');
                $("#btnProvinceData").text("Update");

                $('#DioProvince1 option[value="' + result.ProvinceName + '"]').attr("selected", "selected");
                $("#Tital").val(result.Title);
                $("#id").val(result.id);
               
                $('#persionNames option[value="' + result.Member + '"]').attr("selected", "selected")
                $("#Date").val(result.Date);
                $("#Description").val(result.Description);
                $("#ProvinceId").val(result.ProvinceId);
                $("#file1").val(result.File);
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);

        }
    });
}


$(".EditCongre").on('click', function () {
  //debugger;
    $('#CongreForm').attr('action', '/Home/UpdateCongre');
    var id = $(this).attr("data-val");
    $("#AddCongreData").text("Update");
    GetCongreById(id);
});

function GetCongreById(id) {
    $.ajax({
        url: "/Home/GetProvinceDataById?id=" + id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result != null) {
              //debugger;
                $("#Tital").val(result.other1);
                $("#id").val(result.id);
                $("#Date").val(result.Date);
                $("#Description").val(result.Description);
                $("#file1").val(result.File1);
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}


