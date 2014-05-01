using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib.Interface;
using HQLib.Util;
namespace HQOnlineExam.ML
{
    //OEPaperDetailQuestion
    [Serializable]
    public class OEPaperDetailQuestion : IDatasource
    {

        /// <summary>
        /// 试卷ID
        /// </summary>		
        public long FPaperId { get; set; }
        /// <summary>
        /// 明细设定ID
        /// </summary>		
        public int FDetailSetId { get; set; }
        /// <summary>
        /// 题目ID
        /// </summary>		
        public long FQuestionId { get; set; }

        public OEPaperDetailQuestion()
        {

        }

        public string ToJson()
        {
            return Utils.ConvertToJson(this);
        }

    }
}