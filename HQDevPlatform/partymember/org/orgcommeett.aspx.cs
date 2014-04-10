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

namespace HQDevPlatform.partymember.org
{
    public partial class orgcommeett : PageBase
    {
        protected int sPageIndex = 1;
        protected int sPageSize = 10;
        protected string sSortName = "FCommitteeOrder";
        protected string sSortDirection = "ASC";
        protected string gsorgname = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string _orgid = Parameters["orgid"];
            PmOrgInfoBiz biz = new PmOrgInfoBiz();
            biz.GetParentOrgName(_orgid, ref gsorgname);
        }

        public void SaveItem()
        {
            string _FCommitteeID = Parameters["pFCommitteeID"];
            // other paramters fill here
            string _name = Parameters["pName"];
            string _position = Parameters["pPosition"];
            string _mobile = Parameters["pMobile"];
            string _tel = Parameters["pTel"];
            string _order = Parameters["pOrder"];
            string _orgid = Parameters["orgid"];
            PmOrgCommittee item = new PmOrgCommittee();
            item.FCommitteeID = string.IsNullOrEmpty(_FCommitteeID) ? 0 : Convert.ToInt64(_FCommitteeID);
            item.FCommitteeName = _name;
            item.FCommitteePosition = _position;
            item.FCommitteeMobile = _mobile;
            item.FCommitteeTel = _tel;
            item.FCommitteeOrder = string.IsNullOrEmpty(_order) ? 0 : Convert.ToInt32(_order);
            item.FOrgId = Convert.ToInt64(_orgid);
            PmOrgCommitteeBiz biz = new PmOrgCommitteeBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            if (item.FCommitteeID == 0)
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
            PmOrgCommitteeBiz biz = new PmOrgCommitteeBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            biz.Delete(idlist, out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }

        public void GetItem()
        {
            string _id = Parameters["pid"];
            PmOrgCommittee item = new PmOrgCommittee();
            PmOrgCommitteeBiz biz = new PmOrgCommitteeBiz();
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
            List<PmOrgCommittee> lists = new List<PmOrgCommittee>();
            PmOrgCommitteeBiz biz = new PmOrgCommitteeBiz();
            string _searchtext = _searchcontent;
            string wheresql = "";
            if (!string.IsNullOrEmpty(_searchtext))
            {
                //difine wheresql
                wheresql = " (FCommitteeName like '%" + _searchtext + "%')";

            }
            else
            {
                wheresql = "1=1";
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