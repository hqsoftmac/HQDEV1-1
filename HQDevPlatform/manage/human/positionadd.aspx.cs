using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HQLib.Page;
using HQPortal.ML;
using HQPortal.Biz;
using HQLib;

namespace HQDevSys.manage.human
{
    public partial class positionadd : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void SaveItem()
        {
            string _positionname = Parameters["ppositionname"];
            string _positiondept = Parameters["ppositiondept"];
            string _positiontype = Parameters["ppositiontype"];
            string _positiongendor = Parameters["ppositiongendor"];
            string _positionnumber = Parameters["ppositionnumber"];
            string _positionbegindate = Parameters["pbegindate"];
            string _positionenddate = Parameters["penddate"];
            string _backcontent = Parameters["pbackcontent"];
            string _content = Parameters["pcontent"];
            string _order = Parameters["porder"];
            PortalPosition item = new PortalPosition();
            PortalPositionBiz biz = new PortalPositionBiz();
            item.FPositionName = _positionname;
            item.FPositionDept = _positiondept;
            item.FPositionType = _positiontype;
            item.FPositionGendor = _positiongendor;
            item.FPositionNum = Convert.ToInt32(_positionnumber);
            item.FBeginDate = Convert.ToDateTime(_positionbegindate);
            item.FEndDate = Convert.ToDateTime(_positionenddate);
            item.FBackContent = _backcontent;
            item.FPositionContent = _content;
            item.FPositionOrder = Convert.ToInt32(_order);
            ErrorEntity ErrInfo = new ErrorEntity();
            biz.Insert(item, out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }

    }
}