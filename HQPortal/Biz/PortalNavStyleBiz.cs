using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQLib.Common;
using HQPortal.ML;
using System.Collections.Specialized;
using HQPortal.DA;

namespace HQPortal.Biz
{
    public class PortalNavStyleBiz
    {
        public List<PortalNavStyle> Select(NameValueCollection where)
        {
            PortalNavStyleDA da = new PortalNavStyleDA();
            return da.Select(where).DataTableToList<PortalNavStyle>();
        }

        public List<PortalNavStyle> Select(NameValueCollection where, NameValueCollection orderby)
        {
            PortalNavStyleDA da = new PortalNavStyleDA();
            return da.Select(where, orderby).DataTableToList<PortalNavStyle>();
        }

        public List<PortalNavStyle> Select()
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("condition", "1=1");
            NameValueCollection orderby = new NameValueCollection();
            orderby.Add("FNavStyleName", "asc");
            return Select(where, orderby);
        }
    }
}
