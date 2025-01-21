using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hx.Abp.DataQualityInspection.Application.Contracts
{
    public class RuleGroupCreateDto : RuleGroupCreateOrUpdateDtoBase
    {
        /// <summary>
        /// 父Id
        /// </summary>
        public Guid? ParentId { get; set; }
    }
}
