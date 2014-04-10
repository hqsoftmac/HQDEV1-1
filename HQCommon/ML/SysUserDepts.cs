using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib.Interface;
using HQLib.Util;

namespace HQCommon.ML
{
    [Serializable]
    public class SysUserDepts:IDatasource
    {
        public Int64 FUserId { get; set; }

        public Int64 FDepartmentId { get; set; }

        public SysUserDepts()
        {

        }

        public string ToJson()
        {
            return Utils.ConvertToJson(this);
        }
    }
}
