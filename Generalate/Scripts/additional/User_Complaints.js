//Load Data in Table when documents is ready 
$(document).ready(function () {

    loadData();
   

});

function loadData() {
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
                tr.append("<td hidden='hidden'>" + json[i].ComplaintID + "</td>");
                tr.append('<td><a href="#"/' + json[i].ComplaintID + '>' + json[i].Name + '</a></td>');
                tr.append("<td>" + json[i].MemberID + "</td>");
                tr.append('<td><a href=ComplaintView/' + json[i].MemberID + '>View</a></td>');
                $('table').append(tr);

            }
            $('#EmpInfo').DataTable();
        });
}