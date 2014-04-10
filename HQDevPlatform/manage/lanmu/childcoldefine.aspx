<%@ Page Title="" Language="C#" MasterPageFile="~/WebContent.Master" AutoEventWireup="true" CodeBehind="childcoldefine.aspx.cs" Inherits="HQDevSys.manage.lanmu.childcoldefine" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../jquery.min.js" type="text/javascript"></script>
    <script src="../../jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../../Js/common.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHPageName" runat="server">
    导航子栏目管理
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHPageTool" runat="server">
    <a href="javascript:void(0)" class="btn" id="A2" iconCls="icon-back" onclick="backnav()">返回</a>
    <a href="javascript:void(0)" class="btn" id="btnadd" iconCls="icon-add" onclick="addchildcol()">新增子栏目</a>
    <a href="javascript:void(0)" class="btn" id="btndel" iconCls="icon-remove" onclick="delchildcol()">删除子栏目</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPHContent" runat="server">
    <div style="width:100%;margin:0 auto;">
        <div style="height:24px;clear:both;margin-top:0;padding:0;">
            <div style="float:left;margin-left:10px;margin-top:3px;">
                <label for="txtsearch">子栏目搜索</label>
            </div>
            <div style="float:left;margin-left:10px;">
                <input type="text" id="txtsearch" value="" style="width:150px;" />
            </div>
            <div style="float:left;margin:-2px 0 0 10px;">
                <a href="javascript:void(0)" class="btn1" id="A1" iconCls="icon-search" onclick="searchlanmu()">查找子栏目</a>
            </div>
        </div>
        <div style="width:98%;margin:0 auto;clear:both;">
            <table id="childcolgrid" class="easyui-datagrid" title="子栏目列表" style="margin:2px auto;" data-options="singleSelect:false,fitColumns:true,idField:'FChildColumnId',rownumbers:true,pagination:true">
                <thead>
                    <tr>
                        <th data-options="field:'FChildColumnId',align:'center',checkbox:true">选择</th>
                        <th data-options="field:'FChildColumnName',width:160,align:'center'">子栏目名称</th>
                        <th data-options="field:'FChildColumnTypeName',width:60,align:'center'">子栏目类型</th>
                        <th data-options="field:'FChildColumnUrl',width:80,align:'center'">自定义地址</th>
                        <th data-options="field:'FChildColumnTargetName',width:80,align:'center'">链接目标</th>
                        <th data-options="field:'FChildColumnOrder',width:60,align:'center'">顺序</th>
                        <th data-options="field:'FChildColumnVisibleName',width:60,align:'center',sortable:true">显示</th>
                        <th data-options="field:'FOperation',width:140,align:'center'">操作</th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>
    <input type="hidden" id="hsortname" value="FChildColumnOrder" />
    <input type="hidden" id="hsortdirection" value="asc" />
    <input type="hidden" id="hpagenum" value="1" />
    <input type="hidden" id="hpagesize" value="10" />
    <!-- 新增窗口 Begin-->
    <div id="addwin" iconCls="icon-save" title="子栏目资料" style="display:none;text-align:center;">  
        <table style="width: 470px;margin:10px auto;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">            
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    子栏目名称：
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <input type="hidden" id="hchildcolid" value="0" />
                    <input type="text" id="txtchildcolname" style="width:150px;" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    子栏目类型：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left:5px;text-align:left;" >
                    <select id="selchildcoltype">
                        <option value="" selected>==选择子栏目类型==</option>
                        <option value="0">普通简介</option>
                        <option value="1">文章列表</option>
                        <option value="2">产品列表</option>
                        <option value="3">用户反馈</option>
                        <option value="9">自定义模型</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    自定义地址：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left:5px;text-align:left;" >
                    <input type="text" id="txturl" style="width:200px;" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    链接目标：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left:5px;text-align:left;" >
                    <select id="selchildcoltarget">
                        <option value="" selected>==选择链接目标==</option>
                        <option value="0">本窗口</option>
                        <option value="1">新窗口</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    显示：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left:5px;text-align:left;" >
                    <select id="selchildcolvisible">
                        <option value="1" selected>显示</option>
                        <option value="0">隐藏</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    顺序：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left:5px;text-align:left;" >
                    <input type="text" id="txtchildcolorder" style="width:50px;" value="10" />
                </td>
            </tr>
        </table>
        <div style="margin:20px auto;">
            <a href="#" class="btn1" id="btnsave" iconCls="icon-save" onclick="save()">保存</a>&nbsp;&nbsp;
            <a href="#" class="btn1" id="btnclose" iconCls="icon-cancel" onclick="closewin()" >取消</a>
        </div> 
    </div>
    <!-- 新增窗口 End-->
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="CPHJavascript" runat="server">
    <script type="text/javascript">
        function normalcontent(id) {
            window.location = "childcolcontent.aspx?ccolid=" + id;
        }

        function backnav() {
            var options = {
                type: "POST",
                data: { pdata: "1" },
                success: function (res) {
                    window.location = "navdefine.aspx?colid=" + res;
                }
            };
            common.Ajax("GetBackUrl", options);
        }

        function addchildcol() {
            initwin();
            openwin("addwin", 500, 400, true, "loadgriddata");
        }

        function delchildcol() {
            var idlist = GetGridData("childcolgrid", "FChildColumnId");
            $.messager.confirm('确认', '您是否确定要删除选中的子栏目吗?', function (r) {
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
                    common.Ajax("DelColumn", options);
                }
            });
        }

        function initwin() {
            $("#hchildcolid").val("0");
            $("#txtchildcolname").val("");
            $("#selchildcoltype").val("");
            $("#txturl").val("");
            $("#selchildcoltarget").val("");
            $("#selchildcolvisible").val("1");
            $("#txtchildcolorder").val("10");
        }

        function save() {
            var _colid = $("#hchildcolid").val();
            var _colname = $("#txtchildcolname").val();
            var _coltype = $("#selchildcoltype").val();
            var _colurl = $("#txturl").val();
            var _coltarget = $("#selchildcoltarget").val();
            var _colvisible = $("#selchildcolvisible").val();
            var _colorder = $("#txtchildcolorder").val();
            if (!_colname) {
                $.messager.alert("子栏目名称不能为空!");
                return;
            }
            if (!_coltype) {
                $.messager.alert("请选择子栏目类型!");
                return;
            }
            if (!_coltarget) {
                $.messager.alert("请选择子栏目链接目标!");
                return;
            }
            if (!_colorder) {
                $.messager.alert("子栏目顺序不能为空!");
                return;
            }
            var options = {
                type: "POST",
                data: {
                    pcolid: _colid,
                    pcolnam: _colname,
                    pcoltype: _coltype,
                    pcolurl: _colurl,
                    pcoltarget: _coltarget,
                    pcolvisible: _colvisible,
                    pcolorder: _colorder
                },
                success: function (res) {
                    var json = common.Util.StringToJson(res);
                    if (json.ErrorCode == common.Consts.SuccessCode) {
                        $.messager.progress('close');
                        closewin();
                    }
                    else {
                        $.messager.progress('close');
                        $.messager.alert('警告', json.ErrorMessage, 'warning');
                        return;
                    }
                }
            };
            common.Ajax("SaveItem", options);
        }

        function closewin() {
            $("#addwin").window("close");
        }
        
        $(function () {
            $('.btn').linkbutton({ plain: true });
            $('.btn1').linkbutton();
            formatgrid("childcolgrid", "loadgriddata", "hpagenum", "hpagesize", "hsortname", "hsortdirection");
            loadgriddata();
        });

        function loadgriddata() {
            $.messager.progress();
            $('#childcolgrid').datagrid('loading');
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
                    loadgrid("childcolgrid", json);
                }
            };
            common.Ajax("GetGridData", options);
        }
    </script>
</asp:Content>
