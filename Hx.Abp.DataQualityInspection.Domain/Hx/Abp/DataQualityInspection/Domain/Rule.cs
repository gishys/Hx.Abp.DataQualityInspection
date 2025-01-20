using Hx.Abp.DataQualityInspection.Domain.Shared;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hx.Abp.DataQualityInspection.Domain
{
    /// <summary>
    /// 质量检查规则记录，表示一个质检规则的定义。
    /// </summary>
    public class Rule : FullAuditedEntity<Guid>
    {

        /// <summary>
        /// 规则键值，用于唯一标识规则。
        /// </summary>
        public string RuleName { get; private set; }

        /// <summary>
        /// 规则标题，用于描述规则内容。
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// 规则描述，提供规则的详细信息（可选）。
        /// </summary>
        public string? Description { get; private set; }

        /// <summary>
        /// 标识规则执行结果。
        /// </summary>
        public string? SuccessEvent {  get; private set; }

        /// <summary>
        /// 规则对应的错误级别。
        /// </summary>
        public ErrorType ErrorType { get; private set; }

        /// <summary>
        /// 错误描述。
        /// </summary>
        public string ErrorMessage {  get; private set; }

        /// <summary>
        /// 表达式的类型。
        /// </summary>
        public RuleExpressionType RuleExpressionType { get; private set; }

        /// <summary>
        /// 规则约束条件列表（可选）。
        /// </summary>
        public List<RuleConstraints> Constraints { get; private set; }

        /// <summary>
        /// 表达式。
        /// </summary>
        public string? Expression { get; private set; }

        /// <summary>
        /// 子规则列表，支持规则的嵌套（可选）。
        /// </summary>
        public List<Rule> Children { get; private set; }

        /// <summary>
        /// 无参构造函数，用于支持默认初始化。
        /// </summary>
        public Rule()
        {
            this.Constraints = new List<RuleConstraints>();
            this.Children = new List<Rule>();
        }

        /// <summary>
        /// 带参构造函数，用于初始化 QualityInspectionRule 对象。
        /// </summary>
        /// <param name="id">规则唯一标识符。</param>
        /// <param name="ruleName">规则键值。</param>
        /// <param name="title">规则标题。</param>
        /// <param name="successEvent">标识规则执行结果。</param>
        /// <param name="description">规则描述。</param>
        /// <param name="errorType">规则对应的错误级别。</param>
        /// <param name="errorMessage">错误描述。</param>
        /// <param name="ruleExpressionType">表达式类型。</param>
        /// <param name="expression">表达式。</param>
        public Rule(Guid id, string ruleName, string title, ErrorType errorType, string errorMessage, RuleExpressionType ruleExpressionType, string? expression = null, string? successEvent = null, string? description = null)
        {
            this.Id = id;
            this.RuleName = ruleName;
            this.Title = title;
            this.SuccessEvent = successEvent;
            this.ErrorType = errorType;
            this.Description = description;
            this.ErrorMessage = errorMessage;
            this.RuleExpressionType = ruleExpressionType;
            this.Expression = expression;
            this.Constraints = new List<RuleConstraints>();
            this.Children = new List<Rule>();
        }

        /// <summary>
        /// 设置规则键值。
        /// </summary>
        /// <param name="ruleName">规则键值。</param>
        public void SetKey(string ruleName) => this.RuleName = ruleName;

        /// <summary>
        /// 设置规则标题。
        /// </summary>
        /// <param name="title">规则标题。</param>
        public void SetTitle(string title) => this.Title = title;

        /// <summary>
        /// 设置规则描述。
        /// </summary>
        /// <param name="description">规则描述。</param>
        public void SetDescription(string description) => this.Description = description;

        /// <summary>
        /// 错误描述。
        /// </summary>
        /// <param name="errorMessage"></param>
        public void SetErrorMessage(string errorMessage) => this.ErrorMessage = errorMessage;

        /// <summary>
        /// 标识规则执行结果。
        /// </summary>
        /// <param name="successEvent"></param>
        public void SetSuccessEvent(string successEvent) => this.SuccessEvent = successEvent;

        /// <summary>
        /// 表达式。
        /// </summary>
        /// <param name="expression"></param>
        public void SetExpression(string expression) => this.Expression = expression;

        /// <summary>
        /// 表达式类型。
        /// </summary>
        /// <param name="errorMessage"></param>
        public void SetRuleExpressionType(RuleExpressionType ruleExpressionType) => this.RuleExpressionType = ruleExpressionType;

        /// <summary>
        /// 设置规则对应的错误级别。
        /// </summary>
        /// <param name="errorType">错误级别。</param>
        public void SetErrorType(ErrorType errorType) => this.ErrorType = errorType;

        /// <summary>
        /// 设置规则约束条件列表。
        /// </summary>
        /// <param name="constraints">约束条件列表。</param>
        public void SetConstraints(List<RuleConstraints> constraints) => this.Constraints = constraints;

        /// <summary>
        /// 设置子规则列表。
        /// </summary>
        /// <param name="children">子规则列表。</param>
        public void SetChildren(List<Rule> children) => this.Children = children;
    }
}
