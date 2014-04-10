<%@ Page Title="" Language="C#" MasterPageFile="~/WebContent.Master" AutoEventWireup="true" CodeBehind="deptmanage.aspx.cs" Inherits="HQDevPlatform.manage.department.deptmanage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../jquery.min.js" type="text/javascript"></script>
    <script src="../../jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../../Js/common.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHPageName" runat="server">
    部门管理
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHPageTool" runat="server">
    <a href="javascript:void(0)" class="btn" id="btnadd" iconCls="icon-add" onclick="adddept()">新增部门</a>
    <a href="javascript:void(0)" class="btn" id="btndel" iconCls="icon-remove" onclick="deldept()">删除部门</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPHContent" runat="server">
    <div style="width:100%;margin:0 auto;">
        <div style="height:24px;clear:both;margin-top:0;padding:0;">
            <div style="float:left;margin-left:10px;margin-top:3px;">
                <label for="txtsearch">部门名称搜索</label>
            </div>
            <div style="float:left;margin-left:10px;">
                <input type="text" id="txtsearch" value="" style="width:150px;" />
            </div>
            <div style="float:left;margin:-2px 0 0 10px;">
                <a href="javascript:void(0)" class="btn1" id="A1" iconCls="icon-search" onclick="searchlanmu()">查找部门</a>
            </div>
        </div>
        <div style="width:98%;margin:0 auto;clear:both;">
            <table id="articlelistgrid" class="easyui-datagrid" title="部门列表" style="margin:2px auto;" data-options="singleSelect:false,fitColumns:true,idField:'FDepartmentID',rownumbers:true,pagination:true">
                <thead>
                    <tr>
                        <th data-options="field:'FDepartmentID',align:'center',checkbox:true">选择</th>
                        <th data-options="field:'FDepartmentCode',width:60,align:'center'">部门编号</th>
                        <th data-options="field:'FDepartmentTypeName',width:80,align:'center'">部门归属</th>   
                        <th data-options="field:'FDepartmentName',width:100,align:'center'">部门编号</th>
                        <th data-options="field:'FDepartmentCharge',width:60,align:'center'">部门负责人</th>
                        <th data-options="field:'FDepartmentNum',width:60,align:'center'">部门人数</th>
                        <th data-options="field:'FDepartmentTel',width:100,align:'center'">联系电话</th>
                        <th data-options="field:'FOperation',width:80,align:'center'">操作</th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>
    <input type="hidden" id="hsortname" value="FDepartmentCode" />
    <input type="hidden" id="hsortdirection" value="asc" />
    <input type="hidden" id="hpagenum" value="1" />
    <input type="hidden" id="hpagesize" value="10" />
    <input type="hidden" id="hparentid" value="0" />
    <!-- 新增窗口 Begin-->
    <div id="addwin" iconCls="icon-save" title="部门资料" style="text-align:center;display:none;">  
        <table style="width: 470px;margin:10px auto;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">            
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    部门编号：
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <input type="hidden" id="hdeptid" value="0" />
                    <input type="text" id="txtdeptcode" style="width:100px;" />
                </td>
            </tr>
             <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    管理归属：
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <select id="seldepttype"></select>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    部门名称：
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <input type="text" id="txtdeptname" style="width:200px;" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    部门负责人：
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <input type="text" id="txtdeptcharge" style="width:200px;" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    联系电话：
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <input type="text" id="txtdepttel" style="width:200px;" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    部门人数：
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <input type="text" id="txtdeptnum" style="width:200px;" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    备注：
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <textarea id="txtcontent" rows="5" cols="30"></textarea>
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
        function editdept(id) {
            var options = {
                type: "POST",
                data: { pid: id },
                success: function (res) {
                    if (res) {
                        var json = common.Util.StringToJson(res);
                        $("#hdeptid").val(json.FDepartmentID);
                        $("#txtdeptcode").val(json.FDepartmentCode);
                        $("#seldepttype").val(json.FDepartmentTypeId);
                        $("#txtdeptname").val(json.FDepartmentName);
                        $("#txtdeptcharge").val(json.FDepartmentCharge);
                        $("#txtdepttel").val(json.FDepartmentTel);
                        $("#txtcontent").val(json.FDepartmentContent);
                        $("#txtdeptnum").val(json.FDepartmentNum);
                        openwin("addwin", 500, 400, true, "loadgriddata");
                    }
                    else {
                        $.messager.alert("警告", "无法获取数据,请刷新后重试!", 'warning');
                        return;
                    }
                }
            };
            common.Ajax("GetDeptItem", options);
        }
        
        function deldept() {
            var idlist = GetGridData("articlelistgrid", "FDepartmentID");
            if (!idlist) {
                $.messager.alert('警告', '请选择相关要删除的数据!', 'warning');
                return;
            }
            $.messager.confirm('确认', '您是否确定要删除选中的部门吗?', function (r) {
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
                    common.Ajax("DelDepartment", options);
                }
            });
        }
        
        function save() {
            var _deptid = $("#hdeptid").val();
            var _deptcode = $("#txtdeptcode").val();
            var _depttype = $("#seldepttype").val();
            var _deptname = $("#txtdeptname").val();
            var _deptcharge = $("#txtdeptcharge").val();
            var _depttel = $("#txtdepttel").val();
            var _deptnum = $("#txtdeptnum").val();
            var _content = $("#txtcontent").val();
            if (!_deptcode) {
                $.messager.alert('警告', '部门编号不能为空!', 'warning');
                return;
            }
            if (!_deptname) {
                $.messager.alert('警告', '部门名称不能为空!', 'warning');
                return;
            }
            if (!_depttype) {
                $.messager.alert('警告', '部门归属不能为空!', 'warning');
                return;
            }
            if (!common.Validate.ValidateNumber(_deptnum)) {
                $.messager.alert('警告', "部门人数输入格式不正确,请输入正整数!", 'warning');
                return;
            }
            var options = {
                type: "POST",
                data: {
                    pdeptid: _deptid,
                    pdeptcode: _deptcode,
                    pdepttype: _depttype,
                    pdeptname: _deptname,
                    pdeptcharge: _deptcharge,
                    pdepttel: _depttel,
                    pdeptnum: _deptnum,
                    pcontent: _content
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
        
        function searchlanmu() {
            loadgriddata();
        }

        function closewin() {
            $("#addwin").window("close");
        }

        function adddept() {
            initdept();
            openwin("addwin", 500, 400, true, "loadgriddata");
        }

        function initdept() {
            $("#hdeptid").val("0");
            $("#txtdeptcode").val("");
            $("#seldepttype").val("");
            $("#txtdeptname").val("");
            $("#txtdeptcharge").val("");
            $("#txtdepttel").val("");
            $("#txtcontent").val("");
            $("#txtdeptnum").val("1");
        }

        $(function () {
            $('.btn').linkbutton({ plain: true });
            $('.btn1').linkbutton();
            formatgrid("articlelistgrid", "loadgriddata", "hpagenum", "hpagesize", "hsortname", "hsortdirection");
            loadgriddata();
            var moduledata = common.Data.GetDatasource("typelist");
            $("#seldepttype").empty();
            $("#seldepttype").append("<option value=''>==选择所属部门归属==</option>");
            common.DropDownList.Load("seldepttype", moduledata, "FDepartmentTypeName", "FDepartmentTypeId");
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
                    ppagesize: _pagesize
                },
                success: function (res) {
                    var json = common.Util.StringToJson(res);
                    $.messager.progress('close');
                    loadgrid("articlelistgrid", json);
                }
            };
            common.Ajax("GetGridData", options);
        }
    </script>
</asp:Content>
