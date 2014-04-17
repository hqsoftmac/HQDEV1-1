using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib.Interface;
using HQLib.Util;

namespace HQOnlineExam.ML
{
    [Serializable]
    public class OEContentClassTree :OEContentClass ,IDatasource
    {
        public List<OEContentClassTree> children { get; set; }

        public OEContentClassTree()
        {

        }

        string IDatasource.ToJson()
        {
            return Utils.ConvertToJson(this);
        }
    }
}
