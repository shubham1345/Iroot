
$(document).ready(function () {
    $("#provincedata").hide();
    $("#HideSubmenuHeader").hide();
});

$("#Userrole").on('click', function () {
    var id = $("#Userrole").val();
    if (id == 0) {
        //alert("Please Select Role");
        return false;
        //GetGeneralateData();
    }
    GetRoleById(id);

});

$("#topmenuheader").on('click', function () {
    var id = $("#topmenuheader").val();
    if (id == 0) {
        //alert("Please Select Anything");
        return false;
        //GetGeneralateData();
    }
    GetSubMenuById(id);
});

$("#submenuchild").on('change', function () {
    var id = $("#submenuchild").val();
    var userroleid = $("#Userrole").val();
    if (id == 0) {
        //alert("Please Select Anything");
        return false;
        //GetGeneralateData();
    }
    GetSubmenuTabsById(id, userroleid);
});
$("#Userrole").on('change', function () {
    $("#submenuchild").html('');
    $("#topmenuheader").val(0);
});
function GetSubmenuTabsById(id, userroleid) {
    $.ajax({
        url: "/RolePermission/GetsubmenutabsById?id=" + id + "&roleid=" + userroleid,
        type: "GET",
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        success: function (response) {
            if (response.length > 0) {
                $("#HideSubmenuHeader").show();
                $("#Tblsubmenubody").empty();
                var html = "";
                for (var i = 0; i < response.length; i++) {
                    html += "<tr>";
                    html += "<td class='submenuname'>" + response[i].PageName + "</td>";
                    html += "<td>";
                    html += "<div clas='sexbox'>";
                    html += "<input id='Create' class='css-checkbox pageviewname' type='checkbox'  name='" + response[i].TopMenu_Id + "' name1='" + "' name2='MenuPermission' " + (response[i].HasPermission ? "checked" : "") + " />";
                    html += "<label for='Create' name='demo_lbl_2' class='css-label'></label>";
                    html += "</div>";
                    html += "</td>";
                    html += "<td>";
                    html += "<div clas='sexbox'>";
                    html += "<input id='Create' class='css-checkbox createpage' type='checkbox' value='Createpage' name2='MenuPermission' " + (response[i].Createpermission ? "checked" : "") + " />";
                    html += "<label for='Create' name='demo_lbl_2' class='css-label'></label>";
                    html += "</div>";
                    html += "</td>";
                    html += "<td>";
                    html += "<div clas='sexbox'>";
                    html += "<input id='Create' class='css-checkbox  Viewpage' type='checkbox' value='EditPage' name2='MenuPermission'  " + (response[i].Viewpermission ? "checked" : "") + " />";
                    html += "<label for='Create' name='demo_lbl_2' class='css-label'></label>";
                    html += "</div>";
                    html += "</td>";
                    html += "<td>";
                    html += "<div clas='sexbox'>";
                    html += "<input id='Create' class='css-checkbox Editpage ' type='checkbox' value='DeletePage' name2='MenuPermission'  " + (response[i].Editpermission ? "checked" : "") + " />";
                    html += "<label for='Create' name='demo_lbl_2' class='css-label'></label>";
                    html += "</div>";
                    html += "</td>";
                    html += "<td>";
                    html += "<div clas='sexbox'>";
                    html += "<input id='Create' class='css-checkbox Deletepage' type='checkbox' value='UpdatePage' name2='MenuPermission'  " + (response[i].Deletepermission ? "checked" : "") + " />";
                    html += "<label for='Create' name='demo_lbl_2' class='css-label'></label>";
                    html += "</div>";
                    html += "</td>";
                }
                $("#Tblsubmenubody").append(html);
            }
            else {
                $("#Tblsubmenubody").empty();
            }
        },
        error: function (erroremessage) {
            alert(erroremessage.responseText);
        }
    });
}

