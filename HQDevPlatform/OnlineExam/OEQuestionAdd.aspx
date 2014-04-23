<%@ Page Title="" Language="C#" MasterPageFile="~/WebContent.Master" ValidateRequest="false"  AutoEventWireup="true" CodeBehind="OEQuestionAdd.aspx.cs" Inherits="HQDevPlatform.OnlineExam.OEQuestionAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.4.1-vsdoc.js" type="text/javascript"></script>
    <script src="../../jquery.min.js" type="text/javascript"></script>
    <script src="../../jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../../Js/common.js" type="text/javascript"></script>
    <script charset="gb2312" language="javascript" src="../../js/jquery.uploadify-v2.1.0/example/scripts/swfobject.js" type="text/javascript"></script>
    <script charset="gb2312" language="javascript" src="../../js/jquery.uploadify-v2.1.0/example/scripts/jquery.uploadify.v2.1.0.min.js" type="text/javascript"></script>
    <link href="../../Scripts/xheditor_skin/default/iframe.css" rel="stylesheet" type="text/css" />
    <link href="../../Scripts/xheditor_skin/default/ui.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/xheditor-1.1.13-zh-cn.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHPageName" runat="server">
    新增题目
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHPageTool" runat="server">
    <a href="javascript:void(0)" class="btn" id="btnadd" iconCls="icon-add" onclick="savequestion()">保存</a>
    <a href="javascript:void(0)" class="btn" id="btndel" iconCls="icon-back" onclick="window.parent.closecurtab()" >返回</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPHContent" runat="server">
    <div id="tt" class="easyui-tabs">  
        <div title="题目内容" style="padding:5px;">
            <table style="width:99%;margin:0px auto;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">  
                <tr>
                    <td align="right" style="width: 100px; background-color: #e1f5fc; height: 25px;" >
                        内容类别
                    </td>
                    <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                        <input type="hidden" id="hFContentClassId" value="0" />
                        <label id="lblclassname" style="min-width:200px;border:1px solid #000;padding:2px 3px;">===请选择内容类别===</label>
                        <a href="javascript:void(0)" class="btn" id="A2" iconCls="icon-search" onclick="searchcontentclass()"></a>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 100px; background-color: #e1f5fc; height: 25px;" >
                        所属题库
                    </td>
                    <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                        <select id="selquestionbank">
                            <option value="">===请选择题库===</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 100px; background-color: #e1f5fc; height: 25px;" >
                        题目标题
                    </td>
                    <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                        <input type="hidden" id="hFQuestionId" value="0" />
                        <textarea id="txtFQuestionTitle" style="width:100%;height:320px;"></textarea>
   			        </td>
 		        </tr>
                <tr>
                    <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                        题目类型
                    </td>
                    <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                        <select id="selFQuestionType">
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
                        难易等级
                    </td>
                    <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                        <select id="selFQuestionDifficulty">
                            <option value="">==选择题目难度</option>
                            <option value="0">低</option>
                            <option value="1">中</option>
                            <option value="2">高</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                        题目关键字
                    </td>
                    <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                        <input type="text" id="txtFKeyWord" value="" style="width:98%;" />
   			        </td>
 		        </tr>
            </table>
        </div>
        <div title="题目解析" style="padding:5px;">
            <table style="width:99%;margin:0px auto;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">   
                <tr>
                    <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                        考察点说明
                    </td>
                    <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                        <textarea id="txtFQuestionDesc" style="width:100%;height:80px;"></textarea>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 100px; background-color: #e1f5fc; height: 25px;" >
                        题目解析
                    </td>
                    <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                        <textarea id="txtAnalysis" style="width:100%;height:260px;"></textarea>
   			        </td>
 		        </tr>
            </table>
        </div>
    </div>
    <div id="contentclasswin" iconCls="icon-save" title="内容类别选择" style="display:none;text-align:center;">
        <table id="treetable">
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="CPHJavascript" runat="server">
    <script type="text/javascript">
        function initwin() {
            $("#hFContentClassId").val();
            $("#lblclassname").html("===请选择内容类别===");
            $("#selquestionbank").val("");
            $("#hFQuestionId").val("");
            $("#txtFQuestionTitle").val("");
            $("#selFQuestionType").val("");
            $("#selFQuestionDifficulty").val("");
            $("#txtFKeyWord").val("");
            $("#txtAnalysis").val("");
        }
        
        function savequestion() {
            var _contentclassid = $("#hFContentClassId").val();
            var _questionbank = $("#selquestionbank").val();
            var _questionid = $("#hFQuestionId").val();
            var _questiontitile = $("#txtFQuestionTitle").val();
            var _questiontype = $("#selFQuestionType").val();
            var _questiondiffculty = $("#selFQuestionDifficulty").val();
            var _keyword = $("#txtFKeyWord").val();
            var _desc = $("#txtFQuestionDesc").val();
            var _analysis = $("#txtAnalysis").val();
            if (!_contentclassid || _contentclassid == "0") {
                $.messager.alert("警告", "所属类别不能为空,请选择相关内容类别!", "warning");
                return;
            }
            if (!_questionbank || _questionbank == "0") {
                $.messager.alert("警告", "所属题库不能为空,请选择相关所属题库!", "warning");
                return;
            }
            if (!_questiontitile) {
                $.messager.alert("警告", "标题内容不能为空,请填写标题的相关内容!", "warning");
                return;
            }
            if (!_questiontype) {
                $.messager.alert("警告", "题目类型不能为空!", "warning");
                return;
            }
            if (!_questiondiffculty) {
                $.messager.alert("警告", "题目难度设定不能为空!", "warning");
                return;
            }
            if (!_keyword) {
                $.messager.alert("警告", "题目关键字设定不能为空!", "warning");
                return;
            }
            $.messager.progress();
            var options = {
                type: "POST",
                data: {
                    pcontentclassid: _contentclassid,
                    pquestionbank: _questionbank,
                    pquestionid: _questionid,
                    pquestiontitle: _questiontitile,
                    pquestiontype: _questiontype,
                    pquestiondifficulty: _questiondiffculty,
                    pkeyword: _keyword,
                    pdesc: _desc,
                    panalysis: _analysis
                },
                success: function (res) {
                    var json = common.Util.StringToJson(res);
                    if (json.ErrorCode == common.Consts.SuccessCode) {
                        $.messager.progress('close');
                        $.messager.alert("提示", "保存成功!", "info");
                        initwin();
                    }
                    else {
                        $.messager.progress('close');
                        $.messager.alert('警告', json.ErrorMessage, 'warning');
                        return;
                    }
                }
            };
            common.Ajax("SaveQuestion", options);
        }
        
        function loadquestionbank() {
            var _classid = $("#hFContentClassId").val();
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
        
        function nullrnt() {
            
        }

        function closewin1() {
            $("#contentclasswin").window('close');
        }

        function choosecontentclass() {
            var row = $("#treetable").treegrid('getSelected');
            if (!row || row.length == 0) {
                $.messager.alert('提示', '请选择相关内容类别!', 'info');
                return;
            }
            $("#hFContentClassId").val(row.FContentClassId);
            $("#lblclassname").html("[" + row.FContentClassCode + "]" + row.FContentClassName);
            closewin1();
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

        $(function () {
            $('.btn').linkbutton({ plain: true });
            $('.btn1').linkbutton();
            $("#txtFQuestionTitle").xheditor({ upLinkUrl: "../upload.aspx", upLinkExt: "zip,rar,txt,doc,xls,docx,xlsx,ppt,pptx,rft", upImgUrl: "../upload.aspx", upImgExt: "jpg,jpeg,gif,png", upFlashUrl: "../upload.aspx", upFlashExt: "swf", upMediaUrl: "../upload.aspx", upMediaExt: "avi" });
            $("#txtFQuestionDesc").xheditor({ upLinkUrl: "../upload.aspx", upLinkExt: "zip,rar,txt,doc,xls,docx,xlsx,ppt,pptx,rft", upImgUrl: "../upload.aspx", upImgExt: "jpg,jpeg,gif,png", upFlashUrl: "../upload.aspx", upFlashExt: "swf", upMediaUrl: "../upload.aspx", upMediaExt: "avi" });
            $("#txtAnalysis").xheditor({ upLinkUrl: "../upload.aspx", upLinkExt: "zip,rar,txt,doc,xls,docx,xlsx,ppt,pptx,rft", upImgUrl: "../upload.aspx", upImgExt: "jpg,jpeg,gif,png", upFlashUrl: "../upload.aspx", upFlashExt: "swf", upMediaUrl: "../upload.aspx", upMediaExt: "avi" });
            initwin();
        });

    </script>
</asp:Content>
