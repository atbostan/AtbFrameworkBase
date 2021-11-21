using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtbFramework.Persistance.Configurations;
using AtbFramework.Persistance.Seeds;
using Microsoft.EntityFrameworkCore;

namespace AtbFramework.Persistance.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region ApplyEntityConfiguration

            modelBuilder.ApplyConfiguration(new ExampleConfiguration());

            #endregion

            #region ApplySeeds

            modelBuilder.ApplyConfiguration(new ExampleSeed());


            #endregion
        }
    }
}
