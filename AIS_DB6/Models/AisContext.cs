namespace AIS_DB6.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AisContext : DbContext
    {
        public AisContext()
            : base("name=AIS_MODEL")
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<ContractClauses> ContractClauses { get; set; }
        public virtual DbSet<Good> Goods { get; set; }
        public virtual DbSet<GoodsGroup> GoodsGroup { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceLinesGoods> InvoiceLinesGoods { get; set; }
        public virtual DbSet<InvoiceLinesWork> InvoiceLinesWork { get; set; }
        public virtual DbSet<Producer> Producers { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Worker> Workers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Patronym)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Telephone)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.District)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Region)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Street)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.FlatNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.AppartmentNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Good>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Good>()
                .Property(e => e.Characteristics)
                .IsUnicode(false);

            modelBuilder.Entity<Good>()
                .HasMany(e => e.ContractClauses)
                .WithRequired(e => e.Good)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Good>()
                .HasMany(e => e.InvoiceLinesGoods)
                .WithRequired(e => e.Good)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GoodsGroup>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<GoodsGroup>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<GoodsGroup>()
                .HasMany(e => e.Goods)
                .WithRequired(e => e.GoodsGroup)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Invoice>()
                .HasMany(e => e.InvoiceLinesGoods)
                .WithRequired(e => e.Invoice)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InvoiceLinesWork>()
                .Property(e => e.TypeOfWork)
                .IsUnicode(false);

            modelBuilder.Entity<Producer>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Producer>()
                .Property(e => e.UserExpierence)
                .IsUnicode(false);

            modelBuilder.Entity<Producer>()
                .HasMany(e => e.Goods)
                .WithRequired(e => e.Producer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Patronym)
                .IsUnicode(false);

            modelBuilder.Entity<Worker>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<Worker>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Worker>()
                .Property(e => e.Patronym)
                .IsUnicode(false);

            modelBuilder.Entity<Worker>()
                .Property(e => e.Telephone)
                .IsUnicode(false);

            modelBuilder.Entity<Worker>()
                .Property(e => e.Speciality)
                .IsUnicode(false);

            modelBuilder.Entity<Worker>()
                .HasMany(e => e.InvoiceLinesWork)
                .WithRequired(e => e.Worker)
                .WillCascadeOnDelete(false);
        }
    }
}
