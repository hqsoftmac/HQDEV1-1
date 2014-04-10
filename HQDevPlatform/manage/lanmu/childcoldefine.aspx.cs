using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HQLib.Page;
using HQPortal.ML;
using System.Collections.Specialized;
using HQLib.Util;
using HQPortal.Biz;
using HQLib;
using HQConst.Const;

namespace HQDevSys.manage.lanmu
{
    public partial class childcoldefine : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void DelColumn()
        {
            string _idlist = Parameters["pparm"];
            PortalChildColumnBiz biz = new PortalChildColumnBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            PortalChildColumnContentBiz ccbiz = new PortalChildColumnContentBiz();
            NameValueCollection where = new NameValueCollection();
            where.Add("condition","FChildColumnId in (" + _idlist + ")");
            ccbiz.Delete(where, out ErrInfo);
            if (ErrInfo.ErrorCode == RespCode.Success)
            {
                biz.Delete(_idlist, out ErrInfo);
            }
            Response.Write(ErrInfo.ToJson());
        }

        public void GetBackUrl()
        {
            string _navid = Parameters["navid"];
            PortalColumnNav item = new PortalColumnNav();
            PortalColumnNavBiz biz = new PortalColumnNavBiz();
            item = biz.Select(Convert.ToInt64(_navid));
            Response.Write(item.FColumnId.ToString());
        }

        public void SaveItem()
        {
            string _navid = Parameters["navid"];
            string _colid = Parameters["pcolid"];
            string _colname = Parameters["pcolnam"];
            string _coltype = Parameters["pcoltype"];
            string _colurl = Parameters["pcolurl"];
            string _coltarget = Parameters["pcoltarget"];
            string _colvisible = Parameters["pcolvisible"];
            string _colorder = Parameters["pcolorder"];
            PortalChildColumn item = new PortalChildColumn();
            item.FChildColumnId = Convert.ToInt64(_colid);
            item.FChildColumnName = _colname;
            item.FChildColumnOrder = Convert.ToInt32(_colorder);
            item.FChildColumnTarget = _coltarget;
            item.FChildColumnType = _coltype;
            item.FChildColumnUrl = _colurl;
            item.FChildColumnVisible = _colvisible;
            item.FNavId = Convert.ToInt64(_navid);
            PortalChildColumnBiz biz = new PortalChildColumnBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            if (item.FChildColumnId == 0)
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
            string _colid = Parameters["navid"];
            string _search = Parameters["psearchcontent"];
            string _sortname = Parameters["psortname"];
            string _direction = Parameters["psortdirection"];
            string _pagenumber = Parameters["ppagenumber"];
            string _pagesize = Parameters["ppagesize"];
            List<PortalChildColumn> lists = new List<PortalChildColumn>();
            PortalChildColumnBiz biz = new PortalChildColumnBiz();
            string _sql = "(FNavId =" + _colid + ")";
            if (!string.IsNullOrEmpty(_search))
            {
                _sql += " and (FChildColumnName like '%" + _search + "%')";
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