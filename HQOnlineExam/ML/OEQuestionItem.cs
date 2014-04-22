using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib.Interface;
using HQLib.Util;

namespace HQOnlineExam.ML
{
     [Serializable]
    public class OEQuestionItem :IDatasource
    {
         public Int64 FQuestionId { get; set; }

         public Int32 FItemId { get; set; }

         public string FItemContent{get; set;}

         public string FItemFlag{get; set;}

         public string FItemFlagName
         {
             get
             {
                 if (FItemFlag == "1")
                 {
                     return "正确答案";
                 }
                 else
                 {
                     return "错误答案";
                 }
             }
         }

         public OEQuestionItem()
         {

         }


         public string ToJson()
         {
             return Utils.ConvertToJson(this);
         }
    }
}
