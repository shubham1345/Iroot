$(document).ready(function () {
    var weburl = "";
    if (!weburl) weburl = window.location.href
    var array = weburl.split('/');
    var no = array[array.length - 1];
    var update = array[array.length - 2];

    popuplateView(no);
    //var RegstrNo = $("#Jobcode").val();
    //if (RegstrNo != "") {

    //    GetContactPersonDetailsByCompanyId(RegNo);
    //    GetFollowUpDetailsByCompanyId(RegNo);
    //}


    GetContactPersonDetailsView(no);
    GetFollowUpDetailsView(no);

});

  function popuplateView(no) {
    var html = "";

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "/UX/Student.asmx/GetCompanyDetails",
        data: "{'id' : '" + no + "'}",
        dataType: "json",
        success: function (data)
        {
            
            

            

            //console.log(data.d.CompanyName);
            //$("#viewstudent").append("<tr><td><b>Company Name</b><td>" + data.d.CompanyName + "</td><td><b>Company Code</b></td><td>"  + data.d.CompanyCode + "</td></tr>");
            html += "<tr>";
            html += "<td><b>Company Name</b></td><td>" + data.d.CompanyName + "</td>";
            html += "<td><b>Company Code</b></td><td>" + data.d.CompanyCode + "</td>";
            html += "</tr>";

            html += "<tr>";
            html += "<td><b>Source of Data</b></td><td>" + data.d.SourceOfData + "</td>";
            html += "<td><b>Recruitment Start Month</b></td><td>" + data.d.RecruitmentStartMonth + "</td>";
            html += "</tr>";

            html += "<tr>";
            html += "<td><b>Incorporation Status</b></td><td>" + data.d.IncStatustext + "</td>";
            html += "<td><b>Incorporation Date</b></td><td>" + data.d.IncorporationDate + "</td>";
            html += "</tr>";

            html += "<tr>";
            html += "<td><b>Company Type</b></td><td>" + data.d.CompanyType + "</td>";
            html += "<td><b>RefferedBy</b></td><td>" + data.d.RefferedBy + "</td>";
            html += "</tr>";

            html += "<tr>";
            html += "<td><b>Sector</b></td><td>" + data.d.Sector + "</td>";
            html += "<td><b>Company Sub Type</b></td><td>" + data.d.CompanySubType + "</td>";
            html += "</tr>";

            html += "<tr>";
            html += "<td><b>Specialization</b></td><td>" + data.d.Specialization + "</td>";
            html += "<td><b>Total Turnover</b></td><td>" + data.d.TotalTurnover + "</td>";
            html += "</tr>";

            html += "<tr>";
            html += "<td><b>No of Employee</b></td><td>" + data.d.NoofEmployees + "</td>";
            html += "<td><b>Placement Type</b></td><td>" + data.d.PlacementType + "</td>";
            html += "</tr>";

            html += "<tr>";
            html += "<td><b>Company Address</b></td><td>" + data.d.CompanyAddress + "</td>";
            html += "<td><b>City</b></td><td>" + data.d.City + "</td>";
            html += "</tr>";

            html += "<tr>";
            html += "<td><b>Contact Number </b></td><td>" + data.d.ContactNo + "</td>";
            html += "<td><b>Website</b></td><td>" + data.d.Website + "</td>";
            html += "</tr>";

            html += "<tr>";
            html += "<td><b>Company Location</b></td><td>" + data.d.CompanyLocation + "</td>";
            html += "<td><b>Pincode </b></td><td>" + data.d.Pincode + "</td>";
            html += "</tr>";

            html += "<tr>";
            html += "<td><b>Communications</b></td><td>" + data.d.Communications + "</td>";
            html += "<td><b>PLM status</b></td><td>" + data.d.PLMStatus + "</td>";
            html += "</tr>";

            $("").html("");
            $("#viewcompanytbl").html(html);

            if (data.d.CompanyStatus != null && data.d.CompanyStatus != "") {
                var stat = data.d.CompanyStatus.toLowerCase();
                if (stat == "verified") {
                    $("#checkselected").attr('checked', 'checked');
                    $("#checkselected").attr('disabled', true);
                    $("#checknotselected").attr('disabled', true);
                }

                if (stat == "notverified") {
                    $("#checknotselected").attr('checked', 'checked');
                    $("#checkselected").attr('disabled', true);
                    $("#checknotselected").attr('disabled', true);
                }

                if (stat == "verified" || stat == "notverified") {

                    $("#OfficeUse").show();
                    $("#ContentPlaceHolder1_placementstatusupdate").hide();
                    $("#pl_CMCRemarks").val(data.d.CMCRemarks);
                    $("#ddlPlmntldr_Authorized").html(data.d.UpdatedBy);
                    $("#datepicker").html(data.d.Updatedon);
                }

            }

        

    },
        error: function (result) {
        alert("Error");
    }
    });
  }


  function GetContactPersonDetailsView(no) {


      $.ajax({
          type: "POST",
          contentType: "application/json; charset=utf-8",
          url: "/UX/Student.asmx/getAllContactPersonDetailsByID",
          //url: "../Student.asmx/getFollowUpDetailsById",
          data: "{'CompanyId' : '" + no + "'}",
          dataType: "json",
          success: function (data) {

              for (var i = 0; i < data.d.length; i++) {
                  $("#viewcontact").append("<tr><td>" + data.d[i].ContactPerson + "</td><td>" + data.d[i].Name + "</td><td>" + data.d[i].Designation

                      + "</td><td>" + data.d[i].DirectNo + "</td><td>" + data.d[i].Mobile + "</td><td>" + data.d[i].Email + "</td><td>");

              }

          },
          error: function (result) {
              alert("Error");
          }
      });
  }



  //function GetContactPersonDetailsView(no){
  
  //    $.ajax({
  //        type: "POST",
  //        contentType: "application/json; charset=utf-8",
  //        url: "Student.asmx/getAllContactPersonDetailsByID",
  //        data: "{'CompanyId' : '" + no + "'}",
  //        dataType: "json",
  //        success: function(data)
  //        {
  //            for (var i = 0; i < data.d.length; i++){ 

  //                $("#viewcontact").append("<tr><td hidden='hidden'>" + data.d[i].ContactPerson + "</td><td>" + data.d[i].Name + "</td><td>" + data.d[i].Designation

  //                  + "</td><td>" + data.d[i].DirectNo + "</td><td>" + data.d[i].Mobile + "</td><td>" + data.d[i].Email + "</td><td>");
                      
  //                }
              

  //        },
  //        error: function (result) {
  //            alert("Error");
  //        }
  //    });
  //}
        
        

  function GetFollowUpDetailsView(no) {
      
            
      $.ajax({
          type: "POST",
          contentType: "application/json; charset=utf-8",
          url: "/UX/Student.asmx/getAllFollowUpDetailsByCompanyID",
          //url: "../Student.asmx/getFollowUpDetailsById",
          data: "{'CompanyId' : '" + no + "'}",
          dataType: "json",
          success: function (data)
          {
            
              for (var i = 0; i < data.d.length; i++) {
                  $("#viewfollowUp").append("<tr><td>" + data.d[i].FollowUpDate + "</td><td>" + data.d[i].FollowUpRemark + "</td><td>" + data.d[i].FollowUpRemainderDate

                      + "</td><td>" + data.d[i].RemainderRemark + "</td><td>" + data.d[i].Updatedon + "</td><td>" );
              
              }

          },
          error: function (result) {
              alert("Error");
          }
      });
  }



           


function changestatus() {
    var weburl = "";
    if (!weburl) weburl = window.location.href
    var array = weburl.split('/');
    var no = array[array.length - 1];
    var content = $("#pl_CMCRemarks").val();
    var status = "";
    if ($("#checkselected").is(":checked") || $("#checknotselected").is(":checked")) {
        if ($("#checkselected").is(":checked")) {
            status = "Verified";
        }
        if ($("#checknotselected").is(":checked")) {
            status = "Notverified";
        }

        //if ($("#checknotselected").is(":checked")) {

        var request = JSON.stringify({ RegNo: no, comments: content, updatestatus: status });

        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/UX/Student.asmx/UpdateCompanyStatus",
            //data: "{'RegNo' : '" + no + "'}",
            data: request,
            dataType: "json",
            success: function (data) {
                $("#ddlPlmntldr_Authorized").html(data.d.UpdatedBy);
                $("#datepicker").html(data.d.UpdatedOn);
                $("#OfficeUse").show();
                $("#ContentPlaceHolder1_placementstatusupdate").hide();
                $("#checkselected").attr('disabled', true);
                $("#checknotselected").attr('disabled', true);
                alert("Placement record status changed successfully");
            }
        })
    }
}

 