/// <reference path="ChangeOfSpecializationView.js" />
/// <reference path="ChangeOfSpecializationView.js" />
$(document).ready(function () {

    GetAllCOSDetails();
});

function GetAllCOSDetails() {
    var tb = document.getElementById('Studenttbl');
    while (tb.rows.length > 1) {
        tb.deleteRow(1);
    }

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "Student.asmx/GetAllCOS",
        //data: "{'RegNo' : '" + RegstrNo + "'}",
        dataType: "json",
        success: function (data) {
            for (var i = 0; i < data.d.length; i++) {
                $("#Studenttbl").append("<tr><td>" + data.d[i].CosID + "</td><td hidden='hidden'>" + data.d[i].RegisterNumber + "</td><td>" + "<a href='ChangeofSpecializationFullView.aspx/BindCOSView'>" + data.d[i].StudentName
                    + "<a/></td><td>" + data.d[i].RegisterNumber + "</td><td>" + data.d[i].Batch + "</td><tr>");
            }

        },
        error: function (result) {
            alert("Error");
        }
    });
}