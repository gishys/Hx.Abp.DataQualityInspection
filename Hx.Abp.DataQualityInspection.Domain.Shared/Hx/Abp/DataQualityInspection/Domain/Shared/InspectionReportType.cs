using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hx.Abp.DataQualityInspection.Domain.Shared
{
    /// <summary>
    /// 检查报告类型枚举，用于表示不同的检查类型。
    /// </summary>
    public enum InspectionReportType
    {
        /// <summary>
        /// 拓扑检查：检查几何图形的拓扑关系。
        /// </summary>
        Topology,

        /// <summary>
        /// 属性检查：检查数据的属性完整性、一致性和正确性。
        /// </summary>
        Attribute,

        /// <summary>
        /// 几何检查：检查几何图形的有效性（如自相交、闭合性等）。
        /// </summary>
        Geometry,

        /// <summary>
        /// 逻辑检查：检查数据的逻辑关系（如父子关系、关联关系等）。
        /// </summary>
        Logical
    }
}
