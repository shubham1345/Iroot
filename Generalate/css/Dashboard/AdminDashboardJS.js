//import { async } from "q";

$(document).ready(function () {
    //$('#ProvinceDrop1').select2({ data: [{ id: '', text: '' }] });
    $("#SocietyDrop").select2({
    });
    $("#CongrationDrop").select2({});
    $("#CongsDrop").select2({});
    $("#ComOSDrop").select2({});
    $("#DisSecDrop").select2({});
    $("#ProvinceDrop1").select2({
    }); 
    $("#ProvinceDrop").select2({});
    $("#persionNames").select2({});
    //GetAllPersions2();
    //GetAllSociety();
    //GetAllCongrations();
    //GetAllCongs();
    //GetAllProvince();
    //GetAllComOutSide();
    //GetAllComHouse();
    //GetAllDiocese();
    //GetAllDisSec();
    
});

//$(document).ready(function () {
//    //GetAllParish12();
//    //GetAllInstitution12();
//    //GetAllProvince1();
//});
function GetAllProvince1() {
    $.ajax({
        url: "/Home/GetAllProvince",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response2) {

            if (response2.length > 0 || response2 != "Fail") {
                var allDate2 = [];
                var omObj2 = {};
                $('#ProvinceDrop1').html('').select2({ data: [{ id: '', text: '' }] });
                //allDate2.push({ id: '0', text: '-- All Province --' });
                if ($("#Language").val() == 'EN') {
                    allDate2.push({ id: '0', text: '-- All Province --' });

                }
                else {
                    allDate2.push({ id: '0', text: '-- Toutes les provinces --' });

                }
                for (var i = 0; i < response2.length; i++) {
                    allDate2.push({ id: response2[i].Id, text: response2[i].ProvinceName + " " + response2[i].Place });
                }
                $("#ProvinceDrop1").html('').select2({
                    data: allDate2
                });
            }
            else {
                window.location.href = '/Account/Login';
            }
        },
        error: function (er) {
        }
    });
}

