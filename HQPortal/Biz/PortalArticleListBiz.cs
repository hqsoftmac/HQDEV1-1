using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib.Common;
using HQPortal.DA;
using HQPortal.ML;
using System.Collections.Specialized;
using HQLib;
using HQConst.Const;

namespace HQPortal.Biz
{
    public class PortalArticleListBiz
    {
        public PortalArticleList Select(string _listid)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("FListId", _listid);
            List<PortalArticleList> lists = new List<PortalArticleList>();
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

        public List<PortalArticleList> Select()
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("condition", "1=1");
            NameValueCollection orderby = new NameValueCollection();
            orderby.Add("FListOrder","ASC");
            return Select(where, orderby);
        }

        public void GetListName(string _id,ref string _titlename)
        {
            PortalArticleList item = new PortalArticleList();
            item = Select(_id);
            if (string.IsNullOrEmpty(_titlename))
            {
                _titlename = item.FListName  + _titlename;
            }
            else
            {
                _titlename = item.FListName + "&nbsp;>&nbsp;" + _titlename;
            }
            if (item.FParentListId != 0)
            {
                GetListName(item.FParentListId.ToString(), ref _titlename);
            }
        }

        public List<PortalArticleList> SelectByParentId(string _parentid)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("FParentListId", _parentid);
            NameValueCollection orderby = new NameValueCollection();
            orderby.Add("FListOrder", "asc");
            return Select(where, orderby);
        }

        public List<PortalArticleList> SelectTopList()
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("condition", "FParentListId is null");
            NameValueCollection orderby = new NameValueCollection();
            orderby.Add("FListOrder", "asc");
            return Select(where, orderby);
        }
        
        public List<PortalArticleList> Select(NameValueCollection where)
        {
            PortalArticleListDA da = new PortalArticleListDA();
            return da.Select(where).DataTableToList<PortalArticleList>();
        }

        public List<PortalArticleList> Select(NameValueCollection where, NameValueCollection orderby)
        {
            PortalArticleListDA da = new PortalArticleListDA();
            return da.Select(where, orderby).DataTableToList<PortalArticleList>();
        }

        public List<PortalArticleList> Select(NameValueCollection where, NameValueCollection orderby, int pageIndex, int pageSize, out int totalCount)
        {
            PortalArticleListDA da = new PortalArticleListDA();
            return da.Select(where, orderby, pageIndex, pageSize, out totalCount).DataTableToList<PortalArticleList>();
        }

        public Boolean ChkNameExist(Int64 _id,Int64 _parentid,string _name)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("FListId <>",_id.ToString());
            where.Add("FListName",_name);
            where.Add("FParentListId",_parentid.ToString());
            if(Select(where).Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Int64 Insert(PortalArticleList item, out ErrorEntity ErrInfo)
        {
            if(string.IsNullOrEmpty(item.FListName))
            {
                ErrInfo = new ErrorEntity("999999","目录名称不能为空!");
                return -1;
            }
            if(item.FListOrder == 0)
            {
                ErrInfo = new ErrorEntity("999999","目录顺序不能为空!");
                return -1;
            }
            if (ChkNameExist(item.FListId, item.FParentListId, item.FListName))
            {
                NameValueCollection parameters = new NameValueCollection();
                parameters.Add("FListName", item.FListName);
                parameters.Add("FListOrder", item.FListOrder.ToString());
                if (item.FParentListId > 0)
                {
                    parameters.Add("FParentListId", item.FParentListId.ToString());
                }
                Int64 result = Insert(parameters, out ErrInfo);
                return result;
            }
            else
            {
                ErrInfo = new ErrorEntity("999999", "目录名称重复,无法保存!");
                return -1;
            }
        }


        public Int64 Insert(NameValueCollection parameters, out ErrorEntity ErrInfo)
        {
            PortalArticleListDA da = new PortalArticleListDA();
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

        public Int32 Update(PortalArticleList item, out ErrorEntity ErrInfo)
        {
            if (string.IsNullOrEmpty(item.FListName))
            {
                ErrInfo = new ErrorEntity("999999", "目录名称不能为空!");
                return -1;
            }
            if (item.FListOrder == 0)
            {
                ErrInfo = new ErrorEntity("999999", "目录顺序不能为空!");
                return -1;
            }
            if (ChkNameExist(item.FListId, item.FParentListId, item.FListName))
            {
                NameValueCollection parameters = new NameValueCollection();
                parameters.Add("FListName", item.FListName);
                parameters.Add("FListOrder", item.FListOrder.ToString());
                if (item.FParentListId > 0)
                {
                    parameters.Add("FParentListId", item.FParentListId.ToString());
                }
                NameValueCollection where = new NameValueCollection();
                where.Add("FListId", item.FListId.ToString());
                Int32 result = Update(parameters, where, out ErrInfo);
                return result;
            }
            else
            {
                ErrInfo = new ErrorEntity("999999", "目录名称重复,无法保存!");
                return -1;
            }
        }


        public Int32 Update(NameValueCollection parameters, NameValueCollection where, out ErrorEntity ErrInfo)
        {
            PortalArticleListDA da = new PortalArticleListDA();
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

        public Int32 Delete(string idlist,out ErrorEntity ErrInfo)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("condition", "FListId in (" + idlist + ")");
            try
            {
                return Delete(where, out ErrInfo);
            }
            catch (Exception ex)
            {
                ErrInfo = new ErrorEntity("999999", "删除失败,可能该目录下存在下级目录!错误原因:" + ex.Message);
                return -1;
            }
        }

        public Int32 Delete(NameValueCollection where, out ErrorEntity ErrInfo)
        {
            PortalArticleListDA da = new PortalArticleListDA();
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
