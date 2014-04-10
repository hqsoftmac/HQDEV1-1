using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib;

namespace HQPortal.DA
{
    public class PortalProductListDA:CommonDA
    {
        public PortalProductListDA()
        {
            this._selecttable = "t_portal_pruductlist";
            this._inserttable = "t_portal_pruductlist";
            this._updatetable = "t_portal_pruductlist";
            this._deletetable = "t_portal_pruductlist";
        }
    }
}
