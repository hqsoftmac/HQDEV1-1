using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib.Interface;
using HQLib.Util;

namespace HQPortal.ML
{
    [Serializable]
    public class PortalNavStyle:IDatasource
    {
        public Int64 FNavStyleId { get; set; }

        public string FNavStyleName { get; set; }

        public string FNavStyleUrl { get; set; }

        public PortalNavStyle()
        {

        }

        public string ToJson()
        {
            return Utils.ConvertToJson(this);
        }
    }
}
