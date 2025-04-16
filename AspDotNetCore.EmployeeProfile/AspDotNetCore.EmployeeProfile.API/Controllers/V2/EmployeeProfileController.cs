using Asp.Versioning;
using AspDotNetCore.EmployeeProfile.BusinessLayer.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspDotNetCore.EmployeeProfile.API.Controllers.V2
{
    [Authorize]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]       
    [ApiController]
    public class EmployeeProfileController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeProfileController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("uploadfile")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            try
            {
                //check if file is empty
                if (file == null || file.Length <= 0) return BadRequest("No file uploaded");


                //creating file and writing in it
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles", file.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                //Store Data in DB
                await _employeeService.UploadEmployeeFromFileAsync(filePath);

                return Ok("File Uploaded Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest("Bad Request "+ex);
            }

        }
    }
}
