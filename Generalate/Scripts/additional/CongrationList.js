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
                debugger;
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

$(".EditCong").on('click', function () {
    //debugger;
    $('#CongForm').attr('action', '/Home/UpdateCong');
    var id = $(this).attr("data-val");

    $("#btnAddCong").text("Update");

    GetCongById(id);
});

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




//<span class="MandatoryStar"> *</span>
function SaveOfficalMeeting() {
    if ($('#Date').val() == "") {
        alert("Please select the date");
        return false;
    }
    return true;
}

function SaveAddCommunity() {
    //if ($('#ActiveCheck7').is(":checked") == false && $('#ActiveCheck8').is(":checked") == false) {
    //    alert("Check Active or Inactive !");
    //    return false;
    //}
    return true;
}
function SavebtnAddInstitution() {
    if ($('#ActiveCheck3').is(":checked") == false && $('#ActiveCheck4').is(":checked") == false) {
        alert("Check Active or Inactive !");
        return false;
    }
    return true;
}
function SavebtnAddInstitution1() {
    if ($('#ActiveCheck5').is(":checked") == false && $('#ActiveCheck6').is(":checked") == false) {
        alert("Check Active or Inactive !");
        return false;
    }
    return true;
}
function DistrictValidation() {
    $('#ActiveInactiveDisErrorMessage').text("");
    var act1 = $('#ActiveDisSec1').is(":checked");
    var act2 = $('#ActiveDisSec2').is(":checked");
    // alert($('#DisSecRegProvinceName').val() + "" + $('#ActivitiesDisSec1').val());
    if (act1 == false && act2 == false) {
        $('#ActiveInactiveDisErrorMessage').text("please select any one Active or InActive");//.css("color",red);
        return false;
    }
    else if ($('#DisSecRegProvinceName').val() == 0) {
        alert("Please select the province name");
        return false;
    }
    else if ($('#ActivitiesDisSec1').val() == null || $('#ActivitiesDisSec1').val() == "") {
        alert("Please select the activities")
        return false;
    }
    else if ($('#DioceseNameDisSec').val() == null || $('#DioceseNameDisSec').val() == "") {
        alert("Please select the Diocese Name")
        return false;
    }

    else if ($('#Country').val() == null || $('#Country').val() == "") {
        alert("Please select the Country")
        return false;
    }



    return true;
}

function SaveActivitiesPopup() {
    if ($('#Name1').val() == "") {
        alert("Please enter the Name!");
        return false;
    }
    var name = $('#Name1').val();
    var option = '<option value="' + name + '">' + name + '</option>';
    $('#ActivitiesInst,#ActivitiesCom12').append(option);
    $('#ActivitiesInst').multipleSelect({
        width: 355,
        allSelectedText: 'All'
    })
    $('#ActivitiesCom12').multipleSelect({
        width: 355,
        allSelectedText: 'All'
    })

    $("#MyModalMaster").modal('hide');
    SaveDataList($('#DataListName1').val(), $('#Name1').val(), "", "Activities created successfully!");
    $('#Name1').val('');
}

function SaveInsPopup() {
    if ($('#InsName1').val() == "") {
        alert("Please enter the Name!");
        return false;
    }
    var name = $('#InsName1').val();
    var option = '<option value="' + name + '">' + name + '</option>';
    $('#InstitutionType').append(option);

    $("#MyModalMaster").modal('hide');
    SaveDataList($('#InsDataListName1').val(), $('#InsName1').val(), "", "Institution saved successfully");
    $('#Name1').val('');
}


function SaveDataList(DataListName, Name, Continent, msg) {

    $.ajax({
        url: "/Data/DataItemCountryDetailSave",
        type: "POST",
        data: { DataListName: DataListName, Name: Name, Continent: Continent },
        dataType: "json",
        success: function (result) {
            if (msg != undefined && msg != "")
                alert(msg);
            else
                alert(result);
        }
    });
}


