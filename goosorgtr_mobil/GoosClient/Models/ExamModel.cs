using System;
using Newtonsoft.Json;

namespace goosorgtr_mobil.Models
{
    public class ExamModel
    {
        [JsonProperty("examName")]
        public string ExamName { get; set; }

        [JsonProperty("courseName")]
        public string CourseName { get; set; }

        [JsonProperty("className")]
        public string ClassName { get; set; }

        [JsonProperty("percent")]
        public int Percent { get; set; }

        [JsonProperty("courseId")]
        public int CourseId { get; set; }

        [JsonProperty("classId")]
        public int ClassId { get; set; }

        [JsonProperty("semesterId")]
        public int SemesterId { get; set; }

        [JsonProperty("examDate")]
        public DateTime ExamDate { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }
    }
}