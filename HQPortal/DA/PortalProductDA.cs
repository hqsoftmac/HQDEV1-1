using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib;

namespace HQPortal.DA
{
    public class PortalProductDA :CommonDA
    {
        public PortalProductDA()
        {
            this._selecttable = "t_portal_product";
            this._inserttable = "t_portal_product";
            this._updatetable = "t_portal_product";
            this._deletetable = "t_portal_product";
        }
    }
}
