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
                builder.ToTable("QUALITY_INSPECTION_TASKS");
                builder.HasKey(t => t.Id)
                       .HasName("PK_QUALITY_INSPECTION_TASKS");

                builder.Property(t => t.Id).IsRequired().HasColumnName("ID");
                builder.Property(t => t.Name).IsRequired().HasMaxLength(255).HasColumnName("NAME");
                builder.Property(t => t.Status).IsRequired().HasColumnName("STATUS");
                builder.Property(t => t.CompletedAt).IsRequired(false).HasColumnName("COMPLETED_AT");

                builder.HasMany(t => t.Reports)
                       .WithOne()
                       .HasForeignKey("QUALITY_INSPECTION_TASK_REPORTS_ID")
                       .OnDelete(DeleteBehavior.Cascade);

                builder.ConfigureFullAuditedAggregateRoot();
                builder.Property(p => p.CreationTime).HasColumnName("CREATIONTIME").HasColumnType("timestamp with time zone");
                builder.Property(p => p.CreatorId).HasColumnName("CREATORID");
                builder.Property(p => p.LastModificationTime).HasColumnName("LASTMODIFICATIONTIME").HasColumnType("timestamp with time zone");
                builder.Property(p => p.LastModifierId).HasColumnName("LASTMODIFIERID");
                builder.Property(p => p.IsDeleted).HasColumnName("ISDELETED");
                builder.Property(p => p.DeleterId).HasColumnName("DELETERID");
                builder.Property(p => p.DeletionTime).HasColumnName("DELETIONTIME").HasColumnType("timestamp with time zone");
            });

            modelBuilder.Entity<Report>(builder =>
            {
                builder.ToTable("QUALITY_INSPECTION_REPORTS");
                builder.HasKey(t => t.Id)
                       .HasName("PK_QUALITY_INSPECTION_REPORTS");

                builder.Property(t => t.Id).IsRequired().HasColumnName("ID");
                builder.Property(t => t.RuleId).IsRequired().HasColumnName("RULEID");
                builder.Property(t => t.ReportType).IsRequired().HasColumnName("REPORT_TYPE");

                builder.HasOne(t => t.Rule)
                       .WithMany()
                       .HasForeignKey(d => d.RuleId)
                       .HasConstraintName("QUALITY_INSPECTION_REPORTS_RULE_ID")
                       .IsRequired();

                builder.HasMany(t => t.Results)
                       .WithOne()
                       .HasForeignKey(d=>d.ReportId)
                       .HasConstraintName("QUALITY_INSPECTION_REPORTS_RESULTS_ID")
                       .OnDelete(DeleteBehavior.Cascade);

                builder.ConfigureFullAuditedAggregateRoot();
                builder.Property(p => p.CreationTime).HasColumnName("CREATIONTIME").HasColumnType("timestamp with time zone");
                builder.Property(p => p.CreatorId).HasColumnName("CREATORID");
                builder.Property(p => p.LastModificationTime).HasColumnName("LASTMODIFICATIONTIME").HasColumnType("timestamp with time zone");
                builder.Property(p => p.LastModifierId).HasColumnName("LASTMODIFIERID");
                builder.Property(p => p.IsDeleted).HasColumnName("ISDELETED");
                builder.Property(p => p.DeleterId).HasColumnName("DELETERID");
                builder.Property(p => p.DeletionTime).HasColumnName("DELETIONTIME").HasColumnType("timestamp with time zone");
            });
            modelBuilder.Entity<ResultRecord>(builder =>
            {
                builder.ToTable("QUALITY_INSPECTION_RESULT_RECORDS");
                builder.HasKey(t => t.Id)
                       .HasName("PK_QUALITY_INSPECTION_RESULT_RECORDS");

                builder.Property(t => t.Id).IsRequired().HasColumnName("ID");
                builder.Property(t => t.ReportId).IsRequired().HasColumnName("REPORT_ID");
                builder.Property(t => t.Status).IsRequired().HasColumnName("STATUS");
                builder.Property(t => t.Description).IsRequired(false).HasMaxLength(1000).HasColumnName("DESCRIPTION");
                builder.Property(t => t.LocationLayer).IsRequired(false).HasMaxLength(255).HasColumnName("LOCATION_LAYER");
                builder.Property(t => t.LocationId).IsRequired(false).HasMaxLength(255).HasColumnName("LOCATION_ID");

                builder.Property(t => t.ReferenceLayer).IsRequired(false).HasMaxLength(255).HasColumnName("REFERENCE_LAYER");
                builder.Property(t => t.ReferenceId).IsRequired(false).HasMaxLength(255).HasColumnName("REFERENCE_ID");
                builder.Property(t => t.Shape).IsRequired(false).HasColumnName("SHAPE");
                builder.Property(t => t.RuleId).IsRequired().HasColumnName("RULE_ID");
                builder.Property(t => t.Geometry).IsRequired(false).HasColumnName("GEOMETRY");

                builder.HasOne(d => d.Rule)
                .WithMany()
                .HasForeignKey(d => d.RuleId)
                .HasConstraintName("QUALITY_INSPECTION_RESULT_RECORDS_RULE_ID")
                .OnDelete(DeleteBehavior.Cascade);

                builder.ConfigureFullAuditedAggregateRoot();
                builder.Property(p => p.CreationTime).HasColumnName("CREATIONTIME").HasColumnType("timestamp with time zone");
                builder.Property(p => p.CreatorId).HasColumnName("CREATORID");
                builder.Property(p => p.LastModificationTime).HasColumnName("LASTMODIFICATIONTIME").HasColumnType("timestamp with time zone");
                builder.Property(p => p.LastModifierId).HasColumnName("LASTMODIFIERID");
                builder.Property(p => p.IsDeleted).HasColumnName("ISDELETED");
                builder.Property(p => p.DeleterId).HasColumnName("DELETERID");
                builder.Property(p => p.DeletionTime).HasColumnName("DELETIONTIME").HasColumnType("timestamp with time zone");
            });

            modelBuilder.Entity<Rule>(builder =>
            {
                builder.ToTable("QUALITY_INSPECTION_RULES");
                builder.HasKey(t => t.Id).HasName("PK_QUALITY_INSPECTION_RULES");

                builder.Property(t => t.Id).IsRequired().HasColumnName("ID");
                builder.Property(t => t.RuleName).IsRequired().HasMaxLength(255).HasColumnName("RULENAME");
                builder.Property(t => t.Title).HasMaxLength(255).IsRequired().HasColumnName("TITLE");
                builder.Property(t => t.Description).HasMaxLength(500).IsRequired(false).HasColumnName("DESCRIPTION");
                builder.Property(t => t.SuccessEvent).HasMaxLength(255).IsRequired(false).HasColumnName("SUCCESSEVENT");

                builder.Property(t => t.ErrorType).IsRequired().HasColumnName("ERRORTYPE");
                builder.Property(t => t.ErrorMessage).HasMaxLength(255).IsRequired().HasColumnName("ERRORMESSAGE");
                builder.Property(t => t.RuleExpressionType).IsRequired().HasColumnName("RULEEXPRESSIONTYPE");
                builder.Property(t => t.Expression).HasMaxLength(500).IsRequired(false).HasColumnName("EXPRESSION");

                builder.HasMany(t => t.Children)
                .WithOne()
                .HasForeignKey("QUALITY_INSPECTION_RULE_CHILDREN_ID")
                .OnDelete(DeleteBehavior.Cascade);

                builder.HasMany(t => t.Constraints)
                .WithOne()
                .HasForeignKey(d => d.RuleId)
                .HasConstraintName("QUALITY_INSPECTION_RULE_CONSTRAINTS_ID")
                .OnDelete(DeleteBehavior.Cascade);

                builder.ConfigureFullAuditedAggregateRoot();
                builder.Property(p => p.CreationTime).HasColumnName("CREATIONTIME").HasColumnType("timestamp with time zone");
                builder.Property(p => p.CreatorId).HasColumnName("CREATORID");
                builder.Property(p => p.LastModificationTime).HasColumnName("LASTMODIFICATIONTIME").HasColumnType("timestamp with time zone");
                builder.Property(p => p.LastModifierId).HasColumnName("LASTMODIFIERID");
                builder.Property(p => p.IsDeleted).HasColumnName("ISDELETED");
                builder.Property(p => p.DeleterId).HasColumnName("DELETERID");
                builder.Property(p => p.DeletionTime).HasColumnName("DELETIONTIME").HasColumnType("timestamp with time zone");
            });

            modelBuilder.Entity<RuleConstraints>(builder =>
            {
                builder.ToTable("QUALITY_INSPECTION_RULECONSTRAINTS");
                builder.HasKey(t => t.Id)
                       .HasName("PK_QUALITY_INSPECTION_RULECONSTRAINTS");

                builder.Property(t => t.Id).IsRequired().HasColumnName("ID");
                builder.Property(t => t.Name).IsRequired().HasMaxLength(255).HasColumnName("NAME");
                builder.Property(t => t.Title).IsRequired().HasMaxLength(255).HasColumnName("TITLE");
                builder.Property(t => t.RuleId).IsRequired().HasColumnName("RULEID");
                builder.Property(t => t.Expression).IsRequired(false).HasMaxLength(500).HasColumnName("EXPRESSION");
            });
        }
    }
}
