using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib.Interface;
using HQLib.Util;
namespace HQOnlineExam.ML
{
    //学员在线状态
    [Serializable]
    public class 学员在线状态 : IDatasource
    {

        /// <summary>
        /// 学员ID
        /// </summary>		
        public Guid FStudentId { get; set; }
        /// <summary>
        /// FOnlineTime
        /// </summary>		
        public DateTime FOnlineTime { get; set; }

        public string FOnlineTimeStr
        {
            get
            {
                if (FOnlineTime == new DateTime())
                {
                    return "";
                }
                else
                {
                    return ("yyyy-MM-dd hh:mm:ss");
                }
            }
        }

        public 学员在线状态()
        {

        }

        public string ToJson()
        {
            return Utils.ConvertToJson(this);
        }

    }
}