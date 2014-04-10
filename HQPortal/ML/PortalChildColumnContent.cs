using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib.Interface;
using HQLib.Util;

namespace HQPortal.ML
{
    [Serializable]
    public class PortalChildColumnContent:IDatasource
    {
        public Int64 FCCContentId { get; set; }

        public Int64 FChildColumnId { get; set; }

        public string FCCContentText { get; set; }

        public string FSEOTitle { get; set; }

        public string FSEOKeyWord { get; set; }

        public string FSEODescription { get; set; }

        public string FOperation
        {
            get
            {
                return "";
            }
        }

        public PortalChildColumnContent()
        {

        }

        public string ToJson()
        {
            return Utils.ConvertToJson(this);
        }
    }
}