$("#btnSubmit").on("click", function () {
    var persionId = $("#persionNames option:selected").val();
    var radioBtn = $("input[name='radioBtn']:checked").val();
    if (radioBtn == "P") {
        var memberId = $("#memberId").val();
        //var text = @{@HomeController.GetControlTextByControlId("Id")};
        if (persionId !== "0") {
            window.location.href = "/Member/MemberInfoById_Primary" + "?memberId=" + memberId + "&Name=" + '' + "&SirName=" + '';
        } else {
            if ($("#Language").val() == 'EN') {
                alert("Please Select Member Name");
                //alert(HomeController.GetControlTextByControlId("MemberId"));
            }
            else {
                alert("Veuillez sélectionner le nom du membre");
            }
        }
    }
});
$("#btnSubmit1").on("click", function () {
    //InstitutionDrop
    //debugger;
    var parisChk = $("#ParisDrop option:selected").val();
    var InstitutionChk = $("#InstitutionDrop option:selected").val();

    var parisChkName = $("#ParisDrop option:selected").text();
    var InstitutionChkName = $("#InstitutionDrop option:selected").text();
    var changeProvincenDrop = $("#ChangeProvincenDrop option:selected").text();
    var Id = $("#Id").val();
    var myId = $("#IdCong").val();
    //ChangeProvinceDiv
    
    var radioBtn = $("input[name='radioBtn1']:checked").val();
    if (radioBtn == "Paris") {
        if (parisChk !== "0") {
            window.location.href = "/Paris/ParisList/?id=" + Id + "&&name=" + parisChkName;
        }
    }
    else if (radioBtn == "ChangeProvince") {
        window.location.href = "/ChangingProvince/ChangingProvinceList/?myId=" + Id;
        // }
    } else if (InstitutionChk !== "0") {
        window.location.href = "/Institution/InstitutionList/?id=" + Id + "&&name=" + InstitutionChkName;

    } else {
        $("#RdParis").prop("checked", true);
        if ($("#Language").val() == 'EN') {
            alert("Please select paris");
        }
        else {
            alert("Veuillez sélectionner paris");
        }
    }
});
$("#btnSocCong").on("click", function () {
    var sociertyDrop = $("#SocietyDrop option:selected").val();
    var CongDrop = $("#ProvinceDrop option:selected").val();

    var Id = $("#IdSocCong").val();
    var radioBtn = $("input[name='radioBtn3']:checked").val();
    if (radioBtn == "Society") {
        if (sociertyDrop !== "0") {
            window.location.href = "/Home/SociertDetails?id=" + Id;
        } else {
            if ($("#Language").val() == 'EN') {
                alert("Please Select Society");
            }
            else {
                alert("Veuillez sélectionner la société");
            }
        }
    } else {
        if (CongDrop !== "0") {
            window.location.href = "/Home/ProvinceList?myId=" + Id;
        } else {
            if ($("#Language").val() == 'EN') {
                alert("Please Select Province");
            }
            else {
                alert("Veuillez sélectionner Félicitations");
            }
        }
    }
});
$("#btnCong").on("click", function () {
    //debugger;
    var CongsDrop = $("#CongsDrop option:selected").val();
    var ProvinceDrop = $("#ProvinceDrop option:selected").val();
    var Id = $("#IdCong").val();
    var myId = $("#IdCong").val();

    //debugger;
    if (Id == "" || Id == "0") {
        if ($("#Language").val() == 'EN') {
            alert("Please select value from Dropdown of radio selection");

        }
        else {

            alert("Veuillez sélectionner une valeur dans le menu déroulant de la sélection radio");
        }
        return false;
    }

    var radioBtn = $("input[name='radioBtn5']:checked").val();
    if (radioBtn == "Congre") {
        if (CongsDrop !== "0") {
            window.location.href = "/Home/CongrationList?id=" + Id;
        } else {
            if ($("#Language").val() == 'EN') {
                alert("Please Select Congregation");
            }
            else {
                alert("Veuillez sélectionner la congrégation");

            }
        }
    } else {

        if (ProvinceDrop !== "0") {
            window.location.href = "/Home/ProvinceList?myId=" + myId;
        } else {
            if ($("#Language").val() == 'EN') {

                alert("Please Select Province");
            }
            else {
                alert("Veuillez sélectionner la province");
            }
        }
    }
});
$("#btnComOSCH").on("click", function () {
    //debugger;
    var ComOSDrop = $("#ComOSDrop option:selected").val();
    var dioName = $("#DioNames option:selected").val();

    var Id = $("#IdComOSCH").val();
    var myId = $("#IdComOSCH").val();

    if (Id == "" || Id == "0") {
        if ($("#Language").val() == 'EN') {
        alert("Please select value from Dropdown of radio selection");

        } else {
            alert("Veuillez sélectionner une valeur dans le menu déroulant de la sélection radio");

        }
        return false;
    }

    var radioBtn = $("input[name='radioBtn6']:checked").val();
    if (radioBtn == "ComOS") {
        if (ComOSDrop !== "0") {
            window.location.href = "/Home/ComOutSideList?id=" + Id;
        } else {
            if ($("#Language").val() == 'EN') {
            alert("Please Select Community");

            }
            else {

                alert("Veuillez sélectionner la communauté");
            }
        }
    } else {
        if (dioName !== "0") {
            window.location.href = "/EntryLife/Details?id=" + myId;
        } else {
            if ($("#Language").val() == 'EN') {

            alert("Please Select Diocese Name");
            }
            else {
                alert("Veuillez sélectionner le nom du diocèse");

            }
        }
    }
});
$("#btnDisSec").on("click", function () {
    //debugger;
    var DisSecDrop = $("#DisSecDrop option:selected").val();
    var ComHouseDrop = $("#ComHouseDrop option:selected").val();
    var Id = $("#IdDisSec").val();
    var myId = $("#IdDisSec").val();
    if (Id == "" || Id == "0") {
        if ($("#Language").val() == 'EN') {
        alert("Please select value from Dropdown of radio selection");

        }
        else {
            alert("Veuillez sélectionner une valeur dans le menu déroulant de la sélection radio");

        }
        return false;
    }
    var radioBtn = $("input[name='radioBtn7']:checked").val();
    if (radioBtn == "DisSec") {
        if (DisSecDrop !== "0") {
            window.location.href = "/Home/DisSecList?id=" + Id;
        } else {
            if ($("#Language").val() == 'EN') {

            alert("Please Select Items");
            }
            else {

                alert("Veuillez sélectionner des articles");
            }
        }
    } else {
        if (ComHouseDrop !== "0") {
            window.location.href = "/Home/ComHouseList?id=" + myId;
        } else {
            if ($("#Language").val() == 'EN') {

            alert("Please Select Community");
            }
            else {
                alert("Veuillez sélectionner la communauté");

            }
        }
    }
});

