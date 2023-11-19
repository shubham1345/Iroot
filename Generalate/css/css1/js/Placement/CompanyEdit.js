
$(document).ready(function () {
    

    //GetAllJobPostDetails();

    //company.aspx?Action=View&Id=16


    var nTotalRecords = $('#selectNumberRecords').val();
    var searchKeyword = $.trim($('#txtSearchBox').val());
    GenerateGridHtml(nTotalRecords, 1, 0, 0, 1, "", "");
    $('#ImgCompanyName').attr('src', '/img/sort_asc.png');

    $('input[type=radio][name=cmptype]').change(function () {
        $("#hdncompanytype").val(this.value);
        AdvanceSearch();
    });

    $('input[type=radio][name=cmpsubtype]').change(function () {
        $("#hdncompanysubtype").val(this.value);
        AdvanceSearch();
    });

    $('input[type=radio][name=cmpstatus]').change(function () {
        $("#hdncompanystatus").val(this.value);
        AdvanceSearch();
    });

    //bind checkbox
    $('.chkcomm').change(function () {
        if ($(this).is(":checked")) {
            var title = $(this).attr("title");
            var val = $("#hdncommunication").val();
            if (val == "") {
                $("#hdncommunication").val(title);
            }
            else {
                $("#hdncommunication").val(val + "," + title);
            }

        }
        else {
            var arr = $("#hdncommunication").val().split(',');
            var itemtoremove = $(this).attr("title");
            arr = jQuery.grep(arr, function (value) {
                return value != itemtoremove;
            });

            $("#hdncommunication").val(arr.toString());

        }
        AdvanceSearch();
    });



    //bind checkbox
    $('.chkplm').change(function () {
        if ($(this).is(":checked")) {
            var title = $(this).attr("title");
            var val = $("#hdnplmstatus").val();
            if (val == "") {
                $("#hdnplmstatus").val(title);
            }
            else {
                $("#hdnplmstatus").val(val + "," + title);
            }
        }
        else {
            var arr = $("#hdnplmstatus").val().split(',');
            var itemtoremove = $(this).attr("title");
            arr = jQuery.grep(arr, function (value) {
                return value != itemtoremove;
            });

            $("#hdnplmstatus").val(arr.toString());
        }
        AdvanceSearch();
    });


});

function resetfilterform() {
    $('.chkcomm').attr('checked', false);
    $('.chkplm').attr('checked', false);

    $('input[name="cmptype"]').attr('checked', false);
    $('input[name="cmpsubtype"]').attr('checked', false);
    $('input[name="cmpstatus"]').attr('checked', false);

    $("#hdncompanytype").val("");
    $("#hdncompanysubtype").val("");
    $("#hdncompanystatus").val("");
    $("#hdncommunication").val("");
    $("#hdnplmstatus").val("");

    var nTotalRecords = $('#selectNumberRecords').val();
    var searchKeyword = $.trim($('#txtSearchBox').val());
    GenerateGridHtml(nTotalRecords, 1, 0, 0, 1, "", "");
    $('#ImgCompanyName').attr('src', '/img/sort_asc.png');
}

function AdvanceSearch() {
    var request = {

        communications: $("#hdncommunication").val(),
        companytype: $("#hdncompanytype").val(),
        companysubtype: $("#hdncompanysubtype").val(),
        plmstatus: $("#hdnplmstatus").val(),
        companystatus: $("#hdncompanystatus").val()
    };


    var nTotalRecords = $("#selectNumberRecords").val();

    GenerateGridHtml(nTotalRecords, 1, 0, 0, 1, "", "|" + JSON.stringify(request));

}

//for no of Pages
$(document).ready(function () {
    $("#selectNumberRecords").change(function () {
        var nTotalRecords = $("#selectNumberRecords").val();
        var sSortKey = $("#hdnSortKey").val();
        var sSortOrder = $("#hdnSortOrder").val();
        var searchKeyword = $.trim($('#txtSearchBox').val());
        GenerateGridHtml(nTotalRecords, 1, 0, 0, sSortKey, sSortOrder, searchKeyword);
    });
});

//Function to search with keyword
function SearchwithKeyword() {
    var nTotalRecords = $("#selectNumberRecords").val();
    var searchKeyword = $.trim($('#txtSearchBox').val());
    if (searchKeyword.length > 0) {
        GenerateGridHtml(nTotalRecords, 1, 0, 0, 1, "", searchKeyword);
    }
    else {
        GenerateGridHtml(nTotalRecords, 1, 0, 0, 1, "", "");
    }
}

