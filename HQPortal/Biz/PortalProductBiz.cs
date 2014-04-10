using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQPortal.ML;
using HQPortal.DA;
using System.Collections.Specialized;
using HQLib.Common;
using HQLib;
using HQConst.Const;

namespace HQPortal.Biz
{
    public class PortalProductBiz
    {
        public List<PortalProduct> Select(NameValueCollection where)
        {
            PortalProductDA da = new PortalProductDA();
            return da.Select(where).DataTableToList<PortalProduct>();
        }

        public List<PortalProduct> Select(NameValueCollection where, NameValueCollection orderby)
        {
            PortalProductDA da = new PortalProductDA();
            return da.Select(where, orderby).DataTableToList<PortalProduct>();
        }

        public List<PortalProduct> Select(NameValueCollection where, NameValueCollection orderby, int _pageIndex, int _pageSize, out int _totalCount)
        {
            PortalProductDA da = new PortalProductDA();
            return da.Select(where, orderby, _pageIndex, _pageSize, out _totalCount).DataTableToList<PortalProduct>();
        }

        public PortalProduct Select(string _id)
        {
            List<PortalProduct> lists = new List<PortalProduct>();
            NameValueCollection where = new NameValueCollection();
            where.Add("FProductId", _id);
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
            PortalProductDA da = new PortalProductDA();
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

        public Int64 Insert(PortalProduct item, out ErrorEntity ErrInfo)
        {
            if (item.FProductListID == 0)
            {
                ErrInfo = new ErrorEntity(RespCode.Pp01003);
                return -1;
            }
            if (string.IsNullOrEmpty(item.FProductName))
            {
                ErrInfo = new ErrorEntity(RespCode.Pp01004);
                return -1;
            }
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FProductListID", item.FProductListID.ToString());
            parameters.Add("FProductName", item.FProductName);
            parameters.Add("FProductModule", item.FProductModule);
            parameters.Add("FProductDesc", item.FProductDesc);
            parameters.Add("FProductPic", item.FProductPic);
            parameters.Add("FBriefPic", item.FBriefPic);
            parameters.Add("FSEOTitle", item.FSEOTitle);
            parameters.Add("FSEOKeyWord", item.FSEOKeyWord);
            parameters.Add("FSEODesc", item.FSEODesc);
            parameters.Add("FProductBrief", item.FProductBrief);
            parameters.Add("FProductContent", item.FProductContent);
            return Insert(parameters, out ErrInfo);
        }

        public Int32 Update(NameValueCollection parameters, NameValueCollection where, out ErrorEntity ErrInfo)
        {
            PortalProductDA da = new PortalProductDA();
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

        public Int32 Update(PortalProduct item, out ErrorEntity ErrInfo)
        {
            if (item.FProductListID == 0)
            {
                ErrInfo = new ErrorEntity(RespCode.Pp01003);
                return -1;
            }
            if (string.IsNullOrEmpty(item.FProductName))
            {
                ErrInfo = new ErrorEntity(RespCode.Pp01004);
                return -1;
            }
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FProductListID", item.FProductListID.ToString());
            parameters.Add("FProductName", item.FProductName);
            parameters.Add("FProductModule", item.FProductModule);
            parameters.Add("FProductDesc", item.FProductDesc);
            parameters.Add("FProductPic", item.FProductPic);
            parameters.Add("FBriefPic", item.FBriefPic);
            parameters.Add("FSEOTitle", item.FSEOTitle);
            parameters.Add("FSEOKeyWord", item.FSEOKeyWord);
            parameters.Add("FSEODesc", item.FSEODesc);
            parameters.Add("FProductBrief", item.FProductBrief);
            parameters.Add("FProductContent", item.FProductContent);
            NameValueCollection where = new NameValueCollection();
            where.Add("FProductId", item.FProductId.ToString());
            return Update(parameters, where, out ErrInfo);
        }

        public Int32 Delete(string _idlist, out ErrorEntity ErrInfo)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("condition", "FProductId in (" + _idlist + ")");
            return Delete(where, out ErrInfo);
        }

        public Int32 Delete(NameValueCollection where, out ErrorEntity ErrInfo)
        {
            PortalProductDA da = new PortalProductDA();
            Int32 result = da.Delete(where);
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
