$(document).ready(function () {
    $("#MemberDetailsDiv").css("display", "none");
    $("#PersionalDetailsDiv").css("display", "none");
    $("#InstitutionDetailsDiv").css("display", "none");
    $("#UnderAgesDiv").css("display", "none");
    $("#DeathDiv").css("display", "none");
    $("#BirthDiv").css("display", "none");
    $("#FeastDiv").css("display", "none");
    $("#ChronologicalDiv").css("display", "none");
})

$(document).ready(function () {
    GetAllPersions123();
    GetAllProvince();
    GetAllDesignationandInstitution();
    BindDrpInstitution1();
})

$(window).load(function () {
    OpenMemberReport();
});
function BindDrpInstitution1() {
    $.ajax({
        url: "/Member/BindDrpInstitution1",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.length > 0) {
                var allInstitutionDate = [];
                var omObj = {};
                $('#AllInstitutions').html('').select2({ data: [{ id: '', text: '' }] });
                allInstitutionDate.push({ id: '0', text: '@{ @HomeController.GetControlTextByControlId("Select-Name") ;}' });
                for (var i = 0; i < response.length; i++) {
                    allInstitutionDate.push({ id: response[i].Name, text: response[i].Name });
                }
                $("#AllInstitutions").html('').select2({
                    data: allInstitutionDate
                });
            }
        },
        error: function (er) {
        }
    });
}
function GetAllPersions123() {
    $.ajax({
        url: "/Member/GetAllPersions123",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",

        success: function (response) {
            //debugger;
            if (response.length > 0) {
                var allData = [];
                var omObj2 = {};
                $('#AllMembers').html('').select2({ data: [{ id: '', text: '', text: '' }] }); //select Name
                allData.push({ id: '0', text: '' });
                for (var i = 0; i < response.length; i++) {
                    allData.push({ id: response[i].MemberID, text: response[i].Name + " " + response[i].SirName });
                }
                $("#AllMembers").html('').select2({
                    data: allData
                });
            }
        },
        error: function (er) {
            //alert(er);
        }
    });
}
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
                $('#ProvinceDrop').html('').select2({ data: [{ id: '', text: '' }] });
                allDate2.push({ id: '0', text: '' }); // Select name
                for (var i = 0; i < response2.length; i++) {
                    allDate2.push({ id: response2[i].Id, text: response2[i].ProvinceName + " " + response2[i].Place });
                }
                $("#ProvinceDrop").html('').select2({
                    data: allDate2
                });
            }
        },
        error: function (er) {
            //alert(er);
        }
    });
}

$("#ProvinceDrop").on("change", function () {
    var province = $("#ProvinceDrop option:selected").val();
    if (province != '' && province != 0) {
        GetAllPersions1(province);
        BindDrpInstitution(province);
    }
});
function GetAllDesignationandInstitution() {
    $.ajax({
        url: "/Member/GetAllDesignationandInstitution",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.length > 0) {
                var allDesignationDate = [];
                var omObj = {};
                $('#AllDesignations').html('').select2({ data: [{ id: '', text: '' }] });
                allDesignationDate.push({ id: '0', text: '-- Select Name --' });
                for (var i = 0; i < response.length; i++) {
                    allDesignationDate.push({ id: response[i].Id, text: response[i].Name });
                }
                $("#AllDesignations").html('').select2({
                    data: allDesignationDate
                });
            }
        },
        error: function (er) {
        }
    });
}
function BindDrpInstitution(province) {
    $.ajax({
        url: "/Member/BindDrpInstitution?province=" + province,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.length > 0) {
                var allInstitutionDate = [];
                var omObj = {};
                $('#AllInstitutions').html('').select2({ data: [{ id: '', text: '' }] });
                allInstitutionDate.push({ id: '0', text: '-- Select Name --' });
                for (var i = 0; i < response.length; i++) {
                    allInstitutionDate.push({ id: response[i].Name, text: response[i].Name });
                }
                $("#AllInstitutions").html('').select2({
                    data: allInstitutionDate
                });
            }
        },
        error: function (er) {
        }
    });
}

function GetAllPersions1(province) {
    $.ajax({
        url: "/Member/GetAllPersions1?province=" + province,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            var allDate = [];
            if (response.length > 0) {
                var omObj = {};
                $('#AllMembers').html('').select2({ data: [{ id: '', text: '' }] });
                allDate.push({ id: '0', text: '-- Select Name --' });
                for (var i = 0; i < response.length; i++) {
                    allDate.push({ id: response[i].MemberID, text: response[i].Name + " " + response[i].SirName });
                }
            }
            $("#AllMembers").html('').select2({
                data: allDate
            });
        },
        error: function (er) {
        }
    });
}
$("#btnSearchMember").on("click", function () {
    var memberId = $("#AllMembers option:selected").val();
    if (memberId == "0") {
        $("#PersionalDetailsDiv").css("display", "none");
        alert("Please Select any Member");
        return false;
    }
    var name = $("#AllMembers option:selected").text();
    if (name == "0") {
        $("#PersionalDetailsDiv").css("display", "none");
        alert("Please Select any Member");
        return false;
    }
    $("#RadioBtnReport1").hide();
    $("#RadioBtnReport2").hide();
    $("#RadioBtnReport3").hide();
    $("#RadioBtnReport4").hide();
    $("#RadioBtnReport5").hide();
    $("#RadioBtnReport6").hide();
    $("#RadioBtnReport7").hide();
    $("#RadioBtnReport8").hide();
    $("#RadioBtnReport9").hide();
    $("#RadioBtnReport10").hide();
    $("#RadioBtnReport11").hide();
    $("#RadioBtnReport12").hide();
    $("#RadioBtnReport13").hide();
    $("#RadioBtnReport14").hide();
    $("#RadioBtnReport15").hide();
    $("#RadioBtnReport16").hide();
    $("#RadioBtnReport17").hide();
    $("#RadioBtnReport18").hide();
    $("#RadioBtnReport19").hide();
    $("#Professiontbl").hide();
    $("#RadioBtnReport").css("display", "none");
    $("#RadioBtnReport1").css("display", "none");
    $("#PersionalDetailsDiv").css("display", "block");
    GetPersionById(memberId);
    GetAllRetirementById(memberId);
    GetAllProfessionById(memberId);
    GetAllClustrationById(memberId);
    GetAllFamilyById(memberId);
    GetAllFormationById(memberId);
    GetAllVowsById(name);
    GetAllOffDocById(memberId)
    GetAllAcademyById(memberId);
    GetAllAppinmentById(memberId);
    GetAllHealthById(memberId);
    GetAllPassedById(memberId);
    GetAllInsuranceById(memberId);
    GetAllSaprationById(memberId);

    GetAllSacramentdataById(memberId);
    GetAllInstitutionAppinmentById(memberId);
    GetHomeVisit(memberId);
    GetExclaustration(memberId);

    $("#Professiontbl").hide(); $("#Professiontbl1").hide();
    $("#TblAppointment").hide(); $("#AppointmentDiv").hide();
    $("#TblAppointmentInst").hide(); $("#AppointmentIns").hide();

});

function checkNullValue(val) {
    return val == null ? "" : val;
}

function checkzero(val) {
    return val == "--Select--" ? "" : val;
}

