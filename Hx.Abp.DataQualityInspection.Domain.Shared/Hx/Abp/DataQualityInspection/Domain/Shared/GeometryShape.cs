using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hx.Abp.DataQualityInspection.Domain.Shared
{
    /// <summary>
    /// 几何形状类型，表示地理信息数据中的几何图形类型。
    /// 该枚举定义了常见的地理信息几何形状类型。
    /// </summary>
    public enum GeometryShape
    {
        /// <summary>
        /// 点类型，表示一个单一的地理坐标点。
        /// 例如：`{ type: 'Point', coordinates: [30, 10] }`
        /// </summary>
        Point,

        /// <summary>
        /// 线类型，表示由一系列点连接而成的线段。
        /// 例如：`{ type: 'LineString', coordinates: [[30, 10], [40, 40]] }`
        /// </summary>
        LineString,

        /// <summary>
        /// 多线类型，表示由多条线段组成的几何图形。
        /// 例如：`{ type: 'MultiLineString', coordinates: [[[30, 10], [40, 40]], [[50, 50], [60, 60]]] }`
        /// </summary>
        MultiLineString,

        /// <summary>
        /// 多边形类型，表示一个封闭的区域，由多个点组成的环构成。
        /// 例如：`{ type: 'Polygon', coordinates: [[[30, 10], [40, 40], [20, 40], [10, 20], [30, 10]]] }`
        /// </summary>
        Polygon,

        /// <summary>
        /// 多多边形类型，表示由多个多边形组成的几何图形。
        /// 例如：`{ type: 'MultiPolygon', coordinates: [[[[30, 10], [40, 40], [20, 40], [10, 20], [30, 10]]], [[[50, 50], [60, 60], [70, 70], [50, 50]]]] }`
        /// </summary>
        MultiPolygon,

        /// <summary>
        /// 几何集合类型，表示包含多种几何图形的集合。
        /// 例如：`{ type: 'GeometryCollection', geometries: [{ type: 'Point', coordinates: [30, 10] }, { type: 'LineString', coordinates: [[30, 10], [40, 40]] }] }`
        /// </summary>
        GeometryCollection,

        /// <summary>
        /// 多点类型，表示由多个点组成的几何图形。
        /// 例如：`{ type: 'MultiPoint', coordinates: [[30, 10], [40, 40], [50, 50]] }`
        /// </summary>
        MultiPoint
    }
}
