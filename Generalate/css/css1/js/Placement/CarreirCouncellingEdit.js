$(document).ready(function () {

    GetAllCarrierCouncelling();
});

//Get All CarrierCouncelling
function GetAllCarrierCouncelling() {

    var html = "";
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "Student.asmx/GetAllCarrierCouncelling",
        //data: "{'RegNo' : '" + RegstrNo + "'}",
        dataType: "json",
        success: function (data) {


            $("#careertblbody").html("");
            var tabledata = data.d.split('~')[0];
            if (data.d.split('~')[1] == "False") {

                $("#careertblbody").html(tabledata);
                loaddatatable();

            }
            else {
                $("#careertblbody").html(tabledata);
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
          
           { "orderable": false, "targets": 5}
        ]
    });

}

//Delete AcademicDetail
function DeleleCareerCouncling(ID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "Student.asmx/DeleteCarrierCouncelling",
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            data: "{id:'" + ID + "'}",
            success: function (result) {
                window.location.href = "/UX/Carrier.aspx";

            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}