$(".EditCongre").on('click', function () {
    //debugger;
    $('#CongreForm').attr('action', '/IdGenerate/UpdateCongregation');
    var id = $(this).attr("data-val");
    $("#AddCongregations").text("Update");
    $(".panel-body").scrollTop(0);
    GetCongreById(id);
});
function GetCongreById(id) {
    $.ajax({
        url: "/IdGenerate/GetCongreById?id=" + id,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            //debugger;
            $("#CongId").val(result.Id);
            $("#CongreId").val(result.CongreId);
            $("#CongrigationName").val(result.CongregationName);
            $("#Establishment").val(result.Establishment);
            $("#Continent").val(result.Continent);
            $("#AddressGeneralateka").val(result.Address);
            $("#Website").val(result.Website);
            $("#Phone").val(result.Phone);
            $("#Fax").val(result.Fax);
            $("#Country").val(result.Country);
            $("#Email").val(result.Email);
            $("#History").val(result.History);
            $("#VissionGeneralate").val(result.Vission);
            $("#MissionGeneralate").val(result.Mission);
            $("#FileGen").text(result.File);

            $("#Foundation_Date2").val(result.FoundationDate);
            $("#Foundation_day2").val(result.Foundationday);
            $("#Date_of_the_diocesan_decree2").val(result.DiocesanDecreeDate);
            $("#Date_of_pontifical_decree2").val(result.PontificalDecreeDate);
            $("#Date_of_the_official_gouvernemental_decree_in_France2").val(result.GouvernementalDecreeDate);
            $("#CIVCSVA2").val(result.DepCIVCSVA);

            $("#NameofFounder").val(result.NameofFounder);
            $("#NameofCoFounder").val(result.NameofCoFounder);
            $("#CongregationMotto").val(result.CongregationMotto);
            $("#CongregationLogo1").text(result.CongregationLogo);
            // $("#CongregationLogo").val(data[0].CongregationLogo);
            var value = result.CongregationCountriesofMission;
            if (value != null || value != undefined) {
                var valuedata = value.split(",");
                $('#CongregationCountriesofMission').multipleSelect('setSelects', valuedata);
            }


            $('#DioceseNameCong opetion[value="' + result.Diocese + '"]').attr("selected", "selected");
            $("#DioceseNameCong").val(result.Diocese).change();
            value = result.Activities;
            if (value != null || value != undefined) {
                var valuedata = result.Activities.split(",");
                $('#ActivitiesGeneralate').multipleSelect('setSelects', valuedata);
            }
            if (result.FamilyBelongsTo != "Yes") {
                $("#FamilyBelongsTo1").attr('checked', true);
            }
            else {
                $("#FamilyBelongsTo1").attr('checked', false);
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    }); return false;
}

$(".EditProvince").on('click', function () {
    //debugger;
    $('#ProvinceForm').attr('action', '/IdGenerate/UpdateProvince');
    var id = $(this).attr("data-val");
    $("#AddProvince").text("Update");
    $(".panel-body").scrollTop(0);
    GetProvById(id);
    //GetGrid();
});
function GetProvById(id) {
    $.ajax({
        url: "/IdGenerate/GetProvById?id=" + id,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            //debugger;
            $("#ProvCode").change(function () {
                var selectedCountry = $("#ProvCode").val();
                if (selectedCountry != null && selectedCountry != '') {
                    AddRegions(selectedCountry, regionsSelect);
                }
            });
            $("#ProvId").val(result.Id);
            $("#MyId").val(result.MyId);
            $("#ProvinceName1").val(result.ProvinceName);
            $('#CountryProvinceka').select2('destroy');
            $("#CountryProvinceka").val(result.Country);
            $("#StartDate123").val(result.StartDate);
            $("#CloseDate123").val(result.EndDate);
            $("#SuspensionDate123").val(result.SuspensionDate);
            $("#RestartDate123").val(result.RestartDate);
            $("#NameofFounders").val(result.NameofFounders);
            $("#NameofFounder").val(result.NameofFounder);
            $("#CountryProvinceka").select2();
            $("#ProvCode").val(result.Place);
            $("#CreatedBy").val(result.CreatedBy);
            $("#ReligiousTitle").val(result.ReligiousTitle);
            $("#Continent123").val(result.Continent);
            
            $("#EmailId").val(result.EmailId);
            $("#ProPhoneE").val(result.Phone);
            $("#ProFaxE").val(result.Fax);
            //$("#HistoryProvinceka").val(result.History);
            CKEDITOR.instances['HistoryProvinceka'].setData(result.History);
            $("#VissionProvinceka").val(result.Vission);
            $("#Status").val(result.ActiveCkeck);
            $("#MissionProvinceka").val(result.Mission);
            $("#FilePro12").text(result.File);
            $("#ProvinceMotto").val(result.ProvinceMotto);
            $("#ProvinceLogo1").text(result.ProvinceLogo);
            var value = result.ProvinceCountriesofMission;
            if (value != null || value != undefined) {
                var valuedata = value.split(",");
                $('#ProvinceCountriesofMission').multipleSelect('setSelects', valuedata);
            }

            value = result.Activities;
            if (value != null || value != undefined) {
                var valuedata = result.Activities.split(",");
                $('#ActivitiesProvinceka').multipleSelect('setSelects', valuedata);
            }

            //$('#DisSecProvinceka opetion[value="' + result.DisSec + '"]').attr("selected", "selected");
            //$("#DisSecProvinceka").val(result.DisSec).change();

            $('#DioceseNameProv opetion[value="' + result.Diocese + '"]').attr("selected", "selected");
            $("#DioceseNameProv").val(result.Diocese).change();

            if (result.ActiveCkeck == "Active") {
                $("#ActiveCheck1").prop("checked", true);
            } else {

                $("#ActiveCheck2").prop("checked", true);
            }
            GetGrid();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    }); return false;
}

$(".EditDisSec").on('click', function () {
    //debugger;
    $('#DistSecForm').attr('action', '/IdGenerate/UpdateDistSec');
    var id = $(this).attr("data-val");
    $("#AddDisSec").text("Update");
    $(".panel-body").scrollTop(0);
    GetDistSecById(id);
});
function GetDistSecById(id) {
    $.ajax({
        url: "/IdGenerate/GetDistSecById?id=" + id,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            //debugger;

            $('#DisSecType opetion[value="' + result.DisSec + '"]').attr("selected", "selected");
            $("#DisSecType").val(result.DisSec).change();
            $("#DisSecRegId").val(result.Id);
            $("#DisSecRegName").val(result.DistSecName);
            $("#MyIdDisSecReg").val(result.MyId);
            $("#EmailIdDisSec").val(result.EmailId);
            $("#CountryDisSec").val(result.Country);
            $(".CountrySelect2").select2('destroy');
            $(".CountrySelect2").val(result.Country);
            $(".CountrySelect2").select2();
            $("#FileDisSec12").text(result.File);
            if (result.ActiveCkeck == "Active") {
                $("#ActiveDisSec1").prop("checked", true);
            } else {
                $("#ActiveDisSec2").prop("checked", true);
            }
            $('#DioceseNameDisSec opetion[value="' + result.Diocese + '"]').attr("selected", "selected");
            $("#DioceseNameDisSec").val(result.Diocese).change();
            $("#HistoryDisSec").val(result.History);

            var value = result.Activities;
            if (value != null || value != undefined) {
                var valuedata = result.Activities.split(",");
                $('#ActivitiesDisSec1').multipleSelect('setSelects', valuedata);
            }
            $('#DisSecRegProvinceName opetion[value="' + result.ProvinceName + '"]').attr("selected", "selected");
            $("#DisSecRegProvinceName").val(result.ProvinceName).change();

            $("#VissionDisSec").val(result.Vission);
            $("#MissionDisSec").val(result.Mission);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    }); return false;
}

$(".EditOutside123").on('click', function () {
    //debugger;
    $('#CommunityFormOutSide').attr('action', '/IdGenerate/UpdateCommunityOutside');
    var id = $(this).attr("data-val");
    $("#CommunityOutSidebtn").text("Update");
    $(".panel-body").scrollTop(0);
    GetCommunityByIdOutside(id);
});
function GetCommunityByIdOutside(id) {
    $.ajax({
        url: "/IdGenerate/GetCommunityByIdOutside?id=" + id,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            //debugger;
            $("#CommunityId1").val(result.Id);
            $("#CommunityName1").val(result.CommunityName);
            $("#ComCode1234").val(result.ComCode);
            $("#CommunityPlace1").val(result.Place);
            $("#CommunityAddress1").val(result.Address);
            $("#CommunityContactNumber1").val(result.Phone);
            $("#OtherProvinceName1").val(result.OtherProvince);
            $("#Country1").val(result.Country);
            $("#EmailId1").val(result.EmailId);
            $("#DisSec1").val(result.DisSec);
            $("#FileCOS12").text(result.File);

            var value = result.Activities;
            if (value != null || value != undefined) {
                var valuedata = result.Activities.split(",");
                $('#ActivitiesCOS').multipleSelect('setSelects', valuedata);
            }
            $('#DioceseNameCOS opetion[value="' + result.Diocese + '"]').attr("selected", "selected");
            $("#DioceseNameCOS").val(result.Diocese).change();
            if (result.ActiveCkeck == "Active") {
                $("#ActiveCheck11").prop("checked", true);
            } else {
                $("#ActiveCheck12").prop("checked", true);
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    }); return false;
}

$(".EditCommunity1234").on('click', function () {
    //debugger;
    $('#CommunityFormHouse').attr('action', '/IdGenerate/UpdateCommunityComHouse');
    var id = $(this).attr("data-val");
    $("#CommunityHousebtn").text("Update");
    $(".panel-body").scrollTop(0);
    GetCommunityByIdComHouse(id);
});
function GetCommunityByIdComHouse(id) {
    $.ajax({
        url: "/IdGenerate/GetCommunityByIdComHouse?id=" + id,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            debugger;
            $("#CommunityId2").val(result.Id);
            $("#CommunityName2").val(result.CommunityName);
            $("#CommunityCode2").val(result.CommunityCode);
            $("#CommunityPlace2").val(result.Place);
            $("#CommunityAddress2").val(result.Address);
            $("#CommunityContactNumber2").val(result.Phone);
            $("#Country2").val(result.Country);
            $("#EmailId2").val(result.EmailId);
            $("#FileCH123").text(result.File);

            var value = result.Activities;
            if (value != null || value != undefined) {
                var valuedata = result.Activities.split(",");
                $('#ActivitiesCH').multipleSelect('setSelects', valuedata);
            }
            $('#OtherProvinceName2 opetion[value="' + result.OtherProvince + '"]').attr("selected", "selected");
            $("#OtherProvinceName2").val(result.OtherProvince).change();

            $('#DioceseNameCH opetion[value="' + result.Diocese + '"]').attr("selected", "selected");
            $("#DioceseNameCH").val(result.Diocese).change();

            $('#DisSec2 opetion[value="' + result.DisSec + '"]').attr("selected", "selected");
            $("#DisSec2").val(result.DisSec).change();

            if (result.ActiveCkeck == "Active") {
                $("#ActiveCheck13").prop("checked", true);
            } else {
                $("#ActiveCheck14").prop("checked", true);
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    }); return false;
}

$(".EditDiocese").on('click', function () {
    //debugger;
    $('#DioceseForm').attr('action', '/IdGenerate/UpdateDiocese');
    var id = $(this).attr("data-val");
    $("#AddDiocese").text("Update");
    $(".panel-body").scrollTop(0);
    GetDioceseById(id);
});
function GetDioceseById(id) {
    $.ajax({
        url: "/IdGenerate/GetDioceseById?id=" + id,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            //debugger;
            $("#IdDio").val(result.Id);
            $("#DioId").val(result.DioId);
            $("#DioceseName").val(result.DioceseName);
            $("#Placedio").val(result.Place);
            $("#AddressDio").val(result.Address);
            $("#EmailIdDio").val(result.EmailId);
            $("#FileDio12").text(result.FileDio);
            $("#CountryOfDiocese").val(result.Country);
            $('#DioProvince opetion[value="' + result.ProvinceName + '"]').attr("selected", "selected");
            $("#DioProvince").val(result.ProvinceName).change();
            //$('#DioState1 opetion[value="' + result.State + '"]').attr("selected", "selected");
            //$("#DioState1").val(result.State).change();
            var value = result.State;
            if (value != null || value != undefined) {
                var valuedata = result.State.split(",");
                $('#DioState1').multipleSelect('setSelects', valuedata);
                $('#DioState1').change();
            }
            if (result.ActiveCkeck == "Active") {
                $("#ActiveCheckDioa").prop("checked", true);
            } else {
                $("#ActiveCheckDiob").prop("checked", true);
            }

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    }); return false;
}

//$(".EditParish").on('click', function () {
//    //debugger;
//    $('#ParishForm').attr('action', '/IdGenerate/UpdateIdGenerate');
//    var id = $(this).attr("data-val");
//    $("#btnAddParish").text("Update");
//    GetIdGenerateParishById(id);
//});
//function GetIdGenerateParishById(id)
//{
//    $.ajax({
//        url: "/IdGenerate/GetParishById?id=" + id,
//        type: "GET",
//        contentType: "application/json;charset=UTF-8",
//        dataType: "json",
//        success: function (result) {
//            //debugger;
//            $("#Id").val(result.Id); 
//            $("#Name").val(result.Name);
//            $("#ParishId").val(result.MyId); 
//            $("#Place").val(result.Place);
//            $('#TypesOfReg option[value="' + result.TypesOfReg + '"]').attr("selected", "selected");
//            $('#TypesOfReg').val(result.TypesOfReg).change();
//            $('#ProvinceName option[value="' + result.ProvinceName + '"]').attr("selected", "selected");
//            $('#ProvinceName').val(result.ProvinceName).change();
//            $("#Telephone").val(result.Telephone);
//            $("#YearOfEstablacement").val(result.YearOfEstablacement);
//            $("#ParishAddress123").val(result.Address);
//            $("#fileparish").text(result.FileName);

//            var value = result.Activities;
//            if (value != null || value != undefined) {
//                var valuedata = result.Activities.split(",");
//                $('#ActivitiesTrust').multipleSelect('setSelects', valuedata);
//            }
//            $('#DioceseTrust opetion[value="' + result.Diocese + '"]').attr("selected", "selected");
//            $("#DioceseTrust").val(result.Diocese).change();

//            if (result.ActiveCkeck == "Active") {
//                $("#ActiveCheck9").prop("checked", true);
//            } else {
//                $("#ActiveCheck10").prop("checked", true);
//            }
//        },
//        error: function (errormessage) {
//            alert(errormessage.responseText);
//        }
//    }); return false;
//}

//$(".EditInstitution").on('click', function () {
//    //debugger;
//    $('#InstitutiionForm').attr('action', '/IdGenerate/UpdateInsitution');
//    var id = $(this).attr("data-val");
//    $("#btnAddInstitution").text("Update");
//    GetIdGenerateInstitutionById(id);
//});
//function GetIdGenerateInstitutionById(id) {
//    $.ajax({
//        url: "/IdGenerate/GetParishById?id=" + id,
//        type: "GET",
//        contentType: "application/json;charset=UTF-8",
//        dataType: "json",
//        success: function (result) {
//            //debugger;
//            $("#InstId").val(result.Id);
//            $("#InstName123").val(result.Name);
//            $("#InstitutionId123").val(result.MyId);
//            $("#InstPlace123").val(result.Place);
//            $("#InstType").val(result.Type);
//            $("#InstRegistrationNo").val(result.RegistrationNo);
//            $("#InstTelephone").val(result.Telephone);
//            $("#InstYearOfEstablacement").val(result.YearOfEstablacement);
//            $("#InstAddress").val(result.Address);
//            $("#Instfile12").text(result.FileName);
//            $("#InstDiscCode").val(result.DiscCode);
//            $("#InstTypeCode").val(result.TypeCode);
//            $("#InstRegIdCode").val(result.RegIdCode);
//            $("#InstBEORegCode").val(result.BEORegCode);

//            $('#ProvinceNameInst option[value="' + result.ProvinceName + '"]').attr("selected", "selected");
//            $('#ProvinceNameInst').val(result.ProvinceName).change();
//            var value = result.Activities;
//            if (value != null || value != undefined) {
//                var valuedata = result.Activities.split(",");
//                $('#ActivitiesInst').multipleSelect('setSelects', valuedata);
//            }
//            $('#DioceseInst opetion[value="' + result.Diocese + '"]').attr("selected", "selected");
//            $("#DioceseInst").val(result.Diocese).change();

//            $("#InstCertificationCode").val(result.CertificationCode);
//            $("#InstOtherDoc12").text(result.OtherDoc);
//            $('#Persohomeparish').val(result.InstitutionType);
//            $("#Country12inst").val(result.Country);
//            $("#EmailId12inst").val(result.EmailId);
//            $("#InstDisSec123").val(result.DisSec);
//            if (result.ActiveCkeck == "Active") {
//                $("#ActiveCheck3").prop("checked", true);
//            } else {
//                $("#ActiveCheck4").prop("checked", true);
//            }
//        },
//        error: function (errormessage) {
//            alert(errormessage.responseText);
//        }
//    }); return false;
//}

//$(".SocietyEdit12").on('click', function () {
//    //debugger;
//    $('#SocietyForm').attr('action', '/IdGenerate/UpdateSociety');
//    var id = $(this).attr("data-val");
//    $("#btnSociety").text("Update");
//    GetSocietyById(id);
//});
//function GetSocietyById(id) {
//    $.ajax({
//        url: "/IdGenerate/GetSocietyById?id=" + id,
//        type: "GET",
//        contentType: "application/json;charset=UTF-8",
//        dataType: "json",
//        success: function (result) {
//            //debugger;
//            $("#SocietyId12").val(result.Id);
//            $("#SocietyName").val(result.NameOfTheSocity);
//            $("#SocId").val(result.SocId);
//            $("#SocietyDate").val(result.Date);
//            $("#SocietyRegistrationNumber").val(result.RegistrationNumber);
//            $("#SocietyPanNumber").val(result.PanNumber);
//            $("#SocietyFCRANumber").val(result.FCRANumber);
//            $("#SocietyNumber12A").val(result.Number12A);
//            $("#SocietyNumber12AA").val(result.Number12AA);
//            $("#SocietyNumber80G").val(result.Number80G); 
//            $("#AddressSoc12data").val(result.Address);
//            $("#VissionSoc12data").val(result.Vission);
//            $("#MissionSoc12data").val(result.Mission); 
//            $('#TypesOfReg12 option[value="' + result.TypesOfReg + '"]').attr("selected", "selected");
//            $('#TypesOfReg12').val(result.TypesOfReg).change();
//            $('#ProvinceNameSoc option[value="' + result.ProvinceName + '"]').attr("selected", "selected");
//            $('#ProvinceNameSoc').val(result.ProvinceName).change();
//            $('#DioceseSoc opetion[value="' + result.Diocese + '"]').attr("selected", "selected");
//            $("#DioceseSoc").val(result.Diocese).change();
//            $("#SocFiles").text(result.File);
//            if (result.ActiveCkeck == "Active") {
//                $("#ActiveCheck5").prop("checked", true);
//            } else {
//                $("#ActiveCheck6").prop("checked", true);
//            }

//            var value = result.Activities;
//            if (value != null || value != undefined) {
//                var valuedata = result.Activities.split(",");
//                $('#ActivitiesSoc').multipleSelect('setSelects', valuedata);
//            }
//        },
//        error: function (errormessage) {
//            alert(errormessage.responseText);
//        }
//    }); return false;
//}

//$(".EditCommunity").on('click', function () {
//    //debugger;
//    $('#CommunityForm').attr('action', '/IdGenerate/UpdateCommunity');
//    var id = $(this).attr("data-val");
//    $("#AddCommunity").text("Update");
//    GetCommunityById(id);
//});
//function GetCommunityById(id) {
//    $.ajax({
//        url: "/IdGenerate/GetCommunityById?id=" + id,
//        type: "GET",
//        contentType: "application/json;charset=UTF-8",
//        dataType: "json",
//        success: function (result) {
//            //debugger;
//            $("#CommunityId").val(result.Id);
//            $("#CommunityName112").val(result.CongregationName);
//            $("#CommCode123").val(result.CommCode);
//            $("#CommunityId123").val(result.CommId);
//            $("#CommunityPlace").val(result.Place);
//            $("#CommunityAddress").val(result.Address);
//            $("#CommunityContactNumber").val(result.Phone);
//            $('#ProvinceNameCom123 option[value="' + result.ProvinceName + '"]').attr("selected", "selected");
//            $('#ProvinceNameCom123').val(result.ProvinceName).change();
//            $("#Country123com").val(result.Country);
//            $("#EmailId123com").val(result.EmailId);
//            $("#DisSec123com").val(result.DisSec);
//            $('#DioceseCom opetion[value="' + result.Diocese + '"]').attr("selected", "selected");
//            $("#DioceseCom").val(result.Diocese).change();

//            $("#CommFile").text(result.File);
//            if (result.ActiveCkeck == "Active") {
//                $("#ActiveCheck7").prop("checked", true);
//            } else {
//                $("#ActiveCheck8").prop("checked", true);
//            }
//            var value = result.Activities;
//            if (value != null || value != undefined) {
//                var valuedata = result.Activities.split(",");
//                $('#ActivitiesCom').multipleSelect('setSelects', valuedata);
//            }
//        },
//        error: function (errormessage) {
//            alert(errormessage.responseText);
//        }
//    }); return false;
//}






/////////////////////////////////validation
function ProvinceValidation() {
    $('#ActiveInactiveProErrorMessage').text("");
    var act1 = $('#ActiveCheck1').is(":checked");
    var act2 = $('#ActiveCheck2').is(":checked");
    if (act1 == false && act2 == false) {
        $('#ActiveInactiveProErrorMessage').text("please select any one Active or InActive");//.css("color",red);
        // alert("please select any one Active or InActive")
        return false;
    }
    return true;
}
function DistrictValidation() {
    $('#ActiveInactiveDisErrorMessage').text("");
    var act1 = $('#ActiveDisSec1').is(":checked");
    var act2 = $('#ActiveDisSec2').is(":checked");
    if (act1 == false && act2 == false) {
        $('#ActiveInactiveDisErrorMessage').text("please select any one Active or InActive");//.css("color",red);
        return false;
    }
    else if ($('#DisSecRegProvinceName').val() == 0) {
        return false;
    }
    else if ($('#ActivitiesDisSec1').val() == null) {
        return false;
    }
    return true;
}

function OutSideValidation() {
    $('#ActiveInactiveOutSideConErrorMessage').text("");
    var act1 = $('#ActiveCheck11').is(":checked");
    var act2 = $('#ActiveCheck12').is(":checked");
    if (act1 == false && act2 == false) {
        $('#ActiveInactiveOutSideConErrorMessage').text("please select any one Active or InActive");//.css("color",red);
        return false;
    }
    else if ($('#DioceseNameCOS').val() == 0) {
        return false;
    }
    else if ($('#ActivitiesCOS').val() == null) {
        return false;
    }
    return true;
}

function CommonHouseValidation() {
    $('#ActiveInactiveCommonHouseErrorMessage').text("");
    var act1 = $('#ActiveCheck13').is(":checked");
    var act2 = $('#ActiveCheck14').is(":checked");
    if (act1 == false && act2 == false) {
        $('#ActiveInactiveCommonHouseErrorMessage').text("please select any one Active or InActive");//.css("color",red);
        return false;
    }
    else if ($('#DioceseNameCH').val() == 0) {
        return false;
    }
    else if ($('#ActivitiesCH').val() == null) {
        return false;
    }
    return true;
}

function DioceseValidation() {
    $('#ActiveInactiveDioceseErrorMessage').text("");
    var act1 = $('#ActiveCheckDioa').is(":checked");
    var act2 = $('#ActiveCheckDiob').is(":checked");
    if (act1 == false && act2 == false) {
        $('#ActiveInactiveDioceseErrorMessage').text("please select any one Active or InActive");//.css("color",red);
        return false;
    }
    else if ($('#DioProvince').val() == 0) {
        return false;
    }
    else if ($('#DioState1').val() == 0) {
        return false;
    }
    return true;
}

function SaveActivitiesPopup() {
    if ($('#Name1').val() == "") {
        ShowDialogMessage("Please enter the Name!");
        return false;
    }
    var name = $('#Name1').val();
    var option = '<option value="' + name + '">' + name + '</option>';
    $('#ActivitiesGeneralate,#ActivitiesProvinceka,#ActivitiesDisSec1,#ActivitiesCOS,#ActivitiesCH').append(option);
    $('#ActivitiesGeneralate,#ActivitiesProvinceka,#ActivitiesDisSec1,#ActivitiesCOS,#ActivitiesCH').multipleSelect({
        width: 355,
        allSelectedText: 'All'
    })
    $("#MyModalMaster").modal('hide');
    SaveDataList($('#DataListName1').val(), $('#Name1').val(), "");
    $('#Name1').val('');
}

function SaveCountyPopup() {
    var name = $('#CountryName').val();
    if (name == "") {
        ShowDialogMessage("Please enter the Name!");
        return false;
    }
    if ($('#CountryContinent').val() == "0") {
        ShowDialogMessage("Please enter the Continent!");
        return false;
    }

    var option = '<option value="' + name + '">' + name + '</option>';
    $('#CountryProvinceka,#Country,#Country,#Country1,#Country2,#CountryOfDiocese,#CountryOfDiocese1').append(option);
    $('#CongregationCountriesofMission,#ProvinceCountriesofMission').append(option);

    $('#ProvinceCountriesofMission,#CongregationCountriesofMission').multipleSelect({
        width: 355,
        allSelectedText: 'All'
    })

    $("#MyModalCountry").modal('hide');
    SaveDataList($('#DataListCountryName').val(), $('#CountryName').val(), $('#CountryContinent').val());
    $('#CountryName,#CountryContinent').val('');
}

function SaveDataList(DataListName, Name, Continent) {

    $.ajax({
        url: "/Data/DataItemCountryDetailSave",
        type: "POST",
        data: { DataListName: DataListName, Name: Name, Continent: Continent },
        dataType: "json",
        success: function (result) {
            ShowDialogMessage(result);
        }
    });
}

function ShowDialogMessage(msg) {
    $('#DialogMessage').text(msg);
    $("#MyModalDialog").modal('show');
}

function CloseDialogMessage() {
    $("#MyModalDialog").modal('hide');
}

