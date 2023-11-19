$(function () {
    $('#AcademicAdd').click(function () {

        

        var RegNo = $('#RegisterNo').val();
        //var per = $('#Aca_Percentage').val();
        //var a = "";

        //if (per > 35) {
        //    a = $('#Aca_Percentage').val();
        //}
        var msg = "";

        var _AcademicYear = $('#Aca_Year').val();
        var _Qualification = $('#ddlAca_Qualification').val();
        var _Institution = $('#Aca_College').val();
        var _University = $('#Aca_University').val();
        var _Percentage = $('#Aca_Percentage').val();
        var _ScholarNumber = $('#RegisterNo').val();
        var _Stream = $('#txtacadamicQualification').val();



        if (_AcademicYear == "") {
            msg += "Year cannot be blank\n";
        }

        if (_Qualification == "0") {

            msg += "Select Qualification\n";
        }

        if (_Institution == "") {
            msg += "School/college cannot be blank\n";

        }

        if (_University == "") {
            msg += "University cannot be blank\n";
        }

        if (_Percentage == "") {
            msg += "Percentage cannot be blank\n";
        }

        //if (_Stream == "") {
        //    msg += "Stream cannot be blank\n";
        //}


        if (msg != "") {

            alert("Please fill required fields :\n" + msg);
        }
        else {

            if (parseInt(_Percentage) < 35 || parseFloat(_Percentage) > 100) {

                alert("Percentage should be between 35-100");

            }
            else {


                var general =
                {
                    AcademicYear: _AcademicYear,
                    Qualification: _Qualification,
                    Institution: _Institution,
                    University: _University,
                    Percentage: _Percentage,
                    ScholarNumber: _ScholarNumber,
                    Stream: _Stream
                };

                
                $.ajax({
                    type: "POST",
                    url: "/Student.asmx/AddAcademic",
                    data: JSON.stringify({ 'AcademicDetail': general }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (msg) {
                        ClearAcademicDetails();
                        GetAcademicDetailsByRegNo(RegNo);

                    }
                });
            }
        }
    });
});


// Update AcademicDetail
$(function () {
    $('#AcademicUpdate').click(function () {

        
        var RegNo = $('#RegisterNo').val();

        var general =
        {
            AcademicDetailId: $('#AcademicDetailId').val(),
            AcademicYear: $('#Aca_Year').val(),
            Qualification: $('#ddlAca_Qualification').val(),
            Institution: $('#Aca_College').val(),
            University: $('#Aca_University').val(),
            Percentage: $('#Aca_Percentage').val(),
            //ScholarNumber: $('#RegisterNo').val(),
            ScholarNumber: RegNo,

            Stream: $('#txtacadamicQualification').val()
        };

        $.ajax({
            type: "POST",
            url: "/Student.asmx/UpdateAcademic",
            data: JSON.stringify({ 'AcademicDetail': general }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                ClearAcademicDetails();
                GetAcademicDetailsByRegNo(RegNo);
                $("#AcademicAdd").prop("disabled", false);
            }
        });
    });
});

//Get All AcademicDetail By RegNo
function GetAcademicDetailsByRegNo(RegstrNo) {
    var tb = document.getElementById('Academictbl');
    while (tb.rows.length > 1) {
        tb.deleteRow(1);
    }

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "/Student.asmx/GetAllAcademicDetailsByRegNo",
        data: "{'RegNo' : '" + RegstrNo + "'}",
        dataType: "json",
        success: function (data) {
            for (var i = 0; i < data.d.length; i++) {
                $("#Academictbl").append("<tr><td hidden='hidden'>" + data.d[i].AcademicDetailId + "</td><td>" + data.d[i].AcademicYear + "</td><td>" + data.d[i].Qualification
                    + "</td><td>" + data.d[i].Stream + "</td><td>" + data.d[i].Institution + "</td><td>" + data.d[i].University + "</td><td>" + data.d[i].Percentage.toFixed(2) + "</td><td>"
                    + '<a href="#" onclick="return GetAcademicDetailsByID(' + data.d[i].AcademicDetailId + ')">Edit</a> | <a href="#" onclick="Delele(' + data.d[i].AcademicDetailId + ')">Delete</a></td><tr>');
            }

        },
        error: function (result) {
            alert("Error");
        }
    });
}


function ClearAcademicDetails() {
    $('#AcademicDetailId').val("");
    $('#Aca_Year').val("");
    $('#ddlAca_Qualification').val("");
    $('#Aca_College').val("");
    $('#Aca_University').val("");
    $('#Aca_Percentage').val("");
    $('#txtacadamicQualification').val("");
    //$('#RegisterNo').val("");
}

