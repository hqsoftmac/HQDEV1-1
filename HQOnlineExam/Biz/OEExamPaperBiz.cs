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
            parameters.Add("FPaperStatus", item.FPaperStatus);
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
            parameters.Add("FPaperStatus", item.FPaperStatus);
            NameValueCollection where = new NameValueCollection();
            where.Add("FPaperd", item.FPaperd.ToString());
            return Update(parameters, where, out ErrInfo);
        }

        public int Delete(string idlist, out ErrorEntity ErrInfo)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("condition", "FPaperd in (" + idlist + ")");
            return Delete(where, out ErrInfo);
        }

        public int Delete(NameValueCollection where, out ErrorEntity ErrInfo)
        {
            OEExamPaperDA da = new OEExamPaperDA();
            int result = da.Delete(where);
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