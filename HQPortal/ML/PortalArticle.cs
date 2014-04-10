using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib.Interface;
using HQLib.Util;

namespace HQPortal.ML
{
    [Serializable]
    public class PortalArticle :IDatasource
    {
        public Int64 FArticleId { get; set; }

        public Int64 FListId { get; set; }

        public string FArticleTitle { get; set; }

        public string FArticleStyle { get; set; }

        public string FArticleAuthor { get; set; }

        public string FArticleComeFrom { get; set; }

        public DateTime FArticleTime { get; set; }

        public string FArticleTimeStr
        {
            get
            {
                return FArticleTime.Year.ToString() + "-" + FArticleTime.Month.ToString() + "-" + FArticleTime.Day.ToString();
            }
        }

        public Int32 FArticleClickNum { get; set; }

        public string FArticleUrl { get; set; }

        public string FArticlePic { get; set; }

        public string FArticlePicFlag { get; set; }

        public string FArticlePicFlagName
        {
            get
            {
                switch (FArticlePicFlag)
                {
                    case "0":
                        return "关闭缩略图";
                    case "1":
                        return "生成缩略图";
                    default:
                        return "关闭缩略图";
                }
            }
        }

        public string FSEOTitle { get; set; }

        public string FSEOKeyWord { get; set; }

        public string FSEODescription { get; set; }

        public string FCommentFlag { get; set; }

        public string FCommentFlagName
        {
            get
            {
                switch (FCommentFlag)
                {
                    case "0":
                        return "评论关闭";
                    case "1":
                        return "评论开启(需要审核)";
                    case "2":
                        return "评论开启(直接显示)";
                    default:
                        return "评论关闭";
                }
            }
        }

        public string FBriefContent { get; set; }

        public string FContent { get; set; }

        public string FRecommendFlag { get; set; }

        public string FRecommendFlagName
        {
            get
            {
                if (FRecommendFlag == "1")
                {
                    return "<span style='color:red;'>推荐</span>";
                }
                else
                {
                    return "";
                }
            }
        }

        public string FOperation
        {
            get
            {
                if (FRecommendFlag == "0")
                {
                    return "<a href='javascript:void(0)' onclick='editarticle(" + FArticleId.ToString() + ")'>编辑</a>&nbsp;&nbsp;<a href='javascript:void(0)' onclick='recommend(" + FArticleId.ToString() + ")'>推荐</a>";
                }
                else
                {
                    return "<a href='javascript:void(0)' onclick='editarticle(" + FArticleId.ToString() + ")'>编辑</a>&nbsp;&nbsp;<a href='javascript:void(0)' onclick='unrecommend(" + FArticleId.ToString() + ")'>取消推荐</a>";
                }
            }
        }

        public PortalArticle()
        {

        }

        public string ToJson()
        {
            return Utils.ConvertToJson(this);
        }
    }
}
