<%@ Page Title="" Language="C#" MasterPageFile="~/WebContent.Master" AutoEventWireup="true" CodeBehind="OEExamPaperAdd.aspx.cs" Inherits="HQDevPlatform.OnlineExam.OEExamPaperAdd" %>
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
    新增考试试卷
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHPageTool" runat="server">
    
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPHContent" runat="server">
    <div id="contentclasswin" iconCls="icon-save" title="内容类别选择" style="display:none;text-align:center;">
        <table id="treetable">
        </table>
    </div>

    <div id="tt" class="easyui-tabs">  
        <div title="试卷基本设定" style="padding:5px;">
            <table style="width:100%;margin:0px auto;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">            
                <tr>
                    <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                        试卷名称：
                    </td>
                    <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                        <input type="hidden" id="hpagerid" value="0" />
                        <input type="text" id="txtpagername" value="" style="width:400px;" />
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                        所属内容类别：
                    </td>
                    <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                        <input type="text" id="txtFContentClassName" value="" style="width:250px;" readonly />
                        <input type="hidden" id="hFContentClassId" value="" />
                        <a href="javascript:void(0)" class="btn" id="A3" iconCls="icon-search" onclick="selectcontentclass()"></a>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                        试卷总分：
                    </td>
                    <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                        <input type="text" id="txtpapertotal" value="100" style="width:60px;" />
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                        通过分数：
                    </td>
                    <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                        <input type="text" id="txtpassscore" value="60" style="width:60px;" />
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                        试卷模式：
                    </td>
                    <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                        <select id="selexamtype">
                            <option value="0">离线模式</option>
                            <option value="1" selected>在线模式</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                        抽题模式：
                    </td>
                    <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                        <select id="selextractway">
                            <option value="0">随机</option>
                            <option value="1">固定</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                        答案显示顺序：
                    </td>
                    <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                        <select id="selchooseitemway">
                            <option value="0">随机</option>
                            <option value="1">固定</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                        补考设置：
                    </td>
                    <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                        <select id="selexamagain">
                            <option value="1">允许</option>
                            <option value="0">禁止</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                        考试时间：
                    </td>
                    <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                        <input type="text" id="txtexamtime" value="120" style="width:60px;" />&nbsp;&nbsp;分钟
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                        试卷说明：
                    </td>
                    <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                       <textarea id="txtpapercontent" style="width:98%;height:130px;"></textarea> 
                    </td>
                </tr>
            </table>
            <div style="margin:20px auto;width:100%;text-align:center;">
                <a href="#" class="btn1" id="btnsave" iconCls="icon-save" onclick="save1()">下一步</a>&nbsp;&nbsp;
                <a href="#" class="btn1" id="btnclose" iconCls="icon-undo" onclick="closewin()" >取消</a>
            </div>
        </div>
        <div title="试卷题型设定" style="padding:5px;">
            <table style="width:100%;margin:0px auto;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">            
                <tr>
                    <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                        备选题库
                    </td>
                    <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                        <table id="questionbankgrid" class="easyui-datagrid" style="margin:10px auto;" data-options="singleSelect:true,fitColumns:true,idField:'FQBankId',rownumbers:true,toolbar: [{ text: '新增', iconCls: 'icon-add', handler: function () { addqbank(); } }, { text: '删除', iconCls: 'icon-cancel', handler: function () { delqbank(); } }]">
                            <thead>
                                <tr>
						            <th data-options="field:'FQBankId',align:'center',checkbox:true">选择</th>
                                    <th data-options="field:'FQBankName',width:200,align:'left'">题库名称</th>
                                    <th data-options="field:'FQBnakRate',width:60,align:'center'">抽题占比(%)</th>
                                    <th data-options="field:'FOperation',width:60,align:'center'">操作</th>
                                </tr>
                            </thead>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                        题型设定
                    </td>
                    <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                        <table id="questiontypegrid" class="easyui-datagrid" style="margin:10px auto;" data-options="singleSelect:true,fitColumns:true,idField:'FQuestionType',rownumbers:true,toolbar: [{ text: '新增', iconCls: 'icon-add', handler: function () { addqtype(); } }, { text: '删除', iconCls: 'icon-cancel', handler: function () { delqtype(); } }]">
                            <thead>
                                <tr>
						            <th data-options="field:'FQuestionType',align:'center',checkbox:true">选择</th>
                                    <th data-options="field:'FQuestionTypeName',width:200,align:'left'">题目类型</th>
                                    <th data-options="field:'FQuestionNum',width:60,align:'center'">题目数量</th>
                                    <th data-options="field:'FQuestionScore',width:60,align:'center'">单题分值</th>
                                    <th data-options="field:'FQuestionTotal',width:60,align:'center'">题型总分</th>
                                </tr>
                            </thead>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                        难度设定
                    </td>
                    <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                        <table id="difficultygrid" class="easyui-datagrid" style="margin:10px auto;" data-options="singleSelect:true,fitColumns:true,idField:'FDifficulty',rownumbers:true,toolbar: [{ text: '新增', iconCls: 'icon-add', handler: function () { adddifficulty(); } }, { text: '删除', iconCls: 'icon-cancel', handler: function () { deldifficulty(); } }]">
                            <thead>
                                <tr>
						            <th data-options="field:'FDifficulty',align:'center',checkbox:true">选择</th>
                                    <th data-options="field:'FDifficultyName',width:200,align:'left'">难度等级</th>
                                    <th data-options="field:'FRate',width:60,align:'center'">抽题占比(%)</th>
                                </tr>
                            </thead>
                        </table>
                    </td>
                </tr>
            </table>
            <div style="margin:5px auto;width:100%;text-align:center;">
                <a href="#" class="btn1" id="A1" iconCls="icon-undo" onclick="next(0)">上一步</a>&nbsp;&nbsp;
                <a href="#" class="btn1" id="A2" iconCls="icon-save" onclick="save2()" >下一步</a>
            </div>
        </div>
    </div>
    <div id="qbankwin" iconCls="icon-save" title="内容类别选择" style="text-align:center;">
        <table id="qbankgrid" class="easyui-datagrid" style="margin:2px auto;" data-options="singleSelect:false,fitColumns:true,idField:'FQBankId',rownumbers:true,toolbar: [{ text: '选择', iconCls: 'icon-add', handler: function () { chooseqbank(); } }, { text: '取消', iconCls: 'icon-cancel', handler: function () { $('#qbankwin').window('close'); } }]">
            <thead>
                <tr>
					<th data-options="field:'FQBankId',align:'center',checkbox:true">选择</th>
					<th data-options="field:'FQBankCode',align:'center'">题库编号</th>
					<th data-options="field:'FQBankName',align:'center'">题库名称</th>
                </tr>
            </thead>
        </table>
    </div>
    <div id="ratewin" iconCls="icon-save" title="题库题数占总题数比例" style="text-align:center;display:none;">
        <table style="width:80%;margin:20px auto;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1"> 
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    题目数量占比:
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <input type="hidden" id="hratebankid" value="0" />
                    <input type="text" id="txtrate" value="" style="width:60px;" />
                </td>
            </tr>
        </table>
        <div style="margin:5px auto;width:100%;text-align:center;">
            <a href="#" class="btn1" id="A4" iconCls="icon-save" onclick="saverate()">确定</a>&nbsp;&nbsp;
            <a href="#" class="btn1" id="A5" iconCls="icon-cancel" onclick="$('#ratewin').window('close');" >取消</a>
        </div>
    </div>
    <div id="typewin" iconCls="icon-save" title="题型设定" style="text-align:center;display:none;">
        <table style="width:80%;margin:20px auto;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1"> 
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    题型
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <select id="selquestiontype" onchange="loadquestiontypenum()">
                        <option value="">==选择题目类型==</option>
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
                    题库已有题目数量
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <label id="havequestionnum"></label>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    题目数量
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <input type="text" id="txtquestionnum" value="0" style="width:60px;" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    单题分值
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <input type="text" id="txtquestionval" value="0" style="width:60px;" />
                </td>
            </tr>
        </table>
        <div style="margin:5px auto;width:100%;text-align:center;">
            <a href="#" class="btn1" id="A6" iconCls="icon-save" onclick="savetype()">确定</a>&nbsp;&nbsp;
            <a href="#" class="btn1" id="A7" iconCls="icon-cancel" onclick="$('#typewin').window('close');" >取消</a>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="CPHJavascript" runat="server">
    <script type="text/javascript">
        function delqtype() {
            var rows = $('#questiontypegrid').datagrid('getSelections');
            if (!rows || rows.length == 0) {
                return "";
            }
            $.messager.confirm('确认', '您是否确定要删除选中的题型设定吗?', function (r) {
                if (!r) {
                    return;
                }
                else {
                    $.each(rows, function (i, n) {
                        var _index = $("#questiontypegrid").datagrid('getRowIndex', n.FQuestionType);
                        $("#questiontypegrid").datagrid('deleteRow', _index);
                    });
                }
            });
        }

        function save2() {
            var _paperid = $("#hpagerid").val();
            var rows = $("#questionbankgrid").datagrid('getRows');
            var _banklist = "";
            var _ratelist = "";
            if (!rows || rows.length == 0) {
                $.messager.alert("警告", "备选题库尚未设定!", "warning");
                return;
            }
            $.each(rows, function (i, n) {
                if (i == 0) {
                    _banklist += n.FQBankId;
                    _ratelist += n.FQBnakRate;
                } else {
                    _banklist += ',' + n.FQBankId;
                    _ratelist += ',' + n.FQBnakRate;
                }
            });
            var _typelist = "";
            var _numlist = "";
            var _scorelist = "";
            var typerows = $("#questiontypegrid").datagrid('getRows');
            if (!typerows || typerows.length == 0) {
                $.messager.alert("警告", "试卷题型尚未设定!", "warning");
                return;
            }
            $.each(typerows, function (i, n) {
                if (i == 0) {
                    _typelist += n.FQuestionType;
                    _numlist += n.FQuestionNum;
                    _scorelist += n.FQuestionScore;
                } else {
                    _typelist += ',' + n.FQuestionType;
                    _numlist += ',' + n.FQuestionNum;
                    _scorelist += ',' + n.FQuestionScore;
                }
            });
            $.messager.progress();
            var options = {
                type: "POST",
                data: { pbanklist: _banklist, pratelist: _ratelist, ptypelist: _typelist, pnumlist: _numlist, pscorelist: _scorelist, ppaperid: _paperid },
                success: function (res) {
                    $.messager.progress('close');
                    var json = common.Util.StringToJson(res);
                    if (json.ErrorCode == common.Consts.SuccessCode) {
                        alert('保存成功!');
                        //next(2);
                    }
                    else {
                        $.messager.alert('警告', json.ErrorMessage, 'warning');
                        return;
                    }
                }
            };
            common.Ajax("SaveInfo2", options);
        }

        function loadquestiontypenum() {
            var _type = $("#selquestiontype").val();
            var rows = $("#questionbankgrid").datagrid('getRows');
            var parm = "";
            $.each(rows, function (i, n) {
                if (i == 0) {
                    parm += n.FQBankId;
                } else {
                    parm += ',' + n.FQBankId;
                }
            });
            var options = {
                type: "POST",
                data: { ptype: _type, pidlist: parm },
                success: function (res) {
                    $("#havequestionnum").html(res);
                }
            };
            common.Ajax("GetQTypeCount", options);
        }

        function savetype() {
            var _type = $("#selquestiontype").val();
            var _typename = "";
            switch (_type) {
                case "0":
                    _typename = "判断题";
                    break;
                case "1":
                    _typename = "单项选择题";
                    break;
                case "2":
                    _typename = "多项选择题";
                    break;
                case "3":
                    _typename = "填空题";
                    break;
                case "4":
                    _typename = "综合应用题";
                    break;
                default:
                    _typename = "未知";
                    break;
            }
            var _questionnum = $("#txtquestionnum").val();
            var _questionval = $("#txtquestionval").val();
            if (!_questionval) {
                $.messager.alert('警告', '单题分值不能为空!', 'warning');
                return;
            }
            if (!_questionnum) {
                $.messager.alert('警告', '题目数量不能为空!', 'warning');
                return;
            }
            var _haveqnum = $("#havequestionnum").html();
            if (_haveqnum > 0) {
                if (_questionnum > _haveqnum) {
                    $.messager.alert("警告", "设置该题型的条数已经超过了备选题库中存在的数量!", "warning");
                    return;
                }
            }
            else {
                $.messager.alert("警告", "备选题库中不存在该题型!", "warning");
                return;
            }
            //判断是否已经存在于已选择的列表中
            $("#questiontypegrid").datagrid('clearSelections');
            $("#questiontypegrid").datagrid('selectRecord', _type);
            var selrow = $("#questiontypegrid").datagrid('getSelected');
            if (!selrow || selrow.length == 0) {
                var _total = _questionnum * _questionval;
                var datarow = { FQuestionType: _type, FQuestionTypeName: _typename, FQuestionNum: _questionnum, FQuestionScore: _questionval, FQuestionTotal: _total };
                $("#questiontypegrid").datagrid("appendRow", datarow);
                $('#typewin').window('close');
            }
            else {
                $.messager.alert("警告", _typename + "已经存在,无法新增!", "warning");
                return;
            }
        }
        
        function addqtype() {
            var _paperid = $("#hpagerid").val();
            if (!_paperid || _paperid == '0') {
                $.messager.alert('警告', '试卷基本信息尚未设定,无法进行题型设定', 'warning');
                return;
            }
            var _int = $("#questionbankgrid").datagrid('getRows');
            if (!_int) {
                $.messager.alert('警告', '备选题库尚未设定,无法进行题型设定', 'warning');
                return;
            }
            openwin("typewin", 400, 300, true, "loadmanqbank");
            
        }
        
        function delqbank() {
            var rows = $('#questionbankgrid').datagrid('getSelections');
            if (!rows || rows.length == 0) {
                return "";
            }
            $.messager.confirm('确认', '您是否确定要删除选中的题库设定吗?', function (r) {
                if (!r) {
                    return;
                }
                else {
                    $.each(rows, function (i, n) {
                        var _index = $("#questionbankgrid").datagrid('getRowIndex', n.FQBankId);
                        $("#questionbankgrid").datagrid('deleteRow', _index);
                    });
                }
            });
        }
        
        function saverate() {
            var id = $("#hratebankid").val();
            var rate = $("#txtrate").val();
            var _index = $("#questionbankgrid").datagrid('getRowIndex', id);
            $("#questionbankgrid").datagrid('clearSelections');
            $("#questionbankgrid").datagrid('selectRecord', id);
            var row = $("#questionbankgrid").datagrid('getSelected');
            var newdata = { FQBankRate: rate};
            row.FQBnakRate = rate;
            $("#questionbankgrid").datagrid('updateRow', { index: _index, row: newdata });
            $('#ratewin').window('close');
        }

        function setrate(id) {
            $("#questionbankgrid").datagrid('clearSelections');
            $("#questionbankgrid").datagrid('selectRecord', id);
            $("#hratebankid").val(id);
            var row = $("#questionbankgrid").datagrid('getSelected');
            openwin("ratewin", 400, 200, true, "loadmanqbank");
            $("#txtrate").val(row.FQBnakRate);
        }

        function chooseqbank() {
            var rows = $('#qbankgrid').datagrid('getSelections');
            if (!rows || rows.length == 0) {
                $.messager.alert('警告', '请选择相关题库!', 'warning');
                return;
            }
            $.each(rows, function (i, n) {
                var _bankid = n.FQBankId;
                //判断是否已经存在于已选择的列表中
                $("#questionbankgrid").datagrid('clearSelections');
                $("#questionbankgrid").datagrid('selectRecord', _bankid);
                var selrow = $("#questionbankgrid").datagrid('getSelected');
                if (!selrow || selrow.length == 0) {
                    var _bankname = n.FQBankName;
                    var _rate = 10;
                    var _operation = '<a href="javascript:void(0)" onclick="setrate(' + _bankid + ')">设置比例</a>';
                    $("#questionbankgrid").datagrid("appendRow", { FQBankId: _bankid, FQBankName: _bankname, FQBnakRate: _rate, FOperation: _operation });
                }
                $("#questionbankgrid").datagrid('clearSelections');
            });
        }
        
        function loadmanqbank() {
            
        }

        function addqbank() {
            var _paperid = $("#hpagerid").val();
            if (!_paperid || _paperid == '0') {
                $.messager.alert('警告', '试卷基本信息尚未设定,无法进行题型设定', 'warning');
                return;
            }
            var _contentclassid = $("#hFContentClassId").val();
            if (!_contentclassid || _contentclassid == '0') {
                $.messager.alert('警告', '内容类别为空,无法加载题库列表', 'warning');
                return;
            }
            openwin("qbankwin", 400, 400, true, "loadmanqbank");
            var options = {
                type: "POST",
                data: { pcontentclassid: _contentclassid },
                success: function (res) {
                    var json = common.Util.StringToJson(res);
                    loadgrid("qbankgrid", json);
                }
            };
            common.Ajax("GetBankList", options);
        }

        function save1() {
            var _paperid = $("#hpagerid").val();
            var _pagename = $("#txtpagername").val();
            var _contentclassid = $("#hFContentClassId").val();
            var _total = $("#txtpapertotal").val();
            var _examtype = $("#selexamtype").val();
            var _extractway = $("#selextractway").val();
            var _chooseitemway = $("#selchooseitemway").val();
            var _examtime = $("#txtexamtime").val();
            var _papercontent = $("#txtpapercontent").val();
            var _examagain = $("#selexamagain").val();
            var _passscore = $("#txtpassscore").val();
            if (!_pagename) {
                $.messager.alert("警告", "试卷名称不能为空!", "warning");
                return;
            }
            if (!_contentclassid || _contentclassid == "0") {
                $.messager.alert("警告", "请选择所属内容类别!", "warning");
                return;
            }
            if (!_total) {
                $.messager.alert("警告", "试卷总分不能为空!", "warning");
                return;
            }
            else {
                if (!common.Validate.ValidateNumber(_total)) {
                    $.messager.alert("警告", "请正确输入试卷总分!", "warning");
                    return;
                }
            }
            if (!_examtime) {
                $.messager.alert("警告", "考试时间不能为空!", "warning");
                return;
            }
            else {
                if (!common.Validate.ValidateNumber(_examtime)) {
                    $.messager.alert("警告", "请正确输入考试时间!", "warning");
                    return;
                }
            }

            if (!_passscore) {
                $.messager.alert("警告", "通过分数不能为空!", "warning");
                return;
            }
            else {
                if (!common.Validate.ValidateNumber(_passscore)) {
                    $.messager.alert("警告", "请正确输入通过分数!", "warning");
                    return;
                }
            }
            $.messager.progress();
            var options = {
                type: "POST",
                data: {
                    ppaperid: _paperid,
                    ppagename: _pagename,
                    pcontentclassid: _contentclassid,
                    ptotal: _total,
                    pexamtype: _examtype,
                    pextractway: _extractway,
                    pchooseitemway: _chooseitemway,
                    pexamtime: _examtime,
                    ppapercontent: _papercontent,
                    pexamagain: _examagain,
                    ppassscore: _passscore
                },
                success: function (res) {
                    $.messager.progress('close');
                    var json = common.Util.StringToJson(res);
                    if (json.ErrorCode == common.Consts.SuccessCode) {
                        $("#hpagerid").val(json.ErrorMessage);
                        next(1);
                    }
                    else {
                        $.messager.alert('警告', json.ErrorMessage, 'warning');
                        return;
                    }
                }
            };
            common.Ajax("SavePage1", options);

        }

        function next(index) {
            $("#tt").tabs("select", index);
        }

        function closewin() {
            window.parent.refreshtab('考试维护管理', 'OE000201', 'ExamManage.aspx');
            window.parent.closecurtab();
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

        function change(obj) {
            obj = $(obj);
            var num = obj.attr("array");
            changetotal(num);
        }

        $(function () {
            $('.btn').linkbutton({ plain: true });
            $('.btn1').linkbutton();
            for (var i = 1; i < 6; i++) {
                $("#num" + i).numberspinner({ editable: true, onSpinUp: function () { change(this); } });
                $("#fz" + i).numberspinner({ editable: true, onSpinUp: function () { change(this); } });
            }
            $("#qbankwin").hide();
            $('#txtrate').numberspinner({
                editable:true
            });
            $('#txtquestionnum').numberspinner({
                editable: true
            });
            $('#txtquestionval').numberspinner({
                editable: true
            });
        });

    </script>
</asp:Content>
