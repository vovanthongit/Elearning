using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BELibrary.Entity
{
    [Table("ExamResults")]
    public partial class ExamResults
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int LectureId { get; set; }
        public int Point { get; set; }
        public DateTime? ExamTime { get; set; }
        public DateTime? TestDay { get; set; }

    }
}
