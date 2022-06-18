using HR.API.Models;
using HR.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.API.Controllers
{
    [Controller]
    [Route("api/[controller]/[action]")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            try
            {
                var allemployess = await _employeeService.GetEmployees();
                return Ok(allemployess);
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
            //return await _context.Employees.ToListAsync();
        }


        [HttpGet]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            try
            {
                var employee = await _employeeService.GetEmployee(id);
                return Ok(employee);
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddEmployee([FromBody] Employee employee)
        {
            try
            {
                string result = string.Empty;
                if (employee != null)
                {
                    result = await _employeeService.AddEmployee(employee);
                }
                return Ok(result);
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
                //
            }
        }

        [HttpPut]
        public async Task<ActionResult> EditEmployee(int id, [FromBody] Employee employee)
        {
            try
            {
                string result = string.Empty;
                result = await _employeeService.EditEmployee(id, employee);
                return Ok(result);
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            try
            {
                string result = string.Empty;
                result = await _employeeService.RemoveEmployee(id);
                return Ok(result);
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }
    }
}
