using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HQPortal.ML;
using HQPortal.Biz;
using HQLib.Params;

namespace HQDevPlatform.template.style01
{
    public partial class header : System.Web.UI.UserControl
    {
        protected string gsmenu = string.Empty;
        protected string gslogourl = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            gsmenu = GetMenu();
            SysConfigBiz biz = new SysConfigBiz();
            gslogourl = biz.GetKeyValue("WebLogo", "SITE");
        }

        /// <summary>
        /// 获取门户菜单
        /// </summary>
        /// <returns></returns>
        private string GetMenu()
        {
            string menulist = string.Empty;
            PortalColumnBiz biz = new PortalColumnBiz();
            List<PortalColumn> lists = new List<PortalColumn>();
            lists = biz.SelectValidColumn();
            foreach (PortalColumn item in lists)
            {
                if (item.FParentColumnId == 0)
                {
                    menulist += "<li>";
                    if (string.IsNullOrEmpty(item.FColumnUrl))
                    {
                        menulist += "<a href=\"default.aspx?ColId=" + item.FColumnId.ToString() + "\"";
                    }
                    else
                    {
                        menulist += "<a href=\"" + item.FColumnUrl + "\"";
                    }
                    if (item.FColumnTarget == "1")
                    {
                        menulist += " target=\"_blank\"><span class=\"uppercase\">";
                    }
                    else
                    {
                        menulist += "><span class=\"uppercase\">";
                    }
                    menulist += item.FColumnName + "</span></a>";
                    if (lists.Where(p => p.FParentColumnId == item.FColumnId).Count() > 0)
                    {
                        GetChildMenu(item.FColumnId.ToString(), lists, ref menulist);
                        menulist += "</li>";
                    }
                    else
                    {
                        menulist += "</li>";
                    }
                }
            }
            return menulist;
        }

        /// <summary>
        /// 递归获取多级菜单
        /// </summary>
        /// <param name="iparentid"></param>
        /// <param name="lists"></param>
        /// <returns></returns>
        private void GetChildMenu(string iparentid, List<PortalColumn> lists, ref string menulist)
        {
            menulist += "<ul>";
            foreach (PortalColumn item in lists.Where(p => p.FParentColumnId == Convert.ToInt64(iparentid)))
            {
                menulist += "<li>";
                if (string.IsNullOrEmpty(item.FColumnUrl))
                {
                    menulist += "<a href=\"default.aspx?ColId=" + item.FColumnId.ToString() + "\"";
                }
                else
                {
                    menulist += "<a href=\"" + item.FColumnUrl + "\"";
                }
                if (item.FColumnTarget == "1")
                {
                    menulist += " target=\"_blank\">";
                }
                else
                {
                    menulist += ">";
                }
                menulist += item.FColumnName + "</a>";
                if (lists.Where(p => p.FParentColumnId == item.FColumnId).Count() > 0)
                {
                    GetChildMenu(item.FColumnId.ToString(), lists, ref menulist);
                    menulist += "</li>";
                }
                else
                {
                    menulist += "</li>";
                }
            }
            menulist += "</ul>";
        }
    }
}