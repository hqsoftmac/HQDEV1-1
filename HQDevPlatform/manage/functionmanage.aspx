<%@ Page Title="" Language="C#" MasterPageFile="~/WebContent.Master" AutoEventWireup="true" CodeBehind="functionmanage.aspx.cs" Inherits="HQDevSys.manage.functionmanage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../jquery.min.js" type="text/javascript"></script>
    <script src="../jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../Js/common.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHPageName" runat="server">
    系统功能管理
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHPageTool" runat="server">
    <a href="javascript:void(0)" class="btn" id="btnadd" iconCls="icon-add" onclick="addfunction()">新增功能</a>
    <a href="javascript:void(0)" class="btn" id="btnstart" iconCls="icon-ok" onclick="startfunction()">启用功能</a>
    <a href="javascript:void(0)" class="btn" id="btnstop" iconCls="icon-no" onclick="stopfunction()">暂停功能</a>
    <a href="javascript:void(0)" class="btn" id="btndel" iconCls="icon-remove" onclick="delfunction()">删除功能</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPHContent" runat="server">
    <div style="width:100%;margin:0 auto;">
        <div style="height:24px;clear:both;margin-top:0;padding:0;">
            <div style="float:left;margin-left:10px;margin-top:3px;">
                <label for="txtsearch">所属模块</label>
            </div>
            <div style="float:left;margin-left:10px;">
                <select id="selmodule" onchange="loadgriddata()"></select>
            </div>
        </div>
        <div style="width:98%;margin:0 auto;clear:both;">
        <table id="functiongrid" class="easyui-datagrid" title="功能列表" style="margin:2px auto;" data-options="singleSelect:false,collapsible:true,fitColumns:true,striped:true,idField:'FFunId',rownumbers:true,pagination:true">
            <thead>
                <tr>
                    <th data-options="field:'FFunId',align:'center',checkbox:true">选择</th>
                    <th data-options="field:'FFunCode',width:150,align:'center',sortable:true">功能编号</th>
                    <th data-options="field:'FFunName',width:150,align:'center',sortable:true">功能名称</th>
                    <th data-options="field:'FFunNavigateUrl',width:150,align:'center',sortable:true">功能地址</th>
                    <th data-options="field:'FFunContent',width:250,align:'center'">功能描述</th>
                    <th data-options="field:'FFunStatusName',width:100,align:'center'">功能状态</th>
                    <th data-options="field:'FOperation',width:120,align:'center'">操作</th>
                </tr>
            </thead>
        </table>
        <input type="hidden" id="hsortname" value="FFunCode" />
        <input type="hidden" id="hsortdirection" value="asc" />
        <input type="hidden" id="hpagenum" value="1" />
        <input type="hidden" id="hpagesize" value="10" />
        </div>
    </div>
    <div id="addwin" iconCls="icon-save" title="系统功能" style="display:none;text-align:center;">  
        <table style="width: 320px;margin:10px auto;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">            
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    功能(组)编号：
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <input type="hidden" id="hfunid" value="0" />
                    <input type="text" id="txtfuncode" style="width:150px;" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    所属功能组：
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <select id="selparentfun">
                    
                    </select>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    功能(组)名称：
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <input type="text" id="txtfunname" style="width:150px;" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    功能地址：
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <input type="text" id="txtnavigateurl" style="width:150px;" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    功能描述：
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <input type="text" id="txtfundesc" style="width:150px;" />
                </td>
            </tr>
        </table>
        <div style="margin:20px auto;">
            <a href="javascript:void(0)" class="btn1" id="btnsave" iconCls="icon-save" onclick="save()">保存</a>&nbsp;&nbsp;
            <a href="javascript:void(0)" class="btn1" id="btnclose" iconCls="icon-cancel" onclick="closewin()" >取消</a>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="CPHJavascript" runat="server">
    <script type="text/javascript">
        function addfunction() {
            var moduleflag = $("#selmodule").val();
            if (!moduleflag) {
                $.messager.alert('警告', '增加功能请先选择相关模块!', 'warning');
                return;
            }
            else {
                $("#hfunid").val("0");
                $("#txtfuncode").val("");
                $("#txtfunname").val("");
                $("#txtnavigateurl").val("");
                $("#txtfundesc").val("");
                var options = {
                    type: "POST",
                    data: { pmoduleflag: moduleflag },
                    success: function (res) {
                        var json = common.Util.StringToJson(res);
                        $("#selparentfun").empty();
                        $("#selparentfun").append("<option value=''>==选择所属功能组==</option>");
                        common.DropDownList.Load("selparentfun", json, "FFunName", "FFunId");
                        openwin("addwin", 350, 300, true, "loadgriddata");
                    }
                };
                common.Ajax("GetParentFun", options);
            }
        }

        function loadparentlist() {
            var moduleflag = $("#selmodule").val();
            if (!moduleflag) {
                $.messager.alert('警告', '增加功能请先选择相关模块!', 'warning');
                return;
            }
            else {
                var options = {
                    type: "POST",
                    data: { pmoduleflag: moduleflag },
                    success: function (res) {
                        var json = common.Util.StringToJson(res);
                        $("#selparentfun").empty();
                        $("#selparentfun").append("<option value=''>==选择所属功能组==</option>");
                        common.DropDownList.Load("selparentfun", json, "FFunName", "FFunId");
                    }
                };
                common.Ajax("GetParentFun", options);
            }

        }

        function delfunction() {
            var parm = GetGridData("functiongrid", "FFunId");
            if (!parm) {
                $.messager.alert('提示', '请选择要删除的功能!', 'info');
                return;
            }
            parm = "(" + parm + ")";
            $.messager.confirm('确认', '您是否确定要删除选中的功能吗?', function (r) {
                if (!r) {
                    return;
                }
                else {
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
                    common.Ajax("DelFunction", options);
                }
            });
        }

        function startfunction() {
            var parm = GetGridData("functiongrid", "FFunId");
            if (!parm) {
                $.messager.alert('提示', '请选择要启用的功能!', 'info');
                return;
            }
            parm = "(" + parm + ")";
            $.messager.confirm('确认', '您是否确定要启用选中的功能吗?', function (r) {
                if (!r) {
                    return;
                }
                else {
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
                    common.Ajax("StartFunction", options);
                }
            });
        }

        function stopfunction() {
            var parm = GetGridData("functiongrid", "FFunId");
            if (!parm) {
                $.messager.alert('提示', '请选择要停用的功能!', 'info');
                return;
            }
            parm = "(" + parm + ")";
            $.messager.confirm('确认', '您是否确定要停用选中的功能吗?', function (r) {
                if (!r) {
                    return;
                }
                else {
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
                    common.Ajax("StopFunction", options);
                }
            });
        }

        function save() {
            var _funid = $("#hfunid").val();
            var _funcode = $("#txtfuncode").val();
            var _parentid = $("#selparentfun").val();
            var _funname = $("#txtfunname").val();
            var _navigateurl = $("#txtnavigateurl").val();
            var _fundesc = $("#txtfundesc").val();
            var _moduleflag = $("#selmodule").val();
            if (!_funcode) {
                $.messager.alert('警告', '功能或者功能组编号不能为空!', 'warning', function () { $("#txtfuncode").focus(); });
                return;
            }
            if (!_funname) {
                $.messager.alert('警告', '功能或者功能组名称不能为空!', 'warning', function () { $("#txtfunname").focus(); });
                return;
            }
            var options = {
                type: "POST",
                data: {
                    pfunid: _funid,
                    pfuncode: _funcode,
                    pparentid: _parentid,
                    pfunname: _funname,
                    pnavigateurl: _navigateurl,
                    pfundesc: _fundesc,
                    pmoduleflag: _moduleflag
                },
                success: function (res) {
                    var json = common.Util.StringToJson(res);
                    if (json.ErrorCode == common.Consts.SuccessCode) {
                        closewin();
                    }
                    else {
                        $.messager.alert('警告', json.ErrorMessage, 'warning');
                        return;
                    }
                }
            };
            common.Ajax("SaveFunction", options);
        }

        $(function () {
            $('.btn').linkbutton({ plain: true });
            $('.btn1').linkbutton();
            formatgrid("functiongrid", "loadgriddata", "hpagenum", "hpagesize", "hsortname", "hsortdirection");
            $('#txtfuncode').validatebox({
                required: true,
                missingMessage: '请填写功能或者功能组编号!'
            });
            $('#txtfunname').validatebox({
                required: true,
                missingMessage: '请填写功能名称或者功能组名称!'
            });
            var moduledata = common.Data.GetDatasource("modulelist");
            $("#selmodule").empty();
            $("#selmodule").append("<option value=''>==选择所属模块==</option>");
            common.DropDownList.Load("selmodule", moduledata, "FModuleName", "FModuleFlag");
        });

        function closewin() {
            $('#addwin').window('close');
        }

        function loadgriddata() {
            $('#functiongrid').datagrid('loading');
            var _searchcontent = $("#selmodule").val();
            var _sortname = $("#hsortname").val();
            var _sortdirection = $("#hsortdirection").val();
            var _pagenumber = $("#hpagenum").val();
            var _pagesize = $("#hpagesize").val();
            if (!_searchcontent) {
                $('#functiongrid').datagrid('loadData', { total: 0, rows: [] });
            }
            else {
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
                        $('#functiongrid').datagrid('loadData', json);
                        $('#functiongrid').datagrid('loaded');
                        $('#functiongrid').datagrid('unselectAll');
                    }
                };
                common.Ajax("GetGridData", options);
            }
        }

         

        function modifyfunction(_funid) {
            loadparentlist();
            $("#hfunid").val(_funid);
            var options = {
                type: "POST",
                data: {
                    pfunid: _funid
                },
                success: function (res) {
                    var json = common.Util.StringToJson(res);
                    $("#txtfuncode").val(json.FFunCode);
                    $("#txtfunname").val(json.FFunName);
                    $("#txtnavigateurl").val(json.FFunNavigateUrl);
                    $("#txtfundesc").val(json.FFunContent);
                    $("#selparentfun").val(json.FParentFunId);
                    openwin("addwin", 350, 300, true, "loadgriddata");
                }
            };
            common.Ajax("GetFunctionInfo", options);
        }
    </script>
</asp:Content>
