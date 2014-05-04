using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HQLib.Page;
using HQOnlineExam.ML;
using HQOnlineExam.Biz;
using System.Collections.Specialized;
using HQLib.Util;
using HQLib;

namespace HQDevPlatform.OnlineExam
{
    public partial class ExamManage : PageBase
    {
        protected int sPageIndex = 1;
        protected int sPageSize = 10;
        protected string sSortName = "FPaperId";
        protected string sSortDirection = "ASC";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void SetPaperPublic()
        {
            string _paperid = Parameters["ppaperid"];
            OEExamPaperBiz biz = new OEExamPaperBiz();
            NameValueCollection par = new NameValueCollection();
            par.Add("FPaperStatus", "1");
            NameValueCollection where = new NameValueCollection();
            where.Add("FPaperId", _paperid);
            ErrorEntity ErrInfo = new ErrorEntity();
            biz.Update(par, where, out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }

        public void SetPaperPrivate()
        {
            string _paperid = Parameters["ppaperid"];
            OEExamPaperBiz biz = new OEExamPaperBiz();
            NameValueCollection par = new NameValueCollection();
            par.Add("FPaperStatus", "2");
            NameValueCollection where = new NameValueCollection();
            where.Add("FPaperId", _paperid);
            ErrorEntity ErrInfo = new ErrorEntity();
            biz.Update(par, where, out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }

        public void DelData()
        {
            string idlist = Parameters["pparm"];
            OEExamPaperBiz biz = new OEExamPaperBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            biz.Delete(idlist, out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }

        public void GetContentClassTree()
        {
            OEContentClassTreeBiz biz = new OEContentClassTreeBiz();
            Response.Write(biz.JsonSelect());
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
            List<OEExamPaper> lists = new List<OEExamPaper>();
            OEExamPaperBiz biz = new OEExamPaperBiz();
            string _searchtext = _searchcontent;
            string _contentclassid = Parameters["pcontentclassid"];
            string wheresql = "(FContentClassId = " + _contentclassid + ")";
            wheresql += " and ((FPaperStatus = '1') or ((FPaperStatus = '2') and (AUserId = " + userid + ")))";
            if (!string.IsNullOrEmpty(_searchtext))
            {
                //difine wheresql
                //for example:wheresql = " (FDepartmentName like '%" + _searchtext + "%') or (FDepartmentCode like '%" + _searchtext + "%')";
                wheresql += " and (FPaperName like '%" + _searchtext + "%')";
            }
            NameValueCollection where = new NameValueCollection();
            where.Add("condition", wheresql);
            NameValueCollection orderby = new NameValueCollection();
            orderby.Add(_sortname, _sortdirection);
            Int32 totalcount = 0;
            lists = biz.Select(where, orderby, Convert.ToInt32(sPageIndex), Convert.ToInt32(sPageSize), out totalcount);
            //设置操作动作
            for (int i = 0; i < lists.Count; i++)
            {
                string _operation = "";
                if (lists[0].AUserId == Convert.ToInt64(userid))
                {
                    _operation = "<a href='javascript:void(0)' onclick='editpaper(" + lists[i].FPaperId.ToString() + ")'>更改设定</a>";
                    if (lists[i].FPaperStatus == "1")
                    {
                        _operation += "&nbsp;&nbsp;&nbsp;&nbsp;<a href='javascript:void(0)' onclick='setprivate(" + lists[i].FPaperId.ToString() + ")'>设为保密</a>";
                    }
                    else
                    {
                        _operation += "&nbsp;&nbsp;&nbsp;&nbsp;<a href='javascript:void(0)' onclick='setpublic(" + lists[i].FPaperId.ToString() + ")'>设为公开</a>";
                    }
                }
                else
                {
                    _operation = "<a href='javascript:void(0)' onclick='viewpaper(" + lists[i].FPaperId.ToString() + ")'>查看设定</a>";
                }
                lists[i].FOperation = _operation;
            }
            string datasource = Utils.GetRepeaterDatasource(lists, sPageIndex, sPageSize, totalcount);
            Response.Write(datasource);
        }
    }
}