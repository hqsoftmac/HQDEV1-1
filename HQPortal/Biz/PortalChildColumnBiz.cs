using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib.Common;
using System.Collections.Specialized;
using HQPortal.ML;
using HQPortal.DA;
using HQLib;
using HQConst.Const;

namespace HQPortal.Biz
{
    public class PortalChildColumnBiz
    {
        public List<PortalChildColumn> Select(NameValueCollection where)
        {
            PortalChildColumnDA da = new PortalChildColumnDA();
            return da.Select(where).DataTableToList<PortalChildColumn>();
        }

        public List<PortalChildColumn> Select(NameValueCollection where, NameValueCollection orderby)
        {
            PortalChildColumnDA da = new PortalChildColumnDA();
            return da.Select(where, orderby).DataTableToList<PortalChildColumn>();
        }

        public List<PortalChildColumn> Select(NameValueCollection where, NameValueCollection orderby, int pageIndex, int pageSize, out int totalCount)
        {
            PortalChildColumnDA da = new PortalChildColumnDA();
            return da.Select(where, orderby, pageIndex, pageSize, out totalCount).DataTableToList<PortalChildColumn>();
        }

        public PortalChildColumn Select(Int64 _childcolumnid)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("FChildColumnId", _childcolumnid.ToString());
            List<PortalChildColumn> lists = new List<PortalChildColumn>();
            lists = Select(where);
            if (lists.Count > 0)
            {
                return lists[0];
            }
            else
            {
                return null;
            }
        }

        public List<PortalChildColumn> SelectByNavId(Int64 _navid)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("FNavId", _navid.ToString());
            NameValueCollection orderby = new NameValueCollection();
            orderby.Add("FChildColumnOrder", "asc");
            return Select(where, orderby);
        }

        public Int64 Insert(NameValueCollection parameters, out ErrorEntity ErrInfo)
        {
            PortalChildColumnDA da = new PortalChildColumnDA();
            Int64 result = 0;
            result = da.InsertAndReturnId64(parameters);
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

        public Int64 Insert(PortalChildColumn item, out ErrorEntity ErrInfo)
        {
            if (item.FNavId == 0)
            {
                ErrInfo = new ErrorEntity(RespCode.Cc010006);
                return -1;
            }
            if (string.IsNullOrEmpty(item.FChildColumnName))
            {
                ErrInfo = new ErrorEntity(RespCode.Cc010001);
                return -1;
            }
            if (string.IsNullOrEmpty(item.FChildColumnTarget))
            {
                ErrInfo = new ErrorEntity(RespCode.Cc010003);
                return -1;
            }
            if (string.IsNullOrEmpty(item.FChildColumnType))
            {
                ErrInfo = new ErrorEntity(RespCode.Cc010002);
                return -1;
            }
            if (item.FChildColumnOrder == 0)
            {
                ErrInfo = new ErrorEntity(RespCode.Cc010005);
                return -1;
            }
            if (!ChkNameRepeation(item.FChildColumnId, item.FNavId, item.FChildColumnName))
            {
                ErrInfo = new ErrorEntity(RespCode.Cc010004);
                return -1;
            }
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FNavId", item.FNavId.ToString());
            parameters.Add("FChildColumnName", item.FChildColumnName);
            parameters.Add("FChildColumnType", item.FChildColumnType);
            parameters.Add("FChildColumnUrl", item.FChildColumnUrl);
            parameters.Add("FChildColumnTarget", item.FChildColumnTarget);
            parameters.Add("FChildColumnVisible", item.FChildColumnVisible);
            parameters.Add("FChildColumnOrder", item.FChildColumnOrder.ToString());
            return Insert(parameters, out ErrInfo);
        }

        public Int32 Update(NameValueCollection parameters, NameValueCollection where, out ErrorEntity ErrInfo)
        {
            PortalChildColumnDA da = new PortalChildColumnDA();
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

        public Int32 Update(PortalChildColumn item, out ErrorEntity ErrInfo)
        {
            if (item.FNavId == 0)
            {
                ErrInfo = new ErrorEntity(RespCode.Cc010006);
                return -1;
            }
            if (string.IsNullOrEmpty(item.FChildColumnName))
            {
                ErrInfo = new ErrorEntity(RespCode.Cc010001);
                return -1;
            }
            if (string.IsNullOrEmpty(item.FChildColumnTarget))
            {
                ErrInfo = new ErrorEntity(RespCode.Cc010003);
                return -1;
            }
            if (string.IsNullOrEmpty(item.FChildColumnType))
            {
                ErrInfo = new ErrorEntity(RespCode.Cc010002);
                return -1;
            }
            if (item.FChildColumnOrder == 0)
            {
                ErrInfo = new ErrorEntity(RespCode.Cc010005);
                return -1;
            }
            if (!ChkNameRepeation(item.FChildColumnId, item.FNavId, item.FChildColumnName))
            {
                ErrInfo = new ErrorEntity(RespCode.Cc010004);
                return -1;
            }
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FNavId", item.FNavId.ToString());
            parameters.Add("FChildColumnName", item.FChildColumnName);
            parameters.Add("FChildColumnType", item.FChildColumnType);
            parameters.Add("FChildColumnUrl", item.FChildColumnUrl);
            parameters.Add("FChildColumnTarget", item.FChildColumnTarget);
            parameters.Add("FChildColumnVisible", item.FChildColumnVisible);
            parameters.Add("FChildColumnOrder", item.FChildColumnOrder.ToString());
            NameValueCollection where = new NameValueCollection();
            where.Add("FChildColumnId", item.FChildColumnId.ToString());
            return Update(parameters, where, out ErrInfo);
        }

        public int Delete(NameValueCollection where, out ErrorEntity ErrInfo)
        {
            PortalChildColumnDA da = new PortalChildColumnDA();
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

        public int Delete(string idlist, out ErrorEntity ErrInfo)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("condition", "FChildColumnId in (" + idlist + ")");
            return Delete(where, out ErrInfo);
        }

        public Boolean ChkNameRepeation(Int64 _childcolid, Int64 _navid, string _childcolname)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("FChildColumnId <>", _childcolid.ToString());
            where.Add("FNavId", _navid.ToString());
            where.Add("FChildColumnName", _childcolname);
            if (Select(where).Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
