using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQPartyManage.ML;
using HQLib.Common;
using System.Collections.Specialized;
using HQPartyManage.DA;
using HQLib;
using HQConst.Const;
namespace HQPartyManage.Biz
{
    //PmOrgInfo
    public partial class PmOrgInfoBiz
    {
        public List<PmOrgInfo> SelectByDeptId(string _deptid)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("FDepartmentID", _deptid);
            return Select(where);
        }
        
        public PmOrgInfo Select(string _id)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("FOrgId", _id);
            List<PmOrgInfo> lists = new List<PmOrgInfo>();
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

        public void GetParentOrgName(string _parentid, ref string _name)
        {
            PmOrgInfo item = new PmOrgInfo();
            item = Select(_parentid);
            if (item == null)
            {
                if (string.IsNullOrEmpty(_name))
                {
                    _name = "无";
                }
            }
            else
            {
                if (string.IsNullOrEmpty(_name))
                {
                    _name = item.FOrgName;
                }
                else
                {
                    _name = item.FOrgName + "&nbsp;-&nbsp;" + _name;
                }
                GetParentOrgName(item.FParentOrgId.ToString(), ref _name);
            }

        }

        public List<PmOrgInfo> Select(NameValueCollection where)
        {
            PmOrgInfoDA da = new PmOrgInfoDA();
            return da.Select(where).DataTableToList<PmOrgInfo>();
        }

        public List<PmOrgInfo> Select(NameValueCollection where, NameValueCollection orderby)
        {
            PmOrgInfoDA da = new PmOrgInfoDA();
            return da.Select(where, orderby).DataTableToList<PmOrgInfo>();
        }

        public List<PmOrgInfo> Select(NameValueCollection where, NameValueCollection orderby, int pageIndex, int pageSize, out int totalCount)
        {
            PmOrgInfoDA da = new PmOrgInfoDA();
            return da.Select(where, orderby, pageIndex, pageSize, out totalCount).DataTableToList<PmOrgInfo>();
        }

        public Int64 Insert(PmOrgInfo item, out ErrorEntity ErrInfo)
        {
            if (string.IsNullOrEmpty(item.FOrgName))
            {
                ErrInfo = new ErrorEntity("OI010001", "组织名称不能为空!");
                return -1;
            }
            if (string.IsNullOrEmpty(item.FOrgType))
            {
                ErrInfo = new ErrorEntity("OI010002", "组织类型不能为空!");
                return -1;
            }
            if (item.FDepartmentID == 0)
            {
                ErrInfo = new ErrorEntity("OI010003", "所属部门不能为空!");
                return -1;
            }
            if (item.FOrgOrder == 0)
            {
                ErrInfo = new ErrorEntity("OI010004", "组织显示顺序不能为空!");
                return -1;
            }
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FDepartmentID", item.FDepartmentID.ToString());
            parameters.Add("FOrgName", item.FOrgName);
            parameters.Add("FParentOrgId", item.FParentOrgId.ToString());
            parameters.Add("FOrgType", item.FOrgType);
            parameters.Add("FOrgNewDate", item.FOrgNewDate.ToString());
            parameters.Add("FOrgOrder", item.FOrgOrder.ToString());
            return Insert(parameters, out ErrInfo);
        }

        public Int64 Insert(NameValueCollection parameters, out ErrorEntity ErrInfo)
        {
            PmOrgInfoDA da = new PmOrgInfoDA();
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

        public int Update(PmOrgInfo item, out ErrorEntity ErrInfo)
        {
            if (string.IsNullOrEmpty(item.FOrgName))
            {
                ErrInfo = new ErrorEntity("OI010001", "组织名称不能为空!");
                return -1;
            }
            if (string.IsNullOrEmpty(item.FOrgType))
            {
                ErrInfo = new ErrorEntity("OI010002", "组织类型不能为空!");
                return -1;
            }
            if (item.FDepartmentID == 0)
            {
                ErrInfo = new ErrorEntity("OI010003", "所属部门不能为空!");
                return -1;
            }
            if (item.FOrgOrder == 0)
            {
                ErrInfo = new ErrorEntity("OI010004", "组织显示顺序不能为空!");
                return -1;
            }
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FDepartmentID", item.FDepartmentID.ToString());
            parameters.Add("FOrgName", item.FOrgName);
            parameters.Add("FParentOrgId", item.FParentOrgId.ToString());
            parameters.Add("FOrgType", item.FOrgType);
            parameters.Add("FOrgNewDate", item.FOrgNewDate.ToString());
            parameters.Add("FOrgOrder", item.FOrgOrder.ToString());
            NameValueCollection where = new NameValueCollection();
            where.Add("FOrgId", item.FOrgId.ToString());
            return Update(parameters, where, out ErrInfo);
        }

        public int Update(NameValueCollection parameters, NameValueCollection where, out ErrorEntity ErrInfo)
        {
            PmOrgInfoDA da = new PmOrgInfoDA();
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

        public int Delete(string idlist, out ErrorEntity ErrInfo)
        {
            NameValueCollection chkwhere = new NameValueCollection();
            chkwhere.Add("condition", "FParentOrgId in (" + idlist + ")");
            if (Select(chkwhere).Count > 0)
            {
                ErrInfo = new ErrorEntity("OI010005", "当前要删除的组织,存在下级组织!");
                return -1;
            }
            
            NameValueCollection where = new NameValueCollection();
            where.Add("condition", "FOrgId in (" + idlist + ")");
            return Delete(where, out ErrInfo);
        }

        public int Delete(NameValueCollection where, out ErrorEntity ErrInfo)
        {
            PmOrgInfoDA da = new PmOrgInfoDA();
            int result = da.Delete(where);
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