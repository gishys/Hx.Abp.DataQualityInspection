using Hx.Abp.DataQualityInspection.Application.Contracts;
using Hx.Abp.DataQualityInspection.Domain;

namespace Hx.Abp.DataQualityInspection.Application
{
    public class RuleGroupAppService : DataQualityInspectionAppServiceBase, IRuleGroupAppService
    {
        private IRuleGroupRepository RuleGroupRepository { get; }
        private RuleGroupManager RuleGroupManager { get; }
        public RuleGroupAppService(IRuleGroupRepository ruleGroupRepository, RuleGroupManager ruleGroupManager)
        {
            RuleGroupRepository = ruleGroupRepository;
            RuleGroupManager = ruleGroupManager;
        }
        public async virtual Task CreateAsync(RuleGroupCreateDto dto)
        {
            var orderNumber = await RuleGroupManager.GetNextOrderNumberAsync(dto.ParentId);
            var code = await RuleGroupManager.GetNextCodeAsync(dto.ParentId);
            var entity = new RuleGroup(GuidGenerator.Create(), dto.Title, code, orderNumber, dto.Description);
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
        public async virtual Task UpdateAsync(RuleGroupUpdateDto dto)
        {
            var entity = await RuleGroupRepository.GetAsync(dto.Id);
            if (!string.Equals(entity.Title, dto.Title, StringComparison.OrdinalIgnoreCase))
            {
                entity.SetTitle(dto.Title);
            }
            if (!string.Equals(entity.Description, dto.Description, StringComparison.OrdinalIgnoreCase))
            {
                entity.SetDescription(dto.Description);
            }
            await RuleGroupRepository.UpdateAsync(entity);
        }
        public async virtual Task DeleteAsync(Guid id)
        {
            await RuleGroupRepository.DeleteAsync(id);
        }

    }
}