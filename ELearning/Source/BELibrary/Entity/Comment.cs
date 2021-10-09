namespace BELibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comment")]
    public partial class Comment
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime Time { get; set; }

        public bool Status { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        public int LectureId { get; set; }

        public int? ReplyId { get; set; }

        public virtual Lecture Lecture { get; set; }

        public virtual User User { get; set; }
    }
}
