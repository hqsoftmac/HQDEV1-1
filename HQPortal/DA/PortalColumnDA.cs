using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib;

namespace HQPortal.DA
{
    public class PortalColumnDA :CommonDA
    {
        public PortalColumnDA()
        {
            this._selecttable = "t_portal_column";
            this._inserttable = "t_portal_column";
            this._updatetable = "t_portal_column";
            this._deletetable = "t_portal_column";
        }
    }
}
