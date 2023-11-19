$("#AppointmentType").on("change", function () {
    var dataListName = $(this).val();
    GetDataListItemsByDataListName(dataListName);
})

function GetDataListItemsByDataListName(name) {
    var persionId = $.urlParam('persionId');
    window.location.href = "/EntryLife/Details?persionId=" + persionId + "&dataListName=" + name;
}

var dataListName = $.urlParam('dataListName');
$('#AppointmentType option[value="' + dataListName + '"]').attr("selected", "selected");

//update records 
$(document.body).on('click', '.EditAcademy', function () {
    debugger;
    $(".commonGrid").hide();
    $(".membrDetails").show();
    $('#').attr('actAcademyFormion', '/EntryLife/UpdateAcademyDetail');
    var AppID = $(this).attr("data-val");
    $("#btnAcademySave").text("Update");
    GetAcademyById(AppID);
    $(".panel-body").scrollTop(0);
});

$(document.body).on('click', '.DeleteAcademy', function () {

    var AppID = $(this).attr("data-val");
    if (confirm("Do you want to delete ?")) {
        window.location.href = "/EntryLife/AcademicDelete?id=" + AppID;
    }
});

function GetAcademyById(id)
{
    $.ajax({
        url: "/EntryLife/GetAcademyById?id=" + id,
        type: "GET",
        success: function (response)
       
        {
            $("#fromdate12").val(response.fromdate);
            $("#todate123").val(response.todate);


            $('#Course option[value="' + response.course + '"]').attr("selected", "selected");
            $('#course').val(response.course).change();


            $('#degree option[value="' + response.course + '"]').attr("selected", "selected");
            $('#degree').val(response.degree).change();

            //$("#Course").val(response.course);
            //$("#degree").val(response.degree);
            $("#university").val(response.university);
            $("#remark").val(response.remark);
            $("#adress").val(response.adress);
            $("#DescriptionAcademy").val(response.Description);
            $("#acaid").val(response.acaid);
            if (response.doc != null) {
                $("#Acafile123").text(response.doc);
            }
            console.log(response);
        },
        error: function (ex) {

        }

        
    });
}