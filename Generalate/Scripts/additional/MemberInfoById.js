//import { Certificate } from "crypto";

$(document).ready(function () {

    $("#AddDioCom").on('click', function () {
        //debugger;
        $("#MyModal").modal('show');
    });
    $("#AddDioSoc").on('click', function () {
        //debugger;
        $("#MyModal").modal('show');
    });    

    GetAllDisSec1();
});

function GetAllDisSec1() {

    $.ajax({
        url: "/IdGenerate/GetAllDisSec1",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response2) {
            if (response2.length > 0) {
                var allDate2 = [];
                var omObj2 = {};
                $('#InstDisSec123').html('').select2({ data: [{ id: '', text: '' }] });
                allDate2.push({ id: '0', text: '-- Select Items Name --' });
                for (var i = 0; i < response2.length; i++) {
                    allDate2.push({ id: response2[i].Id, text: response2[i].DistSecName });
                }
                $("#InstDisSec123").html('').select2({
                    data: allDate2
                });
            }
        },
        error: function (er) {
        }
    });
}

$(document).ready(function () {
    GetAllDioceseNameCong1();
});
function GetAllDioceseNameCong1() {
    $.ajax({
        url: "/IdGenerate/GetAllDioceseNameCong1",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response2) {
            if (response2.length > 0) {
                var allDate2 = [];
                var omObj2 = {};
                $('#DioceseNameInst').html('').select2({ data: [{ id: '', text: '' }] });
                allDate2.push({ id: '0', text: '-- Select Diosece Name --' });
                for (var i = 0; i < response2.length; i++) {
                    allDate2.push({ id: response2[i].Id, text: response2[i].DioceseName });
                }
                $("#DioceseNameInst").html('').select2({
                    data: allDate2
                });
            }
        },
        error: function (er) {
        }
    });
}

$(document).ready(function () {
    GetAllParish();
});
function GetAllParish() {
    $.ajax({
        url: "/IdGenerate/GetAllParish",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response2) {
            if (response2.length > 0) {
                var allDate2 = [];
                var omObj2 = {};
                $('#ParisId').html('').select2({ data: [{ id: '', text: '' }] });
                allDate2.push({ id: '0', text: '-- Select Items Name --' });
                for (var i = 0; i < response2.length; i++) {
                    allDate2.push({ id: response2[i].Id, text: response2[i].Name });
                }
                $("#ParisId").html('').select2({
                    data: allDate2
                });
            }
        },
        error: function (er) {
        }
    });
}

$(document).ready(function () {
    GetAllSociety();
});
function GetAllSociety() {
    $.ajax({
        url: "/IdGenerate/GetAllSociety",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response2) {
            if (response2.length > 0) {
                var allDate2 = [];
                var omObj2 = {};
                $('#SocietyId').html('').select2({ data: [{ id: '', text: '' }] });
                allDate2.push({ id: '0', text: '-- Select Items Name --' });
                for (var i = 0; i < response2.length; i++) {
                    allDate2.push({ id: response2[i].Id, text: response2[i].NameOfTheSocity });
                }
                $("#SocietyId").html('').select2({
                    data: allDate2
                });
            }
        },
        error: function (er) {
        }
    });
}


$(document).ready(function () {
    GetAllDisSec2();
});
function GetAllDisSec2() {
    $.ajax({
        url: "/IdGenerate/GetAllDisSec2",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response2) {
            if (response2.length > 0) {
                var allDate2 = [];
                var omObj2 = {};
                $('#DisSec123SocE').html('').select2({ data: [{ id: '', text: '' }] });
                allDate2.push({ id: '0', text: '-- Select Items Name --' });
                for (var i = 0; i < response2.length; i++) {
                    allDate2.push({ id: response2[i].Id, text: response2[i].DistSecName });
                }
                $("#DisSec123SocE").html('').select2({
                    data: allDate2
                });
            }
        },
        error: function (er) {
        }
    });
}


$(document).ready(function () {
    GetAllDioceseNameCong2();
});
function GetAllDioceseNameCong2() {
    $.ajax({

        url: "/IdGenerate/GetAllDioceseNameCong2",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response2) {
            if (response2.length > 0) {
                var allDate2 = [];
                var omObj2 = {};
                $('#DioceseNameSoc').html('').select2({ data: [{ id: '', text: '' }] });
                allDate2.push({ id: '0', text: '-- Select Diosece Name --' });
                for (var i = 0; i < response2.length; i++) {
                    allDate2.push({ id: response2[i].Id, text: response2[i].DioceseName });
                }
                $("#DioceseNameSoc").html('').select2({
                    data: allDate2
                });
            }
        },
        error: function (er) {
        }
    });
}


$(document).ready(function () {
    GetAllProvince();
});

