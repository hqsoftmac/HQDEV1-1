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
    public partial class OEQuestionItemEdit : PageBase
    {
        public string gsquestionid = string.Empty;
        public string gsquestionitemid = string.Empty;
        public OEQuestionItem item;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                gsquestionid = Parameters["qid"];
                gsquestionitemid = Parameters["itemid"];
                OEQuestionItemBiz biz = new OEQuestionItemBiz();
                item = new OEQuestionItem();
                item = biz.Select(gsquestionid, gsquestionitemid);
                
            }

        }

        public void SaveItem()
        {
            gsquestionid = Parameters["qid"];
            gsquestionitemid = Parameters["itemid"];
            string _itemcontent = Parameters["pitemcontent"];
            string _itemflag = Parameters["pitemflag"];
            OEQuestionItem item = new OEQuestionItem();
            item.FQuestionId = Convert.ToInt64(gsquestionid);
            item.FItemId = Convert.ToInt32(gsquestionitemid);
            item.FItemContent = _itemcontent;
            item.FItemFlag = _itemflag;
            OEQuestionItemBiz biz = new OEQuestionItemBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            biz.Update(item, out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }
    }
}