using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib.Interface;
using HQLib.Util;

namespace HQPortal.ML
{
    [Serializable]
    public class PortalColumnNav :IDatasource
    {
        public Int64 FNavId { get; set; }

        public Int64 FColumnId { get; set; }

        public string FNavName { get; set; }

        public string FNavType { get; set; }

        public string FNavTypeName
        {
            get
            {
                switch (FNavType)
                {
                    case "0":
                        return "子栏目";
                    case "1":
                        return "文章列表";
                    case "2":
                        return "产品列表";
                    case "3":
                        return "自定义内容";
                    case "4":
                        return "自定义模型";
                    default:
                        return "未定义参数";
                }
            }
        }

        public string FNavPosition { get; set; }

        public string FNavPositionName
        {
            get
            {
                switch (FNavPosition)
                {
                    case "0":
                        return "页面左侧";
                    case "1":
                        return "页面右侧";
                    default:
                        return "页面左侧";
                }
            }
        }

        public Int32 FNavOrder { get; set; }

        public string FNavVisible { get; set; }

        public string FNavVisibleName
        {
            get
            {
                if (FNavVisible == "1")
                {
                    return "显示";
                }
                else
                {
                    return "隐藏";
                }
            }
        }

        public string FNavTitleVisible { get; set; }

        public string FNavTitleVisibleName
        {
            get
            {
                if (FNavTitleVisible == "1")
                {
                    return "显示";
                }
                else
                {
                    return "隐藏";
                }
            }
        }

        public string FNavStyle { get; set; }

        public string FNavUrl { get; set; }

        public string FOperation
        {
            get
            {
                switch (FNavType)
                {
                    case "0":
                        return "<a href='javascript:void(0)' onclick='navedit(" + FNavId.ToString() + ")'>编辑</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href='javascript:void(0)' onclick='childcoldefine(" + FNavId.ToString() + ")'>子栏目设置</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href='javascript:void(0)' onclick='childcolstyle(" + FNavId.ToString() + ")'>样式设置</a>";
                    case "1":
                        return "<a href='javascript:void(0)' onclick='navedit(" + FNavId.ToString() + ")'>编辑</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href='javascript:void(0)' onclick='articlelistdefine(" + FNavId.ToString() + ")'>文章列表设置</a>";
                    case "2":
                        return "<a href='javascript:void(0)' onclick='navedit(" + FNavId.ToString() + ")'>编辑</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href='javascript:void(0)' onclick='productslistdefine(" + FNavId.ToString() + ")'>产品列表设置</a>";
                    case "3":
                        return "<a href='javascript:void(0)' onclick='navedit(" + FNavId.ToString() + ")'>编辑</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href='javascript:void(0)' onclick='contentdefine(" + FNavId.ToString() + ")'>自定义内容设置</a>";
                    case "4":
                        return "<a href='javascript:void(0)' onclick='navedit(" + FNavId.ToString() + ")'>编辑</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href='javascript:void(0)' onclick='modeldefine(" + FNavId.ToString() + ")'>自定义模型设置</a>";
                    default:
                        return "";
                }
            }
        }


        public string ToJson()
        {
            return Utils.ConvertToJson(this);
        }
    }
}
