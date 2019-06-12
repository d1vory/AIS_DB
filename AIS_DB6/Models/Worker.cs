namespace AIS_DB6.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("energondb.worker")]
    public partial class Worker
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Worker()
        {
            InvoiceLinesWork = new HashSet<InvoiceLinesWork>();
        }

        [Key]
        public int WorkerId { get; set; }

        [Required]
        [StringLength(30)]
        public string Surname { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [StringLength(30)]
        public string Patronym { get; set; }

        [Required]
        [StringLength(11)]
        public string Telephone { get; set; }

        [StringLength(25)]
        public string Speciality { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoiceLinesWork> InvoiceLinesWork { get; set; }
    }
}
