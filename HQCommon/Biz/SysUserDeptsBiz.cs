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
    public class SysUserDeptsBiz
    {
        public string GetUserDeptList(string _userid)
        {
            List<SysUserDepts> lists = new List<SysUserDepts>();
            lists = Select(_userid);
            string deptlist = "";
            foreach (SysUserDepts item in lists)
            {
                if (string.IsNullOrEmpty(deptlist))
                {
                    deptlist += item.FDepartmentId.ToString();
                }
                else
                {
                    deptlist += "," + item.FDepartmentId.ToString();
                }
            }
            return deptlist;
        }
        
        public List<SysUserDepts> Select(NameValueCollection where)
        {
            SysUserDeptsDA da = new SysUserDeptsDA();
            return da.Select(where).DataTableToList<SysUserDepts>();
        }

        public List<SysUserDepts> Select(NameValueCollection where, NameValueCollection orderby)
        {
            SysUserDeptsDA da = new SysUserDeptsDA();
            return da.Select(where, orderby).DataTableToList<SysUserDepts>();
        }

        public List<SysUserDepts> Select(NameValueCollection where, NameValueCollection orderby, int pageIndex, int pageSize, out int totalCount)
        {
            SysUserDeptsDA da = new SysUserDeptsDA();
            return da.Select(where, orderby, pageIndex, pageSize, out totalCount).DataTableToList<SysUserDepts>();
        }

        public List<SysUserDepts> Select(string _userid)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("FUserId", _userid);
            return Select(where);
        }

        public int Insert(NameValueCollection parameters, out ErrorEntity ErrInfo)
        {
            SysUserDeptsDA da = new SysUserDeptsDA();
            int result = da.Insert(parameters);
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

        public int Insert(string _userid, string _deptlistid, out ErrorEntity ErrInfo)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("FUserId", _userid);
            if (Delete(where, out ErrInfo) >= 0)
            {
                string[] deptidarray;
                deptidarray = _deptlistid.Split(',');
                for (int i = 0; i < deptidarray.Length; i++)
                {
                    NameValueCollection parameters = new NameValueCollection();
                    parameters.Add("FUserId", _userid);
                    parameters.Add("FDepartmentId", deptidarray[i]);
                    Insert(parameters, out ErrInfo);
                    if (ErrInfo.ErrorCode != RespCode.Success)
                    {
                        return -1;
                    }
                }
                return 1;
            }
            else
            {
                return -1;
            }
        }

        public int Delete(NameValueCollection where, out ErrorEntity ErrInfo)
        {
            SysUserDeptsDA da = new SysUserDeptsDA();
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
