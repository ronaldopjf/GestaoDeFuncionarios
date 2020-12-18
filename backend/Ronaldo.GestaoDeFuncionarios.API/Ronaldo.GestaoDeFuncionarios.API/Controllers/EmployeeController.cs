using Microsoft.AspNetCore.Mvc;
using Ronaldo.GestaoDeFuncionarios.Core.Aggregates.EmployeeAggregate.DTOs;
using Ronaldo.GestaoDeFuncionarios.Core.Aggregates.EmployeeAggregate.Interfaces.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ronaldo.GestaoDeFuncionarios.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: <EmployeeController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = _employeeService.Get();
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        // GET <EmployeeController>/5
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var result = _employeeService.Get(id);
            if (result != null)
                return Ok(result);
            return NotFound();
        }

        // POST <EmployeeController>
        [HttpPost]
        public IActionResult Post([FromBody] EmployeeForCreateDto employeeForCreateDto)
        {
            var result = _employeeService.Post(employeeForCreateDto);
            if (result.Success)
            {
                return Created("/employee", result.Object);
            }

            if (result.Message != null)
            {
                return BadRequest(new { error = result.Message });
            }

            return StatusCode(500);
        }

        // PUT <EmployeeController>
        [HttpPut]
        public IActionResult Put([FromBody] EmployeeForUpdateDto employeeForUpdateDto)
        {
            var result = _employeeService.Put(employeeForUpdateDto);
            if (result.Success)
            {
                return Ok(result.Object);
            }

            if (!string.IsNullOrEmpty(result.Message))
            {
                return BadRequest(new { error = result.Message });
            }

            return StatusCode(500);
        }

        // DELETE <EmployeeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var result = _employeeService.Delete(id);
            if (result.Success)
            {
                return Ok(result.Object);
            }

            if (!string.IsNullOrEmpty(result.Message))
            {
                return BadRequest(new { error = result.Message });
            }

            return StatusCode(500);
        }
    }
}
