using Hx.Abp.DataQualityInspection.Domain;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Hx.Abp.DataQualityInspection.EntityFrameworkCore
{
    public static class DbEntityTypeConfiguration
    {
        public static void OnModuleConfigration(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QualityInspectionTask>(builder =>
            {
                builder.ToTable("QI_TASKS");
                builder.HasKey(t => t.Id)
                       .HasName("PK_QI_TASKS");

                builder.Property(t => t.Id).IsRequired().HasColumnName("ID");
                builder.Property(t => t.Name).IsRequired().HasMaxLength(255).HasColumnName("NAME");
                builder.Property(t => t.Status).IsRequired().HasColumnName("STATUS");
                builder.Property(t => t.CompletedAt).IsRequired(false).HasColumnName("COMPLETED_AT");

                builder.HasMany(t => t.Reports)
                       .WithOne()
                       .HasForeignKey("QI_TASK_REPORT_ID")
                       .OnDelete(DeleteBehavior.Cascade);

                builder.ConfigureFullAuditedAggregateRoot();
                builder.Property(p => p.CreationTime).HasColumnName("CREATION_TIME").HasColumnType("timestamp with time zone");
                builder.Property(p => p.CreatorId).HasColumnName("CREATOR_ID");
                builder.Property(p => p.LastModificationTime).HasColumnName("LAST_MODIFICATION_TIME").HasColumnType("timestamp with time zone");
                builder.Property(p => p.LastModifierId).HasColumnName("LAST_MODIFIER_ID");
                builder.Property(p => p.IsDeleted).HasColumnName("IS_DELETED");
                builder.Property(p => p.DeleterId).HasColumnName("DELETER_ID");
                builder.Property(p => p.DeletionTime).HasColumnName("DELETION_TIME").HasColumnType("timestamp with time zone");
            });

            modelBuilder.Entity<Report>(builder =>
            {
                builder.ToTable("QI_REPORTS");
                builder.HasKey(t => t.Id)
                       .HasName("PK_QI_REPORTS");

                builder.Property(t => t.Id).IsRequired().HasColumnName("ID");
                builder.Property(t => t.RuleId).IsRequired().HasColumnName("RULE_ID");
                builder.Property(t => t.ReportType).IsRequired().HasColumnName("REPORT_TYPE");

                builder.HasOne(t => t.Rule)
                       .WithMany()
                       .HasForeignKey(d => d.RuleId)
                       .HasConstraintName("QI_REPORTS_RULE_ID")
                       .IsRequired();

                builder.HasMany(t => t.Results)
                       .WithOne()
                       .HasForeignKey(d => d.ReportId)
                       .HasConstraintName("QI_REPORTS_RESULT_ID")
                       .OnDelete(DeleteBehavior.Cascade);

                builder.ConfigureFullAuditedAggregateRoot();
                builder.Property(p => p.CreationTime).HasColumnName("CREATION_TIME").HasColumnType("timestamp with time zone");
                builder.Property(p => p.CreatorId).HasColumnName("CREATOR_ID");
                builder.Property(p => p.LastModificationTime).HasColumnName("LAST_MODIFICATION_TIME").HasColumnType("timestamp with time zone");
                builder.Property(p => p.LastModifierId).HasColumnName("LAST_MODIFIER_ID");
                builder.Property(p => p.IsDeleted).HasColumnName("IS_DELETED");
                builder.Property(p => p.DeleterId).HasColumnName("DELETER_ID");
                builder.Property(p => p.DeletionTime).HasColumnName("DELETION_TIME").HasColumnType("timestamp with time zone");
            });
            modelBuilder.Entity<ResultRecord>(builder =>
            {
                builder.ToTable("QI_RESULT_RECORDS");
                builder.HasKey(t => t.Id)
                       .HasName("PK_QI_RESULT_RECORDS");

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
                .HasConstraintName("QI_RESULT_RECORDS_RULE_ID")
                .OnDelete(DeleteBehavior.Cascade);

                builder.ConfigureFullAuditedAggregateRoot();
                builder.Property(p => p.CreationTime).HasColumnName("CREATION_TIME").HasColumnType("timestamp with time zone");
                builder.Property(p => p.CreatorId).HasColumnName("CREATOR_ID");
                builder.Property(p => p.LastModificationTime).HasColumnName("LAST_MODIFICATION_TIME").HasColumnType("timestamp with time zone");
                builder.Property(p => p.LastModifierId).HasColumnName("LAST_MODIFIER_ID");
                builder.Property(p => p.IsDeleted).HasColumnName("IS_DELETED");
                builder.Property(p => p.DeleterId).HasColumnName("DELETER_ID");
                builder.Property(p => p.DeletionTime).HasColumnName("DELETION_TIME").HasColumnType("timestamp with time zone");
            });

            modelBuilder.Entity<Rule>(builder =>
            {
                builder.ToTable("QI_RULES");
                builder.HasKey(t => t.Id).HasName("PK_QI_RULES");

                builder.Property(t => t.Id).IsRequired().HasColumnName("ID");
                builder.Property(t => t.RuleGroupId).IsRequired().HasColumnName("RULE_GROUP_ID");
                builder.Property(t => t.RuleGroupTemplateId).IsRequired(false).HasColumnName("RULE_GROUP_TEMPLATE_ID");
                builder.Property(t => t.RuleName).IsRequired().HasMaxLength(255).HasColumnName("RULE_NAME");
                builder.Property(t => t.Title).HasMaxLength(255).IsRequired().HasColumnName("TITLE");
                builder.Property(t => t.Description).HasMaxLength(500).IsRequired(false).HasColumnName("DESCRIPTION");
                builder.Property(t => t.SuccessEvent).HasMaxLength(255).IsRequired(false).HasColumnName("SUCCESS_EVENT");

                builder.Property(t => t.RuleType).IsRequired().HasColumnName("RULE_TYPE");
                builder.Property(t => t.ErrorType).IsRequired().HasColumnName("ERROR_TYPE");
                builder.Property(t => t.ErrorMessage).HasMaxLength(255).IsRequired().HasColumnName("ERROR_MESSAGE");
                builder.Property(t => t.RuleExpressionType).IsRequired().HasColumnName("RULE_EXPRESSION_TYPE");
                builder.Property(t => t.Expression).HasMaxLength(500).IsRequired().HasColumnName("EXPRESSION");

                builder.HasMany(t => t.Constraints)
                .WithOne()
                .HasForeignKey(d => d.RuleId)
                .HasConstraintName("QI_RULE_CONSTRAINTS_ID")
                .OnDelete(DeleteBehavior.Cascade);

                builder.ConfigureFullAuditedAggregateRoot();
                builder.Property(p => p.CreationTime).HasColumnName("CREATION_TIME").HasColumnType("timestamp with time zone");
                builder.Property(p => p.CreatorId).HasColumnName("CREATOR_ID");
                builder.Property(p => p.LastModificationTime).HasColumnName("LAST_MODIFICATION_TIME").HasColumnType("timestamp with time zone");
                builder.Property(p => p.LastModifierId).HasColumnName("LAST_MODIFIER_ID");
                builder.Property(p => p.IsDeleted).HasColumnName("IS_DELETED");
                builder.Property(p => p.DeleterId).HasColumnName("DELETER_ID");
                builder.Property(p => p.DeletionTime).HasColumnName("DELETION_TIME").HasColumnType("timestamp with time zone");
            });

            modelBuilder.Entity<RuleConstraints>(builder =>
            {
                builder.ToTable("QI_RULE_CONSTRAINTS");
                builder.HasKey(t => t.Id)
                       .HasName("PK_QI_RULE_CONSTRAINTS");

                builder.Property(t => t.Id).IsRequired().HasColumnName("ID");
                builder.Property(t => t.Name).IsRequired().HasMaxLength(255).HasColumnName("NAME");
                builder.Property(t => t.Title).IsRequired().HasMaxLength(255).HasColumnName("TITLE");
                builder.Property(t => t.RuleId).IsRequired().HasColumnName("RULE_ID");
                builder.Property(t => t.Expression).IsRequired(false).HasMaxLength(500).HasColumnName("EXPRESSION");
            });

            modelBuilder.Entity<RuleGroupTemplate>(builder =>
            {
                builder.ToTable("QI_RULE_GROUP_TEMPLATES");
                builder.HasKey(t => t.Id)
                       .HasName("PK_RULE_GROUP_TEMPLATES_REPORTS");

                builder.Property(t => t.Id).IsRequired().HasColumnName("ID");
                builder.Property(t => t.Title).IsRequired().HasMaxLength(255).HasColumnName("TITLE");
                builder.Property(t => t.Description).IsRequired(false).HasMaxLength(500).HasColumnName("DESCRIPTION");

                builder.HasMany(t => t.Rules)
                       .WithOne()
                       .HasForeignKey(d => d.RuleGroupTemplateId)
                       .HasConstraintName("QI_RULE_GROUP_TEMPLATES_RULE_ID")
                       .OnDelete(DeleteBehavior.Cascade);

                builder.ConfigureFullAuditedAggregateRoot();
                builder.Property(p => p.CreationTime).HasColumnName("CREATION_TIME").HasColumnType("timestamp with time zone");
                builder.Property(p => p.CreatorId).HasColumnName("CREATOR_ID");
                builder.Property(p => p.LastModificationTime).HasColumnName("LAST_MODIFICATION_TIME").HasColumnType("timestamp with time zone");
                builder.Property(p => p.LastModifierId).HasColumnName("LAST_MODIFIER_ID");
                builder.Property(p => p.IsDeleted).HasColumnName("IS_DELETED");
                builder.Property(p => p.DeleterId).HasColumnName("DELETER_ID");
                builder.Property(p => p.DeletionTime).HasColumnName("DELETION_TIME").HasColumnType("timestamp with time zone");
            });

            modelBuilder.Entity<RuleGroup>(builder =>
            {
                builder.ToTable("QI_RULE_GROUPS");
                builder.HasKey(t => t.Id)
                       .HasName("PK_RULE_GROUPS_REPORTS");

                builder.Property(t => t.Id).IsRequired().HasColumnName("ID");
                builder.Property(t => t.Title).IsRequired().HasMaxLength(255).HasColumnName("TITLE");
                builder.Property(t => t.Code).IsRequired().HasMaxLength(119).HasColumnName("CODE");
                builder.Property(t => t.ParentId).IsRequired(false).HasColumnName("PARENT_ID");
                builder.Property(t => t.Order).IsRequired().HasColumnName("ORDER");
                builder.Property(t => t.Description).IsRequired(false).HasMaxLength(500).HasColumnName("DESCRIPTION");

                builder.HasMany(t => t.Rules)
                       .WithOne()
                       .HasForeignKey(d => d.RuleGroupId)
                       .HasConstraintName("QI_RULE_GROUPS_RULE_ID")
                       .OnDelete(DeleteBehavior.Cascade);

                builder.HasMany(t => t.Children)
                       .WithOne()
                       .HasForeignKey(d => d.ParentId)
                       .HasConstraintName("QI_RULE_GROUPS_PARENT_ID")
                       .OnDelete(DeleteBehavior.Cascade);

                builder.ConfigureFullAuditedAggregateRoot();
                builder.Property(p => p.CreationTime).HasColumnName("CREATION_TIME").HasColumnType("timestamp with time zone");
                builder.Property(p => p.CreatorId).HasColumnName("CREATOR_ID");
                builder.Property(p => p.LastModificationTime).HasColumnName("LAST_MODIFICATION_TIME").HasColumnType("timestamp with time zone");
                builder.Property(p => p.LastModifierId).HasColumnName("LAST_MODIFIER_ID");
                builder.Property(p => p.IsDeleted).HasColumnName("IS_DELETED");
                builder.Property(p => p.DeleterId).HasColumnName("DELETER_ID");
                builder.Property(p => p.DeletionTime).HasColumnName("DELETION_TIME").HasColumnType("timestamp with time zone");
            });
        }
    }
}
