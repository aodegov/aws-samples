using VehicleHub.IdentityProviderClient.Models;
using Microsoft.Extensions.Configuration;

namespace VehicleHub.IdentityProviderClient.Shared.Interfaces
{
    public interface ICognitoConfigService
    {
        /// <summary>
        /// Bind json config file data to Cognito configuration model
        /// </summary>
        /// <returns cref="CognitoConfigurationModel">CognitoConfigurationModel</returns>
        CognitoConfigurationModel GetConfiguration();
    }
}
