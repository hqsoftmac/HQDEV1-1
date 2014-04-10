using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib.Interface;
using HQLib.Util;

namespace HQCommon.ML
{
    [Serializable]
    public class SysDepartmentType :IDatasource
    {
        public Int64 FDepartmentTypeId { get; set; }

        public string FDepartmentTypeName { get; set; }

        public Int32 FDepartmentTypeOrder { get; set; }

        public string FOperation
        {
            get
            {
                return "<a href='javascript:void(0)' onclick='edit(" + FDepartmentTypeId.ToString() + ")'>编辑</a>";
            }
        }

        public SysDepartmentType()
        {

        }

        public string ToJson()
        {
            return Utils.ConvertToJson(this);
        }
    }
}
