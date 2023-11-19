$(document).ready(function () {
    loadData();
   
    $("a.sentclass").click(function () {
        if (!$("a.sentclass").hasClass("clsExist")) {

            sentData();
            $("a.sentclass").addClass("clsExist");
            $("#Inbox").css("display", "none");
            $('#sentbox').css("display", "block");
        }
    });

});
function sentData() {
  
    $.getJSON("/Gmail/GetEmailWithFileCount",
        function (json) {
          
            var tr;

            //Append each row to html table
            for (var i = 0; i < json.length; i++) {

                tr = $('<tr />');
                //tr.append("<td >" + json[i].EmailUniqueId + "</td>");
                tr.append("<td>" + json[i].ToAddress.replace(',', '  ') + "</td>");
                tr.append("<td>" + json[i].EmailSubject + "</td>");
                //tr.append('<td><a href=ViewProfile/' + json[i].EmailId + '>' + json[i].EmailSubject + '</a></td>');
                //tr.append("<td>" + json[i].Emailsenddate + "</td>");
                tr.append("<td>" + json[i].FileCount + "</td>");
                tr.append('<td><a href="#" id="' + json[i].EmailUniqueId + '"onclick="return GetDataByMailId(\'' + json[i].EmailUniqueId + '\')">View</a> | <a href="#"  onclick="return Delele(\'' + json[i].EmailUniqueId + '\')">Delete</a></td>')
                //tr.append('<td><a href="#" onclick="return GetDataByMailId((\'' + json[i].EmailUniqueId + '\')">View</a> | <a href="#" onclick="Delele(\'' + json[i].EmailUniqueId + '\')">Delete</a></td>')
                $('#sentboxbody').append(tr);

            }
            $('#EmpInfosent').DataTable({
                "order": [[1, "asc"]],
                retrieve: true
            });
        });
}
function GetDataByMailId(FileUniqueId) {

    $('table#FileInfo').html("");
    var url = '/Gmail/GetDataByMailId/' + FileUniqueId;
    $.ajax({
        url: url,
        type: 'GET',
        contentType: 'application/json;charset=UTF-8',
        dataType: "json",
        success: function (json) {

            var html = '';
            if (json[0].attchedfilename != null) {

                html += "<tr><td  width='20%'>" + 'EmailSubject' + "</td><td colspan='2'>" + json[0].EmailSubject + "</td><td></td></tr>";
                html += "<tr><td  width='20%'>" + 'EmailBody' + "</td><td td colspan='2'>" + json[0].EmailBody + "</td><td></td></tr>";
                html += "<tr ><td colspan='3' class='text-center'>" + 'Attachements' + "</td></tr>";

                var tab = "<tr><td width='10%'>" + 'FileSlno' + "</td><td width='45%'>" + 'attchedfilename' + "</td><td width='45%'>" + 'Action' + "</td></tr>";
                html += tab;
                for (var i = 0; i < json.length; i++) {
                    html += "<tr><td width='10%'>" + json[i].FileSlno + "</td><td width='45%'>" + json[i].attchedfilename + "</td><td width='45%'><a href='#' onclick='return GetDataByFileId(\"" + json[i].FileUniqueId + "\")'>Download</a></td></tr>";

                    //alert(json[i].attchedfilename);

                }

            }
            else if (json[0].attchedfilename == null) {

                html += "<tr><td>" + 'EmailSubject' + "</td><td>" + json[0].EmailSubject + "</td></tr>";
                html += "<tr><td>" + 'EmailBody' + "</td><td>" + json[0].EmailBody + "</td></tr>";
            }

            $('#FileInfo').append(html);
            $('#myModal').modal('show');
        },

        error: function (xhr, ajaxOptions, thrownError) {
            if (xhr.status == 404) {

            }
        }

    });


}
function GetDataByFileId(id) {
    //alert(id);
    var url = '/Gmail/GetFileDataByFileIdMethod/' + id;
    $.ajax({
        url: url,
        contentType: 'application/json; charset=utf-8',
        datatype: 'json',
        type: "GET",
        success: function () {
            window.location = url;
        }, error: function (xhr, ajaxOptions, thrownError) {

            //alert(thrownError);

        }
    });
}
function autocomplete1() {
    var url = '/Gmail/GetPersonaldetails';
    $.ajax({
        type: "GET",
        url: url,
        dataType: "json",
        async: true,
        success: function (data, status) {
            var items = data.toString().split(",");

            $('#PersonalDetails').autocomplete({
                minLength: 1,
                source: function (request, response) {
                    var term = request.term;

                    // substring of new string (only when a comma is in string)
                    if (term.indexOf(', ') > 0) {
                        var index = term.lastIndexOf(', ');
                        term = term.substring(index + 2);
                    }

                    // regex to match string entered with start of suggestion strings
                    var re = $.ui.autocomplete.escapeRegex(term);
                    var matcher = new RegExp('^' + re, 'i');
                    var regex_validated_array = $.grep(items, function (item, index) {
                        return matcher.test(item);
                    });

                    // pass array `regex_validated_array ` to the response and
                    // `extractLast()` which takes care of the comma separation
                    var data = $.ui.autocomplete.filter(regex_validated_array,
                         extractLast(term));

                    response($.ui.autocomplete.filter(regex_validated_array,
                         extractLast(term)));
                    //$.each(data, function (key, value) {
                    //    $("ul.result").append('<li class="ui-menu-item"><div tabindex="-1" class="ui-menu-item-wrapper">' + value + '</div></li>');

                    //});
                    //-- <li class="ui-menu-item"><div id="ui-id-2" tabindex="-1" class="ui-menu-item-wrapper">nanduconquer@gmail.com </div></li><li class="ui-menu-item"><div id="ui-id-3" tabindex="-1" class="ui-menu-item-wrapper">netproworld@gmail.com </div></li>


                },
                focus: function () {
                    return false;
                },
                select: function (event, ui) {
                    var terms = split(this.value);
                    terms.pop();
                    terms.push(ui.item.value);
                    terms.push('');
                    this.value = terms.join(', ');
                    return false;
                },
                messages: {
                    noResults: '',
                    results: function () { }
                }
            });

            function split(val) {
                return val.split(/,\s*/);
            }

            function extractLast(term) {
                return split(term).pop();
            }
        }
    });
}
function loadData() {
    var tb = document.getElementById('InboxInfo');
    while (tb.rows.length > 1) {
        tb.deleteRow(1);
    }

    $.getJSON("GetAll",
        function (json) {
            var tr;

            //Append each row to html table
            for (var i = 0; i < json.length; i++) {
                var result = new Date(+json[i].EmailDate.replace(/\/Date\((-?\d+)\)\//gi, "$1"));
                tr = $('<tr />');
              //  tr.append("<td hidden='hidden'>" + json[i].ID + "</td>");
                tr.append("<td>" + json[i].FromAddress + "</td>");
                //tr.append('<td><a href=ViewProfile/' + json[i].PersonalDetailsId + '>' + json[i].Name + '</a></td>');
                tr.append("<td>" + json[i].Subject + "</td>");
                tr.append("<td>" + (result.getMonth()+1)+"/"+result.getUTCDate() + "</td>");
                //tr.append("<td>" + json[i].EmailID + "</td>");
                //tr.append("<td>" + json[i].Mobile + "</td>");
                //tr.append("<td>" + json[i].MotherTongue + "</td>");
                //tr.append("<td>" + json[i].AadharNo + "</td>");
                tr.append('<td ><a href="#" onclick="return GetInboxDataByMailId(\'' + json[i].ID + '\')">View</a></td>');
                tr.append('<td><a href="#" onclick="DeleteInboxDataByMailId(\'' + json[i].ID + '\')">Delete</a></td>');
                $('table#InboxInfo').append(tr);

            }
            
            $('table#InboxInfo').DataTable();
        });

    
}
function DeleteInboxDataByMailId(ID) {
    alert(ID);
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/Gmail/deleteInboxrecord/" + ID,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {              
                $(this).closest('tr').remove();
              
                loadData();
                return result.data;
                //window.location.href = "~/Inbox/Inbox"

            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
};
function GetInboxDataByMailId(ID) {

    $('table#FileInfoInbox').html("");
    var url = '/Gmail/GetInboxDataByMailId/' + ID;
    $.ajax({
        url: url,
        type: 'GET',
        contentType: 'application/json;charset=UTF-8',
        dataType: "json",
        success: function (json) {

            var html = '';
            if (json[0].Filename != null) {

                html += "<tr><td colspan='2'>" + json[0].FromAddress + "</td><td></td></tr>";
                html += "<tr><td colspan='2'>" + json[0].CCAddress + "</td><td></td></tr>";
                html += "<tr><td colspan='2'>" + json[0].BCCAddress + "</td><td></td></tr>";
                html += "<tr><td td colspan='2'>" + json[0].Subject + "</td><td></td></tr>";
                html += "<tr><td td colspan='2'>" + json[0].asciiBody + "</td><td></td></tr>";
                html += "<tr ><td colspan='3' class='text-center'>" + 'Attachements' + "</td></tr>";

                var tab = "<tr><td width='10%'>" + 'FileSlno' + "</td><td width='45%'>" + 'Filename' + "</td><td width='45%'>" + 'Action' + "</td></tr>";
                html += tab;
                for (var i = 0; i < json.length; i++) {
                    html += "<tr><td width='10%'>" + json[i].FileSlno + "</td><td width='45%'>" + json[i].Filename + "</td><td width='45%'><a href='#' onclick='return GetDataByFileId(" + json[i].FileId + ")'>Download</a></td></tr>";

                    //alert(json[i].attchedfilename);

                }

            }
            else if (json[0].Filename == null) {
                html += "<tr><td colspan='2'>" + json[0].FromAddress + "</td><td></td></tr>";
                html += "<tr><td colspan='2'>" + json[0].CCAddress + "</td><td></td></tr>";
                html += "<tr><td colspan='2'>" + json[0].BCCAddress + "</td><td></td></tr>";
                html += "<tr><td>" + json[0].Subject + "</td></tr>";
                html += "<tr><td>" + json[0].asciiBody + "</td></tr>";
            }
        
            $('#FileInfoInbox').append(html);         
            $('#myModalInbox').modal('show');         
        },

        error: function (xhr, ajaxOptions, thrownError) {
            if (xhr.status == 404) {
                alert(thrownError);
            }
        }

    });
};