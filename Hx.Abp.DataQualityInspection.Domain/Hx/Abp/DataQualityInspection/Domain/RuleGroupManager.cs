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
        public IDistributedCache<RuleGroupCodeCache> RuleGroupCodeCache { get; }
        public IRuleGroupRepository RuleGroupRepository { get; }
        public RuleGroupManager(
            IDistributedCache<RuleGroupSortCache> ruleGroupSortCache,
            IRuleGroupRepository ruleGroupRepository,
            IDistributedCache<RuleGroupCodeCache> ruleGroupCodeCache)
        {
            RuleGroupSortCache = ruleGroupSortCache;
            RuleGroupRepository = ruleGroupRepository;
            RuleGroupCodeCache = ruleGroupCodeCache;
        }
        /// <summary>
        /// 通过父Id获取下一个排序号
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public virtual async Task<double> GetNextOrderNumberAsync(Guid? parentId)
        {
            var key = parentId?.ToString() ?? "parent";
            var cache = await RuleGroupSortCache.GetOrAddAsync(key,
                    async () =>
                    {
                        var maxNumber = await RuleGroupRepository.GetMaxOrderNumberAsync(parentId);
                        return new RuleGroupSortCache(parentId, maxNumber);
                    },
                    () => new DistributedCacheEntryOptions()
                    {
                    });
            var maxNumber = cache?.Sort ?? 0;
            maxNumber++;
            await RuleGroupSortCache.SetAsync(key, new RuleGroupSortCache(parentId, maxNumber));
            return maxNumber;
        }
        /// <summary>
        /// 通过父Id获取下一个路径枚举
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public virtual async Task<string> GetNextCodeAsync(Guid? parentId)
        {
            var key = parentId?.ToString() ?? "parent";
            var cache = await RuleGroupCodeCache.GetOrAddAsync(key,
                    async () =>
                    {
                        string maxNumber = await RuleGroupRepository.GetMaxCodeNumberAsync(parentId);
                        return new RuleGroupCodeCache(parentId, maxNumber);
                    },
                    () => new DistributedCacheEntryOptions()
                    {
                    });
            var maxCode = cache?.Code ?? RuleGroup.CreateCode([0]);
            maxCode = RuleGroup.CalculateNextCode(maxCode);
            await RuleGroupCodeCache.SetAsync(key, new RuleGroupCodeCache(parentId, maxCode));
            return maxCode;
        }
    }
}