using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hx.Abp.DataQualityInspection.Domain
{
    /// <summary>
    /// 规则组模板
    /// </summary>
    public class RuleGroupTemplate : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 规则组模板标题
        /// </summary>
        public string Title { get; private set; }
        /// <summary>
        /// 规则组模板描述
        /// </summary>
        public string? Description { get; private set; }
        /// <summary>
        /// 一组规则
        /// </summary>
        public List<Rule> Rules { get; private set; }
        public RuleGroupTemplate() { }
        public RuleGroupTemplate(Guid id, string title, string? description = null)
        {
            Id = id;
            Title = title;
            Description = description;
            Rules = new List<Rule>();
        }
        /// <summary>
        /// 添加规则
        /// </summary>
        /// <param name="rule"></param>
        public void AddRule(Rule rule) => Rules.Add(rule);
        /// <summary>
        /// 设置标题
        /// </summary>
        /// <param name="title"></param>
        public void SetTitle(string title) => Title = title;
        /// <summary>
        /// 设置描述
        /// </summary>
        /// <param name="description"></param>
        public void SetDescription(string description) => Description = description;
    }
}
