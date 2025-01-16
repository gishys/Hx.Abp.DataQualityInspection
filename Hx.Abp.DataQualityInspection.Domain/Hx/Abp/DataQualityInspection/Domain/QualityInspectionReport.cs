using Hx.Abp.DataQualityInspection.Domain.Shared;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hx.Abp.DataQualityInspection.Domain
{
    /// <summary>
    /// 质量检查报告，表示一次质检任务的结果汇总。
    /// </summary>
    public class QualityInspectionReport: FullAuditedEntity<Guid>
    {

        /// <summary>
        /// 关联的质检规则。
        /// </summary>
        public QualityInspectionRule Rule { get;private set; }

        /// <summary>
        /// 规则Id
        /// </summary>
        public Guid RuleId { get; private set; }

        /// <summary>
        /// 质检结果记录列表。
        /// </summary>
        public List<QualityInspectionResultRecord> Results { get; private set; }

        /// <summary>
        /// 报告生成时间。
        /// </summary>
        public DateTime Timestamp { get; private set; }

        /// <summary>
        /// 报告类型。
        /// </summary>
        public InspectionReportType ReportType { get; private set; }

        /// <summary>
        /// 无参构造函数，用于支持默认初始化。
        /// </summary>
        public QualityInspectionReport()
        {
            this.Results = new List<QualityInspectionResultRecord>();
        }

        /// <summary>
        /// 带参构造函数，用于初始化 QualityInspectionReport 对象。
        /// </summary>
        /// <param name="id">报告唯一标识符。</param>
        /// <param name="rule">关联的质检规则。</param>
        /// <param name="timestamp">报告生成时间。</param>
        /// <param name="reportType">报告类型。</param>
        public QualityInspectionReport(QualityInspectionRule rule, DateTime timestamp, InspectionReportType reportType)
        {
            this.Rule = rule;
            this.Timestamp = timestamp;
            this.ReportType = reportType;
            this.Results = new List<QualityInspectionResultRecord>();
        }

        /// <summary>
        /// 设置关联的质检规则。
        /// </summary>
        /// <param name="rule">质检规则。</param>
        public void SetRule(QualityInspectionRule rule) => this.Rule = rule;

        /// <summary>
        /// 设置质检结果记录列表。
        /// </summary>
        /// <param name="results">质检结果记录列表。</param>
        public void SetResults(List<QualityInspectionResultRecord> results) => this.Results = results;

        /// <summary>
        /// 设置报告生成时间。
        /// </summary>
        /// <param name="timestamp">报告生成时间。</param>
        public void SetTimestamp(DateTime timestamp) => this.Timestamp = timestamp;

        /// <summary>
        /// 设置报告类型。
        /// </summary>
        /// <param name="reportType">报告类型。</param>
        public void SetReportType(InspectionReportType reportType) => this.ReportType = reportType;
    }
}
