using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HQLib.Util;
using HQLib;
using HQLib.User;
using HQConst.Const;
using HQLib.Page;

namespace HQDevSys.manage
{
    public partial class login : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginbtn_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string psw = txtUserPsw.Text;
            ErrorEntity ErrInfo = new ErrorEntity();
            SysUserBiz userbiz = new SysUserBiz();
            SysUser useritem = new SysUser();
            useritem = userbiz.UserLogin(username, psw, "SITE", out ErrInfo);
            if (ErrInfo.ErrorCode == RespCode.Success)
            {
                SetUserInfo(useritem);
                Response.Redirect("~/manage/default.aspx");
            }
            else
            {
                Server_Alert(ErrInfo.ErrorMessage);
                return;
            }
        }
    }
}