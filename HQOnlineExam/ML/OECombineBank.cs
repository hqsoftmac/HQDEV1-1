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
      public Int64 OECombineBank { get; set; }

      public Int64 FQBankId { get; set; }

      public Int32 FQBnakRate { get; set; }

      public OECombineBank()
      {
      }



      public string ToJson()
      {
          return Utils.ConvertToJson(this);
      }
  }
}
