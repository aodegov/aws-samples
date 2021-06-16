using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Threading.Tasks;
using VehicleHub.IdentityProviderClient.Interfaces;
using VehicleHub.IdentityProviderClient.Services;
using VehicleHub.IdentityProviderClient.Shared.Interfaces;

namespace VehicleHub.IdentityProviderClient
{
    class Program
    {
        static async Task Main(string[] args) => await CreateHostBuilder(args).Build().Services.GetService<ICognitoTokenService>().GetTokenAsync();

        private static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, builder) =>
                {
                    builder.SetBasePath(Directory.GetCurrentDirectory());
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton<ICognitoTokenService, CognitoTokenService>();
                    services.AddSingleton<ICognitoConfigService, CognitoConfigService>();
                });
    }
}
