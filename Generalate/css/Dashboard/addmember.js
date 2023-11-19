$(document).on('click', '#btnClear', function () {
    $("#btnAddPrimary").css("display", "block");
    clearall();
    
});
//insurance
$(document).on('click', '#btnClear', function () {
    $("#btnAddinsurance").css("display", "block");
    clearall();

});

//Add Data Function
function Add() {
    var datenow = new Date();
    var AddMember =
    {
        Name: $('#PName').text(),
        SirName: $('#PSirName').text(),
        MemberId: $('#PMemberId').text(),
        Knowname: $('#know').val(),
        Baptismialname: $('#baptisimial').val()
    }

    $.ajax({
        url: "/Member/AddPrimaryDetails",
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        data: JSON.stringify(AddMember),
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
function clearall() {
    $('#Primaryid').val("");
    $('#MemberId').val("");
    $("#Knowname").val("");
    $('#Baptismialname').val("");
    $('#Nationality').val("");
    $('#Congregation').val("");
    $('#Country').val("");
    $('#DOB').val("");
    $('#DOB1').val("");
    $('#Feastday').val("");
    $('#Bloodgroup').val("");
    $('#emailid').val("");
    $('#mobilenumber').val("");
    $('#whatsappnumber').val("");
    $('#facebookid').val("");
    $('#twitterid').val("");
    $('#blog').val("");
    $('#house').val("");
    $('#city').val(""),
        $('#district').val("");
    $('#state').val("");
    $('#pin').val("");
    $('#adhar').val("");
    $('#nameonadhar').val("");
    $('#passport').val("");
    $('#nameonpassport').val("");
    $('#pan').val("");
    $('#nameonpan').val("");
    $('#nop').val("");
}

////Primary Details Page
$(".btnPrimaryEdit").on('click', function () {
    $('#PrimaryForm').attr('action', '/Member/UpdatePrimaryDetails');
    var id = $(this).attr("data-val");
    GetPrimaryDetailById(id);
    $(".panel-body").scrollTop(0);
});
function GetPrimaryDetailById(id) {
    //debugger;
    $.ajax({
        url: "/Member/GetPrimaryDetailById/" + id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            EnableDataFields();
            if (result != null) {
                clearall();
                //debugger;
                $('#Primaryid').val(result.Primaryid);
                $('#MemberId').val(result.MemberId);
                $("#Knowname").val(result.Knowname);
                $('#Baptismialname').val(result.Baptismialname);
                $('#DOB').val(result.DOB);
                $('#DOB1').val(result.DOB1);
                $('#DOBInTheCertificate').val(result.DOBInTheCertificate);
                $('#Feastday').val(result.Feastday);
                $('#Bloodgroup').val(result.Bloodgroup).trigger('change');
                $('#emailid').val(result.emailid);
                $('#mobilenumber').val(result.mobilenumber);
                $('#whatsappnumber').val(result.whatsappnumber);
                $('#facebookid').val(result.facebookid);
                $('#twitterid').val(result.twitterid);
                $('#blog').val(result.blog);
                $('#Telephone').val(result.Telephone);
                $('#NameInTheCertificate').val(result.NameInTheCertificate);
                $('#house').val(result.house);
                $('#city').val(result.city);
                $('#district').val(result.district);
                $('#MemmAddress').val(result.Address);
                $('#state').val(result.state);
                $('#pin').val(result.pin);
                $('#adhar').val(result.adhar);
                $('#nameonadhar').val(result.nameonadhar);
                $('#passport').val(result.passport);
                $('#nameonpassport').val(result.nameonpassport);
                $('#pan').val(result.pan);
                $('#nameonpan').val(result.nameonpan);
                $('#Ordination').val(result.Ordination);
                $('#nop').val(result.nop);
                $('#VoterIDaddress').val(result.VoterIDaddress);
                // alert(result.country)
               // $('#Country').val(result.country);
                $('#Congregation').val(result.Congregation);
                $('#Nationality').val(result.Nationality);
                $('#DrivingLicenseNumber').val(result.DrivingLicenseNumber);
                $('#placeofbirth').val(result.placeofbirth);
                $('#homeparish').val(result.homeparish);
                $('#homediocese').val(result.homediocese);
                $('#mothertounge').val(result.mothertounge);
                $('#nop').val(result.nop);
                $('#UploadPhotoShow').text(result.UploadPhoto);
                $('#File3Show').text(result.File3);
                $('#File2Show').text(result.File2);
                $('#File1Show').text(result.File1);
                $('#DrivingLicence').text(result.DrivingLicence);
                $('#Baptismialname').val(result.Baptismialname);
                $('#noofbrother').val(result.noofbrother);
                $('#noofsisters').val(result.noofsisters);
                $('#placeinfamily').val(result.placeinfamily);
                $('#OtherName').val(result.OtherName);
                $('#FathersBaptismialName').val(result.FathersBaptismialName);
                $('#FatherName').val(result.FatherName);
                $('#MotherName').val(result.MotherName);
                $('#MothersBaptismialName').val(result.MothersBaptismialName);
                $('#Paris').val(result.Paris);
                $('#Diocese').val(result.Diocese);
                $('#Pincode').val(result.Pincode);
                $('#SurName').val(result.SurName);
                $('#ProvinceName').val(result.ProvinceName);
                $('#Congregation').val(result.Congregation);
                $('#CountryName12').val(result.country);
                if (result.Will == "yes") {
                    $("#RDWillYes").prop("checked", true);
                } else {
                    $("#RDWillNo").prop("checked", true);
                }
                $('#Country option[value="' + result.country + '"]').attr("selected", "selected");

              //  $('#Country option[value="' + result.Continent + '"]').attr("selected", "selected");
              //  $('#Country').val(result.Continent).change();

                $('#Continent').val(result.Continent);
               // $('#Country').val(result.country);

               // alert(result.country)
                var value = result.LangSpocken;
                if (value != null || value != undefined) {
                    var valuedata = result.LangSpocken.split(",");
                    $('#LangSpocken').multipleSelect('setSelects', valuedata);
                }
                $("#btnAddPrimary").text("Update");
                $("#btnAddPrimary").css("display", "block");

                $("#btnAddPrimary").val("Update");
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Scrament code

$(document.body).on('click', '.ScramentEdit', function () {
    $(".commonGrid").hide();
    $(".membrDetails").show();
    $('#ScramentForm').attr('action', '/Member/UpdateScrament');
    var id = $(this).attr("data-val");
    $("#btnSaveScrament").text("Update");
    $(".panel-body").scrollTop(0);
    GetAllScramentById(id);
});
function GetAllScramentById(id) {
    $.ajax({
        url: "/Member/GetScrament?id=" + id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result != null) {
                //debugger;
                $('#ScramentMemberId').val(result.MemberId);
                $("#ScramentTitle1").val(result.Title);
                $("#ScramentSacrament").val(result.Sacrament);
                $("#ScramentMinister1").val(result.Minister);
                $("#ScramentDate").val(result.Date);
                $("#ScramentChurchName").val(result.ChurchName);
                $("#ScramentRemarks1").val(result.Remarks);
                $("#ScramentId").val(result.Id);
                $("#ConfirmationDate").val(result.ConfirmationDate);

                $('#DioceseNameSacra option[value="' + result.Diocese + '"]').attr("selected", "selected");
                $('#DioceseNameSacra').val(result.Diocese).change();

                $("#DioceseNameSacra").val(result.Diocese);
                $('#ProvinceName').val(result.ProvinceName);
                if (result.File != null) {
                    $("#sacrementfile").text(result.File);
                }
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
$(document.body).on('click', '.ScramentDelete', function () {

    var id = $(this).attr("data-val");
    if (confirm("Do you want to delete ?")) {
        window.location.href = "/Member/DeleteScrament?id=" + id;
    }
});

//Sepration

$(document.body).on('click', '.btnSeprationEdit', function () {
    $(".commonGrid").hide();
    $(".membrDetails").show();
    $('#SeprationForm').attr('action', '/Member/SeprationUpdate');
    var sepID = $(this).attr("data-val");
    $("#btnSaveSepration").text("Update");
    $(".panel-body").scrollTop(0);
    GetSeprationById(sepID);
});
function GetSeprationById(sepID) {
    $.ajax({
        url: "/Member/GetSeprationById?Id=" + sepID,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result != null) {
                //debugger;
                $("#SeprationMemberID").val(result.MemberID);
                $("#SeperationId").val(result.SeperationId);
                $("#StageOFFormation").val(result.StageOFFormation);
                $("#SepTitle").val(result.Title);
                $("#SeperationDate").val(result.SeperationDate);
                $("#SeperationAge").val(result.SeperationAge);
                $("#SapDescribtion").val(result.Describtion);
                $("#ActiveCheck1").val(result.Sapcheck);
                $("#sepFile").text(result.File);
                $("#ProvinceName").val(result.ProvinceName);
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function EnableDataFields()
{
    $("#Baptismialname").attr("readonly", false);
    $("#Congregation").attr("readonly", false);
    $("#placeofbirth").attr("readonly", false);
    $("#Continent").attr("readonly", false);
    $("#DOB").attr("readonly", false);
    $("#DOBInTheCertificate").attr("readonly", false);
    $("#placeinfamily").attr("readonly", false);
    $("#NameInTheCertificate").attr("readonly", false);
    $("#emailid").attr("readonly", false);
    $("#Nationality").attr("readonly", false);
    $("#mobilenumber").attr("readonly", false);
    $("#noofbrother").attr("readonly", false);
    $("#city").attr("readonly", false);
    $("#district").attr("readonly", false);
    $("#state").attr("readonly", false);
    $("#MemmAddress").attr("readonly", false);
    $("#noofsisters").attr("readonly", false);
    $("#homeparish").attr("readonly", false);
    $("#homediocese").attr("readonly", false);
    $("#pin").attr("readonly", false);
    $("#Country").attr("disabled", false);
    $("#UploadPhoto").attr("disabled", false);
    $("#RDWillYes").attr("disabled", false);
    $("#RDWillNo").attr("disabled", false);
    $("#Bloodgroup").attr("disabled", false);
}