//Function to get the nextPage
function GetPageNo(object) {
    var nTotalRecords = $("#selectNumberRecords").val();
    var PageNo = $("#" + object.id).html();
    var minPage = $("#hdnMinPageVal").val();
    var maxPage = $("#hdnMaxPageVal").val();
    var sSortKey = $("#hdnSortKey").val();
    var sSortOrder = $("#hdnSortOrder").val();
    var searchKeyword = $.trim($('#txtSearchBox').val());
    GenerateGridHtml(nTotalRecords, PageNo, minPage, maxPage, sSortKey, sSortOrder, searchKeyword);
}

function GetNextPage() {
    var nTotalRecords = $("#selectNumberRecords").val();
    var CurrentPageNo = $("#hdnCurrentPageNo").val();
    var pageNo = parseInt(CurrentPageNo) + parseInt(1);
    var minPage = $("#hdnMinPageVal").val();
    var maxPage = $("#hdnMaxPageVal").val();
    var sSortKey = $("#hdnSortKey").val();
    var sSortOrder = $("#hdnSortOrder").val();
    var searchKeyword = $.trim($('#txtSearchBox').val());
    GenerateGridHtml(nTotalRecords, pageNo, minPage, maxPage, sSortKey, sSortOrder, searchKeyword);
}

function GetLastPage() {
    var nTotalRecords = $("#selectNumberRecords").val();
    var minPage = $("#hdnMinPageVal").val();
    var maxPage = $("#hdnMaxPageVal").val();
    var sSortKey = $("#hdnSortKey").val();
    var sSortOrder = $("#hdnSortOrder").val();
    var searchKeyword = $.trim($('#txtSearchBox').val());
    GenerateGridHtml(nTotalRecords, 0, minPage, maxPage, sSortKey, sSortOrder, searchKeyword);
}

function GetPreviousPage() {
    var nTotalRecords = $("#selectNumberRecords").val();
    var CurrentPageNo = $("#hdnCurrentPageNo").val();
    var minPage = $("#hdnMinPageVal").val();
    var maxPage = $("#hdnMaxPageVal").val();
    var sSortKey = $("#hdnSortKey").val();
    var sSortOrder = $("#hdnSortOrder").val();

    var searchKeyword = $.trim($('#txtSearchBox').val());
    if (CurrentPageNo > 1) {
        var pageNo = parseInt(CurrentPageNo) - parseInt(1);

    }
    else {
        pageNo = CurrentPageNo;
    }
    GenerateGridHtml(nTotalRecords, pageNo, minPage, maxPage, sSortKey, sSortOrder, searchKeyword);
}

function GetToFirstPage() {
    var nTotalRecords = $('#selectNumberRecords').val();
    var searchKeyword = $.trim($('#txtSearchBox').val());
    GenerateGridHtml(nTotalRecords, 1, 0, 0, 1, "", searchKeyword);
    $('#ImgHotelName').attr('src', '/img/sort_asc.png');
}

//Function to Sort
function SortBy(sKeyName, AncId, ImgID) {
    var nTotalRecords = $("#selectNumberRecords").val();
    var pageNo = $("#hdnCurrentPageNo").val();
    var minPage = $("#hdnMinPageVal").val();
    var maxPage = $("#hdnMaxPageVal").val();
    var sSortKey = $("#hdnSortKey").val();
    var sSortOrder = $("#hdnSortOrder").val();
    var AncObject = $("#" + AncId);
    var ImgObject = $("#" + ImgID);
    var searchKeyword = $.trim($('#txtSearchBox').val());

    ////////////////////////////////////

    $("#ImgCompanyName").attr("src", "/img/sort_both.png");
    $("#ImgCompanyCode").attr("src", "/img/sort_both.png");
    $("#ImgSourceOfData").attr("src", "/img/sort_both.png");
    $("#ImgAncComm").attr("src", "/img/sort_both.png");
    $("#ImgReffered").attr("src", "/img/sort_both.png");
    $("#ImgType").attr("src", "/img/sort_both.png");
    $("#ImgSubType").attr("src", "/img/sort_both.png");
    $("#ImgSector").attr("src", "/img/sort_both.png");
    $("#ImgTurnover").attr("src", "/img/sort_both.png");
    $("#ImgTEmployee").attr("src", "/img/sort_both.png");
    $("#ImgPlacementType").attr("src", "/img/sort_both.png");
    $("#ImgSpecialization").attr("src", "/img/sort_both.png");
    $("#ImgPLMStatus").attr("src", "/img/sort_both.png");
    $("#ImgRecruitment").attr("src", "/img/sort_both.png");
    $("#ImgAddress").attr("src", "/img/sort_both.png");
    $("#ImgLocation").attr("src", "/img/sort_both.png");
    $("#ImgCity").attr("src", "/img/sort_both.png");
    $("#ImgPincode").attr("src", "/img/sort_both.png");
    $("#ImgWebsite").attr("src", "/img/sort_both.png");
    $("#ImgContactNo").attr("src", "/img/sort_both.png");
    $("#ImgRemark").attr("src", "/img/sort_both.png");
    $("#AncStatus").attr("src", "/img/sort_both.png");
    $("#ImgUpdatedOn").attr("src", "/img/sort_both.png");
    $("#ImgUpdatedBy").attr("src", "/img/sort_both.png");


    ///////////////////////////////////

    //sort Key selection is same
    if (sKeyName == sSortKey) {
        if (sSortOrder == "Asc") {
            sSortOrder = "Desc"
            $("#" + ImgID).attr("src", "/img/sort_desc.png");
        }
        else {
            sSortOrder = "Asc"
            $("#" + ImgID).attr("src", "/img/sort_asc.png");
        }
    }
    else {
        sSortKey = sKeyName;
        sSortOrder = "Asc";
        $("#" + ImgID).attr("src", "/img/sort_asc.png");

    }
    GenerateGridHtml(nTotalRecords, pageNo, minPage, maxPage, sSortKey, sSortOrder, searchKeyword);
}



