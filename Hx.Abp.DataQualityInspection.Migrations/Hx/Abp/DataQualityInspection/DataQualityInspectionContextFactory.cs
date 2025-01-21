using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Hx.Abp.DataQualityInspection
{
    public class DataQualityInspectionContextFactory : IDesignTimeDbContextFactory<DataQualityInspectionMContext>
    {
        public DataQualityInspectionMContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();
            var builder =
                new DbContextOptionsBuilder<DataQualityInspectionMContext>()
                .UseNpgsql(
                configuration.GetConnectionString("DataQualityInspection"));
            return new DataQualityInspectionMContext(builder.Options);
        }
        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
