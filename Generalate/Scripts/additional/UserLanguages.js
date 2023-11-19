
//Load Data in Table when documents is ready 
$(document).ready(function () {
    loadLanguagesData();
    

});

function loadLanguagesData() {
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
                tr.append("<td hidden='hidden'>" + json[i].KnownLanguagesId + "</td>");
                tr.append('<td><a href=ViewProfile/' + json[i].KnownLanguagesId + '>' + json[i].MemberID + '</a></td>');
                tr.append("<td>" + json[i].Name + "</td>");
                tr.append("<td>" + json[i].LanguageName + "</td>");
                tr.append("<td>" + json[i].ToRead + "</td>");
                tr.append("<td>" + json[i].ToWrite + "</td>");
                tr.append("<td>" + json[i].ToSpeak + "</td>");
                tr.append('<td><a href="UserLanguagesView" onclick="return getbyID(' + json[i].KnownLanguagesId + ')">View</a></td>')
                $('table').append(tr);

            }
            $('#EmpInfo').DataTable();
        });
}