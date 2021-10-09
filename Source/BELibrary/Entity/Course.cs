namespace BELibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Course")]
    public partial class Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            Ratings = new HashSet<Rating>();
            Subjects = new HashSet<Subject>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(2)]
        public string LanguageId { get; set; }

        [Required]
        [StringLength(500)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        [Required]
        [StringLength(300)]
        public string Description { get; set; }

        [Required]
        public string Content { get; set; }

        [StringLength(1000)]
        public string Benefits { get; set; }

        [Required]
        public string Requirements { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        [Required]
        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public bool Status { get; set; }

        public bool TopHot { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rating> Ratings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
