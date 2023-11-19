function AddMember1() {
    //var res = validate();
    //if (res == false) {
    //    return false;
    //}



    var general =
    {

        // DoccumentName: $('#DoccumentName').val(),
        // DoccumentName: $("#tbl_FomDoc option:selected").text(),
        INSTID: $('#MemberId').val(),
        InstName: $('#instName').val(),
        InstType: $('#insttype').val()
    };
    
    $.ajax({
        url: "/Socity1/AddMember",
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