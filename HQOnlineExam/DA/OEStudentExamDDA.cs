using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib;
namespace HQOnlineExam.DA
{
    //OEStudentExamD
    public partial class OEStudentExamDDA : CommonDA
    {
        public OEStudentExamDDA()
        {
            this._selecttable = "t_oe_studentexamd";
            this._inserttable = "t_oe_studentexamd";
            this._updatetable = "t_oe_studentexamd";
            this._deletetable = "t_oe_studentexamd";
        }
    }
}