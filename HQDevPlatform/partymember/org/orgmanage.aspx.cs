using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HQLib.Page;
using HQPartyManage.ML;
using HQPartyManage.Biz;
using HQLib;
using System.Collections.Specialized;
using HQLib.Util;
using HQCommon.ML;
using HQCommon.Biz;
using HQLib.Common;

namespace HQDevPlatform.partymember.org
{
    public partial class orgmanage : PageBase
    {
        protected int sPageIndex = 1;
        protected int sPageSize = 10;
        protected string sSortName = "FOrgId";
        protected string sSortDirection = "ASC";
        protected string parentorgname = "";
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

        public void GetNowParent()
        {
            string _id = Parameters["pid"];
            PmOrgInfo item = new PmOrgInfo();
            PmOrgInfoBiz biz = new PmOrgInfoBiz();
            item = biz.Select(_id);
            if (item == null)
            {
                Response.Write("0");
            }
            else
            {
                Response.Write(item.FParentOrgId.ToString());
            }
        }
        
        public void SaveItem()
        {
            string _FOrgId = Parameters["pFOrgId"];
            // other paramters fill here
            string _orgname = Parameters["pFOrgName"];
            string _deptid = Parameters["pDeptId"];
            string _orgtype = Parameters["pFOrgType"];
            string _order = Parameters["pOrder"];
            string _parentid = Parameters["pParentId"];
            string _newdate = Parameters["pNewDate"];
            PmOrgInfo item = new PmOrgInfo();
            item.FOrgId = string.IsNullOrEmpty(_FOrgId) ? 0 : Convert.ToInt64(_FOrgId);
            item.FDepartmentID = Convert.ToInt64(_deptid);
            item.FOrgName = _orgname;
            item.FOrgType = _orgtype;
            item.FParentOrgId = Convert.ToInt32(_parentid);
            item.FOrgOrder = Convert.ToInt32(_order);
            item.FOrgNewDate = Convert.ToDateTime(_newdate);
            PmOrgInfoBiz biz = new PmOrgInfoBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            if (item.FOrgId == 0)
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
            PmOrgInfoBiz biz = new PmOrgInfoBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            biz.Delete(idlist, out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }

        public void GetItem()
        {
            string _id = Parameters["pid"];
            PmOrgInfo item = new PmOrgInfo();
            PmOrgInfoBiz biz = new PmOrgInfoBiz();
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
            string _deptid = "";
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
            _deptid = Parameters["pdeptid"];
            string _parentid = Parameters["pparentid"];
            List<PmOrgInfo> lists = new List<PmOrgInfo>();
            PmOrgInfoBiz biz = new PmOrgInfoBiz();
            biz.GetParentOrgName(_parentid, ref parentorgname);
            string _searchtext = _searchcontent;
            string wheresql = "(FDepartmentID = " + _deptid + ") and (FParentOrgId = " + _parentid + ") ";
            if (!string.IsNullOrEmpty(_searchtext))
            {
                //difine wheresql
                wheresql += " and (FOrgName like '%" + _searchtext + "%')";
            }
            NameValueCollection where = new NameValueCollection();
            where.Add("condition", wheresql);
            NameValueCollection orderby = new NameValueCollection();
            orderby.Add(_sortname, _sortdirection);
            Int32 totalcount = 0;
            lists = biz.Select(where, orderby, Convert.ToInt32(sPageIndex), Convert.ToInt32(sPageSize), out totalcount);
            string datasource = Utils.GetRepeaterDatasource(lists, sPageIndex, sPageSize, totalcount);
            Response.Write(parentorgname + "|]" + datasource);
        }
    }
}