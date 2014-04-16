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
    //学员在线状态
    public partial class 学员在线状态Biz
    {

        public List<学员在线状态> Select(NameValueCollection where)
        {
            学员在线状态DA da = new 学员在线状态DA();
            return da.Select(where).DataTableToList<学员在线状态>();
        }

        public List<学员在线状态> Select(NameValueCollection where, NameValueCollection orderby)
        {
            学员在线状态DA da = new 学员在线状态DA();
            return da.Select(where, orderby).DataTableToList<学员在线状态>();
        }

        public List<学员在线状态> Select(NameValueCollection where, NameValueCollection orderby, int pageIndex, int pageSize, out int totalCount)
        {
            学员在线状态DA da = new 学员在线状态DA();
            return da.Select(where, orderby, pageIndex, pageSize, out totalCount).DataTableToList<学员在线状态>();
        }

        public Int32 Insert(NameValueCollection parameters, out ErrorEntity ErrInfo)
        {
            学员在线状态DA da = new 学员在线状态DA();
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

        public Int32 Insert(学员在线状态 item, out ErrorEntity ErrInfo)
        {
            //Error Judge Define

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FStudentId", item.FStudentId.ToString());
            parameters.Add("FOnlineTime", item.FOnlineTime.ToString());
            return Insert(parameters, out ErrInfo);
        }

        public int Update(NameValueCollection parameters, NameValueCollection where, out ErrorEntity ErrInfo)
        {
            学员在线状态DA da = new 学员在线状态DA();
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

        public Int32 Update(学员在线状态 item, out ErrorEntity ErrInfo)
        {
            //Error Judge Define

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FStudentId", item.FStudentId.ToString());
            parameters.Add("FOnlineTime", item.FOnlineTime.ToString());
            NameValueCollection where = new NameValueCollection();
            where.Add("FStudentId", item.FStudentId.ToString());
            return Update(parameters, where, out ErrInfo);
        }


        public int Delete(NameValueCollection where, out ErrorEntity ErrInfo)
        {
            学员在线状态DA da = new 学员在线状态DA();
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