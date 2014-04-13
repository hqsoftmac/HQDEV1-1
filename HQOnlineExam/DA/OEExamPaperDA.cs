using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib;

namespace HQOnlineExam.DA
{
    public class OEExamPaperDA:CommonDA
    {
        public OEExamPaperDA()
        {
            this._selecttable = "t_oe_exampaper";
            this._inserttable = "t_oe_exampaper";
            this._updatetable = "t_oe_exampaper";
            this._deletetable = "t_oe_exampaper";
        }

    }
}
