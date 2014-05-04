using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQOnlineExam.ML;
using HQLib.Common;
using System.Collections.Specialized;
using HQOnlineExam.DA;
using HQLib;
using HQConst.Const;
namespace HQOnlineExam.Biz
{
    //OEExamPaper
    public partial class OEExamPaperBiz
    {

        public OEExamPaper Select(string id)
        {
            List<OEExamPaper> lists = new List<OEExamPaper>();
            NameValueCollection where = new NameValueCollection();
            where.Add("FPaperId", id);
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
        
        public List<OEExamPaper> Select(NameValueCollection where)
        {
            OEExamPaperDA da = new OEExamPaperDA();
            return da.Select(where).DataTableToList<OEExamPaper>();
        }

        public List<OEExamPaper> Select(NameValueCollection where, NameValueCollection orderby)
        {
            OEExamPaperDA da = new OEExamPaperDA();
            return da.Select(where, orderby).DataTableToList<OEExamPaper>();
        }

        public List<OEExamPaper> Select(NameValueCollection where, NameValueCollection orderby, int pageIndex, int pageSize, out int totalCount)
        {
            OEExamPaperDA da = new OEExamPaperDA();
            return da.Select(where, orderby, pageIndex, pageSize, out totalCount).DataTableToList<OEExamPaper>();
        }

        public Int64 Insert(NameValueCollection parameters, out ErrorEntity ErrInfo)
        {
            OEExamPaperDA da = new OEExamPaperDA();
            Int64 result = da.InsertAndReturnId64(parameters);
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

        public Int64 Insert(OEExamPaper item, out ErrorEntity ErrInfo)
        {
            //Error Judge Define
            if (item.FContentClassId == 0)
            {
                ErrInfo = new ErrorEntity("EP010001", "试卷所属内容类别不能为空!");
                return -1;
            }
            if (string.IsNullOrEmpty(item.FPaperName))
            {
                ErrInfo = new ErrorEntity("EP010002", "试卷名称不能为空!");
                return -1;
            }
            if (item.FPaperTotal == 0)
            {
                ErrInfo = new ErrorEntity("EP010003", "试卷总分不能为空或者等于零!");
                return -1;
            }
            if (item.FPassScore == 0)
            {
                ErrInfo = new ErrorEntity("EP010004", "试卷通过分数设定不能为空或者等于零");
                return -1;
            }
            if (item.FExamTime == 0)
            {
                ErrInfo = new ErrorEntity("EP010005", "考试时间不能为空或者等于零!");
                return -1;
            }
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FContentClassId", item.FContentClassId.ToString());
            parameters.Add("FPaperName", item.FPaperName);
            parameters.Add("FPaperTotal", item.FPaperTotal.ToString());
            parameters.Add("FPaperExtractWay", item.FPaperExtractWay);
            parameters.Add("FChooseItemWay", item.FChooseItemWay);
            parameters.Add("FPassScore", item.FPassScore.ToString());
            parameters.Add("FPaperContent", item.FPaperContent);
            parameters.Add("AUserId", item.AUserId.ToString());
            parameters.Add("FPaperStatus", item.FPaperStatus);
            parameters.Add("FExamTime", item.FExamTime.ToString());
            parameters.Add("FExamType", item.FExamType);
            parameters.Add("FExamAgain", item.FExamAgain);
            return Insert(parameters, out ErrInfo);
        }

        public int Update(NameValueCollection parameters, NameValueCollection where, out ErrorEntity ErrInfo)
        {
            OEExamPaperDA da = new OEExamPaperDA();
            int result = da.Update(parameters, where);
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

        public Int32 Update(OEExamPaper item, out ErrorEntity ErrInfo)
        {
            //Error Judge Define
            if (item.FContentClassId == 0)
            {
                ErrInfo = new ErrorEntity("EP010001", "试卷所属内容类别不能为空!");
                return -1;
            }
            if (string.IsNullOrEmpty(item.FPaperName))
            {
                ErrInfo = new ErrorEntity("EP010002", "试卷名称不能为空!");
                return -1;
            }
            if (item.FPaperTotal == 0)
            {
                ErrInfo = new ErrorEntity("EP010003", "试卷总分不能为空或者等于零!");
                return -1;
            }
            if (item.FPassScore == 0)
            {
                ErrInfo = new ErrorEntity("EP010004", "试卷通过分数设定不能为空或者等于零");
                return -1;
            }
            if (item.FExamTime == 0)
            {
                ErrInfo = new ErrorEntity("EP010005", "考试时间不能为空或者等于零!");
                return -1;
            }
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FContentClassId", item.FContentClassId.ToString());
            parameters.Add("FPaperName", item.FPaperName);
            parameters.Add("FPaperTotal", item.FPaperTotal.ToString());
            parameters.Add("FPaperExtractWay", item.FPaperExtractWay);
            parameters.Add("FChooseItemWay", item.FChooseItemWay);
            parameters.Add("FPassScore", item.FPassScore.ToString());
            parameters.Add("FPaperContent", item.FPaperContent);
            parameters.Add("AUserId", item.AUserId.ToString());
            parameters.Add("FPaperTime", item.FPaperTime.ToString());
            parameters.Add("FExamTime", item.FExamTime.ToString());
            parameters.Add("FExamType", item.FExamType);
            parameters.Add("FExamAgain", item.FExamAgain);
            NameValueCollection where = new NameValueCollection();
            where.Add("FPaperId", item.FPaperId.ToString());
            return Update(parameters, where, out ErrInfo);
        }

        public int Delete(string idlist, out ErrorEntity ErrInfo)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("condition", "FPaperId in (" + idlist + ")");
            return Delete(where, out ErrInfo);
        }

        public int Delete(NameValueCollection where, out ErrorEntity ErrInfo)
        {
            OEExamPaperDA da = new OEExamPaperDA();
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FPaperStatus", "0");
            int result = da.Update(parameters, where);
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

    }
}