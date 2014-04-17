using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQOnlineExam.ML;
using System.Web.Script.Serialization;

namespace HQOnlineExam.Biz
{
    public class OEContentClassTreeBiz
    {
        public List<OEContentClassTree> Select()
        {
            OEContentClassBiz biz = new OEContentClassBiz();
            return Select(0,biz.Select());
        }

        public string JsonSelect()
        {
            return ConvertToJson(Select());
        }

        private List<OEContentClassTree> Select(Int64 _parentid, List<OEContentClass> _list)
        {
            List<OEContentClassTree> lists = new List<OEContentClassTree>();
            foreach (OEContentClass item in _list.Where(p => p.FParentId == _parentid))
            {
                OEContentClassTree newitem = new OEContentClassTree();
                newitem.FContentClassId = item.FContentClassId;
                newitem.FContentClassCode = item.FContentClassCode;
                newitem.FContentClassName = item.FContentClassName;
                newitem.FContentClassContent = item.FContentClassContent;
                newitem.FIconPath = item.FIconPath;
                newitem.FParentId = item.FParentId;
                newitem.children = Select(item.FContentClassId, _list);
                lists.Add(newitem);
            }
            return lists;
        }

        public string ConvertToJson(List<OEContentClassTree> lists)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return "{\"total\":" + lists.Count.ToString() + ",\"rows\":" + serializer.Serialize(lists) + "}";
        }

    }
}
