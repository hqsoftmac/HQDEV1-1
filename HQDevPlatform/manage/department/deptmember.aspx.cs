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
    public partial class deptmember : PageBase
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

                List<SysNation> nationlist = new List<SysNation>();
                SysNationBiz nationbiz = new SysNationBiz();
                nationlist = nationbiz.Select();
                AddDatasource("nationlist", nationlist);


                List<SysEducation> educationlist = new List<SysEducation>();
                SysEducationBiz edbiz = new SysEducationBiz();
                educationlist = edbiz.Select();
                AddDatasource("educationlist", educationlist);
            }
        }

        public void GetPic()
        {
            string _id = Parameters["pid"];
            SysMember item = new SysMember();
            SysMemberBiz biz = new SysMemberBiz();
            item = biz.Select(_id);
            if (item == null)
            {
                Response.Write("../../images/defphoto.png");
            }
            else
            {
                Response.Write(item.FPicPathStr);
            }
        }

        public void SavePic()
        {
            string _id = Parameters["pid"];
            string _path = Parameters["ppath"];
            NameValueCollection para = new NameValueCollection();
            para.Add("FPicPath", _path);
            NameValueCollection where = new NameValueCollection();
            where.Add("FMemberId", _id);
            ErrorEntity ErrInfo = new ErrorEntity();
            SysMemberBiz biz = new SysMemberBiz();
            biz.Update(para, where, out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }

        public void StopData()
        {
            string _id = Parameters["pparm"];
            SysMemberBiz biz = new SysMemberBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            biz.Stop(_id, out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }

        public void StartData()
        {
            string _id = Parameters["pparm"];
            SysMemberBiz biz = new SysMemberBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            biz.Start(_id, out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }

        public void SaveItem()
        {
            string _FMemberId = Parameters["pFMemberId"];
            // other paramters fill here
            string _FMemberCode = Parameters["pFMemberCode"];
            string _FMemberName = Parameters["pFMemberName"];
            string _FEductionId = Parameters["pFEductionId"];
            string _FNationId = Parameters["pFNationId"];
            string _FDepartmentId = Parameters["pFDepartmentId"];
            string _FMemberGendor = Parameters["pFMemberGendor"];
            string _FBirthDate = Parameters["pFBirthDate"];
            string _FPosition = Parameters["pFPosition"];
            string _FMobile = Parameters["pFMobile"];
            string _FIDNumber = Parameters["pFIDNumber"];
            string _FPicPath = Parameters["pFPicPath"];
            SysMember item = new SysMember();
            item.FMemberId = string.IsNullOrEmpty(_FMemberId) ? 0 : Convert.ToInt64(_FMemberId);
            item.FBirthDate = string.IsNullOrEmpty(_FBirthDate) ? new DateTime() : Convert.ToDateTime(_FBirthDate);
            item.FDepartmentId = string.IsNullOrEmpty(_FDepartmentId) ? 0 : Convert.ToInt64(_FDepartmentId);
            item.FEductionId = string.IsNullOrEmpty(_FEductionId) ? 0 : Convert.ToInt64(_FEductionId);
            item.FIDNumber = _FIDNumber;
            item.FMemberCode = _FMemberCode;
            item.FMemberGendor = _FMemberGendor;
            item.FMemberName = _FMemberName;
            item.FMobile = _FMobile;
            item.FNationId = string.IsNullOrEmpty(_FNationId) ? 0 : Convert.ToInt64(_FNationId);
            item.FPicPath = _FPicPath;
            item.FPosition = _FPosition;
            SysMemberBiz biz = new SysMemberBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            if (item.FMemberId == 0)
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
            SysMemberBiz biz = new SysMemberBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            biz.Delete(idlist, out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }

        public void GetItem()
        {
            string _id = Parameters["pid"];
            SysMember item = new SysMember();
            SysMemberBiz biz = new SysMemberBiz();
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
            _deptid = Parameters["pdeptid"];
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
            List<SysMember> lists = new List<SysMember>();
            SysMemberBiz biz = new SysMemberBiz();
            string _searchtext = _searchcontent;
            string wheresql = "";
            if (string.IsNullOrEmpty(_deptid) || _deptid == "0")
            {
                if (userid != "1")
                {
                    SysUserDeptsBiz udbiz = new SysUserDeptsBiz();
                    string deptidlist = udbiz.GetUserDeptList(userid);
                    if (string.IsNullOrEmpty(deptidlist))
                    {
                        wheresql = "(FDepartmentId in (0))";
                    }
                    else
                    {
                        wheresql = "(FDepartmentId in (" + deptidlist + "))";
                    }
                }
                else
                {
                    wheresql = "1=1";
                }
            }
            else
            {
                wheresql = "(FDepartmentId = " + _deptid + ")";
            }
            if (!string.IsNullOrEmpty(_searchtext))
            {
                wheresql = " and ((FMemberName like '%" + _searchtext + "%') or (FMemberCode like '%" + _searchtext + "%'))";
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