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
        /// 通过id获取实体携带children
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<RuleGroup?> GetByIdAsync(Guid id)
        {
            return await (await GetDbSetAsync()).Include(d => d.Children).FirstOrDefaultAsync(x => x.Id == id);
        }
        /// <summary>
        /// 获取某分类最大排序值
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public virtual async Task<double> GetMaxOrderNumberAsync(Guid? parentId)
        {
            var dbSet = await GetDbSetAsync();
            var query = dbSet
                .Where(d => d.ParentId == parentId);
            if (!await query.AnyAsync().ConfigureAwait(false))
            {
                return 0;
            }
            double maxNumber = await query
                .MaxAsync(d => d.Order)
                .ConfigureAwait(false);
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
                return RuleGroup.CreateCode([0]);
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
                return RuleGroup.CreateCode([0]);
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
    WITH RECURSIVE RecursiveGroups AS (
        SELECT * FROM ""QI_RULE_GROUPS"" WHERE ""PARENT_ID"" IS NULL
        UNION ALL
        SELECT g.* FROM ""QI_RULE_GROUPS"" g
        INNER JOIN RecursiveGroups rg ON g.""PARENT_ID"" = rg.""ID""
    )
    SELECT * FROM RecursiveGroups
";
            var dbSet = await GetDbSetAsync();
            List<RuleGroup> groups = await dbSet.FromSqlRaw(sql)
                .Include(d => d.Rules)
                .ThenInclude(d => d.Constraints).ToListAsync();
            return groups.Where(d => d.ParentId == null).ToList();
        }
    }
}