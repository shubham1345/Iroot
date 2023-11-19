
$(document).ready(function ()
{
    GetAllCOSDetails();
});

//Get All COS
function GetAllCOSDetails() {
    
     var html = "";

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "/UX/Student.asmx/GetAllCOS",
        //data: "{'RegNo' : '" + RegstrNo + "'}",
        dataType: "json",
        success: function (data)
        {
           


            $("#costblbody").html("");
            var tabledata = data.d.split('~')[0];
            if (data.d.split('~')[1] == "False") {
                
                $("#costblbody").html(tabledata);
                loaddatatable();

            }
            else {
                $("#costblbody").html(tabledata);
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
            //    $("#Studenttbl").append("<tr><td hidden='hidden'>" + data.d[i].CosID + "</td><td>" + data.d[i].RegisterNumber + "</td><td>" + data.d[i].StudentName
            //        + "</td><td>" + data.d[i].CurrentSpecialization + "</td><td>" + data.d[i].Changingspecialization + "</td><td>" + data.d[i].Batch + "</td><td>" + data.d[i].Reason + "</td><td>"
            //        + '<a href="ViewChangeSpecialization.aspx/' + data.d[i].CosID + '">View</a> | <a href="ChangeofSpecialization.aspx/Update/' + data.d[i].CosID + '">Edit</a> | <a href="#" onclick="DeleleStudent(' + data.d[i].CosID + ')">Delete</a></td><tr>');
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