$(document).ready(function () {

    GetAllPlacementDetails();
});

//Get All COS
function GetAllPlacementDetails() {
    var tb = document.getElementById('Studenttbl');
    while (tb.rows.length > 1) {
        tb.deleteRow(1);
    }
    var html = "";

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "Student.asmx/GetAllPlacementLeader",
        //data: "{'RegNo' : '" + RegstrNo + "'}",
        dataType: "json",
        success: function (data) {
           
            //for (var i = 0; i < data.d.length; i++) {
            //    $("#Studenttbl").append("<tr><td hidden='hidden'>" + data.d[i].PlacementLeaderId + "</td><td>" + data.d[i].RegisterNumber + "</td><td>" + data.d[i].StudentName
            //         + "</td><td>" + data.d[i].Specialization + "</td><td>" + data.d[i].Course + "</td><td>" + data.d[i].Batch + "</td><td>" + data.d[i].MobileNo + "</td><td>" + data.d[i].Authorized + "</td><td>" + data.d[i].PlacementDate + "</td><td>"
            //         + '<a href="ViewPlacementLeader.aspx/' + data.d[i].PlacementLeaderId + '">View</a> | <a href="PlacementLeader.aspx/Update/' + data.d[i].PlacementLeaderId + '">Edit</a> | <a href="#" onclick="DelelePlacement(' + data.d[i].PlacementLeaderId + ')">Delete</a></td><tr>');

            //    //+ '<a href="PlacementLeader.aspx/' + data.d[i].PlacementLeaderId + '">View</a> | <a href="PlacementLeader.aspx/Update/' + data.d[i].PlacementLeaderId + '">Edit</a> | <a href="#" onclick="DelelePlacement(' + data.d[i].PlacementLeaderId + ')">Delele</a></td><tr>');


            //}

            //for (var i = 0; i < data.d.length; i++) {
            //    html += "<tr>";
            //    html += "<td hidden='hidden'>" + data.d[i].PlacementLeaderId + "</td>";
            //    html += "<td>" + data.d[i].RegisterNumber + "</td>";
            //    html += "<td>" + data.d[i].StudentName + "</td>";
            //    html += "<td>" + data.d[i].Specialization + "</td>";
            //    html += "<td>" + data.d[i].Course + "</td>";
            //    html += "<td>" + data.d[i].Batch + "</td>";
            //    html += "<td>" + data.d[i].MobileNo + "</td>";
            //    html += "<td>" + data.d[i].Authorized + "</td>";
            //    html += "<td>" + data.d[i].PlacementDate + "</td>";
            //    html += "<td>";
            //    html += '<a href="ViewPlacementLeader.aspx/' + data.d[i].PlacementLeaderId + '">View</a>&nbsp&nbsp;<a href="PlacementLeader.aspx/Update/' + data.d[i].PlacementLeaderId + '">Edit</a>&nbsp&nbsp;<a href="#" onclick="DelelePlacement(' + data.d[i].PlacementLeaderId + ')">Delete</a>';
            //    html += "</td>";
            //    html += "</tr>";
            //}
            //<td hidden='hidden'>" + data.d[i].StudentId + "</td>
            $("#placementtblbody").html("");
            var tabledata = data.d.split('~')[0];
            if (data.d.split('~')[1] == "False") {
                $("#placementtblbody").html(tabledata);
                loaddatatable();
            }

                //if (data.d == undefined || data.d == null || data.d == "")
                //{
                //  $("#placementtblbody").html("<tr><td colspan='10'>No records found</td></tr>");
                //}



                //$("#placementtblbody").html(data.d);
                //loaddatatable();
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
            { "orderable": false, "targets": 6 },
            { "orderable": false, "targets": 8 },
            { "orderable": false, "targets": 9 }
        ]
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
                //GetAllPlacementDetails();
                window.location.href = "/UX/ManagePlacementLeader.aspx";
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}