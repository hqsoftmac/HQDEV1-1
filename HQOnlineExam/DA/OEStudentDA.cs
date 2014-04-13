using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib;

namespace HQOnlineExam.DA
{
    public class OEStudentDA:CommonDA
    {
        public OEStudentDA()
        {
            this._selecttable = "t_oe_student";
            this._inserttable = "t_oe_student";
            this._updatetable = "t_oe_student";
            this._deletetable = "t_oe_student";
        }                      
    }
}
