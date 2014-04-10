using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HQLib.Page;
using HQPartyManage.ML;
using HQPartyManage.Biz;
using System.Collections.Specialized;
using HQLib.Util;
using HQLib;
using HQCommon.ML;
using HQCommon.Biz;

namespace HQDevPlatform.partymember.org
{
    public partial class orgmember : PageBase
    {

        protected int sPageIndex = 1;
        protected int sPageSize = 10;
        protected string sSortName = "FLeaderId";
        protected string sSortDirection = "ASC";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<SysDepartment> deptlist = new List<SysDepartment>();
                SysDepartmentBiz deptbiz = new SysDepartmentBiz();
                deptlist = deptbiz.SelectDeptByUser(userid);
                AddDatasource("deptlist", deptlist);
            }
        }

        public void SaveItem()
        {
            string _FLeaderId = Parameters["pFLeaderId"];
            // other paramters fill here
            string _name = Parameters["pName"];
            string _position = Parameters["pPosition"];
            string _order = Parameters["pOrder"];
            string _deptid = Parameters["pDeptid"];
            PmOrgLeader item = new PmOrgLeader();
            item.FLeaderId = string.IsNullOrEmpty(_FLeaderId) ? 0 : Convert.ToInt64(_FLeaderId);
            item.FOrgId = Convert.ToInt64(_deptid);
            item.FLeaderName = _name;
            item.FLeaderPostion = _position;
            item.FLeaderOrder = string.IsNullOrEmpty(_order) ? 0 : Convert.ToInt32(_order);
            PmOrgLeaderBiz biz = new PmOrgLeaderBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            if (item.FLeaderId == 0)
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
            PmOrgLeaderBiz biz = new PmOrgLeaderBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            biz.Delete(idlist, out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }

        public void GetItem()
        {
            string _id = Parameters["pid"];
            PmOrgLeader item = new PmOrgLeader();
            PmOrgLeaderBiz biz = new PmOrgLeaderBiz();
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
            string _deptid = Parameters["pdeptid"];

            List<PmOrgLeader> lists = new List<PmOrgLeader>();
            PmOrgLeaderBiz biz = new PmOrgLeaderBiz();
            string _searchtext = _searchcontent;
            string wheresql = "(FOrgId = " + _deptid + ")";
            if (!string.IsNullOrEmpty(_searchtext))
            {
                //difine wheresql
                //for example:wheresql = " (FDepartmentName like '%" + _searchtext + "%') or (FDepartmentCode like '%" + _searchtext + "%')";
                wheresql += "(FLeaderName like '%" + _searchtext + "%')";
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