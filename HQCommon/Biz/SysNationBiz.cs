using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib.Common;
using System.Collections.Specialized;
using HQCommon.ML;
using HQCommon.DA;
using HQLib;
using HQConst.Const;

namespace HQCommon.Biz
{
    public class SysNationBiz
    {
        public List<SysNation> Select()
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("condition", "1=1");
            NameValueCollection orderby = new NameValueCollection();
            orderby.Add("FNationOrder", "asc");
            return Select(where, orderby);
        }

        public SysNation Select(string _id)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("FNationId", _id);
            List<SysNation> list = new List<SysNation>();
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
        
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public List<SysNation> Select(NameValueCollection where)
        {
            SysNationDA da = new SysNationDA();
            return da.Select(where).DataTableToList<SysNation>();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="orderby">排序条件</param>
        /// <returns></returns>
        public List<SysNation> Select(NameValueCollection where, NameValueCollection orderby)
        {
            SysNationDA da = new SysNationDA();
            return da.Select(where, orderby).DataTableToList<SysNation>();
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="orderby">排序条件</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="totalCount">记录总行数</param>
        /// <returns></returns>
        public List<SysNation> Select(NameValueCollection where, NameValueCollection orderby, int pageIndex, int pageSize, out int totalCount)
        {
            SysNationDA da = new SysNationDA();
            return da.Select(where, orderby, pageIndex, pageSize, out totalCount).DataTableToList<SysNation>();
        }

        private Boolean ChkNationName(Int64 _id, string _name)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("FNationId <>", _id.ToString());
            where.Add("FNationName", _name);
            if (Select(where).Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Int64 Insert(SysNation item, out ErrorEntity ErrInfo)
        {
            if (string.IsNullOrEmpty(item.FNationName))
            {
                ErrInfo = new ErrorEntity("NT010001", "民族名称不能为空!");
                return -1;
            }

            if (item.FNationOrder == 0)
            {
                ErrInfo = new ErrorEntity("NT010002", "民族显示排序不能为空!");
                return -1;
            }
            if (!ChkNationName(item.FNationID, item.FNationName))
            {
                ErrInfo = new ErrorEntity("NT010003", "民族名称已经存在,不能重复!");
                return -1;
            }
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FNationName", item.FNationName);
            parameters.Add("FNationOrder", item.FNationOrder.ToString());
            return Insert(parameters, out ErrInfo);
        }

        public Int64 Insert(NameValueCollection parameters,out ErrorEntity ErrInfo)
        {
            SysNationDA da = new SysNationDA();
            Int64 result = da.InsertAndReturnId64(parameters);
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

        public Int32 Update(SysNation item, out ErrorEntity ErrInfo)
        {
            if (string.IsNullOrEmpty(item.FNationName))
            {
                ErrInfo = new ErrorEntity("NT010001", "民族名称不能为空!");
                return -1;
            }

            if (item.FNationOrder == 0)
            {
                ErrInfo = new ErrorEntity("NT010002", "民族显示排序不能为空!");
                return -1;
            }
            if (!ChkNationName(item.FNationID, item.FNationName))
            {
                ErrInfo = new ErrorEntity("NT010003", "民族名称已经存在,不能重复!");
                return -1;
            }
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FNationName", item.FNationName);
            parameters.Add("FNationOrder", item.FNationOrder.ToString());
            NameValueCollection where = new NameValueCollection();
            where.Add("FNationId", item.FNationID.ToString());
            return Update(parameters, where, out ErrInfo);

        }

        public Int32 Update(NameValueCollection parameters, NameValueCollection where, out ErrorEntity ErrInfo)
        {
            SysNationDA da = new SysNationDA();
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
            where.Add("condition", "FNationId in (" + _idlist + ")");
            return Delete(where, out ErrInfo);
        }

        public Int32 Delete(NameValueCollection where, out ErrorEntity ErrInfo)
        {
            SysNationDA da = new SysNationDA();
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
