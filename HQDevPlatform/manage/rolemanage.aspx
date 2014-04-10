<%@ Page Title="" Language="C#" MasterPageFile="~/WebContent.Master" AutoEventWireup="true" CodeBehind="rolemanage.aspx.cs" Inherits="HQDevSys.manage.rolemanage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../jquery.min.js" type="text/javascript"></script>
    <script src="../jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../Js/common.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHPageName" runat="server">
    角色管理
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHPageTool" runat="server">
    <a href="javascript:void(0)" class="btn" id="btnadd" iconCls="icon-add" onclick="addrole()">新增角色</a>
    <a href="javascript:void(0)" class="btn" id="btnstart" iconCls="icon-ok" onclick="startrole()">启用角色</a>
    <a href="javascript:void(0)" class="btn" id="btnstop" iconCls="icon-no" onclick="stoprole()">暂停角色</a>
    <a href="javascript:void(0)" class="btn" id="btndel" iconCls="icon-remove" onclick="delrole()">删除角色</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPHContent" runat="server">
    <div style="width:100%;margin:0 auto;">
        <div style="height:24px;clear:both;margin-top:0;padding:0;width:100%;">
            <div style="float:left;margin-left:10px;margin-top:3px;">
                <label for="txtsearch">角色检索</label>
            </div>
            <div style="float:left;margin-left:10px;">
                <input type="text" id="txtsearch" style="width:150px;" />
            </div>
            <div style="float:left;margin:-2px 0 0 10px;">
                <a href="javascript:void(0)" class="btn1" id="A1" iconCls="icon-search" onclick="searchrole()">查找角色</a>
            </div>
        </div>
        <div style="width:98%;margin:0 auto;clear:both;">
            <table id="rolegrid" class="easyui-datagrid" title="角色列表" style="margin:2px auto;" data-options="singleSelect:false,fitColumns:true,idField:'FRoleId',rownumbers:true,pagination:true">
                <thead>
                    <tr>
                        <th data-options="field:'FRoleId',align:'center',checkbox:true">选择</th>
                        <th data-options="field:'FRoleName',width:150,align:'center',sortable:true">角色名称</th>
                        <th data-options="field:'FRoleDesc',width:160,align:'center',sortable:true">角色描述</th>
                        <th data-options="field:'FUsedFlagName',width:80,align:'center'">用户状态</th>
                        <th data-options="field:'FOperation',width:100,align:'center'">操作</th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>
    <input type="hidden" id="hsortname" value="FRoleId" />
    <input type="hidden" id="hsortdirection" value="asc" />
    <input type="hidden" id="hpagenum" value="1" />
    <input type="hidden" id="hpagesize" value="10" />
    <!-- 新增窗口 Begin-->
    <div id="addwin" iconCls="icon-save" title="角色资料" style="display:none;text-align:center;">  
        <table style="width: 370px;margin:10px auto;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">            
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    角色名称：
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <input type="hidden" id="roleid" value="0" />
                    <input type="text" id="txtrolename" style="width:150px;" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 250px; background-color: #e1f5fc; height: 25px;" >
                    角色描述：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left:5px;text-align:left;" >
                    <input type="text" id="txtroledesc" style="width:250px;" />
                </td>
            </tr>
        </table>
        <div style="margin:20px auto;">
            <a href="#" class="btn1" id="btnsave" iconCls="icon-save" onclick="save()">保存</a>&nbsp;&nbsp;
            <a href="#" class="btn1" id="btnclose" iconCls="icon-cancel" onclick="closewin()" >取消</a>
        </div> 
    </div>
    <!-- 新增窗口 End-->
    <!--授权窗口 Begin-->
    <div id="authorwin" iconCls="icon-ok" title="角色功能授权" style="text-align:center;width:550px;display:none;"> 
         <div style="text-align:left;padding:5px;">选择授权模块:<select id="selmodule" onchange="loadfunctionlist()"></select> </div>
         <table id="functiongrid" class="easyui-datagrid" title="功能列表" style="margin:2px auto;width:540px;" data-options="singleSelect:false,collapsible:true,fitColumns:true,striped:true,idField:'FFunId'">
            <thead>
                <tr>
                    <th data-options="field:'FFunId',width:80,align:'center',checkbox:true">选择</th>
                    <th data-options="field:'FFunCode',width:120,align:'center'">功能(组)编号</th>
                    <th data-options="field:'FFunName',width:120,align:'left'">功能(组)名称</th>
                    <th data-options="field:'FFunContent',width:200,align:'left'">功能(组)描述</th>
                </tr>
            </thead>
        </table>
        <input type="hidden" id="hroleid" value="0" />
    </div>
    <!--授权窗口 End-->
    <!--模块授权窗口 Begin-->
    <div id="modulewin" iconCls="icon-ok" title="角色模块授权" style="text-align:center;width:440px;display:none;">  
         <table id="modulegrid" class="easyui-datagrid" title="模块列表" style="margin:2px auto;width:420px;" data-options="singleSelect:false,fitColumns:true,striped:true,idField:'FModuleFlag'">
            <thead>
                <tr>
                    <th data-options="field:'FModuleFlag',width:80,align:'center',checkbox:true">选择</th>
                    <th data-options="field:'FModuleName',width:120,align:'center'">系统模块</th>
                </tr>
            </thead>
        </table>
        <input type="hidden" id="mhroleid" value="0" />
    </div>
    <!--模块授权窗口 End-->
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="CPHJavascript" runat="server">
    <script type="text/javascript">
        function saveauthor() {
            var _roleid = $("#hroleid").val();
            var _moduleflag = $("#selmodule").val();
            var parm = GetGridData("functiongrid", "FFunId");
            var options = {
                type: "POST",
                data: { proleid: _roleid, pmoduleflag: _moduleflag, pparm: parm },
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
            common.Ajax("SaveRoleFunction", options);
        }

        function initfunlist() {
            $('#functiongrid').datagrid('unselectAll');
            $('#functiongrid').datagrid('loadData', { total: 0, rows: [] });
        }

        function initmodulelist() {
            $('#modulegrid').datagrid('unselectAll');
            $('#modulegrid').datagrid('loadData', { total: 0, rows: [] });
        }


        function authormodule(_roleid) {
            openwin("modulewin", 440, 400, true, "initmodulelist");
            loadmodulelist(_roleid);
        }

        function savemodule() {
            var _roleid = $("#mhroleid").val();
            var parm = "";
            parm = GetGridData("modulegrid", "FModuleFlag");
            $.messager.progress();
            var options = {
                type: "POST",
                data: { proleid: _roleid, pmoduleid: parm },
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
            common.Ajax("SaveRoleModule", options);
        }

        function closewin2() {
            $("#modulewin").window("close");
        }

        function loadmodulelist(roleid) {
            $.messager.progress();
            $('#modulegrid').datagrid({ loadMsg: '正在载入权限列表,请耐心等待...', toolbar: [{ text: '保存', iconCls: 'icon-save', handler: function () { savemodule(); } }, { text: '取消', iconCls: 'icon-cancel', handler: function () { closewin2(); } }] });
            var modulelist = common.Data.GetDatasource("modulelist");
            $('#modulegrid').datagrid('loadData', modulelist);
            $('#modulegrid').datagrid('unselectAll');
            $('#mhroleid').val(roleid);
            var options = {
                type: "POST",
                data: { proleid: roleid },
                success: function (res) {
                    var json = common.Util.StringToJson(res);
                    $('#modulegrid').datagrid('loading');
                    for (var i = 0; i < json.length; i++) {
                        var moduleflag = json[i]['FModuleFlag'];
                        $('#modulegrid').datagrid('selectRecord', moduleflag);
                    }
                    $('#modulegrid').datagrid('loaded');
                    $.messager.progress('close');
                }
            };
            common.Ajax("GetRoleModulelist", options);
        }

        function loadrolemodule(_roleid) {
            var options = {
                type: "POST",
                data: { proleid: _roleid },
                success: function (res) {
                    var json = common.Util.StringToJson(res);
                    $("#selmodule").empty();
                    $("#selmodule").append("<option value='0'>====选择授权模块====</option>");
                    common.DropDownList.Load("selmodule", json, "FModuleName", "FModuleFlag");
                }
            };
            common.Ajax("GetModuleList", options);
        }

        function authorrole(_roleid) {
            $('#hroleid').val(_roleid);
            loadrolemodule(_roleid);
            openwin("authorwin", 550, 500, true, "initfunlist");
            $('#functiongrid').datagrid({ loadMsg: '正在载入权限列表,请耐心等待...', toolbar: [{ text: '保存', iconCls: 'icon-save', handler: function () { saveauthor(); } }, { text: '取消', iconCls: 'icon-cancel', handler: function () { closewin1(); } }] });
        }

        function closewin1() {
            $("#authorwin").window('close');
        }

        function loadfunctionlist() {
            var _roleid = $('#hroleid').val();
            var _moduleflag = $("#selmodule").val();
            $('#functiongrid').datagrid('unselectAll');
            $('#functiongrid').datagrid('loadData', { total: 0, rows: [] }); 
            if (_moduleflag != "0" || !_moduleflag) {
                var options = {
                    type: "POST",
                    data: { proleid: _roleid, pmoduleflag: _moduleflag },
                    success: function (res) {
                        $.messager.progress();
                        var json = common.Util.StringToJson(res);
                        $('#functiongrid').datagrid('loading');
                        $('#functiongrid').datagrid('loadData', json);
                        $('#functiongrid').datagrid('unselectAll');

                        for (var i = 0; i < json.length; i++) {
                            var funid = json[i]['FSelFlag'];
                            $('#functiongrid').datagrid('selectRecord', funid);
                        }
                        $('#functiongrid').datagrid('loaded');
                        $.messager.progress('close');

                    }
                };
                common.Ajax("GetRoleFunList", options);
            }
            else {
                $('#functiongrid').datagrid('unselectAll');
                $('#functiongrid').datagrid('loadData', { total: 0, rows: [] });
            }
        }
        
        function searchrole() {
            loadgriddata();
        }
        
        function modifyRole(roleid) {
            var options =
            {
                type: "POST",
                data: { pid: roleid },
                success: function (res) {
                    var json = common.Util.StringToJson(res);
                    $("#roleid").val(roleid);
                    $("#txtrolename").val(json.FRoleName);
                    $("#txtroledesc").val(json.FRoleDesc);
                    openwin("addwin", 400, 300, true, "loadgriddata");
                }
            };
            common.Ajax("GetRoleData", options);
        }

        function delrole() {
            var parm = GetGridData('rolegrid', 'FRoleId');
            if (!parm) {
                $.messager.alert('提示', '请选择要删除的角色!', 'info');
                return;
            }
            $.messager.confirm('确认', '您是否确定要删除选中的角色吗?', function (r) {
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
                    common.Ajax("DeleteRole", options);
                }
            });
        }
        
        function addrole() {
            $("#roleid").val("0");
            $("#txtrolename").val("");
            $("#txtroledesc").val("");
            openwin("addwin", 400, 300, true, "loadgriddata");
        }

        function closewin() {
            $("#addwin").window('close');
        }

        function stoprole() {
            var parm = GetGridData('rolegrid', 'FRoleId');
            if (!parm) {
                $.messager.alert('提示', '请选择要停用的角色!', 'info');
                return;
            }
            $.messager.confirm('确认', '您是否确定要停用选中的角色吗?', function (r) {
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
                    common.Ajax("StopRole", options);
                }
            });
        }

        function startrole() {
            var parm = GetGridData('rolegrid', 'FRoleId');
            if (!parm) {
                $.messager.alert('提示', '请选择要启用的角色!', 'info');
                return;
            }
            $.messager.confirm('确认', '您是否确定要启用选中的角色吗?', function (r) {
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
                    common.Ajax("StartRole", options);
                }
            });
        }

        function save() {
            var _roleid = $("#roleid").val();
            var _rolename = $("#txtrolename").val();
            var _roledesc = $("#txtroledesc").val();
            if (!_rolename) {
                $.messager.alert('警告', '角色名称不能为空!', 'warning', function () { $("#txtrolename").focus(); });
                return;
            }
            var options = {
                type: "POST",
                data: { proleid: _roleid,
                    prolename: _rolename,
                    proledesc: _roledesc
                },
                success: function (res) {
                    var json = common.Util.StringToJson(res);
                    if (json.ErrorCode == common.Consts.SuccessCode) {
                        closewin();
                    }
                    else {
                        $.messager.alert('警告', json.ErrorCode + json.ErrorMessage, 'warning');
                        return;
                    }
                }
            };
            common.Ajax("SaveRole", options); 
        }

        $(function () {
            $('.btn').linkbutton({ plain: true });
            $('.btn1').linkbutton();
            formatgrid("rolegrid", "loadgriddata", "hpagenum", "hpagesize", "hsortname","hsortdirection");
            loadgriddata();
        });

        function loadgriddata() {
            $.messager.progress();
            $('#rolegrid').datagrid('loading');
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
                    loadgrid("rolegrid", json);
                }
            };
            common.Ajax("GetGridData", options);
        }

    </script>
</asp:Content>
