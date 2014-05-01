using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib;
namespace HQOnlineExam.DA
{
    //OEPaperDetailQuestion
    public partial class OEPaperDetailQuestionDA : CommonDA
    {
        public OEPaperDetailQuestionDA()
        {
            this._selecttable = "t_oe_paperdetailquestion";
            this._inserttable = "t_oe_paperdetailquestion";
            this._updatetable = "t_oe_paperdetailquestion";
            this._deletetable = "t_oe_paperdetailquestion";
        }
    }
}