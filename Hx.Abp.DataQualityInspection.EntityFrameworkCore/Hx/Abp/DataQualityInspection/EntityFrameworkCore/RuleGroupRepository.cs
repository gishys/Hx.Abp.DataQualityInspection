using Hx.Abp.DataQualityInspection.Domain;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hx.Abp.DataQualityInspection.EntityFrameworkCore
{
    internal class RuleGroupRepository : EfCoreRepository<DataQualityInspectionDbContext, RuleGroup, Guid>, IRuleGroupRepository
    {
        public RuleGroupRepository(
            IDbContextProvider<DataQualityInspectionDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }
    }
}
