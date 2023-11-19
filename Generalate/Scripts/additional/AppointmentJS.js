$(document).ready(function () {
    GetAllSuperior();
});
function GetAllSuperior() {
    //debugger;
    $.ajax({
        url: "/EntryLife/GetAllSuperior",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response1) {
            if (response1.length > 0) {
                var allDate1 = [];
                var omObj1 = {};
                $('#SuperiorAppo').html('').select2({ data: [{ id: '', text: '' }] });
                allDate1.push({ id: '0', text: '-- Select Name --' });
                for (var i = 0; i < response1.length; i++) {
                    allDate1.push({ id: response1[i].Name, text: response1[i].Name });
                }
                $("#SuperiorAppo").html('').select2({
                    data: allDate1
                });
            }
        },
        error: function (er) {
            //alert(er);
        }
    });
}
$("#AppointmentType").on("change", function () {
    var dataListName = $(this).val();
    GetDataListItemsByDataListName(dataListName);
});

function GetDataListItemsByDataListName(name) {
    var persionId = $.urlParam('persionId');
    window.location.href = "/EntryLife/Details?persionId=" + persionId + "&dataListName=" + name;
}

var dataListName = $.urlParam('dataListName');
$('#AppointmentType option[value="' + dataListName + '"]').attr("selected", "selected");

//update records 
$(".AppointmentEdit").on('click', function () {
    $('#AppointmentForm').attr('action', '/EntryLife/AppointmentUpdate');
    var AppID = $(this).attr("data-val");
    $("#btnAppointmentSave").text("Update");
    GetAppointmentById(AppID);
    $(".panel-body").scrollTop(0);
});
function deleteCommAppointment(id) {
    //var AppID = $(this).attr("data-val");
    if (confirm("Do you want to delete ?")) {
        window.location.href = "/EntryLife/AppoinmentDelete?id=" + id;
    }
}
function updateCommAppointment(id) {
    $('#AppointmentForm').attr('action', '/EntryLife/AppointmentUpdate');
    //var AppID = $(this).attr("data-val");
    $("#btnAppointmentSave").text("Update");
    GetAppointmentById(id);
    $(".panel-body").scrollTop(0);
}

