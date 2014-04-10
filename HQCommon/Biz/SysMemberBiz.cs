using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQCommon.ML;
using HQLib.Common;
using System.Collections.Specialized;
using HQCommon.DA;
using HQLib;
using HQConst.Const;

namespace HQCommon.Biz
{
    public class SysMemberBiz
    {
        public int Stop(string _memberid, out ErrorEntity ErrInfo)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("FMemberId", _memberid);
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FStatus", "0");
            return Update(parameters, where, out ErrInfo);
        }

        public int Start(string _memberid,out ErrorEntity ErrInfo)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("FMemberId", _memberid);
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FStatus", "1");
            return Update(parameters, where, out ErrInfo);
        }

        public SysMember Select(string _memberid)
        {
            NameValueCollection where = new NameValueCollection();
            List<SysMember> lists = new List<SysMember>();
            where.Add("FMemberId", _memberid);
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

        public List<SysMember> Select(NameValueCollection where)
        {
            SysMemberDA da = new SysMemberDA();
            return da.Select(where).DataTableToList<SysMember>();
        }

        public List<SysMember> Select(NameValueCollection where, NameValueCollection orderby)
        {
            SysMemberDA da = new SysMemberDA();
            return da.Select(where, orderby).DataTableToList<SysMember>();
        }

        public List<SysMember> Select(NameValueCollection where, NameValueCollection orderby, int pageIndex, int pageSize, out int totalCount)
        {
            SysMemberDA da = new SysMemberDA();
            return da.Select(where, orderby, pageIndex, pageSize, out totalCount).DataTableToList<SysMember>();
        }

        public Int64 Insert(NameValueCollection parameters, out ErrorEntity ErrInfo)
        {
            SysMemberDA da = new SysMemberDA();
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

        private Boolean ChkMemberCode(string _id, string _code)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("FMemberCode", _code);
            where.Add("FMemberId <>", _id);
            if (Select(where).Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private Boolean ChkMemberIdNumber(string _id, string _IDNumber)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("FMemberId <>", _id);
            where.Add("FIDNumber", _IDNumber);
            if (Select(where).Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Int64 Insert(SysMember item, out ErrorEntity ErrInfo)
        {
            if (string.IsNullOrEmpty(item.FBirthDateStr))
            {
                ErrInfo = new ErrorEntity("MB010001", "出生日期不能为空!");
                return -1;
            }
            if (item.FDepartmentId == 0)
            {
                ErrInfo = new ErrorEntity("MB010002", "所属部门不能为空!");
                return -1;
            }
            if (item.FEductionId == 0)
            {
                ErrInfo = new ErrorEntity("MB010003", "人员学历不能为空!");
                return -1;
            }
            if (string.IsNullOrEmpty(item.FIDNumber))
            {
                ErrInfo = new ErrorEntity("MB010004", "人员身份证号码不能为空!");
                return -1;
            }
            if (!ChkMemberIdNumber(item.FMemberId.ToString(), item.FIDNumber))
            {
                ErrInfo = new ErrorEntity("MB010005", "人员身份证号码已经存在,不能重复!");
                return -1;
            }
            if (string.IsNullOrEmpty(item.FMemberCode))
            {
                ErrInfo = new ErrorEntity("MB010006", "人员编号不能为空!");
                return -1;
            }
            if (!ChkMemberCode(item.FMemberId.ToString(), item.FMemberCode))
            {
                ErrInfo = new ErrorEntity("MB010007", "人员编号已经存在,不能重复!");
                return -1;
            }
            if (string.IsNullOrEmpty(item.FMemberName))
            {
                ErrInfo = new ErrorEntity("MB010008", "人员姓名不能为空!");
                return -1;
            }
            if (string.IsNullOrEmpty(item.FMobile))
            {
                ErrInfo = new ErrorEntity("MB010009", "移动电话不能为空!");
                return -1;
            }
            if (item.FNationId == 0)
            {
                ErrInfo = new ErrorEntity("MB010010", "人员民族不能为空!");
                return -1;
            }
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FBirthDate", item.FBirthDate.ToString());
            parameters.Add("FDepartmentId", item.FDepartmentId.ToString());
            parameters.Add("FEductionId", item.FEductionId.ToString());
            parameters.Add("FIDNumber", item.FIDNumber);
            parameters.Add("FMemberCode", item.FMemberCode);
            parameters.Add("FMemberGendor", item.FMemberGendor);
            parameters.Add("FMemberName", item.FMemberName);
            parameters.Add("FMobile", item.FMobile);
            parameters.Add("FNationId", item.FNationId.ToString());
            parameters.Add("FPicPath", item.FPicPathStr);
            parameters.Add("FPosition", item.FPosition);
            parameters.Add("FStatus", "1");
            return Insert(parameters, out ErrInfo);
        }

        public int Update(SysMember item, out ErrorEntity ErrInfo)
        {
            if (string.IsNullOrEmpty(item.FBirthDateStr))
            {
                ErrInfo = new ErrorEntity("MB010001", "出生日期不能为空!");
                return -1;
            }
            if (item.FDepartmentId == 0)
            {
                ErrInfo = new ErrorEntity("MB010002", "所属部门不能为空!");
                return -1;
            }
            if (item.FEductionId == 0)
            {
                ErrInfo = new ErrorEntity("MB010003", "人员学历不能为空!");
                return -1;
            }
            if (string.IsNullOrEmpty(item.FIDNumber))
            {
                ErrInfo = new ErrorEntity("MB010004", "人员身份证号码不能为空!");
                return -1;
            }
            if (!ChkMemberIdNumber(item.FMemberId.ToString(), item.FIDNumber))
            {
                ErrInfo = new ErrorEntity("MB010005", "人员身份证号码已经存在,不能重复!");
                return -1;
            }
            if (string.IsNullOrEmpty(item.FMemberCode))
            {
                ErrInfo = new ErrorEntity("MB010006", "人员编号不能为空!");
                return -1;
            }
            if (!ChkMemberCode(item.FMemberId.ToString(), item.FMemberCode))
            {
                ErrInfo = new ErrorEntity("MB010007", "人员编号已经存在,不能重复!");
                return -1;
            }
            if (string.IsNullOrEmpty(item.FMemberName))
            {
                ErrInfo = new ErrorEntity("MB010008", "人员姓名不能为空!");
                return -1;
            }
            if (string.IsNullOrEmpty(item.FMobile))
            {
                ErrInfo = new ErrorEntity("MB010009", "移动电话不能为空!");
                return -1;
            }
            if (item.FNationId == 0)
            {
                ErrInfo = new ErrorEntity("MB010010", "人员民族不能为空!");
                return -1;
            }
            string ErrStr = "";
            if (!PublicMethod.IsIdNo(item.FIDNumber.ToLower(), out ErrStr))
            {
                ErrInfo = new ErrorEntity("MB010011", ErrStr);
                return -1;
            }

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FBirthDate", item.FBirthDate.ToString());
            parameters.Add("FDepartmentId", item.FDepartmentId.ToString());
            parameters.Add("FEductionId", item.FEductionId.ToString());
            parameters.Add("FIDNumber", item.FIDNumber);
            parameters.Add("FMemberCode", item.FMemberCode);
            parameters.Add("FMemberGendor", item.FMemberGendor);
            parameters.Add("FMemberName", item.FMemberName);
            parameters.Add("FMobile", item.FMobile);
            parameters.Add("FNationId", item.FNationId.ToString());
            parameters.Add("FPicPath", item.FPicPathStr);
            parameters.Add("FPosition", item.FPosition);
            parameters.Add("FStatus", "1");
            NameValueCollection where = new NameValueCollection();
            where.Add("FMemberId",item.FMemberId.ToString());
            return Update(parameters,where,out ErrInfo);
        }

        public int Update(NameValueCollection parameters, NameValueCollection where, out ErrorEntity ErrInfo)
        {
            SysMemberDA da = new SysMemberDA();
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
            NameValueCollection where = new NameValueCollection();
            where.Add("condition", "FMemberId in (" + idlist + ")");
            return Delete(where, out ErrInfo);
        }

        public int Delete(NameValueCollection where, out ErrorEntity ErrInfo)
        {
            SysMemberDA da = new SysMemberDA();
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
