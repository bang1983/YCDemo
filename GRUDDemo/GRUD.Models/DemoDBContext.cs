using Microsoft.EntityFrameworkCore;

namespace GRUDDemo.Models
{
    /// <summary>
    /// 資料庫容器
    /// </summary>
    public partial class DemoDBContext : DbContext
    {
        public virtual DbSet<DemoCode> DemoCode { get; set; }

        public DemoDBContext(DbContextOptions options) : base(options)
        {

        }
 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //代碼 Unique Index
            //modelBuilder.Entity<DemoCode>()
            //    .HasIndex(o => o.Code).IsUnique();

            modelBuilder.Entity<DemoCode>(entity =>
            {
                entity.HasIndex(e => e.Code)
                    .HasName("UX_DemoCode")
                    .IsUnique();

                entity.Property(e => e.ID).HasDefaultValueSql("(newid())");
 
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
