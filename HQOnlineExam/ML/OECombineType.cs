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

        public Int32 FQuestionNum { get; set; }

        public decimal FQuestionScore { get; set; }

        public OECombineType()
        {
        }



        public string ToJson()
        {
            return Utils.ConvertToJson(this);
        }
    }
}