function GetPersionById(id) {
    $.ajax({
        url: "/Home/GetPersionDetailbyId/" + id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            $("#memberId").val(response.MemberID);
        },
        error: function (er) {
        }
    });
}
function GetAllParish12() {
    $.ajax({
        url: "/Home/GetAllParish12",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response1) {
            if (response1.length > 0) {
                var allDate1 = [];
                var omObj1 = {};
                $('#ParisDrop').html('').select2({ data: [{ id: '', text: '' }] });
                if ($("#Language").val() == 'EN') {
                allDate1.push({ id: '0', text: '-- Select Name --' });

                } else {
                    allDate1.push({ id: '0', text: '-- Sélectionnez le nom --' });

                }
                for (var i = 0; i < response1.length; i++) {
                    allDate1.push({ id: response1[i].MyId, text: response1[i].Name });
                }
                $("#ParisDrop").html('').select2({
                    data: allDate1
                });
            }
        },
        error: function (er) {
            //alert(er);
        }
    });
}
function GetAllInstitution12() {
    $.ajax({
        url: "/Home/GetAllInstitution12",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response2) {
            //debugger;
            if (response2.length > 0) {
                var allDate2 = [];
                var omObj2 = {};
                $('#InstitutionDrop').html('').select2({ data: [{ id: '', text: '' }] });
                if ($("#Language").val() == 'EN') {
                    allDate2.push({ id: '0', text: '-- Select Name --' });

                }
                else {
                    allDate2.push({ id: '0', text: '-- Sélectionnez le nom --' });

                }
                for (var i = 0; i < response2.length; i++) {
                    allDate2.push({ id: response2[i].MyId, text: response2[i].Name });
                }
                $("#InstitutionDrop").html('').select2({
                    data: allDate2
                });
            }
        },
        error: function (er) {
        }
    });
}
async function GetAllSociety() {
    await $.ajax({
        url: "/Home/GetAllSociety",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response2) {
            if (response2.length > 0 || response2 != "Fail") {
                var allDate2 = [];
                var omObj2 = {};
                $('#SocietyDrop').html('').select2({ data: [{ id: '', text: '' }] });
                //allDate2.push({ id: '0', text: '-- Select Name --' });
                if ($("#Language").val() == 'EN') {
                    allDate2.push({ id: '0', text: '-- Select Name --' });

                }
                else {
                    allDate2.push({ id: '0', text: '-- Sélectionnez le nom --' });

                }
                for (var i = 0; i < response2.length; i++) {
                    allDate2.push({ id: response2[i].Id, text: response2[i].NameOfTheSocity });
                }
                $("#SocietyDrop").html('').select2({
                    data: allDate2
                });
            }
            else {
                window.location.href = "/Account/Login";
            }
        },
        error: function (er) {
        }
    });
}
async function GetAllCongrations() {
    await $.ajax({
        url: "/Home/GetAllCongrations",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response2) {
            if (response2.length > 0) {
                var allDate2 = [];
                var omObj2 = {};
                $('#CongrationDrop').html('').select2({ data: [{ id: '', text: '' }] });
                //allDate2.push({ id: '0', text: '-- Select Name --' });
                if ($("#Language").val() == 'EN') {
                    allDate2.push({ id: '0', text: '-- Select Name --' });

                }
                else {
                    allDate2.push({ id: '0', text: '-- Sélectionnez le nom --' });

                }
                for (var i = 0; i < response2.length; i++) {
                    allDate2.push({ id: response2[i].Id, text: response2[i].CongregationName });
                }
                $("#CongrationDrop").html('').select2({
                    data: allDate2
                });
            }
        },
        error: function (er) {
        }
    });
}
async function GetAllCongs() {
    await $.ajax({
        url: "/Home/GetAllCongs",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response2) {
            if (response2.length > 0) {
                var allDate2 = [];
                var omObj2 = {};
                $('#CongsDrop').html('').select2({ data: [{ id: '', text: '' }] });
                //allDate2.push({ id: '0', text: '-- Select Name --' });
                if ($("#Language").val() == 'EN') {
                    allDate2.push({ id: '0', text: '-- Select Name --' });

                }
                else {
                    allDate2.push({ id: '0', text: '-- Sélectionnez le nom --' });

                }
                for (var i = 0; i < response2.length; i++) {
                    allDate2.push({ id: response2[i].Id, text: response2[i].CongregationName });
                }
                $("#CongsDrop").html('').select2({
                    data: allDate2
                });
            }
        },
        error: function (er) {
        }
    });
}


