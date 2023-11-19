$(document).ready(function () {
    GetAllPersions();
    GetAllParis();
    GetAllInstitution();
    GetAllSociety();
    GetAllCongrations();

});
$("#persionNames").on("change", function () {
    var id = $("#persionNames option:selected").val();
    if (id > 0) {
        GetPersionById(id);
    } else {
        //$("#sirName").val("");
        $("#memberId").val("");
    }
});

$("#btnSubmit").on("click", function () {

    var persionId = $("#persionNames option:selected").val();
    var radioBtn = $("input[name='radioBtn']:checked").val();
    if (radioBtn == "M") {
        if (persionId !== "0") {
            window.location.href = "/EntryLife/Details?persionId=" + persionId;
        }
    } else {
        var memberId = $("#memberId").val();
        if (persionId !== "0") {
            window.location.href = "/Member/MemberInfoById" + "?memberId=" + memberId + "&Name=" + '' + "&SirName=" + '';
        }
    }
});

$("#btnSubmit1").on("click", function () {
    var parisChk = $("#ParisDrop option:selected").val();
    var InstitutionChk = $("#InstitutionDrop option:selected").val();

    var parisChkName = $("#ParisDrop option:selected").text();
    var InstitutionChkName = $("#InstitutionDrop option:selected").text();

    var Id = $("#Id").val();

    var radioBtn = $("input[name='radioBtn1']:checked").val();
    if (radioBtn == "Paris") {
        if (parisChk !== "0") {
            window.location.href = "/Paris/ParisList/?id=" + Id + "&&name=" + parisChkName;
        }
    } else {
        if (InstitutionChk !== "0") {
            window.location.href = "/IdGenerate/IdGenerator/?id=" + Id + "&&name=" + InstitutionChkName;
        }
    }

});
$("#btnSocCong").on("click", function () {
    debugger
    var sociertyDrop = $("#SocietyDrop option:selected").val();
    var CongDrop = $("#CongrationDrop option:selected").val();

    var Id = $("#IdSocCong").val();
    var radioBtn = $("input[name='radioBtn3']:checked").val();
    if (radioBtn == "Society") {
        if (sociertyDrop !== "0") {
            window.location.href = "/Home/SociertDetails?id=" + Id;
        } else {
            alert("Please Select Society");
        }
    } else {
        if (CongDrop !== "0") {
            window.location.href = "/Home/CongDetail?id=" + Id;
        } else {
            alert("Please Select Congration");
        }
    }
});


