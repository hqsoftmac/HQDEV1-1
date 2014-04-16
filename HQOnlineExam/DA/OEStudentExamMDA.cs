using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib;
namespace HQOnlineExam.DA
{
    //OEStudentExamM
    public partial class OEStudentExamMDA : CommonDA
    {
        public OEStudentExamMDA()
        {
            this._selecttable = "t_oe_studentexamm";
            this._inserttable = "t_oe_studentexamm";
            this._updatetable = "t_oe_studentexamm";
            this._deletetable = "t_oe_studentexamm";
        }
    }
}