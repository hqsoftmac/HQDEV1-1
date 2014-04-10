<%@ Page Title="" Language="C#" MasterPageFile="~/WebContent.Master" AutoEventWireup="true" CodeBehind="orgmember.aspx.cs" Inherits="HQDevPlatform.partymember.org.orgmember" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../jquery.min.js" type="text/javascript"></script>
    <script src="../../jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../../Js/common.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHPageName" runat="server">
    组织领导管理
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHPageTool" runat="server">
    <a href="javascript:void(0)" class="btn" id="btnadd" iconCls="icon-add" onclick="add()">新增</a>
    <a href="javascript:void(0)" class="btn" id="btndel" iconCls="icon-remove" onclick="del()">删除</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPHContent" runat="server">
    <div style="width:100%;margin:0 auto;">
	<div style="height:24px;clear:both;margin-top:0;padding:0;">
		<div style="float:left;margin-left:10px;margin-top:3px;">
                <label for="txtsearch">部门过滤</label>
            </div>
            <div style="float:left;margin-left:10px;">
                <select id="seldept"></select>
            </div>
        <div style="float:left;margin-left:10px;margin-top:3px;">
            <label for="txtsearch">领导姓名</label>
        </div>
        <div style="float:left;margin-left:10px;">
                <input type="text" id="txtsearch" value="" style="width:150px;" />
            </div>
            <div style="float:left;margin:-2px 0 0 10px;">
                <a href="javascript:void(0)" class="btn1" id="A1" iconCls="icon-search" onclick="loadgriddata()">查找</a>
            </div>
        </div>
         <div style="width:98%;margin:0 auto;clear:both;">
            <table id="listgrid" class="easyui-datagrid" title="列表" style="margin:2px auto;" data-options="singleSelect:false,fitColumns:true,idField:'FLeaderId',rownumbers:true,pagination:true">
                <thead>
                    <tr>
						<th data-options="field:'FLeaderId',align:'center',checkbox:true">选择</th>
						<th data-options="field:'FLeaderName',width:120,align:'center'">领导姓名</th>
						<th data-options="field:'FLeaderPostion',width:120,align:'center'">领导职务</th>
                        <th data-options="field:'FLeaderOrder',width:60,align:'center'">显示顺序</th>
						<th data-options="field:'FOperation',width:60,align:'center'">操作</th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>
    <input type="hidden" id="hsortname" value="FLeaderOrder" />
    <input type="hidden" id="hsortdirection" value="asc" />
    <input type="hidden" id="hpagenum" value="1" />
    <input type="hidden" id="hpagesize" value="10" />
    
    <div id="addwin" iconCls="icon-save" title="领导资料" style="text-align:center;display:none;">  
        <table style="width: 470px;margin:10px auto;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">            
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    领导姓名
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                	<input type="hidden" id="hFLeaderId" value="0" />
                    <input type="text" id="txtLeaderName" value="" style="width:220px;" />
   				</td>
 			</tr>
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    领导职务
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <input type="text" id="txtLeaderPosition" value="" style="width:220px;" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    排序
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <input type="text" id="txtLeaderOrder" value="" style="width:60px;" />
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
            $("#hFLeaderId").val("0");
            //other init control fill there
            $("#txtLeaderName").val("");
            $("#txtLeaderPosition").val("");
            $("#txtLeaderOrder").val("10");
        }

        function add() {
            var _deptid = $("#seldept").val();
            if (!_deptid || _deptid == '0') {
                $.messager.alert("警告", "请首先选择所属部门", "warning");
                return;
            }
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
                        $("#hFLeaderId").val(json.FLeaderId);
                        //other controls fill here
                        $("#txtLeaderName").val(json.FLeaderName);
                        $("#txtLeaderPosition").val(json.FLeaderPostion);
                        $("#txtLeaderOrder").val(json.FLeaderOrder);
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
            var _FLeaderId = $("#hFLeaderId").val();
            //get data fill here
            var _leadername = $("#txtLeaderName").val();
            var _leaderposition = $("#txtLeaderPosition").val();
            var _leaderorder = $("#txtLeaderOrder").val();
            var _deptid = $("#seldept").val();
            //judge data fill here
            if (!_leadername) {
                $.messager.alert("警告", "领导姓名不能为空!", 'warning');
                return;
            }

            if (!_leaderposition) {
                $.messager.alert("警告", "领导职务不能为空!", 'warning');
                return;
            }
            if (!_leaderorder) {
                $.messager.alert("警告", "领导职务不能为空!", 'warning');
                return;
            }
            else {
                if (!common.Validate.ValidateNumber(_leaderorder)) {
                    $.messager.alert("警告", "显示顺序输入不正确!", 'warning');
                    return;
                }
            }

            var options = {
                type: "POST",
                data: {
                    pFLeaderId: _FLeaderId,
                    pName : _leadername,
                    pPosition : _leaderposition,
                    pOrder: _leaderorder,
                    pDeptid : _deptid
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
            var idlist = GetGridData("listgrid", "FLeaderId");
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
            loadgriddata();
            var deptdata = common.Data.GetDatasource("deptlist");
            $("#seldept").empty();
            $("#seldept").append("<option value=''>==请选择所属部门==</option>");
            common.DropDownList.Load("seldept", deptdata, "FDepartmentName", "FDepartmentID");
        });

        function loadgriddata() {
            
            var _searchcontent = $("#txtsearch").val();
            var _sortname = $("#hsortname").val();
            var _sortdirection = $("#hsortdirection").val();
            var _pagenumber = $("#hpagenum").val();
            var _pagesize = $("#hpagesize").val();
            var _deptid = $("#seldept").val();
            if (!_deptid || _deptid == '0') {
                return;
            }
            $.messager.progress();
            $('#listgrid').datagrid('loading');
            var options = {
                type: "POST",
                data: {
                    psearchcontent: _searchcontent,
                    psortname: _sortname,
                    psortdirection: _sortdirection,
                    ppagenumber: _pagenumber,
                    ppagesize: _pagesize,
                    pdeptid : _deptid
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
