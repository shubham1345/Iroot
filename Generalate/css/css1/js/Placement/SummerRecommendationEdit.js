$(document).ready(function () {

    GetAllSummerDetails();
});

//Get All COS
function GetAllSummerDetails() {
    var tb = document.getElementById('Studenttbl');
    while (tb.rows.length > 1) {
        tb.deleteRow(1);
    }
    var html = "";

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "Student.asmx/GetAllSummerRecommendation",
        //data: "{'RegNo' : '" + RegstrNo + "'}",
        dataType: "json",
        success: function (data) {

            $("#summertblbody").html("");
            var tabledata = data.d.split('~')[0];
            if (data.d.split('~')[1] == "False") {

                $("#summertblbody").html(tabledata);
                loaddatatable();

            }
            else {
                $("#summertblbody").html(tabledata);
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



            //for (var i = 0; i < data.d.length; i++) {
            //    $("#Studenttbl").append("<tr><td hidden='hidden'>" + data.d[i].SummerRecommendationId + "</td><td>" + data.d[i].RegisterNumber + "</td><td>" + data.d[i].Name
            //        + "</td><td>" + data.d[i].Specialization + "</td><td>" + data.d[i].MobileNo + "</td><td>" + data.d[i].Batch + "</td><td>" + data.d[i].EmailId + "</td><td>"
            //        + '<a href="ViewSummerRecommendation.aspx/' + data.d[i].SummerRecommendationId + '">View</a> | <a href="SummerRecommendation.aspx/Update/' + data.d[i].SummerRecommendationId + '">Edit</a> | <a href="#" onclick="DeleteSummerRecomDetailsById(' + data.d[i].SummerRecommendationId + ')">Delete</a></td><tr>');
            //}

            
        },
        error: function (result) {
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
           { "orderable": false, "targets": 3 },
           { "orderable": false, "targets": 5 },
           { "orderable": false, "targets": 6 }
        ]
    });

}

//Delete AcademicDetail
function DeleteSummerRecomDetailsById(ID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "Student.asmx/DeleteSummerRecommendation",
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            data: "{id:'" + ID + "'}",
            success: function (result) {
                GetAllSummerDetails();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}


//letter link
  function GetSummerRecomletterById(ID) {
    var ans = confirm("Do you want to get the letter?");
    if (ans) {
        $.ajax({
            url: "Student.asmx/GetSummerletter",
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            data: "{id:'" + ID + "'}",
            success: function (result) {
                GetAllSummerDetails();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}