using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib.Interface;
using HQLib.Util;

namespace HQOnlineExam.ML
{
  [Serializable]
  public class OECombineBank:IDatasource
  {
      public Int64 FPaperId { get; set; }

      public Int64 FQBankId { get; set; }

      public string FQBankCode { get; set; }

      public string FQBankName { get; set; }

      public Decimal FQBnakRate { get; set; }

      public string FOperation { get; set; }

      public OECombineBank()
      {
      }



      public string ToJson()
      {
          return Utils.ConvertToJson(this);
      }
  }
}
