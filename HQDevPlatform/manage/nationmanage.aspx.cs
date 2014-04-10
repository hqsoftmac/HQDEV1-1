using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HQLib.Page;
using HQCommon.ML;
using HQCommon.Biz;
using System.Collections.Specialized;
using HQLib.Util;
using HQLib;

namespace HQDevPlatform.manage
{
    public partial class nationmanage : PageBase
    {
        protected int sPageIndex = 1;
        protected int sPageSize = 10;
        protected string sSortName = "FNationOrder";
        protected string sSortDirection = "ASC";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void GetNationItem()
        {
            string _id = Parameters["pid"];
            SysNationBiz biz = new SysNationBiz();
            SysNation item = new SysNation();
            item = biz.Select(_id);
            if (item == null)
            {
                Response.Write("");
            }
            else
            {
                Response.Write(item.ToJson());
            }
        }

        public void DelNation()
        {
            string _parm = Parameters["pparm"];
            SysNationBiz biz = new SysNationBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            biz.Delete(_parm, out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }

        public void SaveItem()
        {
            string _nationid = Parameters["pnationid"];
            string _nationname = Parameters["pnationname"];
            string _nationorder = Parameters["pnationorder"];
            SysNationBiz biz = new SysNationBiz();
            SysNation item = new SysNation();
            item.FNationID = string.IsNullOrEmpty(_nationid) ? 0 : Convert.ToInt64(_nationid);
            item.FNationName = _nationname;
            item.FNationOrder = string.IsNullOrEmpty(_nationorder) ? 0 : Convert.ToInt32(_nationorder);
            ErrorEntity ErrInfo = new ErrorEntity();
            if (item.FNationID == 0)
            {
                biz.Insert(item, out ErrInfo);
            }
            else
            {
                biz.Update(item, out ErrInfo);
            }
            Response.Write(ErrInfo.ToJson());
        }

        public void GetGridData()
        {
            string _searchcontent = "";
            string _sortname = "";
            string _sortdirection = "";
            string _pagenumber = "";
            string _pagesize = "";
            _searchcontent = Parameters["psearchcontent"];
            _sortname = Parameters["psortname"];
            if (!string.IsNullOrEmpty(_sortname))
            {
                sSortName = _sortname;
            }
            _sortdirection = Parameters["psortdirection"];
            if (!string.IsNullOrEmpty(_sortdirection))
            {
                sSortDirection = _sortdirection;
            }
            _pagenumber = Parameters["ppagenumber"];
            if (!string.IsNullOrEmpty(_pagenumber))
            {
                sPageIndex = Convert.ToInt32(_pagenumber);
            }
            _pagesize = Parameters["ppagesize"];
            if (!string.IsNullOrEmpty(_pagesize))
            {
                sPageSize = Convert.ToInt32(_pagesize);
            }
            List<SysNation> lists = new List<SysNation>();
            SysNationBiz biz = new SysNationBiz();
            string _searchtext = _searchcontent;
            string wheresql = "";
            if (!string.IsNullOrEmpty(_searchtext))
            {
                wheresql = "(FNationName like '%" + _searchtext + "%')";
            }
            else
            {
                wheresql = "1=1";
            }
            NameValueCollection where = new NameValueCollection();
            where.Add("condition", wheresql);
            NameValueCollection orderby = new NameValueCollection();
            orderby.Add(_sortname, _sortdirection);
            Int32 totalcount = 0;
            lists = biz.Select(where, orderby, Convert.ToInt32(sPageIndex), Convert.ToInt32(sPageSize), out totalcount);
            string datasource = Utils.GetRepeaterDatasource(lists, sPageIndex, sPageSize, totalcount);
            Response.Write(datasource);
        }
    }
}