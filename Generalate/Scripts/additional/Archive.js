$(document).ready(function () {
    $("#idAddDocument").click(function () {
        $("#myAddFileModal").modal('show');
    });
    $("#idUpdateField").click(function () {
        $("#myModal").modal("show");
        var fieldvalue = $("#FieldName").val();

        callFieldValueMethod(fieldvalue);
    });
    $('#manageClose').click(function () {
        location.reload();
    });
    $("#FieldName").change(function () {
        var fieldvalue = $(this).val();
        callFieldValueMethod(fieldvalue);

    });
    $("#idedit").click(function () {
        $("#myAddFieldModal").modal('show');

    });
    $("#idSerchDocument ").click(function () {
        $("#mySerachDocumentModal").modal('show');

    });
    
    $("#idAdd").click(function () {
        var fieldId = $('#FieldName :selected').val();
        var fiename = $('#FieldName :selected').text();

        var fieldvalue = $('#FieldValueNew').val();
        alert(fieldId + "" + fiename + "" + fieldvalue);
        $.ajax({
            url: "../Archive/SaveFieldvalue",
            type: "GET",
            dataType: "json",
            data: {fieldId: fieldId, fiename: fiename,  fieldvalue: fieldvalue },
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {

                $("#myAddFieldModal").modal('hide');
                callFieldValueMethod(fieldId);
                $('#FieldValueNew').val(" ");
            }
        });

    });
    
    //GASDGASDG
    $("#pidAddDocument").click(function () {
        $("#pmyAddFileModal").modal('show');
       

    });
    $("#pidUpdateField").click(function () {
        $("#pmyModal").modal("show");
        var pfieldvalue = $("#PFieldName").val();

        pcallFieldValueMethod(pfieldvalue);
    });
    $('#pmanageClose').click(function () {
        location.reload();
    });
    $("#PFieldName").change(function () {
        var fieldvalue = $(this).val();
        callFieldValueMethod(fieldvalue);

    });
    $("#pidedit").click(function () {
        $("#pmyAddFieldModal").modal('show');

    });
    $("#pidSerchDocument").click(function () {
        $("#pmySerachDocumentModal").modal('show');
        var d = $(".myaddusr option:selected").val();
        alert(d);
    });

    $("#pidAdd").click(function () {
        var pfieldId = $('#PFieldName :selected').val();
        var pfiename = $('#PFieldName :selected').text();

        var pfieldvalue = $('#FieldValueNewP').val();
        alert(pfieldId + "" + pfiename + "" + pfieldvalue);
        $.ajax({
            url: "../Archive/PSaveFieldvalue",
            type: "GET",
            dataType: "json",
            data: { pfieldId: pfieldId, pfiename: pfiename, pfieldvalue: pfieldvalue },
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {

                $("#pmyAddFieldModal").modal('hide');
                pcallFieldValueMethod(pfieldId);
                $('#FieldValueNewP').val(" ");
            }
        });

    });
});
function callFieldValueMethod(fieldvalue) {
    $.ajax({
        url: "../Archive/GetFieldValues/" + fieldvalue,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        //data : { "DlistName"},
        dataType: "json",
        success: function (result) {
            $("#fieldvaluesbody").empty();
            for (var i = 0; i < result.length; i++) {
                $("#fieldvaluesbody").append("<tr><td>" + result[i].FieldValue + "</td></tr>");
            }
        }
    });
}

function pcallFieldValueMethod(fieldvalue) {
    $.ajax({
        url: "../Archive/PGetFieldValues/" + fieldvalue,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        //data : { "DlistName"},
        dataType: "json",
        success: function (result) {
            $("#pfieldvaluesbody").empty();
            for (var i = 0; i < result.length; i++) {
                $("#pfieldvaluesbody").append("<tr><td>" + result[i].FieldValue + "</td></tr>");
            }
        }
    });
}
function GetDataByLandId(Id) {
    $.ajax({
        url: "../Archive/GetDataByLandId/" + Id,
        type: "GET",
        dataType: 'html',
        success: function (result) {
           
            $('#imageviewer').html(result);
        }
    });
}
function GetDataByPId(Id) {
    $.ajax({
        url: "../Archive/GetDataByPId/" + Id,
        type: "GET",
        dataType: 'html',
        success: function (result) {

            $('#pimageviewer').html(result);
        }
    });
}
