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

        public string FIconPath { get; set; }

        public string FOperation
        {
            get
            {
                string rnt = "<a href='javascript:void(0)' onclick='edit(" + FContentClassId.ToString() + ")'>编辑</a>";
                rnt += "&nbsp;&nbsp;<a href='javascript:void(0)' onclick='downclass(" + FContentClassId.ToString() + ")'>下级类别</a>";
                return rnt;
            }
        }

        public OEContentClass()
        {

        }

        public string ToJson()
        {
            return Utils.ConvertToJson(this);
        }
    }
}
