using DevTrackR.Tracking.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DevTrackR.Tracking.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddApplicationServices();

            return services;
        }

        private static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IShippingOrderUpdateService, ShippingOrderUpdateService>();

            return services;
        }
    }
}
