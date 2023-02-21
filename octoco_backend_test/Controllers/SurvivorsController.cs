using Microsoft.AspNetCore.Mvc;
using octoco_backend_test.Models;
using octoco_backend_test.Repository;

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
                return Ok(await survivorRepository.GetSurvivors());
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
                survivorRepository.AddSurvivor(survivor);
                return Ok();
            }
            catch (Exception err)
            {
                return StatusCode(500, $"Internal server error: {err.Message}");
            }
        }

        //void UpdateLocation(int survivorId, double latitude, double longitude);
        [HttpPost("UpdateLocation/{id}")]
        public ActionResult UpdateLocation(int id, [FromBody] LocationUpdate location)
        {
            try
            {
                survivorRepository.UpdateLocation(id, location.Latitude, location.Longitude);
                return Ok($"location of survivor {id} updated to ({location.Latitude}, {location.Longitude}).");
            }
            catch (Exception err)
            {
                return StatusCode(500, $"internal server error: {err.Message}");
            }
        }
        // void UpdateinfectionStatus(int survivorId);
        [HttpPut("UpdateInfectionStatus/{id}")]

        public ActionResult UpdateInfectionStatus(int id)
        { 
            try
            {
                survivorRepository.UpdateinfectionStatus(id);
                return Ok($"Location of survivor {id} updated to Infected.");
            }
            catch (Exception err)
            {
                return StatusCode(500, $"Internal server error: {err.Message}");
            }
        }
    }
}
