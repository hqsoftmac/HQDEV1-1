using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib;

namespace HQPortal.DA
{
    public class PortalChildColumnDA : CommonDA
    {
        public PortalChildColumnDA()
        {
            this._selecttable = "t_portal_childColumn";
            this._inserttable = "t_portal_childColumn";
            this._updatetable = "t_portal_childColumn";
            this._deletetable = "t_portal_childColumn";
        }
    }
}
