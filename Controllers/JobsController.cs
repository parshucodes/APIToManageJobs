using ManageJobs.Models;
using ManageJobs.Repository.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManageJobs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobServerice jobservice;
        private readonly ILocationService locationservice;
        private readonly IDepartmentService departmentservice;
        public JobsController(IJobServerice jobservice, IDepartmentService departmentservice, ILocationService locationservice)
        {
            this.jobservice = jobservice;
            this.departmentservice = departmentservice;
            this.locationservice = locationservice;

        }
        [HttpPost]
        public IActionResult PostdataJobs(Jobs jobs)
        {
            var jobd = jobservice.CreateJob(jobs);
            return Ok(jobd);
        }
        [HttpPut("{id}")]
        public IActionResult PutJobs(int id,[FromBody]Jobs jobs)
        {
            var data = jobservice.UpdateJob(jobs, id);
            return Ok(data);
        }
        [HttpGet]
        public IActionResult GetJobsAll()
        {
            var data = jobservice.GetAll();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult GetbyId(int id)
        {

        
        }

    }
}
