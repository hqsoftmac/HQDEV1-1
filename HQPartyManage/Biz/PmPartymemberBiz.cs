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
    //v_pm_partymember
    public partial class PmPartymemberBiz
    {
        public List<PmPartymember> Select(NameValueCollection where)
        {
            PmPartymemberDA da = new PmPartymemberDA();
            return da.Select(where).DataTableToList<PmPartymember>();
        }

        public List<PmPartymember> Select(NameValueCollection where, NameValueCollection orderby)
        {
            PmPartymemberDA da = new PmPartymemberDA();
            return da.Select(where, orderby).DataTableToList<PmPartymember>();
        }

        public List<PmPartymember> Select(NameValueCollection where, NameValueCollection orderby, int pageIndex, int pageSize, out int totalCount)
        {
            PmPartymemberDA da = new PmPartymemberDA();
            return da.Select(where, orderby, pageIndex, pageSize, out totalCount).DataTableToList<PmPartymember>();
        }

        public int UpdatePreParty(string _memberid, string _status, string _date, string _orgid, out ErrorEntity ErrInfo)
        {
            NameValueCollection parameters = new NameValueCollection();
            if (_status == "1")
            {
                parameters.Add("FPrePartyDate", _date);
            }
            parameters.Add("FPrePartyFlag", _status);
            if (!string.IsNullOrEmpty(_orgid))
            {
                parameters.Add("FOrgId", _orgid);
            }
            NameValueCollection where = new NameValueCollection();
            where.Add("FMemberId", _memberid);
            return Update(parameters, where, out ErrInfo);
        }

        public int UpdateObject(string _memberid, string _status, string _date, string _orgid, out ErrorEntity ErrInfo)
        {
            NameValueCollection parameters = new NameValueCollection();
            if (_status == "1")
            {
                parameters.Add("FObjectDate", _date);
            }
            parameters.Add("FObjectFlag", _status);
            if (!string.IsNullOrEmpty(_orgid))
            {
                parameters.Add("FOrgId", _orgid);
            }
            NameValueCollection where = new NameValueCollection();
            where.Add("FMemberId", _memberid);
            return Update(parameters, where, out ErrInfo);
        }

        public int UpdateActivist(string _memberid, string _status, string _date,string _orgid, out ErrorEntity ErrInfo)
        {
            NameValueCollection parameters = new NameValueCollection();
            if (_status == "1")
            {
                parameters.Add("FActivistDate", _date);
            }
            parameters.Add("FActivistFlag", _status);
            if (!string.IsNullOrEmpty(_orgid))
            {
                parameters.Add("FOrgId", _orgid);
            }
            NameValueCollection where = new NameValueCollection();
            where.Add("FMemberId", _memberid);
            return Update(parameters, where, out ErrInfo);
        }

        public int Update(NameValueCollection parameters, NameValueCollection where, out ErrorEntity ErrInfo)
        {
            PmPartymemberDA da = new PmPartymemberDA();
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

    }
}