$(document).ready(function () {

    GetAllCOSDetails();
});

//Get All COS
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
                    + "</td><td><a/>" + data.d[i].CurrentSpecialization + "</td><td>" + data.d[i].Changingspecialization + "</td><td>" + data.d[i].Batch + "</td><tr>");
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
            url: "Student.asmx/DeleteCOS",
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            data: "{id:'" + ID + "'}",
            success: function (result) {
                GetAllCOSDetails();

            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}