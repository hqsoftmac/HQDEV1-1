using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib.Interface;
using HQLib.Util;

namespace HQPortal.ML
{
    [Serializable]
    public class PortalColumn :IDatasource
    {
        public Int64 FColumnId { get; set; }

        public string FColumnName { get; set; }

        public string FColumnContent { get; set; }

        public string FColumnType { get; set; }

        public string FColumnTypeName
        {
            get
            {
                switch (FColumnType)
                {
                    case "0":
                        return "普通页面";
                    case "1":
                        return "首页";
                    default:
                        return "普通页面";
                }
            }
        }

        public string FColumnUrl { get; set; }

        public string FColumnTarget { get; set; }

        public string FColumnTargetName
        {
            get
            {
                switch (FColumnTarget)
                {
                    case "0":
                        return "本窗口";
                    case "1":
                        return "新窗口";
                    default:
                        return "本窗口";
                }
            }
        }

        public string FColumnVisible { get; set;}

        public string FColumnVisibleName
        {
            get
            {
                switch (FColumnVisible)
                {
                    case "0":
                        return "隐藏";
                    case "1":
                        return "显示";
                    default:
                        return "显示";
                }
            }
        }

        public int FColumnOrder { get; set;}

        public Int64 FParentColumnId { get; set; }

        public string FOperation
        {
            get
            {
                string _rnt;
                _rnt = "<a href=\"javascript:void(0)\" onclick=\"downclass(" + FColumnId.ToString() + ")\">下级栏目</a>";
                _rnt += "&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"javascript:void(0)\" onclick=\"edititem(" + FColumnId.ToString() + ")\">编辑</a>";
                _rnt += "&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"javascript:void(0)\" onclick=\"nav(" + FColumnId.ToString() + ")\">导航设置</a>";
                _rnt += "&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"javascript:void(0)\" onclick=\"module(" + FColumnId.ToString() + ")\">模块设置</a>";
                _rnt += "&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"javascript:void(0)\" onclick=\"define(" + FColumnId.ToString() + ")\">局部定义</a>";
                return _rnt;
            }
        }

        public PortalColumn()
        {

        }

        public string  ToJson()
        {
 	        return Utils.ConvertToJson(this);
        }
    }
}
