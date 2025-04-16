using AspDotNetCore.EmployeeProfile.BusinessLayer.Services;
using AspDotNetCore.EmployeeProfile.BusinessLayer.Services.IServices;
using AspDotNetCore.EmployeeProfile.BusinessLayer.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AspDotNetCore.EmployeeProfile.BusinessLayer
{
    public static class DependencyInjection
    {
        public static void RegisterBLDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(Mapper));
            services.AddScoped<IEmployeeService,EmployeeService>();
            services.AddScoped<IAuthService,AuthService>();
        }

    }
}
