namespace BELibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StudentTest")]
    public partial class StudentTest
    {
        public int Id { get; set; }

        [StringLength(250)]
        public string FileAnswer { get; set; }

        [StringLength(250)]
        public string ReplyFile { get; set; }

        public int LectureId { get; set; }

        public float? Point { get; set; }

        public bool Status { get; set; }

        [Required]
        [StringLength(250)]
        public string Email { get; set; }

        public string Username { get; set; }

        public virtual Lecture Lecture { get; set; }

        public virtual User User { get; set; }
    }
}