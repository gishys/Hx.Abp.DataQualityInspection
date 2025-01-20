using Volo.Abp.Domain.Entities;

namespace Hx.Abp.DataQualityInspection.Domain
{
    /// <summary>
    /// 质量检查规则条件，表示规则的约束条件或参数。
    /// </summary>
    public class RuleConstraints : Entity<Guid>
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
        /// 条件表达式，可以是字符串、数字或布尔值。
        /// </summary>
        public string? Expression { get; private set; }

        /// <summary>
        /// 无参构造函数，用于支持默认初始化。
        /// </summary>
        public RuleConstraints() { }

        /// <summary>
        /// 带参构造函数，用于初始化 QualityInspectionRuleConstraints 对象。
        /// </summary>
        /// <param name="id">规则唯一标识符。</param>
        /// <param name="name">条件名称。</param>
        /// <param name="title">条件标题。</param>
        /// <param name="expression">条件表达式。</param>
        public RuleConstraints(Guid id,string name, string title, string? expression)
        {
            this.Id = id;
            this.Name = name;
            this.Title = title;
            this.Expression = expression;
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
        /// 设置条件表达式。
        /// </summary>
        /// <param name="expression">条件表达式。</param>
        public void SetValue(string? expression) => this.Expression = expression;
    }
}
