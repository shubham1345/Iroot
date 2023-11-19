$(function () {
    $('#AcademicAdd1').click(function () {

        
        var per = $('#Percentage_Sem').val();
        var a = "";
        if (per > 35) {
            a = $('#Percentage_Sem').val();
        }

        var RegNo = $('#ScholarNo').val();

        var general =
        {
            Year: $('#Year_Sem').val(),
            Sem: $('#ddlSemester').val(),
            Persentagegrade: a,

            //perse2: $('#Percentage_Sem').val(),
            ScholarNumber: $('#ScholarNo').val()
        };

        $.ajax({
            type: "POST",
            url: "Student.asmx/AddSem",
            data: JSON.stringify({ 'AcademicDetail': general }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                ClearSemesterDetails();
                GetSemDetailsByRegNo(RegNo);

            }
        });
    });
});

//Get All AcademicDetail By RegNo
function GetSemDetailsByRegNo(RegstrNo) {
    var tb = document.getElementById('Academictbl1');
    while (tb.rows.length > 1) {
        tb.deleteRow(1);
    }

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "Student.asmx/getAllSemDetailsByRegNo",
        data: "{'RegNo' : '" + RegstrNo + "'}",
        dataType: "json",
        success: function (data) {
            for (var i = 0; i < data.d.length; i++) {
                $("#Academictbl1").append("<tr><td hidden='hidden'>" + data.d[i].SemesterId + "</td><td>" + data.d[i].Year + "</td><td>" + data.d[i].Sem
                    + "</td><td>" + data.d[i].Persentagegrade + "</td><td>"
                    + '<a href="#" onclick="return GetSemDetailsByID(' + data.d[i].SemesterId + ')">Edit</a> | <a href="#" onclick="DeleteSem(' + data.d[i].SemesterId + ')">Delete</a></td><tr>');
            }

        },
        error: function (result) {
            alert("Error");
        }
    });
}



$(function () {
    $('#AcademicUpdate1').click(function () {

        
        var RegNo = $('#RegisterNo').val();

        var general =
        {
            SemesterId: $('#SemesterId').val(),
            Year: $('#Year_Sem').val(),
            Sem: $('#ddlSemester').val(),
            Persentagegrade: $('#Percentage_Sem').val(),
            ScholarNumber: $('#ScholarNo').val()
        };

        $.ajax({
            type: "POST",
            url: "Student.asmx/UpdateSem",
            data: JSON.stringify({ 'AcademicDetail': general }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                ClearSemesterDetails();
                GetSemDetailsByRegNo(RegNo);
                $("#AcademicAdd1").prop("disabled", false);
            }
        });
    });
});


function GetSemDetailsByID(AcademicId) {
    
    $.ajax({
        url: "Student.asmx/getSemDetailsById",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        data: "{id:'" + AcademicId + "'}",
        success: function (result) {
            
            $('#SemesterId').val(result.d[0].SemesterId);
            $('#Year_Sem').val(result.d[0].Year);
            $('#ddlSemester').val(result.d[0].Sem);
            $('#Percentage_Sem').val(result.d[0].Persentagegrade);


            $("#AcademicAdd1").prop("disabled", true);
            //$('#myModal').modal('show');
            //$('#btnUpdate').show();
            //$('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    }); return false;
}






//Delete AcademicDetail
function DeleteSem(ID) {
    var RegNo = $('#RegisterNo').val();
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "Student.asmx/DeleteSem",
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            data: "{id:'" + ID + "'}",
            success: function (result) {
                $(this).closest('tr').remove()
                GetSemDetailsByRegNo(RegNo);

            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}



function ClearSemesterDetails() {
    $('#SemesterId').val("");
    $('#Year_Sem').val("");
    $('#ddlSemester').val("");
    $('#Percentage_Sem').val("");
    //$('#RegisterNo').val("");
}
