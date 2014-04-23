<%@ Page Title="" Language="C#" MasterPageFile="~/WebContent.Master" AutoEventWireup="true" CodeBehind="OEQuestionItemEdit.aspx.cs" Inherits="HQDevPlatform.OnlineExam.OEQuestionItemEdit" %>
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
    编辑题目答案
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHPageTool" runat="server">
    <a href="javascript:void(0)" class="btn" id="btnadd" iconCls="icon-save" onclick="save()">保存</a>
    <a href="javascript:void(0)" class="btn" id="btndel" iconCls="icon-back" onclick="closepage()" >返回</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPHContent" runat="server">
    <table style="width:99%;margin:0px auto;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">  
        <tr>
            <td align="right" style="width: 100px; background-color: #e1f5fc; height: 25px;" >
                答案内容
            </td>
            <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                <input type="hidden" id="hquestionid" value="<%=gsquestionid %>" />
                <input type="hidden" id="hquestionitemid" value="<%=gsquestionitemid %>" />
                <input type="hidden" id="hflag" value="<%=item.FItemFlag %>" />
                <textarea id="txtFItemContent" style="width:99%;height:350px;"><%=item.FItemContent %></textarea>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 100px; background-color: #e1f5fc; height: 25px;" >
                正确答案
            </td>
            <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                <input type="checkbox" id="cbxFItemFlag" /><label for="cbxFItemFlag">设置为正确答案</label>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="CPHJavascript" runat="server">
    <script type="text/javascript">
        $(function () {
            $('.btn').linkbutton({ plain: true });
            $('.btn1').linkbutton();
            $("#txtFItemContent").xheditor({ upLinkUrl: "../upload.aspx", upLinkExt: "zip,rar,txt,doc,xls,docx,xlsx,ppt,pptx,rft", upImgUrl: "../upload.aspx", upImgExt: "jpg,jpeg,gif,png", upFlashUrl: "../upload.aspx", upFlashExt: "swf", upMediaUrl: "../upload.aspx", upMediaExt: "avi" });
            var _flag = $("#hflag").val();
            if (_flag == 1) {
                $("#cbxFItemFlag").attr("checked", "checked");
            }
        });

        function closepage() {
            var _id = $("#hquestionid").val();
            window.parent.refreshtab('设置题目答案', 'OE000103003', 'OEQuestionItemSet.aspx?qid=' + _id);
            window.parent.closecurtab();
        }

        function save() {
            var _itemcontent = $("#txtFItemContent").val();
            var _itemflag = '0';
            if ($("#cbxFItemFlag").attr("checked") == 'checked') {
                _itemflag = '1';
            }
            if (!_itemcontent) {
                $.messager.alert("警告", "答案内容不能为空!", "warning");
                return;
            }
            $.messager.progress();
            var options = {
                type: "POST",
                data: { pitemcontent: _itemcontent, pitemflag: _itemflag },
                success: function (res) {
                    var json = common.Util.StringToJson(res);
                    if (json.ErrorCode == common.Consts.SuccessCode) {
                        $.messager.progress('close');
                        $.messager.alert("提示", "保存成功!", "info");
                        closepage();

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
    </script>
</asp:Content>
