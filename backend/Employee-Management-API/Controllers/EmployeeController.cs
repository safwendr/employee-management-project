using Employee_Management_API.Models;
using Employee_Management_API.Repository.EmployeeRepository;
using Microsoft.AspNetCore.Mvc;


namespace Employee_Management_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepo _employeeRepo;
        public EmployeeController(
             IEmployeeRepo employeeRepo
            )
        {
            _employeeRepo = employeeRepo;
        }
        [HttpGet]
        public async Task<IActionResult> onGetAllEmployee()
        {
            try
            {
                var response = await _employeeRepo.getAllEmployee();
                if (response.Success == false || response.Success == null)
                {
                    if (response.Exception != null) return BadRequest(response.Exception);
                    return BadRequest();
                }
                return Ok(response.ListEmpoyees);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleEmployee(int id)
        {
            try
            {
                var response = await _employeeRepo.getSingleEmployee(id);
                if (response.Success == false || response.Success == null)
                {
                    if (response.NotFound == true) return NotFound();
                    if (response.Exception != null) return BadRequest(response.Exception);
                    return BadRequest();
                }
                return Ok(response.SingleEmployee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> createEmployee(Employee employee)
        {
            try
            {
                var response = await _employeeRepo.createEmployee(employee);
                if (response.Success == false || response.Success == null)
                {
                    if (response.Exception != null) return BadRequest(response.Exception);
                    return BadRequest();
                }
                return Ok(response.SingleEmployee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{employeeId}")]
        public async Task<IActionResult> updateEmployee(int employeeId, Employee employee)
        {
            try
            {
                var response = await _employeeRepo.updateEmployee(employeeId, employee);
                if (response.Success == false || response.Success == null)
                {
                    if (response.NotFound == true) return NotFound(); 
                    if (response.Exception != null) return BadRequest(response.Exception);
                    return BadRequest();
                }
                return Ok(response.SingleEmployee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{employeeId}")]
        public async Task<IActionResult> deleteEmployee(int employeeId)
        {
            try
            {
                var response = await _employeeRepo.deleteEmployee(employeeId);
                if (response.Success == false || response.Success == null)
                {
                    if (response.NotFound == true) return NotFound();
                    if (response.Exception != null) return BadRequest(response.Exception);
                    return BadRequest();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
