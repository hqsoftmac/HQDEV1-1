using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HQLib.Page;
using HQCommon.ML;
using HQCommon.Biz;
using HQPartyManage.Biz;
using HQLib;
using HQPartyManage.ML;
using System.Collections.Specialized;
using HQLib.Util;

namespace HQDevPlatform.partymember.party
{
    public partial class prepartymanage : PageBase
    {
        protected int sPageIndex = 1;
        protected int sPageSize = 10;
        protected string sSortName = "FMemberCode";
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

        public void GetOrgTree()
        {
            string _deptid = Parameters["pdeptid"];
            PmOrgInfoTreeBiz biz = new PmOrgInfoTreeBiz();
            Response.Write(biz.JsonSelectByDeptId(_deptid));
        }

        public void DelItem()
        {
            string _id = Parameters["pid"];
            string _date = (new DateTime()).ToString();
            PmPartymemberBiz biz = new PmPartymemberBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            biz.UpdatePreParty(_id, "0", _date, "", out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }

        public void SetPreparty()
        {
            string _memberid = Parameters["pmemberid"];
            string _date = Parameters["pdate"];
            string _orgid = Parameters["porgid"];
            PmPartymemberBiz biz = new PmPartymemberBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            biz.UpdatePreParty(_memberid, "1", _date, _orgid, out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }

        public void GetDeptMember()
        {
            string _deptid = Parameters["pdeptid"];
            string _content = Parameters["psearchtext"];
            List<PmPartymember> lists = new List<PmPartymember>();
            PmPartymemberBiz biz = new PmPartymemberBiz();
            NameValueCollection where = new NameValueCollection();
            where.Add("FActivistFlag", "1");
            where.Add("FObjectFlag", "1");
            where.Add("FPrePartyFlag", "0");
            where.Add("FPartyFlag", "0");
            where.Add("FHistoryFlag", "0");
            where.Add("FDepartmentId", _deptid);
            if (!string.IsNullOrEmpty(_content))
            {
                where.Add("FMemberName like", "%" + _content + "%");
            }
            NameValueCollection orderby = new NameValueCollection();
            orderby.Add("FMemberCode", "ASC");
            lists = biz.Select(where, orderby);
            Response.Write(Utils.ConvertToJson(lists));
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
            List<PmPartymember> lists = new List<PmPartymember>();
            PmPartymemberBiz biz = new PmPartymemberBiz();
            string _searchtext = _searchcontent;
            string wheresql = "(FActivistFlag = '1') and (FObjectFlag = '1') and (FPrePartyFlag = '1') and (FPartyFlag = '0') and (FHistoryFlag = '0') ";
            string _deptid = Parameters["pdeptid"];
            if (string.IsNullOrEmpty(_deptid) || _deptid == "0")
            {
                if (userid != "1")
                {
                    SysUserDeptsBiz udbiz = new SysUserDeptsBiz();
                    string deptidlist = udbiz.GetUserDeptList(userid);
                    if (string.IsNullOrEmpty(deptidlist))
                    {
                        wheresql += " and  (FDepartmentId in (0))";
                    }
                    else
                    {
                        wheresql += " and (FDepartmentId in (" + deptidlist + "))";
                    }
                }
            }
            else
            {
                wheresql += "(FDepartmentId = " + _deptid + ")";
            }

            if (!string.IsNullOrEmpty(_searchtext))
            {
                //difine wheresql
                wheresql += " and (FMemberName like '%" + _searchtext + "%')";

                //for example:wheresql = " (FDepartmentName like '%" + _searchtext + "%') or (FDepartmentCode like '%" + _searchtext + "%')";

            }
            NameValueCollection where = new NameValueCollection();
            where.Add("condition", wheresql);
            NameValueCollection orderby = new NameValueCollection();
            orderby.Add(_sortname, _sortdirection);
            Int32 totalcount = 0;
            lists = biz.Select(where, orderby, Convert.ToInt32(sPageIndex), Convert.ToInt32(sPageSize), out totalcount);
            for (int i = 0; i < lists.Count; i++)
            {
                lists[i].FOperation = "<a iconCls='icon-remove' class='btn' href='javascript:void(0)' onclick='delpre(" + lists[i].FMemberId.ToString() + ")'>取消资格</a>";
                lists[i].FOperation += "&nbsp;&nbsp;<a iconCls='icon-remove' class='btn' href='javascript:void(0)' onclick='delaypre(" + lists[i].FMemberId.ToString() + ")'>延长预备期</a>";
            }
            string datasource = Utils.GetRepeaterDatasource(lists, sPageIndex, sPageSize, totalcount);
            Response.Write(datasource);
        }
    }
}