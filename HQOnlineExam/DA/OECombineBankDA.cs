using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib;

namespace HQOnlineExam.DA
{
    public class OECombineBankDA:CommonDA
    {
        public OECombineBankDA()
        {
            this._selecttable = "v_oe_combinebank";
            this._inserttable = "t_oe_combinebank";
            this._updatetable = "t_oe_combinebank";
            this._deletetable = "t_oe_combinebank";
        }
    }
}
