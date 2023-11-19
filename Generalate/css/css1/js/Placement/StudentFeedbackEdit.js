$(document).ready(function () {

    GetAllJobsheetDetails();
});

//Get All COS
function GetAllJobsheetDetails() {
    var tb = document.getElementById('Studenttbl');
    while (tb.rows.length > 1) {
        tb.deleteRow(1);
    }
    var html = "";
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "Student.asmx/GetAllFeedback",
        //data: "{'RegNo' : '" + RegstrNo + "'}",
        dataType: "json",
        success: function (data) {
            //for (var i = 0; i < data.d.length; i++) {
            //    $("#Studenttbl").append("<tr><td hidden='hidden'>" + data.d[i].FeedbackId + "</td><td>" + data.d[i].RegisterNumber + "</td><td>" + data.d[i].StudentName
            //        + "</td><td>" + data.d[i].Specialization + "</td><td>" + data.d[i].CompanyName + "</td><td>" + data.d[i].Batch + "</td><td>" + data.d[i].Designation + "</td><td>"
            //        + '<a href="ViewStudentFeedback.aspx/' + data.d[i].FeedbackId + '">View</a> | <a href="StudentFeedback.aspx?Action=Update&Id=' + data.d[i].FeedbackId + '">Edit</a> | <a href="#" onclick="DeleleJobsheet(' + data.d[i].FeedbackId + ')">Delete</a></td><tr>');
            //}
            $("#feedbackblbody").html("");
            var tabledata = data.d.split('~')[0];
            if (data.d.split('~')[1] == "False") {

                $("#feedbackblbody").html(tabledata);
                loaddatatable();

            }
            else {
                $("#feedbackblbody").html(tabledata);
                $('#Studenttbl').dataTable({
                    "paging": false,
                    "searching": false,
                    "columnDefs": [
                        { "orderable": false, "targets": 6 },
                        { "orderable": false, "targets": 8 },
                        { "orderable": false, "targets": 9 }
                    ]

                });
            }

        },
        error: function (result)
        {
            alert("Error");
        }
    });
    }



        
function loaddatatable() {
    if ($.fn.DataTable.isDataTable('#Studenttbl')) {
        $('#Studenttbl').DataTable().destroy();
    }


    $('#Studenttbl').dataTable({
        "autoWidth": true,
        "columnDefs": [

           { "orderable": false, "targets": 6 }
        ]
    });

}

//Delete AcademicDetail
function DeleleJobsheet(ID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "Student.asmx/DeleteFeedback",
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