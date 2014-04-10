<%@ Page Title="" Language="C#" MasterPageFile="~/WebContent.Master" AutoEventWireup="true" CodeBehind="lanmuset.aspx.cs" Inherits="HQDevSys.manage.lanmu.lanmuset" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../jquery.min.js" type="text/javascript"></script>
    <script src="../../jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../../Js/common.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHPageName" runat="server">
    网站栏目管理
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHPageTool" runat="server">
    <a href="javascript:void(0)" class="btn" id="A2" iconCls="icon-back" onclick="backlanmu()" style="display:none;">返回上级</a>
    <a href="javascript:void(0)" class="btn" id="btnadd" iconCls="icon-add" onclick="addlanmu()">新增栏目</a>
    <a href="javascript:void(0)" class="btn" id="btndel" iconCls="icon-remove" onclick="dellanmu()">删除栏目</a>
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
            <table id="lanmugrid" class="easyui-datagrid" title="栏目列表" style="margin:2px auto;" data-options="singleSelect:false,fitColumns:true,idField:'FColumnId',rownumbers:true,pagination:true">
                <thead>
                    <tr>
                        <th data-options="field:'FColumnId',align:'center',checkbox:true">选择</th>
                        <th data-options="field:'FColumnName',width:100,align:'center'">栏目名称</th>
                        <th data-options="field:'FColumnTypeName',width:60,align:'center'">栏目类型</th>
                        <th data-options="field:'FColumnUrl',width:120,align:'center'">自定义url</th>
                        <th data-options="field:'FColumnTargetName',width:60,align:'center'">链接目标</th>
                        <th data-options="field:'FColumnVisibleName',width:60,align:'center',sortable:true">显示</th>
                        <th data-options="field:'FColumnOrder',width:60,align:'center'">顺序</th>
                        <th data-options="field:'FOperation',width:180,align:'center'">操作</th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>
    <input type="hidden" id="hsortname" value="FColumnOrder" />
    <input type="hidden" id="hsortdirection" value="asc" />
    <input type="hidden" id="hpagenum" value="1" />
    <input type="hidden" id="hpagesize" value="10" />
    <input type="hidden" id="hparentid" value="0" />
    <!-- 新增窗口 Begin-->
    <div id="addwin" iconCls="icon-save" title="栏目资料" style="display:none;text-align:center;">  
        <table style="width: 470px;margin:10px auto;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">            
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    栏目名称：
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <input type="hidden" id="hcolumnid" value="0" />
                    <input type="text" id="txtcolumnname" style="width:150px;" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    栏目描述：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left:5px;text-align:left;" >
                    <input type="text" id="txtcolumncontent" style="width:250px;" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    栏目类型：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left:5px;text-align:left;" >
                    <select id="selcolumntype">
                        <option value="" selected>==选择栏目类型==</option>
                        <option value="0">普通页面</option>
                        <option value="1">首页</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    自定义Url：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left:5px;text-align:left;" >
                    <input type="text" id="txtcolumnurl" value="" style="width:250px;" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    链接目标：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left:5px;text-align:left;" >
                    <select id="selcolumntarget">
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
                    <select id="selcolumnvisible">
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
                    <input type="text" id="txtorder" style="width:50px;" value="10" />
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
        function nav(_columnid) {
            window.location = "navdefine.aspx?colid=" + _columnid;
        }

        function dellanmu() {
            var idlist = GetGridData("lanmugrid", "FColumnId");
            $.messager.confirm('确认', '您是否确定要删除选中的栏目吗?注意若栏目下存在下级栏目,请先删除下级栏目,否则无法删除!', function (r) {
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

        function save() {
            var _columnid = $("#hcolumnid").val();
            var _columnname = $("#txtcolumnname").val();
            var _columncontent = $("#txtcolumncontent").val();
            var _columntype = $("#selcolumntype").val();
            var _columnurl = $("#txtcolumnurl").val();
            var _columntarget = $("#selcolumntarget").val();
            var _columnvisible = $("#selcolumnvisible").val();
            var _parentid = $("#hparentid").val();
            var _order = $("#txtorder").val();
            //验证
            if (!_columnname) {
                $.messager.alert('警告', '栏目名称不能为空!', 'warning');
                return;
            }
            if (!_columntype) {
                $.messager.alert('警告', '栏目类型不能为空!', 'warning');
                return;
            }
            if (!_columntarget) {
                $.messager.alert('警告', '链接目标不能为空!', 'warning');
                return;
            }
            $.messager.progress();
            var options = {
                type: "POST",
                data: {
                    pcolumnid: _columnid,
                    pcolumnname: _columnname,
                    pcolumncontent: _columncontent,
                    pcolumntype: _columntype,
                    pcolumnurl: _columnurl,
                    pcolumntarget: _columntarget,
                    pcolumnvisible: _columnvisible,
                    pparentid: _parentid,
                    pcolumnorder : _order
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

        function edititem(id) {
            var options = {
                type: "POST",
                data: { pid: id },
                success: function (res) {
                    var json = common.Util.StringToJson(res);
                    $("#hcolumnid").val(json.FColumnId);
                    $("#txtcolumnname").val(json.FColumnName);
                    $("#txtcolumncontent").val(json.FColumnContent);
                    $("#selcolumntype").val(json.FColumnType);
                    $("#txtcolumnurl").val(json.FColumnUrl);
                    $("#selcolumntarget").val(json.FColumnTarget);
                    $("#selcolumnvisible").val(json.FColumnVisible);
                    openwin("addwin", 500, 350, true, "loadgriddata");
                }
            };
            common.Ajax("GetColumnItem", options);
        }
        
        function initlanmu() {
            $("#hcolumnid").val("0");
            $("#txtcolumnname").val("");
            $("#txtcolumncontent").val("");
            $("#selcolumntype").val("");
            $("#txtcolumnurl").val("");
            $("#selcolumntarget").val("");
            $("#selcolumnvisible").val("1");
        }
        
        function addlanmu() {
            initlanmu();
            openwin("addwin",500,350,true,"loadgriddata");
        }
        
        $(function () {
            $('.btn').linkbutton({ plain: true });
            $('.btn1').linkbutton();
            formatgrid("lanmugrid", "loadgriddata", "hpagenum", "hpagesize", "hsortname", "hsortdirection");
            loadgriddata();
            var _parentid = $("#hparentid").val();
            if (_parentid == "0") {
                $("#A2").hide();
            }
            else {
                $("#A2").show();
            }
        });

        function closewin() {
            $("#addwin").window("close");
        }

        function downclass(id) {
            $("#hparentid").val(id);
            $("#hpagenum").val("1");
            $("#hpagesize").val("10");
            loadgriddata();
        }

        function backlanmu() {
            var _parentid = $("#hparentid").val();
            if (_parentid == "0") {
                $.messager.alert('警告', '已经是最上一级栏目了!', 'warning');
                return;
            }
            else {
                var _parentid = $("#hparentid").val();
                var options = {
                    type: "POST",
                    data: { pchildid: _parentid },
                    success: function (res) {
                        $("#hsortname").val("FColumnOrder");
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

        function loadgriddata() {
            $.messager.progress();
            $('#lanmugrid').datagrid('loading');
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
                    loadgrid("lanmugrid", json);
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
