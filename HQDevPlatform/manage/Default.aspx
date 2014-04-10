<%@ Page Language="C#" AutoEventWireup="true" Inherits="manage_Default" Codebehind="Default.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../jquery.min.js" type="text/javascript"></script>
    <script src="../jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../Js/common.js" type="text/javascript"></script>
</head>
<body class="easyui-layout">
    <form id="main" method="post" runat="server">
    <div id="divnorth" region="north" data-options="region:'north',border:false" style="height:50px;padding:0;">
        <div class="headerNav">
        
        </div>
        <div class="quickmenu">
            欢迎您,[<asp:Label ID="lblusername" runat="server" Text="Label"></asp:Label>]&nbsp;<asp:Label ID="lbluserdesc" runat="server" Text="Label"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;<a class="quicklink" href="javascript:void(0)" onclick="modifypsw()">修改密码</a>&nbsp;&nbsp;&nbsp;&nbsp;<a class="quicklink" href="javascript:void(0)" onclick="A_exit()">安全退出</a>
        </div>
    </div>
    <div region="west" data-options="region:'west',split:true,title:'功能菜单'" style="width:157px;">
        <div runat="server" id="menu" style="border:0;">
            
        </div>
    </div>
    <div data-options="region:'east',split:true,collapsed:true,title:'快捷导航'" style="width:160px;padding:10px;">
        
    </div>
	<div region="south" data-options="region:'south',border:false" style="height:30px;background:#A9FACD;padding:10px;text-align:right;">南通华强通用软件有限公司&nbsp;&nbsp; &copy;版权所有&nbsp;&nbsp;7X8小时免费热线:&nbsp;400-666-8049 &nbsp;&nbsp;官方网站:<a href="www.hq365.net" target="_blank">www.hq365.net</a></div>
	<div region="center" data-options="region:'center',border:false">
        <div id="tt" class="easyui-tabs" fit="true">
            
        </div> 
    </div>
    <div id="addwin" iconCls="icon-save" title="修改密码" style="display:none;text-align:center;">
        <table style="width: 320px;margin:10px auto;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">            
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    原密码：
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <input type="password" id="txtorgpassword" style="width:150px;" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    新密码：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left:5px;text-align:left;" >
                    <input type="password" id="txtnewpassword" style="width:150px;" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    确认密码：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left:5px;text-align:left;" >
                    <input type="password" id="txtconfirmpassword" style="width:150px;" />
                </td>
            </tr>
        </table>
        <div style="margin:20px auto;">
            <a href="#" class="btn1" id="btnsave" iconCls="icon-save" onclick="save()">修改</a>&nbsp;&nbsp;
            <a href="#" class="btn1" id="btnclose" iconCls="icon-cancel" onclick="closewin()" >取消</a>
        </div>
    </div>
    </form>   
</body>
<script src="../Js/UIjs.js" type="text/javascript"></script>
<script type="text/javascript">
    function save() {
        var _orgpsw = $("#txtorgpassword").val();
        var _newpsw = $("#txtnewpassword").val();
        var _confirmpsw = $("#txtconfirmpassword").val();
        if (!_newpsw) {
            $.messager.alert('警告', '新密码不能为空!', 'warning');
            return;
        }
        if (_newpsw != _confirmpsw) {
            $.messager.alert('警告', '新密码和确认密码不一致,无法修改密码!', 'warning');
            return;
        }
        var options = {
            type: "POST",
            data: { orgpsw: _orgpsw, newpsw: _newpsw, confirmpsw: _confirmpsw },
            success: function (res) {
                var json = common.Util.StringToJson(res);
                if (json.ErrorCode == common.Consts.SuccessCode) {
                    closewin();
                }
                else {
                    $.messager.alert('警告', json.ErrorMessage, 'warning');
                    return;
                }
            }
        };
        common.Ajax("SavePsw", options);
    }

    $(function () {
        $('.btn1').linkbutton();
    });

    function closewin() {
        $('#addwin').window('close');
    }

    function A_exit() {
        $.messager.confirm('确认', '您是否确定退出系统吗?', function (r) {
            if (!r) {
                return false;
            }
            else {
                location.replace("ClearIE.aspx");
                event.returnValue = false;
                return true;
            }
        });
    }

    function modifypsw() {
        $('#addwin').window({
            width: 350,
            height: 300,
            modal: true
        });
        $('#addwin').show();
    }
</script>
</html>
