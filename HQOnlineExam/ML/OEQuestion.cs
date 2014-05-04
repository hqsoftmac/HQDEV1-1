using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib.Interface;
using HQLib.Util;
using HQLib.Common;

namespace HQOnlineExam.ML
{
    [Serializable]
    public class OEQuestion : IDatasource
    {
        public Int64 FQuestionId { get; set; }

        public Int64 FContentClassId { get; set; }

        public string FContentClassCode { get; set; }

        public string FContentClassName { get; set; }

        public Int64 FQBankId { get; set; }

        public string FQBankCode { get; set; }

        public string FQBankName { get; set; }

        public string FQuestionTitle { get; set; }

        public string FQuestionDisplayTitle
        {
            get
            {
                string rnt = PublicMethod.NoHTML(FQuestionTitle);
                if (rnt.Length > 30)
                {
                    rnt = rnt.Substring(0, 30) + "...";
                }
                return rnt;
            }
        }

        public string FQuestionType { get; set; }

        public string FQuestionTypeName
        {
            get
            {
                switch (FQuestionType)
                {
                    case "0":
                        return "判断题";
                    case "1":
                        return "单项选择题";
                    case "2":
                        return "多项选择题";
                    case "3":
                        return "填空题";
                    case "4":
                        return "综合应用题";
                    default:
                        return "未知题型";
                }
            }
        }

        public string FQuestionDifficulty { get; set; }

        public string FQuestionDifficultyName
        {
            get
            {
                switch (FQuestionDifficulty)
                {
                    case "0":
                        return "低";
                    case "1":
                        return "中";
                    case "2":
                        return "高";
                    default:
                        return "未知";
                }
            }
        }

        public string FKeyWord { get; set; }

        public string FQuestionDesc { get; set; }

        public string FQuestionAnalysis { get; set; }

        public string FQuestionStatus { get; set; }

        public string FQuestionStatusName
        {
            get
            {
                switch (FQuestionStatus)
                {
                    case "0":
                        return "删除";
                    case "1":
                        return "启用";
                    case "2":
                        return "停用";
                    default:
                        return "未知";
                }
            }
        }

        public DateTime FQuestionDateTime { get; set; }

        public string FQuestionDateTimeStr
        {
            get
            {
                return FQuestionDateTime.ToString("yyyy-MM-dd hh:mm:ss");
            }
        }

        public Int64 AUserId { get; set; }

        public string AUserName { get; set; }

        public string FOperation
        {
            get
            {
                string rnt = "";
                rnt += "<a href='javascript:void(0)' onclick='edit(" + FQuestionId.ToString() + ")'>编辑</a>";
                rnt += "&nbsp;&nbsp;&nbsp;&nbsp;<a href='javascript:void(0)' onclick='setitem(" + FQuestionId.ToString() + ")'>设置答案</a>";
                switch (FQuestionStatus)
                {
                    case "1":
                        rnt += "&nbsp;&nbsp;&nbsp;&nbsp;<a href='javascript:void(0)' onclick='status(" + FQuestionId.ToString() + ",\"2\")'>停用</a>";
                        break;
                    case "2":
                        rnt += "&nbsp;&nbsp;&nbsp;&nbsp;<a href='javascript:void(0)' onclick='status(" + FQuestionId.ToString() + ",\"1\")'>恢复</a>";
                        break;
                    case "0":
                        rnt += "&nbsp;&nbsp;&nbsp;&nbsp;<a href='javascript:void(0)' onclick='status(" + FQuestionId.ToString() + ",\"1\")'>启用</a>";
                        break;
                    default:
                        rnt += "";
                        break;
                }
                return rnt;
            }
        }

        public string FOperation1
        {
            get
            {
                return "<a href='javascript:void(0)' onclick='window.open (\"../onlineexam/questionview.aspx?qid=" + FQuestionId.ToString() + "\", \"newwindow\", \"height=600px, width=800px, scrollbars=yes, resizable=yes\")'>查看</a>";
            }
        }

        public OEQuestion()
        {
        }

        public string ToJson()
        {
            return Utils.ConvertToJson(this);
        }

    }
}
