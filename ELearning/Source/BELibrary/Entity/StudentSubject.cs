namespace BELibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StudentSubject")]
    public partial class StudentSubject
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        public int SubjectId { get; set; }

        public int Status { get; set; }

        public DateTime CreatedDate { get; set; }

        [StringLength(250)]
        public string ApproveName { get; set; }

        public virtual User User { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
