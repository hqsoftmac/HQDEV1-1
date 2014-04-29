using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib.Interface;
using HQLib.Util;

namespace HQOnlineExam.ML
{
    [Serializable]
    
    public class OEStudent:IDatasource
    {
        public Guid FStudentId { get; set; }

        public string FStudentName { get; set; }

        public string FStudentIDNumber { get; set; }

        public string FEmail { get; set; }

        public string FMobile { get; set; }

        public DateTime FRegTime { get; set; }

        public string FRegTimeStr
        {
            get
            {
                if (FRegTime == new DateTime())
                {
                    return "";
                }
                else
                {
                    return FRegTime.ToString();
                }
            }
        }

        public string FStudentPSW { get; set; }

        public string FStatus { get; set; }

        public string FStatusName
        {
            get
            {
                switch (FStatus)
                {
                    case "0":
                        return "删除";
                    case "1":
                        return "正常";
                    case "2":
                        return "禁用";
                    default:
                        return "未知";
                }
            }
        }

        public string FOperation
        {
            get
            {
                string rnt = "<a href='javascript:void(0)' onclick='edit(\"" + FStudentId.ToString() + "\")'>编辑</a>";
                rnt += "&nbsp;&nbsp;&nbsp;&nbsp;<a href='javascript:void(0)' onclick='resetpsw(\"" + FStudentId.ToString() + "\")'>重置口令</a>";
                if (FStatus == "1")
                {
                    rnt += "&nbsp;&nbsp;&nbsp;&nbsp;<a href='javascript:void(0)' onclick='status(\"" + FStudentId.ToString() + "\",\"2\")'>停用</a>";
                }
                else
                {
                    rnt += "&nbsp;&nbsp;&nbsp;&nbsp;<a href='javascript:void(0)' onclick='status(\"" + FStudentId.ToString() + "\",\"1\")'>启用</a>";
                }
                return rnt;
            }
        }

        public OEStudent()
        {
        }

        public string ToJson()
        {
            return Utils.ConvertToJson(this);
        }
    }
}
