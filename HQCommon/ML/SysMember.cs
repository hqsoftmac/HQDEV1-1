using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib.Interface;
using HQLib.Util;

namespace HQCommon.ML
{
    [Serializable]
    public class SysMember : IDatasource
    {
        public Int64 FMemberId { get; set; }

        public Int64 FEductionId { get; set; }

        public string FEducationName { get; set; }

        public Int64 FNationId { get; set; }

        public string FNationName { get; set; }

        public Int64 FDepartmentId { get; set; }

        public string FDepartmentCode { get; set; }

        public string FDepartmentName { get; set; }

        public string FMemberCode { get; set; }

        public string FMemberName { get; set; }

        public string FMemberGendor { get; set; }

        public string FMemberGendorName
        {
            get
            {
                if (FMemberGendor == "0")
                {
                    return "男";
                }
                else
                {
                    return "女";
                }
            }
        }

        public DateTime FBirthDate { get; set; }

        public string FBirthDateStr
        {
            get
            {
                return FBirthDate == new DateTime() ? "" : FBirthDate.ToString("yyyy-MM-dd");
            }
        }

        public int FAge
        {
            get
            {
                if(FBirthDate.Month > DateTime.Now.Month)
                {
                    return DateTime.Now.Year - FBirthDate.Year -1;
                }
                else if(FBirthDate.Month == DateTime.Now.Month)
                {
                    if(FBirthDate.Date >= DateTime.Now.Date)
                    {
                        return DateTime.Now.Year - FBirthDate.Year -1;
                    }
                    else
                    {
                       return DateTime.Now.Year - FBirthDate.Year;
                    }
                }
                else
                {
                    return DateTime.Now.Year - FBirthDate.Year;
                }
            }
        }

        public string FIDNumber { get; set; }

        public string FMobile { get; set; }

        public string FPosition { get; set; }

        public string FPicPath { get; set; }

        public string FPicPathStr
        {
            get
            {
                return string.IsNullOrEmpty(FPicPath) ? "../../images/defphoto.png" : FPicPath;
            }

        }

        public string FStatus { get; set; }

        public string FStatusName
        {
            get
            {
                switch (FStatus)
                {
                    case "1":
                        return "正常";
                    case "2":
                        return "历史";
                    case "0":
                        return "停用";
                    default:
                        return "状态未知";
                }
            }
        }

        public string FOperation
        {
            get
            {
                switch (FStatus)
                {
                    case "1":
                        return "<a href='javascript:void(0)' onclick='edit(" + FMemberId.ToString() + ")'>编辑</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href='javascript:void(0)' onclick='stop(" + FMemberId.ToString() + ")'>停用</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href='javascript:void(0)' onclick='uppic(" + FMemberId.ToString() + ")'>照片</a>";
                    case "2":
                        return "<a href='javascript:void(0)' onclick='view(" + FMemberId.ToString() + ")'>查看</a>";
                    case "0":
                        return "<a href='javascript:void(0)' onclick='edit(" + FMemberId.ToString() + ")'>编辑</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href='javascript:void(0)' onclick='start(" + FMemberId.ToString() + ")'>启用</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href='javascript:void(0)' onclick='uppic(" + FMemberId.ToString() + ")'>照片</a>";
                    default:
                        return "";
                }
            }
        }

        public SysMember()
        {

        }

        public string ToJson()
        {
            return Utils.ConvertToJson(this);
        }
    }
}
