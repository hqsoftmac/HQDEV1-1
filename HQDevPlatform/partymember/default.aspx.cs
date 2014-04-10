using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HQLib.User;
using HQLib.Page;
using HQLib;
using HQConst.Const;
using System.Text;
using HQLib.Function;

namespace HQDevPlatform.partymember
{
    public partial class _default : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SysUser useritem = new SysUser();
            useritem = GetUserInfo();
            lbluserdesc.Text = useritem.FUserDesc;
            lblusername.Text = useritem.FUserName;
            this.menu.InnerHtml = SetMenu(useritem.FUserId);
        }

        public string SetMenu(Int64 _userid)
        {
            StringBuilder sb = new StringBuilder();
            SysFunListBiz biz = new SysFunListBiz();
            List<SysFunList> lists = new List<SysFunList>();
            lists = biz.SelectValidFunList(_userid, "PMMG");
            Session["RightList"] = lists;
            foreach (SysFunList item in lists)
            {
                if (item.FParentFunId == 0)
                {
                    sb.Append("<div title=\"" + item.FFunName + "\" style=\"background-color:#efefef;\">");
                    sb.Append("<ul class=\"menutree\">");
                    foreach (SysFunList childitem in lists.Where(p => p.FParentFunId == item.FFunId))
                    {
                        sb.Append("<li>");
                        sb.Append("<a class=\"menulink\" href=\"javascript:void(0)\" url=\"" + childitem.FFunNavigateUrl + "\" framename=\"" + childitem.FFunName + "\" title=\"" + childitem.FFunContent + "\" rel=\"" + childitem.FFunCode + "\">" + childitem.FFunName + "</a>");
                        sb.Append("</li>");
                    }
                    sb.Append("</ul>");
                    sb.Append("</div>");
                }
            }
            return sb.ToString();
        }

        public void SavePsw()
        {
            string _orgpsw = Parameters["orgpsw"];
            string _newpsw = Parameters["newpsw"];
            string _confirmpsw = Parameters["confirmpsw"];
            SysUserBiz biz = new SysUserBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            SysUser useritem = new SysUser();
            useritem = GetUserInfo();
            if (_newpsw.Length < 6)
            {
                ErrInfo = new ErrorEntity(RespCode.SysUser0010);
            }
            else
            {
                int result = biz.UserChangePsw(useritem.FUserId, _orgpsw, _newpsw, _confirmpsw, out ErrInfo);
            }
            Response.Write(ErrInfo.ToJson());
        }
    }

}