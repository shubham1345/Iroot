$(document).ready(function () {
    loadSacramentData();

});


function loadSacramentData() {
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
                tr.append("<td hidden='hidden'>" + json[i].EntryId + "</td>");
                tr.append('<td><a href=ViewProfile/' + json[i].EntryId + '>' + json[i].MemberID + '</a></td>');
                tr.append("<td>" + json[i].Name + "</td>");                            
                tr.append('<td><a href=User_ViewSacrament/' + json[i].MemberID + '>View</a></td>');
                $('table').append(tr);

            }
            $('#EmpInfo').DataTable();
        });
}