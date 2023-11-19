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
                tr.append("<td hidden='hidden'>" + json[i].SpiritualCommunityId + "</td>");
                //tr.append('<td><a href="#"/' + json[i].BookOfAccountsId + '>' + json[i].DoccumentName + '</a></td>');

                tr.append("<td>" + json[i].DoccumentName + "</td>");
                tr.append("<td>" + json[i].Title + "</td>");
                tr.append("<td>" + json[i].Date + "</td>");

                tr.append("<td> <a href=/Images/SpiritualCommunityDoc/" + json[i].File + " view>View</a></td>");
                $('table').append(tr);

            }
            $('#EmpInfo').DataTable();
        });
}