using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib.Interface;
using HQLib.Util;

namespace HQCommon.ML
{
    [Serializable]
    public class SysEducation :IDatasource
    {
        public Int64 FEducationID { get; set; }

        public string FEducationName { get; set; }

        public int FEducationOrder { get; set; }

        public string FOperation
        {
            get
            {
                return "<a href='javascript:void(0)' onclick='edit(" + FEducationID.ToString() + ")'>编辑</a>";
            }
        }

        public SysEducation()
        {

        }

        public string ToJson()
        {
            return Utils.ConvertToJson(this);
        }
    }
}
