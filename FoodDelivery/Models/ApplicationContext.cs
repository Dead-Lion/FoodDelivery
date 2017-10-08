using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=FoolDeliveryDB;Username=postgres;Password=password");
        }
    }
}