function GetAppointmentById(AppID) {
    //debugger;
    $.ajax({
        url: "/EntryLife/GetAppointmentById?id=" + AppID,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

            //debugger;
            if (result != null) {
                //alert(result.AppointmentType);
                $("#AppId").val(result.Id);
                $("#AppMemberId").val(result.MemberId);
                $("#AppTitle").val(result.Title);
                $("#Date2").val(result.Date);
                $("#Apointfile").text(result.doc);
                $("#FromDateappo12").val(result.FromDate);
                $("#ToDateappo12").val(result.ToDate);
                $("#AppDescription").val(result.Description);
                $("#Status").val(result.Status);
                $("#ProvinceName").val(result.ProvinceName);
                $("#mandate").val(result.Mandate);
                $("#Place123").val(result.Place);

                if (result.AppointmentType == "OSPro") {
                    //$("#RDOtherProvince").prop("checked", true).trigger('change');
                    $("#RDDiocese").prop("checked", false);
                    $("#RDPresentProvince").prop("checked", false);
                    $("#RDOtherProvince").prop("checked", false);
                    $("#RDMyGen").prop("checked", false);
                    $("#RDOSPro").prop("checked", true);
                    $("#RDOSPro").prop("checked", true).trigger('change');
                }

                $('#ProvinceDrop1 option[value="' + result.ProvinceName + '"]').attr("selected", "selected");
                $('#ProvinceDrop1').val(result.ProvinceName).change();
                GetAllPersions($("#ProvinceDrop1 option:selected").val());
                $("#MemberId").val(result.MemberId);
                $('#persionNames option[value="' + result.MemberId + '"]').attr("selected", "selected");
                $('#persionNames').val(result.MemberId).change();

                $('#CommunityType22 option[value="' + result.CommunityType + '"]').attr("selected", "selected");
                $('#CommunityType22').val(result.CommunityType).change();

                $('#InstitutionType2 option[value="' + result.InstitutionType + '"]').attr("selected", "selected");
                $('#InstitutionType2').val(result.InstitutionType).change();

                //debugger;
                $('#CommunityType option[value="' + result.CommunityType + '"]').attr("selected", "selected");
                $('#CommunityType').val(result.CommunityType).change();

                // var ddsd = "BANGALORE (Lake Montfort School) - 1998";
                //var ddsd = "BANGALORE(LakeMontfortSchool)-1998";
                //$('#CommunityType option[value="' + ddsd + '"]').attr("selected", "selected");
                //$('#CommunityType').val(ddsd).change();


                $('#InstitutionType option[value="' + result.ParisData + '"]').attr("selected", "selected");
                $('#InstitutionType').val(result.ParisData).change();

                $('#SGGeneralate option[value="' + result.SGGeneralate + '"]').attr("selected", "selected");
                $('#SGGeneralate').val(result.SGGeneralate).change();

                $('#SuperiorAppo option[value="' + result.Superior + '"]').attr("selected", "selected");
                $('#SuperiorAppo').val(result.Superior).change();

                $('#appoParish option[value="' + result.ParisData + '"]').attr("selected", "selected");
                $('#appoParish').val(result.ParisData).change();

                $('#appoDiocese option[value="' + result.Diocese + '"]').attr("selected", "selected");
                $('#appoDiocese').val(result.Diocese).change();
                //debugger;
                $('#appoOSPro option[value="' + result.OSProvince + '"]').attr("selected", "selected");
                $('#appoOSPro').val(result.OSProvince).change();

                $('#CommunityType111 option[value="' + result.CommunityType + '"]').attr("selected", "selected");
                $('#CommunityType111').val(result.CommunityType).change();

                //$('#CommunityType option[vaue="' + result.CommunityType + '"]').attr("selected", "selected");
                //$('#CommunityType').val(result.CommunityType).change();

                $('#appoOSCong option[value="' + result.OSCongName + '"]').attr("selected", "selected");
                $('#appoOSCong').val(result.OSCongName).change();

                $('#appoCongPro option[value="' + result.OSCongProvince + '"]').attr("selected", "selected");
                $('#appoCongPro').val(result.OSCongProvince).change();

                $('#appoDiocese option[value="' + result.Diocese + '"]').attr("selected", "selected");
                $('#appoDiocese').val(result.Diocese).change();

                var value = result.InstitutionType;

                if (value != null || value != undefined) {
                    var valuedata = result.InstitutionType.split(",");
                    $('#InstitutionType').multipleSelect('setSelects', valuedata);
                }
                var valuea = result.InstitutionType;
                if (valuea != null || valuea != undefined) {
                    var valuedataa = result.InstitutionType.split(",");
                    $('#InstitutionType1').multipleSelect('setSelects', valuedataa);
                    $('#InstitutionType2').multipleSelect('setSelects', valuedataa);

                }


                var valueb = result.InstitutionType;

                if (valueb != null || valueb != undefined) {
                    var valuedatab = result.InstitutionType.split(",");
                    $('#InstitutionType2').multipleSelect('setSelects', valuedatab);
                }
                var valuec = result.InstitutionType;
                if (valuec != null || valuec != undefined) {
                    var valuedatac = result.InstitutionType.split(",");
                    $('#InstitutionType3').multipleSelect('setSelects', valuedatac);
                }

                // var value1 = result.CommunityType;

                //debugger;
                //if ((value1 != null || value1 != undefined)) {
                //    var value1data = result.CommunityType.split(",");
                //    $('#CommunityType').val('setSelects', value1data);
                //   // $('#CommunityType22').multipleSelect('setSelects', value1data);
                //    //$('#CommunityType33').multipleSelect('setSelects', value1data);
                //}
                ////todo
                //var value11 = result.CommunityType;
                //if (value11 != null || value11 != undefined) {
                //    var value11data = result.CommunityType.split(",");
                //    $('#CommunityType').val('setSelects', value11data);
                //}
                var value12 = result.CommunityType;
                if (value12 != null || value12 != undefined) {
                    var value12data = result.CommunityType.split(",");
                    $('#CommunityType2').val('setSelects', value12data);
                }

                //debugger;
                var value13 = result.CommunityType;
                if (value13 != null || value13 != undefined) {
                    var value13data = result.CommunityType.split(",");
                    $('#CommunityType3').val('setSelects', value13data);
                    $('#DesignationType4').val('setSelects', value13data);
                }
                // $('#CommunityType').val('setSelects', value1data);
                var value2 = result.DesignationType;
                //  debugger;
                if (value2 != null || value2 != undefined) {
                    var value2data = result.DesignationType.split(",");
                    //$('#DesignationType,#DesignationType3').multipleSelect('setSelects', value2data);
                    //$('#DesignationType3').multipleSelect('setSelects', value2data);
                    //$('#DesignationType').multipleSelect('setSelects', value2data);
                    //$('#DesignationType2').multipleSelect('setSelects', value2data);
                    //$('#DesignationType4').multipleSelect('setSelects', value2data);

                    var designationTypeArray = [];
                    for (var i in value2data) {
                        var optionVal3 = value2data[i];
                        designationTypeArray.push({
                            text: optionVal3,
                            val: optionVal3
                        });
                    }

                    $("#DesignationType,#DesignationType1,#DesignationType2,#DesignationType3,#DesignationType4").ikrSetValuefSelectCombo({
                        List: designationTypeArray,
                        MatchField: "text"
                    });
                }
                var value1 = result.DesignationType;
                $("#updateDesignationType").val(result.DesignationType);
                if (value1 != null || value1 != undefined) {
                    var value1data = result.DesignationType.split(",");
                    $('#DesignationType1').multipleSelect('setSelects', value1data);
                }

                var values = result.DesignationType;
                $.each(values.split(","), function (i, e) {
                    $("#DesignationType3 option[value='" + e + "']").prop("selected", true);
                });



                //$('#DesignationType3 option[value="' + result.DesignationType + '"]').attr("selected", "selected");
                //$('#DesignationType3').val(result.DesignationType).change();

                //  debugger;
                if (result.AppointmentType != null) {
                    $("#AppointmentType").val(result.AppointmentType);
                    $("#RDOSPro,#RDDiocese,#RDPresentProvince,#RDOtherProvince,#RDMyGen").attr("checked", false);

                    if (result.AppointmentType == "PresentProvince") {
                        $("#RDPresentProvince").prop("checked", true).trigger('change');
                    }
                    //else if (result.AppointmentType == "OSPro") {
                    //    //$("#RDOtherProvince").prop("checked", true).trigger('change');
                    //    $("#RDOSPro").prop("checked", true);
                    //    $("#RDOSPro").prop("checked", true).trigger('change');

                    //}
                    else if (result.AppointmentType == "Diocese") {
                        $("#RDDiocese").prop("checked", true);
                        $("#RDDiocese").prop('checked', true).trigger('change');
                    }
                    else if (result.AppointmentType == "MyGen") {
                        $("#RDMyGen").prop("checked", true).trigger('change');

                    }
                    else if (result.AppointmentType == "OtherProvince") {
                        $("#RDOtherProvince").prop("checked", true).trigger('change');
                        // $("#RDOSPro").prop("checked", true).trigger('change');
                    }
                }
                $('#InstitutionType_1 option[value="' + result.ProvinceName + '"]').attr("selected", "selected");
                $('#InstitutionType_1').val(result.ProvinceName).change();
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

$(".AppointmentDelete").on('click', function () {
    var AppID = $(this).attr("data-val");
    if (confirm("Do you want to delete ?")) {
        window.location.href = "/EntryLife/AppoinmentDelete?id=" + AppID;
    }
});


$(".InsAppointmentDelete").on('click', function () {
    var AppID = $(this).attr("data-val");
    if (confirm("Do you want to delete ?")) {
        window.location.href = "/EntryLife/InstututionAppoinmentDelete?id=" + AppID;
    }
});
function deleteInstAppointment(id) {
    if (confirm("Do you want to delete ?")) {
        window.location.href = "/EntryLife/InstututionAppoinmentDelete?id=" + id;
    }
}



//

$(".InsAppointmentEdit").on('click', function () {
    $('#AppointmentForm').attr('action', '/EntryLife/AppointmentUpdate');
    var AppID = $(this).attr("data-val");
    $('#btnInsAppointmentSave').css('display', 'none');
    $('#btnInsAppointmentUpdate').css('display', 'block');
    GeInstAppointmentById(AppID);
    // $(".panel-body").scrollTop(0);
    localStorage.setItem("EditingInsAppointmentId", AppID);
});
function updateInstAppointment(id) {
    $('#AppointmentForm').attr('action', '/EntryLife/AppointmentUpdate');
    //var AppID = $(this).attr("data-val");
    //$("#btnInsAppointmentSave").text("Update");
    $('#btnInsAppointmentSave').css('display', 'none');
    $('#btnInsAppointmentUpdate').css('display', 'block');
    GeInstAppointmentById(id);
    // $(".panel-body").scrollTop(0);
    localStorage.setItem("EditingInsAppointmentId", id);
}
function GeInstAppointmentById(AppID) {
    // alert(AppID)
    $.ajax({
        url: "/EntryLife/GetInsAppointmentById?id=" + AppID,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result != null) {
                $("#IAppId").val(result.Id);
                $("#IAppMemberId").val(result.MemberId);
                $("#IAppTitle").val(result.Title);
                $("#IDate2").val(result.Date);
                $("#IApointfile").text(result.doc);
                $("#Status2").val(result.Status);

                $("#IFromDateappo12").val(result.FromDate);
                $("#IToDateappo12").val(result.ToDate);
                $("#IAppDescription").val(result.Description);
                $("#ProvinceDrop1_ins").val(result.ProvinceName).change();

                //$('#ProvinceDrop1 option[value="' + result.ProvinceName + '"]').attr("selected", "selected");
                //$('#ProvinceDrop1').val(result.ProvinceName).change();
                //GetAllPersions($("#ProvinceDrop1 option:selected").val());
                $("#MemberId").val(result.MemberId);
                $('#persionNames_ins option[value="' + result.MemberId + '"]').attr("selected", "selected");
                $('#persionNames_ins').val(result.MemberId).change();



                //IappoDiocese
                //IappoParish
                $('#CommunityType22 option[value="' + result.CommunityType + '"]').attr("selected", "selected");
                $('#CommunityType22').val(result.CommunityType).change();

                $('#InstitutionType2 option[value="' + result.InstitutionType + '"]').attr("selected", "selected");
                $('#InstitutionType2').val(result.InstitutionType).change();

                //debugger;
                $('#CommunityType option[value="' + result.CommunityType + '"]').attr("selected", "selected");
                $('#CommunityType').val(result.CommunityType).change();



                $('#InstitutionType option[value="' + result.ParisData + '"]').attr("selected", "selected");
                $('#InstitutionType').val(result.ParisData).change();

                $('#SGGeneralate option[value="' + result.SGGeneralate + '"]').attr("selected", "selected");
                $('#SGGeneralate').val(result.SGGeneralate).change();

                $('#SuperiorAppo option[value="' + result.Superior + '"]').attr("selected", "selected");
                $('#SuperiorAppo').val(result.Superior).change();

                $('#appoParish option[value="' + result.ParisData + '"]').attr("selected", "selected");
                $('#appoParish').val(result.ParisData).change();

                $('#appoDiocese option[value="' + result.Diocese + '"]').attr("selected", "selected");
                $('#appoDiocese').val(result.Diocese).change();

                //$('#appoOSPro option[value="' + result.OSProvince + '"]').attr("selected", "selected");
                //$('#appoOSPro').val(result.OSProvince).change();
                $('#IappoOSPro').val(result.OSProvince);

                $('#CommunityType111 option[value="' + result.CommunityType + '"]').attr("selected", "selected");
                $('#CommunityType111').val(result.CommunityType).change();

                //$('#CommunityType option[vaue="' + result.CommunityType + '"]').attr("selected", "selected");
                //$('#CommunityType').val(result.CommunityType).change();

                $('#appoOSCong option[value="' + result.OSCongName + '"]').attr("selected", "selected");
                $('#appoOSCong').val(result.OSCongName).change();

                $('#appoCongPro option[value="' + result.OSCongProvince + '"]').attr("selected", "selected");
                $('#appoCongPro').val(result.OSCongProvince).change();

                $('#appoDiocese option[value="' + result.Diocese + '"]').attr("selected", "selected");
                $('#appoDiocese').val(result.Diocese).change();

                var value = result.InstitutionType;

                if (value != null || value != undefined) {
                    var valuedata = result.InstitutionType.split(",");
                    $('#InstitutionType').multipleSelect('setSelects', valuedata);
                }
                var valuea = result.InstitutionType;
                if (valuea != null || valuea != undefined) {
                    var valuedataa = result.InstitutionType.split(",");
                    $('#InstitutionType1').multipleSelect('setSelects', valuedataa);
                    $('#InstitutionType2').multipleSelect('setSelects', valuedataa);

                }


                var valueb = result.InstitutionType;

                if (valueb != null || valueb != undefined) {
                    var valuedatab = result.InstitutionType.split(",");
                    $('#InstitutionType2').multipleSelect('setSelects', valuedatab);
                }
                var valuec = result.InstitutionType;
                if (valuec != null || valuec != undefined) {
                    var valuedatac = result.InstitutionType.split(",");
                    $('#InstitutionType3').multipleSelect('setSelects', valuedatac);
                }


                var value12 = result.CommunityType;
                if (value12 != null || value12 != undefined) {
                    var value12data = result.CommunityType.split(",");
                    $('#CommunityType2').val('setSelects', value12data);
                }
                var value13 = result.CommunityType;
                if (value13 != null || value13 != undefined) {
                    var value13data = result.CommunityType.split(",");
                    $('#CommunityType3').val('setSelects', value13data);
                    $('#DesignationType4').val('setSelects', value13data);
                }

                var value1 = result.InsDesignationType;
                if (value1 != null || value1 != undefined) {
                    var value1data = result.InsDesignationType.split(",");
                    $('#InsDesignationType1').multipleSelect('setSelects', value1data);
                }

                var values = result.InsDesignationType;
                $.each(values.split(","), function (i, e) {
                    $("#IDesignationType3 option[value='" + e + "']").prop("selected", true);
                });



                //$('#DesignationType3 option[value="' + result.DesignationType + '"]').attr("selected", "selected");
                //$('#DesignationType3').val(result.DesignationType).change();

                //  debugger;
                if (result.AppointmentType != null) {

                    $("#IAppointmentType").val(result.AppointmentType);
                    $("#IRDOSPro,#IRDDiocese,#IRDPresentProvince,#IRDOtherProvince,#IRDMyGen").attr("checked", false);

                    if (result.AppointmentType == "PresentProvince") {
                        $("#IRDPresentProvince").prop("checked", true).trigger('change');
                    }
                    else if (result.AppointmentType == "OSPro") {
                        //$("#IRDOtherProvince").prop("checked", true).trigger('change');
                        $("#IRDOSPro").prop("checked", true).trigger('change');

                    }
                    else if (result.AppointmentType == "Diocese") {
                        $("#IRDDiocese").prop("checked", true);
                        $("#IRDDiocese").prop('checked', true).trigger('change');
                    }
                    else if (result.AppointmentType == "MyGen") {
                        $("#IRDMyGen").prop("checked", true).trigger('change');

                    }
                    else if (result.AppointmentType == "OtherProvince") {
                        $("#IRDOtherProvince").prop("checked", true).trigger('change');
                        // $("#IRDOSPro").prop("checked", true).trigger('change');
                    }
                    $('#ISGGeneralate option[value="' + result.SGGeneralate + '"]').attr("selected", "selected");
                    $('#ISGGeneralate').val(result.SGGeneralate).change();

                    $('#IappoDiocese option[value="' + result.Diocese + '"]').attr("selected", "selected");
                    $('#IappoDiocese').val(result.Diocese).change();
                    DioceseBasedParisLoadDD(2);
                    $('#IappoParish option[value="' + result.ParisData + '"]').attr("selected", "selected");
                    $('#IappoParish').val(result.ParisData).change();
                    //  alert($('#IappoParish').val() + "-" + result.ParisData)
                    $('#IappoOSCong').val(result.OSCongName);
                    $('#IappoCongPro').val(result.OSCongProvince);

                    $("#IformforPresentProvinceTbl tbody").html("");
                    PresentProvinceCnt = 0;
                    //AddIPresentProvinceaddRow();
                    //debugger;

                    $.when(AddIPresentProvinceaddRow(true)).done(function (a1) {
                        //debugger;
                        var designationType = result.InsDesignationType.split(",");

                        var insdesignationTypeArray = [];
                        for (var i in designationType) {
                            var optionVal3 = designationType[i];
                            insdesignationTypeArray.push({
                                text: optionVal3,
                                val: optionVal3
                            });
                        }

                        for (var k = 1; k <= PresentProvinceCnt; k++) {
                            //$('#InsDesignationType_' + k).multipleSelect('setSelects', designationType);

                            $("#InsDesignationType_" + k).ikrSetValuefSelectCombo({
                                List: insdesignationTypeArray,
                                MatchField: "val"
                            });
                            $("#InsDesignationType_Hidden").val(result.InsDesignationType);
                            //alert("called");
                            $("#IApointfile_" + k).text(result.doc);
                            //alert(result.InstitutionType);
                            $('#InstitutionType_' + k + ' option[value="' + result.InstitutionType + '"]').attr("selected", "selected");
                            $('#InstitutionType_' + k).val(result.InstitutionType).change();
                        }
                    });
                }
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

