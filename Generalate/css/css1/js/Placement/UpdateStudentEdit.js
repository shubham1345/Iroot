
$(document).ready(function () {
    
    var weburl = "";
    if (!weburl) weburl = window.location.href
    var array = weburl.split('/');
    var no = array[array.length - 1];

    $("#RegisterNo").val(no);
    LoadStudentDetails(no);
    GetWorkExpDetailsByRegNo(no);
    GetAcademicDetailsByRegNo(no);
    LoadDeclarationDetails(no);
    LoadInternshipDetails(no);
});



//function GetAcademicDetailsByRegNo(RegstrNo) {
//    var tb = document.getElementById('Academictbl');
//    while (tb.rows.length > 1) {
//        tb.deleteRow(1);
//    }

//    $.ajax({
//        type: "POST",
//        contentType: "application/json; charset=utf-8",
//        url: "ResolveUrl(Student.asmx/getAllAcademicDetailsByRegNo),
//    data: "{'RegNo' : '" + RegstrNo + "'}",
//    dataType: "json",
//    success: function (data) {
//        for (var i = 0; i < data.d.length; i++) {
//            $("#Academictbl").append("<tr><td hidden='hidden'>" + data.d[i].AcademicDetailId + "</td><td>" + data.d[i].AcademicYear + "</td><td>" + data.d[i].Qualification
//                + "</td><td>" + data.d[i].Stream + "</td><td>" + data.d[i].Institution + "</td><td>" + data.d[i].University + "</td><td>" + data.d[i].Percentage + "</td><td>"
//                + '<a href="#" onclick="return GetAcademicDetailsByID(' + data.d[i].AcademicDetailId + ')">Edit</a> | <a href="#" onclick="Delele(' + data.d[i].AcademicDetailId + ')">Delele</a></td><tr>');
//        }

//    },
//    error: function (result) {
//        alert("Error");
//    }
//});
