$("#TabProvince").change(function () {
    var rolename = $("#TabUserRole option:selected").text();
    var provinceId = $("#TabProvince option:selected").val();
    //var selectedVal = $("#UserRole option:selected").val();
    AllCheckedORUncheck1(rolename);
    GetAllTabPermissionByRoleName(rolename, provinceId);
});

$("#TabSaveUpBtn").on("click", function () {
  //debugger;
    var selectedText = $("#TabUserRole option:selected").text();
    var selectedVal = $("#TabUserRole option:selected").val();
    var province = $("#TabProvince option:selected").val();
    if (province == "") {
        alert("Please Select Province Name !");
        return false;
    }
    SaveTabsPermission(selectedVal, selectedText, province);
});

function AllCheckedORUncheck1(value) {
    //if (value == "admin") {
    //    $("input[name=tabPermissions]").prop('checked', 'checked');
    //} else {
    //    $('input[name=tabPermissions]').removeProp('checked');
    //}
    $('input[name=tabPermissions]').removeProp('checked');
    if (value == "--Select Role--") {
        return false;
    }
}
function SaveTabsPermission(roleid, rolename, provinceId) {
  //debugger;
    var ck_box = $('input[name="tabPermissions"]:checked').length;
    var listSaveData1 = [];
    if (ck_box == 0) {
        alert("Please select Permission");
        return false;
    } else if (roleid == 0) {
        alert("Please select Role");
        return false;
    }
    $.each($('input[name=tabPermissions]'), function () {
        var checkboxVal = $(this).val();
        var data = {};
        data.RoleId = roleid;
        data.RoleName = rolename;
        data.provinceId = provinceId;
        data.TabName = checkboxVal;
        data.TabViewName = $(this).attr("name");
        data.TabId = $(this).attr("data-val");
        if (this.checked) {
            data.IsPermission = true;
        } else {
            data.IsPermission = false;
        }
        listSaveData1.push(data);
    });

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "/RolePermission/SaveUpdateTabsPermissions",
        data: JSON.stringify(listSaveData1),
        dataType: "json",
        success: function (data) {
            if (data == true) {
                alert("Tab Permission save Successfully.");
            }
        },
        error: function (result) {
          //debugger;
            alert("Some Error Occure");
        }
    });
}

function GetAllTabPermissionByRoleName(roleName, provinceId) {
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        url: "/RolePermission/GetAllTabByRoleName?roleName=" + roleName + "&provinceId=" + provinceId,
        dataType: "json",
        success: function (data) {
          //debugger;
            bindAllCheckbox1(data);
        },
        error: function (result) {
            alert("Some Error Occure");
        }
    });
}

function bindAllCheckbox1(listData) {
    $('input[name=tabPermissions]').removeProp('checked');

    if (listData.length > 0) {

        $.each(listData, function (index, value) {
            if (value.IsPermission == "True") {
                var TabName = value.TabName;
                $(":checkbox[value='" + TabName + "']").prop("checked", "checked");
            }
        });
    }
}

$("#SelectAllTabPermissions").on("click", function () {
    $("input[name=tabPermissions]").prop('checked', $(this).prop('checked'));
});