function GetAllProvince() {    
    $.ajax({
        url: "/Home/GetAllProvince",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response2) {
            if (response2.length > 0) {
                var allDate2 = [];
                var omObj2 = {};
                $('#DioProvince1').html('').select2({ data: [{ id: '', text: '' }] });
                allDate2.push({ id: '0', text: '-- Select Province Name --' });
                for (var i = 0; i < response2.length; i++) {
                    allDate2.push({ id: response2[i].Id, text: response2[i].ProvinceName + " " + response2[i].Place });
                }
                $("#DioProvince1").html('').select2({
                    data: allDate2
                });
            }
        },
        error: function (er) {
        }
    });
}

$(document).ready(function () {
    GetAllStates();
});

function GetAllStates() {
    $.ajax({
        url: "/Home/GetAllStates",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response2) {
            if (response2.length > 0) {
                var allDate2 = [];
                var omObj2 = {};
                $('#DioState').html('').select2({ data: [{ id: '', text: '' }] });
                allDate2.push({ id: '0', text: '-- Select State Name --' });
                for (var i = 0; i < response2.length; i++) {
                    allDate2.push({ id: response2[i].Name, text: response2[i].Name });
                }
                $("#DioState").html('').select2({
                    data: allDate2
                });
            }
        },
        error: function (er) {
        }
    });
}

$("#btnAddingDiocese123").on("click", function () {
    //debugger;
    var data = {};

    data.ProvinceName = $("#DioProvince1 option:selected").text();
    data.State = $("#DioState option:selected").val();
    data.DioceseName = $("#DioceseName1").val();
    data.DioId = $("#DioId1").val();
    data.EmailId = $("#EmailIdDio1").val();
    data.Country = $("#CountryOfDiocese1").val();
    data.Address = $("#AddressDio1").val();
    data.ActiveCkeck = ("Active");

    if (data.ProvinceName == "0") {
        alert("Please Select Province Name ");
        return false;
    }
    if (data.State == "0") {
        alert("Please Select State Name ");
        return false;
    }
    $.ajax({
        url: "/IdGenerate/SaveDioceseData",
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (response2) {
            if (response2.length > 0) {
                var allDate2 = [];
                var omObj2 = {};
                $('#DioceseNameCom12').html('').select2({ data: [{ id: '', text: '' }] });
                $('#DioceseNameInst').html('').select2({ data: [{ id: '', text: '' }] });
                $('#DioceseNameSoc').html('').select2({ data: [{ id: '', text: '' }] });
                $('#DioceseNameTrust').html('').select2({ data: [{ id: '', text: '' }] });

                allDate2.push({ id: '0', text: '-- Select Diocese Name --' });
                for (var i = 0; i < response2.length; i++) {
                    allDate2.push({ id: response2[i].Id, text: response2[i].DioceseName });
                }
                $("#DioceseNameCom12").html('').select2({
                    data: allDate2
                });
                $("#DioceseNameInst").html('').select2({
                    data: allDate2
                });
                $("#DioceseNameSoc").html('').select2({
                    data: allDate2
                });
                $("#DioceseNameTrust").html('').select2({
                    data: allDate2
                });
            }
            // $("#MyDioceseForm").clearForm();
            $('#MyModal').modal('hide');
        },
        error: function (er) {
        }
    });
});



function SeperationAgeCaluculate() {
    //if ($('#DOB').val() == "") {
    //    alert("Please select the Primary - Date of Birth");
    //    return;
    //}
    var today = new Date($('#SeperationDate').val().split("/").reverse().join("-"));//new Date();
    var birthDate = new Date($('#DOB').val().split("/").reverse().join("-"));
    var age = today.getFullYear() - birthDate.getFullYear();
    $('#SeperationAge').val(age);
}
function AgeCalculate() {
    var today = new Date();
    //alert(today);
    var birthDate = new Date($('#SeperationDate').val().split("/").reverse().join("-"));
    //alert(birthDate);
    var age = today.getFullYear() - birthDate.getFullYear();
    var m = today.getMonth() - birthDate.getMonth();
    if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
        age--;
    }
    $('#SeperationAge').val(age);
}

function DorAgeCaluculate()
{
    debugger;
    if ($('#DOBInTheCertificate').val() == "") {
        //$('#Age').val("0");
        //alert("Please select the Primary - DOB in the Certificate after calculate age");
        return;
    }
    //  alert($('#DOBInTheCertificate').val());
    var today = new Date($('#DOR').val().split("/").reverse().join("-"));//new Date();
    var birthDate = new Date($('#DOBInTheCertificate').val().split("/").reverse().join("-"));

    var age = today.getFullYear() - birthDate.getFullYear();
    $('#Age').val(age);
}
function EtmlAgeCaluculate() {
    var dd = $('#DOB').val();
    //alert(dd);
    var today = new Date($('#Date').val().split("/").reverse().join("-"));//new Date();
    var currentTime = new Date();
    var year = currentTime.getFullYear();
    if (dd == undefined) {
        return false;
    }
    var birthDate = new Date($('#DOB').val().split("/").reverse().join("-"));
    //alert(birthDate);
    var age = today.getFullYear() - birthDate.getFullYear();
    $('#EAge').val(age);
}


