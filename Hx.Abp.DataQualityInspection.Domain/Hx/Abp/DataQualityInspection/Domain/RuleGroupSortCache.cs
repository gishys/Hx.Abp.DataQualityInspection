using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hx.Abp.DataQualityInspection.Domain
{
    public class RuleGroupSortCache
    {
        public RuleGroupSortCache(Guid? parentId, double sort)
        {
            ParentId = parentId;
            Sort = sort;
        }
        public Guid? ParentId { get; set; }
        public double Sort { get; set; }
    }
}
