using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HQOnlineExam.Biz;
using HQLib.Page;

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
            }
        }
    }
}