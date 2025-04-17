using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Reflection;
using Asp.Versioning;
using AspDotNetCore.EmployeeProfile.BusinessLayer.Services.IServices;
using AspDotNetCore.EmployeeProfile.BusinessLayer.Utilities.CustomException;
using AspDotNetCore.EmployeeProfile.DTO.DTO;
using ExcelDataReader;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspDotNetCore.EmployeeProfile.API.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]    
    [ApiController]
    public class EmployeeProfileController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeProfileController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet("getemployee")]
        public async Task<IActionResult> GetEmployee(int employeeId)
        {
            try
            {
                return Ok(await _employeeService.GetAsync(employeeId));
            }
            catch (Exception ex)
            {
                return BadRequest("Bad Request " + ex);
            }
        }
        [HttpGet("getemployees")]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                return Ok(await _employeeService.GetListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest("Bad Request "+ex);
            }
        }
        [Authorize(Policy = "EditPolicy")]
        [HttpPost("addemployee")]
        public async Task<IActionResult> AddEmployee(EmployeeToAddDTO employeeToAddDTO)
        {
            try
            {
                return Ok(await _employeeService.AddEmployeeAsync(employeeToAddDTO));
            }
            catch (Exception ex)
            {
                return BadRequest("Bad Request " +ex);
            }
        }
        [Authorize(Policy = "EditPolicy")]
        [HttpPut("updateemployee")]
        public async Task<IActionResult> UpdateEmployee(EmployeeToUpdateDTO employeeToUpdateDTO)
        {
            try
            {
                return Ok(await _employeeService.UpdateEmployeeAsync(employeeToUpdateDTO));
            }
            catch (Exception ex)
            {
                return BadRequest("Bad Request " + ex);
            }
        }
        [Authorize(Policy = "EditPolicy")]
        [HttpDelete("deleteemployee")]
        public async Task<IActionResult> DeleteEmployee(int employeeId)
        {
            try
            {
                await _employeeService.DeleteEmployeeAsync(employeeId);
                return Ok("deleted");
            }
            catch (Exception ex)
            {
                return BadRequest("Bad Request "+ ex);
            }
        }        
    }
}
