using Newtonsoft.Json;

namespace GoosClient.Models
{
    public class StudentModel
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("name_Surname")]
        public string NameSurname { get; set; }

        [JsonProperty("studentNumber")]
        public string StudentNumber { get; set; }

        [JsonProperty("birthDate")]
        public DateTime BirthDate { get; set; }

        [JsonProperty("gender")]
        public int Gender { get; set; }

        [JsonProperty("isDeleted")]
        public bool IsDeleted { get; set; }

        [JsonProperty("deleterId")]
        public string DeleterId { get; set; }

        [JsonProperty("deletionTime")]
        public DateTime? DeletionTime { get; set; }

        [JsonProperty("lastModificationTime")]
        public DateTime? LastModificationTime { get; set; }

        [JsonProperty("lastModifierId")]
        public string LastModifierId { get; set; }

        [JsonProperty("creationTime")]
        public DateTime CreationTime { get; set; }

        [JsonProperty("creatorId")]
        public string CreatorId { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }
        //[JsonProperty("fullImageUrl")]
        public string FullImageUrl { get; set; } = "profile.png";
    }
}
