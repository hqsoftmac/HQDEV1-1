using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQPortal.ML;
using HQPortal.DA;
using HQLib.Common;
using System.Collections.Specialized;
using HQLib;
using HQConst.Const;

namespace HQPortal.Biz
{
    public class PortalPositionBiz
    {
        public List<PortalPosition> Select(NameValueCollection where)
        {
            PortalPositionDA da = new PortalPositionDA();
            return da.Select(where).DataTableToList<PortalPosition>();
        }

        public List<PortalPosition> Select(NameValueCollection where, NameValueCollection orderby)
        {
            PortalPositionDA da = new PortalPositionDA();
            return da.Select(where, orderby).DataTableToList<PortalPosition>();
        }

        public List<PortalPosition> Select(NameValueCollection where, NameValueCollection orderby, int _pageIndex, int _pageSize, out int _totalCount)
        {
            PortalPositionDA da = new PortalPositionDA();
            return da.Select(where, orderby, _pageIndex, _pageSize, out _totalCount).DataTableToList<PortalPosition>();
        }

        public PortalPosition Select(string _id)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("FPositionId", _id);
            List<PortalPosition> lists = new List<PortalPosition>();
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

        public Int64 Insert(NameValueCollection parameters, out ErrorEntity ErrInfo)
        {
            PortalPositionDA da = new PortalPositionDA();
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

        public Int64 Insert(PortalPosition item, out ErrorEntity ErrInfo)
        {
            if (string.IsNullOrEmpty(item.FPositionName))
            {
                ErrInfo = new ErrorEntity(RespCode.Pz01001);
                return -1;
            }
            if (string.IsNullOrEmpty(item.FPositionDept))
            {
                ErrInfo = new ErrorEntity(RespCode.Pz01002);
                return -1;
            }
            if (string.IsNullOrEmpty(item.FPositionContent))
            {
                ErrInfo = new ErrorEntity(RespCode.Pz01004);
                return -1;
            }
            if (DateTime.Compare(item.FBeginDate, item.FEndDate) > 0)
            {
                ErrInfo = new ErrorEntity(RespCode.Pz01003);
                return -1;
            }
            if (item.FPositionNum <= 0)
            {
                ErrInfo = new ErrorEntity(RespCode.Pz01005);
                return -1;
            }
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FPositionName", item.FPositionName);
            parameters.Add("FPositionDept", item.FPositionDept);
            parameters.Add("FPositionType", item.FPositionType);
            parameters.Add("FPositionGendor", item.FPositionGendor);
            parameters.Add("FPositionNum", item.FPositionNum.ToString());
            parameters.Add("FBeginDate", item.FBeginDate.ToString());
            parameters.Add("FEndDate", item.FEndDate.ToString());
            parameters.Add("FPositionContent", item.FPositionContent);
            parameters.Add("FBackContent", item.FBackContent);
            parameters.Add("FPositionOrder", item.FPositionOrder.ToString());
            return Insert(parameters, out ErrInfo);
        }

        public Int32 Update(PortalPosition item, out ErrorEntity ErrInfo)
        {
            if (string.IsNullOrEmpty(item.FPositionName))
            {
                ErrInfo = new ErrorEntity(RespCode.Pz01001);
                return -1;
            }
            if (string.IsNullOrEmpty(item.FPositionDept))
            {
                ErrInfo = new ErrorEntity(RespCode.Pz01002);
                return -1;
            }
            if (string.IsNullOrEmpty(item.FPositionContent))
            {
                ErrInfo = new ErrorEntity(RespCode.Pz01004);
                return -1;
            }
            if (DateTime.Compare(item.FBeginDate, item.FEndDate) > 0)
            {
                ErrInfo = new ErrorEntity(RespCode.Pz01003);
                return -1;
            }
            if (item.FPositionNum <= 0)
            {
                ErrInfo = new ErrorEntity(RespCode.Pz01005);
                return -1;
            }
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FPositionName", item.FPositionName);
            parameters.Add("FPositionDept", item.FPositionDept);
            parameters.Add("FPositionType", item.FPositionType);
            parameters.Add("FPositionGendor", item.FPositionGendor);
            parameters.Add("FPositionNum", item.FPositionNum.ToString());
            parameters.Add("FBeginDate", item.FBeginDate.ToString());
            parameters.Add("FEndDate", item.FEndDate.ToString());
            parameters.Add("FPositionContent", item.FPositionContent);
            parameters.Add("FBackContent", item.FBackContent);
            parameters.Add("FPositionOrder", item.FPositionOrder.ToString());
            NameValueCollection where = new NameValueCollection();
            where.Add("FPositionId", item.FPositionId.ToString());
            return Update(parameters, where, out ErrInfo);
        }

        public Int32 Update(NameValueCollection parameters, NameValueCollection where, out ErrorEntity ErrInfo)
        {
            PortalPositionDA da = new PortalPositionDA();
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

        public Int32 Delete(string idList, out ErrorEntity ErrInfo)
        {
            PortalPositionDA da = new PortalPositionDA();
            NameValueCollection where = new NameValueCollection();
            where.Add("condition", "FPositionId in (" + idList + ")");
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

        public Int32 Delete(NameValueCollection where, out ErrorEntity ErrInfo)
        {
            PortalPositionDA da = new PortalPositionDA();
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
