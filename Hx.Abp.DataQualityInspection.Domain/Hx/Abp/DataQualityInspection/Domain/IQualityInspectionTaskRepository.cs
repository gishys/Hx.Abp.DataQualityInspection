using Volo.Abp.Domain.Repositories;

namespace Hx.Abp.DataQualityInspection.Domain
{
    public interface IQualityInspectionTaskRepository : IBasicRepository<QualityInspectionTask, Guid>
    {
    }
}
