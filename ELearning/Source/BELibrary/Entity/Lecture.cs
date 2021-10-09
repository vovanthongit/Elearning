namespace BELibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Lecture")]
    public partial class Lecture
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lecture()
        {
            Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public int SubjectId { get; set; }

        public bool IsTest { get; set; }

        public string FileTest { get; set; }

        public string TestTitle { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        [Required]
        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [Required]
        [StringLength(250)]
        public string UrlVideo { get; set; }

        public double TimeVideo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }

        public virtual Subject Subject { get; set; }
    }
}