function GetSubMenuById(id) {
    $.ajax({
        url: "/RolePermission/GetsubmenuHeaderById?id=" + id,
        type: "GET",
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        success: function (response) {
            $("#submenuchild").html('');
            {
                if (response.length > 0) {
                    var allDate2 = [];
                    $('#submenuchild').html('').select2({ data: [{ id: '', text: '' }] });
                    allDate2.push({ id: '0', text: '-- Select Sub menu --' });
                    for (var i = 0; i < response.length; i++) {
                        allDate2.push({ id: checkNullValue(response[i].Submenu_Id), text: checkNullValue(response[i].Submenu_Name) });
                    }
                    $("#submenuchild").html('').select2({
                        data: allDate2
                    });
                }
            }


        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function GetRoleById(id) {
    $.ajax({
        url: "/RolePermission/GetRolepermissionById?id=" + id,
        type: "GET",
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        success: function (response) {
            $("#Personelname").html('');
             {
                if (response.length > 0) {
                    var allDate2 = [];
                    $('#Personelname').html('').select2({ data: [{ id: '', text: '' }] });
                    allDate2.push({ id: '0', text: '-- Select Name --' });
                    for (var i = 0; i < response.length; i++) {
                        allDate2.push({ id: checkNullValue(response[i].MemberID), text: checkNullValue( response[i].Name + " " + response[i].SirName )});
                    }
                    $("#Personelname").html('').select2({
                        data: allDate2
                    });
                }
            }
            
           
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function checkNullValue(val) {
    return val == null ? "" : val;
}

function GetGeneralateData() {
    $("#provincedata").hide();
    $.ajax({
        url: "/RolePermission/GetGeneralatedata?provinceid=0",
        type: "GET",
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        success: function (result) {
            if (result.length > 0) {
                var allDate2 = [];
                var omObj2 = {};
                $('#Personelname').html('').select2({ data: [{ id: '', text: '' }] });
                allDate2.push({ id: '0', text: '-- Select Name --' });
                for (var i = 0; i < result.length; i++) {
                    allDate2.push({ id: result[i].MemberID, text: result[i].Name + " " + result[i].SirName });
                    //allDate2.push({ id: response2[i].Id, text: response2[i].ProvinceName + " " + " " + response2[i].Place });
                }
                $("#Personelname").html('').select2({
                    data: allDate2
                });
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    });
}

function GetAllProvince() {

    $("#provincedata").show();
    $("#Personelname").html('');
    $.ajax({
        url: "/RolePermission/GetAllProvinceData",
        type: "GET",
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        success: function (result) {
            if (result.length > 0) {
                var allDate2 = [];
                $('#Provincelist').html('').select2({ data: [{ id: '', text: '' }] });
                allDate2.push({ id: '0', text: '-- Select Name --' });
                for (var i = 0; i < result.length; i++) {
                    allDate2.push({ id: result[i].MyId, text: result[i].ProvinceName + " " + result[i].Place });
                    //allDate2.push({ id: response2[i].Id, text: response2[i].ProvinceName + " " + " " + response2[i].Place });
                }
                $("#Provincelist").html('').select2({
                    data: allDate2
                });
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    });
}

$("#Provincelist").on("change", function () {
    var provincid = $("#Provincelist").val();
    if (provincid != "") {
        $.ajax({
            url: "/RolePermission/GetGeneralatedata?provinceid=" + provincid,
            type: "GET",
            dataType: "json",
            contentType: "application/json;charset=utf-8",
            success: function (result) {
                if (result.length > 0) {
                    var allDate2 = [];
                    $('#Personelname').html('').select2({ data: [{ id: '', text: '' }] });
                    allDate2.push({ id: '0', text: '-- Select Name --' });
                    for (var i = 0; i < result.length; i++) {
                        allDate2.push({ id: result[i].MemberID, text: result[i].Name + " " + result[i].SirName });
                        //allDate2.push({ id: response2[i].Id, text: response2[i].ProvinceName + " " + " " + response2[i].Place });
                    }
                    $("#Personelname").html('').select2({
                        data: allDate2
                    });
                }
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }

        });
    }
    //alert(provincid);

});

$("#submenuchildd").on('click', function () {
    var id = $("#submenuchildd").val();
    if (id == 0) {
        return false;
    }
    else {
        $.ajax({
            url: "/RolePermission/GetsubmenutabsById?id=" + id,
            type: "GET",
            dataType: "json",
            contentType: "application/json;charset=utf-8",
            success: function (response) {
                if (response.length > 0) {
                    $("#HideSubmenuHeader").show();
                    $("#Tblsubmenubody").empty();
                    var html = "";
                    for (var i = 0; i < response.length; i++) {
                        html += "<tr>";
                        html += "<td class='submenuname'>" + response[i].Submenutab_Name + "</td>";
                        html += "<td>";
                        html += "<div clas='sexbox'>";
                        html += "<input id='Create' class='css-checkbox pageviewname' type='checkbox'  name='" + response[i].Submenu_Id + "' name1='"  + "' name2='MenuPermission' />";
                        html += "<label for='Create' name='demo_lbl_2' class='css-label'></label>";
                        html += "</div>";
                        html += "</td>";
                        html += "<td>";
                        html += "<div clas='sexbox'>";
                        html += "<input id='Create' class='css-checkbox createpage' type='checkbox' value='Createpage' name2='MenuPermission'/>";
                        html += "<label for='Create' name='demo_lbl_2' class='css-label'></label>";
                        html += "</div>";
                        html += "</td>";
                        html += "<td>";
                        html += "<div clas='sexbox'>";
                        html += "<input id='Create' class='css-checkbox Editpage' type='checkbox' value='EditPage' name2='MenuPermission' />";
                        html += "<label for='Create' name='demo_lbl_2' class='css-label'></label>";
                        html += "</div>";
                        html += "</td>";
                        html += "<td>";
                        html += "<div clas='sexbox'>";
                        html += "<input id='Create' class='css-checkbox Deletepage' type='checkbox' value='DeletePage' name2='MenuPermission' />";
                        html += "<label for='Create' name='demo_lbl_2' class='css-label'></label>";
                        html += "</div>";
                        html += "</td>";
                        html += "<td>";
                        html += "<div clas='sexbox'>";
                        html += "<input id='Create' class='css-checkbox Viewpage' type='checkbox' value='UpdatePage' name2='MenuPermission' />";
                        html += "<label for='Create' name='demo_lbl_2' class='css-label'></label>";
                        html += "</div>";
                        html += "</td>";
                    }
                    $("#Tblsubmenubody").append(html);
                }
            },
            error: function (erroremessage) {
                alert(erroremessage.responseText);
            }
        });
    }
});

$("#topmenuheaderr").on('click', function () {
    var id = $("#topmenuheaderr").val();
    if (id == 0) {
        return false;
    }
    else {
        $.ajax({
            url: "/RolePermission/GetsubmenuHeaderById?id=" + id,
            type: "GET",
            dataType: "json",
            contentType: "application/json;charset=utf-8",
            success: function (response) {
                if (response.length > 0) {
                    $("#HideSubmenuHeader").show();
                    $("#Tblsubmenubody").empty();
                    var html = "";
                    for (var i = 0; i < response.length; i++) {
                        html += "<tr>";
                        html += "<td class='submenuname'>" + response[i].Submenu_Name + "</td>";
                        html += "<td>";
                        html += "<div clas='sexbox'>";
                        html += "<input id='Create' class='css-checkbox pageviewname' type='checkbox'  name='" + response[i].Topmenu_Id + "' name1='" + response[i].Page_name + "' name2='MenuPermission' />";
                        html += "<label for='Create' name='demo_lbl_2' class='css-label'></label>";
                        html += "</div>";
                        html += "</td>";
                        html += "<td>";
                        html += "<div clas='sexbox'>";
                        html += "<input id='Create' class='css-checkbox createpage' type='checkbox' value='Createpage' name2='MenuPermission'/>";
                        html += "<label for='Create' name='demo_lbl_2' class='css-label'></label>";
                        html += "</div>";
                        html += "</td>";
                        html += "<td>";
                        html += "<div clas='sexbox'>";
                        html += "<input id='Create' class='css-checkbox Editpage' type='checkbox' value='EditPage' name2='MenuPermission' />";
                        html += "<label for='Create' name='demo_lbl_2' class='css-label'></label>";
                        html += "</div>";
                        html += "</td>";
                        html += "<td>";
                        html += "<div clas='sexbox'>";
                        html += "<input id='Create' class='css-checkbox Deletepage' type='checkbox' value='DeletePage' name2='MenuPermission' />";
                        html += "<label for='Create' name='demo_lbl_2' class='css-label'></label>";
                        html += "</div>";
                        html += "</td>";
                        html += "<td>";
                        html += "<div clas='sexbox'>";
                        html += "<input id='Create' class='css-checkbox Viewpage' type='checkbox' value='UpdatePage' name2='MenuPermission' />";
                        html += "<label for='Create' name='demo_lbl_2' class='css-label'></label>";
                        html += "</div>";
                        html += "</td>";
                    }
                    $("#Tblsubmenubody").append(html);
                }
            },
            error: function (erroremessage) {
                alert(erroremessage.responseText);
            }
        });
    }
});

$("#BtnTopmenusave").on('click', function () {
    var userroleid = $("#Userrole").val();
    var membername = $("#Personelname").val();
    var topmenuid = $("#topmenuheader").val();

    var listsavedata = [];
    var listdave = [];
    //var ckbox = $('input[name1="submenupermission"]:checked').length;
    //if (ckbox == 0) {
    //    alert("Please Select Permission");
    //    return false;
    //}
    //else
        if (userroleid == 0) {
        alert("Please Select Role");
        return false;
    }

    //$("#Tblsubmenubody tr").each(function () {

    //    var i = 1;
    //    var data = {};
    //    data.Incre = i++;
    //    data.RoleId = userroleid;
    //    data.MemberName = membername;
    //    data.TopMenuHeader_Id = topmenuid;
    //    data.PageName = $(".pageviewname").attr("name2");
    //    data.PageViewName = $(".pageviewname").attr("name1");
    //    data.ParentId = $(".pageviewname").attr("name");
    //    data.CreatePageview = $(".createpage").val();
    //    data.EditPageview = $(".Editpage").val();
    //    data.DeletePageview = $(".Deletepage").val();
    //    data.ViewPageview = $(".Viewpage").val();

        

    //    if ($(".createpage").prop('checked')) {
    //        data.Createpermission = true;
    //    }
    //    else {
    //        data.Createpermission = false;
    //    }

    //    if ($(".Editpage").prop('checked')) {
    //        data.Editpermission = true;
    //    }
    //    else {
    //        data.Editpermission = false;
    //    }

    //    if ($(".Deletepage").prop('checked')) {
    //        data.Deletepermission = true;
    //    }
    //    else {
    //        data.Deletepermission = false;
    //    }

    //    if ($(".Viewpage").prop('checked')) {
    //        data.Viewpermission = true;
    //    }
    //    else {
    //        data.Viewpermission = false;
    //    }
    //    listsavedata.push(data);


    //});

    //console.log("Listsavedata", listsavedata);

    $('#Tblsubmenubody tr').each(function () {
        var self = $(this);
        var data = {};
        data.RoleId = userroleid;
        data.MemberId = membername;
        data.TopMenuHeader_Id = topmenuid;
        data.PageName = self.find("td:eq(0)").text();
        data.PageViewName = self.find("td:eq(1) input[type='checkbox']").attr("name1");
        data.ParentId = self.find("td:eq(1) input[type='checkbox']").attr("name");
        data.CreatePageview = self.find("td:eq(2) input[type='checkbox']").val();
        data.ViewPageview= self.find("td:eq(3) input[type='checkbox']").val();
        data.EditPageview= self.find("td:eq(4) input[type='checkbox']").val();
        data.DeletePageview = self.find("td:eq(5) input[type='checkbox']").val();

        if (self.find("td:eq(1) input[type='checkbox']").prop('checked')) {
            data.HasPermission = true;
        }
        else
        {
            data.HasPermission = false;
        }

        if (self.find("td:eq(2) input[type='checkbox']").prop('checked')) {
            data.Createpermission = true;
        }
        else {
            data.Createpermission = false;
        }

        if (self.find("td:eq(4) input[type='checkbox']").prop('checked')) {
            data.Editpermission = true;
        }
        else {
            data.Editpermission = false;
        }

        if (self.find("td:eq(5) input[type='checkbox']").prop('checked')) {
            data.Deletepermission = true;
        }
        else {
            data.Deletepermission = false;
        }

        if (self.find("td:eq(3) input[type='checkbox']").prop('checked')) {
            data.Viewpermission = true;
        }
        else {
            data.Viewpermission = false;
        }

        listdave.push(data);
      
    });
    //console.log("listdata", listdave);
    //$.each($('input[name1="submenupermission"]'), function () {
    //    var checkboxval = $(this).val();
    //    var data = {};
    //    data.RoleId = userroleid;
    //    data.MemberName = membername;
    //    data.TopMenuHeader_Id = topmenuid;
    //    data.PageName = $(this).attr("name");
    //    data.PageViewName = checkboxval;
    //    data.ParentId = $(this).attr("data-val");


    //    if (this.checked) {
    //        data.HasPermission = true;
    //    }
    //    else {
    //        data.HasPermission = false;
    //    }
    //    listsavedata.push(data);
    //});

    $.ajax({
        url: "/RolePermission/SaveTopmenuPersmission",
        type: "POST",
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        data: JSON.stringify(listdave),
        success: function (result) {
            if (result == true) {
                alert("Permission Added Successfully");
                location.reload();
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

});

$("#inactive2").on('click', function () {
    $("input[name2=MenuPermission]").prop('checked', $(this).prop('checked'));
});
