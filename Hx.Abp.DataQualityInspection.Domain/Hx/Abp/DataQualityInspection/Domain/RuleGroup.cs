using Volo.Abp.Domain.Entities.Auditing;

namespace Hx.Abp.DataQualityInspection.Domain
{
    /// <summary>
    /// 规则组
    /// </summary>
    public class RuleGroup : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 分组标题
        /// </summary>
        public string Title { get; protected set; }
        /// <summary>
        /// 路径枚举
        /// </summary>
        public string Code { get; protected set; }
        /// <summary>
        /// 分组排序
        /// </summary>
        public int Order { get; protected set; }
        /// <summary>
        /// 父Id
        /// </summary>
        public Guid ParentId { get; protected set; }
        /// <summary>
        /// 分组描述
        /// </summary>
        public string? Description { get; protected set; }
        /// <summary>
        /// 子组
        /// </summary>
        public List<RuleGroup> Children { get; protected set; }
        /// <summary>
        /// 一组规则
        /// </summary>
        public List<Rule> Rules { get; protected set; }
        public RuleGroup() { }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="title">分组标题</param>
        /// <param name="code">路径枚举</param>
        /// <param name="order">分组排序</param>
        /// <param name="description">分组描述</param>
        public RuleGroup(string title, string code, int order, string? description = null)
        {
            Title = title;
            Code = code;
            Order = order;
            Description = description;
            Children = new List<RuleGroup>();
            Rules = new List<Rule>();
        }
    }
}
