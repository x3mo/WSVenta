using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WSVenta.Models
{
    public partial class VentaRealContext : DbContext
    {
        public VentaRealContext()
        {
        }

        public VentaRealContext(DbContextOptions<VentaRealContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Concepto> Concepto { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Venta> Venta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Server=localhost;Database=VentaReal;Username=postgres;Password=sa");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("cliente");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseNpgsqlIdentityAlwaysColumn();

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Concepto>(entity =>
            {
                entity.ToTable("concepto");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cant).HasColumnName("cant");

                entity.Property(e => e.IdProd).HasColumnName("id_prod");

                entity.Property(e => e.IdVenta).HasColumnName("id_venta");

                entity.Property(e => e.Importe).HasColumnName("importe");

                entity.Property(e => e.PUnit).HasColumnName("pUnit");

                entity.HasOne(d => d.IdProdNavigation)
                    .WithMany(p => p.Concepto)
                    .HasForeignKey(d => d.IdProd)
                    .HasConstraintName("fk_prod");

                entity.HasOne(d => d.IdVentaNavigation)
                    .WithMany(p => p.Concepto)
                    .HasForeignKey(d => d.IdVenta)
                    .HasConstraintName("fk_venta");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("producto");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Costo).HasColumnName("costo");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasColumnType("character varying(100)");

                entity.Property(e => e.PUnit).HasColumnName("pUnit");
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.ToTable("venta");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("fk_cliente");
            });

            modelBuilder.HasSequence("sec_id_cliente")
                .HasMin(0)
                .HasMax(1);
        }
    }
}
