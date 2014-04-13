using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib.Interface;
using HQLib.Util;

namespace HQOnlineExam.ML
{
   
    [Serializable]
    public class OEExamPaper:IDatasource
    {
        public Int64 FPaperd { get; set; }

        public Int64 FContentClassId { get; set; }

        public String FPaperName { get; set; }

        public decimal FPaperTotal { get; set; }

        public string FPaperExtractWay { get; set; }

        public string FPaperExtractWayname
        {
            get
            {
                switch (FPaperExtractWay)
                {
                    case "0":
                        return "随机";
                    case "1":
                        return "固定";
                    default:
                        return "未知";
                }
            }
        }
             
     
       

        public string FChooseItemWay { get; set; }

        public string FChooseItemWayname
        {
            get
            {
                switch (FChooseItemWay)
                {
                    case "0":
                        return "随机";
                    case "1":
                        return "固定";
                    default:
                        return "未知";
                }
            }
        }

        public decimal FPassScore { get; set; }

        public string FPaperContent { get; set; }

        public Int64 AUserId { get; set; }

        public DateTime FPaperTime { get; set; }

        public string FPaperStatus { get; set; }

        public string FPaperStatusname
        {
            get
            {
                switch (FPaperStatus)
                {
                    case "0":
                        return "保密";
                    case "1":
                        return "公开";
                    default:
                        return "未知";
                }
            }
        }
        

        public OEExamPaper()
        {
        }

        public string ToJson()
        {
            return Utils.ConvertToJson(this);
        }
    }
}
