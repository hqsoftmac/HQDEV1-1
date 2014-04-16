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
    //OEPaperDifficulty
    public partial class OEPaperDifficultyBiz
    {

        public List<OEPaperDifficulty> Select(NameValueCollection where)
        {
            OEPaperDifficultyDA da = new OEPaperDifficultyDA();
            return da.Select(where).DataTableToList<OEPaperDifficulty>();
        }

        public List<OEPaperDifficulty> Select(NameValueCollection where, NameValueCollection orderby)
        {
            OEPaperDifficultyDA da = new OEPaperDifficultyDA();
            return da.Select(where, orderby).DataTableToList<OEPaperDifficulty>();
        }

        public List<OEPaperDifficulty> Select(NameValueCollection where, NameValueCollection orderby, int pageIndex, int pageSize, out int totalCount)
        {
            OEPaperDifficultyDA da = new OEPaperDifficultyDA();
            return da.Select(where, orderby, pageIndex, pageSize, out totalCount).DataTableToList<OEPaperDifficulty>();
        }

        public Int32 Insert(NameValueCollection parameters, out ErrorEntity ErrInfo)
        {
            OEPaperDifficultyDA da = new OEPaperDifficultyDA();
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

        public Int32 Insert(OEPaperDifficulty item, out ErrorEntity ErrInfo)
        {
            //Error Judge Define

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FPaperId", item.FPaperId.ToString());
            parameters.Add("FDifficulty", item.FDifficulty);
            parameters.Add("FRate", item.FRate.ToString());
            return Insert(parameters, out ErrInfo);
        }

        public int Update(NameValueCollection parameters, NameValueCollection where, out ErrorEntity ErrInfo)
        {
            OEPaperDifficultyDA da = new OEPaperDifficultyDA();
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

        public Int32 Update(OEPaperDifficulty item, out ErrorEntity ErrInfo)
        {
            //Error Judge Define

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FPaperId", item.FPaperId.ToString());
            parameters.Add("FDifficulty", item.FDifficulty);
            parameters.Add("FRate", item.FRate.ToString());
            NameValueCollection where = new NameValueCollection();
            where.Add("FPaperId", item.FPaperId.ToString());
            where.Add("FDifficulty", item.FDifficulty);
            return Update(parameters, where, out ErrInfo);
        }


        public int Delete(NameValueCollection where, out ErrorEntity ErrInfo)
        {
            OEPaperDifficultyDA da = new OEPaperDifficultyDA();
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