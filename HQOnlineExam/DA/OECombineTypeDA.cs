using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib;

namespace HQOnlineExam.DA
{
    public class OECombineTypeDA:CommonDA
    {
        public OECombineTypeDA()
        {
            this._selecttable = "t_oe_combineqtype";
            this._inserttable = "t_oe_combineqtype";
            this._updatetable = "t_oe_combineqtype";
            this._deletetable = "t_oe_combineqtype";
        }

    }
}
