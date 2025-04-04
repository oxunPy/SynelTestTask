using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SynelTestTask.Dto;
using SynelTestTask.Dto.Response;
using SynelTestTask.Service;
using SynelTestTask.Service.I;

namespace SynelTestTask.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeService.FindAll(Constants.EntityStatus.Active);
            return Ok(employees);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeDTO dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            SynelHttpResponse<EmployeeDTO> response = await _employeeService.Add(dto);
            return Ok(response);
            
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeDTO dto)
        {
            if (dto == null || dto.Id == null)
            {
                return BadRequest();
            }

            SynelHttpResponse<EmployeeDTO> response = await _employeeService.Update(dto);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        { 
            return Ok(await _employeeService.Delete(id));
        }
    }
}
