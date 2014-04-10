using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HQLib.Page;
using HQPortal.Biz;
using HQPortal.ML;
using HQLib;

namespace HQDevSys.manage.product
{
    public partial class productcontentadd : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void GetListTitleName()
        {
            string _id = Parameters["plistid"];
            if (string.IsNullOrEmpty(_id) || _id == "0")
            {
                Response.Write("根目录");
            }
            else
            {
                string _titlename = "";
                PortalProductListBiz biz = new PortalProductListBiz();
                biz.GetListName(_id, ref _titlename);
                Response.Write(_titlename);
            }
        }

        public void SaveProduct()
        {
            string _productname = Parameters["pproductname"];
            string _productlist = Parameters["pproductlist"];
            string _productmodule = Parameters["pproductmodule"];
            string _productdesc = Parameters["pproductdesc"];
            string _briefpath = Parameters["pbriefpath"];
            string _path = Parameters["ppath"];
            string _briefcontent = Parameters["pbriefcontent"];
            string _content = Parameters["pcontent"];
            string _seotitle = Parameters["pseotitle"];
            string _seokeyword = Parameters["pseokeyword"];
            string _seodesc = Parameters["pseodesc"];
            PortalProduct item = new PortalProduct();
            item.FProductId = 0;
            item.FProductListID = Convert.ToInt64(_productlist);
            item.FProductName = _productname;
            item.FProductModule = _productmodule;
            item.FProductDesc = _productdesc;
            item.FProductPic = _path;
            item.FBriefPic = _briefpath;
            item.FSEOTitle = _seotitle;
            item.FSEOKeyWord = _seokeyword;
            item.FSEODesc = _seodesc;
            item.FProductBrief = _briefcontent;
            item.FProductContent = _content;
            PortalProductBiz biz = new PortalProductBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            biz.Insert(item, out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }

        public void GetProductList()
        {
            List<PortalProductListTree> lists = new List<PortalProductListTree>();
            List<PortalProductList> lists1 = new List<PortalProductList>();
            PortalProductListBiz biz = new PortalProductListBiz();
            lists1 = biz.Select();
            PortalProductListTreeBiz treebiz = new PortalProductListTreeBiz();
            lists = treebiz.select(lists1);
            PortalProductListTree newitem = new PortalProductListTree();
            newitem.FParentListId = 0;
            newitem.FProductListName = "根目录";
            newitem.FProductListOrder = 10;
            newitem.FParentListId = 0;
            newitem.children = lists;
            List<PortalProductListTree> newlists = new List<PortalProductListTree>();
            newlists.Add(newitem);
            string datasource = treebiz.ConvertToJson(newlists);
            Response.Write(datasource);
        }
    }
}