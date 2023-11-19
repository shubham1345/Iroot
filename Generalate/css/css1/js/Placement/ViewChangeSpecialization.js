$(document).ready(function () {

    var weburl = "";
    if (!weburl) weburl = window.location.href
    var array = weburl.split('/');
    var no = array[array.length - 1];
    var update = array[array.length - 2];

    LoadChangeOfSpecializationDetails(no)
}
);

function LoadChangeOfSpecializationDetails(no) {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../Student.asmx/getCOSById",
        data: "{'id' : '" + no + "'}",
        dataType: "json",
        success: function (data) {

            

            $("#viewcos").append("<tr><td><b>Change Of Specialization Date</b><td>" + data.d[0].COSDate + "</td><td><b>Scollar Number</b></td><td>" + data.d[0].RegisterNumber + "</td></tr>"
                                 + "<tr><td><b>Batch</b><td>" + data.d[0].Batch + "</td><td><b>Student Name</b></td><td>" + data.d[0].StudentName + "</td></tr>"
                                 + "<tr><td><b>Changing Specialization To</b><td>" + data.d[0].Changingspecialization + "</td><td><b>Changing Specialization from</b></td><td>" + data.d[0].CurrentSpecialization + "</td></tr>"
                                 + "<tr><td><b>Reason</b></td><td>" + data.d[0].Reason + "</td></tr>");

            $("#pl_CMCRemarks").val(data.d[0].CMCRemarks);

            var status = data.d[0].Spare2;
            if (status == "verified") {
                $("#checkselected").prop("checked", true);
                $("#checknotselected").prop("checked", false);
                $("#ContentPlaceHolder1_placementstatusupdate1").hide();
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
            //if (data.d[0].Spare2 == "Not selected") {
            //    $("#checkselected").prop("checked", false);
            //    $("#checknotselected").prop("checked", true);
            //}


            document.getElementById('ddlPlmntldr_Authorized').innerHTML = data.d[0].Authorized;
            document.getElementById('datepicker').innerHTML = data.d[0].Spare1;

            //var str = "";
            //str += "<table>";

            //str+= "<tr><td><b>Change Of Specialization Date</b><td>" + data.d[0].COSDate + "</td><td><b>Scollar Number</b></td><td>" + data.d[0].RegisterNumber + "</td></tr>"
            //str += "<tr><td><b>Batch</b><td>" + data.d[0].Batch + "</td><td><b>Student Name</b></td><td>" + data.d[0].StudentName + "</td></tr>"
            //str += "<tr><td><b>Changing Specialization To</b><td>" + data.d[0].Changingspecialization + "</td><td><b>Changing Specialization from</b></td><td>" + data.d[0].CurrentSpecialization + "</td></tr>"
            //str += "<tr><td><b>Reason</b></td><td>" + data.d[0].Reason + "</td><td><b>Status</b></td><td>" + data.d[0].Spare2 + "</td></tr>"



            //str += "<tr><td></td><td>" + +"</td></tr>";
            //str += "</table>"

        },
        error: function (result) {
            alert("Error");
        }
    })
}



