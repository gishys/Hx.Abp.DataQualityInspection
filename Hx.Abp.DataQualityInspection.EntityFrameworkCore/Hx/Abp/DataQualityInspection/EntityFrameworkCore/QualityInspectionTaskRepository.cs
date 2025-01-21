using Hx.Abp.DataQualityInspection.Domain;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hx.Abp.DataQualityInspection.EntityFrameworkCore
{
    internal class QualityInspectionTaskRepository : EfCoreRepository<DataQualityInspectionDbContext, QualityInspectionTask, Guid>, IQualityInspectionTaskRepository
    {
        public QualityInspectionTaskRepository(
            IDbContextProvider<DataQualityInspectionDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }
    }
}
