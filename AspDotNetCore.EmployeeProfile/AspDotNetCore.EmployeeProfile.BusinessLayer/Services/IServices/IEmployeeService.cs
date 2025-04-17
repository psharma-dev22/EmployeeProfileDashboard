using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspDotNetCore.EmployeeProfile.DTO.DTO;

namespace AspDotNetCore.EmployeeProfile.BusinessLayer.Services.IServices
{
    public interface IEmployeeService
    {
        Task<EmployeeDTO> GetAsync(int employeeId);
        Task<List<EmployeeDTO>> GetListAsync(CancellationToken cancellationToken = default);
        Task<EmployeeDTO> AddEmployeeAsync(EmployeeToAddDTO employeeToAddDTO);
        Task<EmployeeDTO> UpdateEmployeeAsync(EmployeeToUpdateDTO employeeToUpdateDTO);
        Task<int> DeleteEmployeeAsync(int employeeId);
        Task UploadEmployeeFromFileAsync(string filePath);
    }
}
