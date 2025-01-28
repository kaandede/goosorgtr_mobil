using Newtonsoft.Json;

namespace goosorgtr_mobil.GoosClient.Models
{
    public class GradeModel
    {
        [JsonProperty("studentId")]
        public int StudentId { get; set; }     
        
        [JsonProperty("courseCode")]
        public string? CourseCode { get; set; }

        [JsonProperty("studentName")]
        public string? StudentName { get; set; } 
        
        [JsonProperty("examName")]
        public string? ExamName { get; set; }

        [JsonProperty("score")]
        public double Score { get; set; }

        [JsonProperty("examId")]
        public int ExamId { get; set; }     
        
        [JsonProperty("percent")]
        public int Percent { get; set; }

    }
}