using Newtonsoft.Json;

namespace GoosClient.Models
{
    public class AttendanceModel
    {
        [JsonProperty("studentId")]
        public int StudentId { get; set; }
        [JsonProperty("studentName")]
        public string StudentName { get; set; }
        [JsonProperty("classNameCourseCode")]
        public string ClassName_CourseCode { get; set; }
        [JsonProperty("courseScheduleId")]
        public int CourseScheduleId { get; set; }
        [JsonProperty("creationTime")]

        public DateTime CreationTime { get; set; }
        [JsonProperty("attendanceStatus")]
        public AttendanceStatus AttendanceStatus { get; set; }
        [JsonProperty("creatorId")]
        public Guid? CreatorId { get; set; }
        [JsonProperty("semesterId")]
        public int? SemesterId { get; set; }
    }
    public enum AttendanceStatus
    {
        Absent = 1,
        Late,
        Off,
        Attended
    }
}
