<%@ Page Title="" Language="C#" MasterPageFile="~/WebContent.Master" AutoEventWireup="true" CodeBehind="ContentClass.aspx.cs" Inherits="HQDevPlatform.OnlineExam.ContentClass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../jquery.min.js" type="text/javascript"></script>
    <script src="../../jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../../Js/common.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHPageName" runat="server">
    内容类别管理
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHPageTool" runat="server">
    <a href="javascript:void(0)" class="btn" id="btnadd" iconCls="icon-add" onclick="add()">新增</a>
    <a href="javascript:void(0)" class="btn" id="btndel" iconCls="icon-remove" onclick="del()">删除</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPHContent" runat="server">
    <div style="width:100%;margin:0 auto;">
	<div style="height:24px;clear:both;margin-top:0;padding:0;">
		<div style="float:left;margin-left:10px;margin-top:3px;">
            <label for="txtsearch">过滤</label>
        </div>
        <div style="float:left;margin-left:10px;">
                <input type="text" id="txtsearch" value="" style="width:150px;" />
            </div>
            <div style="float:left;margin:-2px 0 0 10px;">
                <a href="javascript:void(0)" class="btn1" id="A1" iconCls="icon-search" onclick="loadgriddata()">查找</a>
            </div>
        </div>
         <div style="width:98%;margin:0 auto;clear:both;">
            <table id="listgrid" class="easyui-datagrid" title="列表" style="margin:2px auto;" data-options="singleSelect:false,fitColumns:true,idField:'FContentClassId',rownumbers:true,pagination:true">
                <thead>
                    <tr>
						<th data-options="field:'FContentClassId',align:'center',checkbox:true">选择</th>
						<th data-options="field:'FContentClassCode',width:60,align:'center'">内容类别编号</th>
						<th data-options="field:'FContentClassName',width:100,align:'center'">内容类别名称</th>
						<th data-options="field:'FContentClassContent',width:120,align:'center'">内容类别说明</th>
						<th data-options="field:'FOperation',width:80,align:'center'">操作</th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>
    <input type="hidden" id="hsortname" value="FContentClassId" />
    <input type="hidden" id="hsortdirection" value="asc" />
    <input type="hidden" id="hpagenum" value="1" />
    <input type="hidden" id="hpagesize" value="10" />
    <input type="hidden" id="hparentid" value="0" />
    
    <div id="addwin" iconCls="icon-save" title="内容类别编辑" style="text-align:center;display:none;">  
        <table style="width: 470px;margin:10px auto;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">            
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    内容类别编号
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                	<input type="hidden" id="hFContentClassId" value="0" />
                    <input type="text" id="txtFContentClassCode" value="" style="width:120px;" />
   				</td>
 			</tr>
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    内容类别名称
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <input type="text" id="txtFContentClassName" value="" style="width:300px;" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    内容类别说明
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <textarea id="txtFContentClassContent" rows="10" cols="50" style="width:300px;height:100px;"></textarea>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    内容类别图标
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <input type="text" id="txtFIconPath" value="" style="width:300px;" />
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
        function closewin() {
            $("#addwin").window('close');
        }

        function initwin() {
            $("#hFContentClassId").val("0");
            //other init control fill there
            $("#txtFContentClassCode").val("");
            $("#txtFContentClassName").val("");
            $("#txtFContentClassContent").val("");
            $("#txtFIconPath").val("");
        }

        function add() {
            initwin();
            openwin("addwin", 500, 400, true, "loadgriddata");
        }

        function edit(id) {
            var options = {
                type: "POST",
                data: { pid: id },
                success: function (res) {
                    if (res) {
                        var json = common.Util.StringToJson(res);
                        $("#hFContentClassId").val(json.FContentClassId);
                        //other controls fill here
                        $("#txtFContentClassCode").val(json.FContentClassCode);
                        $("#txtFContentClassName").val(json.FContentClassName);
                        $("#txtFContentClassContent").val(json.FContentClassContent);
                        $("#txtFIconPath").val(json.FIconPath);
                        $("#hparentid").val(json.FParentId);
                        openwin("addwin", 500, 400, true, "loadgriddata");
                    }
                    else {
                        $.messager.alert("警告", "无法获取数据,请刷新后重试!", 'warning');
                        return;
                    }
                }
            };
            common.Ajax("GetItem", options);
        }

        function save() {
            var _FContentClassId = $("#hFContentClassId").val();
            //get data fill here
            var _FContentClassCode = $("#txtFContentClassCode").val();
            var _FContentClassName = $("#txtFContentClassName").val();
            var _FContentClassContent = $("#txtFContentClassContent").val();
            var _FIconPath = $("#txtFIconPath").val();
            var _FParentId = $("#hparentid").val();

            //judge data fill here
            if (!_FContentClassCode) {
                $.messager.alert("警告", "内容类别编号不能为空!", "warning");
                return;
            }
            if (!_FContentClassName) {
                $.messager.alert("警告", "内容类别名称不能为空!", "warning");
                return;
            }

            var options = {
                type: "POST",
                data: {
                    pFContentClassId: _FContentClassId,
                    pFContentClassCode: _FContentClassCode,
                    pFContentClassName: _FContentClassName,
                    pFContentClassContent: _FContentClassContent,
                    pFIconPath: _FIconPath,
                    pFParentId: _FParentId
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

        function del() {
            var idlist = GetGridData("listgrid", "FContentClassId");
            if (!idlist) {
                $.messager.alert('警告', '请选择相关要删除的数据!', 'warning');
                return;
            }
            $.messager.confirm('确认', '您是否确定要删除选中的数据吗?', function (r) {
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
                    common.Ajax("DelData", options);
                }
            });
        }

        $(function () {
            $('.btn').linkbutton({ plain: true });
            $('.btn1').linkbutton();
            formatgrid("listgrid", "loadgriddata", "hpagenum", "hpagesize", "hsortname", "hsortdirection");
            //loadgriddata();
        });

        function loadgriddata() {
            $.messager.progress();
            $('#listgrid').datagrid('loading');
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
                    loadgrid("listgrid", json);
                }
            };
            common.Ajax("GetGridData", options);
        }
        
    </script>
</asp:Content>
