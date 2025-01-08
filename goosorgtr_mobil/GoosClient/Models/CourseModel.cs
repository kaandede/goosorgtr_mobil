using Newtonsoft.Json;

namespace GoosClient.Models
{
    public class CourseModel
    {
        [JsonProperty("courseName")]
        public string CourseName { get; set; }
        [JsonProperty("courseCode")]
        public string CourseCode { get; set; }
        [JsonProperty("elective")]
        public bool Elective { get; set; }
        [JsonProperty("stage")]
        public int? Stage { get; set; }
        [JsonProperty("semesterId")]
        public int? SemesterId { get; set; }


    }
}
