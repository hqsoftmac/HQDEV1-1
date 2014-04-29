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
    public partial class ExamStudent : PageBase
    {
        protected int sPageIndex = 1;
        protected int sPageSize = 10;
        protected string sSortName = "FStudentName";
        protected string sSortDirection = "ASC";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void DelData()
        {
            string idlist = Parameters["pparm"];
            OEStudentBiz biz = new OEStudentBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            biz.Delete(idlist, out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }

        public void UpdateStatus()
        {
            string _id = Parameters["pid"];
            string _status = Parameters["pstatus"];
            OEStudentBiz biz = new OEStudentBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            biz.UpdateStatus(_id, _status, out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }

        public void SaveItem()
        {
            string _FStudentId = Parameters["pFStudentId"];
            // other paramters fill here
            string _FStudentName = Parameters["pFStudentName"];
            string _FStudentIDNumber = Parameters["pFStudentIDNumber"];
            string _Email = Parameters["pFEmail"];
            string _Mobile = Parameters["pFMobile"];
            OEStudent item = new OEStudent();
            if (!string.IsNullOrEmpty(_FStudentId))
            {
                Guid newid = new Guid(_FStudentId);
                item.FStudentId = newid;
            }
            item.FStudentName = _FStudentName;
            item.FStudentIDNumber = _FStudentIDNumber;
            item.FEmail = _Email;
            item.FMobile = _Mobile;
            OEStudentBiz biz = new OEStudentBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            if (string.IsNullOrEmpty(_FStudentId))
            {
                biz.Insert(item, out ErrInfo);
            }
            else
            {
                biz.Update(item, out ErrInfo);
            }
            Response.Write(ErrInfo.ToJson());

        }

        public void GetItem()
        {
            string _id = Parameters["pid"];
            OEStudent item = new OEStudent();
            OEStudentBiz biz = new OEStudentBiz();
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

        public void ResetPassWord()
        {
            string _id = Parameters["pid"];
            OEStudentBiz biz = new OEStudentBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            biz.ResetPsw(_id, out ErrInfo);
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
            List<OEStudent> lists = new List<OEStudent>();
            OEStudentBiz biz = new OEStudentBiz();
            string _searchtext = _searchcontent;
            string wheresql = "(FStatus <> '0')";
            if (!string.IsNullOrEmpty(_searchtext))
            {
                wheresql += " and ((FStudentName like '%" + _searchcontent + "%') or (FStudentIDNumber like '%" + _searchcontent + "%'))";
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