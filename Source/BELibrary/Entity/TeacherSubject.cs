namespace BELibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TeacherSubject")]
    public partial class TeacherSubject
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        public int SubjectId { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartTime { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FinishTime { get; set; }

        public virtual Subject Subject { get; set; }

        public virtual User User { get; set; }
    }
}
