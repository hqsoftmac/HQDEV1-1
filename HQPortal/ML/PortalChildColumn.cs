using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib.Interface;
using HQLib.Util;

namespace HQPortal.ML
{
    [Serializable]
    public class PortalChildColumn :IDatasource
    {
        public Int64 FChildColumnId { get; set; }

        public Int64 FNavId { get; set; }

        public string FChildColumnName { get; set; }

        public string FChildColumnType { get; set; }

        public string FChildColumnTypeName
        {
            get
            {
                switch (FChildColumnType)
                {
                    case "0":
                        return "普通简介";
                    case "1":
                        return "文章列表";
                    case "2":
                        return "产品列表";
                    case "3":
                        return "用户反馈";
                    case "9":
                        return "自定义模型";
                    default:
                        return "未定义";
                }
            }
        }

        public string FChildColumnUrl { get; set; }

        public string FChildColumnTarget { get; set; }

        public string FChildColumnTargetName
        {
            get
            {
                if (FChildColumnTarget == "1")
                {
                    return "新窗口";
                }
                else
                {
                    return "本窗口";
                }
            }
        }

        public string FChildColumnVisible { get; set; }

        public string FChildColumnVisibleName
        {
            get
            {
                if (FChildColumnVisible == "1")
                {
                    return "显示";
                }
                else
                {
                    return "隐藏";
                }
            }
        }

        public Int32 FChildColumnOrder { get; set; }

        public string FOperation
        {
            get
            {
                switch (FChildColumnType)
                {
                    case "0":
                        return "<a href='javascript:void(0)' onclick='normalcontent(" + FChildColumnId.ToString() + ")'>普通简介</a>";
                    case "1":
                        return "文章列表";
                    case "2":
                        return "产品列表";
                    case "3":
                        return "用户反馈";
                    case "9":
                        return "自定义模型";
                    default:
                        return "未定义";
                }
            }
        }

        public PortalChildColumn()
        {

        }

        public string ToJson()
        {
            return Utils.ConvertToJson(this);
        }
    }
}
