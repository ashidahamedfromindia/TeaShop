using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TeaShop.Domain.Interfaces;
using TeaShop.Domain.Interfaces.IQueries;
using TeaShop.Infrastructure.ApplicationDbContext;
using TeaShop.Infrastructure.Queries;
using TeaShop.Infrastructure.Repositories;

namespace TeaShop.Infrastructure
{
    public static class ConfigureService
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(o => o.UseSqlServer(configuration.
                GetConnectionString("default connection") ?? throw new InvalidOperationException("Connection String DataComtext not found")));
            services.AddTransient<IBaseRepository, BaseRepository>();
            services.AddTransient<IProductQueries, ProductQueries>();
            services.AddTransient<ICustomerQueries, CustomerQueries>();
            services.AddTransient<ISalesReportQueries, SalesReportQueries>();
            return services;
        }
    }
}
