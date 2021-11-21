using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtbFramework.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtbFramework.Persistance.Seeds
{
    public class ExampleSeed : IEntityTypeConfiguration<ExampleClass>
    {
        public void Configure(EntityTypeBuilder<ExampleClass> builder)
        {
            builder.HasData(
                new ExampleClass
                {
                    Id = 1,
                    Name="Ahmet Tarık",
                    City = "Ankara",
                    Number = 88754,
                    
                }
                );
        }
    }
}
