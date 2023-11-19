$(document).ready(function () {
    //var weburl = "";
    //if (!weburl) weburl = window.location.href
    //var array = weburl.split('/');
    //var no = array[array.length - 1];
    //var sRole = '<%= Session["role"] %>';
    //GetAllStudentPlacementDetails(no);
    
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
function OnAllStudentNameCheck(ctrl) {
    $(".StudentNameClass").prop("checked", ctrl.checked);
    // ctrl.parentNode.style.color = (ctrl.checked) ? 'blue' : 'red';
}
function OnAllRNRCheck(ctrl) {
    $(".RnrClass").prop("checked", ctrl.checked);
}
function OnAllPPTCheck(ctrl) {
   // alert(ctrl);

    //if (ctrl.checked) {
    //    $(".pptClass").attr("checked", "checked");
    //    $(".pptClass").prop("checked", ctrl.checked);
    //}
    //else {
    //    $(".pptClass").removeAttr("checked");
    //}
   // if ((".pptClass").prop("checked==true")) {
       // $(".pptClass").prop("checked", ctrl.checked);
   //}
   // else {
        $(".pptClass").prop("checked", ctrl.checked)
   // }
    // ctrl.parentNode.style.color = (ctrl.checked) ? 'black' : 'red';
    //ctrl.parentNode.style.color = (ctrl.checked) ? 'blue' : 'red';

}


function OnAllATCheck(ctrl) {
    $(".AtClass").prop("checked", ctrl.checked);
   // ctrl.parentNode.style.color = (ctrl.checked) ? 'blue' : 'red';
}
function OnAllTTCheck(ctrl) {
    $(".TtClass").prop("checked", ctrl.checked);
   // ctrl.parentNode.style.color = (ctrl.checked) ? 'blue' : 'red';
}
function OnAllGDCheck(ctrl) {
    $(".GDClass").prop("checked", ctrl.checked);
   // ctrl.parentNode.style.color = (ctrl.checked) ? 'blue' : 'red';
}
function OnAllGICheck(ctrl) {
    $(".GIClass").prop("checked", ctrl.checked);
   // ctrl.parentNode.style.color = (ctrl.checked) ? 'blue' : 'red';
}
function OnAllTICheck(ctrl) {
    $(".TIClass").prop("checked", ctrl.checked);
   // ctrl.parentNode.style.color = (ctrl.checked) ? 'blue' : 'red';
}
function OnAllFICheck(ctrl) {
    $(".FIClass").prop("checked", ctrl.checked);
    //ctrl.parentNode.style.color = (ctrl.checked) ? 'blue' : 'red';
}


//function Edit() {

//    function OnAllRNRCheck(ctrl) {
//        $(".RnrClass").prop("checked", ctrl.checked);
//    }
//    function OnAllPPTCheck(ctrl) {
//        $(".pptClass").prop("checked", ctrl.checked);
//    }

//    function OnAllATCheck(ctrl) {
//        $(".AtClass").prop("checked", ctrl.checked);

//    }

//    function OnAllTTCheck(ctrl) {
//        $(".TtClass").prop("checked", ctrl.checked);

//    }
//    function OnAllGDCheck(ctrl) {
//        $(".GDClass").prop("checked", ctrl.checked);

//    }
//    function OnAllGICheck(ctrl) {
//        $(".GIClass").prop("checked", ctrl.checked);

//    }

//    function OnAllTICheck(ctrl) {
//        $(".TIClass").prop("checked", ctrl.checked);

//    }
//    function OnAllFICheck(ctrl) {
//        $(".FIClass").prop("checked", ctrl.checked);
//    }
//}


//Get All CarrierCouncelling
function GetAllApplyStatus() {
    var no = getUrlVars()["id"];
    var html = "";
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "Student.asmx/GetAllApplyStatusCompanyIDE",
        data: "{'id' : '" + no + "'}",
        dataType: "json",
        success: function (data) {
            //for (var i = 0; i < data.d.length; i++) {
            //                    if (data.d[i].MessageType == "1") {

            //                        $("#Attendance").append("<tr><td>" + '<p>Attendance</p>' + "</td><td>" + data.d[i].ApplyStatusId + "</td><td >" + data.d[i].StudentName + "</td><td>" + data.d[i].MobileNo + "</td><td>" + data.d[i].Specialization + "</td><td>" + data.d[i].RNR
            //                         + "</td><td>" + data.d[i].PPT + "</td><td>" + data.d[i].AT
            //                        + "</td><td>" + data.d[i].TT +
            //                        + "</td><td>" + data.d[i].GD +
            //                        + "</td><td>" + data.d[i].GI +
            //                        + "</td><td>" + data.d[i].TI +
            //                        + "</td><td>" + data.d[i].FI + 
            //                        + "</td><td>" + data.d[i].ProcessStatus + "</td></tr>");
            //                    }
            //                }

            $("#stdnttblbody").html("");
            var tabledata = data.d.split('~')[0];
            if (data.d.split('~')[1] == "False") {
                $("#stdnttblbody").html(tabledata);
                loaddatatable();

            }
            else {
                $("#stdnttblbody").html(tabledata);
                $('#Studenttbl').dataTable({
                    "paging": false,
                    "searching": true,
                    "columnDefs": [
                        { "orderable": false, "targets": 9 }

                    ]

                });
            }

        },
        error: function (result) {
            alert("Error");
        }
    });
}


//function GetAllStudentAttendance() {
//    $.ajax({
//        type: "POST",
//        contentType: "application/json; charset=utf-8",
//        url: "Student.asmx/GetAllApplyStatusCompanyIDE",
//        dataType: "json",
//        success: function (data) {

//            for (var i = 0; i < data.d.length; i++) {
//                if (data.d[i].MessageType == "1") {

//                    $("#Attendance").append("<tr><td>" + '<p>Attendance</p>' + "</td><td>" + data.d[i].ApplyStatusId + "</td><td >" + data.d[i].StudentName + "</td><td>" + data.d[i].MobileNo + "</td><td>" + data.d[i].Specialization + "</td><td>" + data.d[i].RNR
//                     + "</td><td>" + data.d[i].PPT + "</td><td>" + data.d[i].AT
//                    + "</td><td>" + data.d[i].TT +
//                    + "</td><td>" + data.d[i].GD +
//                    + "</td><td>" + data.d[i].GI +
//                    + "</td><td>" + data.d[i].TI +
//                    + "</td><td>" + data.d[i].FI + 
//                    + "</td><td>" + data.d[i].ProcessStatus + "</td></tr>");
//                }
//            }

//        },
//        error: function (result) {
//            alert("Error");
//        }
//    });
//}

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


