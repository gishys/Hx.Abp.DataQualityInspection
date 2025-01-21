using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace Hx.Abp.DataQualityInspection.Application
{
    [DependsOn(typeof(AbpDddApplicationModule))]
    public class HxAbpDataQualityInspectionApplicationModule : AbpModule
    {
    }
}
