using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib;

namespace HQOnlineExam.DA
{
    public class OEChooseQuestionDA:CommonDA

    {
        public OEChooseQuestionDA()
        {
            this._selecttable = "t_oe_choosequestion";
            this._inserttable = "t_oe_choosequestion";
            this._updatetable = "t_oe_choosequestion";
            this._deletetable = "t_oe_choosequestion";
        }
    }
}
