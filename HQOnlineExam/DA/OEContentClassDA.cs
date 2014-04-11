using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib;

namespace HQOnlineExam.DA
{
    public class OEContentClassDA :CommonDA
    {
        public OEContentClassDA()
        {
            this._selecttable = "t_oe_contentclass";
            this._inserttable = "t_oe_contentclass";
            this._updatetable = "t_oe_contentclass";
            this._deletetable = "t_oe_contentclass";
        }
    }
}
