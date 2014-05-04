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
    //OEChooseQuestion
    public partial class OEChooseQuestionBiz
    {

        public List<OEChooseQuestion> Select(NameValueCollection where)
        {
            OEChooseQuestionDA da = new OEChooseQuestionDA();
            return da.Select(where).DataTableToList<OEChooseQuestion>();
        }

        public List<OEChooseQuestion> Select(NameValueCollection where, NameValueCollection orderby)
        {
            OEChooseQuestionDA da = new OEChooseQuestionDA();
            return da.Select(where, orderby).DataTableToList<OEChooseQuestion>();
        }

        public List<OEChooseQuestion> Select(NameValueCollection where, NameValueCollection orderby, int pageIndex, int pageSize, out int totalCount)
        {
            OEChooseQuestionDA da = new OEChooseQuestionDA();
            return da.Select(where, orderby, pageIndex, pageSize, out totalCount).DataTableToList<OEChooseQuestion>();
        }

        public Int32 Insert(NameValueCollection parameters, out ErrorEntity ErrInfo)
        {
            OEChooseQuestionDA da = new OEChooseQuestionDA();
            try
            {
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
            catch (Exception ex)
            {
                ErrInfo = new ErrorEntity("999999", ex.Message);
                return -1;
            }
            
        }

        public Int32 Insert(OEChooseQuestion item, out ErrorEntity ErrInfo)
        {
            //Error Judge Define

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FPaperId", item.FPaperId.ToString());
            parameters.Add("FDetailId", item.FDetailId.ToString());
            parameters.Add("FQuestionId", item.FQuestionId.ToString());
            return Insert(parameters, out ErrInfo);
        }

        public int Update(NameValueCollection parameters, NameValueCollection where, out ErrorEntity ErrInfo)
        {
            OEChooseQuestionDA da = new OEChooseQuestionDA();
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

        public int Delete(NameValueCollection where, out ErrorEntity ErrInfo)
        {
            OEChooseQuestionDA da = new OEChooseQuestionDA();
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