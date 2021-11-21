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
            builder.Property(x => x.CreationTime);
            builder.Property(x => x.CreatorUserId);
            builder.Property(x => x.DeletionTime);
            builder.Property(x => x.DeletorUserId);
            builder.Property(x => x.ModificationTime);
            builder.Property(x => x.ModifierUserId);
            builder.Property(x => x.IsDeleted);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.City).HasMaxLength(25);
            builder.Property(x => x.Name).HasMaxLength(25);
            builder.Property(x => x.Number).HasMaxLength(25);
            builder.Property(x => x.Surname).HasMaxLength(25);
            builder.ToTable("Example");


        }
    }
}
