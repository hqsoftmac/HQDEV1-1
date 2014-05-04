using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib.Interface;
using HQLib.Util;

namespace HQOnlineExam.ML
{
   
    [Serializable]
    public class OECombineType:IDatasource
    {
        public Int64 FPaperId { get; set; }

        public string FQuestionType { get; set; }

        public string FQuestionTypeName
        {
            get
            {
                switch (FQuestionType)
                {
                    case "0":
                        return "判断题";
                    case "1":
                        return "单项选择题";
                    case "2":
                        return "多项选择题";
                    case "3":
                        return "填空题";
                    case "4":
                        return "综合应用题";
                    default:
                        return "未知题型";
                }
            }
        }

        public Int32 FQuestionNum { get; set; }

        public decimal FQuestionScore { get; set; }

        public decimal FQuestionTotal
        {
            get
            {
                return FQuestionScore * FQuestionNum;
            }
        }

        public OECombineType()
        {
        }



        public string ToJson()
        {
            return Utils.ConvertToJson(this);
        }
    }
}
