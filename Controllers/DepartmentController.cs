using ManageJobs.Models;
using ManageJobs.Repository.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManageJobs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService repo;
        public DepartmentController(IDepartmentService _repo)
        {
            this.repo = _repo;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var dept = repo.GetAll();
            if (dept == null) { return NotFound(); }
            return Ok(dept);
        }
        [HttpPost]
        public IActionResult CreateDepartemnt([FromBody]Department department)
        {
            repo.CreateDepartment(department);
            return CreatedAtAction(nameof(GetDepartmentByIde), new { id = department.Id }, department);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateDepartmentC(int id, [FromBody]Department department)
        {
            var dept = repo.UpdateDepartment(department, id);
            return Ok(dept);

        }
        [HttpGet("{id}")]
        public IActionResult GetDepartmentByIde(int id)
        {
            var dept = repo.GetDepartmentById(id);
            return Ok(dept);
        }
    }
}