function GetAllPersions() {
    $.ajax({
        url: "/Home/GetAllPersions",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.length > 0) {
                var allDate = [];
                var omObj = {};
                $('#persionNames').html('').select2({ data: [{ id: '', text: '' }] });
                allDate.push({ id: '0', text: '-- Select Name --' });
                for (var i = 0; i < response.length; i++) {
                    allDate.push({ id: response[i].PersonalDetailsId, text: response[i].Name + " " + response[i].SirName });
                }
                $("#persionNames").html('').select2({
                    data: allDate
                });
            }
        },
        error: function (er) {
            //alert(er);
        }
    });
}
function GetPersionById(id) {
    $.ajax({
        url: "/Home/GetPersionDetailbyId/" + id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            //$("#sirName").val(response.SirName);
            $("#memberId").val(response.MemberID);
        },
        error: function (er) {
            //alert(er);
        }
    });
}
//Get all Paris list for the dropdown
function GetAllParis() {
    $.ajax({
        url: "/IdGenerate/GetAllParisInstitution?Type=Paris",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response1) {
            if (response1.length > 0) {
                var allDate1 = [];
                var omObj1 = {};
                $('#ParisDrop').html('').select2({ data: [{ id: '', text: '' }] });
                allDate1.push({ id: '0', text: '-- Select Name --' });
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
//Get all Institution List for the institution Dropdown
function GetAllInstitution() {
    $.ajax({
        url: "/IdGenerate/GetAllParisInstitution?Type=Institution",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response2) {
            if (response2.length > 0) {
                var allDate2 = [];
                var omObj2 = {};
                $('#InstitutionDrop').html('').select2({ data: [{ id: '', text: '' }] });
                allDate2.push({ id: '0', text: '-- Select Name --' });
                for (var i = 0; i < response2.length; i++) {
                    allDate2.push({ id: response2[i].MyId, text: response2[i].Name });
                }
                $("#InstitutionDrop").html('').select2({
                    data: allDate2
                });
            }
        },
        error: function (er) {
            //alert(er);
        }
    });
}

function GetAllSociety() {
    $.ajax({
        url: "/Home/GetAllSociety",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response2) {
            if (response2.length > 0) {
                var allDate2 = [];
                var omObj2 = {};
                $('#SocietyDrop').html('').select2({ data: [{ id: '', text: '' }] });
                allDate2.push({ id: '0', text: '-- Select Name --' });
                for (var i = 0; i < response2.length; i++) {
                    allDate2.push({ id: response2[i].Id, text: response2[i].NameOfTheSocity });
                }
                $("#SocietyDrop").html('').select2({
                    data: allDate2
                });
            }
        },
        error: function (er) {
            //alert(er);
        }
    });
}

function GetAllCongrations() {
    $.ajax({
        url: "/Home/GetAllCongrations",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response2) {
            if (response2.length > 0) {
                var allDate2 = [];
                var omObj2 = {};
                $('#CongrationDrop').html('').select2({ data: [{ id: '', text: '' }] });
                allDate2.push({ id: '0', text: '-- Select Name --' });
                for (var i = 0; i < response2.length; i++) {
                    allDate2.push({ id: response2[i].Id, text: response2[i].CongregationName });
                }
                $("#CongrationDrop").html('').select2({
                    data: allDate2
                });
            }
        },
        error: function (er) {
            //alert(er);
        }
    });
}

$("#ParisDrop").on("change", function () {
    var id = $("#ParisDrop option:selected").val();
    if (id != '' && id != 0) {
        GetParisInstitutionById(id);
    } else {
        //$("#sirName").val("");
        $("#Id").val("");
    }
});

$("#InstitutionDrop").on("change", function () {
  //debugger;
    var id = $("#InstitutionDrop option:selected").val();
    if (id != '' && id != 0) {
        GetParisInstitutionById(id);
    } else {
        //$("#sirName").val("");
        $("#Id").val("");
    }
});

$("#SocietyDrop").on("change", function () {
    var id = $("#SocietyDrop option:selected").val();
    if (id != '' && id != 0) {
        GetSocietyById(id);
    } else {
        //$("#sirName").val("");
        $("#IdSocCong").val("");
    }
});

$("#CongrationDrop").on("change", function () {
    var id = $("#CongrationDrop option:selected").val();
    if (id != '' && id != 0) {
        GetCongById(id);
    } else {
        //$("#sirName").val("");
        $("#IdSocCong").val("");
    }
});
function GetParisInstitutionById(id) {
    $.ajax({
        url: "/IdGenerate/GetParisInstitutionById/?id=" + id,
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
            //$("#sirName").val(response.SirName);
            $("#IdSocCong").val(response.Id);
        },
        error: function (er) {
            //alert(er);
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
            //alert(er);
        }
    });
}

$(window).load(function () {
  
    $("#InstitutionDiv").css("display", "none");
});

$("#RdParis").click(function () {
    $("#InstitutionDiv").css("display", "none");
    $("#ParisDiv").css("display", "block");

})

$("#RdInstitution").click(function () {
    $("#InstitutionDiv").css("display", "block");
    $("#ParisDiv").css("display", "none");

})


$("#RdSociety").click(function () {
    $("#SocietyDiv").css("display", "block");
    $("#CongrationDiv").css("display", "none");
    $("#IdSocCong").val("");
})

$("#RdCongration").click(function () {
    $("#SocietyDiv").css("display", "none");
    $("#IdSocCong").val("");
    $("#CongrationDiv").css("display", "block");

})
