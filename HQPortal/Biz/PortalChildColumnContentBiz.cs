using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib.Common;
using HQPortal.ML;
using System.Collections.Specialized;
using HQPortal.DA;
using HQLib;
using HQConst.Const;

namespace HQPortal.Biz
{
    public class PortalChildColumnContentBiz
    {
        public List<PortalChildColumnContent> Select(NameValueCollection where)
        {
            PortalChildColumnContentDA da = new PortalChildColumnContentDA();
            return da.Select(where).DataTableToList<PortalChildColumnContent>();
        }

        public List<PortalChildColumnContent> Select(NameValueCollection where, NameValueCollection orderby)
        {
            PortalChildColumnContentDA da = new PortalChildColumnContentDA();
            return da.Select(where, orderby).DataTableToList<PortalChildColumnContent>();
        }

        public PortalChildColumnContent SelectByChildColumnId(string childcolumnid)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("FChildColumnId", childcolumnid);
            List<PortalChildColumnContent> lists = new List<PortalChildColumnContent>();
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

        public Int32 Save(PortalChildColumnContent item, out ErrorEntity ErrInfo)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("FChildColumnId", item.FChildColumnId.ToString());
            Delete(where, out ErrInfo);
            if (ErrInfo.ErrorCode == RespCode.Success)
            {
                NameValueCollection parameters = new NameValueCollection();
                parameters.Add("FChildColumnId", item.FChildColumnId.ToString());
                parameters.Add("FCCContentText", item.FCCContentText);
                parameters.Add("FSEOTitle", item.FSEOTitle);
                parameters.Add("FSEOKeyWord", item.FSEOKeyWord);
                parameters.Add("FSEODescription", item.FSEODescription);
                Insert(parameters, out ErrInfo);
                if (ErrInfo.ErrorCode == RespCode.Success)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }

        public Int64 Insert(NameValueCollection parameters, out ErrorEntity ErrInfo)
        {
            PortalChildColumnContentDA da = new PortalChildColumnContentDA();
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

        public Int32 Update(NameValueCollection parameters, NameValueCollection where, out ErrorEntity ErrInfo)
        {
            PortalChildColumnContentDA da = new PortalChildColumnContentDA();
            Int32 result = da.Update(parameters,where);
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

        public Int32 Delete(NameValueCollection where,out ErrorEntity ErrInfo)
        {
            PortalChildColumnContentDA da = new PortalChildColumnContentDA();
            Int32 result = da.Delete(where);
            if(result >= 0)
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
