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
    public partial class articlecontent : PageBase
    {
        protected int sPageIndex = 1;
        protected int sPageSize = 10;
        protected string sSortName = "FArticleId";
        protected string sSortDirection = "ASC";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void DelArticle()
        {
            string _parm = Parameters["pparm"];
            PortalArticleBiz biz = new PortalArticleBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            biz.Delete(_parm, out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }

        public void GetListTitleName()
        {
            string _id = Parameters["plistid"];
            if (string.IsNullOrEmpty(_id) || _id == "0")
            {
                Response.Write("根目录");
            }
            else
            {
                string _titlename = "";
                PortalArticleListBiz biz = new PortalArticleListBiz();
                biz.GetListName(_id, ref _titlename);
                Response.Write(_titlename);
            }
        }

        public void GetArticleList()
        {
            List<PortalArticleListTree> lists = new List<PortalArticleListTree>();
            List<PortalArticleList> lists1 = new List<PortalArticleList>();
            PortalArticleListBiz biz = new PortalArticleListBiz();
            lists1 = biz.Select();
            PortalArticleListTreeBiz treebiz = new PortalArticleListTreeBiz();
            lists = treebiz.select(lists1);
            PortalArticleListTree newitem = new PortalArticleListTree();
            newitem.FListId = 0;
            newitem.FListCode = "";
            newitem.FListName = "根目录";
            newitem.FListOrder = 10;
            newitem.FParentListId = 0;
            newitem.children = lists;
            List<PortalArticleListTree> newlists = new List<PortalArticleListTree>();
            newlists.Add(newitem);
            string datasource = treebiz.ConvertToJson(newlists);
            Response.Write(datasource);
        }

        public void Recommend()
        {
            string _id = Parameters["pid"];
            PortalArticleBiz biz = new PortalArticleBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            biz.UpdateStatus(_id, "1", out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }

        public void UnRecommend()
        {
            string _id = Parameters["pid"];
            PortalArticleBiz biz = new PortalArticleBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            biz.UpdateStatus(_id, "0", out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }

        private void Getwheresql(string _listid, ref string _sqlwhere)
        {
            if (!string.IsNullOrEmpty(_sqlwhere))
            {
                _sqlwhere += " or ";
            }
            _sqlwhere += "(FListId =" + _listid + ")";
            NameValueCollection where = new NameValueCollection();
            where.Add("FParentListId", _listid);
            PortalArticleListBiz biz = new PortalArticleListBiz();
            List<PortalArticleList> lists = new List<PortalArticleList>();
            lists = biz.Select(where);
            foreach (PortalArticleList item in lists)
            {
                Getwheresql(item.FListId.ToString(), ref _sqlwhere);
            }
        }

        public void GetGridData()
        {
            string _sortname = "";
            string _sortdirection = "";
            string _pagenumber = "";
            string _pagesize = "";
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
            List<PortalArticle> lists = new List<PortalArticle>();
            PortalArticleBiz biz = new PortalArticleBiz();
            string listid = Parameters["plistid"];
            string wheresql = "";
            if (listid == "0" || string.IsNullOrEmpty(listid))
            {
                wheresql = "1=1";
            }
            else
            {
                //历遍下级listid
                Getwheresql(listid, ref wheresql);
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