async function GetAllProvince() {

    await $.ajax({
        url: "/Home/GetAllProvince",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response2) {
            if (response2.length > 0) {
                var allDate2 = [];
                var omObj2 = {};
                $('#ProvinceDrop,#ChangeProvincenDrop').html('').select2({ data: [{ id: '', text: '' }] });
                //allDate2.push({ id: '0', text: '-- Select Name --' });
                if ($("#Language").val() == 'EN') {
                    allDate2.push({ id: '0', text: '-- Select Name --' });

                }
                else {
                    allDate2.push({ id: '0', text: '-- Sélectionnez le nom --' });

                }
                for (var i = 0; i < response2.length; i++) {
                    allDate2.push({ id: response2[i].Id, text: response2[i].ProvinceName + " " + response2[i].Place });
                }
                $("#ProvinceDrop,#ChangeProvincenDrop").html('').select2({
                    data: allDate2
                });
            }
        },
        error: function (er) {
        }
    });
}
async function GetAllComOutSide() {
    await $.ajax({
        url: "/Home/GetAllComOutSide",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response2) {
            var allDate2 = [];
            var omObj2 = {};
            $('#ComOSDrop').html('').select2({ data: [{ id: '', text: '' }] });
            //allDate2.push({ id: '0', text: '-- Select Name --' });
            if ($("#Language").val() == 'EN') {
                allDate2.push({ id: '0', text: '-- Select Name --' });

            }
            else {
                allDate2.push({ id: '0', text: '-- Sélectionnez le nom --' });

            }
            if (response2.length > 0) {
                for (var i = 0; i < response2.length; i++) {
                    allDate2.push({ id: response2[i].Id, text: response2[i].CommunityName });
                }
            }
            $("#ComOSDrop").html('').select2({
                data: allDate2
            });
        },
        error: function (er) {
        }
    });
}
function GetAllComHouse() {
    $.ajax({
        url: "/Home/GetAllComHouse",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response2) {
            if (response2.length > 0) {
                var allDate2 = [];
                var omObj2 = {};
                $('#ComHouseDrop').html('').select2({ data: [{ id: '', text: '' }] });
                //allDate2.push({ id: '0', text: '-- Select Name --' });
                if ($("#Language").val() == 'EN') {
                    allDate2.push({ id: '0', text: '-- Select Name --' });

                }
                else {
                    allDate2.push({ id: '0', text: '-- Sélectionnez le nom --' });

                }
                for (var i = 0; i < response2.length; i++) {
                    allDate2.push({ id: response2[i].Id, text: response2[i].CommunityName });
                }
                $("#ComHouseDrop").html('').select2({
                    data: allDate2
                });
            }
        },
        error: function (er) {
        }
    });
}
async function GetAllDiocese() {
    await $.ajax({
        url: "/Home/GetAllDiocese",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response2) {
            if (response2.length > 0) {
                var allDate2 = [];
                var omObj2 = {};
                $('#DioNames').html('').select2({ data: [{ id: '', text: '' }] });
                //allDate2.push({ id: '0', text: '-- Select Name --' });
                if ($("#Language").val() == 'EN') {
                    allDate2.push({ id: '0', text: '-- Select Name --' });

                }
                else {
                    allDate2.push({ id: '0', text: '-- Sélectionnez le nom --' });

                }
                for (var i = 0; i < response2.length; i++) {
                    allDate2.push({ id: response2[i].Id, text: response2[i].DioceseName });
                }
                $("#DioNames").html('').select2({
                    data: allDate2
                });
            }
        },
        error: function (er) {
        }
    });
}
function GetAllDisSec() {
    $.ajax({
        url: "/Home/GetAllDisSec",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response2) {
            if (response2.length > 0) {
                var allDate2 = [];
                var omObj2 = {};
                $('#DisSecDrop').html('').select2({ data: [{ id: '', text: '' }] });
                //allDate2.push({ id: '0', text: '-- Select Name --' });
                if ($("#Language").val() == 'EN') {
                    allDate2.push({ id: '0', text: '-- Select Name --' });

                }
                else {
                    allDate2.push({ id: '0', text: '-- Sélectionnez le nom --' });

                }
                for (var i = 0; i < response2.length; i++) {
                    allDate2.push({ id: response2[i].Id, text: response2[i].DistSecName });
                }
                $("#DisSecDrop").html('').select2({
                    data: allDate2
                });
            }
        },
        error: function (er) {
        }
    });
}

$("#persionNames").on("change", function () {
    var id = $("#persionNames option:selected").val();
    if (id > 0) {
        GetPersionById(id);
    } else {
        $("#memberId").val("");
    }
});
$("#DioNames").on("change", function () {
    var id = $("#DioNames option:selected").val();
    if (id != '' && id != 0) {
        GetDiocesesById(id);
    } else {
        $("#IdComOSCH").val("");
    }
});
$("#ParisDrop").on("change", function () {
    var id = $("#ParisDrop option:selected").val();
    if (id != '' && id != 0) {
        $("#Id").val(id);
    } else {
        $("#Id").val("");
    }
});
$("#ChangeProvincenDrop").on("change", function () {
    //var id = $("#ChangeProvincenDrop option:selected").val();
    //if (id != '' && id != 0) {
    //    $("#Id").val(id);
    //} else {
    //    $("#Id").val("");
    //}

    var id = $("#ChangeProvincenDrop option:selected").val();
    if (id != '' && id != 0) {
        GetProvById(id);
        $("#Id").val($("#IdCong").val());
    } else {
        $("#IdCong").val("");
    }
});
$("#InstitutionDrop").on("change", function () {
    var id = $("#InstitutionDrop option:selected").val();
    if (id != '' && id != 0) {
        $("#Id").val(id);
    } else {
        $("#Id").val("");
    }
});
$("#SocietyDrop").on("change", function () {
    var id = $("#SocietyDrop option:selected").val();
    if (id != '' && id != 0) {
        GetSocietyById(id);
    } else {
        $("#IdSocCong").val("");
    }
});
$("#CongrationDrop").on("change", function () {
    var id = $("#CongrationDrop option:selected").val();
    if (id != '' && id != 0) {
        GetCongById(id);
    } else {
        $("#IdSocCong").val("");
    }
});
$("#CongsDrop").on("change", function () {
    var id = $("#CongsDrop option:selected").val();
    if (id != '' && id != 0) {
        GetCongsById(id);
    } else {
        $("#IdCong").val("");
    }
});
$("#ProvinceDrop").on("change", function () {
    var id = $("#ProvinceDrop option:selected").val();
    if (id != '' && id != 0) {
        GetProvById(id);
    } else {
        $("#IdSocCong").val("");
    }
});
$("#ComOSDrop").on("change", function () {
    var id = $("#ComOSDrop option:selected").val();
    if (id != '' && id != 0) {
        GetComOSById(id);
    } else {
        $("#IdComOSCH").val("");
    }
});
$("#ComHouseDrop").on("change", function () {
    var id = $("#ComHouseDrop option:selected").val();
    if (id != '' && id != 0) {
        GetComHouseMyID(id);
    } else {
        $("#IdDisSec").val("");
    }
});
$("#DisSecDrop").on("change", function () {
    var id = $("#DisSecDrop option:selected").val();
    if (id != '' && id != 0) {
        GetDisSecID(id);
    } else {
        $("#IdDisSec").val("");
    }
});

