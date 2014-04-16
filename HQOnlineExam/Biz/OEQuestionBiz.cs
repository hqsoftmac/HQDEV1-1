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
    //OEQuestion
    public partial class OEQuestionBiz
    {

        public List<OEQuestion> Select(NameValueCollection where)
        {
            OEQuestionDA da = new OEQuestionDA();
            return da.Select(where).DataTableToList<OEQuestion>();
        }

        public List<OEQuestion> Select(NameValueCollection where, NameValueCollection orderby)
        {
            OEQuestionDA da = new OEQuestionDA();
            return da.Select(where, orderby).DataTableToList<OEQuestion>();
        }

        public List<OEQuestion> Select(NameValueCollection where, NameValueCollection orderby, int pageIndex, int pageSize, out int totalCount)
        {
            OEQuestionDA da = new OEQuestionDA();
            return da.Select(where, orderby, pageIndex, pageSize, out totalCount).DataTableToList<OEQuestion>();
        }

        public Int64 Insert(NameValueCollection parameters, out ErrorEntity ErrInfo)
        {
            OEQuestionDA da = new OEQuestionDA();
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

        public Int64 Insert(OEQuestion item, out ErrorEntity ErrInfo)
        {
            //Error Judge Define

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FQBankId", item.FQBankId.ToString());
            parameters.Add("FQuestionTitle", item.FQuestionTitle);
            parameters.Add("FQuestionType", item.FQuestionType);
            parameters.Add("FQuestionDifficulty", item.FQuestionDifficulty);
            parameters.Add("FKeyWord", item.FKeyWord);
            parameters.Add("FQuestionDesc", item.FQuestionDesc);
            parameters.Add("FQuestionAnalysis", item.FQuestionAnalysis);
            parameters.Add("FQuestionStatus", item.FQuestionStatus);
            parameters.Add("FQuestionDateTime", item.FQuestionDateTime.ToString());
            parameters.Add("AUserId", item.AUserId.ToString());
            parameters.Add("AUserName", item.AUserName);
            return Insert(parameters, out ErrInfo);
        }

        public int Update(NameValueCollection parameters, NameValueCollection where, out ErrorEntity ErrInfo)
        {
            OEQuestionDA da = new OEQuestionDA();
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

        public Int32 Update(OEQuestion item, out ErrorEntity ErrInfo)
        {
            //Error Judge Define

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FQBankId", item.FQBankId.ToString());
            parameters.Add("FQuestionTitle", item.FQuestionTitle);
            parameters.Add("FQuestionType", item.FQuestionType);
            parameters.Add("FQuestionDifficulty", item.FQuestionDifficulty);
            parameters.Add("FKeyWord", item.FKeyWord);
            parameters.Add("FQuestionDesc", item.FQuestionDesc);
            parameters.Add("FQuestionAnalysis", item.FQuestionAnalysis);
            parameters.Add("FQuestionStatus", item.FQuestionStatus);
            parameters.Add("FQuestionDateTime", item.FQuestionDateTime.ToString());
            parameters.Add("AUserId", item.AUserId.ToString());
            parameters.Add("AUserName", item.AUserName);
            NameValueCollection where = new NameValueCollection();
            where.Add("FQuestionId", item.FQuestionId.ToString());
            return Update(parameters, where, out ErrInfo);
        }

        public int Delete(string idlist, out ErrorEntity ErrInfo)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("condition", "FQuestionId in (" + idlist + ")");
            return Delete(where, out ErrInfo);
        }

        public int Delete(NameValueCollection where, out ErrorEntity ErrInfo)
        {
            OEQuestionDA da = new OEQuestionDA();
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
