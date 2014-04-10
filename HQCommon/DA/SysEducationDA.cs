using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib;

namespace HQCommon.DA
{
    public class SysEducationDA:CommonDA
    {
        public SysEducationDA()
        {
            this._selecttable = "t_sys_education";
            this._inserttable = "t_sys_education";
            this._updatetable = "t_sys_education";
            this._deletetable = "t_sys_education";
        }
    }
}
