$(document).ready(function () {

    GetAllPlacementDetails();
});

//Get All COS
function GetAllPlacementDetails() {
    var tb = document.getElementById('Studenttbl');
    while (tb.rows.length > 1) {
        tb.deleteRow(1);
    }

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "Student.asmx/GetAllPlacementLeader",
        //data: "{'RegNo' : '" + RegstrNo + "'}",
        dataType: "json",
        success: function (data) {
            for (var i = 0; i < data.d.length; i++) {
                $("#Studenttbl").append("<tr><td hidden='hidden'>" + data.d[i].PlacementLeaderId + "</td><td>" + data.d[i].RegisterNumber + "</td><td>" + data.d[i].StudentName
                     + "</td><td>" + data.d[i].Specialization + "</td><td>" + data.d[i].Course + "</td><td>" + data.d[i].Batch + "</td><td>" + data.d[i].MobileNo + "</td><td>" + data.d[i].Authorized + "</td><td>" + data.d[i].PlacementDate + "</td><td>"
                     + '<a href="#/' + + '"></a> | <a href="PlacementLeader.aspx/Update/' + data.d[i].PlacementLeaderId + '">Edit</a> | <a href="#" onclick="DelelePlacement(' + data.d[i].PlacementLeaderId + ')">Delete</a></td><tr>');

                     //+ '<a href="PlacementLeader.aspx/' + data.d[i].PlacementLeaderId + '">View</a> | <a href="PlacementLeader.aspx/Update/' + data.d[i].PlacementLeaderId + '">Edit</a> | <a href="#" onclick="DelelePlacement(' + data.d[i].PlacementLeaderId + ')">Delele</a></td><tr>');
            }

        },
        error: function (result) {
            alert("Error");
        }
    });
}







//Delete AcademicDetail
function DelelePlacement(ID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "Student.asmx/DeletePlacementLeader",
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            data: "{id:'" + ID + "'}",
            success: function (result) {
                GetAllPlacementDetails();

            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}