using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib;
namespace HQPartyManage.DA
{
    //党组织成员
    public partial class PmOrgCommitteeDA : CommonDA
    {
        public PmOrgCommitteeDA()
        {
            this._selecttable = "t_pm_orgcommittee";
            this._inserttable = "t_pm_orgcommittee";
            this._updatetable = "t_pm_orgcommittee";
            this._deletetable = "t_pm_orgcommittee";
        }
    }
}