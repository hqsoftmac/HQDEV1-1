using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib.Interface;
using HQLib.Util;

namespace HQPortal.ML
{
    public class PortalProduct:IDatasource
    {
        public Int64 FProductId { get; set; }

        public Int64 FProductListID { get; set; }

        public string FProductName { get; set; }

        public string FProductModule { get; set; }

        public string FProductDesc { get; set; }

        public string FProductPic { get; set; }

        public string FBriefPic { get; set; }

        public string FSEOTitle { get; set; }

        public string FSEOKeyWord { get; set; }

        public string FSEODesc { get; set; }

        public string FProductBrief { get; set; }

        public string FProductContent { get; set; }

        public string FOperation
        {
            get
            {
                return "<a href='javascript:void(0)' onclick='editproduct(" + FProductId.ToString() + ")'>编辑</a>";
            }
        }

        public PortalProduct()
        {

        }

        public string ToJson()
        {
            return Utils.ConvertToJson(this);
        }
    }
}
