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
        public int UpdateStatus(string _id, string _status, out ErrorEntity ErrInfo)
        {
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FQBankStatus", _status);
            NameValueCollection where = new NameValueCollection();
            where.Add("FQBankId", _id);
            return Update(parameters, where, out ErrInfo);
        }
        
        public OEQuestionBank Select(string _id)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("FQBankId", _id);
            List<OEQuestionBank> lists = new List<OEQuestionBank>();
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

        public Boolean ChkCodeDuplicate(string _id, string _code)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("FQBankId <>", _id);
            where.Add("FQBankCode", _code);
            if (Select(where).Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
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
            if (item.FContentClassId == 0)
            {
                ErrInfo = new ErrorEntity("QB010001", "内容类别不能为空!");
                return -1;
            }
            if (string.IsNullOrEmpty(item.FQBankCode))
            {
                ErrInfo = new ErrorEntity("QB010002", "题库编号不能为空!");
                return -1;
            }
            if (string.IsNullOrEmpty(item.FQBankName))
            {
                ErrInfo = new ErrorEntity("QB010003", "题库名称不能为空!");
                return -1;
            }

            if (!ChkCodeDuplicate(item.FQBankId.ToString(), item.FQBankCode))
            {
                ErrInfo = new ErrorEntity("QB010004", "题库编号重复,不能保存!");
                return -1;
            }
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FContentClassId", item.FContentClassId.ToString());
            parameters.Add("FQBankCode", item.FQBankCode);
            parameters.Add("FQBankName", item.FQBankName);
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
            if (item.FContentClassId == 0)
            {
                ErrInfo = new ErrorEntity("QB010001", "内容类别不能为空!");
                return -1;
            }
            if (string.IsNullOrEmpty(item.FQBankCode))
            {
                ErrInfo = new ErrorEntity("QB010002", "题库编号不能为空!");
                return -1;
            }
            if (string.IsNullOrEmpty(item.FQBankName))
            {
                ErrInfo = new ErrorEntity("QB010003", "题库名称不能为空!");
                return -1;
            }

            if (!ChkCodeDuplicate(item.FQBankId.ToString(), item.FQBankCode))
            {
                ErrInfo = new ErrorEntity("QB010004", "题库编号重复,不能保存!");
                return -1;
            }
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FContentClassId", item.FContentClassId.ToString());
            parameters.Add("FQBankCode", item.FQBankCode);
            parameters.Add("FQBankName", item.FQBankName);
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
