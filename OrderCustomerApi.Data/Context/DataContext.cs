
using Microsoft.EntityFrameworkCore;
using OrderCustomerApi.Data.Entities;
using OrderCustomerApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketApplication.Data.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresss { get; set; }
        public DbSet<City> Citys { get; set; }
        public DbSet<Country> Countrys { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        private const string connectionString = @"server=BUKET-PEHLIVAN; database=OrderDB; TrustServerCertificate=True; Integrated Security=true ";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasKey(x => x.Guid);
            modelBuilder.Entity<Address>().HasKey(x => x.Guid);
            modelBuilder.Entity<City>().HasKey(x => x.Guid);
            modelBuilder.Entity<Country>().HasKey(x => x.Guid);
            modelBuilder.Entity<District>().HasKey(x => x.Guid);
            modelBuilder.Entity<Order>().HasKey(x => x.Guid);
            modelBuilder.Entity<Product>().HasKey(x => x.Guid);
            modelBuilder.Entity<Product>().Property(x => x.Price).HasColumnType("decimal(18,4)");

        }
    }
}
