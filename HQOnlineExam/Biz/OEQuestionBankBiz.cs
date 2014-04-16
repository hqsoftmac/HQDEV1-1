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
    //OEQuestionBank
    public partial class OEQuestionBankBiz
    {

        public List<OEQuestionBank> Select(NameValueCollection where)
        {
            OEQuestionBankDA da = new OEQuestionBankDA();
            return da.Select(where).DataTableToList<OEQuestionBank>();
        }

        public List<OEQuestionBank> Select(NameValueCollection where, NameValueCollection orderby)
        {
            OEQuestionBankDA da = new OEQuestionBankDA();
            return da.Select(where, orderby).DataTableToList<OEQuestionBank>();
        }

        public List<OEQuestionBank> Select(NameValueCollection where, NameValueCollection orderby, int pageIndex, int pageSize, out int totalCount)
        {
            OEQuestionBankDA da = new OEQuestionBankDA();
            return da.Select(where, orderby, pageIndex, pageSize, out totalCount).DataTableToList<OEQuestionBank>();
        }

        public Int64 Insert(NameValueCollection parameters, out ErrorEntity ErrInfo)
        {
            OEQuestionBankDA da = new OEQuestionBankDA();
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

        public Int64 Insert(OEQuestionBank item, out ErrorEntity ErrInfo)
        {
            //Error Judge Define

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FContentClassId", item.FContentClassId.ToString());
            parameters.Add("FQBankCode", item.FQBankCode);
            parameters.Add("FQBankName", item.FQBankName);
            parameters.Add("FQBankStatus", item.FQBankStatus);
            parameters.Add("FQBankContent", item.FQBankContent);
            return Insert(parameters, out ErrInfo);
        }

        public int Update(NameValueCollection parameters, NameValueCollection where, out ErrorEntity ErrInfo)
        {
            OEQuestionBankDA da = new OEQuestionBankDA();
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

        public Int32 Update(OEQuestionBank item, out ErrorEntity ErrInfo)
        {
            //Error Judge Define

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FContentClassId", item.FContentClassId.ToString());
            parameters.Add("FQBankCode", item.FQBankCode);
            parameters.Add("FQBankName", item.FQBankName);
            parameters.Add("FQBankStatus", item.FQBankStatus);
            parameters.Add("FQBankContent", item.FQBankContent);
            NameValueCollection where = new NameValueCollection();
            where.Add("FQBankId", item.FQBankId.ToString());
            return Update(parameters, where, out ErrInfo);
        }

        public int Delete(string idlist, out ErrorEntity ErrInfo)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("condition", "FQBankId in (" + idlist + ")");
            return Delete(where, out ErrInfo);
        }

        public int Delete(NameValueCollection where, out ErrorEntity ErrInfo)
        {
            OEQuestionBankDA da = new OEQuestionBankDA();
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
