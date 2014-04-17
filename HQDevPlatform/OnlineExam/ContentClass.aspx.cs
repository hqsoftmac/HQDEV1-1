using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HQLib.Page;
using HQOnlineExam.ML;
using HQLib;
using HQOnlineExam.Biz;
using HQLib.Util;
using System.Collections.Specialized;

namespace HQDevPlatform.OnlineExam
{
    public partial class ContentClass : PageBase
    {
        protected int sPageIndex = 1;
        protected int sPageSize = 10;
        protected string sSortName = "FContentClassCode";
        protected string sSortDirection = "ASC";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void GetNowParent()
        {
            string _id = Parameters["pid"];
            OEContentClass item = new OEContentClass();
            OEContentClassBiz biz = new OEContentClassBiz();
            item = biz.Select(_id);
            Response.Write(item.FParentId.ToString());
        }

        public void SaveItem()
        {
            string _FContentClassId = Parameters["pFContentClassId"];
            // other paramters fill here
            string _FContentClassCode = Parameters["pFContentClassCode"];
            string _FContentClassName = Parameters["pFContentClassName"];
            string _FContentClassContent = Parameters["pFContentClassContent"];
            string _FIconPath = Parameters["pFIconPath"];
            string _FParentId = Parameters["pFParentId"];

            OEContentClass item = new OEContentClass();
            item.FContentClassId = string.IsNullOrEmpty(_FContentClassId) ? 0 : Convert.ToInt64(_FContentClassId);
            item.FContentClassCode = _FContentClassCode;
            item.FContentClassName = _FContentClassName;
            item.FContentClassContent = _FContentClassContent;
            item.FIconPath = _FIconPath;
            item.FParentId = string.IsNullOrEmpty(_FParentId) ? 0 : Convert.ToInt64(_FParentId);
            OEContentClassBiz biz = new OEContentClassBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            if (item.FContentClassId == 0)
            {
                biz.Insert(item, out ErrInfo);
            }
            else
            {
                biz.Update(item, out ErrInfo);
            }
            Response.Write(ErrInfo.ToJson());

        }

        public void DelData()
        {
            string idlist = Parameters["pparm"];
            OEContentClassBiz biz = new OEContentClassBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            biz.Delete(idlist, out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }

        public void GetItem()
        {
            string _id = Parameters["pid"];
            OEContentClass item = new OEContentClass();
            OEContentClassBiz biz = new OEContentClassBiz();
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
            List<OEContentClass> lists = new List<OEContentClass>();
            OEContentClassBiz biz = new OEContentClassBiz();
            string _searchtext = _searchcontent;
            string wheresql = "";
            string _parentid = Parameters["pparentid"];
            wheresql = "(FParentId = " + _parentid + ")";
            if (!string.IsNullOrEmpty(_searchtext))
            {
                //difine wheresql
                //for example:wheresql = " (FDepartmentName like '%" + _searchtext + "%') or (FDepartmentCode like '%" + _searchtext + "%')";
                wheresql += " and (FContentClassName like '%" + _searchcontent + "%')";
            }
            else
            {
                wheresql += " and (1=1)";
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