using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HQOnlineExam.ML;
using HQOnlineExam.Biz;
using HQLib.Page;
using HQLib;
using System.Collections.Specialized;
using HQLib.Util;

namespace HQDevPlatform.OnlineExam
{
    public partial class QuestionBank : PageBase
    {
        protected int sPageIndex = 1;
        protected int sPageSize = 10;
        protected string sSortName = "FQBankCode";
        protected string sSortDirection = "ASC";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void UpdateStatus()
        {
            string _id = Parameters["pid"];
            string _status = Parameters["pstatus"];
            OEQuestionBankBiz biz = new OEQuestionBankBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            biz.UpdateStatus(_id, _status, out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }

        public void GetContentClassTree()
        {
            OEContentClassTreeBiz biz = new OEContentClassTreeBiz();
            Response.Write(biz.JsonSelect());
        }

        public void SaveItem()
        {
            string _FQBankId = Parameters["pFQBankId"];
            // other paramters fill here
            string _FContentClassId = Parameters["pFContentClassId"];
            string _FQBankCode = Parameters["FQBankCode"];
            string _FQBankName = Parameters["pFQBankName"];
            string _FQBankContent = Parameters["pFQBankContent"];
            OEQuestionBank item = new OEQuestionBank();
            item.FQBankId = string.IsNullOrEmpty(_FQBankId) ? 0 : Convert.ToInt64(_FQBankId);
            item.FContentClassId = string.IsNullOrEmpty(_FContentClassId) ? 0 : Convert.ToInt64(_FContentClassId);
            item.FQBankCode = _FQBankCode;
            item.FQBankName = _FQBankName;
            item.FQBankContent = _FQBankContent;
            OEQuestionBankBiz biz = new OEQuestionBankBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            if (item.FQBankId == 0)
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
            OEQuestionBankBiz biz = new OEQuestionBankBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            biz.Delete(idlist, out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }

        public void GetItem()
        {
            string _id = Parameters["pid"];
            OEQuestionBank item = new OEQuestionBank();
            OEQuestionBankBiz biz = new OEQuestionBankBiz();
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
            List<OEQuestionBank> lists = new List<OEQuestionBank>();
            OEQuestionBankBiz biz = new OEQuestionBankBiz();
            string _searchtext = _searchcontent;
            string wheresql = "";
            string _searchclassid = Parameters["psearchclassid"];
            OEContentClassBiz ccbiz = new OEContentClassBiz();
            string _idlist = "";
            ccbiz.GetChildrenIdList(_searchclassid, ref _idlist);
            wheresql = "( FContentClassId in (" + _idlist + ")) ";
            if (!string.IsNullOrEmpty(_searchtext))
            {
                //difine wheresql
                //for example:wheresql = " (FDepartmentName like '%" + _searchtext + "%') or (FDepartmentCode like '%" + _searchtext + "%')";
                wheresql += " and (FQBankName like '%" + _searchtext + "%')";
            }
            else
            {
                wheresql += " and (1=1)";
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