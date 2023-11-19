$(document).ready(function () {
    loadSecularEducationData();
});



function loadSecularEducationData() {
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
                tr.append("<td hidden='hidden'>" + json[i].SecularId + "</td>");
                tr.append('<td><a href="ViewProfile"/' + json[i].SecularId + '>' + json[i].MemberID + '</a></td>');
                tr.append("<td>" + json[i].Name + "</td>");
                tr.append('<td><a href=SecularEducationView/' + json[i].MemberID + '>View</a></td>');
                $('table').append(tr);

            }
            $('#EmpInfo').DataTable();
        });
}