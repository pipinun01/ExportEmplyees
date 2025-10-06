using Contract;
using Data;
using Microsoft.EntityFrameworkCore;
using Service;
using Service.Contract;

namespace ExportEmplyees.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) => services.AddDbContext<CompanyContext>(opts => opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
        public static void ConfigureEmployeeRepository(this IServiceCollection services) => services.AddScoped<IRepositoryManager, RepositoryManager>();
        public static void ConfigureServiceManager(this IServiceCollection services) => services.AddScoped<IServiceManager, ServiceManager>();
    }
}
