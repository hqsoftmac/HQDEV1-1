using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib;

namespace HQPortal.DA
{
    public class PortalNavStyleDA : CommonDA
    {
        public PortalNavStyleDA()
        {
            this._selecttable = "t_portal_navstyle";
            this._inserttable = "t_portal_navstyle";
            this._updatetable = "t_portal_navstyle";
            this._deletetable = "t_portal_navstyle";
        }
    }
}
