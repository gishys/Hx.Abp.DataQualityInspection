using Hx.Abp.DataQualityInspection.Domain.Shared;
using NetTopologySuite.Geometries;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hx.Abp.DataQualityInspection.Domain
{
    /// <summary>
    /// 质量检查结果记录，表示一个具体的质检结果。
    /// </summary>
    public class QualityInspectionResultRecord : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 报告Id。
        /// </summary>
        public Guid ReportId { get; private set; }
        /// <summary>
        /// 结果处理状态。
        /// </summary>
        public InspectionStatus Status { get; private set; }

        /// <summary>
        /// 结果描述，提供问题的详细信息。
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// 问题所在的地理图层。
        /// </summary>
        public string LocationLayer { get; private set; }

        /// <summary>
        /// 问题所在的地理要素 ID。
        /// </summary>
        public string LocationId { get; private set; }

        /// <summary>
        /// 参考地理图层（可选）。
        /// </summary>
        public string ReferenceLayer { get; private set; }

        /// <summary>
        /// 参考地理要素 ID（可选）。
        /// </summary>
        public string ReferenceId { get; private set; }

        /// <summary>
        /// 几何图形类型。
        /// </summary>
        public GeometryShape Shape { get; private set; }

        /// <summary>
        /// 关联的规则 ID。
        /// </summary>
        public string RuleId { get; private set; }

        /// <summary>
        /// 关联的规则键值。
        /// </summary>
        public string RuleKey { get; private set; }

        /// <summary>
        /// 关联的规则标题。
        /// </summary>
        public string RuleTitle { get; private set; }

        /// <summary>
        /// 错误级别。
        /// </summary>
        public ErrorLevel ErrorLevel { get; private set; }

        /// <summary>
        /// 几何图形数据。
        /// </summary>
        public Geometry Geometry { get; private set; }

        /// <summary>
        /// 无参构造函数，用于支持默认初始化。
        /// </summary>
        public QualityInspectionResultRecord() { }

        /// <summary>
        /// 带参构造函数，用于初始化 QualityInspectionResultRecord 对象。
        /// </summary>
        /// <param name="id">结果唯一标识符。</param>
        /// <param name="status">结果处理状态。</param>
        /// <param name="description">结果描述。</param>
        /// <param name="locationLayer">问题所在的地理图层。</param>
        /// <param name="locationId">问题所在的地理要素 ID。</param>
        /// <param name="shape">几何图形类型。</param>
        /// <param name="ruleId">关联的规则 ID。</param>
        /// <param name="ruleKey">关联的规则键值。</param>
        /// <param name="ruleTitle">关联的规则标题。</param>
        /// <param name="errorLevel">错误级别。</param>
        public QualityInspectionResultRecord(InspectionStatus status, string description, string locationLayer, string locationId, GeometryShape shape, string ruleId, string ruleKey, string ruleTitle, ErrorLevel errorLevel)
        {
            this.Status = status;
            this.Description = description;
            this.LocationLayer = locationLayer;
            this.LocationId = locationId;
            this.Shape = shape;
            this.RuleId = ruleId;
            this.RuleKey = ruleKey;
            this.RuleTitle = ruleTitle;
            this.ErrorLevel = errorLevel;
        }

        /// <summary>
        /// 设置结果处理状态。
        /// </summary>
        /// <param name="status">结果处理状态。</param>
        public void SetStatus(InspectionStatus status) => this.Status = status;

        /// <summary>
        /// 设置结果描述。
        /// </summary>
        /// <param name="description">结果描述。</param>
        public void SetDescription(string description) => this.Description = description;

        /// <summary>
        /// 设置问题所在的地理图层。
        /// </summary>
        /// <param name="locationLayer">地理图层。</param>
        public void SetLocationLayer(string locationLayer) => this.LocationLayer = locationLayer;

        /// <summary>
        /// 设置问题所在的地理要素 ID。
        /// </summary>
        /// <param name="locationId">地理要素 ID。</param>
        public void SetLocationId(string locationId) => this.LocationId = locationId;

        /// <summary>
        /// 设置参考地理图层。
        /// </summary>
        /// <param name="referenceLayer">参考地理图层。</param>
        public void SetReferenceLayer(string referenceLayer) => this.ReferenceLayer = referenceLayer;

        /// <summary>
        /// 设置参考地理要素 ID。
        /// </summary>
        /// <param name="referenceId">参考地理要素 ID。</param>
        public void SetReferenceId(string referenceId) => this.ReferenceId = referenceId;

        /// <summary>
        /// 设置几何图形类型。
        /// </summary>
        /// <param name="shape">几何图形类型。</param>
        public void SetShape(GeometryShape shape) => this.Shape = shape;

        /// <summary>
        /// 设置关联的规则 ID。
        /// </summary>
        /// <param name="ruleId">规则 ID。</param>
        public void SetRuleId(string ruleId) => this.RuleId = ruleId;

        /// <summary>
        /// 设置关联的规则键值。
        /// </summary>
        /// <param name="ruleKey">规则键值。</param>
        public void SetRuleKey(string ruleKey) => this.RuleKey = ruleKey;

        /// <summary>
        /// 设置关联的规则标题。
        /// </summary>
        /// <param name="ruleTitle">规则标题。</param>
        public void SetRuleTitle(string ruleTitle) => this.RuleTitle = ruleTitle;

        /// <summary>
        /// 设置错误级别。
        /// </summary>
        /// <param name="errorLevel">错误级别。</param>
        public void SetErrorLevel(ErrorLevel errorLevel) => this.ErrorLevel = errorLevel;

        /// <summary>
        /// 设置几何图形数据。
        /// </summary>
        /// <param name="geometry">几何图形数据。</param>
        public void SetGeometry(Geometry geometry) => this.Geometry = geometry;
    }
}
