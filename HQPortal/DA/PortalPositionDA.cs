using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib;

namespace HQPortal.DA
{
    public class PortalPositionDA:CommonDA
    {
        public PortalPositionDA()
        {
            this._selecttable = "t_portal_position";
            this._inserttable = "t_portal_position";
            this._updatetable = "t_portal_position";
            this._deletetable = "t_portal_position";
        }
    }
}
