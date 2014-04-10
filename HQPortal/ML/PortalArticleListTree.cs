using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HQPortal.ML
{
    [Serializable]
    public class PortalArticleListTree
    {
        public Int64 FListId { get; set; }

        public string FListCode { get; set; }

        public string FListName { get; set; }

        public Int64 FParentListId { get; set; }

        public Int32 FListOrder { get; set; }

        public List<PortalArticleListTree> children { get; set; }

        public PortalArticleListTree()
        {

        }
    }
}
