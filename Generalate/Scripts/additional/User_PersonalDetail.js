$(document).ready(function () {
    loadPersonalDetailsDataByStatus();
});

function loadPersonalDetailsDataByStatus() {
    
    var tb = document.getElementById('EmpInfo');
    while (tb.rows.length > 1) {
        tb.deleteRow(1);
    }
   // var obj = { status: $('#Status').val(), age: $('#Age').val() };
    //obj.status = $('#Status').val();
    //obj.age = $('#Age').val();

    $.ajax({
        url: "../User_EmergencyContact/GetByStatus/",
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        data: JSON.stringify(),
        success: function (json) {
            var tr;
            for (var i = 0; i < json.length; i++) {
                tr = $('<tr />');
                tr.append("<td hidden='hidden'>" + json[i].PersonalDetailsId + "</td>");
                tr.append("<td>" + json[i].MemberID + "</td>");
                tr.append('<td><a href=""/' + json[i].PersonalDetailsId + '>' + json[i].Name + '</a></td>');
                //tr.append("<td>" + json[i].FatherName + "</td>");
                //tr.append("<td>" + json[i].DOB + "</td>");
                //tr.append("<td>" + json[i].EmailID + "</td>");
                //tr.append("<td>" + json[i].Mobile + "</td>");
                //tr.append("<td>" + json[i].MotherTongue + "</td>");
                //tr.append("<td>" + json[i].AadharNo + "</td>");
                tr.append('<td><a href=User_PersonalDetails/' + json[i].MemberID + '>View</a></td>');
             
                $('table').append(tr);
                
            }
        },

        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    });

}
//function loadUserData() {
//    var tb = document.getElementById('EmpInfo');
//    while (tb.rows.length > 1) {
//        tb.deleteRow(1);
//    }

//    $.getJSON("GetAllPD",
//        function (json) {
//            var tr;

//            Append each row to html table
//            for (var i = 0; i < json.length; i++) {
//                tr = $('<tr />');
//                tr.append("<td hidden='hidden'>" + json[i].PersonalDetailsId + "</td>");
//                tr.append("<td>" + json[i].MemberID + "</td>");
//                tr.append('<td><a href=""/' + json[i].PersonalDetailsId + '>' + json[i].Name + '</a></td>');
//                tr.append("<td>" + json[i].FatherName + "</td>");
//                tr.append("<td>" + json[i].DOB + "</td>");
//                tr.append("<td>" + json[i].EmailID + "</td>");
//                tr.append("<td>" + json[i].Mobile + "</td>");
//                tr.append("<td>" + json[i].MotherTongue + "</td>");
//                tr.append("<td>" + json[i].AadharNo + "</td>");
//                tr.append('<td><a href="User_PersonalDetails"/' + json[i].MemberID + '>View</a></td>');
//                tr.append('<td><a href="User_PersonalDetails" onclick="return getbyID(' + json[i].MemberID + ')">View</a></td>')
//                $('table').append(tr);

//            }
//            $('#EmpInfo').DataTable();
//        });
//}