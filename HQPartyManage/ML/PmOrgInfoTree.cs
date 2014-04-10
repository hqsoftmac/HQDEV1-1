using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib.Interface;
using HQLib.Util;

namespace HQPartyManage.ML
{
    [Serializable]
    public class PmOrgInfoTree : IDatasource
    {
        /// <summary>
        /// 组织Id
        /// </summary>		
        public long FOrgId { get; set; }

        /// <summary>
        /// 所属部门ID
        /// </summary>		
        public long FDepartmentID { get; set; }

        /// <summary>
        /// 组织名称
        /// </summary>		
        public string FOrgName { get; set; }

        /// <summary>
        /// 上级组织名称
        /// </summary>		
        public long FParentOrgId { get; set; }

        /// <summary>
        /// 组织性质
        /// </summary>		
        public string FOrgType { get; set; }

        /// <summary>
        /// 组织性质名称
        /// </summary>
        public string FOrgTypeName
        {
            get
            {
                switch (FOrgType)
                {
                    case "1":
                        return "党委";
                    case "2":
                        return "党总支";
                    case "3":
                        return "党支部";
                    default:
                        return "党支部";
                }
            }
        }

        /// <summary>
        /// 最近一次选举换届时间
        /// </summary>		
        public DateTime FOrgNewDate { get; set; }


        public string FOrgNewDateStr
        {
            get
            {
                return FOrgNewDate.ToString("yyyy-MM-dd");
            }
        }

        /// <summary>
        /// 显示顺序
        /// </summary>		
        public int FOrgOrder { get; set; }

        public List<PmOrgInfoTree> children { get; set; }

        public PmOrgInfoTree()
        {

        }

        public string ToJson()
        {
            return Utils.ConvertToJson(this);
        }
    }
}
