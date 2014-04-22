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
using HQLib;
using HQLib.User;

namespace HQDevPlatform.OnlineExam
{
    public partial class OEQuestionEdit : PageBase
    {
        public HQOnlineExam.ML.OEQuestion item;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string _id = Parameters["qid"];
                item = new HQOnlineExam.ML.OEQuestion();
                OEQuestionBiz biz = new OEQuestionBiz();
                item = biz.Select(_id);
                List<OEQuestionBank> lists = new List<OEQuestionBank>();
                OEQuestionBankBiz QBbiz = new OEQuestionBankBiz();
                NameValueCollection where = new NameValueCollection();
                where.Add("FContentClassId",item.FContentClassId.ToString());
                NameValueCollection orderby = new NameValueCollection();
                orderby.Add("FQBankCode","asc");
                lists = QBbiz.Select(where, orderby);
                AddDatasource("QBankList", lists);
            }
        }

        public void SaveQuestion()
        {
            string _contentclassid = Parameters["pcontentclassid"];
            string _questionbank = Parameters["pquestionbank"];
            string _questionid = Parameters["pquestionid"];
            string _questiontitile = Parameters["pquestiontitle"];
            string _questiontype = Parameters["pquestiontype"];
            string _questiondiffculty = Parameters["pquestiondifficulty"];
            string _keyword = Parameters["pkeyword"];
            string _desc = Parameters["pdesc"];
            string _analysis = Parameters["panalysis"];
            ErrorEntity ErrInfo = new ErrorEntity();
            OEQuestionBiz biz = new OEQuestionBiz();
            HQOnlineExam.ML.OEQuestion item = new HQOnlineExam.ML.OEQuestion();
            SysUser useritem = new SysUser();
            useritem = GetUserInfo();
            item.AUserId = useritem.FUserId;
            item.AUserName = useritem.FUserName;
            item.FQuestionId = Convert.ToInt64(_questionid);
            item.FQBankId = Convert.ToInt64(_questionbank);
            item.FQuestionTitle = _questiontitile;
            item.FQuestionType = _questiontype;
            item.FQuestionDifficulty = _questiondiffculty;
            item.FKeyWord = _keyword;
            item.FQuestionDesc = _desc;
            item.FQuestionAnalysis = _analysis;
            item.FQuestionStatus = "1";
            if (string.IsNullOrEmpty(_questionid) || _questionid == "0")
            {
                biz.Insert(item, out ErrInfo);
            }
            else
            {
                biz.Update(item, out ErrInfo);
            }
            Response.Write(ErrInfo.ToJson());
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
            orderby.Add("FQBankCode", "asc");
            List<OEQuestionBank> lists = new List<OEQuestionBank>();
            lists = QBBiz.Select(where, orderby);
            Response.Write(Utils.ConvertToJson(lists));
        }
    }
}