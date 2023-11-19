$(document).ready(function () {

    var weburl = "";
    if (!weburl) weburl = window.location.href
    var array = weburl.split('/');
    var no = getUrlVars()["id"];
    getallstudentplacementdetails1(no);
    //getdowmload(no);

});
function getUrlVars() {
    var vars = [], hash;
    var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < hashes.length; i++) {
        hash = hashes[i].split('=');
        vars.push(hash[0]);
        vars[hash[0]] = hash[1];
    }
    return vars;
}






   $(function () {
    $('#PlacementSave_btn').click(function () {


        var verchk = $('#checkselected').is(':checked');
        var nonverchk = $('#checknotselected').is(':checked');
        var status = "";
        if (verchk == false && nonverchk == false)
        {
            status = "";
        }
        else
        {
            if (verchk == true)
            {
                status = "verified";

            }
       else {
                status = "notverified";
            }
        }

        var verchkk = $('#CancelStatus').is(':checked');
        var nonverchkk = $('#NotCancelStatus').is(':checked');
        var statuss = "";
        if (verchkk == false && nonverchkk == false)
        {
            statuss = "";
        }
        else
        {
            if (verchkk == true)
            {
                statuss = "Cancel";
            }
            else
            {
                statuss = "notCancel";

            }
        }


        var carrier =
        {
            
            CancelStatus: statuss,
            Applystatus: status,

        };

        $.ajax({
            type: "POST",
            url: "Student.asmx/ Addstatuss",
            data: JSON.stringify({ 'status': carrier }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                //ClearPlacement();
                window.location.href = "ChangeStatAdmin.aspx";
            }
        });
    });
});






