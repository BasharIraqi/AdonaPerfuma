using AdonaPerfuma.Interfaces;
using AdonaPerfuma.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdonaPerfuma.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepo _repo;

        public EmployeesController(IEmployeeRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _repo.GetAllEmployees();
            return Ok(employees);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetEmployee([FromRoute] int id)
        {
            var employee = await _repo.GetEmployeeById(id);

            if (employee == null)

                return NotFound();

            return Ok(employee);
        }


        [HttpGet("GetEmployeeByUserId/{id}")]

        public async Task<IActionResult> GetEmployeeByUserId([FromRoute] int id)
        {
            var employee = await _repo.GetEmployeeByUserId(id);

            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            await _repo.AddEmployee(employee);
            return Ok();
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateEmployee([FromRoute] int id, [FromBody] Employee ModifiedEmployee)
        {
            await _repo.UpdateEmployee(id, ModifiedEmployee);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _repo.DeleteEmployee(id);
            return Ok();
        }
    }
}
