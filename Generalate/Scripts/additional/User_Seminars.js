//Load Data in Table when documents is ready 
$(document).ready(function () {
    loadSeminarData();
});


function loadSeminarData() {
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
                tr.append("<td hidden='hidden'>" + json[i].SeminarId + "</td>");
                tr.append('<td><a href=ViewProfile/' + json[i].SeminarId + '>' + json[i].Name + '</a></td>');
                tr.append("<td>" + json[i].MemberID + "</td>");
                tr.append('<td><a href=UserSeminarView/' + json[i].MemberID + '>View</a></td>');

                $('table').append(tr);

            }
            $('#EmpInfo').DataTable();
        });
}