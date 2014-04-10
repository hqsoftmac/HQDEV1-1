using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQPortal.ML;
using System.Collections.Specialized;
using HQPortal.DA;
using HQLib.Common;
using HQLib;
using HQConst.Const;

namespace HQPortal.Biz
{
    public class PortalColumnNavBiz
    {
        public List<PortalColumnNav> Select(NameValueCollection where)
        {
            PortalColumnNavDA da = new PortalColumnNavDA();
            return da.Select(where).DataTableToList<PortalColumnNav>();
        }

        public List<PortalColumnNav> Select(NameValueCollection where, NameValueCollection orderby)
        {
            PortalColumnNavDA da = new PortalColumnNavDA();
            return da.Select(where, orderby).DataTableToList<PortalColumnNav>();
        }

        public List<PortalColumnNav> Select(NameValueCollection where, NameValueCollection orderby, int pageIndex, int pageSize, out int totalCount)
        {
            PortalColumnNavDA da = new PortalColumnNavDA();
            return da.Select(where, orderby, pageIndex, pageSize, out totalCount).DataTableToList<PortalColumnNav>();
        }

        public List<PortalColumnNav> SelectByColId(Int64 _columnid)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("FColumnId", _columnid.ToString());
            NameValueCollection orderby = new NameValueCollection();
            orderby.Add("FNavOrder", "asc");
            return Select(where, orderby);
        }

        public PortalColumnNav Select(Int64 _navid)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("FNavId", _navid.ToString());
            List<PortalColumnNav> lists = new List<PortalColumnNav>();
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

        public Boolean chkNameExist(Int64 _navid, Int64 _colid, string _name)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("FNavId <>", _navid.ToString());
            where.Add("FColumnId", _colid.ToString());
            where.Add("FNavName", _name);
            if (Select(where).Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Int64 Insert(NameValueCollection parameters, out ErrorEntity ErrInfo)
        {
            PortalColumnNavDA da = new PortalColumnNavDA();
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

        public Int64 Insert(PortalColumnNav item, out ErrorEntity ErrInfo)
        {
            if (item.FColumnId == 0)
            {
                ErrInfo = new ErrorEntity(RespCode.Nv010003);
                return -1;
            }
            if (string.IsNullOrEmpty(item.FNavName))
            {
                ErrInfo = new ErrorEntity(RespCode.Nv010001);
                return -1;
            }
            if (!chkNameExist(item.FNavId, item.FColumnId, item.FNavName))
            {
                ErrInfo = new ErrorEntity(RespCode.Nv010002);
                return -1;
            }
            if (string.IsNullOrEmpty(item.FNavType))
            {
                ErrInfo = new ErrorEntity(RespCode.Nv010004);
                return -1;
            }
            if (string.IsNullOrEmpty(item.FNavPosition))
            {
                ErrInfo = new ErrorEntity(RespCode.Nv010005);
                return -1;
            }
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FColumnId", item.FColumnId.ToString());
            parameters.Add("FNavName", item.FNavName);
            parameters.Add("FNavType", item.FNavType);
            parameters.Add("FNavPosition", item.FNavPosition);
            parameters.Add("FNavOrder", item.FNavOrder.ToString());
            parameters.Add("FNavVisible", item.FNavVisible);
            return Insert(parameters, out ErrInfo);
        }

        public Int32 UpdateStyle(string _navid, string _visible, string _style, string _url, out ErrorEntity ErrInfo)
        {
            if (string.IsNullOrEmpty(_navid))
            {
                ErrInfo = new ErrorEntity("999999", "导航参数错误,无法保存!");
                return -1;
            }
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FNavTitleVisible", _visible);
            parameters.Add("FNavStyle", _style);
            parameters.Add("FNavUrl", _url);
            NameValueCollection where = new NameValueCollection();
            where.Add("FNavId", _navid);
            return Update(parameters, where, out ErrInfo);
        }

        public Int32 Update(NameValueCollection parameters, NameValueCollection where, out ErrorEntity ErrInfo)
        {
            PortalColumnNavDA da = new PortalColumnNavDA();
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

        public Int32 Update(PortalColumnNav item, out ErrorEntity ErrInfo)
        {
            if (item.FColumnId == 0)
            {
                ErrInfo = new ErrorEntity(RespCode.Nv010003);
                return -1;
            }
            if (string.IsNullOrEmpty(item.FNavName))
            {
                ErrInfo = new ErrorEntity(RespCode.Nv010001);
                return -1;
            }
            if (!chkNameExist(item.FNavId, item.FColumnId, item.FNavName))
            {
                ErrInfo = new ErrorEntity(RespCode.Nv010002);
                return -1;
            }
            if (string.IsNullOrEmpty(item.FNavType))
            {
                ErrInfo = new ErrorEntity(RespCode.Nv010004);
                return -1;
            }
            if (string.IsNullOrEmpty(item.FNavPosition))
            {
                ErrInfo = new ErrorEntity(RespCode.Nv010005);
                return -1;
            }
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FColumnId", item.FColumnId.ToString());
            parameters.Add("FNavName", item.FNavName);
            parameters.Add("FNavType", item.FNavType);
            parameters.Add("FNavPosition", item.FNavPosition);
            parameters.Add("FNavOrder", item.FNavOrder.ToString());
            parameters.Add("FNavVisible", item.FNavVisible);
            NameValueCollection where = new NameValueCollection();
            where.Add("FNavId", item.FNavId.ToString());
            return Update(parameters, where, out ErrInfo);
        }


        public Int32 Delete(NameValueCollection where, out ErrorEntity ErrInfo)
        {
            PortalColumnNavDA da = new PortalColumnNavDA();
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

        public Int32 Delete(string idlist, out ErrorEntity ErrInfo)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("condition", "FNavId in (" + idlist + ")");
            return Delete(where, out ErrInfo);
        }
    }
}
