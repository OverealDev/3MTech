using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

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
    }
}
