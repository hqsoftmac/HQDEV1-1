using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib;

namespace HQCommon.DA
{
    public class SysNationDA:CommonDA
    {
        public SysNationDA()
        {
            this._selecttable = "t_sys_nation";
            this._inserttable = "t_sys_nation";
            this._updatetable = "t_sys_nation";
            this._deletetable = "t_sys_nation";
        }
    }
}
