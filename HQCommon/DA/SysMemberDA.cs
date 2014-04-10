using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib;

namespace HQCommon.DA
{
    public class SysMemberDA:CommonDA
    {
        public SysMemberDA()
        {
            this._selecttable = "v_sys_member";
            this._inserttable = "t_sys_member";
            this._updatetable = "t_sys_member";
            this._deletetable = "t_sys_member";
        }
    }
}
