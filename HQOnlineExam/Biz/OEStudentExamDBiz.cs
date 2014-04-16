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
    //OEStudentExamD
    public partial class OEStudentExamDBiz
    {

        public List<OEStudentExamD> Select(NameValueCollection where)
        {
            OEStudentExamDDA da = new OEStudentExamDDA();
            return da.Select(where).DataTableToList<OEStudentExamD>();
        }

        public List<OEStudentExamD> Select(NameValueCollection where, NameValueCollection orderby)
        {
            OEStudentExamDDA da = new OEStudentExamDDA();
            return da.Select(where, orderby).DataTableToList<OEStudentExamD>();
        }

        public List<OEStudentExamD> Select(NameValueCollection where, NameValueCollection orderby, int pageIndex, int pageSize, out int totalCount)
        {
            OEStudentExamDDA da = new OEStudentExamDDA();
            return da.Select(where, orderby, pageIndex, pageSize, out totalCount).DataTableToList<OEStudentExamD>();
        }

        public Int32 Insert(NameValueCollection parameters, out ErrorEntity ErrInfo)
        {
            OEStudentExamDDA da = new OEStudentExamDDA();
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

        public Int32 Insert(OEStudentExamD item, out ErrorEntity ErrInfo)
        {
            //Error Judge Define

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FExamId", item.FExamId.ToString());
            parameters.Add("FExamDId", item.FExamDId.ToString());
            parameters.Add("FQuestionId", item.FQuestionId.ToString());
            parameters.Add("FAnswerContent", item.FAnswerContent);
            parameters.Add("FStdPoints", item.FStdPoints.ToString());
            parameters.Add("FPoints", item.FPoints.ToString());
            parameters.Add("FResult", item.FResult);
            parameters.Add("FAUserId", item.FAUserId.ToString());
            parameters.Add("FAUserName", item.FAUserName);
            parameters.Add("FResultTime", item.FResultTime.ToString());
            return Insert(parameters, out ErrInfo);
        }

        public int Update(NameValueCollection parameters, NameValueCollection where, out ErrorEntity ErrInfo)
        {
            OEStudentExamDDA da = new OEStudentExamDDA();
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

        public Int32 Update(OEStudentExamD item, out ErrorEntity ErrInfo)
        {
            //Error Judge Define

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FExamId", item.FExamId.ToString());
            parameters.Add("FExamDId", item.FExamDId.ToString());
            parameters.Add("FQuestionId", item.FQuestionId.ToString());
            parameters.Add("FAnswerContent", item.FAnswerContent);
            parameters.Add("FStdPoints", item.FStdPoints.ToString());
            parameters.Add("FPoints", item.FPoints.ToString());
            parameters.Add("FResult", item.FResult);
            parameters.Add("FAUserId", item.FAUserId.ToString());
            parameters.Add("FAUserName", item.FAUserName);
            parameters.Add("FResultTime", item.FResultTime.ToString());
            NameValueCollection where = new NameValueCollection();
            where.Add("FExamId", item.FExamId.ToString());
            where.Add("FExamDId", item.FExamDId.ToString());
            return Update(parameters, where, out ErrInfo);
        }


        public int Delete(NameValueCollection where, out ErrorEntity ErrInfo)
        {
            OEStudentExamDDA da = new OEStudentExamDDA();
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