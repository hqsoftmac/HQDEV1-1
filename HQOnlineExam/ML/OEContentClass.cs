using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HQOnlineExam.ML
{
    [Serializable]
    public class OEContentClass 
    {
        public Int64 FContentClassId { get; set; }

        public string FContentClassCode { get; set; }

        public string FContentClassName { get; set; }

        public string FContentClassContent { get; set; }

        public Int64 FParentId { get; set; }

        public OEContentClass()
        {

        }



    }
}
