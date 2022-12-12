using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;
using Microsoft.Extensions.Configuration.Json;

namespace WebApplication2.Data
{
    public class ItemDbContext : DbContext
    {
        public ItemDbContext(DbContextOptions<ItemDbContext> options)
            :base(options)
        {

        }

        public DbSet<Item> Items { get; set; }

        public DbSet<User> Users { get; set; }


        // Database provider to configure the DbContext instances
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var connectionString = configuration.GetConnectionString("SqlServer");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
