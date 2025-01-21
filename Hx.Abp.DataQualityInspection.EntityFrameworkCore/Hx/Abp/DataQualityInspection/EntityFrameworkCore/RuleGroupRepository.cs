using Hx.Abp.DataQualityInspection.Domain;
using Microsoft.EntityFrameworkCore;
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
            double maxNumber = await dbSet
                .Where(d => d.ParentId == parentId)
                .MaxAsync(d => d.Order);
            return maxNumber;
        }
        /// <summary>
        /// 获取某分类下 Code 字段最后一个部分的最大值
        /// </summary>
        /// <param name="parentId">父分类ID</param>
        /// <returns>最后一个部分的最大值对应的原始 Code，如果没有记录则返回 "00001"</returns>
        public virtual async Task<string> GetMaxCodeNumberAsync(Guid? parentId)
        {
            var dbSet = await GetDbSetAsync();
            List<string> codes = await dbSet
                .Where(d => d.ParentId == parentId)
                .Select(d => d.Code)
                .ToListAsync();
            if (codes.Count == 0)
            {
                return RuleGroup.CreateCode([1]);
            }
            string? maxCode = codes
                .OrderByDescending(code =>
                {
                    string[] parts = code.Split('.');
                    if (parts.Length == 0 || !double.TryParse(parts.Last(), out double value))
                    {
                        return double.MinValue;
                    }
                    return value;
                })
                .FirstOrDefault();
            if (string.IsNullOrEmpty(maxCode))
            {
                return RuleGroup.CreateCode([1]);
            }
            return maxCode;
        }
        /// <summary>
        /// 获取所有节点，包含子节点
        /// </summary>
        /// <returns></returns>
        public async Task<List<RuleGroup>> GetAllWithChildrenAsync()
        {
            var sql = @"
        WITH RecursiveGroups AS (
            SELECT * FROM QI_RULEGROUPS WHERE PARENT_ID IS NULL
            UNION ALL
            SELECT g.* FROM QI_RULEGROUPS g
            INNER JOIN RecursiveGroups rg ON g.PARENT_ID = rg.ID
        )
        SELECT * FROM RecursiveGroups
        ";
            var dbSet = await GetDbSetAsync();
            List<RuleGroup> groups = await dbSet.FromSqlRaw(sql).Include(d => d.Rules).ThenInclude(d => d.Constraints).ToListAsync();
            var groupMap = groups.ToDictionary(g => g.Id);
            var result = new List<RuleGroup>();
            foreach (var group in groups)
            {
                if (group.ParentId == null)
                {
                    result.Add(group);
                }
                else
                {
                    if (groupMap.TryGetValue(group.ParentId.Value, out var parent))
                    {
                        parent.AddChildren(group);
                    }
                }
            }
            return result;
        }
    }
}