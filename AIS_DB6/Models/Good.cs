using System.Drawing;

namespace AIS_DB6.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("energondb.goods")]
    public partial class Good
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Good()
        {
            ContractClauses = new HashSet<ContractClauses>();
            InvoiceLinesGoods = new HashSet<InvoiceLinesGoods>();
        }

        //public Good Copy(Good g)
        //{
        //    Good k = new Good();

        //}


        //public Good(Good g)
        //{
        //    GoodsId = g.GoodsId;
        //    ProducerId = g.ProducerId;
        //    GoodsGroupId = g.GoodsGroupId;
        //    Name = g.Name;
        //    SellingPrice = g.SellingPrice;
        //    Characteristics = g.Characteristics;

        //    //ContractClauses = g.ContractClauses;

        //    //Producer = g.Producer;
        //    //GoodsGroup = g.GoodsGroup;
        //}

        [Key]
        public int GoodsId { get; set; }

        public int ProducerId { get; set; }

        public int GoodsGroupId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public double SellingPrice { get; set; }

        [StringLength(255)]
        public string Characteristics { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContractClauses> ContractClauses { get; set; }

        public virtual Producer Producer { get; set; }

        public virtual GoodsGroup GoodsGroup { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoiceLinesGoods> InvoiceLinesGoods { get; set; }
    }
}
