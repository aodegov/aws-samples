using Amazon.CognitoIdentityProvider;
using Amazon.Extensions.CognitoAuthentication;
using VehicleHub.IdentityProviderClient.Interfaces;
using System.Threading.Tasks;
using System;
using VehicleHub.IdentityProviderClient.Shared.Interfaces;

namespace VehicleHub.IdentityProviderClient.Services
{
    public class CognitoTokenService : ICognitoTokenService
    {
        private readonly ICognitoConfigService _cognitoConfigService;
        
        public CognitoTokenService(ICognitoConfigService cognitoConfigService) => this._cognitoConfigService = cognitoConfigService;

        public async Task GetTokenAsync()
        {
            try
            {
                // read config
                var config = this._cognitoConfigService.GetConfiguration();
                // CognitoIdentityProviderClient adjustments   
                AmazonCognitoIdentityProviderClient provider = new AmazonCognitoIdentityProviderClient(new Amazon.Runtime.AnonymousAWSCredentials(), Amazon.RegionEndpoint.CACentral1);
                CognitoUserPool userPool = new CognitoUserPool(config.PoolId, config.ClientId, provider, config.ClientScrt);
                CognitoUser user = new CognitoUser(config.UserId, config.ClientId, userPool, provider, config.ClientScrt);
                InitiateSrpAuthRequest authRequest = new InitiateSrpAuthRequest() { Password = config.UserPwd };
                // get token
                AuthFlowResponse authResponse = await user.StartWithSrpAuthAsync(authRequest).ConfigureAwait(false);
                var accessToken = authResponse.AuthenticationResult.AccessToken;
                // print token
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("COGNITO ACCESS TOKEN:\r\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(accessToken);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
