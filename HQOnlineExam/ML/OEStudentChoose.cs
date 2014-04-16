using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib.Interface;
using HQLib.Util;
namespace HQOnlineExam.ML
{
    //OEStudentChoose
    [Serializable]
    public class OEStudentChoose : IDatasource
    {

        /// <summary>
        /// 学员ID
        /// </summary>		
        public Guid FStudentId { get; set; }
        /// <summary>
        /// 内容类别ID
        /// </summary>		
        public long FContentClassId { get; set; }

        public OEStudentChoose()
        {

        }

        public string ToJson()
        {
            return Utils.ConvertToJson(this);
        }

    }
}