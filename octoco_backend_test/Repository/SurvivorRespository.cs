using Microsoft.EntityFrameworkCore;
using octoco_backend_test.Models;

namespace octoco_backend_test.Repository
{
    public class SurvivorRespository : ISurvivorRepository
    {
        private readonly AppDBContext appDBContext;

        public SurvivorRespository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public Survivor GetSurvivor(int survivorId)
        {
            return appDBContext.Survivors.Find(survivorId);
        }

        public async Task<IEnumerable<Survivor>> GetSurvivors()
        {
            return await appDBContext.Survivors.ToListAsync();
        }

        void ISurvivorRepository.AddSurvivor(Survivor survivor)
        {
            appDBContext.Survivors.Add(survivor);
            appDBContext.SaveChanges();
        }

        void ISurvivorRepository.FlagAsInfected(int survivorId)
        {
            var survivor = appDBContext.Survivors.FirstOrDefault(s => s.Id == survivorId);
            if (survivor != null)
            {
                survivor.isInfected = true;
                appDBContext.SaveChanges();
            }
        }

        void ISurvivorRepository.UpdateLocation(int survivorId, double latitude, double longitude)
        {
            var survivor = appDBContext.Survivors.FirstOrDefault(s => s.Id == survivorId);
            if (survivor != null)
            {
                survivor.Latitude = latitude;
                survivor.Longitude = longitude;
                appDBContext.SaveChanges();
            }
        }
    }
}
