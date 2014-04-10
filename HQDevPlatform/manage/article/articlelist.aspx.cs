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

namespace HQDevSys.manage.article
{
    public partial class articlelist : PageBase
    {
        protected int sPageIndex = 1;
        protected int sPageSize = 10;
        protected string sSortName = "FListOrder";
        protected string sSortDirection = "ASC";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void GetListItem()
        {
            string id = Parameters["pid"];
            PortalArticleListBiz biz = new PortalArticleListBiz();
            PortalArticleList item = new PortalArticleList();
            item = biz.Select(id);
            Response.Write(item.ToJson());
        }


        public void DelList()
        {
            string idlist = Parameters["pparm"];
            PortalArticleListBiz biz = new PortalArticleListBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            biz.Delete(idlist, out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }

        public void SaveItem()
        {
            string _id = Parameters["plistid"];
            string _name = Parameters["plistname"];
            string _parentid = Parameters["pparentid"];
            string _order = Parameters["porder"];
            PortalArticleList item = new PortalArticleList();
            item.FListId = Convert.ToInt64(_id);
            item.FListName = _name; 
            item.FListOrder = Convert.ToInt32(_order);
            item.FParentListId = Convert.ToInt64(_parentid);
            PortalArticleListBiz biz = new PortalArticleListBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            if (item.FListId == 0)
            {   
                biz.Insert(item, out ErrInfo);
            }
            else
            {
                biz.Update(item, out ErrInfo);
            }
            Response.Write(ErrInfo.ToJson());
        }

        public void GetParentId()
        {
            string id = Parameters["pchildid"];
            PortalArticleListBiz biz = new PortalArticleListBiz();
            PortalArticleList item = new PortalArticleList();
            item = biz.Select(id);
            if (item == null)
            {
                Response.Write("0");
            }
            else
            {
                if (string.IsNullOrEmpty(item.FParentListId.ToString()))
                {
                    Response.Write("0");
                }
                else
                {
                    Response.Write(item.FParentListId.ToString());
                }
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
            List<PortalArticleList> lists = new List<PortalArticleList>();
            PortalArticleListBiz biz = new PortalArticleListBiz();
            string _searchtext = _searchcontent;
            string _parentid = Parameters["pparentid"];
            string wheresql = "";
            if (string.IsNullOrEmpty(_parentid) || _parentid == "0")
            {
                wheresql = "(FParentListId is null)";
            }
            else
            {
                wheresql = "(FParentListId = " + _parentid + ")";
            }
            if (!string.IsNullOrEmpty(_searchtext))
            {
                wheresql += " and (FListName like '%" + _searchtext + "%')";
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