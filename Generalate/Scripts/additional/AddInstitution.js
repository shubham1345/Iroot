function AddInstitution() {
    //var res = validate();
    //if (res == false) {
    //    return false;
    //}



    var general =
    {

        // DoccumentName: $('#DoccumentName').val(),
        // DoccumentName: $("#tbl_FomDoc option:selected").text(),
        MemberID: $('#Int1').val(),
        FromDate: $('#int1').val(),
        Closingdate: $('#int2').val(),
        NameOfInstitution: $('#int3').val(),
        TypeOfInstitution: $('#int4').val(),

        NameOfDiocese: $('#int5').val(),
        OwenedBy: $('#int6').val(),
        MaintainedBy: $('#int7').val(),
        Address: $('#int8').val(),

        Telephone: $('#int9').val(),
        EmailID: $('#int10').val(),

       
        WebSite: $('#int11').val()


    };

    $.ajax({
        url: "/Socity1/AddInst",
        data: JSON.stringify(general),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            alert("Record in data save successfully")

            $('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}



function AddInstDetails() {
    //var res = validate();
    //if (res == false) {
    //    return false;
    //}



    var general =
    {

        // DoccumentName: $('#DoccumentName').val(),
        // DoccumentName: $("#tbl_FomDoc option:selected").text(),
        Date: $('#Place1').val(),
        Tital: $('#Place2').val(),
        Catogory: $('#Place3').val(),
        Remark: $('#Place4').val(),
       

    };

    $.ajax({
        url: "/Socity1/AddInstDetails",
        data: JSON.stringify(general),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            alert("Record in data save successfully")

            $('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}


function AddLandDetails() {
    //var res = validate();
    //if (res == false) {
    //    return false;
    //}



    var general =
    {

        // DoccumentName: $('#DoccumentName').val(),
        // DoccumentName: $("#tbl_FomDoc option:selected").text(),
        RegDate: $('#Land1').val(),
        RegNo: $('#Land2').val(),
        SurveNo: $('#Land3').val(),
        DocCatogery: $('#Land4').val(),
        Discreption: $('#Land5').val(),


    };

    $.ajax({
        url: "/Socity1/AddLandDetails",
        data: JSON.stringify(general),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            alert("Record in data save successfully")

            $('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}