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
    public class SysDepartmentTypeBiz
    {
        public List<SysDepartmentType> SelectAll()
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("condition", "1=1");
            NameValueCollection orderby = new NameValueCollection();
            orderby.Add("FDepartmentTypeOrder", "asc");
            return Select(where, orderby);
        }
        
        public SysDepartmentType Select(string _id)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("FDepartmentTypeId", _id);
            List<SysDepartmentType> lists = new List<SysDepartmentType>();
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
        
        public List<SysDepartmentType> Select(NameValueCollection where)
        {
            SysDepartmentTypeDA da = new SysDepartmentTypeDA();
            return da.Select(where).DataTableToList<SysDepartmentType>();
        }

        public List<SysDepartmentType> Select(NameValueCollection where, NameValueCollection orderby)
        {
            SysDepartmentTypeDA da = new SysDepartmentTypeDA();
            return da.Select(where, orderby).DataTableToList<SysDepartmentType>();
        }

        public List<SysDepartmentType> Select(NameValueCollection where, NameValueCollection orderby, int pageIndex, int pageSize, out int totalCount)
        {
            SysDepartmentTypeDA da = new SysDepartmentTypeDA();
            return da.Select(where, orderby, pageIndex, pageSize, out totalCount).DataTableToList<SysDepartmentType>();
        }

        public Int64 Insert(NameValueCollection parameters, out ErrorEntity ErrInfo)
        {
            SysDepartmentTypeDA da = new SysDepartmentTypeDA();
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

        private Boolean ChkDepartmentTypeName(Int64 _id, string _name)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("FDepartmentTypeId <>", _id.ToString());
            where.Add("FDepartmentTypeName", _name);
            if (Select(where).Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public Int64 Insert(SysDepartmentType item, out ErrorEntity ErrInfo)
        {
            if (string.IsNullOrEmpty(item.FDepartmentTypeName))
            {
                ErrInfo = new ErrorEntity("NT010001", "部门归属名称不能为空!");
                return -1;
            }

            if (item.FDepartmentTypeOrder == 0)
            {
                ErrInfo = new ErrorEntity("NT010002", "部门归属显示排序不能为空!");
                return -1;
            }
            if (!ChkDepartmentTypeName(item.FDepartmentTypeId, item.FDepartmentTypeName))
            {
                ErrInfo = new ErrorEntity("NT010003", "部门归属名称已经存在,不能重复!");
                return -1;
            }
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FDepartmentTypeName", item.FDepartmentTypeName);
            parameters.Add("FDepartmentTypeOrder", item.FDepartmentTypeOrder.ToString());
            return Insert(parameters, out ErrInfo);
        }

        public Int32 Update(NameValueCollection parameters, NameValueCollection where, out ErrorEntity ErrInfo)
        {
            SysDepartmentTypeDA da = new SysDepartmentTypeDA();
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

        public Int32 Update(SysDepartmentType item, out ErrorEntity ErrInfo)
        {
            if (string.IsNullOrEmpty(item.FDepartmentTypeName))
            {
                ErrInfo = new ErrorEntity("NT010001", "部门归属名称不能为空!");
                return -1;
            }

            if (item.FDepartmentTypeOrder == 0)
            {
                ErrInfo = new ErrorEntity("NT010002", "部门归属显示排序不能为空!");
                return -1;
            }
            if (!ChkDepartmentTypeName(item.FDepartmentTypeId, item.FDepartmentTypeName))
            {
                ErrInfo = new ErrorEntity("NT010003", "部门归属名称已经存在,不能重复!");
                return -1;
            }
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FDepartmentTypeName", item.FDepartmentTypeName);
            parameters.Add("FDepartmentTypeOrder", item.FDepartmentTypeOrder.ToString());
            NameValueCollection where = new NameValueCollection();
            where.Add("FDepartmentTypeId", item.FDepartmentTypeId.ToString());
            return Update(parameters, where, out ErrInfo);

        }

        public Int32 Delete(string _idlist, out ErrorEntity ErrInfo)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("condition", "FDepartmentTypeId in (" + _idlist + ")");
            return Delete(where, out ErrInfo);
        }

        public Int32 Delete(NameValueCollection where, out ErrorEntity ErrInfo)
        {
            SysDepartmentTypeDA da = new SysDepartmentTypeDA();
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
