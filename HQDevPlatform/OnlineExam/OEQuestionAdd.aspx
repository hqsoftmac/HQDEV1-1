<%@ Page Title="" Language="C#" MasterPageFile="~/WebContent.Master" AutoEventWireup="true" CodeBehind="OEQuestionAdd.aspx.cs" Inherits="HQDevPlatform.OnlineExam.OEQuestionAdd" %>
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
                        <select id="selFQBankName">
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
        <div title="答案设置" style="padding:5px;">

        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="CPHJavascript" runat="server">
    <script type="text/javascript">
        $(function () {
            $('.btn').linkbutton({ plain: true });
            $('.btn1').linkbutton();
            $("#txtFQuestionTitle").xheditor({ upLinkUrl: "../upload.aspx", upLinkExt: "zip,rar,txt,doc,xls,docx,xlsx,ppt,pptx,rft", upImgUrl: "../upload.aspx", upImgExt: "jpg,jpeg,gif,png", upFlashUrl: "../upload.aspx", upFlashExt: "swf", upMediaUrl: "../upload.aspx", upMediaExt: "avi" });
            $("#txtFQuestionDesc").xheditor({ upLinkUrl: "../upload.aspx", upLinkExt: "zip,rar,txt,doc,xls,docx,xlsx,ppt,pptx,rft", upImgUrl: "../upload.aspx", upImgExt: "jpg,jpeg,gif,png", upFlashUrl: "../upload.aspx", upFlashExt: "swf", upMediaUrl: "../upload.aspx", upMediaExt: "avi" });
            $("#txtAnalysis").xheditor({ upLinkUrl: "../upload.aspx", upLinkExt: "zip,rar,txt,doc,xls,docx,xlsx,ppt,pptx,rft", upImgUrl: "../upload.aspx", upImgExt: "jpg,jpeg,gif,png", upFlashUrl: "../upload.aspx", upFlashExt: "swf", upMediaUrl: "../upload.aspx", upMediaExt: "avi" });
        });
    </script>
</asp:Content>