function GetPersionById(id) {
    $.ajax({
        url: "/Member/GetPrimaryById?id=" + id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (persondata) {

            clearAll();
            if (persondata.PrsnDetails.Spare1 == null || persondata.PrsnDetails.Spare1 == undefined) {
                $("#uploadimage").attr("src", "/Image/Logo/NoImage.jpg");
            }
            else {
                $("#uploadimage").attr("src", "/Image/Primarydetails/" + persondata.PrsnDetails.Spare1);

            }

            $("#PersonKnowName").text(checkNullValue(persondata.PrsnDetails.Name));
            $("#SirName").text(checkNullValue(persondata.PrsnDetails.SirName));
            $("#Congregation1").text(checkNullValue(persondata.PersonPrimaryDetails.Congregation));
            $("#PersonMotherTongue").text(checkNullValue(persondata.PersonPrimaryDetails.mothertounge));
            $("#PersonDiocese").text(checkNullValue(persondata.PersonPrimaryDetails.homediocese));
            $("#PersonParish").text(checkNullValue(persondata.PersonPrimaryDetails.homeparish));
            $("#PersonDOBInCertificate").text(checkNullValue(persondata.PersonPrimaryDetails.DOBInTheCertificate));
            $("#PersonNameInTheCertificate").text(checkNullValue(persondata.PersonPrimaryDetails.NameInTheCertificate));
            $("#PersonPlaceInFamily").text(checkNullValue(persondata.PersonPrimaryDetails.placeinfamily));
            $("#PersonWill").text(checkNullValue(persondata.PersonPrimaryDetails.Will));
            $("#personAddress").text(checkNullValue(persondata.PersonPrimaryDetails.Address));
            $("#personBaptismalName").text(checkNullValue(persondata.PersonPrimaryDetails.Baptismialname));
            $("#PersonDateofBirthBaptism").text(checkNullValue(persondata.PersonPrimaryDetails.DOB));
            $("#PersonDateofBirthSSLC").text(checkNullValue(persondata.PersonPrimaryDetails.placeofbirth));
            $("#PersonFeastDay").text(checkNullValue(persondata.PersonPrimaryDetails.Feastday));
            $("#PersonBloodGroup").text(checkNullValue(persondata.PersonPrimaryDetails.Bloodgroup));
            $("#PersonEmailID").text(checkNullValue(persondata.PersonPrimaryDetails.emailid));
            $("#PersonMobileNumber").text(checkNullValue(persondata.PersonPrimaryDetails.mobilenumber));
            $("#Persohomeparish").text(checkNullValue(persondata.PersonPrimaryDetails.homeparish));
            $("#PersoFileId").text(checkNullValue(persondata.PrsnDetails.FileNo));
            $("#Persohomediocese").text(checkNullValue(persondata.PersonPrimaryDetails.homediocese));
            $("#PersionReligious").text(checkNullValue(persondata.PersonPrimaryDetails.placeinfamily));
            $("#Personnoofsisters").text(checkNullValue(persondata.PersonPrimaryDetails.noofsisters));
            $("#Personnoofbrother").text(checkNullValue(persondata.PersonPrimaryDetails.noofbrother));
            $("#Personmothertongue").text(checkNullValue(persondata.PersonPrimaryDetails.mothertounge));

            $("#PersoHouseAdd").text(checkNullValue(persondata.PersonPrimaryDetails.house));
            $("#personCity").text(checkNullValue(persondata.PersonPrimaryDetails.city));
            $("#personDistrict").text(checkNullValue(persondata.PersonPrimaryDetails.district));
            $("#persionState").text(checkNullValue(persondata.PersonPrimaryDetails.state));
            $("#personPincode").text(checkNullValue(persondata.PersonPrimaryDetails.Pincode));
            $("#PersonCountry").text(checkNullValue(persondata.PersonPrimaryDetails.country));
            $("#Nationality").text(checkNullValue(persondata.PersonPrimaryDetails.Nationality));
            $("#PersonContinent").text(checkNullValue(persondata.PersonPrimaryDetails.Continent));
            $("#LangSpocken").text(checkNullValue(persondata.PersonPrimaryDetails.LangSpocken));
            $("#Personcountryid").text(checkNullValue(persondata.PersonPrimaryDetails.country));

            $("#AadharNumber").text(checkNullValue(persondata.PersonPrimaryDetails.adhar));
            $("#NameasitisAadhar").text(checkNullValue(persondata.PersonPrimaryDetails.nameonadhar));
            $("#Passport").text(checkNullValue(persondata.PersonPrimaryDetails.passport));
            $("#Nameasitispassport").text(checkNullValue(persondata.PersonPrimaryDetails.nameonpassport));
            $("#PANNumber").text(checkNullValue(persondata.PersonPrimaryDetails.pan));
            $("#file1View").attr("href", "/Image/Primarydetails/" + persondata.PersonPrimaryDetails.File1);
            $("#NameasitinPAN").text(persondata.PersonPrimaryDetails.nameonpan);
            $("#file2View").attr("href", "/Image/Primarydetails/" + persondata.PersonPrimaryDetails.File2);
            $("#file3View").attr("href", "/Image/Primarydetails/" + persondata.PersonPrimaryDetails.File3);
            $("#PersonPhotoUpload1").attr("href", "/Image/Primarydetails/" + persondata.PersonPrimaryDetails.UploadPhoto);
            $("#drivinglicense").attr("href", "/Image/Primarydetails/" + persondata.PersonPrimaryDetails.DrivingLicense);

        },
        error: function (er) {
            //alert(er);
        }
    });
}
function GetAllOffDocById(id) {
    $.ajax({
        url: "/Member/GetAllOffDocById?id=" + id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (OfficialData) {
            ////clearAll();

            //$("#uploadDocument").attr("href", "/Image/OfficialDoc/" + OfficialData.uploadDocument);
            $('#tbloffdocDetails tbody').html('');

            if (OfficialData == "") {
                $("#OffDocDiv").hide();
            }
            else {
                var i = 1;
                OfficialData.forEach(function (user) {
                    var url = "";
                    var isView = "No Profile";
                    if (user.Document1 != null && user.Document1 != "") {
                        if (url = "/Image/OfficialDoc/" + user.Document1 + " ") {
                            isView = "View Document";
                        }
                    }
                    else {
                        url = "#";
                        isView = "No Profile";
                    }
                    var row = "<tr><td>" + i + "</td><td>" + checkNullValue(user.DocType1) + "</td><td>" + checkNullValue(user.NameAndNo1) + "</td><td><a target='_blank' href='" + url + "'>" + isView + "</a></</td></tr>";
                    $('#tbloffdocDetails tbody').append(row);
                    i = i + 1;
                });
            }
        },
        error: function (er) {
        }
    });
}
function GetAllFamilyById(id) {
    $.ajax({
        url: "/Member/GetAllFamilyById?id=" + id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (familydata) {
            if (familydata != "") {
                var i = 1;
                $('#tblFamilyDetails tbody').html("");
                familydata.forEach(function (user) {
                    var row = "<tr><td>" + i + "</td><td>" + checkNullValue(user.MemberName) + "</td><td>" + checkNullValue(user.Relationship) + "</td><td>" + checkNullValue(user.Mobile) + "</td><td>" + checkNullValue(user.Email) + "</td><td>" + checkNullValue(user.Address) + "</td><td>" + checkNullValue(user.EmergencyContact) + "</td></tr>";
                    $('#tblFamilyDetails tbody').append(row);
                    i = i + 1;
                });
            }
            else {
                $("#FamilyDiv").hide();
            }
        },
        error: function (er) {
        }
    });
}
function GetAllFormationById(id) {
    $.ajax({
        url: "/Member/GetAllFormationById?id=" + id,
        type: "POST",
        //type: "GET",
        //contentType: "application/json;charset=utf-8",
        async: false,
        dataType: "json",
        success: function (familydata) {
            //""
            if (familydata != "") {
                var i = 1;
                $('#tblFormation tbody').html("");
                var html = "";
                familydata.forEach(function (user) {
                    //console.log("Filename", user.FileName);
                    html += "<tr>";
                    html += "<td>" + i + "</td>";
                    html += "<td>" + checkNullValue(getValue(user.StageOfFormation)) + "</td>";
                    html += "<td>" + checkNullValue(getValue(user.FromDate)) + "</td>";
                    html += "<td>" + checkNullValue(getValue(user.ToDate)) + "</td>";
                    html += "<td>" + checkNullValue(getValue(user.Community)) + "</td>";
                    html += "<td>" + checkNullValue(getValue(user.Formators)) + "</td>";
                    html += "<td>" + checkNullValue(getValue(user.Description)) + "</td>";
                    html += "<td>";
                    if (user.FileName == null || user.FileName == "") {
                        html += "<a href='/Image/No-data-found.png' target='_blank'>View</a>";
                    }
                    else {
                        html += "<a href='/Image/Formation/" + user.FileName + "' target='_blank'>View</a>";
                    }
                    html += "</td>";
                    html += "</tr>";
                    //var row = "<tr><td>" + i + "</td><td>" + checkNullValue(getValue(user.StageOfFormation)) + "</td><td>" + checkNullValue(getValue(user.FromDate)) + "</td><td>" + checkNullValue(getValue(user.ToDate)) + "</td><td>" + checkNullValue(getValue(user.Community)) + "</td><td>" + checkNullValue(getValue(user.Formators)) + "</td><td>" + checkNullValue( getValue(user.Description)) + "</td></tr>";
                    i = i + 1;
                });
                $('#tblFormation tbody').append(html);
            }
            else {
                $("#FormationDiv").hide();
            }
        },
        error: function (er) {
            //alert(er);
        }
    });
}

