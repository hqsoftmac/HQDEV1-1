using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib;
namespace HQPartyManage.DA
{
    //PmOrgLeader
    public partial class PmOrgLeaderDA : CommonDA
    {
        public PmOrgLeaderDA()
        {
            this._selecttable = "t_pm_orgleader";
            this._inserttable = "t_pm_orgleader";
            this._updatetable = "t_pm_orgleader";
            this._deletetable = "t_pm_orgleader";
        }
    }
}