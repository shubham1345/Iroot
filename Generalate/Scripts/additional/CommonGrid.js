$(document).ready(function () {
    
    GetGrid();
    GetAllProvinceView();
    $("#checkedAll").change(function () {
        if (this.checked) {
            $(".checkSingle").each(function () {
                this.checked = true;
            });
        } else {
            $(".checkSingle").each(function () {
                this.checked = false;
            });
        }
    });

    $(".CreateButton").on('click', function (event) {
        $(".membrDetails").show();
        $(".commonGrid").hide();
        event.preventDefault();
    });

    $(".pro").on('click', function (event) {
        event.stopPropagation();
    });
    $('body').on('mouseover', '.select2-search--dropdown', function (event) {
        event.stopPropagation();
    });
    $('body').on('mouseleave', '.uu', function (event) {
        $("#listmenu").show();
        event.stopPropagation();
    });
    $('#example').DataTable({
        dom: 'Bfrtip',
        buttons: [
            'columnsToggle'
        ],
        searching: false,
        paging: false,
        info: false,
        "order": [[1, "asc"]],
        'columnDefs': [{
            'targets': [0, 4, 6, 7], // column index (start from 0)
            'orderable': false, // set orderable false for selected columns
        }]
    });

});
$("#checkbox-grid-1").on('click', function () {
    if ($('input#checkbox-grid-1').prop('checked')) {
        $(".hide-1").show();
    }
    else {
        $(".hide-1").hide();
    }
});
$("#checkbox-grid-2").on('click', function () {
    if ($('input#checkbox-grid-2').prop('checked')) {
        $(".hide-2").show();
    }
    else {
        $(".hide-2").hide();
    }
});
$("#checkbox-grid-3").on('click', function () {
    if ($('input#checkbox-grid-3').prop('checked')) {
        $(".hide-3").show();
    }
    else {
        $(".hide-3").hide();
    }
});
$("#checkbox-grid-4").on('click', function () {
    if ($('input#checkbox-grid-4').prop('checked')) {
        $(".hide-4").show();
    }
    else {
        $(".hide-4").hide();
    }
});
$("#checkbox-grid-5").on('click', function () {
    if ($('input#checkbox-grid-5').prop('checked')) {
        $(".hide-5").show();
    }
    else {
        $(".hide-5").hide();
    }
});
$("#checkbox-grid-6").on('click', function () {
    if ($('input#checkbox-grid-6').prop('checked')) {
        $(".hide-6").show();
    }
    else {
        $(".hide-6").hide();
    }
});
$("#checkbox-grid-7").on('click', function () {
    if ($('input#checkbox-grid-7').prop('checked')) {
        $(".hide-7").show();
    }
    else {
        $(".hide-7").hide();
    }
});
$("#checkbox-grid-8").on('click', function () {
    if ($('input#checkbox-grid-8').prop('checked')) {
        $(".hide-8").show();
    }
    else {
        $(".hide-8").hide();
    }
});
$("#checkbox-grid-9").on('click', function () {
    if ($('input#checkbox-grid-9').prop('checked')) {
        $(".hide-9").show();
    }
    else {
        $(".hide-9").hide();
    }
});
$("#checkbox-grid-10").on('click', function () {
    if ($('input#checkbox-grid-10').prop('checked')) {
        $(".hide-10").show();
    }
    else {
        $(".hide-10").hide();
    }
});
$("#checkbox-grid-11").on('click', function () {
    if ($('input#checkbox-grid-11').prop('checked')) {
        $(".hide-11").show();
    }
    else {
        $(".hide-11").hide();
    }
});
$("#checkbox-grid-12").on('click', function () {
    if ($('input#checkbox-grid-12').prop('checked')) {
        $(".hide-12").show();
    }
    else {
        $(".hide-12").hide();
    }
});
$('.numberonly').keypress(function (e) {

    var charCode = (e.which) ? e.which : event.keyCode

    if (String.fromCharCode(charCode).match(/[^0-9]/g))

        return false;

});
$("#StartingId").on('focusout', function () {
    var firstItem = $("#StartingId").val();
    var lastItem = $("#LastId").val();
    if (firstItem != '' && lastItem != '') {
        GetGrid();
    }
});

$("#LastId").on('focusout', function () {
    var firstItem = $("#StartingId").val();
    var lastItem = $("#LastId").val();
    if (firstItem != '' && lastItem != '') {
        GetGrid();
    }
});
$("#SearchTxt").on('input', function () {
    GetGrid();
});


function openNav() {
    document.getElementById("mySidenav").style.width = "250px";
}

