using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib;
namespace HQOnlineExam.DA
{
    //学员在线状态
    public partial class 学员在线状态DA : CommonDA
    {
        public 学员在线状态DA()
        {
            this._selecttable = "t_oe_studentonlie";
            this._inserttable = "t_oe_studentonlie";
            this._updatetable = "t_oe_studentonlie";
            this._deletetable = "t_oe_studentonlie";
        }
    }
}