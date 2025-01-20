using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hx.Abp.DataQualityInspection.Domain.Shared
{
    /// <summary>
    /// 任务状态枚举，用于表示质检任务的执行状态。
    /// </summary>
    public enum QualityInspectionTaskStatus
    {
        /// <summary>
        /// 未开始：任务已创建，但尚未开始执行。
        /// </summary>
        NotStarted,

        /// <summary>
        /// 进行中：任务正在执行中。
        /// </summary>
        InProgress,

        /// <summary>
        /// 已完成：任务已执行完成。
        /// </summary>
        Completed,

        /// <summary>
        /// 已取消：任务已被取消，未完成。
        /// </summary>
        Canceled
    }
}
