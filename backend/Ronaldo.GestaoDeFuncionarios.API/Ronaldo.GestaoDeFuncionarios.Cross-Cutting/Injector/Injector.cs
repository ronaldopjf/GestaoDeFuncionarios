using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ronaldo.GestaoDeFuncionarios.Core.Aggregates.DepartmentAggregate.Interfaces.Repositories;
using Ronaldo.GestaoDeFuncionarios.Core.Aggregates.DepartmentAggregate.Interfaces.Services;
using Ronaldo.GestaoDeFuncionarios.Core.Aggregates.EmployeeAggregate.Interfaces.Repositories;
using Ronaldo.GestaoDeFuncionarios.Core.Aggregates.EmployeeAggregate.Interfaces.Services;
using Ronaldo.GestaoDeFuncionarios.Core.Aggregates.EmployeeAggregate.Services;
using Ronaldo.GestaoDeFuncionarios.Core.SharedKernel.Interfaces.UnityOfWork;
using Ronaldo.GestaoDeFuncionarios.Infrastructure.Data;
using Ronaldo.GestaoDeFuncionarios.Infrastructure.Data.Repositories;
using Ronaldo.GestaoDeFuncionarios.Infrastructure.Data.UnityOfWork;

namespace Ronaldo.GestaoDeFuncionarios.Cross_Cutting.Injector
{
    public static class Injector
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Entity Framework
            services.AddScoped<DataContext>();

            services.AddDbContext<DataContext>(x =>
                x.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Unity Of Work
            services.AddScoped<IUnityOfWork, UnityOfWork>();

            // Services
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IDepartmentService, DepartmentService>();

            // Repositories
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();

            // Validators

            // Configuration
        }
    }
}
