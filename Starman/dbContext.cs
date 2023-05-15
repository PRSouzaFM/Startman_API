using Microsoft.EntityFrameworkCore;
using Starman.Models;

namespace Starman.Data
{
    public class StockItemDbContext : DbContext
    {
        public DbSet<StockItem> StockItems { get; set; }

        public StockItemDbContext(DbContextOptions<StockItemDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockItem>()
                .HasKey(e => e.ItemCode);
        }

    }
}
