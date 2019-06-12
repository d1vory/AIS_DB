namespace AIS_DB6.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("energondb.contract")]
    public partial class Contract
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Contract()
        {
            ContractClauses = new HashSet<ContractClauses>();
        }

        [Key]
        public int ContractId { get; set; }

        [Column(TypeName = "date")]
        public DateTime SignDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime TerminationDate { get; set; }

        public int SupplierId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContractClauses> ContractClauses { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
