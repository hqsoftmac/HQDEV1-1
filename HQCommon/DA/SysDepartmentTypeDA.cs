using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib;

namespace HQCommon.DA
{
    public class SysDepartmentTypeDA : CommonDA
    {
        public SysDepartmentTypeDA()
        {
            this._selecttable = "t_sys_departmenttype";
            this._inserttable = "t_sys_departmenttype";
            this._updatetable = "t_sys_departmenttype";
            this._deletetable = "t_sys_departmenttype";
        }
    }
}
