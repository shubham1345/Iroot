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
                tr.append("<td hidden='hidden'>" + json[i].SocialInstitutionId + "</td>");
                //tr.append('<td><a href="#"/' + json[i].BookOfAccountsId + '>' + json[i].DoccumentName + '</a></td>');

                tr.append("<td>" + json[i].CommunityName + "</td>");
                tr.append("<td>" + json[i].InstitutionName + "</td>");
                tr.append("<td>" + json[i].EstablishDate + "</td>");
                tr.append("<td>" + json[i].Place + "</td>");
                tr.append("<td>" + json[i].Address + "</td>");
                tr.append("<td>" + json[i].ContactNumber + "</td>");
                tr.append("<td>" + json[i].Website + "</td>");

                tr.append("<td> <a href=/Images/SocialInstitutionDoc/" + json[i].File + " view>View</a></td>");
                $('table').append(tr);

            }
            $('#EmpInfo').DataTable();
        });
}