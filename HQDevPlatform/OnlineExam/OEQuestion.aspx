<%@ Page Title="" Language="C#" MasterPageFile="~/WebContent.Master" AutoEventWireup="true" CodeBehind="OEQuestion.aspx.cs" Inherits="HQDevPlatform.OnlineExam.OEQuestion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.4.1-vsdoc.js" type="text/javascript"></script>
    <script src="../../jquery.min.js" type="text/javascript"></script>
    <script src="../../jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../../Js/common.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHPageName" runat="server">
    题目内容管理
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
            <div style="float:left;margin-left:3px;padding:0 5px;margin-top:-3px;">
                <input type="hidden" id="hsearchclassid" value= "" />
                <label id="lblsearchclassname" style="min-width:200px;border:1px solid #000;padding:2px 3px;">===请选择内容类别===</label>
                <a href="javascript:void(0)" class="btn" id="A2" iconCls="icon-search" onclick="searchcontentclass()"></a>
            </div>
            <div style="float:left;margin-left:10px;margin-top:3px;">
                <label for="txtsearch">题库选择</label>
            </div>
            <div style="float:left;margin-left:3px;padding:3px 5px;margin-top:-3px;">
                <select id="selquestionbank">
                    <option value="">===请选择题库===</option>
                </select>
            </div>
            <div style="float:left;margin:-3px 0 0 10px;">
                <a href="javascript:void(0)" class="btn1" id="A1" iconCls="icon-search" onclick="finddata()">查找</a>
                <a href="javascript:void(0)" class="btn1" id="A3" iconCls="icon-tip" onclick="advfilter()">高级过滤</a>
            </div>
        </div>
         <div style="width:98%;margin:0 auto;clear:both;">
            <table id="listgrid" class="easyui-datagrid" title="列表" style="margin:2px auto;" data-options="singleSelect:false,fitColumns:true,idField:'FQuestionId',rownumbers:true,pagination:true">
                <thead>
                    <tr>
						<th data-options="field:'FQuestionId',align:'center',checkbox:true">选择</th>
                        <th data-options="field:'FQuestionDisplayTitle',width:120,align:'left'">题目标题</th>
                        <th data-options="field:'FQuestionTypeName',width:60,align:'center'">题目类型</th>
                        <th data-options="field:'FQuestionDifficultyName',width:60,align:'center'">题目难易等级</th>
						<th data-options="field:'FQuestionDateTimeStr',width:80,align:'center'">题目创建时间</th>
						<th data-options="field:'AUserName',width:60,align:'center'">题目创建人姓名</th>
						<th data-options="field:'FQuestionStatusName',width:60,align:'center'">题目状态</th>
						<th data-options="field:'FOperation',width:80,align:'center'">操作</th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>
    <input type="hidden" id="hsortname" value="FQuestionId" />
    <input type="hidden" id="hsortdirection" value="asc" />
    <input type="hidden" id="hpagenum" value="1" />
    <input type="hidden" id="hpagesize" value="10" />
    <input type="hidden" id="hparentid" value="0" />
    <div id="contentclasswin" iconCls="icon-save" title="内容类别选择" style="display:none;text-align:center;">
        <table id="treetable">
        </table>
    </div>
    <div id="advfilterwin" iconCls="icon-sum" title="高级过滤" style="display:none;text-align:center;">
        <table style="width: 470px;margin:10px auto;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">            
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    题目标题
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <input type="text" id="txtquestiontitle" value="" style="width:300px;" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    题目类型
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <select id="selfiltertype" />
                        <option value="">所有类型</option>
                        <option value="0">判断题</option>
                        <option value="1">单项选择题</option>
                        <option value="2">多项选择题</option>
                        <option value="3">填空题</option>
                        <option value="4">综合应用题</option>
                    </select>
                </td>
            </tr>
             <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    题目难易程度
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <select id="selfilterdifficulty"/>
                        <option value="">所有难度</option>
                        <option value="0">低</option>
                        <option value="1">中</option>
                        <option value="2">高</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    关键字
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <input type="text" id="txtkeyword" value="" style="width:300px;" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    考查点说明
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <input type="text" id="txtdesc" value="" style="width:300px;" />
                </td>
            </tr>
        </table>
        <div style="margin:20px auto;">
            <a href="#" class="btn1" id="A4" iconCls="icon-save" onclick="closewin4()">过滤</a>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="CPHJavascript" runat="server">
	<script type="text/javascript">
	    function setitem(id) {
	        window.parent.addtab("设置题目答案", "OE000103003", "OEQuestionItemSet.aspx?qid=" + id);
	    }

	    function status(id, flag) {
	        $.messager.progress();
            var options = {
	            type: "POST",
	            data: { pid: id, pflag: flag },
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

	    function edit(id) {
	        window.parent.addtab("编辑题目", "OE000103002", "OEQuestionEdit.aspx?qid=" + id );
	    }

	    function finddata() {
	        $("#txtquestiontitle").val("");
	        $("#selfiltertype").val("");
	        $("#selfilterdifficulty").val("");
	        $("#txtkeyword").val("");
	        $("#txtdesc").val("");
	        loadgriddata();
	    }

        function closewin4() {
	        $("#advfilterwin").window('close');
	    }
        
        function advfilter() {
	        var _qbankid = $("#selquestionbank").val();
	        if (!_qbankid || _qbankid == "0") {
	            $.messager.alert("警告", "请首先选择所属题库!", "warning");
	            return;
	        }
            openwin("advfilterwin", 500, 400, true, "loadgriddata");
	    }

        function loadgriddata() {
            var _contentclassid = $("#hsearchclassid").val();
            var _qbankid = $("#selquestionbank").val();
            if (!_contentclassid || _contentclassid == "0") {
                return;
            }
            if (!_qbankid || _qbankid == "0") {
                return;
            }
	        var _searchcontent = $("#txtsearch").val();
	        var _sortname = $("#hsortname").val();
	        var _sortdirection = $("#hsortdirection").val();
	        var _pagenumber = $("#hpagenum").val();
	        var _pagesize = $("#hpagesize").val();
	        var _tilte = $("#txtquestiontitle").val();
	        var _type = $("#selfiltertype").val();
	        var _diffculty = $("#selfilterdifficulty").val();
	        var _keyword = $("#txtkeyword").val();
	        var _desc = $("#txtdesc").val();
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
                    pcontentclassid: _contentclassid,
                    pqbankid: _qbankid,
                    ptitle: _tilte,
                    ptype:_type,
                    pdifficulty:_diffculty,
                    pkeyword:_keyword,
                    pdesc:_desc
	            },
	            success: function (res) {
	                var json = common.Util.StringToJson(res);
	                $.messager.progress('close');
	                loadgrid("listgrid", json);
	            }
	        };
	        common.Ajax("GetGridData", options);
	    }

	    function nullreturn() {

	    }

	    function loadquestionbank() {
	        var _classid = $("#hsearchclassid").val();
	        var options = {
	            type: "POST",
	            data: { pclassid: _classid },
	            success: function (res) {
	                var json = common.Util.StringToJson(res);
	                $("#selquestionbank").empty();
	                $("#selquestionbank").append("<option value=''>===请选择题库===</option>");
	                common.DropDownList.Load("selquestionbank", json, "FDisplayQBankName", "FQBankId");
	            }
	        };
	        common.Ajax("GetQuestionBank", options);
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

	    function closewin3() {
	        $("#contentclasswin").window('close');
	    }

	    function searchcontentclass() {
	        openwin("contentclasswin", 450, 400, true, "loadquestionbank");
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
	        window.parent.addtab("新增题目", "OE000103001", "OEQuestionAdd.aspx");
	    }

	    function del() {
	        var idlist = GetGridData("listgrid", "FQuestionId");
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

	    
        
    </script>    
</asp:Content>