function GetParisInstitutionById(id) {
    $.ajax({
        url: "/Home/GetParisInstitutionById/?id=" + id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            $("#Id").val(response.MyId);
        },
        error: function (er) {
        }
    });
}
function GetSocietyById(id) {
    $.ajax({
        url: "/Home/GetSocietyById/?id=" + id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            $("#IdSocCong").val(response.Id);
        },
        error: function (er) {
        }
    });
}
function GetCongById(id) {
    $.ajax({
        url: "/Home/GetCongById/?id=" + id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            debugger
            $("#IdSocCong").val(response.Id);
        },
        error: function (er) {
        }
    });
}
function GetCongsById(id) {
    $.ajax({
        url: "/Home/GetCongsById/?id=" + id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            //debugger
            $("#IdCong").val(response.Id);
            $("#IdCong1").val(response.CongreId);
            
        },
        error: function (er) {
        }
    });
}
function GetProvById(id) {
    $.ajax({
        url: "/Home/GetProvById/" + id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            $("#IdSocCong").val(response.MyId);
            //$("#IdCong").val(response.MyId);
        },
        error: function (er) {
        }
    });
}
function GetComOSById(id) {
    $.ajax({
        url: "/Home/GetComOSById/" + id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            $("#IdComOSCH").val(response.MyId);
        },
        error: function (er) {
        }
    });
}
function GetComHouseMyID(id) {
    $.ajax({
        url: "/Home/GetComHouseMyID/" + id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            $("#IdDisSec").val(response.MyId);
        },
        error: function (er) {
        }
    });
}
function GetDiocesesById(id) {
    $.ajax({
        url: "/Home/GetDiocesesById/" + id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            $("#IdComOSCH").val(response.DioId);
        },
        error: function (er) {
        }
    });
}
function GetDisSecID(id) {
    $.ajax({
        url: "/Home/GetDisSecID/" + id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            $("#IdDisSec").val(response.Id);
        },
        error: function (er) {
        }
    });
}

$(window).load(function () {
    var isParisCheck = $("#RdParis").prop('checked');
    //$("#InstitutionDiv").css("display", "none");
    $("#ComOSDiv").css("display", "block");
});
$("#RdParis").click(function () {
    $("#InstitutionDiv").css("display", "none");
    $("#ParisDiv").css("display", "block");
    $("#ChangeProvinceDiv").css("display", "none");

});
$("#RdInstitution").click(function () {
    $("#InstitutionDiv").css("display", "block");
    $("#ParisDiv").css("display", "none");
    $("#CongrationDiv").css("display", "none");

})
$("#RdChangeProvince").click(function () {
    $("#ChangeProvinceDiv").css("display", "block");
    $("#ParisDiv,#InstitutionDiv").css("display", "none");
})
$("#RdSociety").click(function () {
    $("#SocietyDiv").css("display", "block");
    $("#ProvinceDiv").css("display", "none");
    $("#IdSocCong").val("");
})
$("#RdCongration").click(function () {
    $("#CongDiv").css("display", "none");
    $("#IdCong").val("");
    $("#CongrationDiv").css("display", "block");
});
$("#RdCongre").click(function () {
    $("#CongDiv").css("display", "block");
    $("#CongrationDiv").css("display", "none");
    $("#IdCong").val("");
});
$("#RdProvince").click(function () {
    $("#SocietyDiv").css("display", "none");
    $("#IdCong").val("");
    $("#ProvinceDiv").css("display", "block");
});
$("#RdComOS").click(function () {
    $("#DisSecDiv").css("display", "none");
    $("#IdComOSCH").val("");
    $("#ComOSDiv").css("display", "block");
});
$("#RdComHouse").click(function () {
    $("#DisSecDiv").css("display", "none");
    $("#IdDisSec").val("");
    $("#ComHouseDiv").css("display", "block");
});
$("#RdPriMem").click(function () {
    $("#PrimeryMem").css("display", "block");
    $("#memberId").val("");
    $("#DioceseDiv").css("display", "none");
});
$("#RdDiocese").click(function () {
    $("#ComOSDiv").css("display", "none");
    $("#IdComOSCH").val("");
    $("#DioceseDiv").css("display", "block");
});
$("#RdDisSec").click(function () {
    $("#ComOSDiv").css("display", "none");
    $("#IdComOSCH").val("");
    $("#DisSecDiv").css("display", "block");
});
$("#ProvinceDrop1").on("change", function () {
    var province = $("#ProvinceDrop1 option:selected").val();
    //if (province != '' && province != 0) {Insttbl3

    GetAllPersions(province);
    //GetAllParish1(province);
    //GetAllInstitution1(province);
    GetAllSociety1(province);
    GetAllCongrations1(province);
    // GetAllCongs1(province);
    GetAllProvince11(province);
    jubliiData1(province);
    birthdayData1(province);
    //feastdayData1(province);
    //ordinationData1(province);
    eternalData1(province);
    GetDashboardbyprovince(province);
    //GetAllTotalByProvince(province);
    //} else {
    //    $("#persionNames").val(0);
    //}
});

