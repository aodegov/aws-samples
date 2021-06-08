using System.Threading.Tasks;

namespace VehicleHub.IdentityProviderClient.Interfaces
{
    public interface ICognitoTokenService
    {
        /// <summary>
        /// Get Access Token
        /// <seealso cref="https://docs.amazonaws.cn/en_us/sdk-for-net/v3/developer-guide/cognito-authentication-extension.html"/>
        /// </summary>
        /// <returns></returns>
        Task GetTokenAsync();
    }
}
