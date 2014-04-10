using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib;

namespace HQPortal.DA
{
    public class PortalArticleDA : CommonDA
    {
        public PortalArticleDA()
        {
            this._selecttable = "t_portal_article";
            this._inserttable = "t_portal_article";
            this._updatetable = "t_portal_article";
            this._deletetable = "t_portal_article";
        }
    }
}
