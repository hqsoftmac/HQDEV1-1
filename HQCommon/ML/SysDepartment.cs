using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib.Interface;
using HQLib.Util;

namespace HQCommon.ML
{
    [Serializable]
    public class SysDepartment : IDatasource
    {
        public Int64 FDepartmentID { get; set; }

        public Int64 FDepartmentTypeId { get; set; }

        public string FDepartmentTypeName { get; set; }

        public string FDepartmentCode { get; set; }

        public string FDepartmentName { get; set; }

        public string FDepartmentCharge { get; set; }

        public Int32 FDepartmentNum { get; set; }

        public string FDepartmentTel { get; set; }

        public string FDepartmentContent { get; set; }

        public string FOperation
        {
            get
            {
                return "<a href='javascript:void(0)' onclick='editdept(" + FDepartmentID.ToString() + ")'>编辑</a>";
            }
        }

        public SysDepartment()
        {

        }

        public string ToJson()
        {
            return Utils.ConvertToJson(this);
        }
    }
}
