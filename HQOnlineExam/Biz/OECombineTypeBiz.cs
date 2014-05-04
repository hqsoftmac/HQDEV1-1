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
    //OECombineType
    public partial class OECombineTypeBiz
    {

        public List<OECombineType> Select(string _paperid)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("FPaperId", _paperid);
            return Select(where);
        }
        
        public List<OECombineType> Select(NameValueCollection where)
        {
            OECombineTypeDA da = new OECombineTypeDA();
            return da.Select(where).DataTableToList<OECombineType>();
        }

        public List<OECombineType> Select(NameValueCollection where, NameValueCollection orderby)
        {
            OECombineTypeDA da = new OECombineTypeDA();
            return da.Select(where, orderby).DataTableToList<OECombineType>();
        }

        public List<OECombineType> Select(NameValueCollection where, NameValueCollection orderby, int pageIndex, int pageSize, out int totalCount)
        {
            OECombineTypeDA da = new OECombineTypeDA();
            return da.Select(where, orderby, pageIndex, pageSize, out totalCount).DataTableToList<OECombineType>();
        }

        public Int32 Insert(NameValueCollection parameters, out ErrorEntity ErrInfo)
        {
            OECombineTypeDA da = new OECombineTypeDA();
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

        public Int32 Insert(OECombineType item, out ErrorEntity ErrInfo)
        {
            //Error Judge Define

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FPaperId", item.FPaperId.ToString());
            parameters.Add("FQuestionType", item.FQuestionType);
            parameters.Add("FQuestionNum", item.FQuestionNum.ToString());
            parameters.Add("FQuestionScore", item.FQuestionScore.ToString());
            return Insert(parameters, out ErrInfo);
        }

        public int Update(NameValueCollection parameters, NameValueCollection where, out ErrorEntity ErrInfo)
        {
            OECombineTypeDA da = new OECombineTypeDA();
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

        public Int32 Update(OECombineType item, out ErrorEntity ErrInfo)
        {
            //Error Judge Define

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FPaperId", item.FPaperId.ToString());
            parameters.Add("FQuestionType", item.FQuestionType);
            parameters.Add("FQuestionNum", item.FQuestionNum.ToString());
            parameters.Add("FQuestionScore", item.FQuestionScore.ToString());
            NameValueCollection where = new NameValueCollection();
            where.Add("FPaperId", item.FPaperId.ToString());
            return Update(parameters, where, out ErrInfo);
        }


        public int Delete(NameValueCollection where, out ErrorEntity ErrInfo)
        {
            OECombineTypeDA da = new OECombineTypeDA();
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