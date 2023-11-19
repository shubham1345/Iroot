//Load Data in Table when documents is ready 
$(document).ready(function () {
    loadSparationfromtheCongregationData();
     

});


function loadSparationfromtheCongregationData() {
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
                tr.append("<td hidden='hidden'>" + json[i].SeperationId + "</td>");
                tr.append('<td><a href=ViewProfile/' + json[i].SeperationId + '>' + json[i].Name + '</a></td>');
                tr.append("<td>" + json[i].MemberID + "</td>");
                tr.append('<td><a href=SeparationfromtheCongregationView/' + json[i].MemberID + '>View</a></td>');
             //   tr.append('<td><a href="#" onclick="return getbyID(' + json[i].SeperationId + ')">Edit</a> | <a href="#" onclick="Delele(' + json[i].SeperationId + ')">Delete</a></td>')
                $('table').append(tr);

            }
            $('#EmpInfo').DataTable();
        });
}