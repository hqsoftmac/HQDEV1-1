using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib.Common;
using HQCommon.ML;
using System.Collections.Specialized;
using HQCommon.DA;
using HQLib;
using HQConst.Const;

namespace HQCommon.Biz
{
    public class SysDepartmentBiz
    {
        public List<SysDepartment> SelectDeptByUser(string _userid)
        {
            if (_userid == "1")
            {
                return Select();
            }
            else
            {
                string deptlist = "";
                List<SysUserDepts> lists = new List<SysUserDepts>();
                SysUserDeptsBiz biz = new SysUserDeptsBiz();
                deptlist = biz.GetUserDeptList(_userid);
                if (string.IsNullOrEmpty(deptlist))
                {
                    return null;
                }
                else
                {
                    string sql = "";
                    sql = "FDepartmentId in (" + deptlist + ")";
                    NameValueCollection where = new NameValueCollection();
                    where.Add("codition", sql);
                    return Select(where);
                }
            }
        }
        
        public List<SysDepartment> Select()
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("condition", "1=1");
            NameValueCollection orderby = new NameValueCollection();
            orderby.Add("FDepartmentCode", "asc");
            return Select(where, orderby);
        }

        public SysDepartment Select(string _id)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("FDepartmentId", _id);
            List<SysDepartment> lists = new List<SysDepartment>();
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
        
        public List<SysDepartment> Select(NameValueCollection where)
        {
            SysDepartmentDA da = new SysDepartmentDA();
            return da.Select(where).DataTableToList<SysDepartment>();
        }

        public List<SysDepartment> Select(NameValueCollection where, NameValueCollection orderby)
        {
            SysDepartmentDA da = new SysDepartmentDA();
            return da.Select(where, orderby).DataTableToList<SysDepartment>();
        }

        public List<SysDepartment> Select(NameValueCollection where, NameValueCollection orderby, int PageIndex, int PageSize, out int totalCount)
        {
            SysDepartmentDA da = new SysDepartmentDA();
            return da.Select(where, orderby, PageIndex, PageSize, out totalCount).DataTableToList<SysDepartment>();
        }

        public Boolean ChkDeptName(string _id, string _name)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("FDepartmentId <>", _id);
            where.Add("FDepartmentName", _name);
            if (Select(where).Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Boolean ChkDeptCode(string _id, string _code)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("FDepartmentId <>", _id);
            where.Add("FDepartmentCode", _code);
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
            SysDepartmentDA da = new SysDepartmentDA();
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


        public Int64 Insert(SysDepartment item, out ErrorEntity ErrInfo)
        {
            if (string.IsNullOrEmpty(item.FDepartmentName))
            {
                ErrInfo = new ErrorEntity("DM010001", "部门名称不能为空!");
                return -1;
            }
            if (string.IsNullOrEmpty(item.FDepartmentCode))
            {
                ErrInfo = new ErrorEntity("DM010002", "部门编号不能为空!");
                return -1;
            }
            if (!ChkDeptCode(item.FDepartmentID.ToString(), item.FDepartmentCode))
            {
                ErrInfo = new ErrorEntity("DM010003", "部门编号已经存在,不能重复!");
                return -1;
            }
            if (!ChkDeptName(item.FDepartmentID.ToString(), item.FDepartmentName))
            {
                ErrInfo = new ErrorEntity("DM010004", "部门名称已经存在,不能重复!");
                return -1;
            }
            if(item.FDepartmentTypeId == 0)
            {
                ErrInfo = new ErrorEntity("DM010005","部门归属不能为空!");
                return -1;
            }
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FDepartmentTypeId", item.FDepartmentTypeId.ToString());
            parameters.Add("FDepartmentCode", item.FDepartmentCode);
            parameters.Add("FDepartmentName", item.FDepartmentName);
            parameters.Add("FDepartmentCharge", item.FDepartmentCharge);
            if (item.FDepartmentNum > 1)
            {
                parameters.Add("FDepartmentNum", item.FDepartmentNum.ToString());
            }
            parameters.Add("FDepartmentTel", item.FDepartmentTel);
            parameters.Add("FDepartmentContent", item.FDepartmentContent);
            return Insert(parameters, out ErrInfo);

        }

        public Int32 Update(NameValueCollection parameters, NameValueCollection where, out ErrorEntity ErrInfo)
        {
            SysDepartmentDA da = new SysDepartmentDA();
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

        public Int32 Update(SysDepartment item, out ErrorEntity ErrInfo)
        {
            if (string.IsNullOrEmpty(item.FDepartmentName))
            {
                ErrInfo = new ErrorEntity("DM010001", "部门名称不能为空!");
                return -1;
            }
            if (string.IsNullOrEmpty(item.FDepartmentCode))
            {
                ErrInfo = new ErrorEntity("DM010002", "部门编号不能为空!");
                return -1;
            }
            if (!ChkDeptCode(item.FDepartmentID.ToString(), item.FDepartmentCode))
            {
                ErrInfo = new ErrorEntity("DM010003", "部门编号已经存在,不能重复!");
                return -1;
            }
            if (!ChkDeptName(item.FDepartmentID.ToString(), item.FDepartmentName))
            {
                ErrInfo = new ErrorEntity("DM010004", "部门名称已经存在,不能重复!");
                return -1;
            }
            if (item.FDepartmentTypeId == 0)
            {
                ErrInfo = new ErrorEntity("DM010005", "部门归属不能为空!");
                return -1;
            }
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FDepartmentTypeId", item.FDepartmentTypeId.ToString());
            parameters.Add("FDepartmentCode", item.FDepartmentCode);
            parameters.Add("FDepartmentName", item.FDepartmentName);
            parameters.Add("FDepartmentCharge", item.FDepartmentCharge);
            if (item.FDepartmentNum > 1)
            {
                parameters.Add("FDepartmentNum", item.FDepartmentNum.ToString());
            }
            parameters.Add("FDepartmentTel", item.FDepartmentTel);
            parameters.Add("FDepartmentContent", item.FDepartmentContent);
            NameValueCollection where = new NameValueCollection();
            where.Add("FDepartmentID", item.FDepartmentID.ToString());
            return Update(parameters, where, out ErrInfo);
        }

        public int Delete(NameValueCollection where, out ErrorEntity ErrInfo)
        {
            SysDepartmentDA da = new SysDepartmentDA();
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

        public int Delete(string idlist, out ErrorEntity ErrInfo)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("condition", "FDepartmentId in (" + idlist + ")");
            return Delete(where, out ErrInfo);
        }
    }
}
