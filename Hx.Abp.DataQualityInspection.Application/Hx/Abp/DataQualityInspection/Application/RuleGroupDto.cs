using Hx.Abp.DataQualityInspection.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hx.Abp.DataQualityInspection.Application
{
    public class RuleGroupDto
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 分组标题
        /// </summary>
        public required string Title { get; set; }
        /// <summary>
        /// 路径枚举
        /// </summary>
        public required string Code { get; set; }
        /// <summary>
        /// 分组排序
        /// </summary>
        public double Order { get; set; }
        /// <summary>
        /// 父Id
        /// </summary>
        public Guid? ParentId { get; set; }
        /// <summary>
        /// 分组描述
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// 子组
        /// </summary>
        public List<RuleGroupDto>? Children { get; set; }
        /// <summary>
        /// 一组规则
        /// </summary>
        public List<Rule>? Rules { get; set; }
    }
}
