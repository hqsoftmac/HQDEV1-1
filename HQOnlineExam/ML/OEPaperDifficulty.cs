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