function closeNav() {
    document.getElementById("mySidenav").style.width = "0";
}
$('body').click(function (evt) {
    if (evt.target.id == "mySidenav")
        return;
    else if (evt.target.className == "notdivhide") {
        return;
    }

    else {
        closeNav();
        return;
    }
    //For descendants of menu_content being clicked, remove this check if you do not want to put constraint on descendants.
    if ($(evt.target).closest('#menu_content').length)
        return;

    //Do processing of click event here for every element except with id menu_content

});
$("#ExportMemberData").on('click', function () {
    alert("knk");
    //$("fileDow").click();
    //location.href = '/Member/ExportToExcel';
    //@*var firstItem = $("#StartingId").val();
    //var lastItem = $("#LastId").val();
    //var SearchTxt = $("#SearchTxt").val();
    //var grp = $("#ProvinceName_New").val();
    //alert(firstItem);
    //jQuery.ajax({
    //    url: '/Member/ExportToExcel',
    //    type: "POST",
    //    contentType: "application/json; charset=utf-8",
    //    data: JSON.stringify({ name: 'Deep', firstItem: firstItem, lastItem: lastItem, SearchTxt: SearchTxt, grp: grp }),
    //    success: function (result) {

    //        //alert(@{@HomeController.GetControlTextByControlId("Data Downloaded Successfully");});
    //    },
    //    error: function (err) {
    //        alert(err.statusText);
    //    }
    //});*@
        });
function GetAllProvinceView() {
    $.ajax({
        url: "/Home/GetAllProvinceView",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response2) {

            if (response2.length > 0) {
                var allDate2 = [];
                var omObj2 = {};
                $('#ProvinceName_New').html('').select({ data: [{ id: '', text: '' }] });
                $("#ProvinceName_New").append($("<option></option>").val(0).html('------- @{ @HomeController.GetControlTextByControlId("Select") ;} ------'));
                allDate2.push({ id: '0', text: '-- @{ @HomeController.GetControlTextByControlId("Select") ;} --' });
                for (var i = 0; i < response2.length; i++) {
                    allDate2.push({ id: response2[i].Id, text: response2[i].ProvinceName });
                    $("#ProvinceName_New").append($("<option></option>").val(response2[i].ProvinceName).html(response2[i].ProvinceName));
                    //allDate2.push({ id: response2[i].Id, text: response2[i].ProvinceName + " " + " " + response2[i].Place });
                }
                //$("#ProvinceName_New").html('').select({
                //    data: allDate2
                //});
            }
            $("#ProvinceName_New").select2();
            $('#ProvinceName_New').on('mouseover', function (event) {
                // Do something
                event.stopPropagation();
            });

            // return false;

        },
        error: function (er) {
        }
    });
}

function GetGrid() {
    //alert($("#CommAppointmentDetails2").val());
    var id = $("#membrId").val()
    var name = "";
    if ($("#documentDetails").length > 0) {
        name = "document"
    }
    if ($("#familyDetails").length > 0) {
        name = "family"
    }
    if ($("#sacramentDetails").length > 0) {
        name = "sacrament"
    }
    if ($("#healthDetails").length > 0) {
        name = "health"
    }
    if ($("#formationDetails").length > 0) {
        name = "formation"
    }
    if ($("#academicDetails").length > 0) {
        name = "academy"
    }
    
    if ($("#separationDetails").length > 0) {
        name = "seperation"
    }
    if ($("#claustrationDetails").length > 0) {
        name = "claustration"
    }
    if ($("#retirementDetails").length > 0) {
        name = "retirement"
    }
    if ($("#eternalDetails").length > 0) {
        name = "eternal"
    }
    if ($("#archiveDetails").length > 0) {
        name = "archive"
    }
    if ($("#profsnDetails").length > 0) {
        name = "profession"
    }
    if ($("#CommAppointmentDetails2").val == '1') {
        name = "Appointment"
    }
    //alert(name);
    var SearchTxt = $("#SearchTxt").val();
    var grp = $("#ProvinceName_New").val();
    //alert("kdnv");
    jQuery.ajax({
        url: '/Member/GetPrimaryDetails',
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ id:id,name: name, SearchTxt: SearchTxt }),
        success: function (result) {

            $("#PartialTable").empty();
            $("#PartialTable").html(result);
            $('.notdivhide').prop("checked", true);
           
            $(".commonGrid").show();
            

        },
        error: function (err) {
            alert(err.statusText);
        }
    });
    //@* alert('@ViewBag.totalCount');
    //$("#totalcount").html(@ViewBag.totalCount);*@
        }
function deleteMember(id) {
    //var id = $(this).attr("data-val");
    if (confirm("Do you want to delete ?")) {
        window.location.href = "/Member/DeleteGetMemberById?id=" + id;
    }
}
