<%@ Page Title="" Language="C#" MasterPageFile="~/WebContent.Master" AutoEventWireup="true" CodeBehind="nationmanage.aspx.cs" Inherits="HQDevPlatform.manage.nationmanage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../jquery.min.js" type="text/javascript"></script>
    <script src="../../jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../../Js/common.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHPageName" runat="server">
    民族字典
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHPageTool" runat="server">
    <a href="javascript:void(0)" class="btn" id="btnadd" iconCls="icon-add" onclick="addnation()">新增民族</a>
    <a href="javascript:void(0)" class="btn" id="btndel" iconCls="icon-remove" onclick="deletenation()">删除民族</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPHContent" runat="server">
    <div style="width:100%;margin:0 auto;">
        <div style="height:24px;clear:both;margin-top:0;padding:0;">
            <div style="float:left;margin-left:10px;margin-top:3px;">
                <label for="txtsearch">民族搜索</label>
            </div>
            <div style="float:left;margin-left:10px;">
                <input type="text" id="txtsearch" value="" style="width:150px;" />
            </div>
            <div style="float:left;margin:-2px 0 0 10px;">
                <a href="javascript:void(0)" class="btn1" id="A1" iconCls="icon-search" onclick="searchnation()">查找栏目</a>
            </div>
        </div>
        <div style="width:98%;margin:0 auto;clear:both;">
            <table id="nationgrid" class="easyui-datagrid" title="民族列表" style="margin:2px auto;" data-options="singleSelect:false,fitColumns:true,idField:'FNationID',rownumbers:true,pagination:true">
                <thead>
                    <tr>
                        <th data-options="field:'FNationID',align:'center',checkbox:true">选择</th>
                        <th data-options="field:'FNationName',width:160,align:'center'">民族名称</th>
                        <th data-options="field:'FNationOrder',width:60,align:'center'">顺序</th>
                        <th data-options="field:'FOperation',width:100,align:'center'">操作</th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>
    <input type="hidden" id="hsortname" value="FNationOrder" />
    <input type="hidden" id="hsortdirection" value="asc" />
    <input type="hidden" id="hpagenum" value="1" />
    <input type="hidden" id="hpagesize" value="10" />
    <input type="hidden" id="hparentid" value="0" />

    <!-- 新增窗口 Begin-->
    <div id="addwin" iconCls="icon-save" title="民族资料" style="display:none;text-align:center;">  
        <table style="width: 420px;margin:10px auto;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">            
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    民族名称：
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <input type="hidden" id="hnationid" value="0" />
                    <input type="text" id="txtnationname" style="width:250px;" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    目录顺序：
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <input type="text" id="txtnationorder" value="" style="width:100px;" />
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
    function editnation1(id) {
        var options = {
            type: "POST",
            data: { pid: id },
            success: function (res) {
                if (res) {
                    var json = common.Util.StringToJson(res);
                    $("#hnationid").val(json.FNationID);
                    $("#txtnationname").val(json.FNationName);
                    $("#txtnationorder").val(json.FNationOrder);
                    openwin("addwin", 500, 300, true, "loadgriddata");
                }
                else {
                    $.messager.alert("警告", "无法获取数据,请刷新后重试!", 'warning');
                    return;
                }
            }
        };
        common.Ajax("GetNationItem", options);
    }

    function deletenation() {
        var idlist = GetGridData("nationgrid", "FNationID");
        if (!idlist) {
            $.messager.alert('警告', '请选择相关要删除的数据!', 'warning');
            return;
        }
        $.messager.confirm('确认', '您是否确定要删除选中的民族吗?', function (r) {
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
                common.Ajax("DelNation", options);
            }
        });
    }

    function save() {
        var _nationid = $("#hnationid").val();
        var _nationname = $("#txtnationname").val();
        var _nationorder = $("#txtnationorder").val();
        if (!_nationname) {
            $.messager.alert("民族名称不能为空!");
            return;
        }
        if (!_nationorder) {
            $.messager.alert("民族显示顺序不能为空!");
            return;
        }
        if (!common.Validate.ValidateNumber(_nationorder)) {
            $.messager.alert("民族显示顺序输入格式不正确,请输入正整数!");
            return;
        }

        var options = {
            type: "POST",
            data: { pnationid: _nationid, pnationname: _nationname, pnationorder: _nationorder },
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
        formatgrid("nationgrid", "loadgriddata", "hpagenum", "hpagesize", "hsortname", "hsortdirection");
        loadgriddata();
    });

    function loadgriddata() {
        $.messager.progress();
        $('#nationgrid').datagrid('loading');
        var _searchcontent = $("#txtsearch").val();
        var _sortname = $("#hsortname").val();
        var _sortdirection = $("#hsortdirection").val();
        var _pagenumber = $("#hpagenum").val();
        var _pagesize = $("#hpagesize").val();
        //定义Ajax传递参数数据
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
                if (res) {
                    var json = common.Util.StringToJson(res);
                    $.messager.progress('close');
                    loadgrid("nationgrid", json);
                }
            }
        };
        //调用传递参数向后台传递
        common.Ajax("GetGridData", options);
    }

    function searchnation() {
        loadgriddata();
    }

    function initnation() {
        $("#hnationid").val("0");
        $("#txtnationname").val("");
        $("#txtnationorder").val("");
    }

    function addnation() {
        initnation();
        openwin("addwin", 450, 300, true, "loadgriddata");
    }

    function editnation() {

    }

    function delnation() {

    }

</script>
</asp:Content>
