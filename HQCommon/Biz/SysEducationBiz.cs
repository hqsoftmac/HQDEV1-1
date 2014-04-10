using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQCommon.ML;
using System.Collections.Specialized;
using HQCommon.DA;
using HQLib.Common;
using HQLib;
using HQConst.Const;

namespace HQCommon.Biz
{
    public class SysEducationBiz
    {
        public List<SysEducation> Select()
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("condition", "1=1");
            NameValueCollection orderby = new NameValueCollection();
            orderby.Add("FEducationOrder", "asc");
            return Select(where, orderby);
        }

        public SysEducation Select(string _id)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("FEducationId", _id);
            List<SysEducation> list = new List<SysEducation>();
            list = Select(where);
            if (list.Count > 0)
            {
                return list[0];
            }
            else
            {
                return null;
            }
        }
        
        public List<SysEducation> Select(NameValueCollection where)
        {
            SysEducationDA da = new SysEducationDA();
            return da.Select(where).DataTableToList<SysEducation>();
        }

        public List<SysEducation> Select(NameValueCollection where, NameValueCollection orderby)
        {
            SysEducationDA da = new SysEducationDA();
            return da.Select(where, orderby).DataTableToList<SysEducation>();
        }

        public List<SysEducation> Select(NameValueCollection where, NameValueCollection orderby, int pageIndex, int pageSize, out int totalCount)
        {
            SysEducationDA da = new SysEducationDA();
            return da.Select(where, orderby, pageIndex, pageSize, out totalCount).DataTableToList<SysEducation>();
        }

        public Int64 Insert(NameValueCollection parameters, out ErrorEntity ErrInfo)
        {
            SysEducationDA da = new SysEducationDA();
            Int64 result = da.Insert(parameters);
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

        private Boolean ChkEducationName(Int64 _id, string _name)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("FEducationID <>", _id.ToString());
            where.Add("FEducationName", _name);
            if (Select(where).Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Int64 Insert(SysEducation item, out ErrorEntity ErrInfo)
        {
            if (string.IsNullOrEmpty(item.FEducationName))
            {
                ErrInfo = new ErrorEntity("NT010001", "学历名称不能为空!");
                return -1;
            }

            if (item.FEducationOrder == 0)
            {
                ErrInfo = new ErrorEntity("NT010002", "学历显示排序不能为空!");
                return -1;
            }
            if (!ChkEducationName(item.FEducationID, item.FEducationName))
            {
                ErrInfo = new ErrorEntity("NT010003", "学历名称已经存在,不能重复!");
                return -1;
            }
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FEducationName", item.FEducationName);
            parameters.Add("FEducationOrder", item.FEducationOrder.ToString());
            return Insert(parameters, out ErrInfo);
        }

        public Int32 Update(SysEducation item, out ErrorEntity ErrInfo)
        {
            if (string.IsNullOrEmpty(item.FEducationName))
            {
                ErrInfo = new ErrorEntity("NT010001", "学历名称不能为空!");
                return -1;
            }

            if (item.FEducationOrder == 0)
            {
                ErrInfo = new ErrorEntity("NT010002", "学历显示排序不能为空!");
                return -1;
            }
            if (!ChkEducationName(item.FEducationID, item.FEducationName))
            {
                ErrInfo = new ErrorEntity("NT010003", "学历名称已经存在,不能重复!");
                return -1;
            }
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FEducationName", item.FEducationName);
            parameters.Add("FEducationOrder", item.FEducationOrder.ToString());
            NameValueCollection where = new NameValueCollection();
            where.Add("FEducationId", item.FEducationID.ToString());
            return Update(parameters, where, out ErrInfo);

        }

        public Int32 Update(NameValueCollection parameters, NameValueCollection where, out ErrorEntity ErrInfo)
        {
            SysEducationDA da = new SysEducationDA();
            Int32 result = da.Update(parameters, where);
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

        public Int32 Delete(string _idlist, out ErrorEntity ErrInfo)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("condition", "FEducationId in (" + _idlist + ")");
            return Delete(where, out ErrInfo);
        }

        public Int32 Delete(NameValueCollection where, out ErrorEntity ErrInfo)
        {
            SysEducationDA da = new SysEducationDA();
            Int32 result = da.Delete(where);
            if (result >= 0)
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
