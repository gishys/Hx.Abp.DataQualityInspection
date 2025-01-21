using Hx.Abp.DataQualityInspection;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Hx.Workflow.EntityFrameworkCore.DbMigrations
{
    public class DataQualityInspectionModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<DataQualityInspectionMContext>();
        }
    }
}
