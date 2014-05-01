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
    public partial class OEPaperDetailSetBiz
    {

        public List<OEPaperDetailSet> Select(string _paperid)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("FPaperId", _paperid);
            NameValueCollection orderby = new NameValueCollection();
            orderby.Add("FDetailSetId", "asc");
            return Select(where, orderby);
        }

        public List<OEPaperDetailSet> Select(NameValueCollection where)
        {
            OEPaperDetailSetDA da = new OEPaperDetailSetDA();
            return da.Select(where).DataTableToList<OEPaperDetailSet>();
        }

        public List<OEPaperDetailSet> Select(NameValueCollection where, NameValueCollection orderby)
        {
            OEPaperDetailSetDA da = new OEPaperDetailSetDA();
            return da.Select(where, orderby).DataTableToList<OEPaperDetailSet>();
        }

        public List<OEPaperDetailSet> Select(NameValueCollection where, NameValueCollection orderby, int pageIndex, int pageSize, out int totalCount)
        {
            OEPaperDetailSetDA da = new OEPaperDetailSetDA();
            return da.Select(where, orderby, pageIndex, pageSize, out totalCount).DataTableToList<OEPaperDetailSet>();
        }

        public Int32 Insert(NameValueCollection parameters, out ErrorEntity ErrInfo)
        {
            try
            {
                OEPaperDetailSetDA da = new OEPaperDetailSetDA();
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

        public Int32 Insert(OEPaperDetailSet item, out ErrorEntity ErrInfo)
        {
            //Error Judge Define
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FPaperId", item.FPaperId.ToString());
            parameters.Add("FDetailSetId", item.FDetailSetId.ToString());
            parameters.Add("FQuestionType", item.FQuestionType);
            parameters.Add("FDifficulty", item.FDifficulty);
            parameters.Add("FScore", item.FScore.ToString());
            return Insert(parameters, out ErrInfo);
        }

        public int Update(NameValueCollection parameters, NameValueCollection where, out ErrorEntity ErrInfo)
        {
            try
            {
                OEPaperDetailSetDA da = new OEPaperDetailSetDA();
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
            catch (Exception ex)
            {
                ErrInfo = new ErrorEntity("999999", ex.Message);
                return -1;
            }

        }

        public Int32 Update(OEPaperDetailSet item, out ErrorEntity ErrInfo)
        {
            //Error Judge Define

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FPaperId", item.FPaperId.ToString());
            parameters.Add("FDetailSetId", item.FDetailSetId.ToString());
            parameters.Add("FQuestionType", item.FQuestionType);
            parameters.Add("FDifficulty", item.FDifficulty);
            NameValueCollection where = new NameValueCollection();
            where.Add("FPaperId", item.FPaperId.ToString());
            where.Add("FDetailSetId", item.FDetailSetId.ToString());
            return Update(parameters, where, out ErrInfo);
        }

        public int Delete(string paperid, out ErrorEntity ErrInfo)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("FPaperId", paperid);
            return Delete(where, out ErrInfo);
        }

        public int Delete(NameValueCollection where, out ErrorEntity ErrInfo)
        {
            OEPaperDetailSetDA da = new OEPaperDetailSetDA();
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
