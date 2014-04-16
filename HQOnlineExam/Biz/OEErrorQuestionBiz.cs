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
    //OEErrorQuestion
    public partial class OEErrorQuestionBiz
    {

        public List<OEErrorQuestion> Select(NameValueCollection where)
        {
            OEErrorQuestionDA da = new OEErrorQuestionDA();
            return da.Select(where).DataTableToList<OEErrorQuestion>();
        }

        public List<OEErrorQuestion> Select(NameValueCollection where, NameValueCollection orderby)
        {
            OEErrorQuestionDA da = new OEErrorQuestionDA();
            return da.Select(where, orderby).DataTableToList<OEErrorQuestion>();
        }

        public List<OEErrorQuestion> Select(NameValueCollection where, NameValueCollection orderby, int pageIndex, int pageSize, out int totalCount)
        {
            OEErrorQuestionDA da = new OEErrorQuestionDA();
            return da.Select(where, orderby, pageIndex, pageSize, out totalCount).DataTableToList<OEErrorQuestion>();
        }

        public Int32 Insert(NameValueCollection parameters, out ErrorEntity ErrInfo)
        {
            OEErrorQuestionDA da = new OEErrorQuestionDA();
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

        public Int32 Insert(OEErrorQuestion item, out ErrorEntity ErrInfo)
        {
            //Error Judge Define

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FStudentId", item.FStudentId.ToString());
            parameters.Add("FQuestionId", item.FQuestionId.ToString());
            parameters.Add("FCollectFlag", item.FCollectFlag);
            return Insert(parameters, out ErrInfo);
        }

        public int Update(NameValueCollection parameters, NameValueCollection where, out ErrorEntity ErrInfo)
        {
            OEErrorQuestionDA da = new OEErrorQuestionDA();
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

        public Int32 Update(OEErrorQuestion item, out ErrorEntity ErrInfo)
        {
            //Error Judge Define

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FStudentId", item.FStudentId.ToString());
            parameters.Add("FQuestionId", item.FQuestionId.ToString());
            parameters.Add("FCollectFlag", item.FCollectFlag);
            NameValueCollection where = new NameValueCollection();
            where.Add("FStudentId", item.FStudentId.ToString());
            where.Add("FQuestionId", item.FQuestionId.ToString());
            return Update(parameters, where, out ErrInfo);
        }


        public int Delete(NameValueCollection where, out ErrorEntity ErrInfo)
        {
            OEErrorQuestionDA da = new OEErrorQuestionDA();
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