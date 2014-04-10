using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib.Interface;
using HQLib.Util;
namespace HQPartyManage.ML{
	 	//党组织成员
	[Serializable]
	public class PmOrgCommittee :IDatasource
	{	     
      	/// <summary>
		/// 委员ID
        /// </summary>		
        public long FCommitteeID { get; set;}      
		/// <summary>
		/// 组织ID
        /// </summary>		
        public long FOrgId { get; set;}      
		/// <summary>
		/// 委员姓名
        /// </summary>		
        public string FCommitteeName { get; set;}      
		/// <summary>
		/// 委员职务
        /// </summary>		
        public string FCommitteePosition { get; set;}

        /// <summary>
        /// 委员职务名称
        /// </summary>
        public string FCommitteePositionName
        {
            get
            {
                switch (FCommitteePosition)
                {
                    case "1":
                        return "负责人";
                    case "2":
                        return "书记";
                    case "3":
                        return "专职副书记";
                    case "4":
                        return "副书记";
                    case "5":
                        return "委员";
                    case "6":
                        return "联络员";
                    default:
                        return "联络员";
                }
            }
        }

		/// <summary>
		/// 手机号码
        /// </summary>		
        public string FCommitteeMobile { get; set;}      
		/// <summary>
		/// 办公电话
        /// </summary>		
        public string FCommitteeTel { get; set;}      
		/// <summary>
		/// 显示顺序
        /// </summary>		
        public int FCommitteeOrder { get; set;}

        public PmOrgCommittee()
		{

		}

		public string FOperation
        {
            	get
            	{
                	return "<a href='javascript:void(0)' onclick='edit(" + FCommitteeID.ToString() + ")'>编辑</a>";
            	}
        }


        public string ToJson()
        {
            return Utils.ConvertToJson(this);
        }
   
	}
}