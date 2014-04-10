using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib;
namespace HQPartyManage.DA
{
    //PmOrgInfo
    public partial class PmOrgInfoDA : CommonDA
    {
        public PmOrgInfoDA()
        {
            this._selecttable = "t_pm_orginfo";
            this._inserttable = "t_pm_orginfo";
            this._updatetable = "t_pm_orginfo";
            this._deletetable = "t_pm_orginfo";
        }
    }
}