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
        public Int64 FPaperId { get; set; }

        public Int64 FContentClassId { get; set; }

        public string FContentClassCode { get; set; }

        public string FContentClassName { get; set; }

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

        public string FUserName { get; set; }

        public DateTime FPaperTime { get; set; }

        public string FPaperTimeStr
        {
            get
            {
                if (FPaperTime == new DateTime())
                {
                    return "";
                }
                else
                {
                    return FPaperTime.ToString("yyyy-MM-dd hh:mm:ss");
                }
            }
        }

        public string FPaperStatus { get; set; }

        public string FPaperStatusname
        {
            get
            {
                switch (FPaperStatus)
                {
                    case "0":
                        return "删除";
                    case "1":
                        return "公开";
                    case "2":
                        return "保密";
                    case "3":
                        return "公开";
                    default:
                        return "未知";
                }
            }
        }

        public Int32 FExamTime { get; set; }

        public string FExamType { get; set; }

        public string FExamTypeName
        {
            get
            {
                if (FExamType == "1")
                {
                    return "在线模式";
                }
                else
                {
                    return "离线模式";
                }
            }
        }

        public string FExamAgain { get; set; }

        public string FExamAgainName
        {
            get
            {
                if (FExamAgain == "1")
                {
                    return "允许";
                }
                else
                {
                    return "不允许";
                }
            }
        }


        public string FOperation
        {
            get
            {
                return "";
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
