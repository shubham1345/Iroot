$(document).ready(function () {

    var weburl = "";
    if (!weburl) weburl = window.location.href
    var array = weburl.split('/');
    var no = array[array.length - 1];
    var update = array[array.length - 2];

    LoadProfileAnalysisDetails(no)
}
);

function LoadProfileAnalysisDetails(no) {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../Student.asmx/getProfileAnalysisById",
        data: "{'id' : '" + no + "'}",
        dataType: "json",
        success: function (data) {
           
            $("#viewprofile").append("<tr><td><b>Scholar Number</b><td>" + data.d[0].RegisterNumber + "</td><td><b>Batch</b></td><td>" + data.d[0].Batch + "</td></tr>"
                                 + "<tr><td><b>Course</b><td>" + data.d[0].Course + "</td><td><b>Specialization</b></td><td>" + data.d[0].Specialization + "</td></tr>"
                                 + "<tr><td><b>Student Name</b><td>" + data.d[0].StudentName + "</td><td><b>Mobile No</b></td><td>" + data.d[0].MobileNo + "</td></tr>"
                                 + "<tr><td><b>Degree</b><td>" + data.d[0].Degree + "</td><td><b>Father</b></td><td>" + data.d[0].Father + "</td></tr>"
                                 + "<tr><td><b>Mother</b><td>" + data.d[0].Mother + "</td><td><b>Siblings</b></td><td>" + data.d[0].Siblings + "</td></tr>"
                                 + "<tr><td><b>Strength</b><td>" + data.d[0].Strength + "</td><td><b>Weakness</b><td>" + data.d[0].Weakness + "</td></tr>"
                                  + "<tr><td><b>Student Query</b><td>" + data.d[0].StudentQuery + "</td><td><b>Email</b><td>" + data.d[0].EmailId + "</td></tr>"
                                   + "<tr><td><b>CompanyName</b><td>" + data.d[0].CompanyName + "</td><td><b>Company Address</b><td>" + data.d[0].CompanyAddress + "</td></tr>");


            $("#pl_CMCRemarks").val(data.d[0].CMCRemarks);


            var status = data.d[0].Spare2;
            if (status == "verified") {
                $("#checkselected").prop("checked", true);
                $("#checknotselected").prop("checked", false);
                $("#ContentPlaceHolder1_UpdatechnageSpecialization").hide();
                //$("#checkselected").prop("disabled", "disabled");
                //$("#checknotselected").prop("disabled", "disabled");
            }
            else if (status == "notverified") {
                $("#checkselected").prop("checked", false);
                $("#checknotselected").prop("checked", true);
            }
            else {
                $("#checkselected").prop("checked", false);
                $("#checknotselected").prop("checked", false);
            }


            //if (data.d[0].Spare2 == "selected") {
            //    $("#checkselected").prop("checked", true);
            //    $("#checknotselected").prop("checked", false);
            //    document.getElementById("OfficeUse").style.visibility = "visible";
            //    $("#checkselected").attr('disabled', true);
            //    $("#checknotselected").attr('disabled', true);

            //}
            //if (data.d[0].Spare1 == "Not selected") {
            //    $("#checkselected").prop("checked", false);
            //    $("#checknotselected").prop("checked", true);
            //}


            document.getElementById('ddlPlmntldr_Authorized').innerHTML = data.d[0].Authorized;
            document.getElementById('datepicker').innerHTML = data.d[0].Spare1;



        },
        error: function (result) {
            alert("Error");
        }
    })
}



