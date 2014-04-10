using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib;

namespace HQCommon.DA
{
    public class SysDepartmentDA:CommonDA
    {
        public SysDepartmentDA()
        {
            this._selecttable = "v_sys_department";
            this._inserttable = "t_sys_department";
            this._updatetable = "t_sys_department";
            this._deletetable = "t_sys_department";
        }
    }
}
