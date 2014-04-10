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
using HQLib.Function;

namespace HQDevSys.manage
{
    public partial class rolemanage : PageBase
    {
        protected int sPageIndex = 1;
        protected int sPageSize = 10;
        protected string sSortName = "FRoleId";
        protected string sSortDirection = "ASC";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<SysFunList> lists = new List<SysFunList>();
                SysFunListBiz biz = new SysFunListBiz();
                lists = biz.SelectAllFunList();
                AddDatasource("functionlist", lists);
                List<SysModule> modulelists = new List<SysModule>();
                SysModuleBiz mbiz = new SysModuleBiz();
                modulelists = mbiz.SelectUsed();
                AddDatasource("modulelist", modulelists);
            }
        }

        public void SaveRoleFunction()
        {
            string _roleid = Parameters["proleid"];
            string _moduleflag = Parameters["pmoduleflag"];
            string _funlist = Parameters["pparm"];
            SysRolesFunctionBiz biz = new SysRolesFunctionBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            biz.SaveRoleFunction(_roleid, _moduleflag, _funlist, out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }

        public void SaveRoleModule()
        {
            string _roleid = Parameters["proleid"];
            string _moduleid = Parameters["pmoduleid"];
            SysRolesModuleBiz biz = new SysRolesModuleBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            biz.SaveRoleModule(_roleid, _moduleid, out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }

        public void GetRoleData()
        {
            string _id = Parameters["pid"];
            SysRoleBiz biz = new SysRoleBiz();
            SysRole item = new SysRole();
            item = biz.Select(_id);
            string datasource = Utils.ConvertToJson(item);
            Response.Write(datasource);
        }

        public void DeleteRole()
        {
            string _parm = Parameters["pparm"];
            SysRoleBiz biz = new SysRoleBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            biz.Delete(_parm, out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }

        public void StartRole()
        {
            string _parm = Parameters["pparm"];
            SysRoleBiz biz = new SysRoleBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            biz.UpdateStatus(_parm, "1", out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }

        public void GetRoleModulelist()
        {
            string _roleid = Parameters["proleid"];
            List<SysRolesModule> lists = new List<SysRolesModule>();
            SysRolesModuleBiz biz = new SysRolesModuleBiz();
            lists = biz.SelectModuleByRole(Convert.ToInt64(_roleid));
            Response.Write(Utils.ConvertToJson(lists));
        }

        public void GetModuleList()
        {
            string _roleid = Parameters["proleid"];
            List<SysModule> lists = new List<SysModule>();
            SysModuleBiz biz = new SysModuleBiz();
            lists = biz.SelectAuthorRoleModule(_roleid);
            Response.Write(Utils.ConvertToJson(lists));
        }

        public void GetRoleFunList()
        {
            string _roleid = Parameters["proleid"];
            string _moduleflag = Parameters["pmoduleflag"];
            //获取当前模块的所有功能列表
            List<SysFunList> lists = new List<SysFunList>();
            SysFunListBiz biz = new SysFunListBiz();
            lists = biz.SelectAllFunList(_moduleflag);
            //获取当前角色被授权的功能列表
            List<SysRolesFunction> rlists = new List<SysRolesFunction>();
            SysRolesFunctionBiz rbiz = new SysRolesFunctionBiz();
            rlists = rbiz.Select(Convert.ToInt64(_roleid),_moduleflag);
            foreach (SysRolesFunction item in rlists)
            {
                lists.Find(p => p.FFunId == item.FFunId).FSelFlag = item.FFunId;
            }
            Response.Write(Utils.ConvertToJson(lists));
        }

        public void StopRole()
        {
            string _parm = Parameters["pparm"];
            SysRoleBiz biz = new SysRoleBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            biz.UpdateStatus(_parm, "0", out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }

        public void SaveRole()
        {
            string proleid = Parameters["proleid"];
            string prolename = Parameters["prolename"];
            string proledesc = Parameters["proledesc"];
            SysRoleBiz biz = new SysRoleBiz();
            SysRole item = new SysRole();
            item.FRoleId = string.IsNullOrEmpty(proleid) ? 0 : Convert.ToInt64(proleid);
            item.FRoleName = prolename;
            item.FRoleDesc = proledesc;
            ErrorEntity ErrInfo = new ErrorEntity();
            if (item.FRoleId == 0)
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
            List<SysRole> lists = new List<SysRole>();
            SysRoleBiz biz = new SysRoleBiz();
            string _searchtext = _searchcontent;
            string wheresql = "1=1";
            if (!string.IsNullOrEmpty(_searchtext))
            {
                wheresql = "(FRoleName like '%" + _searchtext + "%')";
            }
            Int32 totalcount = 0;
            lists = biz.Select(wheresql, _sortname, _sortdirection, sPageIndex, sPageSize, out totalcount);
            string datasource = Utils.GetRepeaterDatasource(lists, sPageIndex, sPageSize, totalcount);
            Response.Write(datasource);
        }
    }
}