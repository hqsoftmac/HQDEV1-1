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

namespace HQDevSys.manage.lanmu
{
    public partial class lanmuset : PageBase
    {
        protected int sPageIndex = 1;
        protected int sPageSize = 10;
        protected string sSortName = "FColumnOrder";
        protected string sSortDirection = "ASC";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void DelColumn()
        {
            string idlist = Parameters["pparm"];
            PortalColumnBiz biz = new PortalColumnBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            biz.Delete(idlist, out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }

        public void SaveItem()
        {
            string _columnid = Parameters["pcolumnid"];
            string _columnname = Parameters["pcolumnname"];
            string _columncontent = Parameters["pcolumncontent"];
            string _columntype = Parameters["pcolumntype"];
            string _columnurl = Parameters["pcolumnurl"];
            string _columntarget = Parameters["pcolumntarget"];
            string _columnvisible = Parameters["pcolumnvisible"];
            string _parentid = Parameters["pparentid"];
            string _order = Parameters["pcolumnorder"];
            PortalColumnBiz biz = new PortalColumnBiz();
            PortalColumn item = new PortalColumn();
            item.FColumnId = string.IsNullOrEmpty(_columnid) ? 0 : Convert.ToInt64(_columnid);
            item.FColumnName = _columnname;
            item.FColumnContent = _columncontent;
            item.FColumnType = _columntype;
            item.FColumnUrl = _columnurl;
            item.FColumnTarget = _columntarget;
            item.FColumnVisible = _columnvisible;
            item.FParentColumnId = string.IsNullOrEmpty(_parentid) ? 0 : Convert.ToInt64(_parentid);
            item.FColumnOrder = Convert.ToInt32(_order);
            ErrorEntity ErrInfo = new ErrorEntity();
            if (item.FColumnId == 0)
            {
                biz.Insert(item, out ErrInfo);
            }
            else
            {
                biz.Update(item, out ErrInfo);
            }
            Response.Write(ErrInfo.ToJson());
        }

        public void GetColumnItem()
        {
            string id = Parameters["pid"];
            PortalColumnBiz biz = new PortalColumnBiz();
            PortalColumn item = new PortalColumn();
            item = biz.Select(id);
            Response.Write(item.ToJson());
        }

        public void GetParentId()
        {
            string id = Parameters["pchildid"];
            PortalColumnBiz biz = new PortalColumnBiz();
            PortalColumn item = new PortalColumn();
            item = biz.Select(id);
            if (item == null)
            {
                Response.Write("0");
            }
            else
            {
                if(string.IsNullOrEmpty(item.FParentColumnId.ToString()))
                {
                    Response.Write("0");
                }
                else
                {
                    Response.Write(item.FParentColumnId.ToString());
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
            List<PortalColumn> lists = new List<PortalColumn>();
            PortalColumnBiz biz = new PortalColumnBiz();
            string _searchtext = _searchcontent;
            string _parentid = Parameters["pparentid"];
            string wheresql = "";
            if (string.IsNullOrEmpty(_parentid) || _parentid == "0")
            {
                wheresql = "(FParentColumnId is null)";
            }
            else
            {
                wheresql = "(FParentColumnId = " + _parentid + ")";
            }
            if (!string.IsNullOrEmpty(_searchtext))
            {
                wheresql += " and (FRoleName like '%" + _searchtext + "%')";
            }
            NameValueCollection where = new NameValueCollection();
            where.Add("condition", wheresql);
            NameValueCollection orderby = new NameValueCollection();
            orderby.Add(_sortname, _sortdirection);
            Int32 totalcount = 0;
            lists = biz.Select(where,orderby,Convert.ToInt32(sPageIndex), Convert.ToInt32(sPageSize), out totalcount);
            string datasource = Utils.GetRepeaterDatasource(lists, sPageIndex, sPageSize, totalcount);
            Response.Write(datasource);
        }
    }
}