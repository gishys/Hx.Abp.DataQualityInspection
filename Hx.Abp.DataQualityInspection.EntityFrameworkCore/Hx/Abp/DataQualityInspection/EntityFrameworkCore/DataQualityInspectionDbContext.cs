using Hx.Abp.DataQualityInspection.Domain;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Hx.Abp.DataQualityInspection.EntityFrameworkCore
{
    [ConnectionStringName("DataQualityInspection")]
    public class DataQualityInspectionDbContext(DbContextOptions<DataQualityInspectionDbContext> options) : AbpDbContext<DataQualityInspectionDbContext>(options)
    {
        public virtual DbSet<QualityInspectionTask> Weekdays { get; set; }
        public virtual DbSet<RuleGroup> RuleGroups { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.OnModuleConfigration();
        }
    }
}
