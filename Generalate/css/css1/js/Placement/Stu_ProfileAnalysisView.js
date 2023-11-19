$(document).ready(function () {

    GetAllCarrierCouncelling();
});

//Get All CarrierCouncelling
function GetAllCarrierCouncelling() {
    var tb = document.getElementById('Studenttbl');
    while (tb.rows.length > 1) {
        tb.deleteRow(1);
    }

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "Student.asmx/GetAllProfileAnalysis",
        //data: "{'RegNo' : '" + RegstrNo + "'}",
        dataType: "json",
        success: function (data) {
            for (var i = 0; i < data.d.length; i++) {
                $("#Studenttbl").append("<tr><td>" + data.d[i].ProfileAnalysisId + "</td><td hidden='hidden'>" + data.d[i].RegisterNumber + "</td><td>" + " <a href='ProfileAnalysisFullView.aspx/BindprofileanalysisView'>" + data.d[i].StudentName
                    + "</a></td><td>" + data.d[i].Course + "</td><td>" + data.d[i].Batch + "</td><td>" + data.d[i].Specialization + "</td><tr>");
            }

        },
        error: function (result) {
            alert("Error");
        }
    });
}


//Delete AcademicDetail
function DeleleStudent(ID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "Student.asmx/DeleteProfileAnalysis",
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            data: "{id:'" + ID + "'}",
            success: function (result) {
                GetAllCarrierCouncelling();

            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}