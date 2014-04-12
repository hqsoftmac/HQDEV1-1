using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib.Interface;
using HQLib.Util;

namespace HQOnlineExam.ML
{
     [Serializable]
    public class OEExamItem :IDatasource
    {
         public Int64 FPaperId { get; set; }

         public Int32 FItemId { get; set; }

         public string FItemContent{get; set;}

         public string FItemFlag{get; set;}

         public OEExamItem()
         {

         }


         public string ToJson()
         {
             return Utils.ConvertToJson(this);
         }
    }
}
