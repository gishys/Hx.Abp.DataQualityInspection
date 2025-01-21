using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hx.Abp.DataQualityInspection.Domain.Shared
{
    public enum RuleType
    {
        /// <summary>
        /// 属性检查
        /// </summary>
        Attribute,

        /// <summary>
        /// 图形检查
        /// </summary>
        Graphic,
    }
}
