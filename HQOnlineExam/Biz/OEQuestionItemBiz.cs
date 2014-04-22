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
    public partial class OEQuestionItemBiz
    {

        public List<OEQuestionItem> Select(NameValueCollection where)
        {
            OEQuestionItemDA da = new OEQuestionItemDA();
            return da.Select(where).DataTableToList<OEQuestionItem>();
        }

        public List<OEQuestionItem> Select(NameValueCollection where, NameValueCollection orderby)
        {
            OEQuestionItemDA da = new OEQuestionItemDA();
            return da.Select(where, orderby).DataTableToList<OEQuestionItem>();
        }

        public List<OEQuestionItem> Select(NameValueCollection where, NameValueCollection orderby, int pageIndex, int pageSize, out int totalCount)
        {
            OEQuestionItemDA da = new OEQuestionItemDA();
            return da.Select(where, orderby, pageIndex, pageSize, out totalCount).DataTableToList<OEQuestionItem>();
        }

        public Int32 Insert(NameValueCollection parameters, out ErrorEntity ErrInfo)
        {
            OEQuestionItemDA da = new OEQuestionItemDA();
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

        public Int32 Insert(OEQuestionItem item, out ErrorEntity ErrInfo)
        {
            //Error Judge Define

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FQuestionId", item.FQuestionId.ToString());
            parameters.Add("FItemId", item.FItemId.ToString());
            parameters.Add("FItemContent", item.FItemContent);
            parameters.Add("FItemFlag", item.FItemFlag);
            return Insert(parameters, out ErrInfo);
        }

        public int Update(NameValueCollection parameters, NameValueCollection where, out ErrorEntity ErrInfo)
        {
            OEQuestionItemDA da = new OEQuestionItemDA();
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

        public Int32 Update(OEQuestionItem item, out ErrorEntity ErrInfo)
        {
            //Error Judge Define

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FQuestionId", item.FQuestionId.ToString());
            parameters.Add("FItemId", item.FItemId.ToString());
            parameters.Add("FItemContent", item.FItemContent);
            parameters.Add("FItemFlag", item.FItemFlag);
            NameValueCollection where = new NameValueCollection();
            where.Add("FQuestionId", item.FQuestionId.ToString());
            where.Add("FItemId", item.FItemId.ToString());
            return Update(parameters, where, out ErrInfo);
        }


        public int Delete(NameValueCollection where, out ErrorEntity ErrInfo)
        {
            OEQuestionItemDA da = new OEQuestionItemDA();
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