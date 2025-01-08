using Newtonsoft.Json;

namespace GoosClient.Models
{
    public class LoginModel
    {
        [JsonProperty("username")]
        public string UserName { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("client_secret")]
        public string ClientSecret { get; set; } = "1q2w3e*";
        [JsonProperty("client_id")]
        public string ClientId { get; set; } = "goosv2_Web";
        [JsonProperty("scope")]
        public string Scope { get; set; } = "goosv2";
        [JsonProperty("grant_type")]
        public string GrantType { get; set; } = "password";

    }

}
