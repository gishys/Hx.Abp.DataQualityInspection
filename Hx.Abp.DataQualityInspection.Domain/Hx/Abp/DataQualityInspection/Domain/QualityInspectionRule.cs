using Hx.Abp.DataQualityInspection.Domain.Shared;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hx.Abp.DataQualityInspection.Domain
{
    /// <summary>
    /// 质量检查规则记录，表示一个质检规则的定义。
    /// </summary>
    public class QualityInspectionRule : FullAuditedEntity<Guid>
    {

        /// <summary>
        /// 规则键值，用于唯一标识规则。
        /// </summary>
        public string Key { get; private set; }

        /// <summary>
        /// 规则标题，用于描述规则内容。
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// 规则描述，提供规则的详细信息（可选）。
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// 规则对应的错误级别。
        /// </summary>
        public ErrorLevel ErrorLevel { get; private set; }

        /// <summary>
        /// 规则约束条件列表（可选）。
        /// </summary>
        public List<QualityInspectionRuleConstraints> Constraints { get; private set; }

        /// <summary>
        /// 子规则列表，支持规则的嵌套（可选）。
        /// </summary>
        public List<QualityInspectionRule> Children { get; private set; }

        /// <summary>
        /// 无参构造函数，用于支持默认初始化。
        /// </summary>
        public QualityInspectionRule()
        {
            this.Constraints = new List<QualityInspectionRuleConstraints>();
            this.Children = new List<QualityInspectionRule>();
        }

        /// <summary>
        /// 带参构造函数，用于初始化 QualityInspectionRule 对象。
        /// </summary>
        /// <param name="id">规则唯一标识符。</param>
        /// <param name="key">规则键值。</param>
        /// <param name="title">规则标题。</param>
        /// <param name="description">规则描述。</param>
        /// <param name="errorLevel">规则对应的错误级别。</param>
        public QualityInspectionRule(string id, string key, string title, string description, ErrorLevel errorLevel)
        {
            this.Key = key;
            this.Title = title;
            this.ErrorLevel = errorLevel;
            this.Description = description;
            this.Constraints = new List<QualityInspectionRuleConstraints>();
            this.Children = new List<QualityInspectionRule>();
        }

        /// <summary>
        /// 设置规则键值。
        /// </summary>
        /// <param name="key">规则键值。</param>
        public void SetKey(string key) => this.Key = key;

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
        /// 设置规则对应的错误级别。
        /// </summary>
        /// <param name="errorLevel">错误级别。</param>
        public void SetErrorLevel(ErrorLevel errorLevel) => this.ErrorLevel = errorLevel;

        /// <summary>
        /// 设置规则约束条件列表。
        /// </summary>
        /// <param name="constraints">约束条件列表。</param>
        public void SetConstraints(List<QualityInspectionRuleConstraints> constraints) => this.Constraints = constraints;

        /// <summary>
        /// 设置子规则列表。
        /// </summary>
        /// <param name="children">子规则列表。</param>
        public void SetChildren(List<QualityInspectionRule> children) => this.Children = children;
    }
}
