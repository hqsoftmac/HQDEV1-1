using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib.Interface;
using HQLib.Util;

namespace HQOnlineExam.ML
{
    [Serializable]
    public class OEQuestionBank :IDatasource
    {
        public Int64 FQBankId { get; set; }

        public Int64 FContentClassId { get; set; }

        public string FQBankCode { get; set; }

        public string FQBankName { get; set; }

        public string FQBankStatus { get; set; }

        public string FQBankStatusName
        {
            get
            {
                switch (FQBankStatus)
                {
                    case "0":
                        return "停用";
                    case "1":
                        return "启用";
                    default:
                        return "停用";
                }
            }
        }

        public string FQBankContent { get; set; }

        public OEQuestionBank()
        {

        }


        public string ToJson()
        {
            return Utils.ConvertToJson(this);
        }
    }
}
