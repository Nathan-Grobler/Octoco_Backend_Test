using Microsoft.AspNetCore.Mvc;
using octoco_backend_test.Models;
using octoco_backend_test.Repository;
using Newtonsoft.Json;

namespace octoco_backend_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurvivorsController : ControllerBase
    {
        private readonly ISurvivorRepository survivorRepository;
        
        public SurvivorsController(ISurvivorRepository survivorRepository)
        {
            this.survivorRepository = survivorRepository;
        }

        [HttpGet("GetAllSurvivors")]
        public async Task<ActionResult> GetSurvivors()
        {
            try
            {
                var survivors = await survivorRepository.GetSurvivors();
                var survivorsProjection = survivors.Select(s => new
                {
                    s.Name,
                    s.Age,
                    s.Gender,
                    s.Latitude,
                    s.Longitude,
                });
                return Ok(survivorsProjection);
            }
            catch (Exception err)
            {
                return StatusCode(500, $"Internal server error: {err.Message}");
            }
        }

        //void AddSurvivor(Survivor survivor);
        [HttpPost("CreateSurvivor")]
        public ActionResult CreateSurvivor(Survivor survivor)
        {
            try
            {
                survivor.Id = 0;

                survivorRepository.AddSurvivor(survivor);
                return Ok($"New Survivor {survivor.Name} has been added to the Zombie Survival Social Network");
            }
            catch (Exception err)
            {
                return StatusCode(500, $"Internal server error: {err.Message}");
            }
        }

        //void UpdateLocation(int survivorId, double latitude, double longitude);
        [HttpPut("UpdateLocation/{id}/{latitude}/{longitude}")]
        public ActionResult UpdateLocation(int id, double latitude, double longitude)
        {
            try
            {
                survivorRepository.UpdateLocation(id, latitude, longitude);
                return Ok($"location of survivor {id} updated to ({latitude}, {longitude}).");
            }
            catch (Exception err)
            {
                return StatusCode(500, $"internal server error: {err.Message}");
            }
        }
        // void UpdateinfectionStatus(int survivorId);
        [HttpPut("FlagAsInfected/{id}")]

        public ActionResult FlagAsInfected(int id)
        { 
            try
            {
                survivorRepository.FlagAsInfected(id);
                return Ok($"Location of survivor {id} updated to Infected.");
            }
            catch (Exception err)
            {
                return StatusCode(500, $"Internal server error: {err.Message}");
            }
        }
    }
}
