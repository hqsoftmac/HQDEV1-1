<%@ Page Title="" Language="C#" MasterPageFile="~/WebContent.Master" AutoEventWireup="true" CodeBehind="positionmanage.aspx.cs" Inherits="HQDevSys.manage.human.positionmanage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../jquery.min.js" type="text/javascript"></script>
    <script src="../../jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../../Js/common.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHPageName" runat="server">
    职位管理
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHPageTool" runat="server">
    <a href="javascript:void(0)" class="btn" id="btnadd" iconCls="icon-add" onclick="addposition()">新增职位</a>
    <a href="javascript:void(0)" class="btn" id="btndel" iconCls="icon-remove" onclick="delposition()">删除职位</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPHContent" runat="server">
    <div style="width:100%;margin:0 auto;">
        <div style="height:24px;clear:both;margin-top:0;padding:0;">
            <div style="float:left;margin-left:10px;margin-top:3px;">
                <label for="txtsearch">职位搜索</label>
            </div>
            <div style="float:left;margin-left:10px;">
                <input type="text" id="txtsearch" value="" style="width:150px;" />
            </div>
            <div style="float:left;margin:-2px 0 0 10px;">
                <a href="javascript:void(0)" class="btn1" id="A1" iconCls="icon-search" onclick="searchlanmu()">查找职位</a>
            </div>
        </div>
        <div style="width:98%;margin:0 auto;clear:both;">
            <table id="productgrid" class="easyui-datagrid" title="职位列表" style="margin:2px auto;" data-options="singleSelect:false,fitColumns:true,idField:'FPositionId',rownumbers:true,pagination:true">
                <thead>
                    <tr>
                        <th data-options="field:'FPositionId',align:'center',checkbox:true">选择</th>
                        <th data-options="field:'FPositionName',width:100,align:'left'">职位名称</th>
                        <th data-options="field:'FPositionDept',width:80,align:'center'">职位部门</th>
                        <th data-options="field:'FPositionTypeName',width:80,align:'center'">职位类型</th>
                        <th data-options="field:'FPositionGendorName',width:80,align:'center'">性别要求</th>
                        <th data-options="field:'FBeginDateStr',width:100,align:'center'">开始日期</th>
                        <th data-options="field:'FEndDateStr',width:100,align:'center'">结束日期</th>
                        <th data-options="field:'FPositionOrder',width:80,align:'center'">显示顺序</th>
                        <th data-options="field:'FOperation',width:100,align:'center'">操作</th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>
    <input type="hidden" id="hsortname" value="FPositionId" />
    <input type="hidden" id="hsortdirection" value="desc" />
    <input type="hidden" id="hpagenum" value="1" />
    <input type="hidden" id="hpagesize" value="10" />
    <input type="hidden" id="hparentid" value="0" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="CPHJavascript" runat="server">
    <script type="text/javascript">
        function delposition() {
            var idlist = GetGridData("productgrid", "FPositionId");
            $.messager.confirm('确认', '您是否确定要删除选中的职位吗?', function (r) {
                if (!r) {
                    return;
                }
                else {
                    $.messager.progress();
                    var options = {
                        type: "POST",
                        data: { pparm: idlist },
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
                    common.Ajax("DelPosition", options);
                }
            });
        }

        function addposition() {
            window.location = "positionadd.aspx";
        }

        function editposition(id) {
            window.location = "positionedit.aspx?id=" + id;
        }
        
        function searchlanmu() {
            loadgriddata();
        }

        $(function () {
            $('.btn').linkbutton({ plain: true });
            $('.btn1').linkbutton();
            formatgrid("productgrid", "loadgriddata", "hpagenum", "hpagesize", "hsortname", "hsortdirection");
            loadgriddata();
        });

        function loadgriddata() {
            $.messager.progress();
            $('#productgrid').datagrid('loading');
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
                    loadgrid("productgrid", json);
                }
            };
            common.Ajax("GetGridData", options);
        }
    </script>
</asp:Content>
