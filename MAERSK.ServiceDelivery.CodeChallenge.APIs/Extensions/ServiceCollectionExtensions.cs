using MAERSK.ServiceDelivery.CodeChallenge.APIs.Services;
using MAERSK.ServiceDelivery.CodeChallenge.APIs.Services.VoyagePriceService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace MAERSK.ServiceDelivery.CodeChallenge.APIs.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDataServices(this IServiceCollection services)
        {
            services.AddTransient<ICurrencyService, CurrencyService>();
            services.AddTransient<IVoyagePriceService, VoyagePriceService>();
        }

        public static void AddSwaggerService(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "MAERSK Service Delivery APIs",
                    Description = "Provide a simple APIs for some basic operations"
                });
            });
        }
    }
}
