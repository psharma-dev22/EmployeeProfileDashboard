using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AspDotNetCore.EmployeeProfile.DAL.DataContext;
using AspDotNetCore.EmployeeProfile.DAL.Entities;
using AspDotNetCore.EmployeeProfile.DAL.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace AspDotNetCore.EmployeeProfile.DAL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeProfileDBContext _employeeProfileDBContext;

        public EmployeeRepository(EmployeeProfileDBContext employeeProfileDBContext)
        {
            _employeeProfileDBContext= employeeProfileDBContext;
        }
        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            await _employeeProfileDBContext.AddAsync(employee);
            await _employeeProfileDBContext.SaveChangesAsync();
            return employee;
        }

        public async Task<int> DeleteEmployeeAsync(Employee employee)
        {
            _employeeProfileDBContext.Remove(employee);
            return await _employeeProfileDBContext.SaveChangesAsync();
            
        }

        public async Task<Employee> GetAsync(Expression<Func<Employee, bool>> filter = null, CancellationToken cancellationToken = default)
        {
            return await _employeeProfileDBContext.Set<Employee>().AsNoTracking().FirstOrDefaultAsync(filter, cancellationToken);
        }

        public async Task<List<Employee>> GetListAsync(CancellationToken cancellationToken = default)
        {
            return await _employeeProfileDBContext.Set<Employee>().ToListAsync(cancellationToken);
        }

        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            _employeeProfileDBContext.Update(employee);
            await _employeeProfileDBContext.SaveChangesAsync();
            return employee;
        }

        public async Task UploadEmployeeFromFileAsync(List<Employee> employees)
        {
            foreach (var employee in employees)
            {
                await _employeeProfileDBContext.AddAsync(employee);
            }
            await _employeeProfileDBContext.SaveChangesAsync();
        }
    }
}
