namespace octoco_backend_test.Repository
{
    public interface ISurvivorRepository
    {
        Task<IEnumerable<Survivor>> GetSurvivors();

        Survivor GetSurvivor(int survivorId);  

        void AddSurvivor(Survivor survivor);
        void UpdateLocation(int survivorId, double latitude, double longitude);
        void UpdateinfectionStatus (int survivorId);
    }
}
