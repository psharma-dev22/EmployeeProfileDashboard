using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AspDotNetCore.EmployeeProfile.DAL.Entities;

namespace AspDotNetCore.EmployeeProfile.DAL.Repositories.IRepositories
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(Expression<Func<User, bool>> filter = null, CancellationToken cancellationToken = default); 
    }
}
