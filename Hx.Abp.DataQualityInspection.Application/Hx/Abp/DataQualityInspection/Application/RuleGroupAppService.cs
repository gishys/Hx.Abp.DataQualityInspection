using Hx.Abp.DataQualityInspection.Application.Contracts;
using Hx.Abp.DataQualityInspection.Domain;

namespace Hx.Abp.DataQualityInspection.Application
{
    public class RuleGroupAppService : DataQualityInspectionAppServiceBase
    {
        public IRuleGroupRepository RuleGroupRepository { get; }
        public RuleGroupAppService(IRuleGroupRepository ruleGroupRepository)
        {
            RuleGroupRepository = ruleGroupRepository;
        }
        public async virtual Task CreateAsync(RuleGroupCreateDto dto)
        {
            //计算顺序与路径枚举
            var entity = new RuleGroup(GuidGenerator.Create(), dto.Title, "", 1, dto.Description);
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