async function GetAllPersions(province) {
    await $.ajax({
        url: "/Home/GetAllPersions?province=" + province,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            var allDate = [];
            var omObj = {};
            $('#persionNames').html('').select2({ data: [{ id: '', text: '' }] });
            //allDate.push({ id: '0', text: '-- Select Name --' });
            if ($("#Language").val() == 'EN') {
                allDate.push({ id: '0', text: '-- Select Name --' });

            }
            else {
                allDate.push({ id: '0', text: '-- Sélectionnez le nom --' });

            }
            if (response.PersonDetails.length > 0) {
                for (var i = 0; i < response.PersonDetails.length; i++) {
                    allDate.push({ id: response.PersonDetails[i].PersonalDetailsId, text: response.PersonDetails[i].Name + " " + response.PersonDetails[i].SirName });
                }
            }
            $("#persionNames").html('').select2({
                data: allDate
            });
        },
        error: function (er) {
        }
    });
}

async function GetAllPersions2() {
    await $.ajax({
        url: "/Home/GetAllPersions2/",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {

            if (response.length > 0 || response != "Fail") {
                var allDate = [];
                var omObj = {};
                $('#persionNames').html('').select2({ data: [{ id: '', text: '' }] });
                //allDate.push({ id: '0', text: '-- Select Name --' });
                if ($("#Language").val() == 'EN') {
                    allDate.push({ id: '0', text: '-- Select Name --' });

                }
                else {
                    allDate.push({ id: '0', text: '-- Sélectionnez le nom --' });

                }
                for (var i = 0; i < response.length; i++) {
                    allDate.push({ id: response[i].PersonalDetailsId, text: response[i].Name + " " + response[i].SirName });
                }
                $("#persionNames").html('').select2({
                    data: allDate
                });
            }
            else {
                window.location.href = "/Account/Login";
            }
        },

        error: function (er) {

        }
    });
}

function GetAllParish1(province) {
    $.ajax({

        url: "/Home/GetAllParish1?province=" + province,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response1) {
            var allDate1 = [];
            var omObj1 = {};
            $('#ParisDrop').html('').select2({ data: [{ id: '', text: '' }] });
            //allDate1.push({ id: '0', text: '-- Select Name --' });
            if ($("#Language").val() == 'EN') {
                allDate1.push({ id: '0', text: '-- Select Name --' });

            }
            else {
                allDate1.push({ id: '0', text: '-- Sélectionnez le nom --' });

            }
            if (response1.length > 0) {
                for (var i = 0; i < response1.length; i++) {
                    allDate1.push({ id: response1[i].MyId, text: response1[i].Name });
                }
            }
            $("#ParisDrop").html('').select2({
                data: allDate1
            });
        },
        error: function (er) {
            //alert(er);
        }
    });
}

function GetAllInstitution1(province) {
    $.ajax({
        url: "/Home/GetAllInstitution1?province=" + province,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response2) {
            //debugger;
            var allDate2 = [];
            var omObj2 = {};
            $('#InstitutionDrop').html('').select2({ data: [{ id: '', text: '' }] });
            //allDate2.push({ id: '0', text: '-- Select Name --' });
            if ($("#Language").val() == 'EN') {
                allDate2.push({ id: '0', text: '-- Select Name --' });

            }
            else {
                allDate2.push({ id: '0', text: '-- Sélectionnez le nom --' });

            }
            if (response2.length > 0) {               
                for (var i = 0; i < response2.length; i++) {
                    allDate2.push({ id: response2[i].MyId, text: response2[i].Name });
                }                
            }
            $("#InstitutionDrop").html('').select2({
                data: allDate2
            });
        },
        error: function (er) {
            //alert(er);
        }
    });
}

async function GetAllSociety1(province) {
    await $.ajax({
        url: "/Home/GetAllSociety1?province=" + province,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response2) {
            var allDate2 = [];
            var omObj2 = {};
            $('#SocietyDrop').html('').select2({ data: [{ id: '', text: '' }] });
            //allDate2.push({ id: '0', text: '-- Select Name --' });
            if ($("#Language").val() == 'EN') {
                allDate2.push({ id: '0', text: '-- Select Name --' });

            }
            else {
                allDate2.push({ id: '0', text: '-- Sélectionnez le nom --' });

            }
            if (response2.length > 0) {
                for (var i = 0; i < response2.length; i++) {
                    allDate2.push({ id: response2[i].Id, text: response2[i].NameOfTheSocity });
                }
            }
            $("#SocietyDrop").html('').select2({
                data: allDate2
            });
        },
        error: function (er) {
            //alert(er);
        }
    });
}

