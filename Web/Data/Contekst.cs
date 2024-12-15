using Microsoft.EntityFrameworkCore;
using Web.Models;
using Microsoft.EntityFrameworkCore;
namespace Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        { }

        public DbSet<Users> Users { get; set; }
        public DbSet<goods> Goods { get; set; }
        public DbSet<orders> orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<orders>()
                .HasOne(o => o.Users)
                .WithMany() // Если у пользователя есть коллекция заказов, укажите её здесь
                .HasForeignKey(o => o.User_id);

            modelBuilder.Entity<orders>()
                .HasOne(o => o.goods)
                .WithMany() // Если у товара есть коллекция заказов, укажите её здесь
                .HasForeignKey(o => o.Goods_id);
        }
    }

}