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
    //OEPaperDetailQuestion
    public partial class OEPaperDetailQuestionBiz
    {

        public List<OEPaperDetailQuestion> Select(NameValueCollection where)
        {
            OEPaperDetailQuestionDA da = new OEPaperDetailQuestionDA();
            return da.Select(where).DataTableToList<OEPaperDetailQuestion>();
        }

        public List<OEPaperDetailQuestion> Select(NameValueCollection where, NameValueCollection orderby)
        {
            OEPaperDetailQuestionDA da = new OEPaperDetailQuestionDA();
            return da.Select(where, orderby).DataTableToList<OEPaperDetailQuestion>();
        }

        public List<OEPaperDetailQuestion> Select(NameValueCollection where, NameValueCollection orderby, int pageIndex, int pageSize, out int totalCount)
        {
            OEPaperDetailQuestionDA da = new OEPaperDetailQuestionDA();
            return da.Select(where, orderby, pageIndex, pageSize, out totalCount).DataTableToList<OEPaperDetailQuestion>();
        }

        public Int32 Insert(NameValueCollection parameters, out ErrorEntity ErrInfo)
        {
            OEPaperDetailQuestionDA da = new OEPaperDetailQuestionDA();
            Int32 result = da.Insert(parameters);
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

        public Int32 Insert(OEPaperDetailQuestion item, out ErrorEntity ErrInfo)
        {
            //Error Judge Define

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FPaperId", item.FPaperId.ToString());
            parameters.Add("FDetailSetId", item.FDetailSetId.ToString());
            parameters.Add("FQuestionId", item.FQuestionId.ToString());
            return Insert(parameters, out ErrInfo);
        }

        public int Update(NameValueCollection parameters, NameValueCollection where, out ErrorEntity ErrInfo)
        {
            OEPaperDetailQuestionDA da = new OEPaperDetailQuestionDA();
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

        public Int32 Update(OEPaperDetailQuestion item, out ErrorEntity ErrInfo)
        {
            //Error Judge Define

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FPaperId", item.FPaperId.ToString());
            parameters.Add("FDetailSetId", item.FDetailSetId.ToString());
            parameters.Add("FQuestionId", item.FQuestionId.ToString());
            NameValueCollection where = new NameValueCollection();
            where.Add("FPaperId", item.FPaperId.ToString());
            where.Add("FDetailSetId", item.FDetailSetId.ToString());
            where.Add("FQuestionId", item.FQuestionId.ToString());
            return Update(parameters, where, out ErrInfo);
        }


        public int Delete(NameValueCollection where, out ErrorEntity ErrInfo)
        {
            OEPaperDetailQuestionDA da = new OEPaperDetailQuestionDA();
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