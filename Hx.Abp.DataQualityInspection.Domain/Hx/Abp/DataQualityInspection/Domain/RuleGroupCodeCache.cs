using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hx.Abp.DataQualityInspection.Domain
{
    public class RuleGroupCodeCache
    {
        public Guid? ParentId { get; set; }
        public string Code { get; set; }
        public RuleGroupCodeCache(Guid? parentId, string code)
        {
            ParentId = parentId;
            Code = code;
        }
    }
}
