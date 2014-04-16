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
    //OEExamItem
    public partial class OEExamItemBiz
    {

        public List<OEExamItem> Select(NameValueCollection where)
        {
            OEExamItemDA da = new OEExamItemDA();
            return da.Select(where).DataTableToList<OEExamItem>();
        }

        public List<OEExamItem> Select(NameValueCollection where, NameValueCollection orderby)
        {
            OEExamItemDA da = new OEExamItemDA();
            return da.Select(where, orderby).DataTableToList<OEExamItem>();
        }

        public List<OEExamItem> Select(NameValueCollection where, NameValueCollection orderby, int pageIndex, int pageSize, out int totalCount)
        {
            OEExamItemDA da = new OEExamItemDA();
            return da.Select(where, orderby, pageIndex, pageSize, out totalCount).DataTableToList<OEExamItem>();
        }

        public Int32 Insert(NameValueCollection parameters, out ErrorEntity ErrInfo)
        {
            OEExamItemDA da = new OEExamItemDA();
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

        public Int32 Insert(OEExamItem item, out ErrorEntity ErrInfo)
        {
            //Error Judge Define

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FPaperId", item.FPaperId.ToString());
            parameters.Add("FItemId", item.FItemId.ToString());
            parameters.Add("FItemContent", item.FItemContent);
            parameters.Add("FItemFlag", item.FItemFlag);
            return Insert(parameters, out ErrInfo);
        }

        public int Update(NameValueCollection parameters, NameValueCollection where, out ErrorEntity ErrInfo)
        {
            OEExamItemDA da = new OEExamItemDA();
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

        public Int32 Update(OEExamItem item, out ErrorEntity ErrInfo)
        {
            //Error Judge Define

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FPaperId", item.FPaperId.ToString());
            parameters.Add("FItemId", item.FItemId.ToString());
            parameters.Add("FItemContent", item.FItemContent);
            parameters.Add("FItemFlag", item.FItemFlag);
            NameValueCollection where = new NameValueCollection();
            where.Add("FPaperId", item.FPaperId.ToString());
            where.Add("FItemId", item.FItemId.ToString());
            return Update(parameters, where, out ErrInfo);
        }


        public int Delete(NameValueCollection where, out ErrorEntity ErrInfo)
        {
            OEExamItemDA da = new OEExamItemDA();
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