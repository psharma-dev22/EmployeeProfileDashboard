using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AspDotNetCore.EmployeeProfile.DAL.Entities;

namespace AspDotNetCore.EmployeeProfile.DAL.Repositories.IRepositories
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetAsync(Expression<Func<Employee, bool>> filter = null, CancellationToken cancellationToken = default);
        Task<List<Employee>> GetListAsync(CancellationToken cancellationToken=default);
        Task<Employee> AddEmployeeAsync(Employee employee);
        Task<Employee> UpdateEmployeeAsync(Employee employee);
        Task<int> DeleteEmployeeAsync(Employee employee);
        Task UploadEmployeeFromFileAsync(List<Employee> employees);
    }
}