function GenerateGridHtml(nTotalRecords, PageNo, nMinPageVal, nMaxPageVal, sSortCol, sSortOrder, sSearchKey) {
    //alert(nTotalRecords + " " + PageNo + " " + nMinPageVal + " " +  nMaxPageVal + " " +  sSortCol +  " " +  sSortOrder + " " + sSearchKey);
    var items = "";
    try {

        var request =
        {
            nTotalRecords: nTotalRecords,
            PageNo: PageNo,
            nPrevMinPage: nMinPageVal,
            nPrevMaxPage: nMaxPageVal,
            sSortCol: sSortCol,
            sSortOrder: sSortOrder,
            sSerachKey: sSearchKey
        };


        //var sHtml = "<tr><td colspan='11'><div style='width:100%;text-align:center;'><img src='/images/287.gif' alt='' /></div></td></tr>";
        //$("#tbodyDataTable").html(sHtml);
        // SetInProgressContent('tbodyDataTable', 10);
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "Student.asmx/GetCompanyListHtmlForTable",
            data: JSON.stringify(request), //{ nTotalRecords: nTotalRecords, PageNo: PageNo, nPrevMinPage: nMinPageVal, nPrevMaxPage: nMaxPageVal, sSortCol: sSortCol, sSortOrder: sSortOrder, sSerachKey: sSearchKey },
            dataType: "json",

            success: function (result) {



                var item = result.d.split('~');



                var count = $('#selectNumberRecords').val();
                $("#tbodyDataTable").html(item[0].toString());
                $('#DataTable_info').css("display", "block");
                $('#DataTable_paginate').html(item[1].toString());
                $('#DataTable_info').html(item[2].toString());
                //$("#HotelDetails").html(item[3].toString());
            },
            error: function (result) {

                alert("Error");
            }
        });
    } catch (e) {
        //ShowOperationNotCompleted();
    }
}




//Get All COS
function GetAllJobPostDetails() {
   
    var tb = document.getElementById('Studenttbl');
    while (tb.rows.length > 1) {
        tb.deleteRow(1);
    }

    $("#jobpost").empty();

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "Student.asmx/GetAllCompanyDetails",
        data: "{'RegNo' : '" + RegstrNo + "'}",
        dataType: "json",
        success: function (data){
            for (var i = 0; i < data.d.length; i++) {
                $("#Studenttbl").append("<tr><td hidden='hidden'>" + data.d[i].Companyid + "</td><td>" + data.d[i].CompanyName + "</td><td>" + data.d[i].Jobcode
                    + "</td><td>" + data.d[i].SourceOfData + "</td><td>" + data.d[i].Communications + "</td><td>" + data.d[i].DateofCommunication + "</td><td>" + data.d[i].CompanyType + "</td><td>"
                    + '<a href="Company.aspx?Action=View&Id=' + data.d[i].Companyid + '&Jobcode=' + data.d[i].Jobcode + '">View</a> | <a href="Company.aspx?Action=Update&Id=' + data.d[i].Companyid + '&Jobcode=' + data.d[i].Jobcode + '">Edit</a> | <a href="#" onclick="DeleleJobsPosts(' + data.d[i].Companyid + ')">Delete</a></td><tr>');
            }

            InitializeDataTable();

        },
        error: function (result) {
            alert("Error");
        }
    });
}

//Interested
function DeleteCompany(ID) {

    var ans = confirm("Are you sure you want to delete this record?");

    if (ans) {

        $.ajax({
            url: "Student.asmx/DeleteCompany",
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            data: "{id:'" + ID + "'}",
            success: function (result) {
                
                alert("Company deleted Successfully.");

                //reload grid
                var nTotalRecords = $('#selectNumberRecords').val();
                var searchKeyword = $.trim($('#txtSearchBox').val());
                GenerateGridHtml(nTotalRecords, 1, 0, 0, 1, "", "");
                $('#ImgCompanyName').attr('src', '/img/sort_asc.png');
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}