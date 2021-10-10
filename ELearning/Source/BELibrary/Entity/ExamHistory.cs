using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BELibrary.Entity
{
    [Table("ExamHistories")]
  public partial  class ExamHistory
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int LectureId { get; set; }
        public int QuestionId { get; set; }
        public int TypeQuestion { get; set; }

    }
}
