using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQPortal.ML;
using HQPortal.DA;
using System.Data;
using HQLib.Common;
using System.Collections.Specialized;
using HQLib;
using HQConst.Const;

namespace HQPortal.Biz
{
    public class PortalColumnBiz
    {
        public List<PortalColumn> Select(NameValueCollection where)
        {
            PortalColumnDA da = new PortalColumnDA();
            return da.Select(where).DataTableToList<PortalColumn>();
        }

        public List<PortalColumn> Select(NameValueCollection where, NameValueCollection orderby)
        {
            PortalColumnDA da = new PortalColumnDA();
            return da.Select(where, orderby).DataTableToList<PortalColumn>();
        }

        public List<PortalColumn> SelectValidColumn()
        {
            List<PortalColumn> lists = new List<PortalColumn>();
            NameValueCollection where = new NameValueCollection();
            where.Add("FColumnVisible", "1");
            NameValueCollection orderby = new NameValueCollection();
            orderby.Add("FParentColumnId", "asc");
            orderby.Add("FColumnOrder", "asc");
            return Select(where, orderby);
        }

        public PortalColumn Select(string _id)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("FColumnId", _id);
            List<PortalColumn> lists = new List<PortalColumn>();
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

        public List<PortalColumn> Select(NameValueCollection where, NameValueCollection orderby, int pageIndex, int pageSize, out int totalCount)
        {
            PortalColumnDA da = new PortalColumnDA();
            return da.Select(where, orderby, pageIndex, pageSize, out totalCount).DataTableToList<PortalColumn>();
        }

        public Boolean ChkNameRepeation(Int64 _columnId, string _columnName)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("FColumnId <>", _columnId.ToString());
            where.Add("FColumnName", _columnName);
            int rowcount = Select(where).Count;
            if (rowcount > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        

        public Boolean ChkIndexPageExist(Int64 _columnid, string _columntype,out ErrorEntity ErrInfo)
        {
            switch (_columntype)
            {
                case "0":
                    NameValueCollection where1 = new NameValueCollection();
                    where1.Add("FColumnType", "1");
                    if (Select(where1).Count > 0)
                    {
                        ErrInfo = new ErrorEntity(RespCode.Success);
                        return true;
                    }
                    else
                    {
                        ErrInfo = new ErrorEntity(RespCode.Pt010008);
                        return false;
                    }
                case "1":
                    NameValueCollection where = new NameValueCollection();
                    where.Add("FColumnType", _columntype);
                    where.Add("FColumnId <>", _columnid.ToString());
                    if (Select(where).Count > 0)
                    {
                        ErrInfo = new ErrorEntity(RespCode.Pt010006);
                        return false;
                    }
                    else
                    {
                        ErrInfo = new ErrorEntity(RespCode.Success);
                        return true;
                    }
                default:
                    ErrInfo = new ErrorEntity(RespCode.Pt010007);
                    return false;
            }
        }

        public Int64 Insert(PortalColumn item, out ErrorEntity ErrInfo)
        {
            //判别栏目内容
            if (string.IsNullOrEmpty(item.FColumnName))
            {
                ErrInfo = new ErrorEntity(RespCode.Pt010001);
                return -1;
            }
            if (string.IsNullOrEmpty(item.FColumnOrder.ToString()) || item.FColumnOrder == 0)
            {
                ErrInfo = new ErrorEntity(RespCode.Pt010004);
                return -1;
            }
            //判别重复
            if (!ChkNameRepeation(item.FColumnId, item.FColumnName))
            {
                ErrInfo = new ErrorEntity(RespCode.Pt010005);
                return -1;
            }
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FColumnName", item.FColumnName);
            parameters.Add("FColumnContent", item.FColumnContent);
            if (string.IsNullOrEmpty(item.FColumnType))
            {
                item.FColumnType = "0";
            }
            parameters.Add("FColumnType", item.FColumnType);
            parameters.Add("FColumnUrl", item.FColumnUrl);
            if (string.IsNullOrEmpty(item.FColumnTarget))
            {
                item.FColumnTarget = "0";
            }
            parameters.Add("FColumnTarget", item.FColumnTarget);
            if(string.IsNullOrEmpty(item.FColumnVisible))
            {
                item.FColumnVisible = "1";
            }
            if (item.FColumnType == "1")
            {
                item.FColumnVisible = "1";
            }
            parameters.Add("FColumnVisible", item.FColumnVisible);
            parameters.Add("FColumnOrder", item.FColumnOrder.ToString());
            if (item.FParentColumnId != 0)
            {
                parameters.Add("FParentColumnId", item.FParentColumnId.ToString());
            }
            if (ChkIndexPageExist(item.FColumnId, item.FColumnType, out ErrInfo))
            {
                return Insert(parameters, out ErrInfo);
            }
            else
            {
                return -1;
            }
        }

        

        public Int64 Insert(NameValueCollection parameters, out ErrorEntity ErrInfo)
        {
            PortalColumnDA da = new PortalColumnDA();
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

        public int Update(NameValueCollection parameters, NameValueCollection where, out ErrorEntity ErrInfo)
        {
            PortalColumnDA da = new PortalColumnDA();
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

        public int Update(PortalColumn item, out ErrorEntity ErrInfo)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("FColumnId", item.FColumnId.ToString());
            //判别栏目内容
            if (string.IsNullOrEmpty(item.FColumnName))
            {
                ErrInfo = new ErrorEntity(RespCode.Pt010001);
                return -1;
            }
            if (string.IsNullOrEmpty(item.FColumnOrder.ToString()) || item.FColumnOrder == 0)
            {
                ErrInfo = new ErrorEntity(RespCode.Pt010004);
                return -1;
            }
            //判别重复
            if (!ChkNameRepeation(item.FColumnId, item.FColumnName))
            {
                ErrInfo = new ErrorEntity(RespCode.Pt010005);
                return -1;
            }
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FColumnName", item.FColumnName);
            parameters.Add("FColumnContent", item.FColumnContent);
            if (string.IsNullOrEmpty(item.FColumnType))
            {
                item.FColumnType = "0";
            }
            parameters.Add("FColumnType", item.FColumnType);
            parameters.Add("FColumnUrl", item.FColumnUrl);
            if (string.IsNullOrEmpty(item.FColumnTarget))
            {
                item.FColumnTarget = "0";
            }
            parameters.Add("FColumnTarget", item.FColumnTarget);
            if (string.IsNullOrEmpty(item.FColumnVisible))
            {
                item.FColumnVisible = "1";
            }
            if (item.FColumnType == "1")
            {
                item.FColumnVisible = "1";
            }
            parameters.Add("FColumnVisible", item.FColumnVisible);
            parameters.Add("FColumnOrder", item.FColumnOrder.ToString());
            if (item.FParentColumnId != 0)
            {
                parameters.Add("FParentColumnId", item.FParentColumnId.ToString());
            }
            if (ChkIndexPageExist(item.FColumnId, item.FColumnType, out ErrInfo))
            {
                return Update(parameters, where, out ErrInfo);
            }
            else
            {
                return -1;
            }
        }

        public int Delete(string idlist, out ErrorEntity ErrInfo)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("condition", "FColumnId in (" + idlist + ")");
            return Delete(where, out ErrInfo);
        }

        public int Delete(NameValueCollection where, out ErrorEntity ErrInfo)
        {
            PortalColumnDA da = new PortalColumnDA();
            int result = da.Delete(where);
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
