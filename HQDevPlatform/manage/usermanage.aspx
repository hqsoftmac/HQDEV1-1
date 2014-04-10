<%@ Page Title="" Language="C#" MasterPageFile="~/WebContent.Master" AutoEventWireup="true" CodeBehind="usermanage.aspx.cs" Inherits="HQDevSys.manage.usermanage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../jquery.min.js" type="text/javascript"></script>
    <script src="../jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../Js/common.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHPageName" runat="server">
    用户管理
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHPageTool" runat="server">
    <a href="javascript:void(0)" class="btn" id="btnadd" iconCls="icon-add" onclick="adduser()">新增用户</a>
    <a href="javascript:void(0)" class="btn" id="btnstart" iconCls="icon-ok" onclick="startuser()">启用用户</a>
    <a href="javascript:void(0)" class="btn" id="btnstop" iconCls="icon-no" onclick="stopuser()">暂停用户</a>
    <a href="javascript:void(0)" class="btn" id="btndel" iconCls="icon-remove" onclick="deluser()">删除用户</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPHContent" runat="server">
    <div style="width:100%;margin:0 auto;">
        <div style="height:24px;clear:both;margin-top:0;padding:0;width:100%;">
            <div style="float:left;margin-left:10px;margin-top:3px;">
                <label for="txtsearch">用户检索</label>
            </div>
            <div style="float:left;margin-left:10px;">
                <input type="text" id="txtsearch" style="width:150px;" />
            </div>
            <div style="float:left;margin:-2px 0 0 10px;">
                <a href="javascript:void(0)" class="btn1" id="A1" iconCls="icon-search" onclick="searchuser()">查找用户</a>
            </div>
        </div>
        <div style="width:98%;margin:0 auto;clear:both;">
            <table id="usergrid" class="easyui-datagrid" title="用户列表" style="margin:2px auto;" data-options="singleSelect:false,fitColumns:true,idField:'FUserId',rownumbers:true,pagination:true">
                <thead>
                    <tr>
                        <th data-options="field:'FUserId',align:'center',checkbox:true">选择</th>
                        <th data-options="field:'FUserName',width:100,align:'center',sortable:true">用户名称</th>
                        <th data-options="field:'FUserDesc',width:120,align:'center',sortable:true">用户描述</th>
                        <th data-options="field:'FContactTel',width:100,align:'center',sortable:true">联系电话</th>
                        <th data-options="field:'FContactMobile',width:120,align:'center'">移动电话</th>
                        <th data-options="field:'FEmail',width:120,align:'center'">用户邮箱</th>
                        <th data-options="field:'FUserStatusName',width:100,align:'center'">用户状态</th>
                        <th data-options="field:'FOperation',width:160,align:'center'">操作</th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>
    <input type="hidden" id="hsortname" value="FUserId" />
    <input type="hidden" id="hsortdirection" value="asc" />
    <input type="hidden" id="hpagenum" value="1" />
    <input type="hidden" id="hpagesize" value="10" />

    <div id="addwin" iconCls="icon-save" title="用户资料" style="display:none;text-align:center;">  
        <table style="width: 380px;margin:10px auto;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">            
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    用户名称：
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <input type="hidden" id="huserid" value="0" />
                    <input type="text" id="txtusername" style="width:150px;" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    用户描述：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left:5px;text-align:left;" >
                    <input type="text" id="txtuserdesc" style="width:200px;" />
                </td>
            </tr>
             <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    联系电话：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left:5px;text-align:left;" >
                    <input type="text" id="txtcontacttel" style="width:150px;" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    电子信箱：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left:5px;text-align:left;" >
                    <input type="text" id="txtemail" style="width:150px;" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    手机号码：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left:5px;text-align:left;" >
                    <input type="text" id="txtmobile" style="width:150px;" />
                </td>
            </tr>
        </table>
        <div style="margin:20px auto;">
            <a href="javascript:void(0)" class="btn1" id="btnsave" iconCls="icon-save" onclick="save()">保存</a>&nbsp;&nbsp;
            <a href="javascript:void(0)" class="btn1" id="btnclose" iconCls="icon-cancel" onclick="closewin()" >取消</a>
        </div>  
    </div>
    <div id="authorwin" iconCls="icon-ok" title="用户角色" style="display:none;text-align:center;">
        <table id="rolegrid" class="easyui-datagrid" title="角色列表" style="margin:2px auto;width:360px;" data-options="singleSelect:false,collapsible:true,fitColumns:true,striped:true,idField:'FRoleId'">
            <thead>
                <tr>
                    <th data-options="field:'FRoleId',width:80,align:'center',checkbox:true">选择</th>
                    <th data-options="field:'FRoleName',width:120,align:'center'">角色名称</th>
                    <th data-options="field:'FRoleDesc',width:120,align:'left'">角色描述</th>
                </tr>
            </thead>
        </table>
    </div>
    <div id="authordeptwin" iconCls="icon-ok" title="用户部门数据授权" style="display:none;text-align:center;">
        <table id="deptgrid" class="easyui-datagrid" title="部门列表" style="margin:2px auto;width:445px;" data-options="singleSelect:false,collapsible:true,fitColumns:true,striped:true,idField:'FDepartmentID'">
            <thead>
                <tr>
                    <th data-options="field:'FDepartmentID',width:80,align:'center',checkbox:true">选择</th>
                    <th data-options="field:'FDepartmentCode',width:80,align:'center'">部门编号</th>
                    <th data-options="field:'FDepartmentName',width:120,align:'center'">部门名称</th>
                </tr>
            </thead>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="CPHJavascript" runat="server">
    <script type="text/javascript">
        function deptauthor(userid) {
            $.messager.progress();
            openwin("authordeptwin", 460, 450, true, "loadgriddata");
            loaddeptist(userid);
            $.messager.progress('close');
        }

        function closewin2() {
            $("#authordeptwin").window('close');
        }

        function loaddeptist(userid) {
            $('#deptgrid').datagrid({ loadMsg: '正在载入权限列表,请耐心等待...', toolbar: [{ text: '保存', iconCls: 'icon-save', handler: function () { savedept(); } }, { text: '取消', iconCls: 'icon-cancel', handler: function () { closewin2(); } }] });
            var deptlist = common.Data.GetDatasource("deptlist");
            $('#deptgrid').datagrid('loadData', deptlist);
            $('#deptgrid').datagrid('unselectAll');
            $('#huserid').val(userid);
            var options = {
                type: "POST",
                data: { puserid: userid },
                success: function (res) {
                    var json = common.Util.StringToJson(res);
                    $('#deptgrid').datagrid('loading');
                    for (var i = 0; i < json.length; i++) {
                        var deptid = json[i]['FDepartmentId'];
                        $('#deptgrid').datagrid('selectRecord', deptid);
                    }
                    $('#deptgrid').datagrid('loaded');
                }
            };
            common.Ajax("GetUserDeptList", options);
        }

        function closewin1() {
            $("#authorwin").window('close');
        }

        function resetpassword(userid) {
            $.messager.confirm('确认', '您是否确定要重置该用户的密码吗?', function (r) {
                if (!r) {
                    $('#usergrid').datagrid('unselectAll');
                    return;
                }
                else {
                    $.messager.progress();
                    var options = {
                        type: "POST",
                        data: { puserid: userid },
                        success: function (res) {
                            var json = common.Util.StringToJson(res);
                            if (json.ErrorCode == common.Consts.SuccessCode) {
                                $.messager.progress('close');
                                $.messager.alert('成功', "密码已经重置为 123456", 'ok');
                                $('#usergrid').datagrid('unselectAll');
                            }
                            else {
                                $.messager.progress('close');
                                $.messager.alert('警告', json.ErrorMessage, 'warning');
                                return;
                            }
                        }
                    };
                    common.Ajax("RestPsw", options);
                }
            });
        }

        function authoruser(userid) {
            $.messager.progress();
            openwin("authorwin", 375, 450, true, "loadgriddata");
            loadrolelist(userid);
            $.messager.progress('close');
        }

        function savedept() {
            var _userid = $("#huserid").val();
            var parm = "";
            parm = GetGridData("deptgrid", "FDepartmentID");
            $.messager.progress();
            var options = {
                type: "POST",
                data: { puserid: _userid, pdeptid: parm },
                success: function (res) {
                    var json = common.Util.StringToJson(res);
                    if (json.ErrorCode == common.Consts.SuccessCode) {
                        $.messager.progress('close');
                        closewin2();
                    }
                    else {
                        $.messager.progress('close');
                        $.messager.alert('警告', json.ErrorMessage, 'warning');
                        return;
                    }
                }
            };
            common.Ajax("SaveUserDept", options);
        }

        function saverole() {
            var _userid = $("#huserid").val();
            var parm = "";
            parm = GetGridData("rolegrid", "FRoleId");
            $.messager.progress();
            var options = {
                type: "POST",
                data: { puserid: _userid, proleid: parm },
                success: function (res) {
                    var json = common.Util.StringToJson(res);
                    if (json.ErrorCode == common.Consts.SuccessCode) {
                        $.messager.progress('close');
                        closewin1();
                    }
                    else {
                        $.messager.progress('close');
                        $.messager.alert('警告', json.ErrorMessage, 'warning');
                        return;
                    }
                }
            };
            common.Ajax("SaveUserRole", options);
        }

        function loadrolelist(userid) {
            $('#rolegrid').datagrid({ loadMsg: '正在载入权限列表,请耐心等待...', toolbar: [{ text: '保存', iconCls: 'icon-save', handler: function () { saverole(); } }, { text: '取消', iconCls: 'icon-cancel', handler: function () { closewin1(); } }] });
            var rolelist = common.Data.GetDatasource("rolelist");
            $('#rolegrid').datagrid('loadData', rolelist);
            $('#rolegrid').datagrid('unselectAll');
            $('#huserid').val(userid);
            var options = {
                type: "POST",
                data: { puserid: userid },
                success: function (res) {
                    var json = common.Util.StringToJson(res);
                    $('#rolegrid').datagrid('loading');
                    for (var i = 0; i < json.length; i++) {
                        var roleid = json[i]['FRoleId'];
                        $('#rolegrid').datagrid('selectRecord', roleid);
                    }
                    $('#rolegrid').datagrid('loaded');
                }
            };
            common.Ajax("GetUserRoleList", options);
        }
        
        function deluser() {
            var parm = GetGridData('usergrid', 'FUserId');
            if (!parm) {
                $.messager.alert('提示', '请选择要删除的用户!', 'info');
                return;
            }
            $.messager.confirm('确认', '您是否确定要删除选中的用户吗?', function (r) {
                if (!r) {
                    return;
                }
                else {
                    parm = "(" + parm + ")";
                    $.messager.progress();
                    var options = {
                        type: "POST",
                        data: { pparm: parm },
                        success: function (res) {
                            $.messager.progress('close');
                            var json = common.Util.StringToJson(res);
                            if (json.ErrorCode == common.Consts.SuccessCode) {
                                loadgriddata();
                            }
                            else {
                                $.messager.alert('警告', json.ErrorMessage, 'warning');
                                return;
                            }
                        }
                    };
                    common.Ajax("DeleteUser", options);
                }
            });
        }
        
        function stopuser() {
            var parm = GetGridData('usergrid', 'FUserId');
            if (!parm) {
                $.messager.alert('提示', '请选择要停用的用户!', 'info');
                return;
            }
            $.messager.confirm('确认', '您是否确定要停用选中的用户吗?', function (r) {
                if (!r) {
                    return;
                }
                else {
                    parm = "(" + parm + ")";
                    $.messager.progress();
                    var options = {
                        type: "POST",
                        data: { pparm: parm },
                        success: function (res) {
                            $.messager.progress('close');
                            var json = common.Util.StringToJson(res);
                            if (json.ErrorCode == common.Consts.SuccessCode) {
                                loadgriddata();
                            }
                            else {
                                $.messager.alert('警告', json.ErrorMessage, 'warning');
                                return;
                            }
                        }
                    };
                    common.Ajax("StopUser", options);
                }
            });
        }
        
        function startuser() {
            var parm = GetGridData('usergrid', 'FUserId');
            if (!parm) {
                $.messager.alert('提示', '请选择要启用的用户!', 'info');
                return;
            }
            $.messager.confirm('确认', '您是否确定要启用选中的用户吗?', function (r) {
                if (!r) {
                    return;
                }
                else {
                    parm = "(" + parm + ")";
                    $.messager.progress();
                    var options = {
                        type: "POST",
                        data: { pparm: parm },
                        success: function (res) {
                            $.messager.progress('close');
                            var json = common.Util.StringToJson(res);
                            if (json.ErrorCode == common.Consts.SuccessCode) {
                                loadgriddata();
                            }
                            else {
                                $.messager.alert('警告', json.ErrorMessage, 'warning');
                                return;
                            }
                        }
                    };
                    common.Ajax("StartUser", options);
                }
            });
        }

        function modifyuser(userid) {
            $.messager.progress();
            var options = {
                type: "POST",
                data: { puserid: userid },
                success: function (res) {
                    var json = common.Util.StringToJson(res);
                    $("#huserid").val(json.FUserId);
                    $("#txtusername").val(json.FUserName);
                    $("#txtuserdesc").val(json.FUserDesc);
                    $("#txtemail").val(json.FEmail);
                    $("#txtmobile").val(json.FContactMobile);
                    $("#txtcontacttel").val(json.FContactTel);
                    openwin("addwin", 400, 300, true, "loadgriddata");
                    $.messager.progress('close');
                }
            };
            common.Ajax("GetData", options);
        }

        function save() {
            var _userid = $("#huserid").val();
            var _username = $("#txtusername").val();
            var _userdesc = $("#txtuserdesc").val();
            var _email = $("#txtemail").val();
            var _mobile = $("#txtmobile").val();
            var _tel = $("#txtcontacttel").val();
            if (!_username) {
                $.messager.alert('警告', '用户名称不能为空!', 'warning', function () { $("#txtusername").focus(); });
                return;
            }
            if (!_userdesc) {
                $.messager.alert('警告', '用户描述不能为空!', 'warning', function () { $("#txtuserdesc").focus(); });
                return;
            }
            if (_email) {
                if (!common.Validate.ValidateEmail(_email)) {
                    $.messager.alert('警告', '用户邮箱填写不正确!', 'warning', function () { $("#txtemail").focus(); });
                    return;
                }
            }
            if (_mobile) {
                if (!common.Validate.ValidateMobile(_mobile)) {
                    $.messager.alert('警告', '用户手机填写不正确!', 'warning', function () { $("#txtmobile").focus(); });
                    return;
                }
            }
            $.messager.progress();
            var options = {
                type: "POST",
                data: {
                    puserid: _userid,
                    pusername: _username,
                    puserdesc: _userdesc,
                    pemail: _email,
                    pmobile: _mobile,
                    ptel: _tel
                },
                success: function (res) {
                    var json = common.Util.StringToJson(res);
                    $.messager.progress('close');
                    if (json.ErrorCode == common.Consts.SuccessCode) {
                        if (_userid == "0") {
                            $.messager.alert('警告', '新增用户成功,默认密码:123456。', 'warning');
                        }
                        closewin();
                    }
                    else {
                        $.messager.alert('警告', json.ErrorMessage, 'warning');
                        return;
                    }
                }
            };
            common.Ajax("SaveUser", options);
        }

        function closewin() {
            $("#addwin").window('close');
        }

        $(function () {
            $('.btn').linkbutton({ plain: true });
            $('.btn1').linkbutton();
            formatgrid("usergrid", "loadgriddata", "hpagenum", "hpagesize", "hsortname", "hsortdirection");
            loadgriddata();
        });

        function searchuser() {
            loadgriddata();
        }

        function adduser() {
            $("#huserid").val("0");
            $("#txtusername").val("");
            $("#txtuserdesc").val("");
            $("#txtcontacttel").val("");
            $("#txtemail").val("");
            $("#txtmobile").val("");
            openwin("addwin", 400, 300, true, "loadgriddata");
        }

        function loadgriddata() {
            $.messager.progress();
            $('#usergrid').datagrid('loading');
            var _searchcontent = $("#txtsearch").val();
            var _sortname = $("#hsortname").val();
            var _sortdirection = $("#hsortdirection").val();
            var _pagenumber = $("#hpagenum").val();
            var _pagesize = $("#hpagesize").val();
            var options = {
                type: "POST",
                data: {
                    psearchcontent: _searchcontent,
                    psortname: _sortname,
                    psortdirection: _sortdirection,
                    ppagenumber: _pagenumber,
                    ppagesize: _pagesize
                },
                success: function (res) {
                    var json = common.Util.StringToJson(res);
                    $.messager.progress('close');
                    loadgrid("usergrid", json);
                }
            };
            common.Ajax("GetGridData", options);
        }
    </script>
</asp:Content>
