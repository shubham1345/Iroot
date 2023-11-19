$(document).ready(function () {

    //call Initially
    BindFollowUp();
    //function called at interval of 9 secods to bind the followups
    setInterval(function () { BindFollowUp(); }, 18000);

});

function BindFollowUp()
{
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "Student.asmx/getAllFollowUpDashboard",
        //data: "{'RegNo' : '" + RegstrNo + "'}",
        dataType: "json",
        success: function (data) {
            var html = "";
            for (var i = 0; i < data.d.length; i++) {
                html += "<p>" + data.d[i].RemainderRemark + "</p>"
            }

            $("#followuptab").html("");
            $("#followuptab").html(html);
        },
        error: function (result) {
            alert("Error");
        }
    });
}
