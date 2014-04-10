<%@ Page Title="" Language="C#" MasterPageFile="~/WebContent.Master" AutoEventWireup="true" CodeBehind="usemodule.aspx.cs" Inherits="HQDevSys.manage.usemodule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../jquery.min.js" type="text/javascript"></script>
    <script src="../jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../Js/common.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHPageName" runat="server">
    模块管理
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHPageTool" runat="server">
    
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPHContent" runat="server">
    <div style="width:100%;margin:0 auto;">
        <div style="width:98%;margin:0 auto;clear:both;">
            <table id="modulegrid" class="easyui-datagrid" title="模块列表" style="margin:2px auto;" data-options="singleSelect:false,fitColumns:true,idField:'FModuleFlag',rownumbers:true,pagination:true">
                <thead>
                    <tr>
                        <th data-options="field:'FModuleFlag',align:'center',checkbox:true">选择</th>
                        <th data-options="field:'FModuleName',width:250,align:'center'">模块名称</th>
                        <th data-options="field:'FModuleUsedName',width:100,align:'center'">启用状态</th>
                        <th data-options="field:'FOperation',width:100,align:'center'">操作</th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>
    <input type="hidden" id="hsortname" value="FModuleFlag" />
    <input type="hidden" id="hsortdirection" value="asc" />
    <input type="hidden" id="hpagenum" value="1" />
    <input type="hidden" id="hpagesize" value="10" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="CPHJavascript" runat="server">
    <script type="text/javascript">
        function startmodule(_moduleflag) {
            $.messager.confirm('确认', '您是否确定启用该模块吗?', function (r) {
                if (!r) {
                    return;
                }
                else {
                    var options = {
                        type: "POST",
                        data: { pmoduleflag: _moduleflag },
                        success: function (res) {
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
                    common.Ajax("StartModule", options);
                }
            });
        }

        function stopmodule(_moduleflag) {
            $.messager.confirm('确认', '您是否确定停用该模块吗?', function (r) {
                if (!r) {
                    return;
                }
                else {
                    var options = {
                        type: "POST",
                        data: { pmoduleflag: _moduleflag },
                        success: function (res) {
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
                    common.Ajax("StopModule", options);
                }
            });
        }

        $(function () {
            $('.btn').linkbutton({ plain: true });
            $('.btn1').linkbutton();
            formatgrid("modulegrid", "loadgriddata", "hpagenum", "hpagesize", "hsortname", "hsortdirection");
            loadgriddata();
        });

        function loadgriddata() {
            $.messager.progress();
            var _sortname = $("#hsortname").val();
            var _sortdirection = $("#hsortdirection").val();
            var _pagenumber = $("#hpagenum").val();
            var _pagesize = $("#hpagesize").val();
            var options = {
                type: "POST",
                data: {
                    psortname: _sortname,
                    psortdirection: _sortdirection,
                    ppagenumber: _pagenumber,
                    ppagesize: _pagesize
                },
                success: function (res) {
                    var json = common.Util.StringToJson(res);
                    $.messager.progress('close');
                    loadgrid("modulegrid", json);
                }
            };
            common.Ajax("GetGridData", options);
        }

    </script>
</asp:Content>
