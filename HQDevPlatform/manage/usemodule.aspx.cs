using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HQLib.Page;
using HQLib.Function;
using System.Collections.Specialized;
using HQLib.Util;
using HQLib;
using HQLib.Params;
using HQConst.Const;

namespace HQDevSys.manage
{
    public partial class usemodule : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void StartModule()
        {
            string _moduleflag = Parameters["pmoduleflag"];
            SysModuleBiz biz = new SysModuleBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            biz.UpdateStatus(_moduleflag, "1", out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }

        public void StopModule()
        {
            string _moduleflag = Parameters["pmoduleflag"];
            SysModuleBiz biz = new SysModuleBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            biz.UpdateStatus(_moduleflag, "0", out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }

        public void GetGridData()
        {
            string _sortname = Parameters["psortname"];
            string _sortdirection = Parameters["psortdirection"];
            string _pagenumber = Parameters["ppagenumber"];
            string _pagesize = Parameters["ppagesize"];
            List<SysModule> lists = new List<SysModule>();
            SysModuleBiz biz = new SysModuleBiz();
            NameValueCollection where = new NameValueCollection();
            where.Add("condition", "1=1");
            NameValueCollection orderby = new NameValueCollection();
            orderby.Add(_sortname, _sortdirection);
            int totalcount = 0;
            lists = biz.Select(where,orderby,Convert.ToInt32(_pagenumber),Convert.ToInt32(_pagesize),out totalcount);
            Response.Write(Utils.ConvertToJson(lists));

        }
    }
}