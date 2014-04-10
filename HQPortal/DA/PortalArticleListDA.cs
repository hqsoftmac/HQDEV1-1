using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib;

namespace HQPortal.DA
{
    public class PortalArticleListDA:CommonDA
    {
        public PortalArticleListDA()
        {
            this._selecttable = "t_portal_articlelist";
            this._inserttable = "t_portal_articlelist";
            this._updatetable = "t_portal_articlelist";
            this._deletetable = "t_portal_articlelist";
        }
    }
}
