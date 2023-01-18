using ExternalServices.Kinvo.Api;
using Microsoft.Extensions.DependencyInjection;
using ProviderManagement.Providers;
using Refit;

namespace ExternalServices.Kinvo.Injection
{
    public static class KinvoInjector
    {
        public static IServiceCollection InjectKinvoServices(this IServiceCollection services)
        {
            services
                .AddRefitClient<ITokenProvider>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri($"https://kinvo2c-api2.kinvo.com.br"));

            services
                .AddTransient<AuthHeaderHandler>();

            services
                .AddRefitClient<IKinvoService>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri($"https://kinvo2c-api2.kinvo.com.br"))
                .AddHttpMessageHandler<AuthHeaderHandler>();

            return services
                .AddTransient<IKinvoProviderService, GetKinvoPositionService>();
        }
    }
}