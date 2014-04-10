using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib.Interface;
using HQLib.Util;
namespace HQPartyManage.ML
{
    //v_pm_partymember
    [Serializable]
    public class PmPartymember : IDatasource
    {

        /// <summary>
        /// FMemberId
        /// </summary>		
        public long FMemberId { get; set; }
        /// <summary>
        /// FEductionID
        /// </summary>		
        public long FEductionID { get; set; }
        /// <summary>
        /// FEducationName
        /// </summary>		
        public string FEducationName { get; set; }
        /// <summary>
        /// FNationID
        /// </summary>		
        public long FNationID { get; set; }
        /// <summary>
        /// FNationName
        /// </summary>		
        public string FNationName { get; set; }
        /// <summary>
        /// FDepartmentID
        /// </summary>		
        public long FDepartmentID { get; set; }
        /// <summary>
        /// FDepartmentName
        /// </summary>		
        public string FDepartmentName { get; set; }
        /// <summary>
        /// FMemberCode
        /// </summary>		
        public string FMemberCode { get; set; }
        /// <summary>
        /// FMemberName
        /// </summary>		
        public string FMemberName { get; set; }
        /// <summary>
        /// FMemberGendor
        /// </summary>		
        public string FMemberGendor { get; set; }


        public string FMemberGendorName
        {
            get
            {
                switch (FMemberGendor)
                {
                    case "0":
                        return "男";
                    case "1":
                        return "女";
                    default:
                        return "男";
                }
            }
        }

        /// <summary>
        /// FBirthDate
        /// </summary>		
        public DateTime FBirthDate { get; set; }

        public string FBirthDateStr
        {
            get
            {
                if (FBirthDate == new DateTime())
                {
                    return "";
                }
                else
                {
                    return FBirthDate.ToString("yyyy-MM-dd");
                }
            }
        }

        /// <summary>
        /// FIDNumber
        /// </summary>		
        public string FIDNumber { get; set; }
        /// <summary>
        /// FMobile
        /// </summary>		
        public string FMobile { get; set; }
        /// <summary>
        /// FPosition
        /// </summary>		
        public string FPosition { get; set; }
        /// <summary>
        /// FPicPath
        /// </summary>		
        public string FPicPath { get; set; }
        /// <summary>
        /// FStatus
        /// </summary>		
        public string FStatus { get; set; }

        public Int64 FOrgId { get; set; }

        public string FOrgName { get; set; }

        /// <summary>
        /// FActivistFlag
        /// </summary>		
        public string FActivistFlag { get; set; }
        /// <summary>
        /// FActivistDate
        /// </summary>		
        public DateTime FActivistDate { get; set; }

        public string FActivistDateStr
        {
            get
            {
                if (FActivistFlag == "1")
                {
                    if (FActivistDate == new DateTime())
                    {
                        return "";
                    }
                    else
                    {
                        return FActivistDate.ToString("yyyy-MM-dd");
                    }
                }
                else
                {
                    return "";
                }
            }
        }

        /// <summary>
        /// FObjectFlag
        /// </summary>		
        public string FObjectFlag { get; set; }
        /// <summary>
        /// FObjectDate
        /// </summary>		
        public DateTime FObjectDate { get; set; }

        public string FObjectDateStr
        {
            get
            {
                if (FObjectFlag == "1")
                {
                    if (FObjectDate == new DateTime())
                    {
                        return "";
                    }
                    else
                    {
                        return FObjectDate.ToString("yyyy-MM-dd");
                    }
                }
                else
                {
                    return "";
                }
            }
        }

        /// <summary>
        /// FPrePartyFlag
        /// </summary>		
        public string FPrePartyFlag { get; set; }
        /// <summary>
        /// FPrePartyDate
        /// </summary>		
        public DateTime FPrePartyDate { get; set; }

        public string FPrePartyDateStr
        {
            get
            {
                if (FPrePartyFlag == "1")
                {
                    if (FPrePartyDate == new DateTime())
                    {
                        return "";
                    }
                    else
                    {
                        return FPrePartyDate.ToString("yyyy-MM-dd");
                    }
                }
                else
                {
                    return "";
                }
            }
        }

        /// <summary>
        /// FPartyFlag
        /// </summary>		
        public string FPartyFlag { get; set; }
        /// <summary>
        /// FPartyDate
        /// </summary>		
        public DateTime FPartyDate { get; set; }

        public string FPartyDateStr
        {
            get
            {
                if (FPartyFlag == "1")
                {
                    if (FPartyDate == new DateTime())
                    {
                        return "";
                    }
                    else
                    {
                        return FPartyDate.ToString("yyyy-MM-dd");
                    }
                }
                else
                {
                    return "";
                }
            }
        }

        /// <summary>
        /// FHistoryFlag
        /// </summary>		
        public string FHistoryFlag { get; set; }
        /// <summary>
        /// FHistoryDate
        /// </summary>		
        public DateTime FHistoryDate { get; set; }

        public string FHistoryDateStr
        {
            get
            {
                if (FHistoryFlag == "1")
                {
                    if (FHistoryDate == new DateTime())
                    {
                        return "";
                    }
                    else
                    {
                        return FHistoryDate.ToString("yyyy-MM-dd");
                    }
                }
                else
                {
                    return "";
                }
            }
        }

        public PmPartymember()
        {

        }

        public string FOperation { get; set; }
        
        public string ToJson()
        {
            return Utils.ConvertToJson(this);
        }

    }
}