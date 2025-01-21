using Hx.Abp.DataQualityInspection.Application.Contracts;
using Hx.Abp.DataQualityInspection.Domain;

namespace Hx.Abp.DataQualityInspection.Application
{
    public class RuleGroupAppService : DataQualityInspectionAppServiceBase
    {
        public IRuleGroupRepository RuleGroupRepository { get; }
        public RuleGroupManager RuleGroupManager { get; }
        public RuleGroupAppService(IRuleGroupRepository ruleGroupRepository, RuleGroupManager ruleGroupManager)
        {
            RuleGroupRepository = ruleGroupRepository;
            RuleGroupManager = ruleGroupManager;
        }
        public async virtual Task CreateAsync(RuleGroupCreateDto dto)
        {
            //路径枚举
            var orderNumber = await RuleGroupManager.GetMaxOrderNumberAsync(dto.ParentId);
            var entity = new RuleGroup(GuidGenerator.Create(), dto.Title, "", orderNumber, dto.Description);
            if (dto.ParentId.HasValue)
            {
                var parentEntity = await RuleGroupRepository.GetAsync(dto.ParentId.Value);
                parentEntity.Children.AddLast(entity);
                await RuleGroupRepository.UpdateAsync(parentEntity);
            }
            else
            {
                await RuleGroupRepository.InsertAsync(entity);
            }
        }
    }
}