using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib;

namespace HQCommon.DA
{
    public class SysUserDeptsDA:CommonDA
    {
        public SysUserDeptsDA()
        {
            this._inserttable = "t_sys_userdepts";
            this._selecttable = "t_sys_userdepts";
            this._updatetable = "t_sys_userdepts";
            this._deletetable = "t_sys_userdepts";
        }
    }
}
