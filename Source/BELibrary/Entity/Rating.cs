namespace BELibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Rating")]
    public partial class Rating
    {
        public int Id { get; set; }

        public double Point { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
