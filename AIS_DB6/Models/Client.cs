namespace AIS_DB6.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("energondb.client")]
    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            Invoices = new HashSet<Invoice>();
        }

        [Key]
        public int ClientId { get; set; }

        [Required]
        [StringLength(30)]
        public string Surname { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [StringLength(40)]
        public string Patronym { get; set; }

        [Required]
        [StringLength(11)]
        public string Telephone { get; set; }

        [StringLength(30)]
        public string District { get; set; }

        [StringLength(30)]
        public string Region { get; set; }

        [StringLength(30)]
        public string City { get; set; }

        [StringLength(40)]
        public string Street { get; set; }

        [StringLength(5)]
        public string FlatNumber { get; set; }

        [StringLength(5)]
        public string ApartmentNumber { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
