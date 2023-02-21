using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace octoco_backend_test.Models
{
    public class AppDBContext : DbContext
    {
        public DbSet<Survivor> Survivors { get; set; }
        public AppDBContext()
        {

        }
        public AppDBContext(DbContextOptions<AppDBContext> options)
            :base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Survivor>().Ignore(s => s.Inventory).HasData(
                new Survivor { Id = 1, Name = "John", Age = 26, Gender = Gender.Male, Inventory = new Dictionary<string, int> { { "Water Bottles", 5 }, { "Ammo", 49 }, { "Guns", 1 } }, Latitude = -32.241844 , Longitude = 22.2995 }
                );
        }
    }
}
