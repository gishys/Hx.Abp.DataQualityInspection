using Volo.Abp.Application.Services;

namespace Hx.Abp.DataQualityInspection.Application.Contracts
{
    public interface IRuleGroupAppService : IApplicationService
    {
        Task CreateAsync(RuleGroupCreateDto dto);
        Task UpdateAsync(RuleGroupUpdateDto dto);
        Task DeleteAsync(Guid id);
    }
}
