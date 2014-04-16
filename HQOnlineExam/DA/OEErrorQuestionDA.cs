using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib;
namespace HQOnlineExam.DA
{
    //OEErrorQuestion
    public partial class OEErrorQuestionDA : CommonDA
    {
        public OEErrorQuestionDA()
        {
            this._selecttable = "t_oe_errorquestion";
            this._inserttable = "t_oe_errorquestion";
            this._updatetable = "t_oe_errorquestion";
            this._deletetable = "t_oe_errorquestion";
        }
    }
}