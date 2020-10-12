using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace EFCodeFirst
{
    public class AppDBContext : DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderLine> Orderline { get; set; }
        public AppDBContext(DbContextOptions options) : base(options) { }
        public AppDBContext() : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        { if(!options.IsConfigured)
            {
                options.UseSqlServer("server=localhost\\sqlexpress;database=CustOrdDb;trusted_connection=true;");

            }

        }

        protected override void OnModelCreating(ModelBuilder builder) {

            builder.Entity<Customer>(e =>
            {
                e.HasIndex(X => X.Code).IsUnique();

            });

            builder.Entity<Order>(e => {
                e.Property(x => x.Description).IsRequired().HasMaxLength(50);
            });

        }
    }
}
