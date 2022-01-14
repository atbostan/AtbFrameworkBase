using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtbFramework.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtbFramework.Persistance.Configurations
{
    public class ExampleConfiguration : IEntityTypeConfiguration<ExampleClass>
    {
        public void Configure(EntityTypeBuilder<ExampleClass> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn(1,1);
            builder.Property(x => x.CreationTime).HasDefaultValue(null);
            builder.Property(x => x.CreatorUserId).HasDefaultValue(null);
            builder.Property(x => x.DeletionTime).HasDefaultValue(null);
            builder.Property(x => x.DeletorUserId).HasDefaultValue(null);
            builder.Property(x => x.ModificationTime).HasDefaultValue(null);
            builder.Property(x => x.ModifierUserId).HasDefaultValue(null);
            builder.Property(x => x.IsDeleted);
            builder.Property(x => x.City).HasMaxLength(25);
            builder.Property(x => x.Name).HasMaxLength(25);
            builder.Property(x => x.Number).HasMaxLength(25);
            builder.Property(x => x.Surname).HasMaxLength(25);
            builder.Property(x => x.MockId).IsRequired(true);
            builder.ToTable("Example");


        }
    }
}
