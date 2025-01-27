using Newtonsoft.Json;

namespace goosorgtr_mobil.Models
{
    public class GradeModel
    {
        [JsonProperty("studentId")]
        public int StudentId { get; set; }

        [JsonProperty("courseId")]
        public int CourseId { get; set; }

        [JsonProperty("score")]
        public double Score { get; set; }

        [JsonProperty("examId")]
        public int ExamId { get; set; }

        [JsonProperty("sorting")]
        public string Sorting { get; set; }

        [JsonProperty("skipCount")]
        public int SkipCount { get; set; }
    }
}