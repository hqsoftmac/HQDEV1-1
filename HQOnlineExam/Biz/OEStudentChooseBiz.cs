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
    //OEStudentChoose
    public partial class OEStudentChooseBiz
    {

        public List<OEStudentChoose> Select(NameValueCollection where)
        {
            OEStudentChooseDA da = new OEStudentChooseDA();
            return da.Select(where).DataTableToList<OEStudentChoose>();
        }

        public List<OEStudentChoose> Select(NameValueCollection where, NameValueCollection orderby)
        {
            OEStudentChooseDA da = new OEStudentChooseDA();
            return da.Select(where, orderby).DataTableToList<OEStudentChoose>();
        }

        public List<OEStudentChoose> Select(NameValueCollection where, NameValueCollection orderby, int pageIndex, int pageSize, out int totalCount)
        {
            OEStudentChooseDA da = new OEStudentChooseDA();
            return da.Select(where, orderby, pageIndex, pageSize, out totalCount).DataTableToList<OEStudentChoose>();
        }

        public Int32 Insert(NameValueCollection parameters, out ErrorEntity ErrInfo)
        {
            OEStudentChooseDA da = new OEStudentChooseDA();
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

        public Int32 Insert(OEStudentChoose item, out ErrorEntity ErrInfo)
        {
            //Error Judge Define

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FStudentId", item.FStudentId.ToString());
            parameters.Add("FContentClassId", item.FContentClassId.ToString());
            return Insert(parameters, out ErrInfo);
        }

        public int Update(NameValueCollection parameters, NameValueCollection where, out ErrorEntity ErrInfo)
        {
            OEStudentChooseDA da = new OEStudentChooseDA();
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

        public Int32 Update(OEStudentChoose item, out ErrorEntity ErrInfo)
        {
            //Error Judge Define

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FStudentId", item.FStudentId.ToString());
            parameters.Add("FContentClassId", item.FContentClassId.ToString());
            NameValueCollection where = new NameValueCollection();
            where.Add("FStudentId", item.FStudentId.ToString());
            where.Add("FContentClassId", item.FContentClassId.ToString());
            return Update(parameters, where, out ErrInfo);
        }


        public int Delete(NameValueCollection where, out ErrorEntity ErrInfo)
        {
            OEStudentChooseDA da = new OEStudentChooseDA();
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
