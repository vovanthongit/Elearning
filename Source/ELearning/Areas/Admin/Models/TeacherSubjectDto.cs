using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ELearning.Areas.Admin.Models
{
    public class TeacherSubjectDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? FinishTime { get; set; }
          
    }
}