function getValue(e) {
    if (e == null) {
        return "-";
    }
    return e;
}
function GetAllVowsById(name) {
    $.ajax({
        url: "/Member/GetAllVowsById?name=" + name,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (familydata) {
            $('#tblVowsRenewal tbody').html("");
            if (familydata != "") {
                var i = 1;
                familydata.forEach(function (user) {
                    var row = "<tr><td>" + i + "</td><td>" + checkNullValue(user.Name) + "</td><td>" + checkNullValue(user.MyId) + "</td><td>" + checkNullValue(user.Surname) + "</td><td>" + checkNullValue(user.Superior) + "</td><td>" + checkNullValue(user.Duration) + "</td><td>" + checkNullValue(user.Witness) + "</td></tr>";
                    $('#tblVowsRenewal tbody').append(row);
                    i = i + 1;
                })
            }
            else {
                $("#tblVowsRenewal").hide();
            }
        },
        error: function (er) {
        }
    });
}
function GetAllAcademyById(id) {
    $.ajax({
        url: "/Member/GetAllAcademyById?id=" + id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (familydata) {
            //""
            $('#Tbl_Academy tbody').html("");
            var html = "";
            if (familydata != "") {
                var i = 1;

                familydata.forEach(function (user) {

                    html += "<tr>";
                    html += "<td>" + i + "</td>";
                    html += "<td>" + checkNullValue(user.course) + "</td>";
                    html += "<td>" + checkNullValue(user.degree) + "</td>";
                    html += "<td>" + checkNullValue(user.university) + "</td>";
                    html += "<td>" + checkNullValue(user.fromdate) + "</td>";
                    html += "<td>" + checkNullValue(user.todate) + "</td>";
                    html += "<td>" + checkNullValue(user.adress) + "</td>";
                    html += "<td>" + checkNullValue(user.Description) + "</td>";
                    html += "<td>";
                    if (user.doc == null || user.doc == "") {
                        html += "<a href='/Image/No-data-found.png' target='_blank'>View</a>";
                    }
                    else {
                        html += "<a href='/Image/Academy/" + user.doc + "' target='_blank'>View</a>";
                    }
                    html += "</td>";
                    html += "</tr>";

                    //var row = "<tr><td>" + i + "</td><td>" + checkNullValue(user.course) + "</td><td>" + checkNullValue(user.degree) + "</td><td>" + checkNullValue(user.university) + "</td><td>" + checkNullValue(user.fromdate) + "</td><td>" + checkNullValue(user.todate) + "</td><td>" + checkNullValue(user.adress) + "</td><td>" + checkNullValue(user.Description) + "</td></tr>";
                    i = i + 1;
                })
                $('#Tbl_Academy tbody').append(html);
            } else {
                $("#AcademyDiv").hide();
            }
        },
        error: function (er) {
            //alert(er);
        }
    });
}
function GetAllAppinmentById(id) {
    $.ajax({
        url: "/Member/GetAllAppinmentById?id=" + id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (familydata) {
            $("#AppointmentDiv1").show();
            //""
            $('#TblAppointment tbody').html("");
            if (familydata != "") {
                var i = 1;
                var html = "";
                familydata.forEach(function (user) {
                    html += "<tr>";
                    html += "<td>" + i + "</td>";
                    html += "<td>" + (user.FromDate == null ? "" : user.FromDate) + "</td>";
                    html += "<td>" + (user.ToDate == null ? "" : user.ToDate) + "</td>";
                    html += "<td>" + checkzero(user.CommunityType) + "</td>";
                    html += "<td>" + checkNullValue(user.DesignationType) + "</td>";
                    html += "<td>" + checkNullValue(user.Place) + "</td>";
                    html += "<td>" + checkNullValue(user.Description) + "</td>";
                    html += "<td>";
                    if (user.doc == null || user.doc == "") {
                        html += "<a href='/Image/No-data-found.png' target='_blank'>View</a>";
                    }
                    else {
                        html += "<a href='/Image/Appointment/" + user.doc + "' target='_blank'>View</a>";
                    }
                    html += "</td>";
                    html += "</tr>";
                    //  var row = "<tr><td>" + i + "</td><td>" + user.Date + "</td><td>" + user.Name + "</td><td>" + user.DesignationType + "</td><td>" + user.InstitutionType + "</td><td>" + user.CommunityType + "</td><td>" + user.Superior + "</td></tr>";
                    //var row = "<tr><td>" + i + "</td><td>" + (user.FromDate == null ? "" : user.FromDate) + "</td><td>" + (user.ToDate == null ? "" : user.ToDate) + "</td><td>" + checkzero(user.CommunityType) + "</td><td>" + checkNullValue(user.DesignationType) + "</td><td>" + checkNullValue(user.Place) + "</td><td>" + checkNullValue(user.Description) + "</td></tr>";
                    i = i + 1;
                })
                $('#TblAppointment tbody').append(html);
            } else {
                $("#AppointmentDiv").hide();
            }
        },
        error: function (er) {
            //alert(er);
        }
    });
}
function GetAllInstitutionAppinmentById(id) {
    $.ajax({
        url: "/Member/GetAllInstitutionAppinmentById?id=" + id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (familydata) {
            $("#AppointmentDiv1").show();
            //""
            $('#TblAppointmentInst tbody').html("");
            if (familydata != "") {
                var i = 1;
                var html = "";
                familydata.forEach(function (user) {
                    html += "<tr>";
                    html += "<td>" + i + "</td>";
                    html += "<td>" + (user.FromDate == null ? "" : user.FromDate) + "</td>";
                    html += "<td>" + (user.ToDate == null ? "" : user.ToDate) + "</td>";
                    html += "<td>" + checkzero(user.InsDesignationType) + "</td>";
                    html += "<td>" + checkNullValue(user.InstitutionType) + "</td>";
                    html += "<td>";
                    if (user.doc == null || user.doc == "") {
                        html += "<a href='/Image/No-data-found.png' target='_blank'>View</a>";
                    }
                    else {
                        html += "<a href='/Image/Appointment/" + user.doc + "' target='_blank'>View</a>";
                    }
                    html += "</td>";
                    html += "</tr>";
                    //console.log(user);
                    //  var row = "<tr><td>" + i + "</td><td>" + user.Date + "</td><td>" + user.Name + "</td><td>" + user.DesignationType + "</td><td>" + user.InstitutionType + "</td><td>" + user.CommunityType + "</td><td>" + user.Superior + "</td></tr>";
                    //var row = "<tr><td>" + i + "</td><td>" + (user.FromDate == null ? "" : user.FromDate) + "</td><td>" + (user.ToDate == null ? "" : user.ToDate) + "</td><td>" + checkNullValue(user.InsDesignationType) + "</td><td>" + checkNullValue( user.InstitutionType )+ "</td></tr>";
                    i = i + 1;
                })
                $('#TblAppointmentInst tbody').append(html);
            } else {
                $("#AppointmentIns").hide();
            }
        },
        error: function (er) {
            //alert(er);
        }
    });
}
function GetHomeVisit(id) {
    $.ajax({
        url: "/Member/GetHomeVisit?id=" + id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (familydata) {
            //""
            $('#TblTravelDtl tbody').html("");
            if (familydata != "") {
                var i = 1;
                familydata.forEach(function (user) {
                    //console.log(user);
                    //  var row = "<tr><td>" + i + "</td><td>" + user.Date + "</td><td>" + user.Name + "</td><td>" + user.DesignationType + "</td><td>" + user.InstitutionType + "</td><td>" + user.CommunityType + "</td><td>" + user.Superior + "</td></tr>";
                    var row = "<tr><td>" + i + "</td><td>" + (user.FromDate == null ? "" : user.FromDate) + "</td><td>" + (user.ToDate == null ? "" : user.ToDate) + "</td><td>" + checkNullValue(user.Purpose) + "</td><td>" + checkNullValue(user.Place) + "</td><td>" + checkNullValue(user.Description) + "</td></tr>";
                    $('#TblTravelDtl tbody').append(row);
                    i = i + 1;
                });
            }
            else {
                $("#Traveldtl").hide();
            }
        },
        error: function (er) {
            //alert(er);
        }
    });
}
function GetExclaustration(id) {
    $.ajax({
        url: "/Member/GetExclaustration?id=" + id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (familydata) {
            //""
            $('#TblExclaustration tbody').html("");
            if (familydata != "") {
                var i = 1;
                familydata.forEach(function (user) {
                    //console.log(user);
                    //  var row = "<tr><td>" + i + "</td><td>" + user.Date + "</td><td>" + user.Name + "</td><td>" + user.DesignationType + "</td><td>" + user.InstitutionType + "</td><td>" + user.CommunityType + "</td><td>" + user.Superior + "</td></tr>";
                    var row = "<tr><td>" + i + "</td><td>" + checkNullValue(user.ClaustrationPurpose) + "</td><td>" + (user.ClaustrationFromDate == null ? "" : user.ClaustrationFromDate) + "</td><td>" + (user.ClaustrationToDate == null ? "" : user.ClaustrationToDate) + "</td><td>" + checkNullValue(user.ClaustrationPlace) + "</td><td>" + checkNullValue((user.ClaustrationCommunity)) + "</td></tr>";
                    $('#TblExclaustration tbody').append(row);
                    i = i + 1;
                })
            }
            else {
                $("#Exclaustrationdtl").hide();
            }
        },
        error: function (er) {
            //alert(er);
        }
    });
}
function GetAllTravelById(id) {
    $.ajax({
        url: "/Member/GetAllTravelById?id=" + id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (familydata) {
            ""
            $('#TblTravel tbody').html("");
            if (familydata != null) {
                var i = 1;
                familydata.forEach(function (user) {
                    var row = "<tr><td>" + i + "</td><td>" + checkNullValue(user.Name) + "</td><td>" + checkNullValue(user.SirName) + "</td><td>" + checkNullValue(user.FromDate) + "</td><td>" + checkNullValue(user.ToDate) + "</td><td>" + checkNullValue(user.Place) + "</td><td>" + checkNullValue((user.Purpose)) + "</td></tr>";
                    $('#TblTravel tbody').append(row);
                    i = i + 1;
                })
            }
        },
        error: function (er) {
            //alert(er);
        }
    });
}
function GetAllHealthById(id) {
    //console.log("ID", id);
    $.ajax({
        url: "/Member/GetAllHealthById?id=" + id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (familydata) {
            //""
            //console.log("familydata", familydata);
            $('#TblHealth tbody').html("");
            if (familydata != "") {
                var i = 1;
                var html = "";
                familydata.forEach(function (user) {
                    html += "<tr>";
                    html += "<td>" + i + "</td>";
                    html += "<td>" + checkNullValue(user.Complaint) + "</td>";
                    html += "<td>" + checkNullValue(user.FromDate) + "</td>";
                    html += "<td>" + checkNullValue(user.ToDate) + "</td>";
                    html += "<td>" + checkNullValue(user.Diagnosis) + "</td>";
                    html += "<td>" + checkNullValue(user.Hospital) + "</td>";
                    html += "<td>" + checkNullValue(user.Doctor) + "</td>";
                    html += "<td>";
                    if (user.Spare1 == null || user.Spare1 == "") {
                        html += "<a href='/Image/No-data-found.png' target='_blank'>View</a>";
                    }
                    else {
                        html += "<a href='/Image/Health/" + user.Spare1 + "' target='_blank'>View</a>";
                    }
                    html += "</td>";
                    html += "</tr>";
                    // var row = "<tr><td>" + i + "</td><td>" + user.Name + "</td><td>" + user.SirName + "</td><td>" + user.Complaint + "</td><td>" + user.FromDate + "</td><td>" + user.ToDate + "</td><td>" + user.Diagnosis + "</td><td>" + user.Hospital + "</td><td>" + user.Doctor + "</td></tr>";
                    //var row = "<tr><td>" + i + "</td><td>" + checkNullValue(user.Complaint) + "</td><td>" + checkNullValue(user.FromDate) + "</td><td>" + checkNullValue(user.ToDate) + "</td><td>" + checkNullValue(user.Diagnosis) + "</td><td>" + checkNullValue(user.Hospital) + "</td><td>" + checkNullValue(user.Doctor) + "</td></tr>";
                    i = i + 1;
                })
                $('#TblHealth tbody').append(html);
            }
            else {
                $("#HealthDiv").hide();
            }
        },
        error: function (er) {
            //alert(er);
        }
    });
}
function GetAllPassedById(id) {
    //alert();
    $.ajax({
        url: "/Member/GetAllPassedById?id=" + id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (familydata) {
            $('#TblPassed tbody').html("");
            if (familydata != null && familydata != "") {
                var i = 1;
                var html = "";
                familydata.forEach(function (user) {
                    html += "<tr>";
                    html += "<td>" + i + "</td>";
                    html += "<td>" + checkNullValue(user.EAge) + "</td>";
                    html += "<td>" + checkNullValue(user.Cause) + "</td>";
                    html += "<td>" + checkNullValue(user.Date) + "</td>";
                    html += "<td>" + checkNullValue(user.Time) + "</td>";
                    html += "<td>" + checkNullValue(user.Description) + "</td>";
                    html += "<td>" + checkNullValue(user.LastNatureRites) + "</td>";
                    html += "<td>" + checkNullValue(user.LastPlaceRites) + "</td>";
                    html += "<td>";
                    if (user.DeathCertificate == null || user.DeathCertificate == "") {
                        html += "<a target='_blank' href='/Image/No-data-found.png'></a>";
                    }
                    else {
                        html += "<a target='_blank' href='/Image/Death/" + user.DeathCertificate + "'>View</a>";
                    }
                    html += "</td>";
                    html += "</tr>";
                    //  var row = "<tr><td>" + i + "</td><td>" + user.Name + "</td><td>" + user.SirName + "</td><td>" + user.LastCommunity + "</td><td>" + user.Cause + "</td><td>" + user.Date + "</td><td>" + user.Time + "</td><td>" + user.InstitutionPlace + "</td><td>" + user.LastNatureRites + "</td><td>" + user.LastPlaceRites + "</td></tr>";
                    //var row = "<tr><td>" + i + "</td><td>" + checkNullValue(user.EAge) + "</td><td>" + checkNullValue(user.Cause) + "</td><td>" + checkNullValue(user.Date) + "</td><td>" + checkNullValue(user.Time) + "</td><td>" + checkNullValue(user.Description) + "</td><td>" + checkNullValue(user.LastNatureRites) + "</td><td>" + checkNullValue(user.LastPlaceRites) + "</td></tr>";
                    i = i + 1;
                })
                $('#TblPassed tbody').append(html);
            }
            else {
                $("#deathDiv").hide();
            }
        },
        error: function (er) {
            //alert(er);
        }
    });
}
function GetAllInsuranceById(id) {
    $.ajax({
        url: "/Member/GetAllInsuranceById?id=" + id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (familydata) {
            ""
            $('#TblInsurance tbody').html("");

            if (familydata != "") {
                var i = 1;
                familydata.forEach(function (user) {
                    //  var row = "<tr><td>" + i + "</td><td>" + user.Name + "</td><td>" + user.Title + "</td><td>" + user.Date + "</td><td>" + user.Premium + "</td><td>" + user.Ammount + "</td><td>" + user.Description + "</td></tr>";
                    var row = "<tr><td>" + i + "</td><td>" + checkNullValue(user.Title) + "</td><td>" + checkNullValue(user.Date) + "</td><td>" + checkNullValue(user.Premium) + "</td><td>" + checkNullValue(user.Ammount) + "</td><td>" + checkNullValue((user.Description)) + "</td></tr>";
                    $('#TblInsurance tbody').append(row);
                    i = i + 1;
                })
            }
            else {
                $("#InsuranceDiv").hide();
            }
        },
        error: function (er) {
            //alert(er);
        }
    });
}
function GetAllSaprationById(id) {
    $.ajax({
        url: "/Member/GetAllSaprationById?id=" + id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (familydata) {
            console.log("familydata", familydata);
            //""
            $('#TblSapration tbody').html("");
            if (familydata == "") {
                $("#SaprationDiv").hide();
            }
            else {
                var i = 1;
                var html = "";
                familydata.forEach(function (user) {
                    html += "<tr>";
                    html += "<td>" + i + "</td>";
                    html += "<td>" + checkNullValue(user.SeperationDate) + "</td>";
                    html += "<td>" + checkNullValue(user.Title) + "</td>";
                    html += "<td>" + checkNullValue(user.Describtion) + "</td>";
                    html += "<td>";
                    if (user.File == null || user.File == "") {
                        html += "<a target='_blank' href='/Image/No-data-found.png'>View</a>";
                    }
                    else {
                        html += "<a target='_blank' href='/Images/Separation/" + user.File + "'>View</a>";
                    }
                    html += "</td>";
                    html += "</tr>";
                    // var row = "<tr><td>" + i + "</td><td>" + user.Name + "</td><td>" + user.SeperationDate + "</td><td>" + user.Title + "</td><td>" + user.Describtion + "</td></tr>";
                    //var row = "<tr><td>" + i + "</td><td>" + checkNullValue(user.SeperationDate) + "</td><td>" + checkNullValue(user.Title) + "</td><td>" + checkNullValue(user.Describtion) + "</td></tr>";
                    i = i + 1;
                })
                $('#TblSapration tbody').append(html);
            }
        },
        error: function (er) {
            //alert(er);
        }
    });
}


