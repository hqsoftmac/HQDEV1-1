<%@ Page Title="" Language="C#" MasterPageFile="~/WebContent.Master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="positionadd.aspx.cs" Inherits="HQDevSys.manage.human.positionadd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../js/jquery.uploadify-v2.1.0/example/css/default.css" rel="stylesheet" type="text/css" />
    <link href="../../js/jquery.uploadify-v2.1.0/example/css/uploadify.css" rel="stylesheet" type="text/css" />
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
    新增职位
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHPageTool" runat="server">
    <a href="javascript:void(0)" class="btn" id="btnadd" iconCls="icon-add" onclick="saveposition()">保存</a>
    <a href="positionmanage.aspx" class="btn" id="btndel" iconCls="icon-back">返回</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPHContent" runat="server">
    <table style="width:100%;margin:0px auto;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">            
        <tr>
            <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                职位名称：
            </td>
            <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                <input type="text" id="txtpositionname" value="" style="width:350px;" />
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                职位部门：
            </td>
            <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                <input type="text" id="txtpositiondept" value="" style="width:350px;" />
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                职位类型：
            </td>
            <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                <select id="selpositiontype">
                    <option value="0" selected>全职</option>
                    <option value="1">兼职</option>
                </select>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                性别要求：
            </td>
            <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                <select id="selpositiongendor">
                    <option value="0">性别不限</option>
                    <option value="1">男性</option>
                    <option value="2">女性</option>
                </select>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                招聘人数：
            </td>
            <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                <input type="text" id="txtpositionnum" value="1" style="width:100px;" />
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                开始日期：
            </td>
            <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                <input type="text" id="txtbegindate" value="" style="width:100px;" />
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                结束日期：
            </td>
            <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                <input type="text" id="txtenddate" value="" style="width:100px;" />
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                备注：
            </td>
            <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                <input type="text" id="txtbackcontent" value="" style="width:550px;" />
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                职位内容：
            </td>
            <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                <textarea id="txtcontent" style="width:99%;height:300px;"></textarea>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                显示顺序：
            </td>
            <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                <input type="text" id="txtorder" value="10" style="width:100px;" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="CPHJavascript" runat="server">
    <script type="text/javascript">
        function saveposition() {
            var _positionname = $("#txtpositionname").val();
            var _positiondept = $("#txtpositiondept").val();
            var _positiontype = $("#selpositiontype").val();
            var _positiongendor = $("#selpositiongendor").val();
            var _positionnum = $("#txtpositionnum").val();
            var _begindate = $("#txtbegindate").datebox("getValue");
            var _enddate = $("#txtenddate").datebox("getValue");
            var _bakcontent = $("#txtbackcontent").val();
            var _content = $("#txtcontent").val();
            var _order = $("#txtorder").val();
            if (!_positionname) {
                $.messager.alert("错误", "职位名称不能为空!", "warning");
                return;
            }
            if (!_positiondept) {
                $.messager.alert("错误","职位部门不能为空!","warning");
                return;
            }
            if (!common.Validate.ValidateNatNumber(_positionnum)) {
                $.messager.alert("错误","招聘人数输入不正确!","warning");
                return;
            }
            if (!common.Validate.ValidateDateTime(_begindate)) {
                $.messager.alert("错误", "开始日期输入不正确!", "warning");
                return;
            }
            if (!common.Validate.ValidateDateTime(_enddate)) {
                $.messager.alert("错误", "结束日期输入不正确!", "warning");
                return;
            }
            if (_begindate > _enddate) {
                $.messager.alert("错误", "结束日期不能小于开始日期!", "warning");
                return;
            }
            if (!_content) {
                $.messager.alert("错误", "职位内容不能为空!", "warning");
                return;
            }
            if (!common.Validate.ValidateNatNumber(_order)) {
                $.messager.alert("错误", "职位顺序输入不正确!", "warning");
                return;
            }
            var options = {
                type: "POST",
                data: {
                    ppositionname: _positionname,
                    ppositiondept: _positiondept,
                    ppositiontype: _positiontype,
                    ppositiongendor: _positiongendor,
                    ppositionnumber: _positionnum,
                    pbegindate: _begindate,
                    penddate: _enddate,
                    pbackcontent: _bakcontent,
                    pcontent: _content,
                    porder: _order
                },
                success: function (res) {
                    var json = common.Util.StringToJson(res);
                    if (json.ErrorCode == common.Consts.SuccessCode) {
                        window.location = "positionmanage.aspx";
                    }
                    else {
                        $.messager.alert('警告', json.ErrorMessage, 'warning');
                        return;
                    }
                }
            };
            common.Ajax("SaveItem", options);
        }

        $(function () {
            $('.btn').linkbutton({ plain: true });
            $('.btn1').linkbutton();
            $("#txtcontent").xheditor({ upLinkUrl: "../upload.aspx", upLinkExt: "zip,rar,txt,doc,xls,docx,xlsx,ppt,pptx,rft", upImgUrl: "../upload.aspx", upImgExt: "jpg,jpeg,gif,png", upFlashUrl: "../upload.aspx", upFlashExt: "swf", upMediaUrl: "../upload.aspx", upMediaExt: "avi" });
            $('#txtbegindate').datebox({ currentText: '今天', closeText: '关闭', okText: '确定', formatter: formatD });
            $('#txtenddate').datebox({ currentText: '今天', closeText: '关闭', okText: '确定', formatter: formatD });

            var myDate = new Date();
            var month = myDate.getMonth() + 1;
            var ss = myDate.getFullYear() + "-" + month + "-" + myDate.getDate();
            $('#txtbegindate').datebox("setValue", ss);
            $('#txtenddate').datebox("setValue", ss);
        });

        function formatD(date) {
            var _mon = date.getMonth() + 1;
            return date.getFullYear() + "-" + _mon + "-" + date.getDate();
        }

    </script>
</asp:Content>
