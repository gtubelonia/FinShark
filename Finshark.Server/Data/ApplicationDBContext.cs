using FinShark.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinShark.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<StockPortfolio> StockPortfolios { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<StockPortfolio>(s => s.HasKey(p => new { p.AppUserId, p.StockId }));

            builder.Entity<StockPortfolio>()
                .HasOne(u => u.AppUser)
                .WithMany(p => p.StockPortfolios)
                .HasForeignKey(u => u.AppUserId);

            builder.Entity<StockPortfolio>()
                .HasOne(u => u.Stock)
                .WithMany(p => p.StockPortfolios)
                .HasForeignKey(u => u.StockId);

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
