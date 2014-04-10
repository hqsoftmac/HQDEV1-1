<%@ Page Title="" Language="C#" MasterPageFile="~/WebContent.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="childcolcontent.aspx.cs" Inherits="HQDevSys.manage.lanmu.childcolcontent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../jquery.min.js" type="text/javascript"></script>
    <script src="../../jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../../Js/common.js" type="text/javascript"></script>
    <link href="../../Scripts/xheditor_skin/default/iframe.css" rel="stylesheet" type="text/css" />
    <link href="../../Scripts/xheditor_skin/default/ui.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/xheditor-1.1.13-zh-cn.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHPageName" runat="server">
    导航子栏目普通简介定义
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHPageTool" runat="server">
    <a href="javascript:void(0)" class="btn" id="A2" iconCls="icon-back" onclick="backchildcolumn()">返回</a>
    <a href="javascript:void(0)" class="btn" id="btnadd" iconCls="icon-save" onclick="savechildcolcontent()">保存简介内容</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPHContent" runat="server">
    <div style="margin:10px auto;width:95%;">
        <table style="width:100%;margin:10px auto;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">  
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    SEO标题：
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <input type="text" id="txtseotitle" value= "<%=gstitle %>" style="width:500px;" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    SEO关键字：
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <input type="text" id="txtseokeyword" value= "<%=gskeyword %>" style="width:500px;" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    SEO描述：
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <textarea style="width:99%;" id="txtseodescription" onkeyup="if(this.value.length>250)this.value=this.value.substring(0,250)" rows="6" cols="70"><%=gsdescription%></textarea>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    内容编辑：
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <textarea id="txtcontent" style="width: 99%; height: 320px;"><%=gscontent%></textarea>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="CPHJavascript" runat="server">
    <script type="text/javascript">
        function savechildcolcontent() {
            var _seotitle = $("#txtseotitle").val();
            var _seokeyword = $("#txtseokeyword").val();
            var _seodescription = $("#txtseodescription").val();
            var _content = $("#txtcontent").val();
            if (!_content) {
                $.messager.alert("简介内容不能为空!");
                return;
            }
            var options = {
                type: "POST",
                data: { ptitle: _seotitle, pkeyword: _seokeyword, pdescription: _seodescription, pcontent: _content },
                success: function (res) {
                    var json = common.Util.StringToJson(res);
                    if (json.ErrorCode == common.Consts.SuccessCode) {
                        backchildcolumn();
                    }
                    else {
                        $.messager.alert('警告', json.ErrorMessage, 'warning');
                        return;
                    }
                }
            };
            common.Ajax("SaveContent", options);
        }

        $(function () {
            $('.btn').linkbutton({ plain: true });
            $('.btn1').linkbutton();
            $("#txtcontent").xheditor({ upLinkUrl: "../upload.aspx", upLinkExt: "zip,rar,txt,doc,xls,docx,xlsx,ppt,pptx,rft", upImgUrl: "../upload.aspx", upImgExt: "jpg,jpeg,gif,png", upFlashUrl: "../upload.aspx", upFlashExt: "swf", upMediaUrl: "../upload.aspx", upMediaExt: "avi" });
        });

        function backchildcolumn() {
            var options = {
                type: "POST",
                data: { pdata: "1" },
                success: function (res) {
                    window.location = "childcoldefine.aspx?navid=" + res;
                }
            };
            common.Ajax("GetBackUrl", options);
        }
    </script>
</asp:Content>
