$(document).ready(function () {
    GetAllCommunity();
    GetAllSuperior();
});

$(document).ready(function () {
    $("#btnFormationSave").on("click", function () {
        Add();
    });
    $("#btnFormationUpdate").css("display", "none");
  
});

$(document).on('click', '#btnClear', function () {
    $("#btnFormationSave").css("display", "block");
    clearall();
});

function Add() {
    var datenow = new Date();
    var formationViewModel =
    {
        Name: $('#PName').text(),
        SirName: $('#PSirName').text(),
        MemberId: $('#PMemberId').text(),
        StageOfFormation: $('#StageOfFormation').val(),
        FromDate: $('#FromDate').val(),
        ToDate: $('#ToDate').val(),
        Formators: $('#Formators').val(),
        Community: $('#Community').val(),
        FileName: $('#FileName').val()
    }

    $.ajax({
        url: "/EntryLife/AddFormation",
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        data: JSON.stringify(formationViewModel),
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
    $("#Description").val("");
    $("#Date").val("");
    $("#Title").val("");
    $("#Institution").val("");
    $("#Formators").val("");
    $("#Novisemaster").val("");
    $("#Place").val("");
    $("#Receivedby").val("");
    $("#Conferredby").val("");
    $("#Superior").val("");
    $("#VocationFacilitator").val("");
    $("#Description").val("");
    $("#btnFormationDetailSave").val("Save");
    $("#formFormationDetails").attr("action", "/EntryLife/AddFormationDetail");
}
function SaveAddCommunityShort() {
    var Name = $("#CommunityAddData").val();
    if (Name != '' && Name != undefined) {
        //alert(Name);
        $.ajax({
            url: "/EntryLife/AddExtraCommunity",
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            data: JSON.stringify({ Name: Name }),
            success: function (result) {
                alert(Name + " is added successfully");
                GetAllCommunity();
                ChangeProvinceDrop();
            },
            error: function (errormessage) {
                alert(Name + " is added successfully");
                GetAllCommunity();
                ChangeProvinceDrop();
        }
        });
        $("#MyModalCommunity_Short").modal('hide');
    } else {
        return false;
    }
    $("#CommunityAddData").val('');
}
function GetAllCommunity() {
  //debugger;
    $.ajax({
        url: "/EntryLife/GetAllCommunity_All",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response1) {
          //debugger;
            if (response1.length > 0) {
                var allData = [];

                 $('#Communityfor').html('').select2({ data: [{ id: '', text: '' }] });
                $('#CommunityforVows').html('').select2({ data: [{ id: '', text: '' }] });
                var option = '';

                allData.push({ id: '0', text: '-- Select Name --' });
                option = '<option value="0">-- Select Name --</option>';
                for (var i = 0; i < response1.length; i++) {
                  //debugger;
                    allData.push({ id: response1[i], text: response1[i] });
                    option += '<option value="' + response1[i] + '">' + response1[i] + '</option>';

                }
                allData.push({ id: 'Add', text: 'Add Custom Community +' });
                option = '<option value="Add">Add Custom Community +</option>';
                $("#Communityfor").html('').select2({
                    data: allData
                });
                $("#CommunityforVows").html('').select2({
                    data: allData
                });
               // $('#Communityfor').append(option);
                
            }
        },
        error: function (er) {
            //alert(er);
        }
    });
}
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
                $('#superior').html('').select2({ data: [{ id: '', text: '' }] });
                allDate1.push({ id: '0', text: '-- Select Name --' });
                for (var i = 0; i < response1.length; i++) {
                    allDate1.push({ id: response1[i].Name, text: response1[i].Name });
                }
                $("#superior").html('').select2({
                    data: allDate1
                });
            }
        },
        error: function (er) {
            //alert(er);
        }
    });
}
