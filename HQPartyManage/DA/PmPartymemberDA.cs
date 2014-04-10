using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib;
namespace HQPartyManage.DA
{
    //v_pm_partymember
    public partial class PmPartymemberDA : CommonDA
    {
        public PmPartymemberDA()
        {
            this._selecttable = "v_pm_partymember";
            this._inserttable = "t_pm_partymember";
            this._updatetable = "t_pm_partymember";
            this._deletetable = "t_pm_partymember";
        }
    }
}