async function GetAllCongrations1(province) {
    await $.ajax({
        url: "/Home/GetAllCongrations1?province=" + province,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response2) {
            var allDate2 = [];
            var omObj2 = {};
            $('#CongrationDrop').html('').select2({ data: [{ id: '', text: '' }] });
            //allDate2.push({ id: '0', text: '-- Select Name --' });
            if ($("#Language").val() == 'EN') {
                allDate2.push({ id: '0', text: '-- Select Name --' });
            }
            else {
                allDate2.push({ id: '0', text: '-- Sélectionnez le nom --' });
            }
            if (response2.length > 0) {
                for (var i = 0; i < response2.length; i++) {
                    allDate2.push({ id: response2[i].Id, text: response2[i].CongregationName });
                }
            }
            $("#CongrationDrop").html('').select2({
                data: allDate2
            });
        },
        error: function (er) {
            //alert(er);
        }
    });
}

//function GetAllCongs1(province) {
//    $.ajax({
//        url: "/Home/GetAllCongs1?province=" + province,
//        type: "GET",
//        contentType: "application/json;charset=utf-8",
//        dataType: "json",
//        success: function (response2) {
//            if (response2.length > 0) {
//                var allDate2 = [];
//                var omObj2 = {};
//                $('#CongsDrop').html('').select2({ data: [{ id: '', text: '' }] });
//                allDate2.push({ id: '0', text: '-- Select Name --' });
//                for (var i = 0; i < response2.length; i++) {
//                    allDate2.push({ id: response2[i].Id, text: response2[i].CongregationName });
//                }
//                $("#CongsDrop").html('').select2({
//                    data: allDate2
//                });
//            }
//        },
//        error: function (er) {
//            //alert(er);
//        }
//    });
//}

async function GetAllProvince11(province) {
    await $.ajax({
        url: "/Home/GetAllProvince11?province=" + province,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response2) {
            var allDate2 = [];
            var omObj2 = {};
            $('#ProvinceDrop').html('').select2({ data: [{ id: '', text: '' }] });
            //allDate2.push({ id: '0', text: '-- Select Name --' });
            if ($("#Language").val() == 'EN') {
                allDate2.push({ id: '0', text: '-- Select Name --' });

            }
            else {
                allDate2.push({ id: '0', text: '-- Sélectionnez le nom --' });

            }
            if (response2.length > 0) {
                for (var i = 0; i < response2.length; i++) {
                    allDate2.push({ id: response2[i].Id, text: response2[i].ProvinceName + " " + response2[i].Place });
                }
            }
            $("#ProvinceDrop").html('').select2({
                data: allDate2
            });
        },
        error: function (er) {
        }
    });
}

async function jubliiData1(province) {
    await $.ajax({
        url: "/Home/jubliiData1?province=" + province,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (jubilidata) {
            var html = "";
            if (jubilidata != null) {
                //debugger;                
                jubilidata.forEach(function (user) {
                    //debugger;
                    var src = '';
                    if (user.UploadPhoto == '' || user.UploadPhoto == undefined || user.UploadPhoto == null) {
                        src = '/Image/Logo/NoImage.jpg';
                    }
                    else {
                        src = "/Image/Primarydetails/" + user.UploadPhoto;
                    }
                    //debugger;
                    html += "<div class='col-sm-12'>";
                    html += "<div class='col-sm-5'>";
                    html += "<img class='zoom' src='" + src + "' style='height:35px; width:35px;'>" + "<span  style='margin-left:10px'>" + user.Name + "</span>";
                    html += "</div>";

                    html += "<div class='col-sm-4'>";
                    html += "<p>" + user.JubliiType + "</p>";
                    html += "</div>";

                    html += "<div class='col-sm-3'>";
                    html += "<p>" + user.Date + "</p>";
                    html += "</div>";
                    html += "</div class='col-sm-12'>";

                });
            }
            $('#JubileeData').html(html);
        },
        error: function (er) {
        }
    });
}

async function birthdayData1(province) {
    await $.ajax({
        url: "/Home/birthdayData1?province=" + province,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (birthdayData) {
            var html = "";
            if (birthdayData != null) {
                birthdayData.forEach(function (user) {
                    var src = '';
                    if (user.UploadPhoto == '' || user.UploadPhoto == undefined || user.UploadPhoto == null) {
                        src = '/Image/Logo/NoImage.jpg';
                    }
                    else {
                        src = "/Image/Primarydetails/" + user.UploadPhoto;
                    }
                    var row = "<div align='left'><img class='zoom' src='" + src + "' style='height:35px; width:35px;'>" + "<span style='margin-left:10px'>" + user.Name + "</span>" + "</div>";
                    html = html + row;
                });
            }
            $('#birthdayData').html(html);
        },
        error: function (er) {
        }
    });
}

function feastdayData1(province) {
    $.ajax({
        url: "/Home/feastdayData1?province=" + province,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (feastdayData) {
            var html = "";
            if (feastdayData != null) {
                //debugger;                

                feastdayData.forEach(function (user) {
                    html = html + "<p>" + user.Name + "</p>";

                });                
            }
            $('#feastdayData').html(html);
        },
        error: function (er) {
        }
    });
}

