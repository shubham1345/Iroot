$(document).ready(function () {

    GetAllJobsheetDetails();
});





//Get All COS
function GetAllJobsheetDetails() {
    var tb = document.getElementById('Studenttbl');
    while (tb.rows.length > 1) {
        tb.deleteRow(1);
    }

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "Student.asmx/GetAllFeedback",
        //data: "{'RegNo' : '" + RegstrNo + "'}",
        dataType: "json",
        success: function (data) {
            for (var i = 0; i < data.d.length; i++) {
                $("#Studenttbl").append("<tr><td>" + data.d[i].FeedbackId + "</td><td hidden='hidden'>" + data.d[i].RegisterNumber + "</td><td>" + "<a href='StudentFeedBackFullView.aspx/feedbackfullView'>" + data.d[i].StudentName
                    + "<a/></td><td>" + data.d[i].Course + "</td><td>" + data.d[i].Batch + "</td><td>" + data.d[i].Specialization + "</td><tr>'");
            }

        },
        error: function (result) {
            alert("Error");
        }
    });
}