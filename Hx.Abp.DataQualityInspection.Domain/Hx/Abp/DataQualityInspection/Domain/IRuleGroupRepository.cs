using Volo.Abp.Domain.Repositories;

namespace Hx.Abp.DataQualityInspection.Domain
{
    public interface IRuleGroupRepository : IBasicRepository<RuleGroup, Guid>
    {
        /// <summary>
        /// 获取某分类最大排序值
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        Task<double> GetMaxOrderNumberAsync(Guid? parentId);
    }
}
