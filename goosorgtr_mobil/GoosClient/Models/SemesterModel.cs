using Newtonsoft.Json;

namespace GoosClient.Models
{
    public class SemesterModel
    {
        [JsonProperty("semesterName")]
        public string SemesterName { get; set; }
        [JsonProperty("startDate")]
        public DateTime StartDate { get; set; }
        [JsonProperty("endDate")]
        public DateTime EndDate { get; set; }
    }
}
