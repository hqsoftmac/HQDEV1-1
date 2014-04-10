using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQPortal.ML;
using System.Web.Script.Serialization;

namespace HQPortal.Biz
{
    public class PortalProductListTreeBiz
    {
        public List<PortalProductListTree> select(List<PortalProductList> _list)
        {
            List<PortalProductListTree> lists = new List<PortalProductListTree>();
            foreach (PortalProductList item in _list)
            {
                if (item.FParentListId == 0)
                {
                    PortalProductListTree newitem = new PortalProductListTree();
                    newitem.FProductListID = item.FProductListID;
                    newitem.FProductListName = item.FProductListName;
                    newitem.FProductListOrder = item.FProductListOrder;
                    newitem.FParentListId = item.FParentListId;
                    newitem.children = selectchildren(item.FProductListID, _list);
                    lists.Add(newitem);
                }
            }
            return lists;
        }

        private List<PortalProductListTree> selectchildren(Int64 listid, List<PortalProductList> _list)
        {
            List<PortalProductListTree> lists = new List<PortalProductListTree>();
            foreach (PortalProductList item in _list)
            {
                if (item.FParentListId == listid)
                {
                    PortalProductListTree newitem = new PortalProductListTree();
                    newitem.FProductListID = item.FProductListID;
                    newitem.FProductListName = item.FProductListName;
                    newitem.FProductListOrder = item.FProductListOrder;
                    newitem.FParentListId = item.FParentListId;
                    newitem.children = selectchildren(item.FProductListID, _list);
                    lists.Add(newitem);
                }
            }
            return lists;
        }

        public string ConvertToJson(List<PortalProductListTree> lists)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return "{\"total\":" + lists.Count.ToString() + ",\"rows\":" + serializer.Serialize(lists) + "}";
        }
    }
}
