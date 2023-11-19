$("#Province").change(function () {
    var rolename = $("#UserRole option:selected").text();
    var provinceId = $("#Province option:selected").val();
    //var selectedVal = $("#UserRole option:selected").val();
    AllCheckedORUncheck(rolename);
    GetAllPermissionByRoleName(rolename, provinceId);
});

$("#SaveUpBtn").on("click", function () {
  //debugger;
    var selectedText = $("#UserRole option:selected").text();
    var selectedVal = $("#UserRole option:selected").val();
    var province = $("#Province option:selected").val();
    if (province=="") {
        alert("Please Select Province Name !");
        return false;
    }
    SaveRolePermission(selectedVal, selectedText, province);
});

function AllCheckedORUncheck(value) {
    if (value == "Administrator") {
        $("input:checkbox").prop('checked', 'checked');
    } else {
        $('input[type=checkbox]').removeProp('checked');
    }
    if (value == "--Select Role--") {
        return false;
    }
}
function SaveRolePermission(roleid, rolename, provinceId) {
  //debugger;
    var ck_box = $('input[name1="MenuPermission"]:checked').length;
    var listSaveData = [];
    if (ck_box == 0) {
        alert("Please select Permission");
        return false;
    } else if (roleid==0) {
        alert("Please select Role");
        return false;
    }
    $.each($('input[name1="MenuPermission"]'), function () {
      //debugger;
        var checkboxVal = $(this).val();
        var data = {};
        data.RoleId = roleid;
        data.RoleName = rolename;
        data.provinceId = provinceId;
        data.PageName = checkboxVal;
        data.PageViewName = $(this).attr("name");
        data.ParentId = $(this).attr("data-val");
      
        if (this.checked) {
            data.HasPermission = true;
        } else {
            data.HasPermission = false;
        }
        listSaveData.push(data);
    });

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "/RolePermission/SaveUpdateRolePermissions",
        data: JSON.stringify(listSaveData),
        dataType: "json",
        success: function (data) {
            if (data == true) {
                alert("Role Page Permission save Successfully.");
            }  
        },
        error: function (result) {
            alert("Some Error Occure");
        }
    });
}

function GetAllPermissionByRoleName(roleName, provinceId) {
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        url: "/RolePermission/GetAllPageByRoleName?roleName=" + roleName + "&provinceId=" + provinceId,
        dataType: "json",
        success: function (data) {
            bindAllCheckbox(data);
        },
        error: function (result) {
            alert("Some Error Occure");
        }
    });
}

function bindAllCheckbox(listData) {
    $('input[type=checkbox]').removeProp('checked');

    if (listData.length > 0) {

        $.each(listData,function (index, value) {
            if (value.HasPermission) {
                var roleName = value.PageName;
                $(":checkbox[value='" + roleName+"']").prop("checked", "checked");
            }  
        });
    }
}

$("#SelectAllPermissions").on("click", function () {
    $("input[name1=MenuPermission]").prop('checked', $(this).prop('checked'));
});

$(document).ready(function () {
    $("#TabSavetopmenubtn").on("click", function () {
        //debugger;
        var selectedText = $("#UserRole option:selected").text();
        var selectedVal = $("#UserRole option:selected").val();
        var province = $("#Province option:selected").val();
        if (province == "") {
            alert("Please Select Province Name !");
            return false;
        }
        SaveRoleTopTabPermission(selectedVal, selectedText, province);
    });
});

function SaveRoleTopTabPermission(roleid, rolename, provinceId) {
    //debugger;
    var ck_box = $('input[name1="MenuPermission"]:checked').length;
    var listSaveData = [];
    if (ck_box == 0) {
        alert("Please select Permission");
        return false;
    } else if (roleid == 0) {
        alert("Please select Role");
        return false;
    }
    $.each($('input[name1="MenuPermission"]'), function () {
        //debugger;
        var checkboxVal = $(this).val();
        var data = {};
        data.RoleId = roleid;
        data.RoleName = rolename;
        data.provinceId = provinceId;
        data.PageName = checkboxVal;
        data.PageViewName = $(this).attr("name");
        data.ParentId = $(this).attr("data-val");

        if (this.checked) {
            data.HasPermission = true;
        } else {
            data.HasPermission = false;
        }
        listSaveData.push(data);
    });

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "/RolePermission/SaveUpdateRolePermissions",
        data: JSON.stringify(listSaveData),
        dataType: "json",
        success: function (data) {
            if (data == true) {
                alert("Role Page Permission save Successfully.");
            }
        },
        error: function (result) {
            alert("Some Error Occure");
        }
    });
}