function GetAllProfessionById(id) {
    $.ajax({
        url: "/Member/GetAllProfessionById?id=" + id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (professionData) {
          $("#Professiontbl").hide();

            $('#Professiontbl tbody').html("");
            if (professionData != "") {
                var i = 1;
                var html = "";
                professionData.forEach(function (user) {

                    html += "<tr>";
                    html += "<td>" + i + "</td>";
                    html += "<td>" + checkNullValue(user.StageOfFormation) + "</td>";
                    html += "<td>" + checkNullValue(user.VowsDate) + "</td>";
                    html += "<td>" + checkNullValue(user.Community) + "</td>";
                    html += "<td>";
                    if (user.FileName == null || user.FileName == "") {
                        html += "<a href='/Image/No-data-found.png' target='_blank'>View</a>";
                    }
                    else {
                        html += "<a href='/Image/Formation/" + user.FileName + "' target='_blank'>View</a>";
                    }
                    html += "</td>";
                    html += "</tr>";
                    // var row = "<tr><td>" + i + "</td><td>" + user.Name + "</td><td>" + user.SeperationDate + "</td><td>" + user.Title + "</td><td>" + user.Describtion + "</td></tr>";
                    //var row = "<tr><td>" + i + "</td><td>" + checkNullValue(user.StageOfFormation) + "</td><td>" + checkNullValue(user.VowsDate) + "</td><td>" + checkNullValue(user.Community) + "</td></tr>";
                    i = i + 1;
                })
                $('#Professiontbl tbody').append(html);
            }
            else {
                $("#Professiontbl").hide();
            }
        },
        error: function (er) {
            //alert(er);
        }
    });
}

function GetAllClustrationById(id) {
    $.ajax({
        url: "/Member/GetAllClustrationById?id=" + id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (data) {
            //""
            $('#ClustrationTbl tbody').html("");
            if (data != "") {
                var i = 1;
                data.forEach(function (user) {
                    // var row = "<tr><td>" + i + "</td><td>" + user.Name + "</td><td>" + user.SeperationDate + "</td><td>" + user.Title + "</td><td>" + user.Describtion + "</td></tr>";
                    var row = "<tr><td>" + i + "</td><td>" + checkNullValue(user.ClaustrationPurpose) + "</td><td>" + checkNullValue(user.ClaustrationFromDate) + "</td><td>" + checkNullValue(user.ClaustrationToDate) + "</td><td>" + checkNullValue(user.ClaustrationPlace) + "</td><td>" + checkNullValue(user.ClaustrationCommunity) + "</td></tr>";
                    $('#ClustrationTbl tbody').append(row);
                    i = i + 1;
                })
            } else {
                $("#ClustrationTbl").hide();
            }
        },
        error: function (er) {
            //alert(er);
        }
    });
}

