using Microsoft.AspNetCore.Mvc;
using Ronaldo.GestaoDeFuncionarios.Core.Aggregates.DepartmentAggregate.Interfaces.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ronaldo.GestaoDeFuncionarios.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        // GET: <DepartmentController>
        [HttpGet]
        public IActionResult Get()
        {
            var departments = _departmentService.Get();
            if (departments != null)
                return Ok(departments);
            return BadRequest();
        }

        // GET <DepartmentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST <DepartmentController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT <DepartmentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE <DepartmentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
