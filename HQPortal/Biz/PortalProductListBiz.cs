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
    public class PortalProductListBiz
    {
        public List<PortalProductList> Select()
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("condition", "1=1");
            return Select(where);
        }
        
        public PortalProductList Select(string _id)
        {
            List<PortalProductList> lists = new List<PortalProductList>();
            NameValueCollection where = new NameValueCollection();
            where.Add("FProductListID", _id);
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

        public void GetListName(string _id, ref string _titlename)
        {
            PortalProductList item = new PortalProductList();
            item = Select(_id);
            if (string.IsNullOrEmpty(_titlename))
            {
                _titlename = item.FProductListName + _titlename;
            }
            else
            {
                _titlename = item.FProductListName + "&nbsp;>&nbsp;" + _titlename;
            }
            if (item.FParentListId != 0)
            {
                GetListName(item.FParentListId.ToString(), ref _titlename);
            }
        }
        
        public List<PortalProductList> Select(NameValueCollection where)
        {
            PortalProductListDA da = new PortalProductListDA();
            return da.Select(where).DataTableToList<PortalProductList>();
        }

        public List<PortalProductList> Select(NameValueCollection where, NameValueCollection orderby)
        {
            PortalProductListDA da = new PortalProductListDA();
            return da.Select(where, orderby).DataTableToList<PortalProductList>();
        }

        public List<PortalProductList> Select(NameValueCollection where, NameValueCollection orderby, Int32 PageIndex, Int32 PageSize, out Int32 totalCount)
        {
            PortalProductListDA da = new PortalProductListDA();
            return da.Select(where, orderby, PageIndex, PageSize, out totalCount).DataTableToList<PortalProductList>();
        }

        private Boolean ChkNameExist(string _id, string _name)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("FProductListID <>", _id);
            where.Add("FProductListName", _name);
            if (Select(where).Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Int64 Insert(PortalProductList item,out ErrorEntity ErrInfo)
        {
            if(string.IsNullOrEmpty(item.FProductListName))
            {
                ErrInfo = new ErrorEntity(RespCode.Pp01001);
                return -1;
            }
            if (!ChkNameExist(item.FProductListID.ToString(), item.FProductListName))
            {
                ErrInfo = new ErrorEntity(RespCode.Pp01002);
                return -1;
            }
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FProductListName",item.FProductListName);
            if(item.FParentListId > 0)
            {
                parameters.Add("FParentListId",item.FParentListId.ToString());
            }
            parameters.Add("FProductListOrder",item.FProductListOrder.ToString());
            return Insert(parameters,out ErrInfo);
        }

        public Int64 Insert(NameValueCollection parameters, out ErrorEntity ErrInfo)
        {
            PortalProductListDA da = new PortalProductListDA();
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

        public Int32 Update(PortalProductList item, out ErrorEntity ErrInfo)
        {
            if (string.IsNullOrEmpty(item.FProductListName))
            {
                ErrInfo = new ErrorEntity(RespCode.Pp01001);
                return -1;
            }
            if (!ChkNameExist(item.FProductListID.ToString(), item.FProductListName))
            {
                ErrInfo = new ErrorEntity(RespCode.Pp01002);
                return -1;
            }
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FProductListName", item.FProductListName);
            if (item.FParentListId > 0)
            {
                parameters.Add("FParentListId", item.FParentListId.ToString());
            }
            parameters.Add("FProductListOrder", item.FProductListOrder.ToString());
            NameValueCollection where = new NameValueCollection();
            where.Add("FProductListID", item.FProductListID.ToString());
            return Update(parameters, where, out ErrInfo);
        }

        public Int32 Update(NameValueCollection parameters, NameValueCollection where, out ErrorEntity ErrInfo)
        {
            PortalArticleDA da = new PortalArticleDA();
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
            where.Add("condition", "FProductListID in (" + _idlist + ")");
            return Delete(where, out ErrInfo);
        }

        public Int32 Delete(NameValueCollection where, out ErrorEntity ErrInfo)
        {
            PortalProductListDA da = new PortalProductListDA();
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
