using AspDotNetCore.EmployeeProfile.BusinessLayer.Services.IServices;
using AspDotNetCore.EmployeeProfile.BusinessLayer.Utilities.CustomException;
using AspDotNetCore.EmployeeProfile.DTO.DTO;
using Microsoft.AspNetCore.Mvc;

namespace AspDotNetCore.EmployeeProfile.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDTO userLoginDTO)
        {
            try
            {
                var user = await _authService.LoginAsync(userLoginDTO);

                return Ok(user);
            }
            catch (UserNotFoundException)
            {
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return BadRequest("Bad Request"+ ex.Message);
            }
        }
    }
}
