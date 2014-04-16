using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib;
namespace HQOnlineExam.DA
{
    //OEStudentLog
    public partial class OEStudentLogDA : CommonDA
    {
        public OEStudentLogDA()
        {
            this._selecttable = "t_oe_studentlog";
            this._inserttable = "t_oe_studentlog";
            this._updatetable = "t_oe_studentlog";
            this._deletetable = "t_oe_studentlog";
        }
    }
}