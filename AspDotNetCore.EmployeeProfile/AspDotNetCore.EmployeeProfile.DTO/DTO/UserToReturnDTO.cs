using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspDotNetCore.EmployeeProfile.DTO.DTO
{
    public class UserToReturnDTO
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Roles { get; set; }
        public string? AccessToken { get; set; }
    }
}
