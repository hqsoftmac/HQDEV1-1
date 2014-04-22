using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HQOnlineExam.Biz;
using HQLib.Page;
using HQOnlineExam.ML;
using HQLib.Util;
using System.Collections.Specialized;
using HQLib;

namespace HQDevPlatform.OnlineExam
{
    public partial class OEQuestionItemSet : PageBase
    {
        public HQOnlineExam.ML.OEQuestion item;
        protected void Page_Load(object sender, EventArgs e)
        {
            item = new HQOnlineExam.ML.OEQuestion();
            if (!Page.IsPostBack)
            {
                string _id = Parameters["qid"];
                OEQuestionBiz biz = new OEQuestionBiz();
                item = biz.Select(_id);
                List<OEQuestionItem> lists = new List<OEQuestionItem>();
                OEQuestionItemBiz ibiz = new OEQuestionItemBiz();
                lists = ibiz.Select(_id);
                AddDatasource("itemlists", lists);
            }
        }

        public void SetItemError()
        {
            string qid = Parameters["pquestionid"];
            string itemid = Parameters["pitemid"];
            OEQuestionItemBiz biz = new OEQuestionItemBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            biz.UpdateError(qid, itemid, out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }

        public void SetItemRight()
        {
            string qid = Parameters["pquestionid"];
            string itemid = Parameters["pitemid"];
            OEQuestionItemBiz biz = new OEQuestionItemBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            biz.UpdateRight(qid, itemid, out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }

        public void DeleteItem()
        {
            string _id = Parameters["qid"];
            string _idlist = Parameters["pparm"];
            NameValueCollection where = new NameValueCollection();
            where.Add("condition", "(FQuestionId = " + _id + ") and (FItemId in (" + _idlist + "))");
            ErrorEntity ErrInfo = new ErrorEntity();
            OEQuestionItemBiz biz = new OEQuestionItemBiz();
            biz.Delete(where, out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }

        public void GetDataList()
        {
            string _id = Parameters["qid"];
            OEQuestionItemBiz biz = new OEQuestionItemBiz();
            List<OEQuestionItem> lists = new List<OEQuestionItem>();
            lists = biz.Select(_id);
            Response.Write(Utils.ConvertToJson(lists));

        }
    }
}