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
    //OEStudentExamM
    public partial class OEStudentExamMBiz
    {

        public List<OEStudentExamM> Select(NameValueCollection where)
        {
            OEStudentExamMDA da = new OEStudentExamMDA();
            return da.Select(where).DataTableToList<OEStudentExamM>();
        }

        public List<OEStudentExamM> Select(NameValueCollection where, NameValueCollection orderby)
        {
            OEStudentExamMDA da = new OEStudentExamMDA();
            return da.Select(where, orderby).DataTableToList<OEStudentExamM>();
        }

        public List<OEStudentExamM> Select(NameValueCollection where, NameValueCollection orderby, int pageIndex, int pageSize, out int totalCount)
        {
            OEStudentExamMDA da = new OEStudentExamMDA();
            return da.Select(where, orderby, pageIndex, pageSize, out totalCount).DataTableToList<OEStudentExamM>();
        }

        public Int32 Insert(NameValueCollection parameters, out ErrorEntity ErrInfo)
        {
            OEStudentExamMDA da = new OEStudentExamMDA();
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

        public Int32 Insert(OEStudentExamM item, out ErrorEntity ErrInfo)
        {
            //Error Judge Define

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FExamId", item.FExamId.ToString());
            parameters.Add("FStudentId", item.FStudentId.ToString());
            parameters.Add("FPaperd", item.FPaperd.ToString());
            parameters.Add("FExamBeginTime", item.FExamBeginTime.ToString());
            parameters.Add("FExamEndTime", item.FExamEndTime.ToString());
            parameters.Add("FExamSubmitTime", item.FExamSubmitTime.ToString());
            parameters.Add("FExamSubmitFlag", item.FExamSubmitFlag);
            parameters.Add("FExamResultNum", item.FExamResultNum.ToString());
            parameters.Add("FExamPassFlag", item.FExamPassFlag);
            return Insert(parameters, out ErrInfo);
        }

        public int Update(NameValueCollection parameters, NameValueCollection where, out ErrorEntity ErrInfo)
        {
            OEStudentExamMDA da = new OEStudentExamMDA();
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

        public Int32 Update(OEStudentExamM item, out ErrorEntity ErrInfo)
        {
            //Error Judge Define

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FExamId", item.FExamId.ToString());
            parameters.Add("FStudentId", item.FStudentId.ToString());
            parameters.Add("FPaperd", item.FPaperd.ToString());
            parameters.Add("FExamBeginTime", item.FExamBeginTime.ToString());
            parameters.Add("FExamEndTime", item.FExamEndTime.ToString());
            parameters.Add("FExamSubmitTime", item.FExamSubmitTime.ToString());
            parameters.Add("FExamSubmitFlag", item.FExamSubmitFlag);
            parameters.Add("FExamResultNum", item.FExamResultNum.ToString());
            parameters.Add("FExamPassFlag", item.FExamPassFlag);
            NameValueCollection where = new NameValueCollection();
            where.Add("FExamId", item.FExamId.ToString());
            return Update(parameters, where, out ErrInfo);
        }


        public int Delete(NameValueCollection where, out ErrorEntity ErrInfo)
        {
            OEStudentExamMDA da = new OEStudentExamMDA();
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