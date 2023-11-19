
//Load Data in Table when documents is ready 
$(document).ready(function ()
{
    loadData();
    loadDataListItems();
    loadGeneralNames();

    $('#printbtn').click(function () {
        window.open('../CommunityHouses/CommunityReport');
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
                tr.append("<td hidden='hidden'>" + json[i].CHId + "</td>");
                tr.append('<td><a href=ViewProfile/' + json[i].CHId + '>' + json[i].CommunityName + '</a></td>');
                tr.append("<td>" + json[i].VarCHId + "</td>");
                tr.append("<td>" + json[i].Address + "</td>");
                tr.append("<td>" + json[i].Activities + "</td>");
                tr.append("<td>" + json[i].Email + "</td>");
                tr.append("<td>" + json[i].Mobile + "</td>");
                tr.append("<td>" + json[i].SuperiorName + "</td>");
                tr.append("<td>" + json[i].CommunityProfile + "</td>");
                tr.append('<td><a href="#" onclick="return getbyID(' + json[i].CHId + ')">Edit</a> | <a href="#" onclick="Delele(' + json[i].CHId + ')">Delete</a></td>')
                $('table').append(tr);

            }
            $('#EmpInfo').DataTable();
        });
}

function loadDataListItems() {
    $.ajax({
        url: "../CommonDataListItems/GetDatalistItemsByModuleName/?DlistName=CommunityHouses",
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


function loadGeneralNames() {
    $.ajax({
        url: "../CommonDataListItems/GetDatalistItemsByModuleName/?DlistName=General",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        //data : { "DlistName"},
        dataType: "json",
        success: function (result) {
            $("#generallist").empty();
            for (var i = 0; i < result.length; i++) {
                $("#generallist").append("<option value='" + result[i].DataListItemName + "'></option>");
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
            CHId: $('#CHId').val(),
            VarCHId: $('#VarCHId').val(),
            CommunityName: $('#CommunityName').val(),
            Address: $('#Address').val(),
            Email: $('#Email').val(),
            Mobile: $('#Mobile').val(),
            SuperiorName: $('#SuperiorName').val(),
            Activities: $('#Activities').val(),
            CommunityProfile: $('#CommunityProfile').val()

        };

    $.ajax({
        url: "../CommunityHouses/Add",
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
       url: "../CommunityHouses/GetById/" + GId1,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result)
        {
            $('#CHId').val(result.CHId);
            $('#SuperiorName').val(result.SuperiorName);
            $('#Email').val(result.Email);
            $('#Mobile').val(result.Mobile);
            $('#CommunityProfile').val(result.CommunityProfile);
            $('#CommunityName').val(result.CommunityName);
            $('#VarCHId').val(result.VarCHId);
            $('#Address').val(result.Address);
            $('#Activities').val(result.Activities);
            
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
            CHId: $('#CHId').val(),
            VarCHId: $('#VarCHId').val(),
            CommunityName: $('#CommunityName').val(),
            Address: $('#Address').val(),
            Email: $('#Email').val(),
            Mobile: $('#Mobile').val(),
            SuperiorName: $('#SuperiorName').val(),
            Activities: $('#Activities').val(),
            CommunityProfile: $('#CommunityProfile').val()

         };

    $.ajax({
        url: "../CommunityHouses/Update",
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
            url: "../CommunityHouses/Delete/" + ID,
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

    $('#CHId').val(""),
    $('#VarCHId').val(""),
    $('#CommunityName').val(""),
    $('#Address').val(""),
    $('#Email').val(""),
    $('#Mobile').val(""),
    $('#SuperiorName').val(""),
    $('#Activities').val(""),
    $('#CommunityProfile').val("")

    $('#btnUpdate').hide();
    $('#btnAdd').show();

    $('#CHId').css('border-color', 'lightgrey');
    $('#VarCHId').css('border-color', 'lightgrey');
    $('#CommunityName').css('border-color', 'lightgrey');
    $('#Address').css('border-color', 'lightgrey');
    $('#Email').css('border-color', 'lightgrey');
    $('#Mobile').css('border-color', 'lightgrey');
    $('#CommunityProfile').css('border-color', 'lightgrey');
    $('#SuperiorName').css('border-color', 'lightgrey');
    $('#Activities').css('border-color', 'lightgrey');
}

//Valdidation using jquery 
function validate()
{
    var isValid = true;
    if ($('#VarCHId').val().trim() == "")
    {
        $('#VarCHId').css('border-color', 'Red'); isValid = false;
    }
    else
    {
        $('#VarCHId').css('border-color', 'lightgrey');
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
    if ($('#SuperiorName').val().trim() == "") {
        $('#SuperiorName').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#SuperiorName').css('border-color', 'lightgrey');
    }
    return isValid;
}