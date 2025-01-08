using Newtonsoft.Json;

namespace GoosClient.Models
{
    public class RegisterModel
    {
        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("appName")]
        public string AppName { get; set; } = "goosv2";
    }
}
