using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HQLib.Page;
using HQLib.Function;
using System.Collections.Specialized;
using HQLib.Util;
using HQLib;

namespace HQDevSys.manage
{
    public partial class functionmanage : PageBase
    {
        protected int sPageIndex = 1;
        protected int sPageSize = 10;
        protected string sSortName = "FunCode";
        protected string sSortDirection = "ASC";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<SysModule> lists = new List<SysModule>();
                SysModuleBiz biz = new SysModuleBiz();
                lists = biz.SelectUsed();
                AddDatasource("modulelist", lists);
            }
        }

        public void GetFunctionInfo()
        {
            string _funid = Parameters["pfunid"];
            SysFunListBiz biz = new SysFunListBiz();
            SysFunList item = new SysFunList();
            item = biz.Select(_funid);
            Response.Write(item.ToJson());
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
            SysFunListBiz biz = new SysFunListBiz();
            List<SysFunList> lists = new List<SysFunList>();
            NameValueCollection where = new NameValueCollection();
            where.Add("FModuleFlag", _searchcontent);
            Int32 totalcount = 0;
            NameValueCollection orderby = new NameValueCollection();
            orderby.Add(sSortName, sSortDirection);
            lists = biz.Select(where, orderby, sPageIndex, sPageSize, out totalcount);
            string datasource = Utils.GetRepeaterDatasource(lists, sPageIndex, sPageSize, totalcount);
            Response.Write(datasource);
        }

        public void GetParentFun()
        {
            string _moduleflag = Parameters["pmoduleflag"];
            List<SysFunList> lists = new List<SysFunList>();
            SysFunListBiz biz = new SysFunListBiz();
            NameValueCollection where = new NameValueCollection();
            NameValueCollection orderby = new NameValueCollection();
            where.Add("FModuleFlag", _moduleflag);
            where.Add("FParentFunId", "0");
            where.Add("FFunStatus", "1");
            orderby.Add("FFunCode", "asc");
            lists = biz.Select(where, orderby);
            Response.Write(Utils.ConvertToJson(lists));
        }

        public void SaveFunction()
        {
            string _funid = Parameters["pfunid"];
            string _funcode = Parameters["pfuncode"];
            string _parentid = Parameters["pparentid"];
            string _funname = Parameters["pfunname"];
            string _navigateurl = Parameters["pnavigateurl"];
            string _fundesc = Parameters["pfundesc"];
            string _moduleflag = Parameters["pmoduleflag"];
            if (string.IsNullOrEmpty(_funid))
            {
                _funid = "0";
            }
            if (string.IsNullOrEmpty(_parentid))
            {
                _parentid = "0";
            }
            SysFunList item = new SysFunList();
            item.FFunId = Convert.ToInt64(_funid);
            item.FFunCode = _funcode;
            item.FFunName = _funname;
            item.FParentFunId = Convert.ToInt64(_parentid);
            item.FFunNavigateUrl = _navigateurl;
            item.FFunContent = _fundesc;
            item.FModuleFlag = _moduleflag;
            SysFunListBiz biz = new SysFunListBiz();
            Int64 result = 0;
            ErrorEntity ErrInfo = new ErrorEntity();
            result = biz.Save(item, out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }

        public void DelFunction()
        {
            string idlist = Parameters["pparm"];
            SysFunListBiz biz = new SysFunListBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            NameValueCollection where = new NameValueCollection();
            where.Add("condition","FFunId in " + idlist);
            biz.Delete(where, out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }


        public void StartFunction()
        {
            string idlist = Parameters["pparm"];
            SysFunListBiz biz = new SysFunListBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            biz.UpdateStatus(idlist, "1", out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }

        public void StopFunction()
        {
            string idlist = Parameters["pparm"];
            SysFunListBiz biz = new SysFunListBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            biz.UpdateStatus(idlist, "0", out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }
    }
}