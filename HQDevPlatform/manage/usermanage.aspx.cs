using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HQLib.Page;
using HQLib.User;
using HQLib.Util;
using HQLib;
using System.Collections.Specialized;
using HQCommon.ML;
using HQCommon.Biz;

namespace HQDevSys.manage
{
    public partial class usermanage : PageBase
    {
        protected int sPageIndex = 1;
        protected int sPageSize = 10;
        protected string sSortName = "FUserId";
        protected string sSortDirection = "ASC";
        protected void Page_Load(object sender, EventArgs e)
        {
            List<SysRole> rolelist = new List<SysRole>();
            SysRoleBiz rolebiz = new SysRoleBiz();
            rolelist = rolebiz.Select();
            AddDatasource("rolelist", rolelist);

            List<SysDepartment> deptlist = new List<SysDepartment>();
            SysDepartmentBiz deptbiz = new SysDepartmentBiz();
            deptlist = deptbiz.Select();
            AddDatasource("deptlist", deptlist);
        }

        public void GetUserDeptList()
        {
            string _userid = Parameters["puserid"];
            List<SysUserDepts> lists = new List<SysUserDepts>();
            SysUserDeptsBiz biz = new SysUserDeptsBiz();
            lists = biz.Select(_userid);
            Response.Write(Utils.ConvertToJson(lists));
        }

        public void GetUserRoleList()
        {
            string _userid = Parameters["puserid"];
            List<SysUserRoles> lists = new List<SysUserRoles>();
            SysUserRolesBiz biz = new SysUserRolesBiz();
            lists = biz.Select(Convert.ToInt64(_userid));
            Response.Write(Utils.ConvertToJson(lists));
        }

        public void SaveUserDept()
        {
            string _userid = Parameters["puserid"];
            string _deptid = Parameters["pdeptid"];
            SysUserDeptsBiz biz = new SysUserDeptsBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            biz.Insert(_userid, _deptid, out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }

        public void SaveUserRole()
        {
            string _userid = Parameters["puserid"];
            string _roleid = Parameters["proleid"];
            SysUserRolesBiz biz = new SysUserRolesBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            int result = biz.SaveRole(_userid, _roleid, out ErrInfo);
            Response.Write(ErrInfo.ToJson());
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
            List<SysUser> lists = new List<SysUser>();
            SysUserBiz biz = new SysUserBiz();
            string _searchtext = _searchcontent;
            string wheresql = "1=1";
            if (string.IsNullOrEmpty(_searchtext))
            {
                wheresql = "(FUserId <> 1)";
            }
            else
            {
                wheresql = "(FUserId <> 1) and ((FUserName like '%" + _searchtext + "%') or (FUserDesc like '%" + _searchtext + "%'))";
            }
            Int32 totalcount = 0;
            lists = biz.Select(wheresql, _sortname, _sortdirection, sPageIndex, sPageSize, out totalcount);
            string datasource = Utils.GetRepeaterDatasource(lists, sPageIndex, sPageSize, totalcount);
            Response.Write(datasource);
        }
        
        public void GetData()
        {
            string _userid = Parameters["puserid"];
            SysUserBiz biz = new SysUserBiz();
            SysUser item = new SysUser();
            item = biz.Select(_userid);
            Response.Write(item.ToJson());
        }

        public void DeleteUser()
        {
            string _idstr = Parameters["pparm"];
            SysUserBiz biz = new SysUserBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            biz.Delete(_idstr, out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }

        public void StartUser()
        {
            string _idstr = Parameters["pparm"];
            SysUserBiz biz = new SysUserBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            biz.UpdateUserStatus(_idstr, "1", out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }

        public void StopUser()
        {
            string _idstr = Parameters["pparm"];
            SysUserBiz biz = new SysUserBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            biz.UpdateUserStatus(_idstr, "0", out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }

        public void RestPsw()
        {
            string _userid = Parameters["puserid"];
            SysUserCodeBiz biz = new SysUserCodeBiz();
            NameValueCollection parm = new NameValueCollection();
            parm.Add("FUserCode", "3FA0346AF9BE74CBD887D24E1C03057B");
            NameValueCollection where = new NameValueCollection();
            where.Add("FUserId", _userid);
            where.Add("FCodeStatus", "1");
            ErrorEntity ErrInfo = new ErrorEntity();
            biz.Update(parm, where, out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }

        public void SaveUser()
        {
            string _userid = Parameters["puserid"];
            string _username = Parameters["pusername"];
            string _userdesc = Parameters["puserdesc"];
            string _email = Parameters["pemail"];
            string _mobile = Parameters["pmobile"];
            string _tel = Parameters["ptel"];
            SysUser item = new SysUser();
            item.FUserId = Convert.ToInt64(_userid);
            item.FUserName = _username;
            item.FUserDesc = _userdesc;
            item.FContactTel = _tel;
            item.FContactMobile = _mobile;
            item.FEmail = _email;
            ErrorEntity ErrInfo = new ErrorEntity();
            SysUserBiz biz = new SysUserBiz();
            if (item.FUserId == 0)
            {
                Int64 iuserid = biz.Insert(item, out ErrInfo);
                //设置口令
                SysUserCodeBiz codebiz = new SysUserCodeBiz();
                NameValueCollection pa = new NameValueCollection();
                pa.Add("FUserId", iuserid.ToString());
                pa.Add("FUserCode", "3FA0346AF9BE74CBD887D24E1C03057B");
                pa.Add("FCodeStatus", "1");
                codebiz.Insert(pa, out ErrInfo);
            }
            else
            {
                biz.Update(item, out ErrInfo);
            }
            Response.Write(ErrInfo.ToJson());
        }

    }
}