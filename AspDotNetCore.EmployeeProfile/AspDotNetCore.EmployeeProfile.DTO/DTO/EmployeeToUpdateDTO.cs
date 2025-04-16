using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspDotNetCore.EmployeeProfile.DTO.DTO
{
    public class EmployeeToUpdateDTO
    {
        public int EmployeeId { get; set; }
        public required string EmployeeName { get; set; }
        public required DateOnly DOB { get; set; }
        public required string Gender { get; set; }
        public required string Email { get; set; }
        public string? State { get; set; }
    }
}
