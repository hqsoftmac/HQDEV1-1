using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQOnlineExam.ML;
using HQLib.Common;
using System.Collections.Specialized;
using HQOnlineExam.DA;
using HQLib;
using HQConst.Const;

namespace HQOnlineExam.Biz
{
    public class OEContentClassBiz
    {

        public List<OEContentClass> Select(NameValueCollection where)
        {
            OEContentClassDA da = new OEContentClassDA();
            return da.Select(where).DataTableToList<OEContentClass>();
        }

        public List<OEContentClass> Select(NameValueCollection where, NameValueCollection orderby)
        {
            OEContentClassDA da = new OEContentClassDA();
            return da.Select(where, orderby).DataTableToList<OEContentClass>();
        }
    }
}
