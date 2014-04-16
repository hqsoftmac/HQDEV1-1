using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib.Interface;
using HQLib.Util;
namespace HQOnlineExam.ML
{
    //OEStudentPractice
    [Serializable]
    public class OEStudentPractice : IDatasource
    {

        /// <summary>
        /// FPracticeId
        /// </summary>		
        public Guid FPracticeId { get; set; }
        /// <summary>
        /// 学员ID
        /// </summary>		
        public Guid FStudentId { get; set; }
        /// <summary>
        /// 内容类别ID
        /// </summary>		
        public long FContentClassId { get; set; }
        /// <summary>
        /// 题库ID
        /// </summary>		
        public long FQBankId { get; set; }
        /// <summary>
        /// 题目ID
        /// </summary>		
        public long FQuestionId { get; set; }
        /// <summary>
        /// FPracticeAnswer
        /// </summary>		
        public string FPracticeAnswer { get; set; }
        /// <summary>
        /// FPassResult
        /// </summary>		
        public string FPassResult { get; set; }

        public string FPassResultName
        {
            get
            {
                switch (FPassResult)
                {
                    case "0":
                        return "错误";
                    case "1":
                        return "正确";
                    default:
                        return "未知";
                }
            }
        }

        /// <summary>
        /// FPracticeTime
        /// </summary>		
        public DateTime FPracticeTime { get; set; }

        public string FPracticeTimeStr
        {
            get
            {
                if (FPracticeTime == new DateTime())
                {
                    return "";
                }
                else
                {
                    return ("yyyy-MM-dd hh:mm:ss");
                }
            }
        }

        public OEStudentPractice()
        {

        }

        public string ToJson()
        {
            return Utils.ConvertToJson(this);
        }

    }
}