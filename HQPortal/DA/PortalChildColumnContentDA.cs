using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib;

namespace HQPortal.DA
{
    public class PortalChildColumnContentDA:CommonDA
    {
        public PortalChildColumnContentDA()
        {
            this._selecttable = "t_portal_childcolumncontent";
            this._inserttable = "t_portal_childcolumncontent";
            this._updatetable = "t_portal_childcolumncontent";
            this._deletetable = "t_portal_childcolumncontent";
        }
    }
}
