using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hx.Abp.DataQualityInspection.Domain.Shared
{
    /// <summary>
    /// 检查状态枚举，用于表示质检结果的处理状态。
    /// </summary>
    public enum InspectionStatus
    {
        /// <summary>
        /// 未处理：检查结果尚未被处理。
        /// </summary>
        Pending,

        /// <summary>
        /// 处理中：检查结果正在被处理。
        /// </summary>
        InProgress,

        /// <summary>
        /// 已处理：检查结果已被处理。
        /// </summary>
        Processed,

        /// <summary>
        /// 已修复：检查结果对应的问题已被修复。
        /// </summary>
        Fixed,

        /// <summary>
        /// 已忽略：检查结果对应的问题被忽略。
        /// </summary>
        Ignored,

        /// <summary>
        /// 无效：检查结果无效（例如，误报或重复记录）。
        /// </summary>
        Invalid
    }
}
