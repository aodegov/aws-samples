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
        public IConfigurationRoot GetJsonConfig() => new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Shared/Configuration/cognito-settings.json",
                optional: false,
                reloadOnChange: true).Build();

        public CognitoConfigurationModel GetConfiguration()
        {
            var cognitoConfig = new CognitoConfigurationModel();

            GetJsonConfig()
               .GetSection("CognitoSettings")
                .Bind(cognitoConfig);

            return cognitoConfig;
        }
    }
}
