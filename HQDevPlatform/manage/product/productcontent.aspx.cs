using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HQLib.Page;
using HQPortal.Biz;
using HQLib;
using HQPortal.ML;
using System.Collections.Specialized;
using HQLib.Util;

namespace HQDevSys.manage.product
{
    public partial class productcontent : PageBase
    {
        protected int sPageIndex = 1;
        protected int sPageSize = 10;
        protected string sSortName = "FProductId";
        protected string sSortDirection = "ASC";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void DelProduct()
        {
            string _parm = Parameters["pparm"];
            PortalProductBiz biz = new PortalProductBiz();
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
                PortalProductListBiz biz = new PortalProductListBiz();
                biz.GetListName(_id, ref _titlename);
                Response.Write(_titlename);
            }
        }

        public void GetProductList()
        {
            List<PortalProductListTree> lists = new List<PortalProductListTree>();
            List<PortalProductList> lists1 = new List<PortalProductList>();
            PortalProductListBiz biz = new PortalProductListBiz();
            lists1 = biz.Select();
            PortalProductListTreeBiz treebiz = new PortalProductListTreeBiz();
            lists = treebiz.select(lists1);
            PortalProductListTree newitem = new PortalProductListTree();
            newitem.FParentListId = 0;
            newitem.FProductListName = "根目录";
            newitem.FProductListOrder = 10;
            newitem.FParentListId = 0;
            newitem.children = lists;
            List<PortalProductListTree> newlists = new List<PortalProductListTree>();
            newlists.Add(newitem);
            string datasource = treebiz.ConvertToJson(newlists);
            Response.Write(datasource);
        }

        private void Getwheresql(string _listid, ref string _sqlwhere)
        {
            if (!string.IsNullOrEmpty(_sqlwhere))
            {
                _sqlwhere += " or ";
            }
            _sqlwhere += "(FProductListID =" + _listid + ")";
            NameValueCollection where = new NameValueCollection();
            where.Add("FParentListId", _listid);
            PortalProductListBiz biz = new PortalProductListBiz();
            List<PortalProductList> lists = new List<PortalProductList>();
            lists = biz.Select(where);
            foreach (PortalProductList item in lists)
            {
                Getwheresql(item.FProductListID.ToString(), ref _sqlwhere);
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
            List<PortalProduct> lists = new List<PortalProduct>();
            PortalProductBiz biz = new PortalProductBiz();
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