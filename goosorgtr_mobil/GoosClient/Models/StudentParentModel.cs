using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace goosorgtr_mobil.GoosClient.Models
{
    public class StudentParentModel
    {
        [JsonProperty("studentParentId")]
        public int StudentParentId { get; set; }

        [JsonProperty("studentId")]
        public int StudentId { get; set; }

        [JsonProperty("classId")]
        public int ClassId { get; set; }

        [JsonProperty("name_Surname")]
        public string NameSurname { get; set; }

        [JsonProperty("studentNumber")]
        public string StudentNumber { get; set; }

        [JsonProperty("phoneNumber")]
        public object PhoneNumber { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("degreeAffinity")]
        public int DegreeAffinity { get; set; }

        [JsonProperty("lastModificationTime")]
        public object LastModificationTime { get; set; }

        [JsonProperty("lastModifierId")]
        public object LastModifierId { get; set; }

        [JsonProperty("creationTime")]
        public DateTime CreationTime { get; set; }

        [JsonProperty("creatorId")]
        public object CreatorId { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("userId")]
        public string UserId { get; set; }
    }
}
