using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib.Interface;
using HQLib.Util;
namespace HQOnlineExam.ML
{
    //OEStudentExamM
    [Serializable]
    public class OEStudentExamM : IDatasource
    {

        /// <summary>
        /// FExamId
        /// </summary>		
        public Guid FExamId { get; set; }
        /// <summary>
        /// 学员ID
        /// </summary>		
        public Guid FStudentId { get; set; }
        /// <summary>
        /// 试卷ID
        /// </summary>		
        public long FPaperd { get; set; }
        /// <summary>
        /// FExamBeginTime
        /// </summary>		
        public DateTime FExamBeginTime { get; set; }

        public string FExamBeginTimeStr
        {
            get
            {
                if(FExamBeginTime==new DateTime())
                {
                    return "";
                }
                else
                {
                    return FExamBeginTime.ToString("yyyy-MM-dd hh:mm:ss");
                }
            }
        }
        /// <summary>
        /// FExamEndTime
        /// </summary>		
        public DateTime FExamEndTime { get; set; }

        public string FExamEndTimeStr
        {
            get
            {
                if (FExamEndTime == new DateTime())
                {
                    return "";
                }
                else
                {
                    return FExamEndTime.ToString("yyyy-MM-dd hh:mm:ss");
                }
            }
        }

        /// <summary>
        /// FExamSubmitTime
        /// </summary>		
        public DateTime FExamSubmitTime { get; set; }

        public string FExamSubmitTimeStr
        {
            get
            {
                if (FExamSubmitTime == new DateTime())
                {
                    return "";
                }
                else
                {
                    return FExamSubmitTime.ToString("yyyy-MM-dd hh:mm:ss");
                }
            }
        }

        /// <summary>
        /// FExamSubmitFlag
        /// </summary>		
        public string FExamSubmitFlag { get; set; }
        /// <summary>
        /// FExamResultNum
        /// </summary>		
        public decimal FExamResultNum { get; set; }
        /// <summary>
        /// FExamPassFlag
        /// </summary>		
        public string FExamPassFlag { get; set; }

        public string FExamPassFlagName
        {
            get
            {
                switch (FExamPassFlag)
                {
                    case "0":
                        return "未通过";
                    case "1":
                        return "已通过";
                    default:
                        return "未知";
                }
            }
        }

        public OEStudentExamM()
        {

        }

        public string ToJson()
        {
            return Utils.ConvertToJson(this);
        }

    }
}
