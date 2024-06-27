using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace apiservicios.Models
{
    public partial class Datamodel : DbContext
    {
        public Datamodel()
            : base("name=Datamodel")
        {
        }

        public virtual DbSet<element> element { get; set; }
        public virtual DbSet<sucursales> sucursales { get; set; }
        public virtual DbSet<tecelement> tecelement { get; set; }
        public virtual DbSet<tecnicos> tecnicos { get; set; }
        public virtual DbSet<tecsucu> tecsucu { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<element>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<element>()
                .Property(e => e.codigo)
                .IsUnicode(false);

            modelBuilder.Entity<element>()
                .HasMany(e => e.tecelement)
                .WithRequired(e => e.elements)
                .HasForeignKey(e => e.element)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sucursales>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<sucursales>()
                .Property(e => e.codigo)
                .IsUnicode(false);

            modelBuilder.Entity<sucursales>()
                .HasMany(e => e.tecsucu)
                .WithRequired(e => e.sucursales)
                .HasForeignKey(e => e.sucursal)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tecnicos>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<tecnicos>()
                .Property(e => e.codigo)
                .IsUnicode(false);

            modelBuilder.Entity<tecnicos>()
                .HasMany(e => e.tecelement)
                .WithRequired(e => e.tecnicos)
                .HasForeignKey(e => e.tecnico)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tecnicos>()
                .HasMany(e => e.tecsucu)
                .WithRequired(e => e.tecnicos)
                .HasForeignKey(e => e.tecnico)
                .WillCascadeOnDelete(false);
        }
    }
}
