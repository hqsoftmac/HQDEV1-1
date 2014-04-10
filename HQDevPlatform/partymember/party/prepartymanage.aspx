<%@ Page Title="" Language="C#" MasterPageFile="~/WebContent.Master" AutoEventWireup="true" CodeBehind="prepartymanage.aspx.cs" Inherits="HQDevPlatform.partymember.party.prepartymanage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../jquery.min.js" type="text/javascript"></script>
    <script src="../../jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../../Js/common.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHPageName" runat="server">
    预备党员管理
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHPageTool" runat="server">
    <a href="javascript:void(0)" class="btn" id="btnadd" iconCls="icon-add" onclick="add()">新增预备党员</a>
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
                <label for="txtsearch">人员姓名</label>
            </div>
            <div style="float:left;margin-left:10px;">
                <input type="text" id="txtsearch" value="" style="width:150px;" />
            </div>
            <div style="float:left;margin:-2px 0 0 10px;">
                <a href="javascript:void(0)" class="btn1" id="A1" iconCls="icon-search" onclick="loadgriddata()">查找</a>
            </div>
        </div>
         <div style="width:98%;margin:0 auto;clear:both;">
            <table id="listgrid" class="easyui-datagrid" title="列表" style="margin:2px auto;" data-options="singleSelect:false,fitColumns:true,idField:'FMemberId',rownumbers:true,pagination:true">
                <thead>
                    <tr>
						<th data-options="field:'FMemberId',align:'center',checkbox:true">选择</th>
                        <th data-options="field:'FMemberCode',width:40,align:'center'">人员编号</th>
						<th data-options="field:'FMemberName',width:40,align:'center'">人员姓名</th>
                        <th data-options="field:'FDepartmentName',width:60,align:'center'">所属部门</th>
                        <th data-options="field:'FOrgName',width:60,align:'center'">所在党组织</th>
                        <th data-options="field:'FPosition',width:60,align:'center'">职务</th>
						<th data-options="field:'FMemberGendorName',width:20,align:'center'">性别</th>
                        <th data-options="field:'FEducationName',width:60,align:'center'">学历</th>
                        <th data-options="field:'FNationName',width:60,align:'center'">民族</th>
						<th data-options="field:'FBirthDateStr',width:60,align:'center'">出生日期</th>
                        <th data-options="field:'FActivistDateStr',width:60,align:'center'">入党日期</th>
						<th data-options="field:'FOperation',width:120,align:'center'">操作</th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>
    <input type="hidden" id="hsortname" value="FMemberCode" />
    <input type="hidden" id="hsortdirection" value="asc" />
    <input type="hidden" id="hpagenum" value="1" />
    <input type="hidden" id="hpagesize" value="10" />

    <div id="addwin" iconCls="icon-save" title="新增预备党员" style="text-align:center;display:none;">  
        <table style="width: 470px;margin:10px auto;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">            
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    所属部门
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                	<input type="hidden" id="hpartydeptid" value="0" />
                    <label id="lbldeptname"></label>
   				</td>
 			</tr>
             <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    选择人员
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <input type="hidden" id="hselmemberid" value="0" />
                    <input type="text" id="txtmembername" value="" style="width:200px;" readonly />
                    <a href="javascript:void(0)" class="btn" id="A4" iconCls="icon-search" onclick="querymember()">查找人员</a>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    所属党组织
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <input type="hidden" id="horgid" value="0" />
                    <input type="text" id="txtorgname" value="" style="width:200px;" readonly />
                    <a href="javascript:void(0)" class="btn" id="A3" iconCls="icon-search" onclick="queryorg()">查找党组织</a>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    入党日期
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <input type="text" id="txtactivistdate" style="width:80px;" value="" />
                </td>
            </tr>
		</table>
		<div style="margin:20px auto;">
            <a href="#" class="btn1" id="btnsave" iconCls="icon-save" onclick="comfirmpreparty()">确定</a>&nbsp;&nbsp;
            <a href="#" class="btn1" id="btnclose" iconCls="icon-cancel" onclick="closewin()" >取消</a>
        </div>
    </div>
    <div id="searchmember" iconCls="icon-save" title="过滤人员" style="text-align:center;display:none;">  
        <div style="width:98%;margin:0 auto;clear:both;">
            <div style="width:100%;clear:both;margin:5px 0 5px 0;">
                <div style="float:left;margin-left:10px;margin-top:3px;">
                    <label for="txtsearch">姓名过滤</label>
                </div>
                <div style="float:left;margin-left:10px;margin-top:0px;">
                    <input type="text" id="txtmembersearch" value="" style="width:160px;" />
                </div>
                <div style="float:left;margin:-2px 0 0 10px;">
                    <a href="javascript:void(0)" class="btn1" id="A5" iconCls="icon-search" onclick="querymember()">查找</a>
                </div>
            </div>
            <div style="clear:both;width:100%;margin:15px 0 5px 0;">
                <table id="selmembergrid" class="easyui-datagrid" title="选择人员列表" style="margin:2px auto;" data-options="singleSelect:true,fitColumns:true,idField:'FMemberId',rownumbers:true">
                    <thead>
                        <tr>
                            <th data-options="field:'FMemberId',align:'center',checkbox:true">选择</th>
                            <th data-options="field:'FMemberCode',width:60,align:'center'">人员编号</th>
                            <th data-options="field:'FMemberName',width:60,align:'center'">人员姓名</th>  
                            <th data-options="field:'FMemberGendorName',width:50,align:'center'">性别</th>
                            <th data-options="field:'FEducationName',width:50,align:'center'">学历</th>
                            <th data-options="field:'FPosition',width:60,align:'center'">职务</th>
                        </tr>
                    </thead>
                </table>
            </div>
        </div>
    </div>

    <div id="orgwin" iconCls="icon-save" title="党组织选择" style="display:none;text-align:center;">
        <table id="treetable">
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="CPHJavascript" runat="server">
    <script type="text/javascript">
        function chooseorg() {
            var rows = $('#treetable').datagrid('getSelected');
            if (!rows || rows.length == 0) {
                $.messager.alert('提示', '请选择相关党组织!', 'info');
                return;
            }
            $("#horgid").val(rows.FOrgId);
            $("#txtorgname").val(rows.FOrgName);
            closewin3();
        }

        function queryorg() {
            openwin("orgwin", 450, 400, true, "returnorg");
            $("#treetable").treegrid({
                title: '党组织目录',
                rownumbers: true,
                singleSelect: true,
                idField: 'FOrgId',
                treeField: 'FOrgName',
                loadMsg: '数据加载中请稍后……',
                animate: true,
                height: 364,
                columns: [[{ field: 'FOrgId', title: '选择', width: 80, checkbox: true, align: 'center' },
                            { field: 'FOrgName', title: '党组织名称', width: 150 },
                            { field: 'FOrgTypeName', title: '党组织类型', width: 150 }
	                    ]],
                toolbar: [{ text: '选择', iconCls: 'icon-save', handler: function () { chooseorg(); } }, { text: '取消', iconCls: 'icon-cancel', handler: function () { closewin3(); } }]
            });
            loadorg();
        }

        function loadorg() {
            var _deptid = $("#hpartydeptid").val();
            var options = {
                type: "POST",
                data: { pdeptid: _deptid },
                success: function (res) {
                    var json = common.Util.StringToJson(res);
                    $('#treetable').treegrid('loadData', json);
                }
            };
            common.Ajax("GetOrgTree", options);
        }

        function closewin3() {
            $("#orgwin").window('close');
        }

        function returnorg() {

        }

        function uppreparty(id) {
            $.messager.confirm('确认', '您是否确定要将该人员的发展为预备党员吗?', function (r) {
                if (!r) {
                    return;
                }
                else {
                    var options = {
                        type: "POST",
                        data: { pid: id },
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
                    common.Ajax("UpItem", options);
                }
            });
        }

        function delpre(id) {
            $.messager.confirm('确认', '您是否确定要取消该人员的预备党员资格吗?取消后，该人员将降级为发展对象!', function (r) {
                if (!r) {
                    return;
                }
                else {
                    var options = {
                        type: "POST",
                        data: { pid: id },
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
                    common.Ajax("DelItem", options);
                }
            });
        }

        function comfirmpreparty() {
            var _deptid = $("#hpartydeptid").val();
            var _memberid = $("#hselmemberid").val();
            var _date = $("#txtactivistdate").datebox('getValue');
            var _orgid = $("#horgid").val();
            if (!_memberid || _memberid == '0') {
                $.messager.alert('警告', '请选择相关人员', 'warning');
                return;
            }
            if (!_orgid || _orgid == '0') {
                $.messager.alert('警告', '请选择对应的党组织!', 'warning');
                return;
            }

            if (!_date) {
                $.messager.alert('警告', '请选择确定积极份子的日期!', 'warning');
                return;
            }
            var options = {
                type: "POST",
                data: { pdeptid: _deptid, pmemberid: _memberid, pdate: _date, porgid: _orgid },
                success: function (res) {
                    var json = common.Util.StringToJson(res);
                    if (json.ErrorCode == common.Consts.SuccessCode) {
                        loadgriddata();
                        closewin();
                    }
                    else {
                        $.messager.alert('警告', json.ErrorMessage, 'warning');
                        return;
                    }
                }
            };
            common.Ajax("SetPreparty", options);
        }



        function choosemember() {
            var rows = $('#selmembergrid').datagrid('getSelected');
            if (!rows || rows.length == 0) {
                $.messager.alert('提示', '请选择相关人员!', 'info');
                return;
            }
            $("#hselmemberid").val(rows.FMemberId);
            $("#txtmembername").val("[" + rows.FMemberCode + "] " + rows.FMemberName);
            $("#horgid").val(rows.FOrgId);
            $("#txtorgname").val(rows.FOrgName);
            closewin2();
        }

        function querymember() {
            $.messager.progress();
            $("#searchmember").show();
            $('#selmembergrid').datagrid('unselectAll');
            $('#selmembergrid').datagrid('loadData', { total: 0, rows: [] });
            $('#selmembergrid').datagrid({ loadMsg: '正在载入人员列表,请耐心等待...', toolbar: [{ text: '选择', iconCls: 'icon-save', handler: function () { choosemember(); } }, { text: '取消', iconCls: 'icon-cancel', handler: function () { closewin2(); } }] });
            var _deptid = $("#hpartydeptid").val();
            var _searchtext = $("#txtmembersearch").val();
            var options = {
                type: "POST",
                data: { pdeptid: _deptid, psearchtext: _searchtext },
                success: function (res) {
                    var json = common.Util.StringToJson(res);
                    loadgrid("selmembergrid", json);
                    $.messager.progress('close');
                    openwin("searchmember", 450, 500, true, "returnmember");
                }
            };
            common.Ajax("GetDeptMember", options);
        }

        function closewin2() {
            $("#searchmember").window('close');
        }

        function returnmember() {

        }

        function closewin() {
            $("#addwin").window('close');
        }

        function initwin(deptid, deptname) {
            $("#hpartydeptid").val(deptid);
            $("#lbldeptname").html(deptname);
            $("#hselmemberid").val("0");
            $("#txtmembername").val("");
            $("#horgid").val("0");
            $("#txtorgname").val("");
            var myDate = new Date();
            var _mon = myDate.getMonth() + 1;
            var sdate = myDate.getFullYear() + "-" + _mon + "-" + myDate.getDate();
            $("#txtactivistdate").datebox('setValue', sdate);
        }

        function del() {
            var idlist = GetGridData("listgrid", "FMemberId");
            if (!idlist) {
                $.messager.alert('警告', '请选择相关要删除的数据!', 'warning');
                return;
            }
            $.messager.confirm('确认', '您是否确定要选中的数据吗?', function (r) {
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

        function add() {
            var _id = $("#seldept").val();
            var _name = $("#seldept").find("option:selected").text();
            if (!_id || _id == '0') {
                $.messager.alert('警告', '请选择所属部门!', 'warning');
                return;
            }
            initwin(_id, _name);
            openwin("addwin", 500, 400, true, "loadgriddata");
        }

        $(function () {
            $('.btn').linkbutton({ plain: true });
            $('.btn1').linkbutton();
            formatgrid("listgrid", "loadgriddata", "hpagenum", "hpagesize", "hsortname", "hsortdirection");
            loadgriddata();
            var deptdata = common.Data.GetDatasource("deptlist");
            $("#seldept").empty();
            $("#seldept").append("<option value='0'>所有部门</option>");
            common.DropDownList.Load("seldept", deptdata, "FDepartmentName", "FDepartmentID");
            $('#txtactivistdate').datebox({ currentText: '今天', closeText: '关闭', okText: '确定', formatter: formatD });

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
                    $('.btn').linkbutton({ plain: true });
                }
            };
            common.Ajax("GetGridData", options);
        }

        function formatD(date) {
            var _mon = date.getMonth() + 1;
            return date.getFullYear() + "-" + _mon + "-" + date.getDate();
        }
    </script>
</asp:Content>
