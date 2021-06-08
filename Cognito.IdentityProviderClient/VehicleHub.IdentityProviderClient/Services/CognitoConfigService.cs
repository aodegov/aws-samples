using VehicleHub.IdentityProviderClient.Models;
using VehicleHub.IdentityProviderClient.Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace VehicleHub.IdentityProviderClient.Services
{
    public class CognitoConfigService: ICognitoConfigService
    {
        public CognitoConfigService()
        {
        }
        public IConfigurationRoot GetJsonConfig()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Shared/Configuration/cognito-settings.json",
                optional: false,
                reloadOnChange: true);

            return builder.Build();
        }

        public CognitoConfigurationModel GetConfiguration()
        {
            var cognitoConfig = new CognitoConfigurationModel();
            var jsonConfig = GetJsonConfig();

            jsonConfig
                .GetSection("CognitoSettings")
                .Bind(cognitoConfig);

            return cognitoConfig;
        }
    }
}
