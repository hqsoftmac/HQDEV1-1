using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib;
namespace HQOnlineExam.DA
{
    //OEStudentPractice
    public partial class OEStudentPracticeDA : CommonDA
    {
        public OEStudentPracticeDA()
        {
            this._selecttable = "t_oe_studentpractice";
            this._inserttable = "t_oe_studentpractice";
            this._updatetable = "t_oe_studentpractice";
            this._deletetable = "t_oe_studentpractice";
        }
    }
}