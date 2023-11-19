$(document).ready(function () {
    loadUserData();

});


function loadUserData() {
    var tb = document.getElementById('EmpInfo');
    while (tb.rows.length > 1) {
        tb.deleteRow(1);
    }

    $.getJSON("GetAllEC",
        function (json) {
            var tr;

            //Append each row to html table
            for (var i = 0; i < json.length; i++) {
                tr = $('<tr />');
                tr.append("<td hidden='hidden'>" + json[i].EmergencyContactId + "</td>");
                tr.append('<td><a href="#"/' + json[i].GId + '>' + json[i].MemberID + '</a></td>');
                tr.append("<td>" + json[i].Name + "</td>");
                tr.append("<td>" + json[i].Relationship + "</td>");
                tr.append("<td>" + json[i].Mobile + "</td>");
                tr.append("<td>" + json[i].Landline + "</td>");
                tr.append("<td>" + json[i].EmailID + "</td>");
                tr.append("<td>" + json[i].Address + "</td>");
                 tr.append('<td><a href=User_PersonalDetails/' + json[i].MemberID + '>View</a></td>');
                //tr.append('<td><a href="EmergencyContactView" onclick="return getbyID(' + json[i].EmergencyContactId + ')">View</a></td>')
                $('table').append(tr);

            }
            $('#EmpInfo').DataTable();
        });
}