using Microsoft.Extensions.DependencyInjection;
using Order.Application.Features;
using Order.Domain.Interfaces.Facade;

namespace Order.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) 
        {
            services.AddScoped<IOrderService, OrderService>();
            return services;
        }
    }
}
