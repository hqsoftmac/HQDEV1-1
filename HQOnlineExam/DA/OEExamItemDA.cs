using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib;

namespace HQOnlineExam.DA
{
    public class OEExamItemDA : CommonDA
    {
        public OEExamItemDA()
        {
            {
                this._selecttable = "t_oe_examitem";
                this._inserttable = "t_oe_examitem";
                this._updatetable = "t_oe_examitem";
                this._deletetable = "t_oe_examitem";
            }
        }
    }

   
   
}
