using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib;

namespace HQPortal.DA
{
    public class PortalColumnNavDA :CommonDA
    {
        public PortalColumnNavDA()
        {
            this._selecttable = "t_portal_columnnav";
            this._inserttable = "t_portal_columnnav";
            this._updatetable = "t_portal_columnnav";
            this._deletetable = "t_portal_columnnav";
        }
    }
}
