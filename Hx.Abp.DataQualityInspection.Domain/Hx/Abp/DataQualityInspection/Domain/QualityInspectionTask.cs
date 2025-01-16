using Volo.Abp.Domain.Entities.Auditing;

namespace Hx.Abp.DataQualityInspection.Domain
{
    /// <summary>
    /// 质检任务，表示一次完整的质检过程。
    /// </summary>
    public class QualityInspectionTask : FullAuditedEntity<Guid>
    {

        /// <summary>
        /// 任务名称，用于描述任务内容。
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 任务执行状态。
        /// </summary>
        public TaskStatus Status { get; private set; }

        /// <summary>
        /// 任务完成时间（可选）。
        /// </summary>
        public DateTime? CompletedAt { get; private set; }

        /// <summary>
        /// 质检报告记录列表。
        /// </summary>
        public List<QualityInspectionReport> Reports { get; private set; }

        /// <summary>
        /// 无参构造函数，用于支持默认初始化。
        /// </summary>
        public QualityInspectionTask()
        {
            this.Reports = new List<QualityInspectionReport>();
        }

        /// <summary>
        /// 带参构造函数，用于初始化 QualityInspectionTask 对象。
        /// </summary>
        /// <param name="id">任务唯一标识符。</param>
        /// <param name="name">任务名称。</param>
        /// <param name="status">任务执行状态。</param>
        /// <param name="createdAt">任务创建时间。</param>
        public QualityInspectionTask(string name, TaskStatus status)
        {
            this.Name = name;
            this.Status = status;
            this.Reports = new List<QualityInspectionReport>();
        }

        /// <summary>
        /// 设置任务名称。
        /// </summary>
        /// <param name="name">任务名称。</param>
        public void SetName(string name) => this.Name = name;

        /// <summary>
        /// 设置任务执行状态。
        /// </summary>
        /// <param name="status">任务执行状态。</param>
        public void SetStatus(TaskStatus status) => this.Status = status;

        /// <summary>
        /// 设置任务完成时间。
        /// </summary>
        /// <param name="completedAt">任务完成时间。</param>
        public void SetCompletedAt(DateTime? completedAt) => this.CompletedAt = completedAt;

        /// <summary>
        /// 设置质检报告记录列表。
        /// </summary>
        /// <param name="reports">质检报告记录列表。</param>
        public void SetReports(List<QualityInspectionReport> reports) => this.Reports = reports;
    }
}