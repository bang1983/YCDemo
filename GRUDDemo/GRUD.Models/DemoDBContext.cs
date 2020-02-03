using Microsoft.EntityFrameworkCore;

namespace GRUDDemo.Models
{
    public class DemoDBContext : DbContext
    {
        public DbSet<DemoCode> Codes { get; set; }

        public DemoDBContext(DbContextOptions options) : base(options)
        {

        }
 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //代碼 Unique Index
            modelBuilder.Entity<DemoCode>()
                .HasIndex(o => o.Code).IsUnique();
        }
    }
}
