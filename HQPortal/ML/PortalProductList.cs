using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib.Interface;
using HQLib.Util;

namespace HQPortal.ML
{
    public class PortalProductList:IDatasource
    {
        public Int64 FProductListID { get; set; }

        public string FProductListName { get; set; }

        public Int64 FParentListId { get; set; }

        public Int32 FProductListOrder { get; set; }

        public string FOperation
        {
            get
            {
                return "<a href='javascript:void(0)' onclick='childlist(" + FProductListID.ToString() + ")'>下级目录</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href='javascript:void(0)' onclick='editlist(" + FProductListID.ToString() + ")'>编辑</a>";
            }
        }

        public PortalProductList()
        {

        }


        public string ToJson()
        {
            return Utils.ConvertToJson(this);
        }
    }
}
