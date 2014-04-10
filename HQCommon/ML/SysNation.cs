using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib.Interface;
using HQLib.Util;

namespace HQCommon.ML
{
    [Serializable]
    public class SysNation :IDatasource
    {
        public Int64 FNationID { get; set; }

        public string FNationName { get; set; }

        public Int32 FNationOrder { get; set; }

        public string FOperation
        {
            get
            {
                return "<a href='javascript:void(0)' onclick='editnation1(" + FNationID.ToString() + ")'>编辑</a>";
            }
        }

        public SysNation()
        {

        }

        public string ToJson()
        {
            return Utils.ConvertToJson(this);
        }
    }
}
