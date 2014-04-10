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
    public partial class positionedit : PageBase
    {
        protected string positionname = string.Empty;
        protected string positiondept = string.Empty;
        protected string positiontype = string.Empty;
        protected string positiongendor = string.Empty;
        protected string positionnum = "0";
        protected string positionbegindate = string.Empty;
        protected string positionenddate = string.Empty;
        protected string bakcontent = string.Empty;
        protected string content = string.Empty;
        protected string order = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            string positionid = Parameters["id"];
            PortalPosition item = new PortalPosition();
            PortalPositionBiz biz = new PortalPositionBiz();
            item = biz.Select(positionid);
            if (item != null)
            {
                positionname = item.FPositionName;
                positiondept = item.FPositionDept;
                positiontype = item.FPositionType;
                positionnum = item.FPositionNum.ToString();
                positionbegindate = item.FBeginDateStr;
                positionenddate = item.FEndDateStr;
                bakcontent = item.FBackContent;
                content = item.FPositionContent;
                order = item.FPositionOrder.ToString();

            }
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
            string positionid = Parameters["id"];
            PortalPosition item = new PortalPosition();
            PortalPositionBiz biz = new PortalPositionBiz();
            item.FPositionId = Convert.ToInt64(positionid);
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
            biz.Update(item, out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }
    }
}