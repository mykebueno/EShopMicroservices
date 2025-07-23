using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ordering.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services, 
        IConfiguration configuration
    )
    {
        var connectionString = configuration.GetConnectionString("Database");
        // Register infrastructure services here
        // Example: services.AddScoped<IOrderRepository, OrderRepository>();

        // If using a database context, you might add it like this:
        // services.AddDbContext<OrderingContext>(options => 
        //     options.UseSqlServer("YourConnectionString"));
        return services;
    }   
}
