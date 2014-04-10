using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HQLib.Page;
using HQPortal.ML;
using HQPortal.Biz;
using HQLib;

namespace HQDevSys.manage.lanmu
{
    public partial class childcolcontent : PageBase
    {
        protected string gstitle = string.Empty;
        protected string gskeyword = string.Empty;
        protected string gsdescription = string.Empty;
        protected string gscontent = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string _ccolid = Parameters["ccolid"];
                PortalChildColumnContent item = new PortalChildColumnContent();
                PortalChildColumnContentBiz biz = new PortalChildColumnContentBiz();
                item = biz.SelectByChildColumnId(_ccolid);
                if (item != null)
                {
                    gstitle = item.FSEOTitle;
                    gskeyword = item.FSEOKeyWord;
                    gsdescription = item.FSEODescription;
                    gscontent = item.FCCContentText;
                }
            }
        }

        public void SaveContent()
        {
            string _ccolid = Parameters["ccolid"];
            string _title = Parameters["ptitle"];
            string _keyword = Parameters["pkeyword"];
            string _description = Parameters["pdescription"];
            string _content = Parameters["pcontent"];
            PortalChildColumnContent item = new PortalChildColumnContent();
            item.FChildColumnId = Convert.ToInt64(_ccolid);
            item.FSEOTitle = _title;
            item.FSEOKeyWord = _keyword;
            item.FSEODescription = _description;
            item.FCCContentText = _content;
            PortalChildColumnContentBiz biz = new PortalChildColumnContentBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            biz.Save(item, out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }

        public void GetBackUrl()
        {
            string _id = Parameters["ccolid"];
            PortalChildColumn item = new PortalChildColumn();
            PortalChildColumnBiz biz = new PortalChildColumnBiz();
            item = biz.Select(Convert.ToInt64(_id));
            if (item == null)
            {
                Response.Write("0");
            }
            else
            {
                Response.Write(item.FNavId.ToString());
            }
        }
    }
}