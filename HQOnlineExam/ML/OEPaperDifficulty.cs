using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib.Interface;
using HQLib.Util;

namespace HQOnlineExam.ML
{
    [Serializable]
    public class OEPaperDifficulty:IDatasource
    {
        public Int64 FPaperId { get; set; }

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

        public Int32 FRate { get; set; }

        public OEPaperDifficulty()
        {
        }



        public string ToJson()
        {
            return Utils.ConvertToJson(this);
        }
    }
}
