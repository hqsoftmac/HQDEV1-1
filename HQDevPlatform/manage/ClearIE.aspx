<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClearIE.aspx.cs" Inherits="HQExamineSys.admin.ClearIE" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/ecmascript" language="javascript">
        function b(u) {
            var Backlen = history.length;
            if (Backlen > 0) {
                history.go(-Backlen);
            }
            if (u == 0) {
                top.window.location.href = "default.aspx";
            }
            else {
                top.window.location.href = "login.aspx";
            }
        }
        window.onload = function () {
            var src = window.location.href;
            var T = src.indexOf("?u=");
            if (T <= 0) {
                b(0);
            }
            else {
                var I = src.substr(src.indexOf("?u=") + 3);
                if (I == "1") {
                    b(1);
                }
                else {
                    b(0);
                }
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
