using Hx.Abp.DataQualityInspection.Domain;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Hx.Abp.DataQualityInspection.Application
{
    [DependsOn(typeof(AbpAutoMapperModule))]
    [DependsOn(typeof(AbpDddApplicationModule))]
    [DependsOn(typeof(HxAbpDataQualityInspectionDomainModule))]
    public class HxAbpDataQualityInspectionApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<HxAbpDataQualityInspectionApplicationModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<DataQualityInspectionProfile>(validate: true);
            });
        }
    }
}
