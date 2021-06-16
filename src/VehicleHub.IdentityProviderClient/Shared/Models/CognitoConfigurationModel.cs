
using System.Text.Json.Serialization;

namespace VehicleHub.IdentityProviderClient.Models
{
    public class CognitoConfigurationModel
    {
        /// <summary>
        /// Cognito pool ID
        /// </summary>
        [JsonPropertyName("poolId")]
        public string PoolId { get; set; }
        /// <summary>
        /// Cognito client app ID
        /// </summary>
        [JsonPropertyName("clientId")]
        public string ClientId { get; set; }
        /// <summary>
        /// Cognito client app secret
        /// </summary>
        [JsonPropertyName("clientScrt")]
        public string ClientScrt { get; set; }
        /// <summary>
        /// Cognito user ID
        /// </summary>
        [JsonPropertyName("userId")]
        public string UserId { get; set; }
        /// <summary>
        /// Cognito user password
        /// </summary>
        [JsonPropertyName("userPwd")]
        public string UserPwd { get; set; }
    }
}
