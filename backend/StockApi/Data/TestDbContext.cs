using Microsoft.EntityFrameworkCore;
using StockApi.Data.Entities;

namespace StockApi.Data
{
    public class TestDbContext : DbContext 
    {
        public TestDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<TestEntity> TestEntities { get; set; }

        public DbSet<InvestPortfolio> InvestPortfolios { get; set;}

        public DbSet<Asset> Assets { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asset>()
                .HasOne(e => e.InvestPortfolio)
                .WithMany(e => e.Assets)
                .HasForeignKey(e => e.InvestPortfolioId)
                .IsRequired(false);

            modelBuilder.Entity<InvestPortfolio>()
                .HasMany(e => e.Assets)
                .WithOne(e => e.InvestPortfolio)
                .HasForeignKey(e => e.InvestPortfolioId)
                .IsRequired(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.InvestPortfolios)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .IsRequired(false);
        }
    }
}
