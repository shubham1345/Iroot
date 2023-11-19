function AddSocity() {
    //var res = validate();
    //if (res == false) {
    //    return false;
    //}

    var general =
    {
        // DoccumentName: $('#DoccumentName').val(),
        // DoccumentName: $("#tbl_FomDoc option:selected").text(),
        Date: $('#Place11').val(),
        Title: $('#Place22').val(),
        Catogery: $('#Place33').val(),
        Remark: $('#Place44').val()
    };
    
    $.ajax({
        url: "../Socity/Addso",
        data: JSON.stringify(general),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            alert("Record save successfully")
           
            $('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
function Adds() {
    //var res = validate();
    //if (res == false) {
    //    return false;
    //}



    var general =
    {

        // DoccumentName: $('#DoccumentName').val(),
        // DoccumentName: $("#tbl_FomDoc option:selected").text(),
        SocityName: $('#Place1').val(),
        Date: $('#Place2').val(),
        RegNo: $('#Place3').val(),
        PanNo: $('#Place4').val(),
        FCRANo: $('#Place5'),
        ANo: $('#Place6')
      
    };
    
    $.ajax({
        url: "/Socity1/Add",
        data: JSON.stringify(general),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            alert("Record save successfully")

            $('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}