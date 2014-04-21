using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HQLib.Page;
using HQOnlineExam.Biz;
using System.Collections.Specialized;
using HQOnlineExam.ML;
using HQLib.Util;

namespace HQDevPlatform.OnlineExam
{
    public partial class OEQuestion : PageBase
    {
        protected int sPageIndex = 1;
        protected int sPageSize = 10;
        protected string sSortName = "FQuestionId";
        protected string sSortDirection = "ASC";
        protected void Page_Load(object sender, EventArgs e)
        {

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
            string _qbankid = Parameters["pqbankid"];
            string _tilte = Parameters["ptitle"];
            string _type = Parameters["ptype"];
            string _diffculty = Parameters["pdifficulty"];
            string _keyword = Parameters["pkeyword"];
            string _desc = Parameters["pdesc"];
            List<HQOnlineExam.ML.OEQuestion> lists = new List<HQOnlineExam.ML.OEQuestion>();
            OEQuestionBiz biz = new OEQuestionBiz();
            string _searchtext = _searchcontent;
            string wheresql = "(FQBankId = " + _qbankid + ")";
            if (!string.IsNullOrEmpty(_tilte))
            {
                wheresql += " and (FQuestionTilte like '%" + _tilte + "%') ";
            }
            if (!string.IsNullOrEmpty(_type))
            {
                wheresql += " and (FQuestionType = '" + _type + "')";
            }
            if (!string.IsNullOrEmpty(_diffculty))
            {
                wheresql += " and (FQuestionDifficulty = '" + _diffculty + "')";
            }
            if (!string.IsNullOrEmpty(_keyword))
            {
                string _k = _keyword.Trim();
                string[] k;
                k = _k.Split(' ');
                string _sql = "";
                for (int i = 0; i < k.Length; i++)
                {
                    if (!string.IsNullOrEmpty(_sql))
                    {
                        _sql += " or ";
                    }
                    if (!string.IsNullOrEmpty(k[i].Trim()))
                    {
                        _sql += " ( FKeyWord like '%" + k[i].Trim() + "%') ";
                    }
                }
                if (!string.IsNullOrEmpty(_sql))
                {
                    wheresql += " and (" + _sql + ") ";
                }
            }
            if (!string.IsNullOrEmpty(_desc))
            {
                wheresql += " and (FQuestionDesc like '%" + _desc + "%') ";
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

        public void GetContentClassTree()
        {
            OEContentClassTreeBiz biz = new OEContentClassTreeBiz();
            Response.Write(biz.JsonSelect());
        }

        public void GetQuestionBank()
        {
            string _classid = Parameters["pclassid"];
            OEContentClassBiz biz = new OEContentClassBiz();
            string _idlist = "";
            biz.GetChildrenIdList(_classid, ref _idlist);
            OEQuestionBankBiz QBBiz = new OEQuestionBankBiz();
            NameValueCollection where = new NameValueCollection();
            where.Add("condition", "FContentClassId in (" + _idlist + ")");
            NameValueCollection orderby = new NameValueCollection();
            orderby.Add("FQBankCode","asc");
            List<OEQuestionBank> lists = new List<OEQuestionBank>();
            lists = QBBiz.Select(where, orderby);
            Response.Write(Utils.ConvertToJson(lists));
        }
    }
}