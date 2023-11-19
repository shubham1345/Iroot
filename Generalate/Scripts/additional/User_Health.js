//Load Data in Table when documents is ready 
$(document).ready(function () {
    loadHealthData();
   
});

function loadHealthData() {
    var tb = document.getElementById('EmpInfo');
    while (tb.rows.length > 1) {
        tb.deleteRow(1);
    }

    $.getJSON("GetAll",
        function (json) {
            var tr;

            //Append each row to html table
            for (var i = 0; i < json.length; i++) {
                tr = $('<tr />');
                tr.append("<td hidden='hidden'>" + json[i].HealthId + "</td>");
                tr.append('<td><a href=ViewProfile/' + json[i].HealthId + '>' + json[i].Name + '</a></td>');
                tr.append("<td>" + json[i].MemberID + "</td>");
                tr.append('<td><a href=HealthView/' + json[i].MemberID + '>View</a></td>');

                $('table').append(tr);

            }
            $('#EmpInfo').DataTable();
        });
}