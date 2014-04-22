using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib;

namespace HQOnlineExam.DA
{
    public class OEQuestionItemDA : CommonDA
    {
        public OEQuestionItemDA()
        {
            {
                this._selecttable = "t_oe_questionitem";
                this._inserttable = "t_oe_questionitem";
                this._updatetable = "t_oe_questionitem";
                this._deletetable = "t_oe_questionitem";
            }
        }
    }

   
   
}
