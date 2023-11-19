
//Load Data in Table when documents is ready 
$(document).ready(function ()
{
    loadData();
    loadDataListItems();
    loadProvinceDataListItems();

    $('#printbtn').click(function () {
        window.open('../Provincial/ProvincialReport');
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
                tr.append("<td hidden='hidden'>" + json[i].PId + "</td>");
                tr.append('<td><a href=ViewProfile/' + json[i].PId + '>' + json[i].Name + '</a></td>');
                tr.append("<td>" + json[i].Province + "</td>");
                tr.append("<td>" + json[i].CommencementDate + "</td>");
                tr.append("<td>" + json[i].CompletionDate + "</td>");
                tr.append("<td>" + json[i].Place + "</td>");
                tr.append("<td>" + json[i].Designation + "</td>");
                tr.append('<td><a href="#" onclick="return getbyID(' + json[i].PId + ')">Edit</a> | <a href="#" onclick="Delele(' + json[i].PId + ')">Delete</a></td>')
                $('table').append(tr);

            }
            $('#EmpInfo').DataTable();
        });
}

function loadDataListItems() {
    $.ajax({
        url: "../CommonDataListItems/GetDatalistItemsByModuleName/?DlistName=Provincial",
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

function loadProvinceDataListItems() {
    $.ajax({
        url: "../CommonDataListItems/GetDatalistItemsByModuleName/?DlistName=Province",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        //data : { "DlistName"},
        dataType: "json",
        success: function (result) {
            $("#Provincelst").empty();
            for (var i = 0; i < result.length; i++) {
                $("#Provincelst").append("<option value='" + result[i].DataListItemName + "'></option>");
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
            
            PId: $('#PId').val(),
            VarPId: $('#VarPId').val(),
            Name: $('#Name').val(),
            CommencementDate: $('#CommencementDate').val(),
            CompletionDate: $('#CompletionDate').val(),
            Place: $('#Place').val(),
            Designation: $('#Designation').val(),
            Province: $('#Province').val()
        };

    $.ajax({
        url: "../Provincial/Add",
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
       url: "../Provincial/GetById/" + GId1,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result)
        {
            
            $('#PId').val(result.PId);
            $('#Name').val(result.Name);
            $('#CommencementDate').val(result.CommencementDate);
            $('#CompletionDate').val(result.CompletionDate);
            $('#Place').val(result.Place);
            $('#Designation').val(result.Designation);
            $('#VarPId').val(result.VarPId);
            $('#Province').val(result.Province);
            
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
            PId: $('#PId').val(),
            Name: $('#Name').val(),
            CommencementDate: $('#CommencementDate').val(),
            CompletionDate: $('#CompletionDate').val(),
            Place: $('#Place').val(),
            Designation: $('#Designation').val(),
            VarPId: $('#VarPId').val(),
            Province: $('#Province').val()
         };

    $.ajax({
        url: "../Provincial/Update",
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
            url: "../Provincial/Delete/" + ID,
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

    $('#PId').val("");
    $('#Name').val("");
    $('#CommencementDate').val("");
    $('#CompletionDate').val("");
    $('#Place').val("");
    $('#Designation').val("");
    $('#VarPId').val("");
    $('#Province').val("")

    $('#btnUpdate').hide();
    $('#btnAdd').show();

    $('#PId').css('border-color', 'lightgrey');
    $('#Name').css('border-color', 'lightgrey');
    $('#CommencementDate').css('border-color', 'lightgrey');
    $('#CompletionDate').css('border-color', 'lightgrey');
    $('#Place').css('border-color', 'lightgrey');
    $('#Designation').css('border-color', 'lightgrey');
    $('#VarPId').css('border-color', 'lightgrey');
    $('#Province').css('border-color', 'lightgrey');
}

//Valdidation using jquery 
function validate()
{
    var isValid = true;
    if ($('#Name').val().trim() == "")
    {
        $('#Name').css('border-color', 'Red'); isValid = false;
    }
    else
    {
        $('#Name').css('border-color', 'lightgrey');
    }
    if ($('#CommencementDate').val().trim() == "")
    {
        $('#CommencementDate').css('border-color', 'Red'); isValid = false;
    }
    else
    {
        $('#CommencementDate').css('border-color', 'lightgrey');
    }
    if ($('#CompletionDate').val().trim() == "")
    {
        $('#CompletionDate').css('border-color', 'Red'); isValid = false;
    }
    else
    {
        $('#CompletionDate').css('border-color', 'lightgrey');
    }
    if ($('#Place').val().trim() == "")
    {
        $('#Place').css('border-color', 'Red'); isValid = false;
    }
    else
    {
        $('#Place').css('border-color', 'lightgrey');
    }
    if ($('#Designation').val().trim() == "") {
        $('#Designation').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#Designation').css('border-color', 'lightgrey');
    }
    if ($('#VarPId').val().trim() == "") {
        $('#VarPId').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#VarPId').css('border-color', 'lightgrey');
    }
    if ($('#Province').val().trim() == "") {
        $('#Province').css('border-color', 'Red'); isValid = false;
    }
    else {
        $('#Province').css('border-color', 'lightgrey');
    }
    
    return isValid;
}