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
    //OECombineBank
    public partial class OECombineBankBiz
    {

        public List<OECombineBank> Select(NameValueCollection where)
        {
            OECombineBankDA da = new OECombineBankDA();
            return da.Select(where).DataTableToList<OECombineBank>();
        }

        public List<OECombineBank> Select(NameValueCollection where, NameValueCollection orderby)
        {
            OECombineBankDA da = new OECombineBankDA();
            return da.Select(where, orderby).DataTableToList<OECombineBank>();
        }

        public List<OECombineBank> Select(NameValueCollection where, NameValueCollection orderby, int pageIndex, int pageSize, out int totalCount)
        {
            OECombineBankDA da = new OECombineBankDA();
            return da.Select(where, orderby, pageIndex, pageSize, out totalCount).DataTableToList<OECombineBank>();
        }

        public Int32 Insert(NameValueCollection parameters, out ErrorEntity ErrInfo)
        {
            OECombineBankDA da = new OECombineBankDA();
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

        public Int32 Insert(OECombineBank item, out ErrorEntity ErrInfo)
        {
            //Error Judge Define

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FPaperId", item.FPaperId.ToString());
            parameters.Add("FQBankId", item.FQBankId.ToString());
            parameters.Add("FQBnakRate", item.FQBnakRate.ToString());
            return Insert(parameters, out ErrInfo);
        }

        public int Update(NameValueCollection parameters, NameValueCollection where, out ErrorEntity ErrInfo)
        {
            OECombineBankDA da = new OECombineBankDA();
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

        public Int32 Update(OECombineBank item, out ErrorEntity ErrInfo)
        {
            //Error Judge Define

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FPaperId", item.FPaperId.ToString());
            parameters.Add("FQBankId", item.FQBankId.ToString());
            parameters.Add("FQBnakRate", item.FQBnakRate.ToString());
            NameValueCollection where = new NameValueCollection();
            where.Add("FPaperId", item.FPaperId.ToString());
            where.Add("FQBankId", item.FQBankId.ToString());
            return Update(parameters, where, out ErrInfo);
        }


        public int Delete(NameValueCollection where, out ErrorEntity ErrInfo)
        {
            OECombineBankDA da = new OECombineBankDA();
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