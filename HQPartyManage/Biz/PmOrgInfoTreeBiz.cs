using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQPartyManage.ML;
using System.Web.Script.Serialization;

namespace HQPartyManage.Biz
{
    [Serializable]
    public class PmOrgInfoTreeBiz
    {
        public List<PmOrgInfoTree> SelectByDeptId(string _deptid)
        {
            PmOrgInfoBiz biz = new PmOrgInfoBiz();
            List<PmOrgInfo> lists = new List<PmOrgInfo>();
            lists = biz.SelectByDeptId(_deptid);
            return Select(lists);
        }

        public string JsonSelectByDeptId(string _deptid)
        {
            return ConvertToJson(SelectByDeptId(_deptid));
        }
        
        private List<PmOrgInfoTree> Select(List<PmOrgInfo> _list)
        {
            List<PmOrgInfoTree> lists = new List<PmOrgInfoTree>();
            foreach (PmOrgInfo item in _list.Where(p=>p.FParentOrgId == 0))
            {
                PmOrgInfoTree treeitem = new PmOrgInfoTree();
                treeitem.FDepartmentID = item.FDepartmentID;
                treeitem.FOrgId = item.FOrgId;
                treeitem.FOrgName = item.FOrgName;
                treeitem.FOrgNewDate = item.FOrgNewDate;
                treeitem.FOrgOrder = item.FOrgOrder;
                treeitem.FOrgType = item.FOrgType;
                treeitem.FParentOrgId = item.FParentOrgId;
                treeitem.children = SetChildren(item.FOrgId, _list);
                lists.Add(treeitem);
            }
            return lists;
        }

        private List<PmOrgInfoTree> SetChildren(Int64 _parentid, List<PmOrgInfo> _list)
        {
            List<PmOrgInfoTree> lists = new List<PmOrgInfoTree>();
            foreach (PmOrgInfo item in _list.Where(p => p.FParentOrgId == _parentid))
            {
                PmOrgInfoTree treeitem = new PmOrgInfoTree();
                treeitem.FDepartmentID = item.FDepartmentID;
                treeitem.FOrgId = item.FOrgId;
                treeitem.FOrgName = item.FOrgName;
                treeitem.FOrgNewDate = item.FOrgNewDate;
                treeitem.FOrgOrder = item.FOrgOrder;
                treeitem.FOrgType = item.FOrgType;
                treeitem.FParentOrgId = item.FParentOrgId;
                treeitem.children = SetChildren(item.FOrgId, _list);
                lists.Add(treeitem);
            }
            return lists;
        }

        public string ConvertToJson(List<PmOrgInfoTree> lists)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return "{\"total\":" + lists.Count.ToString() + ",\"rows\":" + serializer.Serialize(lists) + "}";
        }
    }
}
