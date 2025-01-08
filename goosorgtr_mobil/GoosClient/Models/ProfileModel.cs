using Newtonsoft.Json;

namespace GoosClient.Models
{
    public class ProfileModel
    {
        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("surname")]
        public object Surname { get; set; }

        [JsonProperty("phoneNumber")]
        public object PhoneNumber { get; set; }

        [JsonProperty("isExternal")]
        public bool IsExternal { get; set; }

        [JsonProperty("hasPassword")]
        public bool HasPassword { get; set; }

        [JsonProperty("concurrencyStamp")]
        public string ConcurrencyStamp { get; set; }

        [JsonProperty("extraProperties")]
        public List<string> ExtraProperties { get; set; }
    }
}
