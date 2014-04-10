<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="HQDevSys.manage.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color:#2287b5;font-size:12px;">
    <form id="form1" runat="server">
    <div style="height:130px;width:100%;">
    </div>
    <div style="width:517px;background-image:url(../images/login.png);background-position:left top;background-repeat:no-repeat;margin:0px auto;height:359px;">
        <div style="width:300px;height:96px;padding:100px 0px 0px 150px;">
            <table>
                <tr style="height:35px;">
                    <td style="width:50px;">用户:</td>
                    <td style="width:150px;">
                        <asp:TextBox ID="txtUserName" runat="server" Width="150px" TabIndex="10"></asp:TextBox>
                    </td>
                    <td rowspan="2" valign="middle">
                        <asp:Button ID="loginbtn" runat="server" Text="登  录" Width="100px" 
                            TabIndex="30" Height="60px" CssClass="btn" onclick="loginbtn_Click" />
                    </td>
                </tr>
                <tr style="height:35px;">
                    <td>密码:</td>
                    <td><asp:TextBox ID="txtUserPsw" runat="server" TextMode="Password" Width="150px" TabIndex="20"></asp:TextBox></td>
                </tr>
            </table>
        </div>
    </div>
    <div style="width:517px;margin:30px auto;height:50px;text-align:center;">
        <div style="background-image:url(../images/12767667063818330.png);background-position:left center;background-repeat:no-repeat;height:23px;padding-left:38px;width:100px;float:left;padding-top:15px;margin-left:30px;">
           <b>FireFox</b>&nbsp;&nbsp;<a href="../addin/FireFox.zip" class="addindowload" >下载</a>
        </div>
        <div style="background-image:url(../images/12767679540794150.png);background-position:left center;background-repeat:no-repeat;height:23px;padding-left:38px;width:80px;float:left;padding-top:15px;margin-left:30px;">
           <b>IE 8</b>&nbsp;&nbsp;<a href="../addin/IE8.zip" class="addindowload" >下载</a>
        </div>
        <div style="background-image:url(../images/13212442872657820.png);background-position:left center;background-repeat:no-repeat;height:23px;padding-left:38px;width:100px;float:left;padding-top:15px;margin-left:30px;">
           <b>Chrome</b>&nbsp;&nbsp;<a href="../addin/chrome.zip" class="addindowload" >下载</a>
        </div>
    </div>
    </form>
</body>
</html>
