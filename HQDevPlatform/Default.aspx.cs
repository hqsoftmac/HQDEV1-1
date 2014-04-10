using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HQLib.Page;
using HQPortal.ML;
using HQPortal.Biz;
using HQLib.Params;

public partial class _Default : PortalBase
{
    protected string gssitename = string.Empty;
    protected string gssitedesc = string.Empty;
    protected string gssitekey = string.Empty;
    protected string gssitestyle = string.Empty;
    protected string gsheadertemplatepath = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        string colid = Parameters["ColId"];
        //读取网站参数
        SysConfigBiz biz = new SysConfigBiz();
        gssitename = biz.GetKeyValue("SiteName", "SITE");
        string stylename = biz.GetKeyValue("SiteStyle", "SITE");
        gssitestyle = "css/" + stylename + "/style.css";
        gsheadertemplatepath = "template/" + stylename + "/header.ascx";

        //读取当前页站点描述和关键词
        if (!string.IsNullOrEmpty(colid))
        {

        }
        if (string.IsNullOrEmpty(gssitedesc))
        {
            gssitedesc = "\"" + biz.GetKeyValue("SiteDesc", "SITE") + "\"";
        }
        if (string.IsNullOrEmpty(gssitekey))
        {
            gssitekey = "\"" + biz.GetKeyValue("SiteKey", "SITE") + "\"";
        }
    }
}