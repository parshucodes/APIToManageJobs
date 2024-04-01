using ManageJobs.Models;
using ManageJobs.Repository.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManageJobs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService repo;
        public LocationController(ILocationService repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var taget = repo.GetAll();
            if (taget == null) { return NotFound(); }
            return Ok(taget);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var target = repo.GetLocationById(id);
            if (target == null) { return NotFound(); }
            return Ok(target);
        }
        [HttpPost]
        public IActionResult CreateLocation(Location location)
        {
            repo.CreateLocation(location);
            return CreatedAtAction(nameof(GetById), new { id = location.Id },location);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateLocationL(int id, [FromBody]Location location)
        {
            var data = repo.UpdateLocation(location, id);
            return Ok(data);
        }
    }
}
