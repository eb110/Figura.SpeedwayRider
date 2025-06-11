using Figura.SpeedwayRider.Model;
using Figura.SpeedwayRider.Service;

namespace Figura.SpeedwayRider.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection IncludeRiderDb(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration
                .GetSection("ConnectionStrings")
                .GetSection("Figura.Rider")
                .Get<string>()!;

            return services.AddTransient<SpeedwayRiderDb>(x => new SpeedwayRiderDb(connectionString));
        }

        public static IServiceCollection IncludeRiderService(this IServiceCollection services)
        {
            return services.AddTransient<IRiderService, RiderService>();
        }
    }
}