$(function () {
    // $('.select2,.select2-container, .select2-container--default').css("width", "100%")
    $('.select2').css("width", "100%");

    // $(".select2").width(100).height(200);
});



function OpenDiosesNewPopUp(act) {
    if (act == 'appoDiocese') {
        $("#MyModal").modal('show');
    }
    else if (act == 'appoParish') {
        $("#MyModalDioParish").modal('show');

    }
    else if (act == 'InstitutionType2') {
        $("#MyModalDioInstution").modal('show');
    }
    else if (act == 'CommunityType22') {
        $("#MyModalDioCommunity").modal('show');
    }

}

function OpenOtherCongNewPopUp(act) {
    if (act == 'appoCongPro') {
        $("#MyModalDioOtherProvince").modal('show');
    }
    else if (act == 'InstitutionType3') {
        $("#MyModalDioOtherInstution").modal('show');
    }
    else if (act == 'CommunityType33') {
        $("#MyModalDioOtherCommunity").modal('show');
    }

}

function DioceseBasedLoadDD() {
  //  alert("");
    //debugger;
    $('#DioIdParish,#DioIdInst,#DioIdCom').val('');
    $('#DioNameParish,#DioNameInst,#DioNameCom').val('');

    if ($('#appoDiocese').val() != null && $('#appoDiocese').val() != "") {

        $('#DioIdParish,#DioIdInst,#DioIdCom').val($('#appoDiocese').val());
        $('#DioNameParish,#DioNameInst,#DioNameCom').val($('#appoDiocese option:selected').val());
        // alert($('#appoDiocese').val())
        for (var i = 1; i <= 3; i++) {
            $.ajax({
                url: "/Member/DioceseBasedLoadDD/",
                data: { id: $('#appoDiocese').val(), action: i },
                type: "Post",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (i == 1)
                        PopulateDropDown("appoParish", data);
                    else if (i == 3) {
                        PopulateMultiSelectDropDown("InstitutionType2", data);
                        $('#InstitutionType2').multipleSelect({
                            width: 600,
                            allSelectedText: 'All'
                        })
                    }
                    else if (i == 2) {
                        PopulateMultiSelectDropDown("CommunityType22", data);
                        $('#CommunityType22').multipleSelect({
                            width: 600,
                            allSelectedText: 'All'
                        })
                    }
                }
            });
        }
    }
    else {
        PopulateDropDown("appoParish", "");
        PopulateMultiSelectDropDown("InstitutionType2", "");
        PopulateMultiSelectDropDown("CommunityType22", "");
        $('#InstitutionType2').multipleSelect({
            width: 600,
            allSelectedText: 'All'
        })
        $('#CommunityType22').multipleSelect({
            width: 600,
            allSelectedText: 'All'
        })
    }
}

function ComOSInsProvinceBasedLoadDD() {   
    $('#ComOSInsProvinceName').val($('#ComOSProvId option:selected').text());
}
function PresentProvinceBasedPopup() {    
    $('#GenIdInst,#EnterbyGenInst,#GenIdCom,#EnterbyGenCom').val('');
    $('#ComOSProvId,#GenIdCom').val(presentProvinceName);
    $('#EnterbyGenInst,#EnterbyGenCom').val(presentProvinceName);

    //var province = $("#ProvinceDrop1 option:selected").val();
    //if (province != null && province != undefined) {
    //    ChangeProvinceDrop();
    //}
}

function OutSideProBasedLoadDD() {
    //debugger;
    $('#GenIdInst,#EnterbyGenInst,#GenIdCom,#EnterbyGenCom').val('');
    if ($('#appoOSPro').val() != null && $('#appoOSPro').val() != "") {
        $('#ComOSProvId,#GenIdCom').val($('#appoOSPro').val());
        $('#EnterbyGenInst,#EnterbyGenCom').val($('#appoOSPro option:selected').text());

        for (var i = 1; i <= 2; i++) {

            $.ajax({
                url: "/Member/OutSideProBasedLoadDD/",
                data: { id: $('#appoOSPro').val(), action: i },
                type: "Post",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (i == 1) {
                        PopulateMultiSelectDropDown("InstitutionType1", data);
                        $('#InstitutionType1').multipleSelect({
                            width: 600,
                            allSelectedText: 'All'
                        })
                    }
                    else if (i == 2) {
                        PopulateMultiSelectDropDown("CommunityType11", data);
                        $('#CommunityType11').multipleSelect({
                            width: 600,
                            allSelectedText: 'All'
                        })
                    }
                }
            });
        }
    }
    else {
        PopulateDropDown("appoCongPro", "");
        PopulateMultiSelectDropDown("InstitutionType1", "");
        PopulateMultiSelectDropDown("CommunityType11", "");
        $('#CommunityType11').multipleSelect({
            width: 600,
            allSelectedText: 'All'
        })
        $('#CommunityType33').multipleSelect({
            width: 600,
            allSelectedText: 'All'
        })
    }
}

