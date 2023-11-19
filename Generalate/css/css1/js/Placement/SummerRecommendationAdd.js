$(document).ready(function () {

    
    var weburl = "";
    if (!weburl) weburl = window.location.href
    var array = weburl.split('/');
    var no = array[array.length - 1];
    var update = array[array.length - 2];

    if (no != "SummerRecommendation.aspx") {
        if (update != "Update") {
            $("#SummerRecommSave_btn").hide();
            $("#SummerRecommUpdate_btn").hide();
            $("#summerrecommendation_headertext").text(" Summer Recommendation Letter");
        }
        else {
            $("#SummerRecommSave_btn").hide();
            $("#SummerRecommUpdate_btn").show();
            $("#summerrecommendation_headertext").text(" Update Summer Recommendation Letter");
        }


        LoadSummerRecomDetailsById(no);
    }

    else {
        $("#SummerRecommUpdate_btn").hide();
        $("#SummerRecommSave_btn").show();
        $("#summerrecommendation_headertext").text(" Add Summer Recommendation Letter");
    }

});


// Add ChageofSpecialization details

  $(function () {
    $('#SummerRecommSave_btn').click(function () { 
        //var Inter;
        //if (Malechkbox.Checked) {
        //    Inter = Malechkbox.Text;
        //}
        //else if (RadioYes.Checked) {
        //    Inter = RadioYes.Text;
        //}
       // this is  for check box  
        var i = $('#Malechkbox').is(':checked');
        var j = $('#RadioYes').is(':checked');
        if (i == true) {

            i = "I Will Not be taking assistance through CMC"
        }
        if (j == true) {
            i = "I Will also be taking assistance through CMC & if selected will join the same company.  I understand, as per placement policy if I do not join or continue in the same company, I will not be eligible for the Final Placement Assistance in future.";

        }
        
        var y = $("#DropDownList2").val();
        if (y == "Mr.") {
            g = "He";
        }
        else {
            g = "She";
        }




        var a = $('#checkselected').is(':checked');
        var b = $('#checknotselected').is(':checked');
        if (a == true)
        {

            a = "selected"
        }
        if (b == true)
        {
            a = "Not selected";

        }
        
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
         
            //Interested: $("#Malechkbox").val(),
            //NotInterested: $("#RadioYes").val(),
            CompanyName: $("#SummerRecomm_Company").val(),
            CompanyAddress: $("#SummerRecomm_CompanyAddress").val(),
            CMCRemarks: $("#sr_CMCRemarks").val(),
            //Authorized: $("#ddlcc_Authorized").val(),
            //Spare1: $("#dateon").val(),
            Spare2: a,
            Interested: i,
            Title1:$("#DropDownList1").val(),
            Title2: $("#DropDownList2").val(),
            gender: g,
        };

        $.ajax({
            type: "POST",
            url: "Student.asmx/AddSummerRecommendation",
            data: JSON.stringify({ 'summerrecomndn': carrier }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                ClearSumerRecom();
                window.location.href = "ManageSummerRecommendation.aspx";


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
    $('#Malechkbox').prop('checked', false);
   

   
}