function ordinationData1(province) {
    $.ajax({
        url: "/Home/ordinationData1?province=" + province,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (ordinationData) {
            var html = "";
            if (ordinationData != null) {
                //debugger;               

                ordinationData.forEach(function (user) {
                    html = html + "<p>" + user.Name + "</p>";

                });               
            }
            $('#ordinationData').html(html);
        },
        error: function (er) {
        }
    });
}

async function eternalData1(province) {
    await $.ajax({
        url: "/Home/eternalData1?province=" + province,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (eternalData) {
            var html = "";
            if (eternalData != null) {
                //debugger;                

                eternalData.forEach(function (user) {
                    var src = '';
                    if (user.UploadPhoto == '' || user.UploadPhoto == undefined || user.UploadPhoto == null) {
                        src = '/Image/Logo/NoImage.jpg';
                    }
                    else {
                        src = "/Image/Primarydetails/" + user.UploadPhoto;
                    }
                    html = html + "<div align='left'><img class='zoom' src='" + src + "' style='height:35px; width:35px;'><span style='margin-left:10px'>" + user.Name + "</span>";

                });
            }
            $('#eternalData').html(html);
        },
        error: function (er) {
        }
    });
}

function GetAllTotalByProvince(province) {
    $.ajax({
        url: "/Home/GetTotalCountByProvince?province=" + province,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (eternalData) {
            //debugger;
            $("#TotalMember1").html(eternalData.TotalMember);
            $("#TotalInstitution").html(eternalData.TotalIns);
            $("#TotalOrdination").html(eternalData.AllPerpetualProfession);
            $("#TotalCong").html(eternalData.TotalSoc);
            $("#TotalRetirement").html(eternalData.TotalRet);
            $("#TotalCommunity").html(eternalData.TotalCom);
            $("#TotalDiedMember").html(eternalData.DepartedRecord);
            $("#TotalParish").html(eternalData.TotalTrust);
            $("#TotalDepart").html(eternalData.AllDeparted);
            $("#TotalDeath1").html(eternalData.DepartedRecord);
            $("#TotalNovandPP1").html(eternalData.TotalNovandPP);
            $("#TotalArchive").html(eternalData.TotalArchive);
            $("#TotalVowsRenewal").html(eternalData.TotalVowsRenewal);
            $("#TotalEnterToNov1").html(eternalData.TotalEnterToNov);
        },
        error: function (er) {
        }
    });

}


async function GetDashboardbyprovince(province) {
    await $.ajax({
        url: "/home/GetDashBoardbyProvince?province=" + province,
        type: "POST",
        dataType:"json",
        contentType: "application/json;charset=utf-8",
        success: function (response) {      
            $("#h4allMemberCount").text(response.AllMembersCount);
            $("#h4AllInstCount").text(response.AllInstituteCount);
            $("#h4TotalEnterToNov1").text(response.AllEnterToNov);
            //$("#h4TotalEnterToNov1").text(response.AllCongCount);
            $("#h4AllCommunityCount").text(response.AllCommunityCount);
            $("#h4AllNovandPPCount").text(response.AllNovandPPCount);
            $("#spAllPerpetualProfession").text(response.AllPerpetualProfession);
            $("#h4allDio").text(response.allDio);
            $("#spAllDiaconate").text(response.AllDiaconate);
            $("#spAllDeathRecordCount").text(response.AllDeathRecordCount);
            $("#h4AllDepartCount").text(response.AllDepartCount);
            $("#spAllOrdinations").text(response.AllOrdinations);
            $("#h4AllCongCount").text(response.LegalReg);
        },
        error: function (er) {
            alert(er.responseText);
        }
        

    });
}

//$("#ProvinceDrop1").change(function () {

//    $.ajax({
//        url: "/home/GetDashBoardbyProvince",
//        type: "POST",
//        data: {
//            province:$(this).val()
//        },
//        success: function (response)
//        {
//            //alert(response.AllEnterToNov);
//            $("#h4allMemberCount").text(response.AllMembersCount);
//            $("#h4AllInstCount").text(response.AllInstituteCount);
//            $("#h4TotalEnterToNov1").text(response.AllEnterToNov);
//            $("#h4TotalEnterToNov1").text(response.AllCongCount);
//            $("#h4AllCommunityCount").text(response.AllCommunityCount);
//            $("#h4AllNovandPPCount").text(response.AllNovandPPCount);
//            $("#spAllPerpetualProfession").text(response.AllPerpetualProfession);
//            $("#h4allDio").text(response.allDio);
//            $("#spAllDiaconate").text(response.AllDiaconate);
//            $("#spAllDeathRecordCount").text(response.AllDeathRecordCount);
//            $("#h4AllDepartCount").text(response.AllDepartCount);
//            $("#spAllOrdinations").text(response.AllOrdinations);
//            $("#h4AllCongCount").text(response.LegalReg);
//        }

//    });


//});