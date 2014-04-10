using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib.Interface;
using HQLib.Util;
namespace HQPartyManage.ML
{
    //PmOrgLeader
    [Serializable]
    public class PmOrgLeader : IDatasource
    {

        /// <summary>
        /// 领导ID
        /// </summary>		
        public long FLeaderId { get; set; }
        /// <summary>
        /// 组织Id
        /// </summary>		
        public long FOrgId { get; set; }
        /// <summary>
        /// 领导姓名
        /// </summary>		
        public string FLeaderName { get; set; }
        /// <summary>
        /// 领导职务
        /// </summary>		
        public string FLeaderPostion { get; set; }

        /// <summary>
        /// 领导显示顺序
        /// </summary>
        public Int32 FLeaderOrder { get; set; }

        public PmOrgLeader()
        {

        }

        public string FOperation
        {
            get
            {
                return "<a href='javascript:void(0)' onclick='edit(" + FLeaderId.ToString() + ")'>编辑</a>";
            }
        }


        public string ToJson()
        {
            return Utils.ConvertToJson(this);
        }

    }
}