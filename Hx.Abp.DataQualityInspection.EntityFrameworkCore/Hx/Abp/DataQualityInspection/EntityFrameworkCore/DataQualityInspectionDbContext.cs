using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Data;
using Hx.Abp.DataQualityInspection.Domain;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Hx.Abp.DataQualityInspection.EntityFrameworkCore.Hx.Abp.DataQualityInspection.EntityFrameworkCore
{
    [ConnectionStringName("DataQualityInspection")]
    public class DataQualityInspectionDbContext(DbContextOptions<DataQualityInspectionDbContext> options) : AbpDbContext<DataQualityInspectionDbContext>(options)
    {
        public virtual DbSet<QualityInspectionTask> Weekdays { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<QualityInspectionTask>(builder =>
            {
                // 设置表名
                builder.ToTable("QUALITY_INSPECTION_TASKS"); // 表名也改为大写

                // 配置主键
                builder.HasKey(t => t.Id)
                       .HasName("PK_QUALITY_INSPECTION_TASKS"); // 主键约束名称

                // 配置 ReportId 属性
                builder.Property(t => t.Id)
                       .IsRequired() // ReportId 是必填项
                       .HasColumnName("ID"); // 数据库字段名改为大写

                // 配置 Name 属性
                builder.Property(t => t.Name)
                       .IsRequired() // Name 是必填项
                       .HasMaxLength(255) // 设置最大长度
                       .HasColumnName("NAME"); // 数据库字段名改为大写

                // 配置 Status 属性
                builder.Property(t => t.Status)
                       .IsRequired() // Status 是必填项
                       .HasColumnName("STATUS"); // 数据库字段名改为大写

                // 配置 CompletedAt 属性
                builder.Property(t => t.CompletedAt)
                       .IsRequired(false) // CompletedAt 是可选项
                       .HasColumnName("COMPLETED_AT"); // 数据库字段名改为大写

                // 配置 Reports 属性
                builder.HasMany(t => t.Reports) // 配置一对多关系
                       .WithOne() // 假设 QualityInspectionReport 有一个外键指向 QualityInspectionTask
                       .HasForeignKey("QUALITY_INSPECTION_TASK_ID") // 外键名称改为大写
                       .OnDelete(DeleteBehavior.Cascade); // 设置级联删除

                builder.ConfigureFullAuditedAggregateRoot();
                builder.Property(p => p.CreationTime).HasColumnName("CREATIONTIME").HasColumnType("timestamp with time zone");
                builder.Property(p => p.CreatorId).HasColumnName("CREATORID");
                builder.Property(p => p.LastModificationTime).HasColumnName("LASTMODIFICATIONTIME").HasColumnType("timestamp with time zone");
                builder.Property(p => p.LastModifierId).HasColumnName("LASTMODIFIERID");
                builder.Property(p => p.IsDeleted).HasColumnName("ISDELETED");
                builder.Property(p => p.DeleterId).HasColumnName("DELETERID");
                builder.Property(p => p.DeletionTime).HasColumnName("DELETIONTIME").HasColumnType("timestamp with time zone");
            });

            modelBuilder.Entity<QualityInspectionReport>(builder =>
            {
                // 设置表名
                builder.ToTable("QUALITY_INSPECTION_REPORTS"); // 表名改为大写

                // 配置主键
                builder.HasKey(t => t.Id)
                       .HasName("PK_QUALITY_INSPECTION_REPORTS"); // 主键约束名称
                                                                  // 配置 ReportId 属性
                builder.Property(t => t.Id)
                       .IsRequired() // ReportId 是必填项
                       .HasColumnName("ID"); // 数据库字段名改为大写

                // 配置 Rule 属性（假设 QualityInspectionRule 是一个关联实体）
                builder.HasOne(t => t.Rule) // 配置一对一或多对一关系
                       .WithMany() // 假设 QualityInspectionRule 有多个 QualityInspectionReport
                       .HasForeignKey(d=>d.RuleId) // 外键名称改为大写
                       .HasConstraintName("RULE_ID")
                       .IsRequired(); // Rule 是必填项

                // 配置 Results 属性
                builder.HasMany(t => t.Results) // 配置一对多关系
                       .WithOne() // 假设 QualityInspectionResultRecord 有一个外键指向 QualityInspectionReport
                       .HasForeignKey("REPORT_ID") // 外键名称改为大写
                       .OnDelete(DeleteBehavior.Cascade); // 设置级联删除

                // 配置 Timestamp 属性
                builder.Property(t => t.Timestamp)
                       .IsRequired() // Timestamp 是必填项
                       .HasColumnName("TIMESTAMP"); // 数据库字段名改为大写

                // 配置 ReportType 属性
                builder.Property(t => t.ReportType)
                       .IsRequired() // ReportType 是必填项
                       .HasColumnName("REPORT_TYPE"); // 数据库字段名改为大写

                builder.ConfigureFullAuditedAggregateRoot();
                builder.Property(p => p.CreationTime).HasColumnName("CREATIONTIME").HasColumnType("timestamp with time zone");
                builder.Property(p => p.CreatorId).HasColumnName("CREATORID");
                builder.Property(p => p.LastModificationTime).HasColumnName("LASTMODIFICATIONTIME").HasColumnType("timestamp with time zone");
                builder.Property(p => p.LastModifierId).HasColumnName("LASTMODIFIERID");
                builder.Property(p => p.IsDeleted).HasColumnName("ISDELETED");
                builder.Property(p => p.DeleterId).HasColumnName("DELETERID");
                builder.Property(p => p.DeletionTime).HasColumnName("DELETIONTIME").HasColumnType("timestamp with time zone");
            });
            modelBuilder.Entity<QualityInspectionResultRecord>(builder =>
            {
                // 设置表名
                builder.ToTable("QUALITY_INSPECTION_RESULT_RECORDS"); // 表名改为大写

                // 配置主键
                builder.HasKey(t => t.Id)
                       .HasName("PK_QUALITY_INSPECTION_RESULT_RECORDS"); // 主键约束名称

                // 配置 ReportId 属性
                builder.Property(t => t.Id)
                       .IsRequired() // ReportId 是必填项
                       .HasColumnName("ID"); // 数据库字段名改为大写

                // 配置 ReportId 属性
                builder.Property(t => t.ReportId)
                       .IsRequired() // ReportId 是必填项
                       .HasColumnName("REPORT_ID"); // 数据库字段名改为大写

                // 配置 Status 属性
                builder.Property(t => t.Status)
                       .IsRequired() // Status 是必填项
                       .HasColumnName("STATUS"); // 数据库字段名改为大写

                // 配置 Description 属性
                builder.Property(t => t.Description)
                       .IsRequired() // Description 是必填项
                       .HasMaxLength(1000) // 设置最大长度
                       .HasColumnName("DESCRIPTION"); // 数据库字段名改为大写

                // 配置 LocationLayer 属性
                builder.Property(t => t.LocationLayer)
                       .IsRequired() // LocationLayer 是必填项
                       .HasMaxLength(255) // 设置最大长度
                       .HasColumnName("LOCATION_LAYER"); // 数据库字段名改为大写

                // 配置 LocationId 属性
                builder.Property(t => t.LocationId)
                       .IsRequired() // LocationId 是必填项
                       .HasMaxLength(255) // 设置最大长度
                       .HasColumnName("LOCATION_ID"); // 数据库字段名改为大写

                // 配置 ReferenceLayer 属性
                builder.Property(t => t.ReferenceLayer)
                       .IsRequired(false) // ReferenceLayer 是可选项
                       .HasMaxLength(255) // 设置最大长度
                       .HasColumnName("REFERENCE_LAYER"); // 数据库字段名改为大写

                // 配置 ReferenceId 属性
                builder.Property(t => t.ReferenceId)
                       .IsRequired(false) // ReferenceId 是可选项
                       .HasMaxLength(255) // 设置最大长度
                       .HasColumnName("REFERENCE_ID"); // 数据库字段名改为大写

                // 配置 Shape 属性
                builder.Property(t => t.Shape)
                       .IsRequired() // Shape 是必填项
                       .HasColumnName("SHAPE"); // 数据库字段名改为大写

                // 配置 RuleId 属性
                builder.Property(t => t.RuleId)
                       .IsRequired() // RuleId 是必填项
                       .HasMaxLength(255) // 设置最大长度
                       .HasColumnName("RULE_ID"); // 数据库字段名改为大写

                // 配置 RuleKey 属性
                builder.Property(t => t.RuleKey)
                       .IsRequired() // RuleKey 是必填项
                       .HasMaxLength(255) // 设置最大长度
                       .HasColumnName("RULE_KEY"); // 数据库字段名改为大写

                // 配置 RuleTitle 属性
                builder.Property(t => t.RuleTitle)
                       .IsRequired() // RuleTitle 是必填项
                       .HasMaxLength(255) // 设置最大长度
                       .HasColumnName("RULE_TITLE"); // 数据库字段名改为大写

                // 配置 ErrorLevel 属性
                builder.Property(t => t.ErrorLevel)
                       .IsRequired() // ErrorLevel 是必填项
                       .HasColumnName("ERROR_LEVEL"); // 数据库字段名改为大写

                // 配置 Geometry 属性
                builder.Property(t => t.Geometry)
                       .IsRequired(false) // Geometry 是可选项
                       .HasColumnName("GEOMETRY"); // 数据库字段名改为大写

                builder.ConfigureFullAuditedAggregateRoot();
                builder.Property(p => p.CreationTime).HasColumnName("CREATIONTIME").HasColumnType("timestamp with time zone");
                builder.Property(p => p.CreatorId).HasColumnName("CREATORID");
                builder.Property(p => p.LastModificationTime).HasColumnName("LASTMODIFICATIONTIME").HasColumnType("timestamp with time zone");
                builder.Property(p => p.LastModifierId).HasColumnName("LASTMODIFIERID");
                builder.Property(p => p.IsDeleted).HasColumnName("ISDELETED");
                builder.Property(p => p.DeleterId).HasColumnName("DELETERID");
                builder.Property(p => p.DeletionTime).HasColumnName("DELETIONTIME").HasColumnType("timestamp with time zone");
            });
        }
    }
}
