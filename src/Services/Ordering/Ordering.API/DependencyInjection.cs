namespace Ordering.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        // Register API services here
        // Example: services.AddControllers();
        // Example: services.AddSwaggerGen();

        // If using a specific controller, you might add it like this:
        // services.AddScoped<IOrderController, OrderController>();

        return services;
    }

    public static WebApplication UseApiServices(this WebApplication app)
    {
        // app.MapCarter()

        return app;
    }
}
