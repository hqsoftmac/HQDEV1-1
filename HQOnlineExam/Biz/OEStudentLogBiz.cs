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
    //OEStudentLog
    public partial class OEStudentLogBiz
    {

        public List<OEStudentLog> Select(NameValueCollection where)
        {
            OEStudentLogDA da = new OEStudentLogDA();
            return da.Select(where).DataTableToList<OEStudentLog>();
        }

        public List<OEStudentLog> Select(NameValueCollection where, NameValueCollection orderby)
        {
            OEStudentLogDA da = new OEStudentLogDA();
            return da.Select(where, orderby).DataTableToList<OEStudentLog>();
        }

        public List<OEStudentLog> Select(NameValueCollection where, NameValueCollection orderby, int pageIndex, int pageSize, out int totalCount)
        {
            OEStudentLogDA da = new OEStudentLogDA();
            return da.Select(where, orderby, pageIndex, pageSize, out totalCount).DataTableToList<OEStudentLog>();
        }

        public Int32 Insert(NameValueCollection parameters, out ErrorEntity ErrInfo)
        {
            OEStudentLogDA da = new OEStudentLogDA();
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

        public Int32 Insert(OEStudentLog item, out ErrorEntity ErrInfo)
        {
            //Error Judge Define

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("LogId", item.LogId.ToString());
            parameters.Add("FStudentId", item.FStudentId.ToString());
            parameters.Add("FLogType", item.FLogType);
            parameters.Add("FLogContent", item.FLogContent);
            parameters.Add("FLogIp", item.FLogIp);
            parameters.Add("LogTime", item.LogTime.ToString());
            return Insert(parameters, out ErrInfo);
        }

        public int Update(NameValueCollection parameters, NameValueCollection where, out ErrorEntity ErrInfo)
        {
            OEStudentLogDA da = new OEStudentLogDA();
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

        public Int32 Update(OEStudentLog item, out ErrorEntity ErrInfo)
        {
            //Error Judge Define

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("LogId", item.LogId.ToString());
            parameters.Add("FStudentId", item.FStudentId.ToString());
            parameters.Add("FLogType", item.FLogType);
            parameters.Add("FLogContent", item.FLogContent);
            parameters.Add("FLogIp", item.FLogIp);
            parameters.Add("LogTime", item.LogTime.ToString());
            NameValueCollection where = new NameValueCollection();
            where.Add("LogId", item.LogId.ToString());
            return Update(parameters, where, out ErrInfo);
        }


        public int Delete(NameValueCollection where, out ErrorEntity ErrInfo)
        {
            OEStudentLogDA da = new OEStudentLogDA();
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