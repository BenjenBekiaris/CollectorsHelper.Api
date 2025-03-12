using CollectorsHelper.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace CollectorsHelper.Api.Data
{
    public class CollectorsHelperContext(DbContextOptions<CollectorsHelperContext> options) : DbContext(options)
    {
        public DbSet<CollectibleItem> CollectibleItems => Set<CollectibleItem>();

        public DbSet<ItemType> ItemTypes => Set<ItemType>();

        public DbSet<Country> Countries => Set<Country>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemType>().HasData(
                new { Id = 1, Name = "Coin" });
            
            modelBuilder.Entity<Country>().HasData(
                new { Id = 1, Name = "Slovakia" },
                new { Id = 2, Name = "Germany" });
        }
    }
}
