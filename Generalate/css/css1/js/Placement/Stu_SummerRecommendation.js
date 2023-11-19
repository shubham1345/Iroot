$(document).ready(function () {

    
    var weburl = "";
    if (!weburl) weburl = window.location.href
    var array = weburl.split('/');
    var no = array[array.length - 1];
    var update = array[array.length - 2];

    //if (no != "SummerRecommendation.aspx") {
    //    if (update != "Update") {
    //        $("#SummerRecommSave_btn").hide();
    //        $("#SummerRecommUpdate_btn").hide();
    //        $("#summerrecommendation_headertext").text(" Summer Recommendation Letter");
    //    }
    //    else {
    //        $("#SummerRecommSave_btn").hide();
    //        $("#SummerRecommUpdate_btn").show();
    //        $("#summerrecommendation_headertext").text(" Update Summer Recommendation Letter");
    //    }


    //    LoadSummerRecomDetailsById(no);
    //}

    //else {
    //    $("#SummerRecommUpdate_btn").hide();
    //    $("#SummerRecommSave_btn").show();
    //    $("#summerrecommendation_headertext").text(" Add Summer Recommendation Letter");
    //}

});


// Add ChageofSpecialization details

$(function () {
    $('#SummerRecommSave_btn').click(function () {
        

        var carrier =
        {
            RegisterNumber: $("#ScholarNumber").val(),
            Batch: $("#SummerRecomm_Batch").val(),
            Date: $("#SummerRecomm_Date").val(),
            Specialization: $("#SummerRecomm_Specialization").val(),
            Name: $("#SummerRecomm_ApplicantName").val(),
            Class: $("#SummerRecomm_Class").val(),
            Div: $("#SummerRecomm_Div").val(),
            MobileNo: $("#SummerRecomm_Mobile").val(),
            LettersTakenTillDate: $("#SummerRecomm_Noofletterstilltaken").val(),
            AppliedCompanies: $("#SummerRecomm_Companiesapplied").val(),
            CompanyRepresentativeName: $("#SummerRecomm_CompanyName").val(),
            Designation: $("#SummerRecomm_Designation").val(),
            ContactNo: $("#SummerRecomm_ContactNo").val(),
            EmailId: $("#SummerRecomm_Email").val(),
            CompanyName: $("#SummerRecomm_Company").val(),
            CompanyAddress: $("#SummerRecomm_CompanyAddress").val()
        };

        $.ajax({
            type: "POST",
            url: "Student.asmx/AddSummerRecommendation",
            data: JSON.stringify({ 'summerrecomndn': carrier }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                ClearSumerRecom();
               // window.location.href = "ManageSummerRecommendation.aspx";


            }
        });
    });
});


function ClearSumerRecom() {
    $("#ScholarNumber").val("");
    $("#SummerRecomm_Date").val("");
    $("#SummerRecomm_Batch").val("");
    $("#SummerRecomm_Specialization").val("");
    $("#SummerRecomm_ApplicantName").val("");
    $("#SummerRecomm_Class").val("");
    $("#SummerRecomm_Div").val("");
    $("#SummerRecomm_Mobile").val("");
    $("#SummerRecomm_Noofletterstilltaken").val("");
    $("#SummerRecomm_Companiesapplied").val("");
    $("#SummerRecomm_CompanyName").val("");
    $("#SummerRecomm_Designation").val("");
    $("#SummerRecomm_ContactNo").val("");
    $("#SummerRecomm_Email").val("");
    $("#SummerRecomm_Company").val("");
    $("#SummerRecomm_CompanyAddress").val("");

}