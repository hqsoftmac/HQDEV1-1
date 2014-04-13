using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib.Interface;
using HQLib.Util;

namespace HQOnlineExam.ML
{
   [Serializable] 
    public class OEChooseQuestion:IDatasource
    {
       public Int64 FPaperId { get; set; }

       public string FQuestionType { get; set; }

       public Int64 FQuestionType { get; set; }

       public OEChooseQuestion()
       {
       }



       public string ToJson()
       {
           return Utils.ConvertToJson(this);
       }
    }
}
