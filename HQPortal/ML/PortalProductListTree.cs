using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HQPortal.ML
{
    [Serializable]
    public class PortalProductListTree
    {
        public Int64 FProductListID { get; set; }

        public string FProductListName { get; set; }

        public Int64 FParentListId { get; set; }

        public Int32 FProductListOrder { get; set; }

        public List<PortalProductListTree> children { get; set; }

        public PortalProductListTree()
        {

        }
    }
}
