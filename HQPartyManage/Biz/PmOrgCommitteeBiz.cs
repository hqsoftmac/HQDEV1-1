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
    //党组织成员
    public partial class PmOrgCommitteeBiz
    {
        /// <summary>
        /// 获取组织下的所有成员
        /// </summary>
        /// <param name="_orgid">组织ID</param>
        /// <returns></returns>
        public List<PmOrgCommittee> SelectByOrg(string _orgid)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("FOrgId", _orgid);
            NameValueCollection orderby = new NameValueCollection();
            orderby.Add("FCommitteeOrder", "asc");
            return Select(where,orderby);
        }

        /// <summary>
        /// 获取PmOrgCommittee
        /// </summary>
        /// <param name="_id">OrgCommittee's ID</param>
        /// <returns></returns>
        public PmOrgCommittee Select(string _id)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("FCommitteeID", _id);
            List<PmOrgCommittee> lists = new List<PmOrgCommittee>();
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

        public List<PmOrgCommittee> Select(NameValueCollection where)
        {
            PmOrgCommitteeDA da = new PmOrgCommitteeDA();
            return da.Select(where).DataTableToList<PmOrgCommittee>();
        }

        public List<PmOrgCommittee> Select(NameValueCollection where, NameValueCollection orderby)
        {
            PmOrgCommitteeDA da = new PmOrgCommitteeDA();
            return da.Select(where, orderby).DataTableToList<PmOrgCommittee>();
        }

        public List<PmOrgCommittee> Select(NameValueCollection where, NameValueCollection orderby, int pageIndex, int pageSize, out int totalCount)
        {
            PmOrgCommitteeDA da = new PmOrgCommitteeDA();
            return da.Select(where, orderby, pageIndex, pageSize, out totalCount).DataTableToList<PmOrgCommittee>();
        }

        public Int64 Insert(PmOrgCommittee item, out ErrorEntity ErrInfo)
        {
            if (item.FOrgId == 0)
            {
                ErrInfo = new ErrorEntity("PC010001", "所属组织不能为空!");
                return -1;
            }
            if (string.IsNullOrEmpty(item.FCommitteeName))
            {
                ErrInfo = new ErrorEntity("PC010002", "组织成员不能为空!");
                return -1;
            }
            if (string.IsNullOrEmpty(item.FCommitteePosition))
            {
                ErrInfo = new ErrorEntity("PC010003", "成员职务不能为空!");
                return -1;
            }
            if (string.IsNullOrEmpty(item.FCommitteeMobile))
            {
                ErrInfo = new ErrorEntity("PC010004", "移动电话不能为空!");
                return -1;
            }
            if(item.FCommitteeOrder == 0)
            {
                ErrInfo = new ErrorEntity("PC010005", "组织成员顺序不能为空!");
                return -1;
            }
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FOrgId",item.FOrgId.ToString());
            parameters.Add("FCommitteeName",item.FCommitteeName);
            parameters.Add("FCommitteePosition",item.FCommitteePosition);
            parameters.Add("FCommitteeMobile",item.FCommitteeMobile);
            parameters.Add("FCommitteeTel",item.FCommitteeTel);
            parameters.Add("FCommitteeOrder",item.FCommitteeOrder.ToString());
            return Insert(parameters,out ErrInfo);

        }


        public Int64 Insert(NameValueCollection parameters, out ErrorEntity ErrInfo)
        {
            PmOrgCommitteeDA da = new PmOrgCommitteeDA();
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

        public int Update(PmOrgCommittee item, out ErrorEntity ErrInfo)
        {
            if (item.FOrgId == 0)
            {
                ErrInfo = new ErrorEntity("PC010001", "所属组织不能为空!");
                return -1;
            }
            if (string.IsNullOrEmpty(item.FCommitteeName))
            {
                ErrInfo = new ErrorEntity("PC010002", "组织成员不能为空!");
                return -1;
            }
            if (string.IsNullOrEmpty(item.FCommitteePosition))
            {
                ErrInfo = new ErrorEntity("PC010003", "成员职务不能为空!");
                return -1;
            }
            if (string.IsNullOrEmpty(item.FCommitteeMobile))
            {
                ErrInfo = new ErrorEntity("PC010004", "移动电话不能为空!");
                return -1;
            }
            if(item.FCommitteeOrder == 0)
            {
                ErrInfo = new ErrorEntity("PC010005", "组织成员顺序不能为空!");
                return -1;
            }
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FOrgId",item.FOrgId.ToString());
            parameters.Add("FCommitteeName",item.FCommitteeName);
            parameters.Add("FCommitteePosition",item.FCommitteePosition);
            parameters.Add("FCommitteeMobile",item.FCommitteeMobile);
            parameters.Add("FCommitteeTel",item.FCommitteeTel);
            parameters.Add("FCommitteeOrder",item.FCommitteeOrder.ToString());
            NameValueCollection where = new NameValueCollection();
            where.Add("FCommitteeID",item.FCommitteeID.ToString());
            return Update(parameters,where,out ErrInfo);
        }

        public int Update(NameValueCollection parameters, NameValueCollection where, out ErrorEntity ErrInfo)
        {
            PmOrgCommitteeDA da = new PmOrgCommitteeDA();
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
            where.Add("condition", "FCommitteeID in (" + idlist + ")");
            return Delete(where, out ErrInfo);
        }
        
        public int Delete(NameValueCollection where, out ErrorEntity ErrInfo)
        {
            PmOrgCommitteeDA da = new PmOrgCommitteeDA();
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