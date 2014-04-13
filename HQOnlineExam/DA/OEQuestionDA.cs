using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib;

namespace HQOnlineExam.DA
{
    public class OEQuestionDA : CommonDA
    {
        public OEQuestionDA()
        {
            this._selecttable = "t_oe_question";
            this._inserttable = "t_oe_question";
            this._updatetable = "t_oe_question";
            this._deletetable = "t_oe_question";
        }
    }

  
}
