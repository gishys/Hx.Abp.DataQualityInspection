using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hx.Abp.DataQualityInspection.Domain.Shared
{
    /// <summary>
    /// 错误级别枚举，用于表示质检结果的严重程度。
    /// </summary>
    public enum ErrorType
    {
        /// <summary>
        /// 提示性信息，不影响数据质量。
        /// </summary>
        Info = 1,

        /// <summary>
        /// 数据质量存在小问题，但不影响使用。
        /// </summary>
        Warning = 2,

        /// <summary>
        /// 数据质量存在重大问题，需要处理。
        /// </summary>
        Error = 3
    }
}