function GetAllRetirementById(id) {
    $.ajax({
        url: "/Member/GetAllRetirementById?id=" + id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (data) {

            //""
            $('#RetirementTbl tbody').html("");
            if (data != "") {
                alert(data);
                var i = 1;
                data.forEach(function (user) {
                    // var row = "<tr><td>" + i + "</td><td>" + user.Name + "</td><td>" + user.SeperationDate + "</td><td>" + user.Title + "</td><td>" + user.Describtion + "</td></tr>";
                    var row = "<tr><td>" + i + "</td><td>" + checkNullValue(user.DOR) + "</td><td>" + checkNullValue(user.Age) + "</td><td>" + checkNullValue(user.Reason) + "</td></tr>";
                    $('#RetirementTbl tbody').append(row);
                    i = i + 1;
                })
            } else {
                //alert("working");
                $("#RetirementTbl").hide();
            }
        },
        error: function (er) {
            //alert(er);
        }
    });
}

function GetAllSacramentdataById(id) {
    $.ajax({
        url: "/Member/GetAllSacramentdataById?id=" + id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (familydata) {
            $('#TblSacrament tbody').html("");
            if (familydata != null) {
                var i = 1;
                var html = "";
                familydata.forEach(function (user) {
                    html += "<tr>";
                    html += "<td>" + i + "</td>";
                    html += "<td>" + checkNullValue(user.Date) + "</td>";
                    html += "<td>" + checkNullValue(user.Sacrament) + "</td>";
                    html += "<td>" + checkNullValue(user.Minister) + "</td>";
                    html += "<td>" + checkNullValue(user.ChurchName) + "</td>";
                    html += "<td>" + checkNullValue(user.Remarks) + "</td>";
                    html += "<td>";
                    if (user.File != null) {
                        html += "<a href='/Image/Sacrament/" + user.File + "' target='_blank'>View</a>";
                    }
                    else {
                        html += "<a href='/Image/No-data-found.png' target='_blank'>View</a>";
                    }
                    html += "</td>";
                    html += "</tr>";
                    //var row = "<tr><td>" + i + "</td><td>" + checkNullValue(user.Date) + "</td><td>" + checkNullValue(user.Sacrament) + "</td><td>" + checkNullValue(user.Minister) + "</td><td>" + checkNullValue(user.ChurchName) + "</td><td>" + checkNullValue(user.Remarks) + "</td></tr>";
                    i = i + 1;
                });
                $('#TblSacrament tbody').append(html);
            }
        },
        error: function (er) {
        }
    });
}

$("#DynamicField").text("Based On Seniority");
$("#agevalue").css("display", "none")
$("#Toagevalue").css("display", "none")
$("#PersionalDetailsDiv").css("display", "none");
$("#btnMemberInfo").on("click", function () {
    $("#DynamicField").text(radioButton);
    var radioButton = $("input[name='optradio']:checked").val();
    var fromdate = $("#fromdate").val();
    var todate = $("#todate").val();
    var age = $("#agevalue").val();
    var toage = $("#Toagevalue").val();

    $.ajax({
        url: "/Member/GetMembersInfo?radioButton=" + radioButton + "&fromdate=" + fromdate + "&todate=" + todate + "&age=" + age,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (elem) {

        },
        error: function (er) {
            //alert(er);
        }
    });
});

//Checkbox clicks
$("#AppointmentDiv").css("display", "none");
$("#AppointmentDivInst").css("display", "none");
$("#AcademyDiv").css("display", "none");
$("#FormationDiv").css("display", "none");
$("#VowsRenewalDiv").css("display", "none");
$("#HealthDiv").css("display", "none");
$("#TravelDiv").css("display", "none");
$("#deathDiv").css("display", "none");
$("#PrimaryDiv").css("display", "none");
$("#FamilyDiv").css("display", "none");
$("#SacramentDiv").css("display", "none");
$("#InsuranceDiv").css("display", "none");
$("#SaprationDiv").css("display", "none");
$("#OffDocDiv").css("display", "none");
$('#chkAppointment').click(function () {
    if ($(this).prop("checked") == true) {
        $("#AppointmentDiv").css("display", "block")
        $("#PersonalDetailDiv").css("display", "none");
    }
    else if ($(this).prop("checked") == false) {
        $("#AppointmentDiv").hide();
    }
});
$('#chkFormation').click(function () {
    if ($(this).prop("checked") == true) {
        $("#FormationDiv").css("display", "block");
        $("#PersonalDetailDiv").css("display", "none");
    }
    else if ($(this).prop("checked") == false) {
        $("#FormationDiv").css("display", "none");
    }
});
$('#chkVows').click(function () {
    if ($(this).prop("checked") == true) {
        $("#VowsRenewalDiv").css("display", "block");
        $("#PersonalDetailDiv").css("display", "none");
    }
    else if ($(this).prop("checked") == false) {
        $("#VowsRenewalDiv").css("display", "none");
        $("#PersonalDetailDiv").css("display", "none");
    }
});
$('#chkAcademy').click(function () {
    if ($(this).prop("checked") == true) {
        $("#AcademyDiv").css("display", "block");
        $("#PersonalDetailDiv").css("display", "none");
    }
    else if ($(this).prop("checked") == false) {
        $("#AcademyDiv").css("display", "none");
    }
});
$('#chkHealth').click(function () {
    if ($(this).prop("checked") == true) {

        $("#HealthDiv").css("display", "block");
        $("#PersonalDetailDiv").css("display", "none");
    }
    else if ($(this).prop("checked") == false) {
        $("#HealthDiv").css("display", "none");

    }
});
$('#chkTravel').click(function () {
    if ($(this).prop("checked") == true) {
        $("#TravelDiv").css("display", "block")
        $("#PersonalDetailDiv").css("display", "none");
    }
    else if ($(this).prop("checked") == false) {
        $("#TravelDiv").css("display", "none")

    }
});
$('#chkdeath').click(function () {
    if ($(this).prop("checked") == true) {
        $("#deathDiv").css("display", "block")
        $("#PersonalDetailDiv").css("display", "none");
    }
    else if ($(this).prop("checked") == false) {
        $("#deathDiv").css("display", "none")

    }
});
$('#chkPrimary').click(function () {
    if ($(this).prop("checked") == true) {

        $("#PersonalDetailDiv").css("display", "block");
    }
    else if ($(this).prop("checked") == false) {
        $("#PersonalDetailDiv").css("display", "none")

    }
});
$('#chkFamily').click(function () {
    var memberId = $("#AllMembers option:selected").val();
    console.log("memberid", memberId);
    if ($(this).prop("checked") == true) {
        $("#FamilyDiv").css("display", "block")
        $("#PersonalDetailDiv").css("display", "none");
    }
    else if ($(this).prop("checked") == false) {
        $("#FamilyDiv").css("display", "none")

    }
});
$('#chkSacrament').click(function () {
    if ($(this).prop("checked") == true) {
        $("#SacramentDiv").css("display", "block")
        $("#PersonalDetailDiv").css("display", "none");
    }
    else if ($(this).prop("checked") == false) {
        $("#SacramentDiv").css("display", "none")

    }
});
$('#chkSapration').click(function () {
    if ($(this).prop("checked") == true) {
        $("#SaprationDiv").css("display", "block")
        $("#PersonalDetailDiv").css("display", "none")
    }
    else if ($(this).prop("checked") == false) {
        $("#SaprationDiv").css("display", "none")
    }
});
$('#chkInsurance').click(function () {
    if ($(this).prop("checked") == true) {
        $("#InsuranceDiv").css("display", "block")
        $("#PersonalDetailDiv").css("display", "none")
    }
    else if ($(this).prop("checked") == false) {
        $("#InsuranceDiv").css("display", "none")
    }
});
$('#chkoffdoc').click(function () {
    if ($(this).prop("checked") == true) {
        $("#OffDocDiv").css("display", "block")
        $("#PersonalDetailDiv").css("display", "none")
    }
    else if ($(this).prop("checked") == false) {
        $("#OffDocDiv").css("display", "none")
    }
});
$('#chkViewAll').click(function () {
    if ($(this).prop("checked") == true) {
        $("#PersonalDetailDiv").css("display", "block");
        $("#AppointmentDiv").css("display", "block")
        $("#AcademyDiv").css("display", "block")
        $("#FormationDiv").css("display", "block")
        $("#VowsRenewalDiv").css("display", "block")
        $("#HealthDiv").css("display", "block")
        $("#TravelDiv").css("display", "block")
        $("#deathDiv").css("display", "block")
        $("#PrimaryDiv").css("display", "block")
        $("#FamilyDiv").css("display", "block")
        $("#SacramentDiv").css("display", "block")
        $("#InsuranceDiv").css("display", "block")
        $("#SaprationDiv").css("display", "block")
        $("#OffDocDiv").css("display", "block")

        $("#AppointmentDiv").attr("checked", true);
        $("#AcademyDiv").attr("checked", true);
        $("#FormationDiv").attr("checked", true);
        $("#VowsRenewalDiv").attr("checked", true);
        $("#HealthDiv").attr("checked", true);
        $("#TravelDiv").attr("checked", true);
        $("#deathDiv").attr("checked", true);
        $("#PrimaryDiv").attr("checked", true);
        $("#FamilyDiv").attr("checked", true);
        $("#SacramentDiv").attr("checked", true);
        $("#InsuranceDiv").attr("checked", true);
        $("#SaprationDiv").attr("checked", true);
        $("#OffDocDiv").attr("checked", true);
    }
    else if ($(this).prop("checked") == false) {
        $("#AppointmentDiv").css("display", "none")
        $("#AcademyDiv").css("display", "none")
        $("#FormationDiv").css("display", "none")
        $("#VowsRenewalDiv").css("display", "none")
        $("#HealthDiv").css("display", "none")
        $("#TravelDiv").css("display", "none")
        $("#deathDiv").css("display", "none")
        $("#PrimaryDiv").css("display", "none")
        $("#FamilyDiv").css("display", "none")
        $("#SacramentDiv").css("display", "none")
        $("#InsuranceDiv").css("display", "none")
        $("#SaprationDiv").css("display", "none")
        $("#ArchiveDiv").css("display", "none")
        $("#OffDocDiv").css("display", "none")

        $("#AppointmentDiv").attr("checked", false);
        $("#AcademyDiv").attr("checked", false);
        $("#FormationDiv").attr("checked", false);
        $("#VowsRenewalDiv").attr("checked", false);
        $("#HealthDiv").attr("checked", false);
        $("#TravelDiv").attr("checked", false);
        $("#deathDiv").attr("checked", false);
        $("#PrimaryDiv").attr("checked", false);
        $("#FamilyDiv").attr("checked", false);
        $("#SacramentDiv").attr("checked", false);
        $("#InsuranceDiv").attr("checked", false);
        $("#SaprationDiv").attr("checked", false);
        $("#ArchiveDiv").attr("checked", false);
        $("#OffDocDiv").attr("checked", false);
    }
});

