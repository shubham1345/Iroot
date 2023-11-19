$(document).ready(function () {

    GetAllApplyStatus();
});
function getUrlVars() {
    var vars = [], hash;
    var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < hashes.length; i++) {
        hash = hashes[i].split('=');
        vars.push(hash[0]);
        vars[hash[0]] = hash[1];
    }
    return vars;
}
//Get All CarrierCouncelling
function GetAllApplyStatus() {
    var no = getUrlVars()["id"];
    var html = "";
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "Student.asmx/GetAllApplyStatusCompanyID",
        data: "{'id' : '" + no + "'}",
        dataType: "json",
        success: function (data) {
            $("#careertblbody").html("");
            var tabledata = data.d.split('~')[0];
            if (data.d.split('~')[1] == "False") {
                $("#careertblbody").html(tabledata);
                loaddatatable();

            }
            else {
                $("#careertblbody").html(tabledata);
                $('#Studenttbl').dataTable({
                    "paging": false,
                    "searching": true,
                    "columnDefs": [
                        { "orderable": false, "targets": 8 }
                        
                    ]

                });
            }

        },
        error: function (result) {
            alert("Error");
        }
    });
    }

    function loaddatatable() {

        if ($.fn.DataTable.isDataTable('#Studenttbl')) {
            $('#Studenttbl').DataTable().destroy();
        }


        $('#Studenttbl').dataTable({
            "autoWidth": true,
            "columnDefs": [

               { "orderable": false, "targets": 8 }
            ]
        });

    }

    //Delete AcademicDetail
    function DeleleCareerCouncling(ID) {
        var ans = confirm("Are you sure you want to delete this Record?");
        if (ans) {
            $.ajax({
                url: "Student.asmx/DeleteCarrierCouncelling",
                type: "POST",
                contentType: "application/json;charset=UTF-8",
                dataType: "json",
                data: "{id:'" + ID + "'}",
                success: function (result) {
                    window.location.href = "/UX/Carrier.aspx";

                },
                error: function (errormessage) {
                    alert(errormessage.responseText);
                }
            });
        }
    }


//$(document).ready(function () {
//    var weburl = "";
//    if (!weburl) weburl = window.location.href
//    var array = weburl.split('/');
//    var no = array[array.length - 1];
//    var sRole = '<%= Session["role"] %>';
//    LoadCommunicationDetails(no);
   
//});


////Get All CarrierCouncelling
//     function LoadCommunicationDetails(no) {
    
//        var tb = document.getElementById('tblComunicationDetails');
//        $.ajax({
//            type: "POST",
//            contentType: "application/json; charset=utf-8",
//            url: "Student.asmx/GetAllApplyStatus",
//            dataType: "json",
//            success: function (data) {
//                for (var i = 0; i < data.d.length; i++) {
//                    $("#tblComunicationDetails").append("<tr><td>" + (i + 1) + "</td><td >" + data.d[i].ApplyStatusId + "</td><td>" + data.d[i].ScholarNumber + "</td><td>" + data.d[i].StudentName + "</td><td>" + data.d[i].MobileNo
//                            + "</td><td>" + data.d[i].Specialization + "</td><td>" + data.d[i].ApplyDate + "</td><td>" + data.d[i].CompanyCode + "</td><tr>'");
//                }

//            },
//            error: function (result) {
//                alert("Error");
//            }
//        });
//    }