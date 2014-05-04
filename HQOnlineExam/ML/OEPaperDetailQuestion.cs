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
        public Int64 FPaperId { get; set; }
        /// <summary>
        /// 明细设定ID
        /// </summary>		
        public int FDetailSetId { get; set; }
        /// <summary>
        /// 难度标示
        /// </summary>		
        public string  FDifficulty { get; set; }

        public OEPaperDetailQuestion()
        {

        }

        public string ToJson()
        {
            return Utils.ConvertToJson(this);
        }

    }
}