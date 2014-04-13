using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib;

namespace HQOnlineExam.DA
{
    public class OEPaperDifficultyDA:CommonDA
    {
        public OEPaperDifficultyDA()
        {
            this._selecttable = "t_oe_paperdifficulty";
            this._inserttable = "t_oe_paperdifficulty";
            this._updatetable = "t_oe_paperdifficulty";
            this._deletetable = "t_oe_paperdifficulty";
        }

    }
}
