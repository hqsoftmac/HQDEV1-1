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
    public partial class navdefine : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<PortalNavStyle> lists = new List<PortalNavStyle>();
                PortalNavStyleBiz biz = new PortalNavStyleBiz();
                lists = biz.Select();
                AddDatasource("stylelist", lists);
            }
        }

        public void SaveStyle()
        {
            string _navid = Parameters["pnavid"];
            string _stylevisible = Parameters["pvisible"];
            string _style = Parameters["pstyle"];
            string _url = Parameters["purl"];
            PortalColumnNavBiz biz = new PortalColumnNavBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            biz.UpdateStyle(_navid, _stylevisible, _style, _url, out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }

        public void DelNav()
        {
            string idlist = Parameters["pparm"];
            PortalColumnNavBiz biz = new PortalColumnNavBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            biz.Delete(idlist, out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }

        public void GetItem()
        {
            string _id = Parameters["pid"];
            PortalColumnNav item = new PortalColumnNav();
            PortalColumnNavBiz biz = new PortalColumnNavBiz();
            item = biz.Select(Convert.ToInt64(_id));
            Response.Write(item.ToJson());
        }

        public void SaveItem()
        {
            string _columnid = Parameters["colid"];
            string _navid = Parameters["pnavid"];
            string _navname = Parameters["pnavname"];
            string _navtype = Parameters["pnavtype"];
            string _navposition = Parameters["pnavposition"];
            string _navvisible = Parameters["pnavvisible"];
            string _order = Parameters["porder"];
            PortalColumnNavBiz biz = new PortalColumnNavBiz();
            PortalColumnNav item = new PortalColumnNav();
            item.FColumnId = Convert.ToInt64(_columnid);
            item.FNavId = Convert.ToInt64(_navid);
            item.FNavName = _navname;
            item.FNavOrder = Convert.ToInt32(_order);
            item.FNavPosition = _navposition;
            item.FNavType = _navtype;
            item.FNavVisible = _navvisible;
            ErrorEntity ErrInfo = new ErrorEntity();
            if (item.FNavId == 0)
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
            string _colid = Parameters["colid"];
            string _search = Parameters["psearchcontent"];
            string _sortname = Parameters["psortname"];
            string _direction = Parameters["psortdirection"];
            string _pagenumber = Parameters["ppagenumber"];
            string _pagesize = Parameters["ppagesize"];
            List<PortalColumnNav> lists = new List<PortalColumnNav>();
            PortalColumnNavBiz biz = new PortalColumnNavBiz();
            string _sql = "(FColumnId =" + _colid + ")";
            if (!string.IsNullOrEmpty(_search))
            {
                _sql += " and (FNavName like '%" + _search + "%')";
            }
            NameValueCollection where = new NameValueCollection();
            where.Add("condition", _sql);
            NameValueCollection orderby = new NameValueCollection();
            orderby.Add(_sortname, _direction);
            Int32 totalcount = 0;
            lists = biz.Select(where, orderby, Convert.ToInt32(_pagenumber), Convert.ToInt32(_pagesize), out totalcount);
            string datasource = Utils.GetRepeaterDatasource(lists, Convert.ToInt32(_pagenumber), Convert.ToInt32(_pagesize), totalcount);
            Response.Write(datasource);
        }
    }
}