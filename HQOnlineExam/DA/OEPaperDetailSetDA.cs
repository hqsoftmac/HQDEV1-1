using System;
using HQLib;

namespace HQOnlineExam.DA
{
    public partial class OEPaperDetailSetDA : CommonDA
    {
        public OEPaperDetailSetDA()
        {
            this._selecttable = "v_oe_paperdetailset";
            this._inserttable = "t_oe_paperdetailset";
            this._updatetable = "t_oe_paperdetailset";
            this._deletetable = "t_oe_paperdetailset";
        }
    }
}
