using Hx.Abp.DataQualityInspection.Domain.Shared;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hx.Abp.DataQualityInspection.Domain
{
    /// <summary>
    /// 质量检查报告，表示一次质检任务的结果汇总。
    /// </summary>
    public class Report: FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 关联的质检规则。
        /// </summary>
        public Rule Rule { get;private set; }

        /// <summary>
        /// 规则Id
        /// </summary>
        public Guid RuleId { get; private set; }

        /// <summary>
        /// 质检结果记录列表。
        /// </summary>
        public List<ResultRecord> Results { get; private set; }

        /// <summary>
        /// 报告类型。
        /// </summary>
        public InspectionReportType ReportType { get; private set; }

        /// <summary>
        /// 无参构造函数，用于支持默认初始化。
        /// </summary>
        public Report()
        {
            this.Results = new List<ResultRecord>();
        }

        /// <summary>
        /// 带参构造函数，用于初始化 QualityInspectionReport 对象。
        /// </summary>
        /// <param name="id">报告唯一标识符。</param>
        /// <param name="rule">关联的质检规则。</param>
        /// <param name="reportType">报告类型。</param>
        public Report(Guid id,Rule rule, InspectionReportType reportType)
        {
            this.Id = id;
            this.Rule = rule;
            this.ReportType = reportType;
            this.Results = new List<ResultRecord>();
        }

        /// <summary>
        /// 设置关联的质检规则。
        /// </summary>
        /// <param name="rule">质检规则。</param>
        public void SetRule(Rule rule) => this.Rule = rule;

        /// <summary>
        /// 设置质检结果记录列表。
        /// </summary>
        /// <param name="results">质检结果记录列表。</param>
        public void SetResults(List<ResultRecord> results) => this.Results = results;

        /// <summary>
        /// 设置报告类型。
        /// </summary>
        /// <param name="reportType">报告类型。</param>
        public void SetReportType(InspectionReportType reportType) => this.ReportType = reportType;
    }
}
