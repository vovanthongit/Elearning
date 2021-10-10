using Ats.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BELibrary.Entity
{
    public enum TYPE_QUESTION
    {
        [Display(Name = "Đáp án A")]
        A = 1,
        [Display(Name = "Đáp án B")]
        B = 2,
        [Display(Name = "Đáp án C")]
        C = 3,
        [Display(Name = "Đáp án D")]
        D = 4
    }
    [Table("Question")]
   public partial class Question 
    {
        public int Id { get; set; }

        public string ContentQuestion { get; set; }

        public string AnswerA { get; set; }

        public string AnswerB { get; set; }

        public string AnswerC { get; set; }

        public string AnswerD { get; set; }

        public TYPE_QUESTION TypeQuestion { get; set; }

        public string Note { get; set; }

        public int LectureId { get; set; }
        public virtual Lecture Lecture { get; set; }

        public DateTime? AddedTimestamp { get; set; }
        public String AddedUserId { get; set; }
        public DateTime? ChangedTimestamp { get; set; }
        public String ChangedUserId { get; set; }


    }
}
