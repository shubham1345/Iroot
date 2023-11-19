$(document).ready(function () {

    var weburl = "";
    if (!weburl) weburl = window.location.href
    var array = weburl.split('/');
    var no = array[array.length - 1];
    var update = array[array.length - 2];

    LoadsummerDetails(no)
    LoadDeclarationDetails(no)
}
);

function LoadsummerDetails(no) {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../Student.asmx/getSummerRecommendationById",
        data: "{'id' : '" + no + "'}",
        dataType: "json",
        success: function (data) {

           
            $("#viewsummer").append("<tr><td><b>Scholar Number</b><td>" + data.d[0].RegisterNumber + "</td><td><b>Batch</b></td><td>" + data.d[0].Batch + "</td></tr>"
                                 + "<tr><td><b>Date</b><td>" + data.d[0].Date + "</td><td><b>Specialization</b></td><td>" + data.d[0].Specialization + "</td></tr>"
                                 + "<tr><td><b>Name</b><td>" + data.d[0].Name + "</td><td><b>Class</b></td><td>" + data.d[0].Class + "</td></tr>"
                                 + "<tr><td><b>Div</b><td>" + data.d[0].Div + "</td><td><b>Mobile No</b></td><td>" + data.d[0].MobileNo + "</td></tr>"
                                 + "<tr><td><b>No.of letters  taken till date</b><td>" + data.d[0].LettersTakenTillDate + "</td><td><b>Company Applied For</b></td><td>" + data.d[0].AppliedCompanies + "</td></tr>"
                                 + "<tr><td><b>Company Representative Name</b><td>" + data.d[0].CompanyRepresentativeName + "</td><td><b>Designation</b><td>" + data.d[0].Designation + "</td></tr>"
                                 + "<tr><td><b>Contact No</b><td>" + data.d[0].ContactNo + "</td><td><b>Email</b><td>" + data.d[0].EmailId + "</td></tr>"
                                 + "<tr><td><b>Title of Company Reprsentative</b><td>" + data.d[0].Title1 + "</td><td><b>Title of student</b><td>" + data.d[0].Title2 + "</td></tr>"
                                 + "<tr><td><b>Company Address</b><td  colspan='3'>" + data.d[0].CompanyAddress + "</td></tr>");


           

            if (data.d[0].Interested == "I Will Not be taking assistance through CMC")
            {
                $("#Malechkbox").prop("checked", true);
            }
            else {
                $("#RadioYes").prop("checked", true);
                 }
            

            $("#pl_CMCRemarks").val(data.d[0].CMCRemarks);
            if (data.d[0].Spare2 == "selected") {

                

                //$("#checkselected").prop("checked", true);
                //$("#checknotselected").prop("checked", false);
                document.getElementById("OfficeUse").style.visibility = "visible";
                //$("#checkselected").attr('disabled', true);
                //$("#checknotselected").attr('disabled', true);
                //alert(data.d[0].StartDate);

                $("#pl_CMCRemarks").val(data.d[0].CMCRemarks);
                $("#Fromdate").val(data.d[0].StartDate);
                $("#Todate").val(data.d[0].EndDate);
                $("#Redate").val(data.d[0].revertdate);

                document.getElementById('ddlPlmntldr_Authorized').innerHTML = data.d[0].Authorized;
                document.getElementById('datepicker').innerHTML = data.d[0].Spare1;
                $("#ContentPlaceHolder1_recupdatestatus").hide();
            }
            
        },
        error: function (result) {
            alert("Error");
        }
    })
}

function LoadDeclarationDetails(no) {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../Student.asmx/getSummerRecommendationById",
        data: "{'RegNo' : '" + no + "'}",
        dataType: "json",
        success: function (data) {

            var inter = data.d[0].Spare1;
            var reason = data.d[0].Spare2;
            //var stdname = data.d[0].StudentName;

            if (inter == "No") {
                //hide declaration div.
                $("#agreementdiv").hide();
            }

            //if (data.d[0].Spare1 != undefined && data.d[0].Spare1 != null && data.d[0].Spare1 != "") {
            //    $("#checkselected").prop("checked", true);
            //    $("#checknotselected").prop("checked", false);

            //}
            //else {
            //    $("#checkselected").prop("checked", false);
            //    $("#checknotselected").prop("checked", true);
            //}

            $("#interestedtxt").text(inter);
            $("#reasontxt").text(reason);
            $("#stdname").text(stdname);

            

        },
        error: function (result) {
            alert("Error");
        }
    });
}



