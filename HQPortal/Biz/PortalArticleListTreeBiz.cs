using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQPortal.ML;
using System.Web.Script.Serialization;

namespace HQPortal.Biz
{
    [Serializable]
    public class PortalArticleListTreeBiz
    {
        public List<PortalArticleListTree> select(List<PortalArticleList> _list)
        {
            List<PortalArticleListTree> lists = new List<PortalArticleListTree>();
            foreach (PortalArticleList item in _list)
            {
                if (item.FParentListId == 0)
                {
                    PortalArticleListTree newitem = new PortalArticleListTree();
                    newitem.FListId = item.FListId;
                    newitem.FListCode = item.FListCode;
                    newitem.FListName = item.FListName;
                    newitem.FListOrder = item.FListOrder;
                    newitem.FParentListId = item.FParentListId;
                    newitem.children = selectchildren(item.FListId, _list);
                    lists.Add(newitem);
                }
            }
            return lists;
        }

        private List<PortalArticleListTree> selectchildren(Int64 listid, List<PortalArticleList> _list)
        {
            List<PortalArticleListTree> lists = new List<PortalArticleListTree>();
            foreach (PortalArticleList item in _list)
            {
                if (item.FParentListId == listid)
                {
                    PortalArticleListTree newitem = new PortalArticleListTree();
                    newitem.FListId = item.FListId;
                    newitem.FListCode = item.FListCode;
                    newitem.FListName = item.FListName;
                    newitem.FListOrder = item.FListOrder;
                    newitem.FParentListId = item.FParentListId;
                    newitem.children = selectchildren(item.FListId, _list);
                    lists.Add(newitem);
                }
            }
            return lists;
        }

        public string ConvertToJson(List<PortalArticleListTree> lists)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return "{\"total\":" + lists.Count.ToString() + ",\"rows\":" + serializer.Serialize(lists) + "}";
        }
    }
}
