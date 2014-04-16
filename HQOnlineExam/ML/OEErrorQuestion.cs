using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib.Interface;
using HQLib.Util;
namespace HQOnlineExam.ML
{
    //OEErrorQuestion
    [Serializable]
    public class OEErrorQuestion : IDatasource
    {

        /// <summary>
        /// 学员ID
        /// </summary>		
        public Guid FStudentId { get; set; }
        /// <summary>
        /// 题目ID
        /// </summary>		
        public long FQuestionId { get; set; }
        /// <summary>
        /// FCollectFlag
        /// </summary>		
        public string FCollectFlag { get; set; }

        public string FCollectFlagname
        {
            get
            {
                switch (FCollectFlag)
                {
                    case "0":
                        return "收藏";
                    case "1":
                        return "出错";
                    default:
                        return "收藏";
                }
            }
        }



        public OEErrorQuestion()
        {

        }

        public string ToJson()
        {
            return Utils.ConvertToJson(this);
        }

    }
}