$(document).ready(function () {

    GetAllSummerDetails();
});


//Get All COS
function GetAllSummerDetails() {
    var tb = document.getElementById('Studenttbl');
    while (tb.rows.length > 1) {
        tb.deleteRow(1);
    }

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "Student.asmx/GetAllSummerRecommendation",
        //data: "{'RegNo' : '" + RegstrNo + "'}",
        dataType: "json",
        success: function (data) {
            for (var i = 0; i < data.d.length; i++) {
                $("#Studenttbl").append("<tr><td >" + data.d[i].SummerRecommendationId + "</td><td hidden='hidden'>" + data.d[i].RegisterNumber + "</td><td>" + "<a href='SummerRecomendationFullView.aspx/BindSummerRecomndView'>" + data.d[i].Name
                    + "<a/></td><td>" + data.d[i].Batch + "</td><td>" + data.d[i].Specialization + "</td><td>" + data.d[i].MobileNo +  "</td><tr>'");
            }

        },
        error: function (result) {
            alert("Error");
        }
    });
}
