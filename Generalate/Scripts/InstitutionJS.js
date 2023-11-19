$("#MemberDetailsDiv").css("display", "none");
$("#PersionalDetailsDiv").css("display", "none");
$("#InstitutionDetailsDiv").css("display", "none");
//$("#OrdinationDiv").css("display", "none");
$("#UnderAgesDiv").css("display", "none");
$("#DeathDiv").css("display", "none");
$("#BirthDiv").css("display", "none");
$("#FeastDiv").css("display", "none");
$("#ChronologicalDiv").css("display", "none");

//GetAllPersions();
//GetAllDesignationandInstitution();

function GetAllPersions() {
    $.ajax({
        url: "/Member/GetAllPersions",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            ""
            if (response.length > 0) {
                var allDate = [];
                var omObj = {};
                $('#AllMembers').html('').select2({ data: [{ id: '', text: '' }] });
                allDate.push({ id: '0', text: '-- Select Name --' });
                for (var i = 0; i < response.length; i++) {
                    allDate.push({ id: response[i].MemberId, text: response[i].Knowname });
                }
                $("#AllMembers").html('').select2({
                    data: allDate
                });
            }
        },
        error: function (er) {
            //alert(er);
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

    $("#RadioBtnReport").css("display", "none");
    $("#PersionalDetailsDiv").css("display", "block");
    GetPersionById(memberId);
    GetAllFamilyById(memberId);
    GetAllFormationById(memberId);
    GetAllAcademyById(memberId);
    GetAllAppinmentById(memberId);
    GetAllTravelById(memberId);
    GetAllHealthById(memberId);
    GetAllPassedById(memberId);
})

function GetPersionById(id) {
    $.ajax({
        url: "/Member/GetPrimaryById?id=" + id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (persondata) {
            ""
            $("#PersonKnowName").text(persondata.Knowname);
            $("#personBaptismalName").text(persondata.Baptismialname);
            $("#PersonDateofBirthBaptism").text(persondata.DOB);
            $("#PersonDateofBirthSSLC").text(persondata.DOB1);
            $("#PersonFeastDay").text(persondata.Feastday);
            $("#PersonBloodGroup").text(persondata.Bloodgroup);
            $("#PersonEmailID").text(persondata.emailid);
            $("#PersonMobileNumber").text(persondata.mobilenumber);
            $("#PersonWhatsappNumber").text(persondata.whatsappnumber);
            $("#PersonFacebookId").text(persondata.facebookid);
            $("#PersonTwitterId").text(persondata.twitterid);
            $("#PersonBlog").text(persondata.blog);
            $("#Houseno").text(persondata.house);
            $("#personCity").text(persondata.city);
            $("#personDistrict").text(persondata.district);
            $("#persionState").text(persondata.state);
            $("#personPincode").text(persondata.pin);
            $("#AadharNumber").text(persondata.adhar);
            $("#NameasitisAadhar").text(persondata.nameonadhar);
            $("#Passport").text(persondata.passport);
            $("#Nameasitispassport").text(persondata.nameonpassport);
            $("#UploadPanDoccument").text(persondata.File1);
            $("#NameasitinPAN").text(persondata.File2);
            $("#UploadAdharDoccumentN").text(persondata.File3);
        },
        error: function (er) {
            //alert(er);
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
            ""
            if (familydata != null) {
                var i = 1;
                familydata.forEach(function (user) {
                    var row = "<tr><td>" + i + "</td><td>" + user.Name + "</td><td>" + user.Relationship + "</td><td>" + user.YearOfBirth + "</td><td>" + user.YearOfDeath + "</td><td>" + user.Mobile + "</td><td>" + user.Email + "</td><td>" + user.Address + "</td><td>" + user.EmergencyContact + "</td></tr>";
                    $('#tblFamilyDetails tbody').append(row);
                    i = i + 1;
                })

            }

        },
        error: function (er) {
            //alert(er);
        }
    });
}
function GetAllFormationById(id) {
    $.ajax({
        url: "/Member/GetAllFormationById?id=" + id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (familydata) {
            ""
            if (familydata != null) {
                var i = 1;
                familydata.forEach(function (user) {
                    var row = "<tr><td>" + i + "</td><td>" + user.Institution + "</td><td>" + user.Superior + "</td><td>" + user.Formators + "</td><td>" + user.Novisemaster + "</td><td>" + user.Place + "</td><td>" + user.Receivedby + "</td><td>" + user.Conferredby + "</td><td>" + user.VocationFacilitator + "</td><td>" + user.FileName + "</td></tr>";
                    $('#tblFormation tbody').append(row);
                    i = i + 1;
                })
            }
        },
        error: function (er) {
            //alert(er);
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
            ""
            if (familydata != null) {
                var i = 1;
                familydata.forEach(function (user) {
                    var row = "<tr><td>" + i + "</td><td>" + user.course + "</td><td>" + user.degree + "</td><td>" + user.university + "</td><td>" + user.fromdate + "</td><td>" + user.todate + "</td><td>" + user.classo + "</td><td>" + user.medium + "</td><td>" + user.adress + "</td><td>" + user.Remark + "</td><td>" + user.doc + "</td></tr>";
                    $('#Tbl_Academy tbody').append(row);
                    i = i + 1;
                })
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
            ""
            if (familydata != null) {
                var i = 1;
                familydata.forEach(function (user) {
                    var row = "<tr><td>" + i + "</td><td>" + user.Date + "</td><td>" + user.EffectedDate + "</td><td>" + user.ToDate + "</td><td>" + user.AppointmentType + "</td><td>" + user.drpNameType + "</td><td>" + user.DesignationType + "</td><td>" + user.InstitutionType + "</td><td>" + user.CommunityType + "</td><td>" + user.Superior + "</td></tr>";
                    $('#TblAppointment tbody').append(row);
                    i = i + 1;
                })
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
            if (familydata != null) {
                var i = 1;
                familydata.forEach(function (user) {
                    var row = "<tr><td>" + i + "</td><td>" + user.Name + "</td><td>" + user.SirName + "</td><td>" + user.FromDate + "</td><td>" + user.ToDate + "</td><td>" + user.Place + "</td><td>" + user.Purpose + "</td></tr>";
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
    $.ajax({
        url: "/Member/GetAllHealthById?id=" + id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (familydata) {
            ""
            if (familydata != null) {
                var i = 1;
                familydata.forEach(function (user) {
                    var row = "<tr><td>" + i + "</td><td>" + user.Name + "</td><td>" + user.SirName + "</td><td>" + user.Complaint + "</td><td>" + user.FromDate + "</td><td>" + user.ToDate + "</td><td>" + user.Diagnosis + "</td><td>" + user.Hospital + "</td><td>" + user.Doctor + "</td></tr>";
                    $('#TblHealth tbody').append(row);
                    i = i + 1;
                })
            }
        },
        error: function (er) {
            //alert(er);
        }
    });
}
function GetAllPassedById(id) {
    $.ajax({
        url: "/Member/GetAllPassedById?id=" + id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (familydata) {
            ""
            if (familydata != null) {
                var i = 1;
                familydata.forEach(function (user) {
                    var row = "<tr><td>" + i + "</td><td>" + user.Name + "</td><td>" + user.SirName + "</td><td>" + user.LastCommunity + "</td><td>" + user.Cause + "</td><td>" + user.Date + "</td><td>" + user.Time + "</td><td>" + user.InstitutionPlace + "</td><td>" + user.LastNatureRites + "</td><td>" + user.LastPlaceRites + "</td><td>" + user.ville + "</td><td>" + user.obituary + "</td></tr>";
                    $('#TblPassed tbody').append(row);
                    i = i + 1;
                })
            }
        },
        error: function (er) {
            //alert(er);
        }
    });
}
//Member information details and table
$("#DynamicField").text("Based On Seniority");
$("#agevalue").css("display", "none")
$("#PersionalDetailsDiv").css("display", "none");

$("#btnMemberInfo").on("click", function () {
    $("#DynamicField").text(radioButton);
    var radioButton = $("input[name='optradio']:checked").val();
    var fromdate = $("#fromdate").val();
    var todate = $("#todate").val();
    var age = $("#agevalue").val();

    $.ajax({
        url: "/Member/GetMembersInfo?radioButton=" + radioButton + "&fromdate=" + fromdate + "&todate=" + todate + "&age=" + age,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (elem) {
            //var table = $("#MembersDetail tbody");
            //table.empty();
            //$.each(elem, function () {
            //    table.append("<tr><td>1.</td><td>" + this.Name + " " + this.SirName + "</td><td>" + this.Mobile + "</td>   <td>" + this.VillageTown + "</td><td>" + this.DName + "</td><td><button type='button' class='btn btn-success btn-sm viewreport' data-val=" + this.MemberID + ">View</button></td></tr>");

            //});
            //$("#PersionalDetailsDiv").css("display", "none");


        },
        error: function (er) {
            //alert(er);
        }
    });
})


//Checkbox clicks
$("#AppointmentDiv").css("display", "none")
$("#AcademyDiv").css("display", "none")
$("#FormationDiv").css("display", "none")
$("#HealthDiv").css("display", "none")
$("#TravelDiv").css("display", "none")
$("#deathDiv").css("display", "none")
$("#PrimaryDiv").css("display", "none")
$("#FamilyDiv").css("display", "none")
$("#SacramentDiv").css("display", "none")


$('#chkAppointment').click(function () {
    if ($(this).prop("checked") == true) {
        $("#AppointmentDiv").css("display", "block")
    }
    else if ($(this).prop("checked") == false) {
        $("#AppointmentDiv").hide();
    }
});
$('#chkFormation').click(function () {
    if ($(this).prop("checked") == true) {
        $("#FormationDiv").css("display", "block")
    }
    else if ($(this).prop("checked") == false) {
        $("#FormationDiv").css("display", "none")

    }
});
$('#chkAcademy').click(function () {
    if ($(this).prop("checked") == true) {

        $("#AcademyDiv").css("display", "block")
    }
    else if ($(this).prop("checked") == false) {
        $("#AcademyDiv").css("display", "none")
    }
});
$('#chkHealth').click(function () {
    if ($(this).prop("checked") == true) {

        $("#HealthDiv").css("display", "block")

    }
    else if ($(this).prop("checked") == false) {
        $("#HealthDiv").css("display", "none")

    }
});
$('#chkTravel').click(function () {
    if ($(this).prop("checked") == true) {
        $("#TravelDiv").css("display", "block")
    }
    else if ($(this).prop("checked") == false) {
        $("#TravelDiv").css("display", "none")
    }
});
$('#chkdeath').click(function () {
    if ($(this).prop("checked") == true) {
        $("#deathDiv").css("display", "block")
    }
    else if ($(this).prop("checked") == false) {
        $("#deathDiv").css("display", "none")
    }
});
$('#chkPrimary').click(function () {
    if ($(this).prop("checked") == true) {
        $("#PrimaryDiv").css("display", "block")
    }
    else if ($(this).prop("checked") == false) {
        $("#PrimaryDiv").css("display", "none")
    }
});
$('#chkFamily').click(function () {
    if ($(this).prop("checked") == true) {
        $("#FamilyDiv").css("display", "block")
    }
    else if ($(this).prop("checked") == false) {
        $("#FamilyDiv").css("display", "none")
    }
});
$('#chkSacrament').click(function () {
    if ($(this).prop("checked") == true) {
        $("#SacramentDiv").css("display", "block")
    }
    else if ($(this).prop("checked") == false) {
        $("#SacramentDiv").css("display", "none")
    }
});
$('#chkViewAll').click(function () {
    if ($(this).prop("checked") == true) {
        $("#AppointmentDiv").css("display", "block")
        $("#AcademyDiv").css("display", "block")
        $("#FormationDiv").css("display", "block")
        $("#HealthDiv").css("display", "block")
        $("#TravelDiv").css("display", "block")
        $("#deathDiv").css("display", "block")
        $("#PrimaryDiv").css("display", "block")
        $("#FamilyDiv").css("display", "block")
        $("#SacramentDiv").css("display", "block")

        $("#AppointmentDiv").attr("checked", true);
        $("#AcademyDiv").attr("checked", true);
        $("#FormationDiv").attr("checked", true);
        $("#HealthDiv").attr("checked", true);
        $("#TravelDiv").attr("checked", true);
        $("#deathDiv").attr("checked", true);
        $("#PrimaryDiv").attr("checked", true);
        $("#FamilyDiv").attr("checked", true);
        $("#SacramentDiv").attr("checked", true);

    }
    else if ($(this).prop("checked") == false) {
        $("#AppointmentDiv").css("display", "none")
        $("#AcademyDiv").css("display", "none")
        $("#FormationDiv").css("display", "none")
        $("#HealthDiv").css("display", "none")
        $("#TravelDiv").css("display", "none")
        $("#deathDiv").css("display", "none")
        $("#PrimaryDiv").css("display", "none")
        $("#FamilyDiv").css("display", "none")
        $("#SacramentDiv").css("display", "none")

        $("#AppointmentDiv").attr("checked", false);
        $("#AcademyDiv").attr("checked", false);
        $("#FormationDiv").attr("checked", false);
        $("#HealthDiv").attr("checked", false);
        $("#TravelDiv").attr("checked", false);
        $("#deathDiv").attr("checked", false);
        $("#PrimaryDiv").attr("checked", false);
        $("#FamilyDiv").attr("checked", false);
        $("#SacramentDiv").attr("checked", false);
    }
});


//work for the radio buttons
function GetAllDesignationandInstitution() {
    $.ajax({
        url: "/Member/GetAllDesignationandInstitution",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            debugger
            if (response.length > 0) {
                var allDesignationDate = [];
                var allInstitutionDate = [];
                var omObj = {};
                $('#AllDesignations').html('').select2({ data: [{ id: '', text: '' }] });
                $('#AllInstitutions').html('').select2({ data: [{ id: '', text: '' }] });
                allDesignationDate.push({ id: '0', text: '-- Select Name --' });
                allInstitutionDate.push({ id: '0', text: '-- Select Name --' });
                for (var i = 0; i < response.length; i++) {
                    allDesignationDate.push({ id: response[i].Id, text: response[i].Designation });
                    allInstitutionDate.push({ id: response[i].Id, text: response[i].Institution });
                }
                $("#AllDesignations").html('').select2({
                    data: allDesignationDate
                });
                $("#AllInstitutions").html('').select2({
                    data: allInstitutionDate
                });
            }
        },
        error: function (er) {
            //alert(er);
        }
    });
}

//$("#BasedOnAge").on("change", function () {
//    $("#agevalue").css("display", "block")
//})
//$("#BasedOnDesignation").on("change", function () {
//    $("#AllDesignationsDiv").css("display", "block")
//})
//$("#BasedOnInstitution").on("change", function () {
//    $("#AllInstitutionsDiv").css("display", "block")
//})
$("input[name='optradio']").on("change", function () {
  //debugger;
    var data = $(this).val();
    if (data == "Society") {
        $("#agevalue").css("display", "block")
    } else {
        $("#agevalue").css("display", "none")
    }

    if (data == "Basedonbatch") {
        $("#batchvalue").css("display", "block")
    } else {
        $("#batchvalue").css("display", "none")
    }
    if (data == "BasedOnDesignation") {
        $("#AllDesignationsDiv").css("display", "block")
    } else {
        $("#AllDesignationsDiv").css("display", "none")
    }

    if (data == "BasedOnInstitution") {
        $("#AllInstitutionsDiv").css("display", "block")
    } else {
        $("#AllInstitutionsDiv").css("display", "none")
    }
    // $("#AllInstitutionsDiv").css("display", "block")
})


$("input[name='optradio']").on("change", function () {
  //debugger;
    var data = $(this).val();
    if (data == "BasedOnAge") {
        $("#agevalue").css("display", "block")
    } else {
        $("#agevalue").css("display", "none")
    }

    if (data == "Basedonbatch") {
        $("#batchvalue").css("display", "block")
    } else {
        $("#batchvalue").css("display", "none")
    }
    if (data == "BasedOnDesignation") {
        $("#AllDesignationsDiv").css("display", "block")
    } else {
        $("#AllDesignationsDiv").css("display", "none")
    }

    if (data == "BasedOnInstitution") {
        $("#AllInstitutionsDiv").css("display", "block")
    } else {
        $("#AllInstitutionsDiv").css("display", "none")
    }
    // $("#AllInstitutionsDiv").css("display", "block")
})

$("#RdobtnSearch").on("click", function () {
    $("#PersionalDetailsDiv").css("display", "none");
    $("#RadioBtnReport").css("display", "block");

  //debugger;
    var rdButton = $("input[name='optradio']:checked").val();
    var selectedDesignation = $("#AllDesignations option:selected").text();
    if (rdButton == "BasedOnDesignation") {

        if (selectedDesignation == "-- Select Name --") {
            alert("Please select designation")
            return false;
        } else {
            $.ajax({
                url: "/Member/GetAllAppoinmentByDesignation?name=" + selectedDesignation,
                type: "GET",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (familydata) {
                    $('#DesignationDetail tbody tr').remove();
                    if (familydata != null) {
                        var i = 1;
                        familydata.forEach(function (user) {
                            var row = "<tr><td>" + i + "</td><td>" + user.drpNameType + "</td><td> </td><td>" + user.InstitutionType + "</td><td>" + user.EffectedDate + "</td><td>" + user.ToDate + "</td></tr>";
                            $('#DesignationDetail tbody').append(row);
                            i = i + 1;
                        })
                    }
                    //$("#MemberDetailsDiv").css("display", "block");
                },
                error: function (er) {
                    //alert(er);
                }
            });
            $("#MemberDetailsDiv").css("display", "block");
        }
    }
    else {
        $("#MemberDetailsDiv").css("display", "none");
    }
    if (rdButton == "BasedOnInstitution") {
        debugger
        var selectedInstitution = $("#AllInstitutions option:selected").text();
        if (selectedInstitution == "-- Select Name --") {
            alert("Please select Institution")
            return false;
        } else {
            $.ajax({
                url: "/Member/GetAllInstitutionByInstitution?name=" + selectedInstitution,
                type: "GET",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (familydata) {
                    $('#InstitutionDetail tbody tr').remove();
                    if (familydata != null) {
                        var i = 1;
                        familydata.forEach(function (user) {
                            var row = "<tr><td>" + i + "</td><td>" + user.drpNameType + "</td><td> </td><td>" + user.DesignationType + "</td><td>" + user.EffectedDate + "</td><td>" + user.ToDate + "</td></tr>";
                            $('#InstitutionDetail tbody').append(row);
                            i = i + 1;
                        })
                    }
                },
                error: function (er) {
                    //alert(er);
                }
            });
            $("#InstitutionDetailsDiv").css("display", "block");
        }

    }
    else {
        $("#InstitutionDetailsDiv").css("display", "none");
    }

    if (rdButton == "BasedOnAge") {
        var age = $("#agevalue").val();
        if (age == "") {
            alert("Please enter age");
            return false;
        }
        $.ajax({
            url: "/Member/GetAllPrimaryByAge?age=" + age,
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (familydata) {
                $('#TblUnderAge tbody tr').remove();
                if (familydata != null) {
                    var i = 1;
                    familydata.forEach(function (user) {
                        var row = "<tr><td>" + i + "</td><td>" + user.Knowname + "</td><td>" + user.Baptismialname + "</td><td>" + user.DOB + "</td><td>" + user.Feastday + "</td><td>" + user.Bloodgroup + "</td><td>" + user.emailid + "</td><td>" + user.mobilenumber + "</td></tr>";
                        $('#TblUnderAge tbody').append(row);
                        i = i + 1;
                    })
                }
            },
            error: function (er) {
                //alert(er);
            }
        });
    } else {
        $("#TblUnderAge").css("display", "none");
    }

    if (rdButton == "BasedOnSeniority") {
        $.ajax({
            url: "/Member/BasedOnSeniority",
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (familydata) {
                $('#TblOrdination tbody tr').remove();
                if (familydata != null) {
                    var i = 1;
                    familydata.forEach(function (user) {
                        var row = "<tr><td>" + i + "</td><td>" + user.Knowname + "</td><td>" + user.Baptismialname + "</td><td>" + user.DOB + "</td><td>" + user.emailid + "</td><td>" + user.Ordination + "</td><td>" + user.Year + "</td></tr>";
                        $('#TblOrdination tbody').append(row);
                        i = i + 1;
                    })
                }
            },
            error: function (er) {
                //alert(er);
            }
        });
    } else {
        $("#OrdinationDiv").css("display", "none");
    }

    if (rdButton == "DeathAnnivers") {
        $.ajax({
            url: "/Member/DeathAnnivers",
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (familydata) {
              //debugger;
                alert("qwerd")
                $('#bindTableBody').html("");
                if (familydata != null) {
                    var i = 1;
                    familydata.forEach(function (user) {
                        var row = "<tr><td>" + i + "</td><td>" + user.Name + "</td><td>" + user.SirName + "</td><td>" + user.Date + " : " + user.Time + "</td></tr>";
                        $('#bindTableBody').append(row);
                        i = i + 1;
                    });
                }
            },
            error: function (er) {
                alert(er);
            }
        });
    } else {
        $("#DeathDiv").css("display", "none");
    }

    if (rdButton == "Birthday") {
        $.ajax({
            url: "/Member/Birthday",
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (familydata) {
                $('#TblBirth tbody tr').remove();
                if (familydata != null) {
                    var i = 1;
                    familydata.forEach(function (user) {
                        var row = "<tr><td>" + i + "</td><td>" + user.Knowname + "</td><td>" + user.Baptismialname + "</td><td>" + user.emailid + "</td><td>" + user.DOB + "</td></tr>";
                        $('#TblBirth tbody').append(row);
                        i = i + 1;
                    })
                    $("#BirthDiv").css("display", "block");
                }
            },
            error: function (er) {
                //alert(er);
            }
        });
    } else {
        $("#BirthDiv").css("display", "none");
    }


    if (rdButton == "Feastday") {
        alert("fdd")
        $.ajax({
            url: "/Member/Feastday",
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (familydata) {
                $('#TblFeast tbody tr').remove();
                if (familydata != null) {
                    var i = 1;
                    familydata.forEach(function (user) {
                        var row = "<tr><td>" + i + "</td><td>" + user.Knowname + "</td><td>" + user.Baptismialname + "</td><td>" + user.emailid + "</td><td>" + user.Feastday + "</td></tr>";
                        $('#TblFeast tbody').append(row);
                        i = i + 1;
                    })
                    alert("2");
                    $("#FeastDiv").css("display", "block");
                }
            },
            error: function (er) {
                //alert(er);
            }
        });
    } else {
        $("#FeastDiv").css("display", "none");
    }

    if (rdButton == "Chronologicalorder") {
        $.ajax({
            url: "/Member/Chronologicalorder",
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (familydata) {
                $('#TblChronologicalorder tbody tr').remove();
                if (familydata != null) {
                    var i = 1;
                    familydata.forEach(function (user) {
                        var row = "<tr><td>" + i + "</td><td>" + user.Knowname + "</td><td>" + user.Baptismialname + "</td><td>" + user.emailid + "</td><td>" + user.DOB + "</td></tr>";
                        $('#TblChronological tbody').append(row);
                        i = i + 1;
                    })
                    $("#ChronologicalDiv").css("display", "block");
                }
            },
            error: function (er) {
                //alert(er);
            }
        });
    } else {
        $("#ChronologicalorderDiv").css("display", "none");
    }

    if (rdButton == "Basedonbatch") {
        var year = $("#batchvalue").val();
        if (year == "") {
            alert("Please Enter Year");
            return false;
        }
        $.ajax({
            url: "/Member/Basedonbatch?year=" + year,
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (familydata) {
                $('#TblChronological tbody tr').remove();
                if (familydata != null) {
                    var i = 1;
                    familydata.forEach(function (user) {
                        var row = "<tr><td>" + i + "</td><td>" + user.Knowname + "</td><td>" + user.Baptismialname + "</td><td>" + user.emailid + "</td><td>" + user.DOB + "</td></tr>";
                        $('#TblChronological tbody').append(row);
                        i = i + 1;
                    })
                    $("#ChronologicalDiv").css("display", "block");
                }
            },
            error: function (er) {
                //alert(er);
            }
        });
    } else {
        $("#ChronologicalorderDiv").css("display", "none");
    }
})