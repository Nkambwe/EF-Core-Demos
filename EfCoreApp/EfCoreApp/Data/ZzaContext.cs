using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using EfCoreApp.Entities;

namespace EfCoreApp.Data
{
    public class ZzaContext : DbContext
    {
        //..connection string
        private readonly string _connectionString;

        //..entities
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> Items { get; set; }
        public DbSet<OrderStatus> Statuses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductOption> Options { get; set; }
        public DbSet<ProductSize> Sizes { get; set; }

        public ZzaContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Select and configure data source
        /// </summary>
        /// <param name="builder">Options builder</param>
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(_connectionString);
        }

        /// <summary>
        /// Configure database model
        /// </summary>
        /// <param name="builder">Model Builder</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.RemovePluralizingTableNameConvention();
        }
    }
}