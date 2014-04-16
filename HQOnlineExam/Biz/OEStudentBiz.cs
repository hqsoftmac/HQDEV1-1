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
    //OEStudent
    public partial class OEStudentBiz
    {

        public List<OEStudent> Select(NameValueCollection where)
        {
            OEStudentDA da = new OEStudentDA();
            return da.Select(where).DataTableToList<OEStudent>();
        }

        public List<OEStudent> Select(NameValueCollection where, NameValueCollection orderby)
        {
            OEStudentDA da = new OEStudentDA();
            return da.Select(where, orderby).DataTableToList<OEStudent>();
        }

        public List<OEStudent> Select(NameValueCollection where, NameValueCollection orderby, int pageIndex, int pageSize, out int totalCount)
        {
            OEStudentDA da = new OEStudentDA();
            return da.Select(where, orderby, pageIndex, pageSize, out totalCount).DataTableToList<OEStudent>();
        }

        public Int32 Insert(NameValueCollection parameters, out ErrorEntity ErrInfo)
        {
            OEStudentDA da = new OEStudentDA();
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

        public Int32 Insert(OEStudent item, out ErrorEntity ErrInfo)
        {
            //Error Judge Define

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FStudentId", item.FStudentId.ToString());
            parameters.Add("FStudentName", item.FStudentName);
            parameters.Add("FStudentIDNumber", item.FStudentIDNumber);
            parameters.Add("FEmail", item.FEmail);
            parameters.Add("FMobile", item.FMobile);
            parameters.Add("FRegTime", item.FRegTime.ToString());
            parameters.Add("FStudentPSW", item.FStudentPSW);
            parameters.Add("FStatus", item.FStatus);
            return Insert(parameters, out ErrInfo);
        }

        public int Update(NameValueCollection parameters, NameValueCollection where, out ErrorEntity ErrInfo)
        {
            OEStudentDA da = new OEStudentDA();
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

        public Int32 Update(OEStudent item, out ErrorEntity ErrInfo)
        {
            //Error Judge Define

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FStudentId", item.FStudentId.ToString());
            parameters.Add("FStudentName", item.FStudentName);
            parameters.Add("FStudentIDNumber", item.FStudentIDNumber);
            parameters.Add("FEmail", item.FEmail);
            parameters.Add("FMobile", item.FMobile);
            parameters.Add("FRegTime", item.FRegTime.ToString());
            parameters.Add("FStudentPSW", item.FStudentPSW);
            parameters.Add("FStatus", item.FStatus);
            NameValueCollection where = new NameValueCollection();
            where.Add("FStudentId", item.FStudentId.ToString());
            return Update(parameters, where, out ErrInfo);
        }


        public int Delete(NameValueCollection where, out ErrorEntity ErrInfo)
        {
            OEStudentDA da = new OEStudentDA();
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