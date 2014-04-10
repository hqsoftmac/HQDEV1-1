using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib.Interface;
using HQLib.Util;

namespace HQPortal.ML
{
    [Serializable]
    public class PortalArticleList:IDatasource
    {
        public Int64 FListId { get; set; }

        public string FListCode { get; set; }

        public string FListName { get; set; }

        public Int64 FParentListId { get; set; }

        public Int32 FListOrder { get; set; }

        public string FOperation
        {
            get
            {
                return "<a href='javascript:void(0)' onclick='childlist(" + FListId.ToString() + ")'>下级目录</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href='javascript:void(0)' onclick='editlist(" + FListId.ToString() + ")'>编辑</a>";
            }
        }

        public PortalArticleList()
        {

        }

        public string ToJson()
        {
            return Utils.ConvertToJson(this);
        }
    }
}
