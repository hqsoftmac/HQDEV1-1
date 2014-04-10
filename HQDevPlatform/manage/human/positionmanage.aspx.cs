using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HQLib.Page;
using HQPortal.ML;
using HQPortal.Biz;
using System.Collections.Specialized;
using HQLib.Util;
using HQLib;

namespace HQDevSys.manage.human
{
    public partial class positionmanage : PageBase
    {
        protected int sPageIndex = 1;
        protected int sPageSize = 10;
        protected string sSortName = "FPositionId";
        protected string sSortDirection = "DESC";
        protected void Page_Load(object sender, EventArgs e)
        {

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
            List<PortalPosition> lists = new List<PortalPosition>();
            PortalPositionBiz biz = new PortalPositionBiz();
            string _searchtext = _searchcontent;
            string wheresql = "";
            if (!string.IsNullOrEmpty(_searchtext))
            {
                wheresql += "(FPositionName like '%" + _searchtext + "%')";
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

        public void DelPosition()
        {
            string _parm = Parameters["pparm"];
            PortalPositionBiz biz = new PortalPositionBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            biz.Delete(_parm, out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }
    }
}