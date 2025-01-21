using Hx.Abp.DataQualityInspection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hx.Abp.DataQualityInspection
{
    public class DataQualityInspectionMContext(
        DbContextOptions<DataQualityInspectionMContext> options) : AbpDbContext<DataQualityInspectionMContext>(options)
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(options =>
            {
                options.UseNetTopologySuite();
            });
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.OnModuleConfigration();
        }
    }
}
