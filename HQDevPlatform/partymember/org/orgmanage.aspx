<%@ Page Title="" Language="C#" MasterPageFile="~/WebContent.Master" AutoEventWireup="true" CodeBehind="orgmanage.aspx.cs" Inherits="HQDevPlatform.partymember.org.orgmanage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../jquery.min.js" type="text/javascript"></script>
    <script src="../../jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../../Js/common.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHPageName" runat="server">
    组织架构管理
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHPageTool" runat="server">
    <a href="javascript:void(0)" class="btn" id="A2" iconCls="icon-back" onclick="back()" style="display:none;">返回上级</a>
    <a href="javascript:void(0)" class="btn" id="btnadd" iconCls="icon-add" onclick="add()">新增党组织</a>
    <a href="javascript:void(0)" class="btn" id="btndel" iconCls="icon-remove" onclick="del()">删除党组织</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPHContent" runat="server">
    <div style="width:100%;margin:0 auto;">
	    <div style="height:24px;clear:both;margin-top:0;padding:0;">
		    <div style="float:left;margin-left:10px;margin-top:3px;">
                <label for="txtsearch">部门过滤</label>
            </div>
            <div style="float:left;margin-left:10px;">
                <select id="seldept" onchange="changedept()"></select>
                <input type="hidden" id="hdeptid" value="0" />
            </div>
            <div style="float:left;margin-left:10px;margin-top:3px;">
                <label for="txtsearch">组织名称</label>
            </div>
            <div style="float:left;margin-left:10px;">
                <input type="text" id="txtsearch" value="" style="width:150px;" />
            </div>
            <div style="float:left;margin:-2px 0 0 10px;">
                <a href="javascript:void(0)" class="btn1" id="A1" iconCls="icon-search" onclick="loadgriddata()">查找党组织</a>
            </div>
            <div style="float:right;margin:0px 20px 0 10px;font-size:9pt;">
                上级党组织:<span id="spanorg" style="font-weight:800;color:Red;">无</span>
            </div>
        </div>
        <div style="width:98%;margin:0 auto;clear:both;">
            <table id="listgrid" class="easyui-datagrid" title="列表" style="margin:22px auto;" data-options="singleSelect:false,fitColumns:true,idField:'FOrgId',rownumbers:true,pagination:true">
                <thead>
                    <tr>
					    <th data-options="field:'FOrgId',align:'center',checkbox:true">选择</th>
					    <th data-options="field:'FOrgName',width:160,align:'center'">组织名称</th>
					    <th data-options="field:'FOrgTypeName',width:60,align:'center'">组织性质</th>
					    <th data-options="field:'FOrgNewDateStr',width:100,align:'center'">最近一次选举换届时间</th>
					    <th data-options="field:'FOrgOrder',width:60,align:'center'">显示顺序</th>
					    <th data-options="field:'FOperation',width:120,align:'center'">操作</th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>
    <input type="hidden" id="hsortname" value="FOrgOrder" />
    <input type="hidden" id="hsortdirection" value="asc" />
    <input type="hidden" id="hpagenum" value="1" />
    <input type="hidden" id="hpagesize" value="10" />
    <input type="hidden" id="hparentid" value="0" />
    
    <div id="addwin" iconCls="icon-save" title="组织明细资料" style="text-align:center;display:none;">  
        <table style="width: 470px;margin:10px auto;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">            
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    组织名称
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                	<input type="hidden" id="hFOrgId" value="0" />
                    <input type="text" id="txtFOrgName" value= "" style="width:240px;" />
   				</td>
 			</tr>
            <tr>
                 <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    组织类型
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <select id="selFOrgType">
                        <option value="">==请选择组织类型==</option>
                        <option value="1">党委</option>
                        <option value="2">党总支</option>
                        <option value="3">党支部</option>
                    </select>
                </td>
            </tr>
             <tr>
                 <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    上一次换届日期
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <input type="text" id="txtorgnewdate" value="" style="width:100px;" />
                </td>
            </tr>
            <tr>
                 <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    显示顺序
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <input type="text" id="txtorder" value="" style="width:100px;" />
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
        function commeett(id) {
            window.parent.addtab("组织成员管理", "PM000101", "../partymember/org/orgcommeett.aspx?orgid=" + id);
            //window.location.href = "../org/orgcommeett.aspx?orgid=" + id;
        }
        
        function back() {
            var _parentid = $("#hparentid").val();
            var options = {
                type: "POST",
                data: { pid: _parentid },
                success: function (res) {
                    $("#hparentid").val(res);
                    loadgriddata();
                }
            };
            common.Ajax("GetNowParent", options);
        }
        
        function downclass(id) {
            $("#hparentid").val(id);
            loadgriddata();
        }
        
        function changedept() {
            var deptid = $("#seldept").val();
            $("#hparentid").val("0");
            if (!deptid) {
                $("#hdeptid").val("0");   
            }
            else {
                $("#hdeptid").val(deptid);
                loadgriddata();
            }
            
        }
        
        function closewin() {
            $("#addwin").window('close');
        }

        function initwin() {
            $("#hFOrgId").val("0");
            //other init control fill there
            $("#txtFOrgName").val("");
            $("#selFOrgType").val("");
            $("#txtorder").val("10");
        }

        function add() {
            var _deptid = $("#hdeptid").val();
            if (_deptid == "0" || !_deptid) {
                $.messager.alert("警告", "请首先选择部门!","warning");
                return;
            }
            else {
                initwin();
                openwin("addwin", 500, 300, true, "loadgriddata");
            }
        }

        function edit(id) {
            var options = {
                type: "POST",
                data: { pid: id },
                success: function (res) {
                    if (res) {
                        var json = common.Util.StringToJson(res);
                        $("#hFOrgId").val(json.FOrgId);
                        //other controls fill here
                        $("#txtFOrgName").val(json.FOrgName);
                        $("#selFOrgType").val(json.FOrgType);
                        $("#txtorgnewdate").datebox('setValue', json.FOrgNewDateStr);
                        $("#txtorder").val(json.FOrgOrder);
                        openwin("addwin", 500, 300, true, "loadgriddata");
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
            var _FOrgId = $("#hFOrgId").val();
            //get data fill here
            var _orgname = $("#txtFOrgName").val();
            var _deptid = $("#hdeptid").val();
            var _parentid = $("#hparentid").val();
            var _orgtype = $("#selFOrgType").val();
            var _orgnewdate = $("#txtorgnewdate").datebox('getValue');
            var _order = $("#txtorder").val();
            //judge data fill here
            if (!_orgname) {
                $.messager.alert("警告", "组织名称不能为空!", "warning");
                return;
            }
            if (!_deptid || _deptid == "0") {
                $.messager.alert("警告", "所属部门未选择,请选择所属部门", "warning");
                return;
            }
            if (!_orgtype) {
                $.messager.alert("警告", "组织类型不能为空!", "warning");
                return;
            }
            if (!_order) {
                $.messager.alert("警告", "组织显示顺序不能为空!", "warning");
                return;
            }
            else {
                if (!common.Validate.ValidateNumber(_order)) {
                    $.messager.alert("警告", "组织显示顺序格式不正确,请输入整数!", "warning");
                    return;
                }
            }
            if (!common.Validate.ValidateDateTime(_orgnewdate)) {
                $.messager.alert("警告", "上次换届日期输入不正确!", "warning");
                return;
            }

            var options = {
                type: "POST",
                data: {
                    pFOrgId: _FOrgId,
                    pFOrgName: _orgname,
                    pDeptId: _deptid,
                    pFOrgType : _orgtype,
                    pOrder: _order,
                    pParentId: _parentid,
                    pNewDate : _orgnewdate
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
            var idlist = GetGridData("listgrid", "FOrgId");
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
            $("#seldept").append("<option value=''>==请选择部门==</option>");
            common.DropDownList.Load("seldept", deptdata, "FDepartmentName", "FDepartmentID");
            $('#txtorgnewdate').datebox({ currentText: '今天', closeText: '关闭', okText: '确定', formatter: formatD });
            var _deptid = $("#hdeptid").val();
            if (_deptid != "0") {
                $("#seldept").val(_deptid);
            }
        });

        function formatD(date) {
            var _mon = date.getMonth() + 1;
            return date.getFullYear() + "-" + _mon + "-" + date.getDate();
        }

        function loadgriddata() {
            var _searchcontent = $("#txtsearch").val();
            var _sortname = $("#hsortname").val();
            var _sortdirection = $("#hsortdirection").val();
            var _pagenumber = $("#hpagenum").val();
            var _pagesize = $("#hpagesize").val();
            var _deptid = $("#seldept").val();
            var _parentorgid = $("#hparentid").val();
            if (!_deptid) {
                return;
            }
            else {
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
                        pdeptid: _deptid,
                        pparentid: _parentorgid
                    },
                    success: function (res) {
                        var pos = res.indexOf('|]');
                        if (pos > 0) {
                            var _orgname = res.substring(0, pos);
                            $("#spanorg").html(_orgname);
                            res = res.substring(pos + 2, res.length);
                        }
                        var json = common.Util.StringToJson(res);
                        var _orgname = common.Data.GetDatasource("parentorgname");
                        var al = common.Data.GetDatasource("orgnamedata");
                        $.messager.progress('close');
                        loadgrid("listgrid", json);

                    }
                };
                common.Ajax("GetGridData", options);
            }
            var _parentid = $("#hparentid").val();
            if (_parentid == "0") {
                $("#A2").hide();
            }
            else {
                $("#A2").show();
            }
        }
        
    </script>  
</asp:Content>
