using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text.Json;

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
            modelBuilder.Entity<Survivor>().HasData(
                new Survivor
                {
                    Id = 1,
                    Name = "John",
                    Age = 26,
                    Gender = Gender.Male,
                    Inventory = new Dictionary<string, int> { { "Water Bottles", 5 }, { "Ammo", 49 }, { "Guns", 1 } },
                    Latitude = -32.241844,
                    Longitude = 22.2995,
                    isInfected = false
                },
                new Survivor
                {
                    Id = 2,
                    Name = "Mary",
                    Age = 33,
                    Gender = Gender.Female,
                    Inventory = new Dictionary<string, int> { { "Food", 10 }, { "Medicine", 2 }, { "Ammo", 15 } },
                    Latitude = 40.712776,
                    Longitude = -74.005974,
                    isInfected = true
                },
                new Survivor
                {
                    Id = 3,
                    Name = "Tom",
                    Age = 45,
                    Gender = Gender.Male,
                    Inventory = new Dictionary<string, int> { { "Water Bottles", 2 }, { "Gasoline", 5 } },
                    Latitude = 51.507351,
                    Longitude = -0.127758,
                    isInfected = false
                }
            );

            modelBuilder.Entity<Survivor>()
            .Property(s => s.Inventory)
            .HasConversion(
                d => JsonConvert.SerializeObject(d),
                s => JsonConvert.DeserializeObject<Dictionary<string, int>>(s)
                );
        }
    }
}
