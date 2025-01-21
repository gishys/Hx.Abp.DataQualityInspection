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
        /// <summary>
        /// 获取某分类最大排序值
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public virtual async Task<double> GetMaxOrderNumberAsync(Guid? parentId)
        {
            var dbSet = await GetDbSetAsync();
            double? maxNumber = dbSet
                .AsEnumerable()
                .Where(d => d.ParentId == parentId)
                .OrderByDescending(d => d.Order)
                .Select(d => d.Order)
                .FirstOrDefault();
            return maxNumber ?? 1;
        }
    }
}
