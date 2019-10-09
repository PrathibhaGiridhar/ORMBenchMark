using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ORMBenchMark.Models;

namespace ORMBenchMark.Models
{
   public partial class EFCoreContext : DbContext
    {
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Customer> customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(@"Host=localhost;Port=5432;Username=postgres;Password=reladmin@123;Database=SampleDB");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>().Property("customerid").IsRequired();
            modelBuilder.HasDefaultSchema("public");
        }


    }
}
