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
        var d = new Date()
        var gmtOffSet = -d.getTimezoneOffset();
        var gmtHours = Math.floor(gmtOffSet / 60);
        var GMTMin = Math.abs(gmtOffSet % 60);
        var dot = ".";
        var retVal = "" + gmtHours + dot + GMTMin;
        document.getElementById('<%= offSet.ClientID%>').value = retVal;
    }
