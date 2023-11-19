$(document).ready(function () {

    var weburl = "";
    if (!weburl) weburl = window.location.href
    var array = weburl.split('/');
    var no = array[array.length - 1];
    var update = array[array.length - 2];

    LoadPlacementDetails(no)
}
);

function LoadPlacementDetails(no) {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../Student.asmx/getPlacementLeaderById",
        data: "{'id' : '" + no + "'}",
        dataType: "json",
        success: function (data) {
            $("#viewplacementleader").append("<tr><td><b>Scholar Number</b><td>" + data.d[0].RegisterNumber + "</td><td><b>Batch</b></td><td>" + data.d[0].Batch + "</td></tr>"
                                 + "<tr><td><b>Course</b><td>" + data.d[0].Course + "</td><td><b>Specialization</b></td><td>" + data.d[0].Specialization + "</td></tr>"
                                 + "<tr><td><b>Student Name</b><td>" + data.d[0].StudentName + "</td><td><b>Mobile No</b></td><td>" + data.d[0].MobileNo + "</td></tr>"
                                 + "<tr><td><b>Residence Location</b><td>" + data.d[0].ResidenceLocation + "</td><td><b>Strengths</b></td><td>" + data.d[0].Strengths + "</td></tr>"
                                 + "<tr><td><b>Weaknesses</b><td>" + data.d[0].Weaknesses + "</td><td><b>Reason to be PlacementLeader</b></td><td>" + data.d[0].ReasontobePlacementLeader + "</td></tr>"
                                 + "<tr><td><b>Activities</b><td>" + data.d[0].Activities + "</td></tr>");

            
            $("#pl_CMCRemarks").val(data.d[0].CMCRemarks);

           

            if (data.d[0].Spare1 == "verified") {
                $("#checkselected").prop("checked", true);
                $("#checknotselected").prop("checked", false);
                //if already updated then hide button
                $("#ContentPlaceHolder1_placementstatusupdate").hide();
                document.getElementById("OfficeUse").style.visibility = "visible";
                $("#checkselected").attr('disabled', true);
                $("#checknotselected").attr('disabled', true);

            } else if (data.d[0].Spare1 == "notverified") {

                $("#checkselected").prop("checked", false);
                $("#checknotselected").prop("checked", true);
            }
            else
            {

                $("#checkselected").prop("checked", false);
                $("#checknotselected").prop("checked", false);
            }


            document.getElementById('ddlPlmntldr_Authorized').innerHTML = data.d[0].Authorized;
            document.getElementById('datepicker').innerHTML = data.d[0].PlacementDate;



        },
        error: function (result) {
            alert("Error");
        }
    })
}



