using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspDotNetCore.EmployeeProfile.DTO.DTO;

namespace AspDotNetCore.EmployeeProfile.BusinessLayer.Services.IServices
{
    public interface IAuthService
    {
        Task<UserToReturnDTO> LoginAsync(UserLoginDTO userLoginDTO);
    }
}
