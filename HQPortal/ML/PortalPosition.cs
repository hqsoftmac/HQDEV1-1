using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib.Interface;
using HQLib.Util;

namespace HQPortal.ML
{
    [Serializable]
    public class PortalPosition : IDatasource
    {
        public Int64 FPositionId { get; set; }

        public string FPositionName { get; set; }

        public string FPositionDept { get; set; }

        public string FPositionType { get; set; }

        public string FPositionTypeName
        {
            get
            {
                if (FPositionType == "0")
                {
                    return "全职";
                }
                else
                {
                    return "兼职";
                }
            }
        }

        public string FPositionGendor { get; set; }

        public string FPositionGendorName
        {
            get
            {
                switch (FPositionGendor)
                {
                    case "0":
                        return "不限";
                    case "1":
                        return "男性";
                    case "2":
                        return "女性";
                    default:
                        return "不限";
                }
            }
        }

        public Int32 FPositionNum { get; set; }

        public DateTime FBeginDate { get; set; }

        public string FBeginDateStr
        {
            get
            {
                return FBeginDate.ToString("yyyy-MM-dd");
            }
        }

        public DateTime FEndDate { get; set; }

        public string FEndDateStr
        {
            get
            {
                return FEndDate.ToString("yyyy-MM-dd");
            }
        }

        public string FPositionContent { get; set; }

        public string FBackContent { get; set; }

        public Int32 FPositionOrder { get; set; }

        public string FOperation
        {
            get
            {
                return "<a href='javascript:void(0)' onclick='editposition(" + FPositionId.ToString() + ")'>编辑</a>";
            }
        }

        public PortalPosition()
        {

        }

        public string ToJson()
        {
            return Utils.ConvertToJson(this);
        }
    }
}
