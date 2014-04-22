<%@ Page Title="" Language="C#" MasterPageFile="~/WebContent.Master" AutoEventWireup="true" CodeBehind="OEQuestionItemSet.aspx.cs" Inherits="HQDevPlatform.OnlineExam.OEQuestionItemSet" %>
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
    题目答案设置
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHPageTool" runat="server">
    <a href="javascript:void(0)" class="btn" id="btnadd" iconCls="icon-add" onclick="add()">新增</a>
    <a href="javascript:void(0)" class="btn" id="btndel" iconCls="icon-remove" onclick="del()">删除</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPHContent" runat="server">
    <div style="width:98%;margin:0 auto;clear:both;margin-top:2px;">
        <table id="listgrid" class="easyui-datagrid" title="答案列表" style="margin:2px auto;" data-options="singleSelect:false,fitColumns:true,idField:'FItemId',rownumbers:true,pagination:true">
            <thead>
                <tr>
					<th data-options="field:'FItemId',align:'center',checkbox:true">选择</th>
                    <th data-options="field:'FItemContent',width:300,align:'left'">答案内容</th>
                    <th data-options="field:'FItemFlagName',width:60,align:'center'">正确答案</th>
					<th data-options="field:'FOperation',width:80,align:'center'">操作</th>
                </tr>
            </thead>
        </table>
    </div>
    <div style="width:98%;margin:5px auto;clear:both;">
        <table style="width:100%;margin:0px auto;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
            <tr>
                <td align="right" style="width: 100px; background-color: #e1f5fc; height: 25px;" >
                    题目标题
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <input type="hidden" id="hFQuestionId" value="<%=item.FQuestionId %>" />
                    <%=item.FQuestionTitle%>
   			    </td>
 		    </tr>
            <tr>
                <td align="right" style="width: 100px; background-color: #e1f5fc; height: 25px;" >
                    题目类型
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <%=item.FQuestionTypeName%>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="CPHJavascript" runat="server">
    <script type="text/javascript">
        $(function () {
            $('.btn').linkbutton({ plain: true });
            $('.btn1').linkbutton();
            formatgrid("listgrid", "loadgriddata", "hpagenum", "hpagesize", "hsortname", "hsortdirection");
        });
    </script>
</asp:Content>
