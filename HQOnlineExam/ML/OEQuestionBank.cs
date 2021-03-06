﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib.Interface;
using HQLib.Util;

namespace HQOnlineExam.ML
{
    [Serializable]
    public class OEQuestionBank :IDatasource
    {
        public Int64 FQBankId { get; set; }

        public Int64 FContentClassId { get; set; }

        public string FContentClassCode { get; set; }

        public string FContentClassName { get; set; }

        public string FQBankCode { get; set; }

        public string FQBankName { get; set; }

        public string FDisplayQBankName
        {
            get
            {
                return "[" + FQBankCode + "]" + FQBankName;
            }
        }

        public string FQBankStatus { get; set; }

        public string FQBankStatusName
        {
            get
            {
                switch (FQBankStatus)
                {
                    case "0":
                        return "停用";
                    case "1":
                        return "启用";
                    default:
                        return "停用";
                }
            }
        }

        public string FQBankContent { get; set; }

        public string FOperation
        {
            get
            {
                string rnt = "<a href='javascript:void(0)' onclick='edit(" + FQBankId.ToString() + ")'>编辑</a>";
                if (FQBankStatus == "1")
                {
                    rnt += "&nbsp;&nbsp;&nbsp;&nbsp;<a href='javascript:void(0)' onclick='bankstatus(" + FQBankId.ToString() + ",\"0\")'>停用</a>";
                }
                else
                {
                    rnt += "&nbsp;&nbsp;&nbsp;&nbsp;<a href='javascript:void(0)' onclick='bankstatus(" + FQBankId.ToString() + ",\"1\")'>启用</a>";
                }
                return rnt;
            }
        }

        public OEQuestionBank()
        {

        }


        public string ToJson()
        {
            return Utils.ConvertToJson(this);
        }
    }
}
