<%@ Page Title="" Language="C#" MasterPageFile="~/WebContent.Master" AutoEventWireup="true" CodeBehind="orgcommeett.aspx.cs" Inherits="HQDevPlatform.partymember.org.orgcommeett" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../jquery.min.js" type="text/javascript"></script>
    <script src="../../jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../../Js/common.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHPageName" runat="server">
    党组织成员管理--所在党组织:< <span style="color:Red;font-weight:800"> <%=gsorgname %></span> >
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHPageTool" runat="server">
    <a href="javascript:void(0)" class="btn" id="A2" iconCls="icon-back" onclick="window.parent.closecurtab()">返回</a>
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
            <table id="listgrid" class="easyui-datagrid" title="成员列表" style="margin:2px auto;" data-options="singleSelect:false,fitColumns:true,idField:'FCommitteeID',rownumbers:true,pagination:true">
                <thead>
                    <tr>
						<th data-options="field:'FCommitteeID',align:'center',checkbox:true">选择</th>
						<th data-options="field:'FCommitteeName',width:60,align:'center'">成员姓名</th>
						<th data-options="field:'FCommitteePositionName',width:60,align:'center'">成员职务</th>
						<th data-options="field:'FCommitteeMobile',width:60,align:'center'">手机号码</th>
						<th data-options="field:'FCommitteeTel',width:60,align:'center'">办公电话</th>
						<th data-options="field:'FCommitteeOrder',width:60,align:'center'">显示顺序</th>
						<th data-options="field:'FOperation',width:80,align:'center'">操作</th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>
    <input type="hidden" id="hsortname" value="FCommitteeOrder" />
    <input type="hidden" id="hsortdirection" value="asc" />
    <input type="hidden" id="hpagenum" value="1" />
    <input type="hidden" id="hpagesize" value="10" />
    <div id="addwin" iconCls="icon-save" title="组织成员资料" style="text-align:center;display:none;">  
        <table style="width: 470px;margin:10px auto;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">            
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    成员姓名:
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                	<input type="hidden" id="hFCommitteeID" value="0" />
                    <input type="text" id="txtname" value="" style="width:180px;" />
   				</td>
 			</tr>
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    职务:
                </td>
                 <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                	<select id="selposition">
                        <option value="">==请选择相关职务==</option>
                        <option value="1">负责人</option>
                        <option value="2">书记</option>
                        <option value="3">专职副书记</option>
                        <option value="4">副书记</option>
                        <option value="5">委员</option>
                        <option value="6">联络员</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    手机号码:
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <input type="text" id="txtmobile" value="" style="width:230px;" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    办公电话:
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <input type="text" id="txttel" value="" style="width:230px;" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    显示顺序:
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <input type="text" id="txtorder" value="" style="width:230px;" />
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
            $("#hFCommitteeID").val("0");
            //other init control fill there
            $("#txtname").val("");
            $("#selposition").val("");
            $("#txtmobile").val("");
            $("#txttel").val("");
            $("#txtorder").val("10");
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
                        $("#hFCommitteeID").val(json.FCommitteeID);
                        //other controls fill here
                        $("#txtname").val(json.FCommitteeName);
                        $("#selposition").val(json.FCommitteePosition);
                        $("#txtmobile").val(json.FCommitteeMobile);
                        $("#txttel").val(json.FCommitteeTel);
                        $("#txtorder").val(json.FCommitteeOrder);
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
            var _FCommitteeID = $("#hFCommitteeID").val();
            //get data fill herevar
            var _name = $("#txtname").val();
            var _position = $("#selposition").val();
            var _mobile = $("#txtmobile").val();
            var _tel = $("#txttel").val();
            var _order = $("#txtorder").val();

            //judge data fill here
            if (!_name) {
                $.messager.alert("警告", "成员姓名不能为空!", "warning");
                return;
            }
            if (!_position) {
                $.messager.alert("警告", "成员职务不能为空!", "warning");
                return;
            }
            if (!_mobile) {
                $.messager.alert("警告", "移动电话不能为空!", "warning");
                return;
            }
            if (!_order) {
                $.messager.alert("警告", "显示顺序不能为空!", "warning");
                return;
            }
            else {
                if (!common.Validate.ValidateNumber(_order)) {
                    $.messager.alert("警告", "显示顺序输入格式不正确,请输入正整数!", "warning");
                    return;
                }
            }
            var options = {
                type: "POST",
                data: {
                    pFCommitteeID: _FCommitteeID,
                    pName: _name,
                    pPosition: _position,
                    pMobile: _mobile,
                    pTel: _tel,
                    pOrder : _order
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
            var idlist = GetGridData("listgrid", "FCommitteeID");
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
