using GoosClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoosClient.InputModels
{
    public class AttendanceGetListInput
    {
        public int? StudentId { get; set; }
        public int? CourseId { get; set; }
        public int? ClassId { get; set; }

        public int? CourseScheduleId { get; set; }

        public DateTime? CreationTime { get; set; }

        public AttendanceStatus? AttendanceStatus { get; set; }

        public Guid? CreatorId { get; set; }
    }
}
