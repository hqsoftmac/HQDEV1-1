<%@ Page Title="" Language="C#" MasterPageFile="~/WebContent.Master" AutoEventWireup="true" CodeBehind="QuestionBank.aspx.cs" Inherits="HQDevPlatform.OnlineExam.QuestionBank" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="../../themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../jquery.min.js" type="text/javascript"></script>
    <script src="../../jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../../Js/common.js" type="text/javascript"></script>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHPageName" runat="server">
    题库字典管理
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHPageTool" runat="server">
 <a href="javascript:void(0)" class="btn" id="btnadd" iconCls="icon-add" onclick="add()">新增</a>
    <a href="javascript:void(0)" class="btn" id="btndel" iconCls="icon-remove" onclick="del()">删除</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPHContent" runat="server">
    <div style="width:100%;margin:0 auto;">
	    <div style="height:24px;clear:both;margin-top:0;padding:0;">
		    <div style="float:left;margin-left:10px;margin-top:3px;">
                <label for="txtsearch">内容类别选择</label>
            </div>
            <div style="float:left;margin-left:10px;border:1px solid #000;padding:0 5px;margin-top:-3px;">
                <input type="hidden" id="hsearchclassid" value= "" />
                <label id="lblsearchclassname" style="min-width:200px;">===请选择题库===</label>
                <a href="javascript:void(0)" class="btn" id="A2" iconCls="icon-search" onclick="searchcontentclass()"></a>
            </div>
            <div style="float:left;margin-left:10px;margin-top:3px;">
                <label for="txtsearch">题库名称</label>
            </div>
            <div style="float:left;margin-left:10px;margin-top:-3px;">
                <input type="text" id="txtsearch" value="" style="width:250px;height:22px;" />
            </div>
            <div style="float:left;margin:-2px 0 0 10px;">
                <a href="javascript:void(0)" class="btn1" id="A1" iconCls="icon-search" onclick="loadgriddata()">查询</a>
            </div>
        </div>
         <div style="width:98%;margin:0 auto;clear:both;margin-top:5px;">
            <table id="listgrid" class="easyui-datagrid" title="列表" style="margin:2px auto;" data-options="singleSelect:false,fitColumns:true,idField:'FQBankId',rownumbers:true,pagination:true">
                <thead>
                    <tr>
						<th data-options="field:'FQBankId',align:'center',checkbox:true">选择</th>
						<th data-options="field:'FQBankCode',width:60,align:'center'">题库编号</th>
						<th data-options="field:'FQBankName',width:100,align:'center'">题库名称</th>
						<th data-options="field:'FQBankStatusName',width:60,align:'center'">题库状态</th>
						<th data-options="field:'FQBankContent',width:120,align:'center'">题库说明</th>
						<th data-options="field:'FOperation',width:60,align:'center'">操作</th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>
    <input type="hidden" id="hsortname" value="FQBankCode" />
    <input type="hidden" id="hsortdirection" value="asc" />
    <input type="hidden" id="hpagenum" value="1" />
    <input type="hidden" id="hpagesize" value="10" />
    <input type="hidden" id="hparentid" value="0" />
    <div id="addwin" iconCls="icon-save" title="题库字典管理" style="text-align:center;display:none;">  
        <table style="width: 470px;margin:10px auto;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">            
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    题库编号
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <input type="hidden" id="hFQBankId" value="0" />
                    <input type="text" id="txtFQBankCode" value="" style="width:200px;" />
   			    </td>
 		    </tr>
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    所属内容类别
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <input type="text" id="txtFContentClassName" value="" style="width:250px;" readonly />
                    <input type="hidden" id="hFContentClassId" value="" />
                    <a href="javascript:void(0)" class="btn" id="A3" iconCls="icon-search" onclick="selectcontentclass()"></a>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    题库名称
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <input type="text" id="txtFQBankName" value="" style="width:300px;" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    题库说明
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <textarea id="txtFQBankContent" rows="10" cols="50" style="width:300px;height:100px;"></textarea>
                </td>
            </tr>

		</table>
		<div style="margin:20px auto;">
            <a href="#" class="btn1" id="btnsave" iconCls="icon-save" onclick="save()">保存</a>&nbsp;&nbsp;
            <a href="#" class="btn1" id="btnclose" iconCls="icon-cancel" onclick="closewin()" >取消</a>
        </div>
    </div>

    <div id="contentclasswin" iconCls="icon-save" title="内容类别选择" style="display:none;text-align:center;">
        <table id="treetable">
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="CPHJavascript" runat="server">
<script type="text/javascript">
    function bankstatus(_id,_status) {
        var str = "您确定要暂停使用该题库吗?";
        if (_status == "1") {
            str = "您确定要启用该题库吗?";
        }
        $.messager.confirm('确认', str, function (r) {
            if (!r) {
                return;
            }
            else {
                $.messager.progress();
                var options = {
                    type: "POST",
                    data: { pid: _id,pstatus:_status },
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
                common.Ajax("UpdateStatus", options);
            }
        });
    }

    function save() {
        var _FQBankId = $("#hFQBankId").val();
        //get data fill here
        var _FContentClassId = $("#hFContentClassId").val();
        var _FQBankCode = $("#txtFQBankCode").val();
        var _FQBankName = $("#txtFQBankName").val();
        var _FQBankContent = $("#txtFQBankContent").val();

        //judge data fill here
        if (!_FQBankCode) {
            $.messager.alert("警告", "题库编号不能为空!", "warning");
            return;
        }
        if (!_FQBankName) {
            $.messager.alert("警告", "题库名称不能为空!", "warning");
            return;
        }
        if (!_FContentClassId || _FContentClassId == "0") {
            $.messager.alert("警告", "请选择内容类别,内容类别不能为空!", "warning");
            return;
        }
        var options = {
            type: "POST",
            data: {
                pFQBankId: _FQBankId,
                pFContentClassId: _FContentClassId,
                FQBankCode: _FQBankCode,
                pFQBankName: _FQBankName,
                pFQBankContent: _FQBankContent
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

    function edit(id) {
        var options = {
            type: "POST",
            data: { pid: id },
            success: function (res) {
                if (res) {
                    var json = common.Util.StringToJson(res);
                    $("#hFQBankId").val(json.FQBankId);
                    //other controls fill here
                    $("#hFContentClassId").val(json.FContentClassId);
                    $("#txtFContentClassName").val("[" + json.FContentClassCode + "]" + json.FContentClassName);
                    $("#txtFQBankCode").val(json.FQBankCode);
                    $("#txtFQBankName").val(json.FQBankName);
                    $("#txtFQBankContent").val(json.FQBankContent);
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

    function initwin() {
        $("#hFQBankId").val("0");
        //other init control fill there
        $("#hFContentClassId").val("");
        $("#txtFContentClassName").val("");
        $("#txtFQBankCode").val("");
        $("#txtFQBankName").val("");
        $("#txtFQBankContent").val("");
    }
    
    function selectcontentclass() {
        openwin("contentclasswin", 450, 400, true, "rtn");
        $("#treetable").treegrid({
            rownumbers: true,
            singleSelect: true,
            idField: 'FContentClassId',
            treeField: 'FContentClassCode',
            loadMsg: '数据加载中请稍后……',
            animate: true,
            height: 364,
            columns: [[{ field: 'FContentClassId', title: '选择', width: 80, checkbox: true, align: 'center' },
                            { field: 'FContentClassCode', title: '内容类别编号', width: 150 },
                            { field: 'FContentClassName', title: '内容类别名称', width: 150 }
	                    ]],
            toolbar: [{ text: '选择', iconCls: 'icon-ok', handler: function () { choosecontentclass1(); } }, { text: '取消', iconCls: 'icon-cancel', handler: function () { closewin3(); } }]
        });
        loadcontentclass();
    }
    
    function closewin3() {
        $("#contentclasswin").window('close');
    }

    function rtn() {

    }

    function searchcontentclass() {
        openwin("contentclasswin", 450, 400, true, "loadgriddata");
        $("#treetable").treegrid({
            rownumbers: true,
            singleSelect: true,
            idField: 'FContentClassId',
            treeField: 'FContentClassCode',
            loadMsg: '数据加载中请稍后……',
            animate: true,
            height: 364,
            columns: [[{ field: 'FContentClassId', title: '选择', width: 80, checkbox: true, align: 'center' },
                            { field: 'FContentClassCode', title: '内容类别编号', width: 150 },
                            { field: 'FContentClassName', title: '内容类别名称', width: 150 }
	                    ]],
            toolbar: [{ text: '选择', iconCls: 'icon-ok', handler: function () { choosecontentclass(); } }, { text: '取消', iconCls: 'icon-cancel', handler: function () { closewin3(); } }]
        });
        loadcontentclass();
    }

    function choosecontentclass1() {
        var row = $("#treetable").treegrid('getSelected');
        if (!row || row.length == 0) {
            $.messager.alert('提示', '请选择相关内容类别!', 'info');
            return;
        }
        var crow = $("#treetable").treegrid('getChildren', row.FContentClassId);
        if (crow.length > 0) {
            $.messager.alert('提示', '请选择最末级内容类别!', 'info');
            return;
        }
        $("#hFContentClassId").val(row.FContentClassId);
        $("#txtFContentClassName").val("[" + row.FContentClassCode + "]" + row.FContentClassName);
        closewin3();
    }

    function choosecontentclass() {
        var row = $("#treetable").treegrid('getSelected');
        if (!row || row.length == 0) {
            $.messager.alert('提示', '请选择相关内容类别!', 'info');
            return;
        }
        $("#hsearchclassid").val(row.FContentClassId);
        $("#lblsearchclassname").html("[" + row.FContentClassCode + "]" + row.FContentClassName);
        closewin3();
    }

    function loadcontentclass() {
        var options = {
            type: "POST",
            data: { pid: "1" },
            success: function (res) {
                var json = common.Util.StringToJson(res);
                $('#treetable').treegrid('loadData', json);
            }
        };
        common.Ajax("GetContentClassTree", options);
    }

    function closewin() {
        $("#addwin").window('close');
    }

    

    function add() {
        initwin();
        openwin("addwin", 500, 400, true, "loadgriddata");
    }

    function del() {
        var idlist = GetGridData("listgrid", "FQBankId");
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
    });

    function loadgriddata() {
        var _searchcontent = $("#txtsearch").val();
        var _sortname = $("#hsortname").val();
        var _sortdirection = $("#hsortdirection").val();
        var _pagenumber = $("#hpagenum").val();
        var _pagesize = $("#hpagesize").val();
        var _searchclassid = $("#hsearchclassid").val();
        if (!_searchclassid || _searchclassid == "0") {
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
                psearchclassid: _searchclassid
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
