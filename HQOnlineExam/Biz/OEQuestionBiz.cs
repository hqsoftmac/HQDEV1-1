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
        public OEQuestion Select(string _id)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("FQuestionId", _id);
            List<OEQuestion> lists = new List<OEQuestion>();
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
            if (item.FQBankId == 0)
            {
                ErrInfo = new ErrorEntity("OQ010001", "所属题库不能为空!");
                return -1;
            }
            if (string.IsNullOrEmpty(item.FQuestionTitle))
            {
                ErrInfo = new ErrorEntity("OQ010002", "题目标题不能为空!");
                return -1;
            }
            if (string.IsNullOrEmpty(item.FQuestionType))
            {
                ErrInfo = new ErrorEntity("OQ010003", "题目类型不能为空!");
                return -1;
            }
            if (string.IsNullOrEmpty(item.FQuestionDifficulty))
            {
                ErrInfo = new ErrorEntity("OQ010004", "题目难度不能为空!");
                return -1;
            }
            if (string.IsNullOrEmpty(item.FKeyWord))
            {
                ErrInfo = new ErrorEntity("OQ010005", "题目关键字不能为空!");
                return -1;
            }
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FQBankId", item.FQBankId.ToString());
            parameters.Add("FQuestionTitle", item.FQuestionTitle);
            parameters.Add("FQuestionType", item.FQuestionType);
            parameters.Add("FQuestionDifficulty", item.FQuestionDifficulty);
            parameters.Add("FKeyWord", item.FKeyWord);
            parameters.Add("FQuestionDesc", item.FQuestionDesc);
            parameters.Add("FQuestionAnalysis", item.FQuestionAnalysis);
            parameters.Add("AUserId", item.AUserId.ToString());
            parameters.Add("AUserName", item.AUserName);
            return Insert(parameters, out ErrInfo);
        }

        public int UpdateStatus(string _id, string _status,out ErrorEntity ErrInfo)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("FQuestionId", _id);
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FQuestionStatus", _status);
            return Update(parameters, where, out ErrInfo);
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
            if (item.FQBankId == 0)
            {
                ErrInfo = new ErrorEntity("OQ010001", "所属题库不能为空!");
                return -1;
            }
            if (string.IsNullOrEmpty(item.FQuestionTitle))
            {
                ErrInfo = new ErrorEntity("OQ010002", "题目标题不能为空!");
                return -1;
            }
            if (string.IsNullOrEmpty(item.FQuestionType))
            {
                ErrInfo = new ErrorEntity("OQ010003", "题目类型不能为空!");
                return -1;
            }
            if (string.IsNullOrEmpty(item.FQuestionDifficulty))
            {
                ErrInfo = new ErrorEntity("OQ010004", "题目难度不能为空!");
                return -1;
            }
            if (string.IsNullOrEmpty(item.FKeyWord))
            {
                ErrInfo = new ErrorEntity("OQ010005", "题目关键字不能为空!");
                return -1;
            }
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FQBankId", item.FQBankId.ToString());
            parameters.Add("FQuestionTitle", item.FQuestionTitle);
            parameters.Add("FQuestionType", item.FQuestionType);
            parameters.Add("FQuestionDifficulty", item.FQuestionDifficulty);
            parameters.Add("FKeyWord", item.FKeyWord);
            parameters.Add("FQuestionDesc", item.FQuestionDesc);
            parameters.Add("FQuestionAnalysis", item.FQuestionAnalysis);
            parameters.Add("FQuestionDateTime", DateTime.Today.ToString());
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
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FQuestionStatus", "0");
            return Update(parameters, where, out ErrInfo);
        }

    }
}
