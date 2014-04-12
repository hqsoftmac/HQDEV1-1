using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib.Interface;
using HQLib.Util;

namespace HQOnlineExam.ML
{
    [Serializable]
    public class OEQuestion : IDatasource
    {
        public Int64 FQuestionId { get; set; }

        public Int64 FQBankId { get; set; }

        public string FQuestionTitle { get; set; }

        public string FQuestionTitle { get; set; }

        public string FQuestionDifficulty { get; set; }

        public string FKeyWord { get; set; }

        public string FQuestionDesc { get; set; }

        public string FQuestionAnalysis { get; set; }

        public string FQuestionStatus { get; set; }

        public DateTime FQuestionStatus { get; set; }

        public Int64 AUserId { get; set; }

        public string AUserName { get; set; }

        public OEQuestion()
        {
        }

        public string ToJson()
        {
            return Utils.ConvertToJson(this);
        }

    }
}
