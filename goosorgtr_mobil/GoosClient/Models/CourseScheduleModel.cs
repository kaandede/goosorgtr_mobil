using Newtonsoft.Json;

namespace GoosClient.Models
{
    public class CourseScheduleModel
    {

        [JsonProperty("courseId")]
        public int CourseId { get; set; }

        [JsonProperty("classId")]
        public int ClassId { get; set; }

        [JsonProperty("teacherId")]
        public object TeacherId { get; set; }

        [JsonProperty("courseCode")]
        public string CourseCode { get; set; }

        [JsonProperty("className")]
        public string ClassName { get; set; }

        [JsonProperty("startTime")]
        public string StartTime { get; set; }

        [JsonProperty("endTime")]
        public string EndTime { get; set; }

        [JsonProperty("daysOfWeek")]
        public int DaysOfWeek { get; set; }

        [JsonProperty("isElective")]
        public bool IsElective { get; set; }

        [JsonProperty("timeSlotId")]
        public int TimeSlotId { get; set; }

        [JsonProperty("scheduleId")]
        public int ScheduleId { get; set; }

        [JsonProperty("teacherNameSurname")]
        public string TeacherNameSurname { get; set; }


    }

}
