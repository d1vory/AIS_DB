namespace AIS_DB6.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("energondb.invoice_lines_work")]
    public partial class InvoiceLinesWork
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WorkerId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InvoiceId { get; set; }

        [Required]
        [StringLength(250)]
        public string TypeOfWork { get; set; }

        public double WorkCost { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        public virtual Invoice Invoice { get; set; }

        public virtual Worker Worker { get; set; }
    }
}
