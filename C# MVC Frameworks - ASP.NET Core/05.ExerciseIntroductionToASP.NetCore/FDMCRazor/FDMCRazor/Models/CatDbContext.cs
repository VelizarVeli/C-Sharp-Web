using Microsoft.EntityFrameworkCore;

namespace FDMCRazor.Models
{
    public class CatDbContext : DbContext
    {
        public CatDbContext(DbContextOptions<CatDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cat> Cats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-8ECROG0\SQLEXPRESS;Database=Cats;Integrated_Security=True;");
        }
    }
}
