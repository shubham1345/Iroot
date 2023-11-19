$(document).ready(function () {

    GetAllCarrierCouncelling();
});

//Get All CarrierCouncelling
function GetAllCarrierCouncelling() {
    var tb = document.getElementById('Studenttbl');
    while (tb.rows.length > 1) {
        tb.deleteRow(1);
    }
    var html = "";

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "Student.asmx/GetAllProfileAnalysis",
        //data: "{'RegNo' : '" + RegstrNo + "'}",
        dataType: "json",
        success: function (data) {



            $("#placementtblbody").html("");
            var tabledata = data.d.split('~')[0];
            if (data.d.split('~')[1] == "False") {
                
                $("#placementtblbody").html(tabledata);
                loaddatatable();

            }
            else {
                $("#placementtblbody").html(tabledata);
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


            //for (var i = 0; i < data.d.length; i++) {
            //    $("#Studenttbl").append("<tr><td hidden='hidden'>" + data.d[i].ProfileAnalysisId + "</td><td>" + data.d[i].RegisterNumber + "</td><td>" + data.d[i].StudentName
            //        + "</td><td>" + data.d[i].Course + "</td><td>" + data.d[i].Specialization + "</td><td>" + data.d[i].Batch + "</td><td>" + data.d[i].Degree + "</td><td>"
            //        + '<a href="ViewProfileAnalysis.aspx/' + data.d[i].ProfileAnalysisId + '">View</a> | <a href="AnalyseProfile.aspx/Update/' + data.d[i].ProfileAnalysisId + '">Edit</a> | <a href="#" onclick="DeleleStudent(' + data.d[i].ProfileAnalysisId + ')">Delete</a></td><tr>');
            //}

            

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