using EmployeeMangment.Modules;
using EmployeeMangment.Repositories;
using Microsoft.AspNetCore.Mvc; // 

namespace EmployeeMangment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;   
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAll()
        {
            var employeesList = 
            await _employeeRepository.GetAllEmployeesAsync();
            return Ok(employeesList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeByID(int id)
        {
            var employee =
            await _employeeRepository.GetEmployeeByIDAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            await _employeeRepository.AddEmployeeAsync(employee);
            return CreatedAtAction(nameof (GetEmployeeByID), new {id = employee.Id}, employee);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            await _employeeRepository.DeleteEmployeeAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }
            await _employeeRepository.UpdateEmployeeAsync(employee);
            return CreatedAtAction(nameof(GetEmployeeByID), new { id = employee.Id }, employee);

        }

    }
}
