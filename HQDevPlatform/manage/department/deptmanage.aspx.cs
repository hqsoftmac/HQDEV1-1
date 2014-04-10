using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HQLib.Page;
using HQCommon.ML;
using HQCommon.Biz;
using System.Collections.Specialized;
using HQLib.Util;
using HQLib;

namespace HQDevPlatform.manage.department
{
    public partial class deptmanage : PageBase
    {
        protected int sPageIndex = 1;
        protected int sPageSize = 10;
        protected string sSortName = "FDepartmentCode";
        protected string sSortDirection = "ASC";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SysDepartmentTypeBiz biz = new SysDepartmentTypeBiz();
                List<SysDepartmentType> lists = new List<SysDepartmentType>();
                lists = biz.SelectAll();
                AddDatasource("typelist", lists);
            }
        }

        public void SaveItem()
        {
            string _deptid = Parameters["pdeptid"];
            string _deptcode = Parameters["pdeptcode"];
            string _depttype = Parameters["pdepttype"];
            string _deptname = Parameters["pdeptname"];
            string _deptcharge = Parameters["pdeptcharge"];
            string _depttel = Parameters["pdepttel"];
            string _deptnum = Parameters["pdeptnum"];
            string _content = Parameters["pcontent"];
            SysDepartment item = new SysDepartment();
            item.FDepartmentID = string.IsNullOrEmpty(_deptid) ? 0 : Convert.ToInt64(_deptid);
            item.FDepartmentCode = _deptcode;
            item.FDepartmentName = _deptname;
            item.FDepartmentCharge = _deptcharge;
            item.FDepartmentTypeId = string.IsNullOrEmpty(_depttype) ? 0 : Convert.ToInt64(_depttype);
            item.FDepartmentContent = _content;
            item.FDepartmentTel = _depttel;
            item.FDepartmentNum = string.IsNullOrEmpty(_deptnum) ? 0 : Convert.ToInt32(_deptnum);
            SysDepartmentBiz biz = new SysDepartmentBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            if (item.FDepartmentID == 0)
            {
                biz.Insert(item, out ErrInfo);
            }
            else
            {
                biz.Update(item, out ErrInfo);
            }
            Response.Write(ErrInfo.ToJson());

        }

        public void DelDepartment()
        {
            string idlist = Parameters["pparm"];
            SysDepartmentBiz biz = new SysDepartmentBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            biz.Delete(idlist, out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }

        public void GetDeptItem()
        {
            string _id = Parameters["pid"];
            SysDepartment item = new SysDepartment();
            SysDepartmentBiz biz = new SysDepartmentBiz();
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
            List<SysDepartment> lists = new List<SysDepartment>();
            SysDepartmentBiz biz = new SysDepartmentBiz();
            string _searchtext = _searchcontent;
            string wheresql = "";
            if (!string.IsNullOrEmpty(_searchtext))
            {
                wheresql = " (FDepartmentName like '%" + _searchtext + "%') or (FDepartmentCode like '%" + _searchtext + "%')";
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