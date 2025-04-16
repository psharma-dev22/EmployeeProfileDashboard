using System.Linq.Expressions;
using AspDotNetCore.EmployeeProfile.DAL.DataContext;
using AspDotNetCore.EmployeeProfile.DAL.Entities;
using AspDotNetCore.EmployeeProfile.DAL.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace AspDotNetCore.EmployeeProfile.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EmployeeProfileDBContext _employeeProfileDBContext;
        public UserRepository(EmployeeProfileDBContext employeeProfileDBContext)
        {
            _employeeProfileDBContext = employeeProfileDBContext;
        }
        public async Task<User> GetUserAsync(Expression<Func<User, bool>> filter=null, CancellationToken cancellationToken = default)
        {
            return await _employeeProfileDBContext.Set<User>().AsNoTracking().FirstOrDefaultAsync(filter, cancellationToken);
        }
    }
}
