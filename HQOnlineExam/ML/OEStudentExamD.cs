using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib.Interface;
using HQLib.Util;
namespace HQOnlineExam.ML
{
    //OEStudentExamD
    [Serializable]
    public class OEStudentExamD : IDatasource
    {

        /// <summary>
        /// FExamId
        /// </summary>		
        public Guid FExamId { get; set; }
        /// <summary>
        /// FExamDId
        /// </summary>		
        public long FExamDId { get; set; }
        /// <summary>
        /// 题目ID
        /// </summary>		
        public long FQuestionId { get; set; }
        /// <summary>
        /// FAnswerContent
        /// </summary>		
        public string FAnswerContent { get; set; }
        /// <summary>
        /// FStdPoints
        /// </summary>		
        public decimal FStdPoints { get; set; }
        /// <summary>
        /// FPoints
        /// </summary>		
        public decimal FPoints { get; set; }
        /// <summary>
        /// FResult
        /// </summary>		
        public string FResult { get; set; }
        /// <summary>
        /// FAUserId
        /// </summary>
        public string FResultName
        {
            get
            {
                switch (FResult)
                {
                    case "0":
                        return "未评判";
                    case "1":
                        return "对";
                    case "2":
                        return "错";
                    default:
                        return "未评判";
                }
            }
        }
        
 
        public long FAUserId { get; set; }
        /// <summary>
        /// FAUserName
        /// </summary>		
        public string FAUserName { get; set; }
        /// <summary>
        /// FResultTime
        /// </summary>		
        public DateTime FResultTime { get; set; }

        public string FResultTimestr
        {
            get
            {
                if (FResultTime == new DateTime())
                {
                    return "";
                }
                else
                {
                    return FResultTime.ToString("yyyy-MM-dd hh:mm:ss");
                }
            }
        }
            



        public OEStudentExamD()
        {

        }

        public string ToJson()
        {
            return Utils.ConvertToJson(this);
        }

    }
}
