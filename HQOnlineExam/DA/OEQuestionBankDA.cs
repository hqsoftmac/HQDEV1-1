using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib;

namespace HQOnlineExam.DA
{
    public class OEQuestionBankDA : CommonDA
    {
        public OEQuestionBankDA()
        {
            this._selecttable = "t_oe_questionbank";
            this._inserttable = "t_oe_questionbank";
            this._updatetable = "t_oe_questionbank";
            this._deletetable = "t_oe_questionbank";
        }
    }
}
