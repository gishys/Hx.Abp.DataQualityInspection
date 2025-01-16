using Volo.Abp.Domain.Entities.Auditing;

namespace Hx.Abp.DataQualityInspection.Domain
{
    /// <summary>
    /// 质量检查规则条件，表示规则的约束条件。
    /// </summary>
    public class QualityInspectionRuleConstraints : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 规则Id
        /// </summary>
        public Guid RuleId { get;private set; }
        /// <summary>
        /// 条件名称，用于标识条件。
        /// </summary>
        public string Name { get;private set; }

        /// <summary>
        /// 条件标题，用于描述条件内容。
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// 条件值，可以是字符串、数字或布尔值。
        /// </summary>
        public object Value { get; private set; }

        /// <summary>
        /// 无参构造函数，用于支持默认初始化。
        /// </summary>
        public QualityInspectionRuleConstraints() { }

        /// <summary>
        /// 带参构造函数，用于初始化 QualityInspectionRuleConstraints 对象。
        /// </summary>
        /// <param name="name">条件名称。</param>
        /// <param name="title">条件标题。</param>
        /// <param name="value">条件值。</param>
        public QualityInspectionRuleConstraints(string name, string title, object value)
        {
            this.Name = name;
            this.Title = title;
            this.Value = value;
        }

        /// <summary>
        /// 设置条件名称。
        /// </summary>
        /// <param name="name">条件名称。</param>
        public void SetName(string name) => this.Name = name;

        /// <summary>
        /// 设置条件标题。
        /// </summary>
        /// <param name="title">条件标题。</param>
        public void SetTitle(string title) => this.Title = title;

        /// <summary>
        /// 设置条件值。
        /// </summary>
        /// <param name="value">条件值。</param>
        public void SetValue(object value) => this.Value = value;
    }
}
