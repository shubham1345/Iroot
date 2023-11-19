$(document).ready(function () {

    GetAllSummerDetails();
});

//Get All COS
function GetAllSummerDetails() {
    var tb = document.getElementById('Studenttbl');
    while (tb.rows.length > 1) {
        tb.deleteRow(1);
    }

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "Student.asmx/GetAllSummerRecommendation",
        //data: "{'RegNo' : '" + RegstrNo + "'}",
        dataType: "json",
        success: function (data) {
            for (var i = 0; i < data.d.length; i++) {
                $("#Studenttbl").append("<tr><td >" + data.d[i].SummerRecommendationId + "</td><td hidden='hidden'>" + data.d[i].RegisterNumber + "</td><td>" + "<a href='SummerRecomendationFullView.aspx/BindSummerRecomndView'>" + data.d[i].Name
                    + "<a/></td><td>" + data.d[i].Specialization + "</td><td>" + data.d[i].MobileNo + "</td><td>" + data.d[i].Batch + "</td><td>" + data.d[i].EmailId + "</td><tr>'");
            }

        },
        error: function (result) {
            alert("Error");
        }
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

$(document).ready(function () {
    var weburl = "";
    if (!weburl) weburl = window.location.href
    var array = weburl.split('/');
    $.ajax({
        type: "POST",
        url: "Student.asmx/getSummerRecommendationById",
        data: JSON.stringify({ 'Career': carrier }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            Getstudentdetail();
            window.location.href = "Carrier.aspx";


        }
    });
});
function Getstudentdetail()
{
        //var d = new Date()
        //var gmtOffSet = -d.getTimezoneOffset();
        //var gmtHours = Math.floor(gmtOffSet / 60);
        //var GMTMin = Math.abs(gmtOffSet % 60);
        var dot = ".";
        var retVal = "" + HiddenField2.StudentName + dot + HiddenField4.Designation ;
        document.getElementById('<%= offSet.ClientID%>').value = retVal;
    }
