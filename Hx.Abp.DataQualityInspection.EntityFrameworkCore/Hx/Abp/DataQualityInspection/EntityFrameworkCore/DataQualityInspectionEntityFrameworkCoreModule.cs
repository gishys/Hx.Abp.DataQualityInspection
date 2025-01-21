using Hx.Abp.DataQualityInspection.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.PostgreSql;
using Volo.Abp.Modularity;

namespace Hx.Abp.DataQualityInspection.EntityFrameworkCore
{

    [DependsOn(typeof(HxAbpDataQualityInspectionDomainModule))]
    [DependsOn(typeof(AbpEntityFrameworkCoreModule))]
    [DependsOn(typeof(AbpEntityFrameworkCorePostgreSqlModule))]
    public class DataQualityInspectionEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            context.Services.AddAbpDbContext<DataQualityInspectionDbContext>(options =>
            {
                options.AddDefaultRepositories(includeAllEntities: true);
            });
            context.Services.AddAbpDbContext<DataQualityInspectionDbContext>(options =>
            {
                options.AddRepository<QualityInspectionTask, QualityInspectionTaskRepository>();
                options.AddRepository<RuleGroup, RuleGroupRepository>();
            });
            Configure<AbpDbContextOptions>(options =>
            {
                options.UseNpgsql(options =>
                {
                    options.UseNetTopologySuite();
                });
            });
        }
    }
}
