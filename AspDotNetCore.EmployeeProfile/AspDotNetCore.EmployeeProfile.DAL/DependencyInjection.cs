using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using AspDotNetCore.EmployeeProfile.DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using AspDotNetCore.EmployeeProfile.DAL.Repositories.IRepositories;
using AspDotNetCore.EmployeeProfile.DAL.Repositories;


namespace AspDotNetCore.EmployeeProfile.DAL
{
    public static class DependencyInjection
    {
        public static void RegisterDALDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EmployeeProfileDBContext>(Options =>
                Options.UseSqlServer(configuration.GetConnectionString("DefualtConnection")));
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
        
    }
}
