<%@ Page Title="" Language="C#" MasterPageFile="~/WebContent.Master" AutoEventWireup="true" CodeBehind="productlist.aspx.cs" Inherits="HQDevSys.manage.product.productlist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../jquery.min.js" type="text/javascript"></script>
    <script src="../../jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../../Js/common.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHPageName" runat="server">
    产品目录管理
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHPageTool" runat="server">
    <a href="javascript:void(0)" class="btn" id="A2" iconCls="icon-back" onclick="backlist()" style="display:none;">返回上级</a>
    <a href="javascript:void(0)" class="btn" id="btnadd" iconCls="icon-add" onclick="addlist()">新增目录</a>
    <a href="javascript:void(0)" class="btn" id="btndel" iconCls="icon-remove" onclick="dellist()">删除目录</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPHContent" runat="server">
    <div style="width:100%;margin:0 auto;">
        <div style="height:24px;clear:both;margin-top:0;padding:0;">
            <div style="float:left;margin-left:10px;margin-top:3px;">
                <label for="txtsearch">栏目搜索</label>
            </div>
            <div style="float:left;margin-left:10px;">
                <input type="text" id="txtsearch" value="" style="width:150px;" />
            </div>
            <div style="float:left;margin:-2px 0 0 10px;">
                <a href="javascript:void(0)" class="btn1" id="A1" iconCls="icon-search" onclick="searchlanmu()">查找栏目</a>
            </div>
        </div>
        <div style="width:98%;margin:0 auto;clear:both;">
            <table id="articlelistgrid" class="easyui-datagrid" title="栏目列表" style="margin:2px auto;" data-options="singleSelect:false,fitColumns:true,idField:'FListId',rownumbers:true,pagination:true">
                <thead>
                    <tr>
                        <th data-options="field:'FProductListID',align:'center',checkbox:true">选择</th>
                        <th data-options="field:'FProductListName',width:160,align:'center'">目录名称</th>
                        <th data-options="field:'FProductListOrder',width:60,align:'center'">顺序</th>
                        <th data-options="field:'FOperation',width:100,align:'center'">操作</th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>
    <input type="hidden" id="hsortname" value="FProductListOrder" />
    <input type="hidden" id="hsortdirection" value="asc" />
    <input type="hidden" id="hpagenum" value="1" />
    <input type="hidden" id="hpagesize" value="10" />
    <input type="hidden" id="hparentid" value="0" />
    <!-- 新增窗口 Begin-->
    <div id="addwin" iconCls="icon-save" title="产品目录资料" style="display:none;text-align:center;">  
        <table style="width: 470px;margin:10px auto;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">            
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    目录名称：
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <input type="hidden" id="hlistid" value="0" />
                    <input type="text" id="txtlistname" style="width:150px;" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    目录顺序：
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <input type="text" id="txtlistorder" style="width:150px;" />
                </td>
            </tr>
        </table>
        <div style="margin:20px auto;">
            <a href="#" class="btn1" id="btnsave" iconCls="icon-save" onclick="save()">保存</a>&nbsp;&nbsp;
            <a href="#" class="btn1" id="btnclose" iconCls="icon-cancel" onclick="closewin()" >取消</a>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="CPHJavascript" runat="server">
    <script type="text/javascript">
        function searchlanmu() {
            loadgriddata();
        }

        function editlist(id) {
            var options = {
                type: "POST",
                data: { pid: id },
                success: function (res) {
                    var json = common.Util.StringToJson(res);
                    $("#hlistid").val(json.FProductListID);
                    $("#txtlistname").val(json.FProductListName);
                    $("#txtlistorder").val(json.FProductListOrder);
                    $("#hparentid").val(json.FParentListId);
                    openwin("addwin", 500, 300, true, "loadgriddata");
                }
            };
            common.Ajax("GetListItem", options);
        }

        function dellist() {
            var idlist = GetGridData("articlelistgrid", "FListId");
            $.messager.confirm('确认', '您是否确定要删除选中的目录吗?注意若目录下存在下级目录,请先删除下级目录,否则无法删除!', function (r) {
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
                    common.Ajax("DelList", options);
                }
            });
        }


        function addlist() {
            initlist();
            openwin("addwin", 500, 300, true, "loadgriddata");
        }

        function childlist(id) {
            $("#hparentid").val(id);
            $("#hpagenum").val("1");
            $("#hpagesize").val("10");
            loadgriddata();
        }

        function save() {
            var _listid = $("#hlistid").val();
            var _listname = $("#txtlistname").val();
            var _parentid = $("#hparentid").val();
            var _order = $("#txtlistorder").val();
            if (!_listname) {
                $.messager.alert("目录名称不能为空!");
                return;
            }
            if (!_order) {
                $.messager.alert("目录顺序不能为空!");
                return;
            }
            $.messager.progress();
            var options = {
                type: "POST",
                data: { plistid: _listid, plistname: _listname, pparentid: _parentid, porder: _order },
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

        function initlist() {
            $("#hlistid").val("0");
            $("#txtlistname").val("");
            $("#txtlistorder").val("10");
        }

        function backlist() {
            var _parentid = $("#hparentid").val();
            if (_parentid == "0") {
                $.messager.alert('警告', '已经是最上一级目录了!', 'warning');
                return;
            }
            else {
                var _parentid = $("#hparentid").val();
                var options = {
                    type: "POST",
                    data: { pchildid: _parentid },
                    success: function (res) {
                        $("#hsortname").val("FProductListOrder");
                        $("#hsortdirection").val("asc");
                        $("#hpagenum").val("1");
                        $("#hpagesize").val("10");
                        $("#txtsearch").val("");
                        $("#hparentid").val(res);
                        loadgriddata();
                    }
                };
                common.Ajax("GetParentId", options);
            }
        }

        $(function () {
            $('.btn').linkbutton({ plain: true });
            $('.btn1').linkbutton();
            formatgrid("articlelistgrid", "loadgriddata", "hpagenum", "hpagesize", "hsortname", "hsortdirection");
            loadgriddata();
            var _parentid = $("#hparentid").val();
            if (_parentid == "0") {
                $("#A2").hide();
            }
            else {
                $("#A2").show();
            }
        });

        function loadgriddata() {
            $.messager.progress();
            $('#articlelistgrid').datagrid('loading');
            var _searchcontent = $("#txtsearch").val();
            var _sortname = $("#hsortname").val();
            var _sortdirection = $("#hsortdirection").val();
            var _pagenumber = $("#hpagenum").val();
            var _pagesize = $("#hpagesize").val();
            var _parentid = $("#hparentid").val();
            var options = {
                type: "POST",
                data: {
                    psearchcontent: _searchcontent,
                    psortname: _sortname,
                    psortdirection: _sortdirection,
                    ppagenumber: _pagenumber,
                    ppagesize: _pagesize,
                    pparentid: _parentid
                },
                success: function (res) {
                    var json = common.Util.StringToJson(res);
                    $.messager.progress('close');
                    loadgrid("articlelistgrid", json);
                    var _parentid = $("#hparentid").val();
                    if (_parentid == "0") {
                        $("#A2").hide();
                    }
                    else {
                        $("#A2").show();
                    }
                }
            };
            common.Ajax("GetGridData", options);
        }

    </script>
</asp:Content>
