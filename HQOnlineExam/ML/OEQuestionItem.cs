using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib.Interface;
using HQLib.Util;
using HQLib.Common;

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

         public string FItemDisplayContent
         {
             get
             {
                 string rnt = PublicMethod.NoHTML(FItemContent);
                 if (rnt.Length > 30)
                 {
                     rnt = rnt.Substring(0, 30) + "...";
                 }
                 return rnt;
             }
         }

         public string FOperation
         {
             get
             {
                 string rnt = "<a href='javascript:void(0)' onclick='edit(" + FItemId.ToString() + "," + FQuestionId.ToString() + ")'>编辑</a>";
                 if (FItemFlag == "0")
                 {
                     rnt += "&nbsp;&nbsp;&nbsp;&nbsp;<a href='javascript:void(0)' onclick='setright(" + FItemId.ToString() + "," + FQuestionId.ToString() + ")'>正确答案</a>";
                 }
                 else
                 {
                     rnt += "&nbsp;&nbsp;&nbsp;&nbsp;<a href='javascript:void(0)' onclick='seterror(" + FItemId.ToString() + "," + FQuestionId.ToString() + ")'>错误答案</a>";
                 }
                 return rnt;
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
