using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Caching;
using Volo.Abp.Domain.Services;

namespace Hx.Abp.DataQualityInspection.Domain
{
    public class RuleGroupManager : IDomainService
    {
        public IDistributedCache<RuleGroupSortCache> RuleGroupSortCache { get; }
        public IRuleGroupRepository RuleGroupRepository { get; }
        public RuleGroupManager(IDistributedCache<RuleGroupSortCache> ruleGroupSortCache, IRuleGroupRepository ruleGroupRepository)
        {
            RuleGroupSortCache = ruleGroupSortCache;
            RuleGroupRepository = ruleGroupRepository;
        }
        public virtual async Task<double> GetMaxOrderNumberAsync(Guid? parentId)
        {
            var cache = await RuleGroupSortCache.GetOrAddAsync(parentId?.ToString() ?? "parent",
                    async () =>
                    {
                        var maxNumber = await RuleGroupRepository.GetMaxOrderNumberAsync(parentId);
                        return new RuleGroupSortCache(parentId, maxNumber);
                    },
                    () => new DistributedCacheEntryOptions()
                    {
                        AbsoluteExpiration = DateTimeOffset.Now.AddDays(1)
                    });
            return cache?.Sort ?? 1;
        }
    }
}
