using Newtonsoft.Json;

namespace goosorgtr_mobil.GoosClient.Models
{

    public class ExtraProperties
    {
        [JsonProperty("parent")]
        public string Parent { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }
    }

    public class UserModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("tenantId")]
        public object TenantId { get; set; }

        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("emailConfirmed")]
        public bool EmailConfirmed { get; set; }

        [JsonProperty("phoneNumber")]
        public object PhoneNumber { get; set; }

        [JsonProperty("phoneNumberConfirmed")]
        public bool PhoneNumberConfirmed { get; set; }

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

        [JsonProperty("lockoutEnabled")]
        public bool LockoutEnabled { get; set; }

        [JsonProperty("accessFailedCount")]
        public int AccessFailedCount { get; set; }

        [JsonProperty("lockoutEnd")]
        public DateTime LockoutEnd { get; set; }

        [JsonProperty("concurrencyStamp")]
        public string ConcurrencyStamp { get; set; }

        [JsonProperty("entityVersion")]
        public int EntityVersion { get; set; }

        [JsonProperty("lastPasswordChangeTime")]
        public DateTime LastPasswordChangeTime { get; set; }

        [JsonProperty("isDeleted")]
        public bool IsDeleted { get; set; }

        [JsonProperty("deleterId")]
        public object DeleterId { get; set; }

        [JsonProperty("deletionTime")]
        public object DeletionTime { get; set; }

        [JsonProperty("lastModificationTime")]
        public DateTime LastModificationTime { get; set; }

        [JsonProperty("lastModifierId")]
        public string LastModifierId { get; set; }

        [JsonProperty("creationTime")]
        public DateTime CreationTime { get; set; }

        [JsonProperty("creatorId")]
        public object CreatorId { get; set; }

        [JsonProperty("extraProperties")]
        public ExtraProperties ExtraProperties { get; set; }
    }
}
