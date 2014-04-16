using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib;
namespace HQOnlineExam.DA
{
    //OEStudentChoose
    public partial class OEStudentChooseDA : CommonDA
    {
        public OEStudentChooseDA()
        {
            this._selecttable = "t_oe_studentchoose";
            this._inserttable = "t_oe_studentchoose";
            this._updatetable = "t_oe_studentchoose";
            this._deletetable = "t_oe_studentchoose";
        }
    }
}
