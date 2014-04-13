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
        public string FStudentId { get; set; }

        public string FStudentName { get; set; }

        public string FStudentIDNumber { get; set; }

        public string FEmail { get; set; }

        public string FMobile { get; set; }

        public DateTime FRegTime { get; set; }

        public string FStudentPSW { get; set; }

        public string FStatus { get; set; }

        public string FStatusname
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


        public OEStudent()
        {
        }

        public string ToJson()
        {
            return Utils.ConvertToJson(this);
        }
    }
}
