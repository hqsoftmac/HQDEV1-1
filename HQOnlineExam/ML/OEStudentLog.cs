using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib.Interface;
using HQLib.Util;
namespace HQOnlineExam.ML
{
    //OEStudentLog
    [Serializable]
    public class OEStudentLog : IDatasource
    {

        /// <summary>
        /// 日志ID
        /// </summary>		
        public Guid LogId { get; set; }
        /// <summary>
        /// 学员ID
        /// </summary>		
        public Guid FStudentId { get; set; }
        /// <summary>
        /// 日志类型
        /// </summary>		
        public string FLogType { get; set; }
        /// <summary>
        /// 日志描述
        /// </summary>		
        public string FLogContent { get; set; }
        /// <summary>
        /// IP地址
        /// </summary>		
        public string FLogIp { get; set; }
        /// <summary>
        /// 日志时间
        /// </summary>		
        public DateTime LogTime { get; set; }

        public string LogTimeStr
        {
            get
            {
                if(LogTime==new DateTime())
                {
                    return"";
                }
                else
                {
                    return ("yyyy-MM-dd hh:mm:ss");
                }
            }
        }


        public OEStudentLog()
        {

        }

        public string ToJson()
        {
            return Utils.ConvertToJson(this);
        }

    }
}