function clearAll() {
    $("#PersonKnowName").text("");
    $("#SirName").text("");
    $("#memberID").text("");
    $("#PlaceInFamily").text("");
    $("#FatherName").text("");
    $("#MotherName").text("");
    $("#fatherBaptismialName").text("");
    $("#MothersBaptismialName").text("");
    $("#OtherName").text("");
    $("#parisname").text("");
    $("#Diocese").text("");
    $("#HouseNo").text("");
    $("#HouseName").text("");
    $("#Will").text("");
    $("#personBaptismalName").text("");
    $("#PersonDateofBirthBaptism").text("");
    $("#PersonDateofBirthSSLC").text("");
    $("#PersonFeastDay").text("");
    $("#PersonBloodGroup").text("");
    $("#PersonEmailID").text("");
    $("#PersonMobileNumber").text("");
    $("#Persohomeparish").text("");
    $("#PersoOrdinationId").text("");
    $("#PersomothertoungeId").text("");
    $("#Persohomediocese").text("");
    $("#PersoHouseno").text("");
    $("#personCity").text("");
    $("#personDistrict").text("");
    $("#persionState").text("");
    $("#personPincode").text("");
    $("#AadharNumber").text("");
    $("#NameasitisAadhar").text("");
    $("#Passport").text("");
    $("#Nameasitispassport").text("");
    $("#UploadPanDoccument").text("");
    $("#NameasitinPAN").text("");
    $("#UploadAdharDoccumentN").text("");
    $("#UploadPassDoccumentN").text("");
    $("#UploadPhotoDoccumentN").text("");
    $("#placeinfamily").text("");
    $("#Personnoofsisters").text("");
    $("#Personnoofbrother").text("");
    $("#PersonCountry").text("");
    $("#file1View").attr("href", "#");
    $("#file2View").attr("href", "#");
    $("#file3View").attr("href", "#");
    $("#PersonPhotoUpload1").attr("href", "#");
    $("#uploadimage").attr("src", "#");
    $("#placeinfamily").text('');
    $("#PANNumber").text('');
    $("#PersonBlog").attr("src", "#");
    $("#uploadDocument").attr("src", "#");
    $("#UploadDoccumentN").text("");

}
//work for the radio buttons

$("#BasedOnAge").on("change", function () {
    $("#agevalue").css("display", "block");
    $("#Toagevalue").css("display", "block");
});
$("#BasedOnDesignation").on("change", function () {
    $("#AllDesignationsDiv").css("display", "block");
});
$("#BasedOnInstitution").on("change", function () {
    $("#AllInstitutionsDiv").css("display", "block");
});

