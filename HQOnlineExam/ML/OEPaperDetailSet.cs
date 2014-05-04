using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib.Interface;
using HQLib.Util;

namespace HQOnlineExam.ML
{
    [Serializable]
    public class OEPaperDetailSet : IDatasource
    {
        /// <summary>
        /// 试卷ID
        /// </summary>		
        public long FPaperId { get; set; }

        /// <summary>
        /// FDetailSetId
        /// </summary>		
        public int FDetailSetId { get; set; }

        /// <summary>
        /// FQuestionType
        /// </summary>		
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

        /// <summary>
        /// FDifficulty
        /// </summary>		
        public string FDifficulty { get; set; }

        public string FDifficultyName
        {
            get
            {
                switch (FDifficulty)
                {
                    case "0":
                        return "低";
                    case "1":
                        return "中";
                    case "2":
                        return "高";
                    default:
                        return "未知";
                }
            }
        }

        public decimal FScore { get; set; }

        public Int64 FQuestionId { get; set; }

        public Int32 FQuestionNum { get; set; }

        public string FViewQuestion
        {
            get
            {
                if (FQuestionNum == 0)
                {
                    return "<未设定备选题目>";
                }
                else
                {
                    return "<已设定备选题目>:" + FQuestionNum.ToString() + "条"  ;
                }
            }
        }

        public string FOperation { get; set; }

        public OEPaperDetailSet()
        {

        }

        public string ToJson()
        {
            return Utils.ConvertToJson(this);
        }

    }
}
