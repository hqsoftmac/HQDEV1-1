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
    //OEStudentPractice
    public partial class OEStudentPracticeBiz
    {

        public List<OEStudentPractice> Select(NameValueCollection where)
        {
            OEStudentPracticeDA da = new OEStudentPracticeDA();
            return da.Select(where).DataTableToList<OEStudentPractice>();
        }

        public List<OEStudentPractice> Select(NameValueCollection where, NameValueCollection orderby)
        {
            OEStudentPracticeDA da = new OEStudentPracticeDA();
            return da.Select(where, orderby).DataTableToList<OEStudentPractice>();
        }

        public List<OEStudentPractice> Select(NameValueCollection where, NameValueCollection orderby, int pageIndex, int pageSize, out int totalCount)
        {
            OEStudentPracticeDA da = new OEStudentPracticeDA();
            return da.Select(where, orderby, pageIndex, pageSize, out totalCount).DataTableToList<OEStudentPractice>();
        }

        public Int32 Insert(NameValueCollection parameters, out ErrorEntity ErrInfo)
        {
            OEStudentPracticeDA da = new OEStudentPracticeDA();
            Int32  result = da.Insert(parameters);
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

        public Int32 Insert(OEStudentPractice item, out ErrorEntity ErrInfo)
        {
            //Error Judge Define

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FPracticeId", item.FPracticeId.ToString());
            parameters.Add("FStudentId", item.FStudentId.ToString());
            parameters.Add("FContentClassId", item.FContentClassId.ToString());
            parameters.Add("FQBankId", item.FQBankId.ToString());
            parameters.Add("FQuestionId", item.FQuestionId.ToString());
            parameters.Add("FPracticeAnswer", item.FPracticeAnswer);
            parameters.Add("FPassResult", item.FPassResult);
            parameters.Add("FPracticeTime", item.FPracticeTime.ToString());
            return Insert(parameters, out ErrInfo);
        }

        public int Update(NameValueCollection parameters, NameValueCollection where, out ErrorEntity ErrInfo)
        {
            OEStudentPracticeDA da = new OEStudentPracticeDA();
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

        public Int32 Update(OEStudentPractice item, out ErrorEntity ErrInfo)
        {
            //Error Judge Define

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FPracticeId", item.FPracticeId.ToString());
            parameters.Add("FStudentId", item.FStudentId.ToString());
            parameters.Add("FContentClassId", item.FContentClassId.ToString());
            parameters.Add("FQBankId", item.FQBankId.ToString());
            parameters.Add("FQuestionId", item.FQuestionId.ToString());
            parameters.Add("FPracticeAnswer", item.FPracticeAnswer);
            parameters.Add("FPassResult", item.FPassResult);
            parameters.Add("FPracticeTime", item.FPracticeTime.ToString());
            NameValueCollection where = new NameValueCollection();
            where.Add("FPracticeId", item.FPracticeId.ToString());
            return Update(parameters, where, out ErrInfo);
        }


        public int Delete(NameValueCollection where, out ErrorEntity ErrInfo)
        {
            OEStudentPracticeDA da = new OEStudentPracticeDA();
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