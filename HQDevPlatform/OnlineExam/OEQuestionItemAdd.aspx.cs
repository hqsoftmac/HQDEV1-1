using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HQLib.Page;
using HQOnlineExam.ML;
using HQOnlineExam.Biz;
using HQLib;

namespace HQDevPlatform.OnlineExam
{
    public partial class OEQuestionItemAdd : PageBase
    {
        public string gsquestionid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            gsquestionid = Parameters["qid"];
        }

        public void SaveItem()
        {
            string _itemcontent = Parameters["pitemcontent"];
            string _qid = Parameters["qid"];
            string _itemflag = Parameters["pitemflag"];
            OEQuestionItem item = new OEQuestionItem();
            item.FQuestionId = Convert.ToInt64(_qid);
            item.FItemId = 0;
            item.FItemContent = _itemcontent;
            item.FItemFlag = _itemflag;
            OEQuestionItemBiz biz = new OEQuestionItemBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            biz.Insert(item, out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }
    }
}