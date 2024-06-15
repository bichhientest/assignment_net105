using Microsoft.EntityFrameworkCore;
namespace assignment_NET105.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Combo> Combo { get; set; }
        public DbSet<Fastfood> Fastfood { get; set; }
        public DbSet<OrderFastfood> OrderFastfoods { get; set; }
        public DbSet<OrderCombo> OrderCombos { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<ComboFastfood> ComboFastfood { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ComboFastfood>().HasKey(cf => new { cf.ComboId, cf.FastfoodId });
            modelBuilder.Entity<ComboFastfood>()
               .HasOne(cf => cf.Combo)
               .WithMany(c => c.ComboFastfood)
               .HasForeignKey(cf => cf.ComboId);

            modelBuilder.Entity<ComboFastfood>()
                .HasOne(cf => cf.Fastfood)
                .WithMany(f => f.ComboFastfood)
                .HasForeignKey(cf => cf.FastfoodId);

            modelBuilder.Entity<OrderDetail>()
                .HasKey(od => od.OrderDetailId);


            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Fastfood)
                .WithMany()
                .HasForeignKey(od => od.FastfoodId);

            modelBuilder.Entity<OrderCombo>()
                .HasKey(oc => oc.OrderComboId);

            modelBuilder.Entity<OrderCombo>()
                .HasOne(oc => oc.User)
                .WithMany(u => u.OrderCombos)
                .HasForeignKey(oc => oc.UserId);
            modelBuilder.Entity<OrderCombo>()
            .HasOne(oc => oc.Combo)
             .WithMany(c => c.OrderCombos)
            .HasForeignKey(oc => oc.ComboId);

            modelBuilder.Entity<OrderFastfood>()
                .HasKey(of => of.OrderFastfoodId);

            modelBuilder.Entity<OrderFastfood>()
                .HasOne(of => of.User)
                .WithMany(u => u.OrderFastfoods)
                .HasForeignKey(of => of.UserId);
        }
    }
}
