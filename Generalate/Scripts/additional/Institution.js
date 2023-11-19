
//Load Data in Table when documents is ready 
$(document).ready(function ()
{
    loadData();
    loadDataListItems();
    loadGeneralList();
    loadCommunityList();

    $('#printbtn').click(function () {
        window.open('../Institution/InstitutionReport');
    });
        
});


function loadData()
{
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
                tr.append("<td hidden='hidden'>" + json[i].INId + "</td>");
                tr.append('<td><a href=ViewProfile/' + json[i].INId + '>' + json[i].InstitutionName + '</a></td>');
                tr.append("<td>" + json[i].CommunityName + "</td>");
                tr.append("<td>" + json[i].VarINId + "</td>");
                tr.append("<td>" + json[i].Address + "</td>");
                tr.append("<td>" + json[i].Email + "</td>");
                tr.append("<td>" + json[i].Mobile + "</td>");
                tr.append("<td>" + json[i].Website + "</td>");
                tr.append('<td><a href="#" onclick="return getbyID(' + json[i].INId + ')">Edit</a> | <a href="#" onclick="Delele(' + json[i].INId + ')">Delete</a></td>')
                $('table').append(tr);

            }
            $('#EmpInfo').DataTable();
        });
}

function loadDataListItems() {
    $.ajax({
        url: "../CommonDataListItems/GetDatalistItemsByModuleName/?DlistName=Institution",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        //data : { "DlistName"},
        dataType: "json",
        success: function (result) {
            $("#generalst").empty();
            for (var i = 0; i < result.length; i++)
            {
                $("#generalst").append("<option value='" + result[i].DataListItemName + "'></option>");
            }

        },

        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    });

}

function loadGeneralList() {
    $.ajax({
        url: "../CommonDataListItems/GetDatalistItemsByModuleName/?DlistName=General",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        //data : { "DlistName"},
        dataType: "json",
        success: function (result) {
            $("#genlist").empty();
            for (var i = 0; i < result.length; i++) {
                $("#genlist").append("<option value='" + result[i].DataListItemName + "'></option>");
            }

        },

        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    });

}

function loadCommunityList() {
    $.ajax({
        url: "../CommonDataListItems/GetDatalistItemsByModuleName/?DlistName=CommunityHouses",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        //data : { "DlistName"},
        dataType: "json",
        success: function (result) {
            $("#communitylist").empty();
            for (var i = 0; i < result.length; i++) {
                $("#communitylist").append("<option value='" + result[i].DataListItemName + "'></option>");
            }

        },

        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    });

}

//Add Data Function 
function Add()
{
    var res = validate();
    if (res == false)
    {
        return false;
    }

    var datenow = new Date();
    
    var general =
        {
            INId: $('#INId').val(),
            VarINId: $('#VarINId').val(),
            InstitutionName: $('#InstitutionName').val(),
            CommunityName: $('#CommunityName').val(),
            Address: $('#Address').val(),
            Email: $('#Email').val(),
            Mobile: $('#Mobile').val(),
            Website: $('#Website').val()

        };

    $.ajax({
        url: "../Institution/Add",
        data: JSON.stringify(general),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result)
        {
            loadData();
            clearTextBox();
            $('#myModal').modal('hide');
        },
        error: function (errormessage)
        {
            alert(errormessage.responseText);
        }
    });
}

//Function for getting the Data Based upon Employee ID 
function getbyID(GId1)
{
   $.ajax({
       url: "../Institution/GetById/" + GId1,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result)
        {
            $('#INId').val(result.INId);
            $('#InstitutionName').val(result.InstitutionName);
            $('#CommunityName').val(result.CommunityName);
            $('#Website').val(result.Website);
            $('#Email').val(result.Email);
            $('#Mobile').val(result.Mobile);
            $('#VarINId').val(result.VarINId);
            $('#Address').val(result.Address);
            
            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage)
        {
            alert(errormessage.responseText);
        }
    }); return false;
}

//function for updating General's record 
function Update()
{
    var res = validate();
    if (res == false)
    {
        return false;
    }

    var datenow = new Date();
    
    var empObj =
        {
            INId: $('#INId').val(),
            VarINId: $('#VarINId').val(),
            InstitutionName: $('#InstitutionName').val(),
            CommunityName: $('#CommunityName').val(),
            Address: $('#Address').val(),
            Email: $('#Email').val(),
            Mobile: $('#Mobile').val(),
            Website: $('#Website').val()
         };

    $.ajax({
        url: "../Institution/Update",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result)
        {
            loadData();
            $('#myModal').modal('hide');
        },
        error: function (errormessage)
        {
            alert(errormessage.responseText);
        }
    });
}

//function for deleting employee's record 
function Delele(ID)
{
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans)
    {
        $.ajax({
            url: "../Institution/Delete/" + ID,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result)
            {
                $(this).closest('tr').remove()
                loadData();

            },
            error: function (errormessage)
            {
                alert(errormessage.responseText);
            }
        });
    }
}

//Function for clearing the textboxes 
function clearTextBox()
{

    $('#INId').val(""),
    $('#VarINId').val(""),
    $('#InstitutionName').val(""),
    $('#CommunityName').val(""),
    $('#Address').val(""),
    $('#Email').val(""),
    $('#Mobile').val(""),
    $('#Website').val("")
    
    $('#btnUpdate').hide();
    $('#btnAdd').show();

    $('#INId').css('border-color', 'lightgrey');
    $('#VarINId').css('border-color', 'lightgrey');
    $('#InstitutionName').css('border-color', 'lightgrey');
    $('#CommunityName').css('border-color', 'lightgrey');
    $('#Address').css('border-color', 'lightgrey');
    $('#Email').css('border-color', 'lightgrey');
    $('#Mobile').css('border-color', 'lightgrey');
    $('#Website').css('border-color', 'lightgrey');
    
}

//Valdidation using jquery 
function validate()
{
    var isValid = true;
    if ($('#VarINId').val().trim() == "")
    {
        $('#VarINId').css('border-color', 'Red'); isValid = false;
    }
    else
    {
        $('#VarINId').css('border-color', 'lightgrey');
    }
    if ($('#InstitutionName').val().trim() == "")
    {
        $('#InstitutionName').css('border-color', 'Red'); isValid = false;
    }
    else
    {
        $('#InstitutionName').css('border-color', 'lightgrey');
    }
    if ($('#CommunityName').val().trim() == "")
    {
        $('#CommunityName').css('border-color', 'Red'); isValid = false;
    }
    else
    {
        $('#CommunityName').css('border-color', 'lightgrey');
    }
    if ($('#Address').val().trim() == "")
    {
        $('#Address').css('border-color', 'Red'); isValid = false;
    }
    else
    {
        $('#Address').css('border-color', 'lightgrey');
    }
    if ($('#Email').val().trim() == "") {
        $('#Email').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#Email').css('border-color', 'lightgrey');
    }
    if ($('#Mobile').val().trim() == "") {
        $('#Mobile').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#Mobile').css('border-color', 'lightgrey');
    }
    if ($('#Website').val().trim() == "") {
        $('#Website').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#Website').css('border-color', 'lightgrey');
    }

    return isValid;
}