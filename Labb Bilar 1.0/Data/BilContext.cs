using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labb_Bilar_1._0.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb_Bilar_1._0.Data
{
    public class BilContext : DbContext
    {
        public BilContext(DbContextOptions<BilContext> options) : base(options)
        { }

        public DbSet<Bil> Bilar { get; set; }
        public DbSet<Bilhandlare> Bilhandlare { get; set; }
        public DbSet<Stad> Städer { get; set; }
        public DbSet<Tillverkare> Tillverkarna { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bil>().ToTable("Bilar");
            modelBuilder.Entity<Bilhandlare>().ToTable("Bilhandlare");
            modelBuilder.Entity<Stad>().ToTable("Städer");
            modelBuilder.Entity<Tillverkare>().ToTable("Tillverkare");

        }
    }
}
