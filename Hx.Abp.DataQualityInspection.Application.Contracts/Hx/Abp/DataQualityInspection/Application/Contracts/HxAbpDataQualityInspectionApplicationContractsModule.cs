using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace Hx.Abp.DataQualityInspection.Application.Contracts
{
    [DependsOn(typeof(AbpDddApplicationContractsModule))]
    public class HxAbpDataQualityInspectionApplicationContractsModule : AbpModule
    {
    }
}
