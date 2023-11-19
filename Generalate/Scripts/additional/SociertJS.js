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

function GetCongById(id) {
    $.ajax({
        url: "/Home/GetCongInfoById?id=" + id,
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
$(document).on('click', '.DeleteCong', function () {
  //debugger;
    var id = $(this).attr("data-val");
    if (window.confirm('Do You want To Delete?')) {
        DeleteCongById(id);
    };

});
function DeleteCongById(id) {
    $.ajax({
        url: "/Home/DeleteCongDataById?id=" + id,
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

$(".EditCongre").on('click', function () {
  //debugger;
    $('#CongreForm').attr('action', '/Home/UpdateCongre');
    var id = $(this).attr("data-val");

    $("#AddCongreData").text("Update");

    GetCongreById(id);
});

function GetCongreById(id) {
    $.ajax({
        url: "/Home/GetCongreInfoById?id=" + id,
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
$(document).on('click', '.DeleteCongre', function () {
  //debugger;
    var id = $(this).attr("data-val");
    if (window.confirm('Do You want To Delete?')) {
        DeleteCongreById(id);
    };

});
function DeleteCongreById(id) {
    $.ajax({
        url: "/Home/DeleteCongreById?id=" + id,
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
$('#btnClear1').on('click', function () {
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
function GetCongById(id) {
    $.ajax({
        url: "/Home/GetCongInfoById?id=" + id,
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
$(document).on('click', '.DeleteCong', function () {
  //debugger;
    var id = $(this).attr("data-val");
    if (window.confirm('Do You want To Delete?')) {
        DeleteCongById(id);
    };

});
function DeleteCongById(id) {
    $.ajax({
        url: "/Home/DeleteCongDataById?id=" + id,
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