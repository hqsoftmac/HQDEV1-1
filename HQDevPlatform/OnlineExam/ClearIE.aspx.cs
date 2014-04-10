using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HQDevPlatform.OnlineExam
{
    public partial class ClearIE : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            clearIE();
        }

        public void clearIE()
        {
            HttpCookie cookie = Request.Cookies["UserInfo"];
            cookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookie);
        }
    }
}