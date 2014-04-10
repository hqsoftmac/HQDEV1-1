using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib.Common;
using HQPortal.ML;
using System.Collections.Specialized;
using HQPortal.DA;
using HQLib;
using HQConst.Const;

namespace HQPortal.Biz
{
    public class PortalArticleBiz
    {
        public List<PortalArticle> Select(NameValueCollection where)
        {
            PortalArticleDA da = new PortalArticleDA();
            return da.Select(where).DataTableToList<PortalArticle>();
        }

        public PortalArticle Select(string _id)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("FArticleId", _id);
            List<PortalArticle> lists = new List<PortalArticle>();
            lists = Select(where);
            if (lists.Count > 0)
            {
                return lists[0];
            }
            else
            {
                return null;
            }
        }

        public List<PortalArticle> Select(NameValueCollection where, NameValueCollection orderby)
        {
            PortalArticleDA da = new PortalArticleDA();
            return da.Select(where, orderby).DataTableToList<PortalArticle>();
        }

        public List<PortalArticle> Select(NameValueCollection where, NameValueCollection orderby, int pageIndex, int pageSize, out int totalCount)
        {
            PortalArticleDA da = new PortalArticleDA();
            return da.Select(where, orderby, pageIndex, pageSize, out totalCount).DataTableToList<PortalArticle>();
        }

        public Int64 Insert(PortalArticle item, out ErrorEntity ErrInfo)
        {
            //if (item.FListId == 0)
            //{
            //    ErrInfo = new ErrorEntity(RespCode.Pa010001);
            //    return -1;
            //}
            if (string.IsNullOrEmpty(item.FArticleTitle))
            {
                ErrInfo = new ErrorEntity(RespCode.Pa010002);
                return -1;
            }
            if (item.FArticlePicFlag == "1")
            {
                if (string.IsNullOrEmpty(item.FArticlePic))
                {
                    ErrInfo = new ErrorEntity(RespCode.Pa010003);
                    return -1;
                }
            }
            NameValueCollection parameters = new NameValueCollection();
            if (item.FListId != 0)
            {
                parameters.Add("FListId", item.FListId.ToString());
            }
            parameters.Add("FArticleTitle", item.FArticleTitle);
            parameters.Add("FArticleStyle", item.FArticleStyle);
            if (string.IsNullOrEmpty(item.FArticleAuthor))
            {
                item.FArticleAuthor = "佚名";
            }
            parameters.Add("FArticleAuthor", item.FArticleAuthor);
            if(string.IsNullOrEmpty(item.FArticleComeFrom))
            {
                item.FArticleComeFrom = "未知";
            }
            parameters.Add("FArticleComeFrom", item.FArticleComeFrom);
            parameters.Add("FArticleTime", item.FArticleTime.ToString());
            parameters.Add("FArticleClickNum", item.FArticleClickNum.ToString());
            parameters.Add("FArticleUrl", item.FArticleUrl);
            if (!string.IsNullOrEmpty(item.FArticlePic))
            {
                parameters.Add("FArticlePic", item.FArticlePic);
            }
            parameters.Add("FArticlePicFlag", item.FArticlePicFlag);
            if (!string.IsNullOrEmpty(item.FSEOTitle))
            {
                parameters.Add("FSEOTitle", item.FSEOTitle);
            }
            if (!string.IsNullOrEmpty(item.FSEOKeyWord))
            {
                parameters.Add("FSEOKeyWord", item.FSEOKeyWord);
            }
            if (!string.IsNullOrEmpty(item.FSEODescription))
            {
                parameters.Add("FSEODescription", item.FSEODescription);
            }
            parameters.Add("FCommentFlag", item.FCommentFlag);
            parameters.Add("FBriefContent", item.FBriefContent);
            parameters.Add("FContent", item.FContent);
            return Insert(parameters, out ErrInfo);
        }

        public Int64 Insert(NameValueCollection parameters, out ErrorEntity ErrInfo)
        {
            PortalArticleDA da = new PortalArticleDA();
            try
            {
                Int64 result = da.Insert(parameters);
                if (result > 0)
                {
                    ErrInfo = new ErrorEntity(RespCode.Success);
                }
                else
                {
                    ErrInfo = new ErrorEntity(RespCode.SysError);
                }
                return result;
            }
            catch (Exception ex)
            {
                ErrInfo = new ErrorEntity("999999", ex.Message);
                return -1;
            }
        }

