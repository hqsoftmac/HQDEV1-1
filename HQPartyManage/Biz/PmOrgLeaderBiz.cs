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
    //PmOrgLeader
    public partial class PmOrgLeaderBiz
    {
        public PmOrgLeader Select(string _id)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("FLeaderId", _id);
            List<PmOrgLeader> lists = new List<PmOrgLeader>();
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

        public List<PmOrgLeader> Select(NameValueCollection where)
        {
            PmOrgLeaderDA da = new PmOrgLeaderDA();
            return da.Select(where).DataTableToList<PmOrgLeader>();
        }

        public List<PmOrgLeader> Select(NameValueCollection where, NameValueCollection orderby)
        {
            PmOrgLeaderDA da = new PmOrgLeaderDA();
            return da.Select(where, orderby).DataTableToList<PmOrgLeader>();
        }

        public List<PmOrgLeader> Select(NameValueCollection where, NameValueCollection orderby, int pageIndex, int pageSize, out int totalCount)
        {
            PmOrgLeaderDA da = new PmOrgLeaderDA();
            return da.Select(where, orderby, pageIndex, pageSize, out totalCount).DataTableToList<PmOrgLeader>();
        }

        public Int64 Insert(PmOrgLeader item, out ErrorEntity ErrInfo)
        {
            if (string.IsNullOrEmpty(item.FLeaderName))
            {
                ErrInfo = new ErrorEntity("PL010001", "领导姓名不能为空!");
                return -1;
            }
            if(string.IsNullOrEmpty(item.FLeaderPostion))
            {
                ErrInfo = new ErrorEntity("PL010002","领导职务不能为空!");
                return -1;
            }
            if (item.FLeaderOrder == 0)
            {
                ErrInfo = new ErrorEntity("PL010003", "领导显示顺序不能为空!");
                return -1;
            }

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FOrgId", item.FOrgId.ToString());
            parameters.Add("FLeaderName", item.FLeaderName);
            parameters.Add("FLeaderPostion", item.FLeaderPostion);
            parameters.Add("FLeaderOrder", item.FLeaderOrder.ToString());
            return Insert(parameters, out ErrInfo);
        }

        public Int64 Insert(NameValueCollection parameters, out ErrorEntity ErrInfo)
        {
            PmOrgLeaderDA da = new PmOrgLeaderDA();
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

        public int Update(PmOrgLeader item, out ErrorEntity ErrInfo)
        {
            if (string.IsNullOrEmpty(item.FLeaderName))
            {
                ErrInfo = new ErrorEntity("PL010001", "领导姓名不能为空!");
                return -1;
            }
            if (string.IsNullOrEmpty(item.FLeaderPostion))
            {
                ErrInfo = new ErrorEntity("PL010002", "领导职务不能为空!");
                return -1;
            }
            if (item.FLeaderOrder == 0)
            {
                ErrInfo = new ErrorEntity("PL010003", "领导显示顺序不能为空!");
                return -1;
            }
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FOrgId", item.FOrgId.ToString());
            parameters.Add("FLeaderName", item.FLeaderName);
            parameters.Add("FLeaderPostion", item.FLeaderPostion);
            parameters.Add("FLeaderOrder", item.FLeaderOrder.ToString());
            NameValueCollection where = new NameValueCollection();
            where.Add("FLeaderId", item.FLeaderId.ToString());
            return Update(parameters, where, out ErrInfo);
        }

        public int Update(NameValueCollection parameters, NameValueCollection where, out ErrorEntity ErrInfo)
        {
            PmOrgLeaderDA da = new PmOrgLeaderDA();
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
            where.Add("condition", "FLeaderId in (" + idlist + ")");
            return Delete(where, out ErrInfo);
        }

        public int Delete(NameValueCollection where, out ErrorEntity ErrInfo)
        {
            PmOrgLeaderDA da = new PmOrgLeaderDA();
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