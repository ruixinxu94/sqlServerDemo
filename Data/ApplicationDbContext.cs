using Microsoft.EntityFrameworkCore;
using sqlServerDemo.Models;

namespace sqlServerDemo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<sqlServerDemo.Models.NFT_Product> NFT_Product { get; set; } = default!;
        
    }
}