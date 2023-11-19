$(document).ready(function () {
    GetAllStudentDetails();
});

function GetAllStudentDetails() {
    var tb = document.getElementById('Studenttbl');
    while (tb.rows.length > 1) {
        tb.deleteRow(1);
    }

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "Student.asmx/GetAllStudents",
        // data: "{'RegNo' : '" + RegstrNo + "'}",
        dataType: "json",
        success: function (data) {
            for (var i = 0; i < data.d.length; i++) {
                $("#Studenttbl").append("<tr><td hidden='hidden'>" + data.d[i].StudentId + "</td><td>" + "<a href='Stu_StudentRegistrationFullView.aspx/'>" + data.d[i].ScholarNumber + "<a/></td><td>" + data.d[i].StudentName
                    + "</td><td>" + data.d[i].Course + "</td><td>" + data.d[i].Years + "</td><td>" + data.d[i].Batch + "</td><td  hidden='hidden'>" + data.d[i].Gender + "</td><tr>'");
            }

        },
        error: function (result) {
            alert("Error");
        }
    });
}