function OutSideCongBasedLoadDD() {
    //debugger;
    $('#ComOSProvId,#ComOSProvName,#ComOSInsId,#ComOSInsName,#ComOSInsProvinceName,#CongOSComId,#CongOSComName').val('');
    if ($('#appoOSCong').val() != null && $('#appoOSCong').val() != "") {
        $('#ComOSProvId,#ComOSInsId,#CongOSComId').val($('#appoOSCong').val());
        $('#ComOSProvName,#ComOSInsName,#CongOSComName').val($('#appoOSCong option:selected').text());

        for (var i = 1; i <= 3; i++) {

            $.ajax({
                url: "/Member/OutSideCongBasedLoadDD/",
                data: { id: $('#appoOSCong').val(), action: i },
                type: "Post",
                dataType: "json",
                async: false,
                success: function (data) {
                    //  debugger;
                    if (i == 1)
                        PopulateDropDown("appoCongPro", data);
                    else if (i == 2) {
                        PopulateMultiSelectDropDown("InstitutionType3", data);
                        $('#InstitutionType3').multipleSelect({
                            width: 600,
                            allSelectedText: 'All'
                        })
                    }
                    else if (i == 3) {
                        PopulateMultiSelectDropDown("CommunityType33", data);
                        $('#CommunityType33').multipleSelect({
                            width: 600,
                            allSelectedText: 'All'
                        })
                    }
                }
            });
        }
    }
    else {
        PopulateDropDown("appoCongPro", "");
        PopulateMultiSelectDropDown("InstitutionType3", "");
        PopulateMultiSelectDropDown("CommunityType33", "");
        $('#InstitutionType3').multipleSelect({
            width: 600,
            allSelectedText: 'All'
        })
        $('#CommunityType33').multipleSelect({
            width: 600,
            allSelectedText: 'All'
        })
    }
}

function SGBasedLoadDD() {
    //debugger;
    $('#GenIdCom,#EnterbyGenCom,#GenIdInst,#EnterbyNameInst').val('');
    if ($('#SGGeneralate').val() != null && $('#SGGeneralate').val() != "") {
        $('#GenIdCom,#GenIdInst').val($('#SGGeneralate').val());
        $('#EnterbyGenCom,#EnterbyNameInst').val($('#SGGeneralate option:selected').text());
        for (var i = 1; i <= 2; i++) {

            $.ajax({
                url: "/Member/SGBasedLoadDD/",
                data: { id: $('#SGGeneralate').val(), action: i },
                type: "Post",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (i == 1) {
                        PopulateMultiSelectDropDown("InstitutionType4", data);
                        $('#InstitutionType4').multipleSelect({
                            width: 600,
                            allSelectedText: 'All'
                        })
                    }
                    else if (i == 2) {
                        PopulateMultiSelectDropDown("CommunityType44", data);
                        $('#CommunityType44').multipleSelect({
                            width: 600,
                            allSelectedText: 'All'
                        })
                    }
                }
            });
        }
    }
    else {
        PopulateMultiSelectDropDown("InstitutionType4", "");
        PopulateMultiSelectDropDown("CommunityType44", "");
        $('#InstitutionType4').multipleSelect({
            width: 600,
            allSelectedText: 'All'
        })
        $('#CommunityType44').multipleSelect({
            width: 600,
            allSelectedText: 'All'
        })
    }
}

function PopulateDropDown(id, data) {
    $('#' + id).empty();
    var option = '<option value="0"> -- Select --</option>';
    if (data != "") {
        for (var i = 0; i < data.length; i++) {
            option += '<option value=' + data[i].Text + '> ' + data[i].Text + '</option>';
        }
    }
    $('#' + id).append(option);
}
function PopulateMultiSelectDropDown(id, data) {
    $('#' + id).empty();
    var option = '';
    if (data != "") {
        for (var i = 0; i < data.length; i++) {
            option += '<option value=' + data[i].Text + '> ' + data[i].Text + '</option>';
        }
    }
    $('#' + id).append(option);
}