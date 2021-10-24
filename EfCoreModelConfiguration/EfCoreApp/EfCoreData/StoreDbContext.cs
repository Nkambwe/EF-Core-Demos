using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

using EfCoreAp.EfCoreEntities;

namespace EfCoreApp.EfCoreData {

    public class StoreDbContext : DbContext {
        //..connection string
        private readonly string _connectionString;

        //..entities
        public DbSet<Product> Products { get; set; }

        public StoreDbContext(string connectionString)
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