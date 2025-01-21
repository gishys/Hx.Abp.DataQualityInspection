using Hx.Abp.DataQualityInspection.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hx.Abp.DataQualityInspection.Application.Contracts
{
    public class RuleDto
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 规则键值，用于唯一标识规则。
        /// </summary>
        public required string RuleName { get; set; }

        /// <summary>
        /// 规则标题，用于描述规则内容。
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// 规则类型。
        /// </summary>
        public required RuleType RuleType { get; set; }

        /// <summary>
        /// 规则描述，提供规则的详细信息（可选）。
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// 标识规则执行结果。
        /// </summary>
        public string? SuccessEvent { get; set; }

        /// <summary>
        /// 规则对应的错误级别。
        /// </summary>
        public required ErrorType ErrorType { get; set; }

        /// <summary>
        /// 错误描述。
        /// </summary>
        public required string ErrorMessage { get; set; }

        /// <summary>
        /// 表达式的类型。
        /// </summary>
        public required RuleExpressionType RuleExpressionType { get; set; }

        /// <summary>
        /// 表达式。
        /// </summary>
        public required string Expression { get; set; }

        /// <summary>
        /// 规则约束条件列表（可选）。
        /// </summary>
        public List<RuleConstraintsDto>? Constraints { get; set; }
    }
}