        public Int32 UpdateStatus(string _artid, string _recommendflag,out ErrorEntity ErrInfo)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("FArticleId", _artid);
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FRecommendFlag", _recommendflag);
            return Update(parameters, where, out ErrInfo);
        }

        public Int64 Update(PortalArticle item, out ErrorEntity ErrInfo)
        {
            //if (item.FListId == 0)
            //{
            //    ErrInfo = new ErrorEntity(RespCode.Pa010001);
            //    return -1;
            //}
            if (string.IsNullOrEmpty(item.FArticleTitle))
            {
                ErrInfo = new ErrorEntity(RespCode.Pa010002);
                return -1;
            }
            if (item.FArticlePicFlag == "1")
            {
                if (string.IsNullOrEmpty(item.FArticlePic))
                {
                    ErrInfo = new ErrorEntity(RespCode.Pa010003);
                    return -1;
                }
            }
            NameValueCollection parameters = new NameValueCollection();
            if (item.FListId != 0)
            {
                parameters.Add("FListId", item.FListId.ToString());
            }
            parameters.Add("FArticleTitle", item.FArticleTitle);
            parameters.Add("FArticleStyle", item.FArticleStyle);
            if (string.IsNullOrEmpty(item.FArticleAuthor))
            {
                item.FArticleAuthor = "佚名";
            }
            parameters.Add("FArticleAuthor", item.FArticleAuthor);
            if (string.IsNullOrEmpty(item.FArticleComeFrom))
            {
                item.FArticleComeFrom = "未知";
            }
            parameters.Add("FArticleComeFrom", item.FArticleComeFrom);
            parameters.Add("FArticleTime", item.FArticleTime.ToString());
            parameters.Add("FArticleClickNum", item.FArticleClickNum.ToString());
            parameters.Add("FArticleUrl", item.FArticleUrl);
            if (!string.IsNullOrEmpty(item.FArticlePic))
            {
                parameters.Add("FArticlePic", item.FArticlePic);
            }
            parameters.Add("FArticlePicFlag", item.FArticlePicFlag);
            if (!string.IsNullOrEmpty(item.FSEOTitle))
            {
                parameters.Add("FSEOTitle", item.FSEOTitle);
            }
            if (!string.IsNullOrEmpty(item.FSEOKeyWord))
            {
                parameters.Add("FSEOKeyWord", item.FSEOKeyWord);
            }
            if (!string.IsNullOrEmpty(item.FSEODescription))
            {
                parameters.Add("FSEODescription", item.FSEODescription);
            }
            parameters.Add("FCommentFlag", item.FCommentFlag);
            parameters.Add("FBriefContent", item.FBriefContent);
            parameters.Add("FContent", item.FContent);
            NameValueCollection where = new NameValueCollection();
            where.Add("FArticleId", item.FArticleId.ToString());
            if (Delete(where, out ErrInfo) >= 0)
            {
                return Insert(parameters, out ErrInfo);
            }
            else
            {
                return -1;
            }
        }

        public Int32 Update(NameValueCollection parameters, NameValueCollection where, out ErrorEntity ErrInfo)
        {
            PortalArticleDA da = new PortalArticleDA();
            Int32 result = da.Update(parameters, where);
            if (result > 0)
            {
                ErrInfo = new ErrorEntity(RespCode.Success);
            }
            else
            {
                ErrInfo = new ErrorEntity(RespCode.SysError);
            }
            return result;
        }

        public Int32 Delete(NameValueCollection where, out ErrorEntity ErrInfo)
        {
            PortalArticleDA da = new PortalArticleDA();
            Int32 result = da.Delete(where);
            if (result >= 0)
            {
                ErrInfo = new ErrorEntity(RespCode.Success);
            }
            else
            {
                ErrInfo = new ErrorEntity(RespCode.SysError);
            }
            return result;
        }

        public Int32 Delete(string idlist, out ErrorEntity ErrInfo)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("condition", "FArticleId in (" + idlist + ")");
            try
            {
                return Delete(where, out ErrInfo);
            }
            catch (Exception ex)
            {
                ErrInfo = new ErrorEntity("999999", ex.Message);
                return -1;
            }
        }
    }
}
