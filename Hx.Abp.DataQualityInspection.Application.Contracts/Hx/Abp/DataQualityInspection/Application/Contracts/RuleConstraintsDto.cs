using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hx.Abp.DataQualityInspection.Application.Contracts
{
    public class RuleConstraintsDto
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 条件名称，用于标识条件。
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// 条件标题，用于描述条件内容。
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// 条件表达式，可以是字符串、数字或布尔值。
        /// </summary>
        public string? Expression { get; set; }
    }
}
