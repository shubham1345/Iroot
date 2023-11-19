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
        url: "Student.asmx/GetAllJobSheet",
        //data: "{'RegNo' : '" + RegstrNo + "'}",
        dataType: "json",
        success: function (data) {
            for (var i = 0; i < data.d.length; i++) {
                $("#Studenttbl").append("<tr><td hidden='hidden'>" + data.d[i].JobSheetId + "</td><td>" + data.d[i].ScholarNumber + "</td><td>" + data.d[i].StudentName
                    + "</td><td>" + data.d[i].Specialization + "</td><td>" + data.d[i].Class + "</td><td>" + data.d[i].Batch + "</td><td>" + data.d[i].CellNo + "</td><td>"
                    + '<a href="JobSheetMain.aspx/' + data.d[i].JobSheetId + '">View</a> | <a href="JobSheetMain.aspx/Update/' + data.d[i].JobSheetId + '">Edit</a> | <a href="#" onclick="DeleleJobsheet(' + data.d[i].JobSheetId + ')">Delete</a></td><tr>');
            }

        },
        error: function (result) {
            alert("Error");
        }
    });
}

//Delete AcademicDetail
function DeleleJobsheet(ID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "Student.asmx/DeleteJobSheet",
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            data: "{id:'" + ID + "'}",
            success: function (result) {
                GetAllJobsheetDetails();

            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}