$("input[name='optradio']").on("change", function () {
    var data = $(this).val();
    //alert(data);
    if (data == 'Birthday' || data == 'Feastday' || data == 'DeathAnnivers' || data == 'Jublie') {
        $('#FromDate').val('');
        $('#ToDate').val('');
        $('#FilterDate').show();
    }
    else {
        $('#FilterDate').hide();
    }
    if (data == "BasedOnAge") {
        $("#agevalue").css("display", "block");
        $("#Toagevalue").css("display", "block");
    } else {
        $("#agevalue").css("display", "none");
        $("#Toagevalue").css("display", "none");
    }
    if (data == "Basedonbatch") {
        $("#batchvalue").css("display", "block");
    } else {
        $("#batchvalue").css("display", "none");
    }

    if (data == "BasedOnDesignation") {
        $("#AllDesignationsDiv").css("display", "block");
    } else {
        $("#AllDesignationsDiv").css("display", "none");
    }

    if (data == "BasedOnInstitution") {
        $("#AllInstitutionsDiv").css("display", "block");
    } else {
        $("#AllInstitutionsDiv").css("display", "none");
    }

});
//$("input[name='optradio']").on('click', function () {
//    alert();
//});
$("#RdobtnSearch").on("click", function () {
    $("#PersionalDetailsDiv").css("display", "none");
    $(".Membergrid").css("display", "none");

    var rdButton = $("input[name='optradio']:checked").val();
    var selectedDesignation = $("#AllDesignations option:selected").text();
    //alert(selectedDesignation);
    var province = $("#ProvinceDrop option:selected").val();
    var FromDate = $('#FromDate').val();
    var ToDate = $('#ToDate').val();
    if (rdButton == "BasedOnDesignation") {
        if (selectedDesignation == "-- Select Name --") {
            alert("Please select designation");
            return false;
        } else {
            $.ajax({
                url: "/Member/GetAllAppoinmentByDesignation?name=" + selectedDesignation + "&&province=" + province,
                type: "GET",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (familydata) {
                    $('#bindTableBody1').html("");
                    if (familydata != null) {
                        var i = 1;
                        familydata.forEach(function (data) {
                            var row = "<tr><td>" + i + "</td><td>" + checkNullValue(data.Name) + "</td><td>" + checkNullValue(data.SurName) + "</td><td>" + checkNullValue(data.FromDate) + "-" + checkNullValue(data.ToDate) + " </td><td>" + checkNullValue(data.Institutions) + "</td></tr>";
                            $('#bindTableBody1').append(row);
                            i = i + 1;
                        });
                    }
                },
                error: function (er) {
                }
            });
            $("#MemberDetailsDiv").css("display", "block");
            $("#RadioBtnReport1").css("display", "block");
            $("#RadioBtnReport").css("display", "none");
        }
    }
    else {
        $("#RadioBtnReport1").css("display", "none");
    }

    if (rdButton == "BasedOnInstitution") {
        //debugger;
        var selectedInstitution = $("#AllInstitutions option:selected").text();
        if (selectedInstitution == "-- Select Name --") {
            alert("Please select Institution");
            return false;
        } else {
            $.ajax({
                url: "/Member/GetAllInstitutionByInstitution?name=" + selectedInstitution,
                type: "GET",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (familydata) {
                    //debugger;
                    $('#bindTableBody10').html("");
                    if (familydata != null) {
                        var i = 1;
                        familydata.forEach(function (user) {
                            var row = "<tr><td>" + i + "</td><td>" + checkNullValue(user.Name) + "</td><td>" + checkNullValue(user.SirName) + "</td><td>" + checkNullValue(user.Designation) + "</td></tr>";
                            $('#bindTableBody10').append(row);
                            i = i + 1;
                        });
                    }
                },
                error: function (er) {
                    alert(er);
                }
            });
            $("#RadioBtnReport10").css("display", "block");
            $("#InstitutionDetailsDiv").css("display", "block");
        }

    } else {
        $("#RadioBtnReport10").css("display", "none");
    }

    if (rdButton == "BasedOnAge") {
        //debugger;
        var age = $("#agevalue").val();
        var Toage = $("#Toagevalue").val();
        if (age == "") {
            alert("Please enter age");
            return false;
        }
        if (Toage == "") {
            Toage = 0;
        }
        $.ajax({
            url: "/Member/GetAllPrimaryByAge?age=" + age + "&&Toage=" + Toage + "&&province=" + province,
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (familydata) {
                //debugger;
                $('#bindTableBody11').html("");

                if (familydata != null) {
                    var i = 1;
                    familydata.forEach(function (user) {
                        var row = "<tr><td>" + i + "</td><td>" + user.Knowname + "</td><td>" + user.SurName + "</td><td>" + user.DOB + "</td></tr>";
                        $('#bindTableBody11').append(row);
                        i = i + 1;
                    });
                    $("#bindTableBody11").css("display", "");
                }
            },
            error: function (er) {
            }
        });
        $("#RadioBtnReport11").css("display", "block");
    } else {
        $("#RadioBtnReport11").css("display", "none");
    }

    if (rdButton == "BasedOnSeniority") {
        //debugger;
        $.ajax({
            url: "/Member/BasedOnSeniority?province=" + province,
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (familydata) {
                //alert(familydata);
                $('#bindTableBody2').html("");
                if (familydata != null) {
                    var i = 1;
                    familydata.forEach(function (user) {
                        var row = "<tr><td>" + i + "</td><td>" + checkNullValue(user.Name) + "</td><td>" + checkNullValue(user.Sirname) + "</td><td>" + checkNullValue(user.DOB) + "</td><td>" + checkNullValue(user.Age) + "</td></tr>";
                        $('#bindTableBody2').append(row);
                        i = i + 1;
                    });
                }
            },
            error: function (er) {
            }
        });
        $("#RadioBtnReport2").css("display", "block");
    } else {
        $("#RadioBtnReport2").css("display", "none");
    }
    if (rdButton == "Birthday") {

        //var provinceid = $("#ProvinceDrop").val();
        var fromdate = $("#FromDate").val();
        var todate = $("#ToDate").val();

        if (fromdate == "" && todate == "") {
            alert("Please Select Province and Fromdate and Todate");
        }
        else {
            $.ajax({
                url: "/Member/Birthday?province=" + province + "&FromDate=" + FromDate + "&ToDate=" + ToDate,
                type: "GET",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (familydata) {
                    //debugger;
                    $('#bindTableBody4').html("");
                    if (familydata != null) {
                        var i = 1;
                        familydata.forEach(function (user) {
                            var row = "<tr><td>" + i + "</td><td>" + checkNullValue(user.Name) + "</td><td>" + checkNullValue(user.Sirname) + "</td><td>" + checkNullValue(user.DOB) + "</td><td>" + checkNullValue(user.Age) + "</td></tr>";
                            $('#bindTableBody4').append(row);
                            i = i + 1;
                        });
                    }
                },
                error: function (er) {
                }
            });
        }


        $("#RadioBtnReport4").css("display", "block");
    } else {
        $("#RadioBtnReport4").css("display", "none");
    }
    if (rdButton == "DeathAnnivers") {

        var provinceid = $("#ProvinceDrop").val();
        var fromdate = $("#FromDate").val();
        var todate = $("#ToDate").val();
        if (provinceid == 0 && fromdate == "" || todate == "") {
            alert("Please Select Province and Fromdate and Todate");
        }
        else {
            $.ajax({
                url: "/Member/DeathAnnivers?province=" + province + "&FromDate=" + FromDate + "&ToDate=" + ToDate,
                type: "GET",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (familydata) {
                    //debugger;
                    $('#bindTableBody3').html("");
                    if (familydata != null) {
                        var i = 1;
                        familydata.forEach(function (user) {
                            var row = "<tr><td>" + i + "</td><td>" + checkNullValue(user.Name) + " " + checkNullValue(user.SirName) + "</td><td>" + checkNullValue(user.Date) + "</td><td>" + checkNullValue(user.Age) + "</td><td>" + checkNullValue(user.WorkingYear) + "</td><td>" + user.LastCommunity + "</td><td>" + checkNullValue(user.LastPlaceRites) + "</td></tr>";
                            $('#bindTableBody3').append(row);
                            i = i + 1;
                        });
                    }
                },
                error: function (er) {
                }
            });
        }

        $("#RadioBtnReport3").css("display", "block");
    } else {
        $("#RadioBtnReport3").css("display", "none");
    }
    if (rdButton == "Feastday") {
        $.ajax({
            url: "/Member/Feastday?province=" + province + "&FromDate=" + FromDate + "&ToDate=" + ToDate,
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (familydata) {
                $('#bindTableBody5').html("");
                if (familydata != null) {
                    var i = 1;
                    familydata.forEach(function (user) {
                        var row = "<tr><td>" + i + "</td><td>" + checkNullValue(user.Knowname) + "</td><td>" + checkNullValue(user.SurName) + "</td><td>" + checkNullValue(user.Feastday) + "</td></tr>";
                        $('#bindTableBody5').append(row);
                        i = i + 1;
                    });

                }
            },
            error: function (er) {
            }
        });
        $("#RadioBtnReport5").css("display", "block");
    } else {
        $("#RadioBtnReport5").css("display", "none");
    }
    if (rdButton == "Chronologicalorder") {
        //var provinceid = $("#ProvinceDrop").val();
        //alert(provinceid);
        //if (provinceid == 0) {
        //    alert("Please Select Province");
        //}
        //else

        $.ajax({
            url: "/Member/Chronologicalorder?province=" + province,
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (familydata) {
                $('#bindTableBody6').html("");
                if (familydata != null) {
                    var i = 1;
                    familydata.forEach(function (user) {
                        var row = "<tr><td>" + i + "</td><td>" + checkNullValue(user.Name) + "</td><td>" + checkNullValue(user.Sirname) + "</td><td>" + checkNullValue(user.EmailId) + "</td><td>" + checkNullValue(user.DOB) + "</td></tr>";
                        $('#bindTableBody6').append(row);
                        i = i + 1;
                    });
                }
            },
            error: function (er) {
            }
        });


        $("#RadioBtnReport6").css("display", "block");
    } else {
        $("#RadioBtnReport6").css("display", "none");
    }
    if (rdButton == "Basedonbatch") {
        var year = $("#batchvalue").val();
        if (year == "") {
            alert("Please Enter Year");
            return false;
        }
        $.ajax({
            url: "/Member/Basedonbatch?year=" + year + "&&province=" + province,
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (familydata) {
                $('#bindTableBody7').html("");
                if (familydata != null) {
                    var i = 1;
                    familydata.forEach(function (user) {
                        var row = "<tr><td>" + i + "</td><td>" + checkNullValue(user.Knowname) + "</td><td>" + checkNullValue(user.SurName) + "</td><td>" + checkNullValue(user.Year) + "</td></tr>";
                        $('#bindTableBody7').append(row);
                        i = i + 1;
                    });
                }
            },
            error: function (er) {
            }
        });
        $("#RadioBtnReport7").css("display", "block");
    } else {
        $("#RadioBtnReport7").css("display", "none");
    }
    if (rdButton == "Jublie") {

        var provinceid = $("#ProvinceDrop").val();
        var fromdate = $("#FromDate").val();
        var todate = $("#ToDate").val();
        //if (provinceid == 0 && fromdate == "" || todate == "") {
        //    alert("Please Select Province and Fromdate and Todate");
        //} else
        {
            $.ajax({
                url: "/Member/jubliiData?province=" + province + "&FromDate=" + FromDate + "&ToDate=" + ToDate,
                type: "GET",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (familydata) {
                    //debugger;
                    $('#bindTableBody8').html("");

                    if (familydata != null) {
                        var i = 1;
                        familydata.forEach(function (user) {
                            var row = "<tr><td>" + i + "</td><td>" + checkNullValue(user.Name) + "</td><td>" + checkNullValue(user.FromDate) + "</td><td>" + checkNullValue(user.JubilyType) + "</td></tr>";
                            $('#bindTableBody8').append(row);
                            i = i + 1;
                        });
                    }
                },
                error: function (er) {
                }
            });
        }


        $("#RadioBtnReport8").css("display", "block");
    } else {
        $("#RadioBtnReport8").css("display", "none");
    }
    if (rdButton == "Ordinationday") {
        $.ajax({   
        });
        //$("#PersionalDetailsDiv").css("display", "none");

        $("#RadioBtnReport12").css("display", "block");
    } else {
        $("#RadioBtnReport12").css("display", "none");
    }
    if (rdButton == "FinalVows") {
        $.ajax({
            url: "/Member/FinalVows?province=" + province,
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (familydata) {
                $('#bindTableBody13').html("");
                //$("#PersionalDetailsDiv").css("display", "none");

                if (familydata != null) {
                    var i = 1;
                    familydata.forEach(function (user) {
                        var row = "<tr><td>" + i + "</td><td>" + checkNullValue(user.Name) + "</td><td>" + checkNullValue(user.FileNo) + "</td><td>" + checkNullValue(user.ToDate) + "</td><td>" + checkNullValue(user.DOB) + "</td><td>" + checkNullValue(user.Age) + "</td></tr>";
                        $('#bindTableBody13').append(row);
                        i = i + 1;
                    });
                }
            },
            error: function (er) {

            }
        });
        $("#RadioBtnReport13").css("display", "block");
    } else {
        $("#RadioBtnReport13").css("display", "none");
    }




    //IstNovitiate
    if (rdButton == "Novitiate") {

        //var provinceid = $("#ProvinceDrop").val();
        //var fromdate = $("#FromDate").val();
        //var todate = $("#ToDate").val();

        //if ( fromdate == "" && todate == "") {
        //    alert(" Fromdate and Todate");
        //} else
        {
            $.ajax({
                url: "/Member/Novitiate?province=" + province,
                type: "GET",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (familydata) {
                    //alert(familydata.IstNovitiatedata);
                    $('#bindTableBody14').html("");
                    //$("#PersionalDetailsDiv").css("display", "none");

                    if (familydata != null) {
                        var i = 1;
                        familydata.forEach(function (user) {
                            var row = "<tr><td>" + i + "</td><td>" + checkNullValue(user.Name) + "</td><td>" + checkNullValue(user.Sirname) + "</td><td>" + checkNullValue(user.FileNo) + "</td><td>" + checkNullValue(user.FromDate) + "</td><td>" + checkNullValue(user.DOB) + "</td><td>" + checkNullValue(user.Age) + "</td></tr>";
                            $('#bindTableBody14').append(row);
                            i = i + 1;
                        });


                    }
                },
                error: function (er) {

                }
            });
        }

        $("#RadioBtnReport14").css("display", "block");
    } else {
        $("#RadioBtnReport14").css("display", "none");
    }

    if (rdButton == "2ndNovitiate") {

        //var provinceid = $("#ProvinceDrop").val();
        //var fromdate = $("#FromDate").val();
        //var todate = $("#ToDate").val();
        //if (fromdate == "" || todate == "") {
        //    alert(" Fromdate and Todate");
        //}
        //else
        {
            $.ajax({
                url: "/Member/IIndNovitiate?province=" + province,
                type: "GET",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (familydata) {
                    //alert(familydata.IstNovitiatedata);
                    $('#bindTableBody15').html("");
                    //$("#PersionalDetailsDiv").css("display", "none");

                    if (familydata != null) {
                        var i = 1;
                        familydata.forEach(function (user) {
                            var row = "<tr><td>" + i + "</td><td>" + checkNullValue(user.Name) + "</td><td>" + checkNullValue(user.Sirname) + "</td><td>" + checkNullValue(user.FileNo) + "</td><td>" + checkNullValue(user.FromDate) + "</td><td>" + checkNullValue(user.DOB) + "</td><td>" + checkNullValue(user.Age) + "</td></tr>";
                            $('#bindTableBody15').append(row);
                            i = i + 1;
                        });


                    }
                },
                error: function (er) {

                }
            });
        }

        $("#RadioBtnReport15").css("display", "block");
    } else {
        $("#RadioBtnReport15").css("display", "none");
    }

    if (rdButton == "Prenovitiate") {

        //alert("working");
        //var provinceid = $("#ProvinceDrop").val();
        //var fromdate = $("#FromDate").val();
        //var todate = $("#ToDate").val();
        //if ( fromdate == "" || todate == "") {
        //    alert("Fromdate and Todate");
        //} else
        //alert("Working");

        $.ajax({
            url: "/Member/Prenovitiatereport?province=" + province,
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (familydata) {
                //alert(familydata.IstNovitiatedata);
                $('#bindTableBody16').html("");
                //$("#PersionalDetailsDiv").css("display", "none");

                if (familydata != null) {
                    var i = 1;
                    familydata.forEach(function (user) {
                        var row = "<tr><td>" + i + "</td><td>" + checkNullValue(user.Name) + "</td><td>" + checkNullValue(user.Sirname) + "</td><td>" + checkNullValue(user.FileNo) + "</td><td>" + checkNullValue(user.FromDate) + "</td><td>" + checkNullValue(user.DOB) + "</td><td>" + checkNullValue(user.Age) + "</td></tr>";
                        $('#bindTableBody16').append(row);
                        i = i + 1;
                    });
                }
            },
            error: function (er) {

            }
        });


        $("#RadioBtnReport16").css("display", "block");
    } else {
        $("#RadioBtnReport16").css("display", "none");
    }

    if (rdButton == "CheckArchieve") {
        //alert("working");
        $.ajax({
            url: "/Member/CheckArchieve?province=" + province,
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (familydata) {
                $('#bindTableBody17').html("");
                //$("#PersionalDetailsDiv").css("display", "none");
                //alert(familydata);
                if (familydata != null) {

                    var i = 1;
                    familydata.forEach(function (user) {
                        var row = "<tr><td>" + i + "</td><td>" + checkNullValue(user.Name) + "</td><td>" + checkNullValue(user.Sirname) + "</td><td>" + checkNullValue(user.FileNo) + "</td><td>" + checkNullValue(user.ArcheveNO) + "</td></tr>";
                        $('#bindTableBody17').append(row);
                        //alert(row);
                        i = i + 1;
                    });
                }
            },
            error: function (er) {
                alert(er.responseText);
            }
        });
        $("#RadioBtnReport17").css("display", "block");
    }
    else {
        $("#RadioBtnReport17").css("display", "none");
    }



    if (rdButton == "Course") {
        //alert("working");
        $.ajax({
            url: "/Member/Course?province=" + province,
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (familydata) {
                $('#bindTableBody18').html("");
                //$("#PersionalDetailsDiv").css("display", "none");
                //alert(familydata);
                if (familydata != null) {

                    var i = 1;
                    familydata.forEach(function (user) {
                        var row = "<tr><td>" + i + "</td><td>" + checkNullValue(user.Name) + "</td><td>" + checkNullValue(user.Sirname) + "</td><td>" + checkNullValue(user.Course) + "</td></tr>";
                        $('#bindTableBody18').append(row);
                        //alert(row);
                        i = i + 1;
                    });
                }
            },
            error: function (er) {
                alert(er.responseText);
            }
        });
        $("#RadioBtnReport18").css("display", "block");
    }
    else {
        $("#RadioBtnReport18").css("display", "none");
    }

    if (rdButton == "Degree") {
        //alert("working");
        $.ajax({
            url: "/Member/Degree?province=" + province,
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (familydata) {
                $('#bindTableBody19').html("");
                //$("#PersionalDetailsDiv").css("display", "none");
                //alert(familydata);
                if (familydata != null) {

                    var i = 1;
                    familydata.forEach(function (user) {
                        var row = "<tr><td>" + i + "</td><td>" + checkNullValue(user.Name) + "</td><td>" + checkNullValue(user.Sirname) + "</td><td>" + checkNullValue(user.Course) + "</td></tr>";
                        $('#bindTableBody19').append(row);
                        //alert(row);
                        i = i + 1;
                    });
                }
            },
            error: function (er) {
                alert(er.responseText);
            }
        });
        $("#RadioBtnReport19").css("display", "block");
    }
    else {
        $("#RadioBtnReport19").css("display", "none");
    }

    ////IIndNovitiate
    //if (rdButton == "Novitiate") {
    //    $.ajax({
    //        url: "/Member/NovitiateIIndYear?province=" + province + "&FromDate=" + FromDate + "&ToDate=" + ToDate,
    //        type: "GET",
    //        contentType: "application/json;charset=utf-8",
    //        dataType: "json",
    //        success: function (familydata) {
    //            //alert(familydata.IstNovitiatedata);
    //            $('#bindTableBody15').html("");
    //            //$("#PersionalDetailsDiv").css("display", "none");

    //            if (familydata!= null) {
    //                var i = 1;
    //                familydata.forEach(function (user) {
    //                    var row = "<tr><td>" + i + "</td><td>" + user.Name + "</td><td>" + user.Sirname + "</td><td>" + user.FileNo + "</td><td>" + user.DOB + "</td><td>" + user.FromDate + "</td><td>" + user.Age + "</td></tr>";
    //                    $('#bindTableBody15').append(row);
    //                    i = i + 1;
    //                });



    //            }
    //        },
    //        error: function (er) {

    //        }
    //    });
    //    $("#RadioBtnReport14").css("display", "block");
    //} else {
    //    $("#RadioBtnReport14").css("display", "none");
    //}

    ////Prenoviate
    //if (rdButton == "Novitiate") {
    //    $.ajax({
    //        url: "/Member/PreNovitiate?province=" + province + "&FromDate=" + FromDate + "&ToDate=" + ToDate,
    //        type: "GET",
    //        contentType: "application/json;charset=utf-8",
    //        dataType: "json",
    //        success: function (familydata) {
    //            //alert(familydata.IstNovitiatedata);
    //            $('#bindTableBody16').html("");
    //            //$("#PersionalDetailsDiv").css("display", "none");

    //            if (familydata != null) {
    //                var i = 1;
    //                familydata.forEach(function (user) {
    //                    var row = "<tr><td>" + i + "</td><td>" + user.Name + "</td><td>" + user.Sirname + "</td><td>" + user.FileNo + "</td><td>" + user.DOB + "</td><td>" + user.FromDate + "</td><td>" + user.Age + "</td></tr>";
    //                    $('#bindTableBody16').append(row);
    //                    i = i + 1;
    //                });



    //            }
    //        },
    //        error: function (er) {

    //        }
    //    });
    //    $("#RadioBtnReport14").css("display", "block");
    //} else {
    //    $("#RadioBtnReport14").css("display", "none");
    //}

});

function OpenMemberReport() {
    var url = window.location.href;
    var id = url.substring(url.lastIndexOf('=') + 1);
    if (id != "" && url.includes("?id=")) {
        $("#AllMembers option[value=CMSF1]").attr('selected', 'selected');
        var selectedValues = $("#AllMembers option:selected").val();
        if (selectedValues != "0") {
            $("#btnSearchMember").click();
        }
        $("#forDashboardHide").css("display", "none");
        $(".panel-heading").css("display", "none");
    }
}