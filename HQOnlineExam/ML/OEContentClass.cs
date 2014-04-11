using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib.Interface;
using HQLib.Util;

namespace HQOnlineExam.ML
{
    [Serializable]
    public class OEContentClass :IDatasource
    {
        public Int64 FContentClassId { get; set; }

        public string FContentClassCode { get; set; }

        public string FContentClassName { get; set; }

        public string FContentClassContent { get; set; }

        public Int64 FParentId { get; set; }

        public OEContentClass()
        {

        }

        public string ToJson()
        {
            return Utils.ConvertToJson(this);
        }
    }
}
