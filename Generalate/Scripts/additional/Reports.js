//Load Data in Table when documents is ready 
$(document).ready(function () {
    loadPersonalDetailsDataByStatus();

});


$('#submitbtn').click(function () {
    var status = $('#Status').val();
    if (status == "Age") {
        $('#myAgeModal').modal('show');
        //var age = $('#Age').val();
        //alert(age);
        //loadPersonalDetailsDataByAge(age);
        //$('#myModal').modal('hide');
    }
    else {
        loadPersonalDetailsDataByStatus();
    }
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
                tr.append("<td hidden='hidden'>" + json[i].PersonalDetailsId + "</td>");
               // tr.append("<td>" + json[i].MemberID + "</td>");
                tr.append("<td>" + json[i].SirName + "</td>");
                tr.append("<td>" + json[i].Name + "</td>");
                tr.append('<td><a href=Index/' + json[i].MemberID + '>Details</a></td>');
                $('table').append(tr);

            }
            $('#EmpInfo').DataTable();
        });
}

//Load Data function 
function loadPersonalDetailsDataByStatus() {
    
    var tb = document.getElementById('EmpInfo');
    while (tb.rows.length > 1) {
        tb.deleteRow(1);
    }
    var obj = { status: $('#Status').val(), age: $('#Age').val() };
    //obj.status = $('#Status').val();
    //obj.age = $('#Age').val();

    $.ajax({
        url: "../AllReports/GetByStatus/",
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        data: JSON.stringify(obj),
        success: function (result) {
            var tr;
            for (var i = 0; i < result.length; i++) {
                
                tr = $('<tr />');
                tr.append("<td hidden='hidden'>" + result[i].PersonalDetailsId + "</td>");
               // tr.append("<td>" + result[i].MemberID + "</td>");
                tr.append("<td>" + result[i].Name + "</td>");
                tr.append("<td>" + result[i].SirName + "</td>");
                tr.append('<td><a href=Index/' + result[i].MemberID + '>Details</a></td>');
                $('table').append(tr);

            }
            $('#EmpInfo').DataTable();
            $('#Age').val("");
        },

        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    });

}