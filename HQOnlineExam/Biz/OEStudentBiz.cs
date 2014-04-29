using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQOnlineExam.ML;
using HQLib.Common;
using System.Collections.Specialized;
using HQOnlineExam.DA;
using HQLib;
using HQConst.Const;
using HQLib.Util;
namespace HQOnlineExam.Biz
{
    //OEStudent
    public partial class OEStudentBiz
    {

        public OEStudent Select(string _id)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("FStudentId", _id);
            List<OEStudent> lists = new List<OEStudent>();
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
        
        public List<OEStudent> Select(NameValueCollection where)
        {
            OEStudentDA da = new OEStudentDA();
            return da.Select(where).DataTableToList<OEStudent>();
        }

        public List<OEStudent> Select(NameValueCollection where, NameValueCollection orderby)
        {
            OEStudentDA da = new OEStudentDA();
            return da.Select(where, orderby).DataTableToList<OEStudent>();
        }

        public List<OEStudent> Select(NameValueCollection where, NameValueCollection orderby, int pageIndex, int pageSize, out int totalCount)
        {
            OEStudentDA da = new OEStudentDA();
            return da.Select(where, orderby, pageIndex, pageSize, out totalCount).DataTableToList<OEStudent>();
        }

        public Int32 Insert(NameValueCollection parameters, out ErrorEntity ErrInfo)
        {
            OEStudentDA da = new OEStudentDA();
            Int32 result = da.Insert(parameters);
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

        public Boolean ChkIDDuplicate(string IDstr)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("FStudentIDNumber", IDstr);
            if (Select(where).Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Int32 Insert(OEStudent item, out ErrorEntity ErrInfo)
        {
            //Error Judge Define
            if (string.IsNullOrEmpty(item.FStudentName))
            {
                ErrInfo = new ErrorEntity("ST010001", "学员姓名不能为空!");
                return -1;
            }
            
            if (string.IsNullOrEmpty(item.FStudentIDNumber))
            {
                ErrInfo = new ErrorEntity("ST010002", "学员身份证号码不能为空!");
                return -1;
            }

            if (!ChkIDDuplicate(item.FStudentIDNumber))
            {
                ErrInfo = new ErrorEntity("ST010003", "学员身份证已经存在,不能新增!");
                return -1;
            }

            if (string.IsNullOrEmpty(item.FStudentPSW))
            {
                item.FStudentPSW = Utils.Md5Sign("123456");
            }
            if (!string.IsNullOrEmpty(item.FEmail))
            {
                if (!PublicMethod.IsEmail(item.FEmail))
                {
                    ErrInfo = new ErrorEntity("ST010003", "请正确输入邮件地址!");
                    return -1;
                }
            }
            if (!string.IsNullOrEmpty(item.FMobile))
            {
                if (!PublicMethod.IsMobile(item.FMobile))
                {
                    ErrInfo = new ErrorEntity("ST010004", "请正确输入手机号码!");
                    return -1;
                }
            }
            string errstr = "";
            if (!PublicMethod.IsIdNo(item.FStudentIDNumber,out  errstr))
            {
                ErrInfo = new ErrorEntity("ST010005", "请正确输入身份证号码!");
                return -1;
            }
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FStudentName", item.FStudentName);
            parameters.Add("FStudentIDNumber", item.FStudentIDNumber);
            parameters.Add("FEmail", item.FEmail);
            parameters.Add("FMobile", item.FMobile);
            parameters.Add("FStudentPSW", item.FStudentPSW);
            return Insert(parameters, out ErrInfo);
        }

        public int ResetPsw(string _userid, out ErrorEntity ErrInfo)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("FStudentId", _userid);
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FStudentPSW", Utils.Md5Sign("123456"));
            return Update(parameters, where, out ErrInfo);

        }

        public int Update(NameValueCollection parameters, NameValueCollection where, out ErrorEntity ErrInfo)
        {
            OEStudentDA da = new OEStudentDA();
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

        public Int32 Update(OEStudent item, out ErrorEntity ErrInfo)
        {
            //Error Judge Define
            if (string.IsNullOrEmpty(item.FStudentName))
            {
                ErrInfo = new ErrorEntity("ST010001", "学员姓名不能为空!");
                return -1;
            }

            if (string.IsNullOrEmpty(item.FStudentIDNumber))
            {
                ErrInfo = new ErrorEntity("ST010002", "学员身份证号码不能为空!");
                return -1;
            }

            if (!string.IsNullOrEmpty(item.FEmail))
            {
                if (!PublicMethod.IsEmail(item.FEmail))
                {
                    ErrInfo = new ErrorEntity("ST010003", "请正确输入邮件地址!");
                    return -1;
                }
            }
            if (!string.IsNullOrEmpty(item.FMobile))
            {
                if (!PublicMethod.IsMobile(item.FMobile))
                {
                    ErrInfo = new ErrorEntity("ST010004", "请正确输入手机号码!");
                    return -1;
                }
            }
            string errstr = "";
            if (!PublicMethod.IsIdNo(item.FStudentIDNumber, out  errstr))
            {
                ErrInfo = new ErrorEntity("ST010005", "请正确输入身份证号码!");
                return -1;
            }
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FStudentName", item.FStudentName);
            parameters.Add("FStudentIDNumber", item.FStudentIDNumber);
            parameters.Add("FEmail", item.FEmail);
            parameters.Add("FMobile", item.FMobile);
            NameValueCollection where = new NameValueCollection();
            where.Add("FStudentId", item.FStudentId.ToString());
            return Update(parameters, where, out ErrInfo);
        }

        public int UpdateStatus(string id, string flag, out ErrorEntity ErrInfo)
        {
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FStatus", flag);
            NameValueCollection where = new NameValueCollection();
            where.Add("FStudentId", id);
            return Update(parameters, where, out ErrInfo);

        }

        public int Delete(string idlist, out ErrorEntity ErrInfo)
        {
            NameValueCollection where = new NameValueCollection();
            idlist = idlist.Replace(",", "','");
            where.Add("condition", "FStudentId in ('" + idlist + "')");
            return Delete(where, out ErrInfo);
        }

        public int Delete(NameValueCollection where, out ErrorEntity ErrInfo)
        {
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FStatus", "0");
            return Update(parameters, where, out ErrInfo);
        }

    }
}