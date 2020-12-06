using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Servicio.Persistence.Database.Models
{
    public partial class CompanyContext : DbContext
    {
        public CompanyContext()
        {
        }

        public CompanyContext(DbContextOptions<CompanyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ObtenerVentasView_1> ObtenerVentasView_1 { get; set; }
        public virtual DbSet<cliente> cliente { get; set; }
        public virtual DbSet<compra> compra { get; set; }
        public virtual DbSet<compradetalle> compradetalle { get; set; }
        public virtual DbSet<documento> documento { get; set; }
        public virtual DbSet<producto> producto { get; set; }
        public virtual DbSet<proveedor> proveedor { get; set; }
        public virtual DbSet<venta> venta { get; set; }
        public virtual DbSet<ventadetalle> ventadetalle { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ObtenerVentasView_1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ObtenerVentasView_1", "ventas");

                entity.Property(e => e.baseimponible).HasColumnType("numeric(30,6)");

                entity.Property(e => e.direccionjuridica).HasMaxLength(150);

                entity.Property(e => e.fechaemision).HasColumnType("timestamp(6) with time zone");

                entity.Property(e => e.igv).HasColumnType("numeric(30,6)");

                entity.Property(e => e.nombrerazonsocial).HasMaxLength(150);

                entity.Property(e => e.nrodocidentidad).HasMaxLength(20);

                entity.Property(e => e.serie).HasMaxLength(4);

                entity.Property(e => e.total).HasColumnType("numeric(30,6)");
            });

            modelBuilder.Entity<cliente>(entity =>
            {
                entity.ToTable("cliente", "ventas");

                entity.Property(e => e.direccionjuridica).HasMaxLength(150);

                entity.Property(e => e.fecharegistro).HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.nombrerazonsocial)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.nrodocidentidad)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<compra>(entity =>
            {
                entity.ToTable("compra", "compras");

                entity.HasIndex(e => e.documentoid)
                    .HasName("IX_Relationship5");

                entity.HasIndex(e => e.proveedorid)
                    .HasName("IX_Relationship3");

                entity.Property(e => e.baseimponible).HasColumnType("numeric(30,6)");

                entity.Property(e => e.fechaemision).HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.fecharegistro).HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.igv).HasColumnType("numeric(30,6)");

                entity.Property(e => e.serie)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.total).HasColumnType("numeric(30,6)");

                entity.HasOne(d => d.documento)
                    .WithMany(p => p.compra)
                    .HasForeignKey(d => d.documentoid)
                    .HasConstraintName("fk_documento_compra");

                entity.HasOne(d => d.proveedor)
                    .WithMany(p => p.compra)
                    .HasForeignKey(d => d.proveedorid)
                    .HasConstraintName("fk_proveedor_compra");
            });

            modelBuilder.Entity<compradetalle>(entity =>
            {
                entity.ToTable("compradetalle", "compras");

                entity.HasIndex(e => e.compraid)
                    .HasName("IX_Relationship8");

                entity.HasIndex(e => e.productoid)
                    .HasName("IX_Relationship6");

                entity.Property(e => e.cantidad).HasColumnType("numeric(30,6)");

                entity.Property(e => e.igv).HasColumnType("numeric(30,6)");

                entity.Property(e => e.precio).HasColumnType("numeric(30,6)");

                entity.Property(e => e.valor).HasColumnType("numeric(30,6)");

                entity.Property(e => e.valorunitario).HasColumnType("numeric(30,6)");

                entity.HasOne(d => d.compra)
                    .WithMany(p => p.compradetalle)
                    .HasForeignKey(d => d.compraid)
                    .HasConstraintName("fk_compra_compradetalle");

                entity.HasOne(d => d.producto)
                    .WithMany(p => p.compradetalle)
                    .HasForeignKey(d => d.productoid)
                    .HasConstraintName("fk_producto_compradetalle");
            });

            modelBuilder.Entity<documento>(entity =>
            {
                entity.Property(e => e.documentoid).ValueGeneratedNever();

                entity.Property(e => e.descripcion)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.siglas)
                    .IsRequired()
                    .HasMaxLength(3);
            });

            modelBuilder.Entity<producto>(entity =>
            {
                entity.Property(e => e.codproducto)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.fecharegistro).HasColumnType("timestamp(6) with time zone");

                entity.Property(e => e.nombreproducto)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.valorunitario).HasColumnType("numeric(30,6)");
            });

            modelBuilder.Entity<proveedor>(entity =>
            {
                entity.ToTable("proveedor", "compras");

                entity.Property(e => e.direccionjuridica).HasMaxLength(150);

                entity.Property(e => e.fecharegistro).HasColumnType("timestamp(6) with time zone");

                entity.Property(e => e.nombrerazonsocial)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.nrodocidentidad)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<venta>(entity =>
            {
                entity.ToTable("venta", "ventas");

                entity.HasIndex(e => e.clienteid)
                    .HasName("IX_Relationship2");

                entity.HasIndex(e => e.documentoid)
                    .HasName("IX_Relationship4");

                entity.Property(e => e.baseimponible).HasColumnType("numeric(30,6)");

                entity.Property(e => e.fechaemision).HasColumnType("timestamp(6) with time zone");

                entity.Property(e => e.fecharegistro).HasColumnType("timestamp(6) with time zone");

                entity.Property(e => e.igv).HasColumnType("numeric(30,6)");

                entity.Property(e => e.serie)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.total).HasColumnType("numeric(30,6)");

                entity.HasOne(d => d.cliente)
                    .WithMany(p => p.venta)
                    .HasForeignKey(d => d.clienteid)
                    .HasConstraintName("fk_cliente_venta");

                entity.HasOne(d => d.documento)
                    .WithMany(p => p.venta)
                    .HasForeignKey(d => d.documentoid)
                    .HasConstraintName("fk_documento_venta");
            });

            modelBuilder.Entity<ventadetalle>(entity =>
            {
                entity.ToTable("ventadetalle", "ventas");

                entity.HasIndex(e => e.productoid)
                    .HasName("IX_Relationship7");

                entity.HasIndex(e => e.ventaid)
                    .HasName("IX_Relationship1");

                entity.Property(e => e.cantidad).HasColumnType("numeric(30,6)");

                entity.Property(e => e.igv).HasColumnType("numeric(30,6)");

                entity.Property(e => e.precio).HasColumnType("numeric(30,6)");

                entity.Property(e => e.valor).HasColumnType("numeric(30,6)");

                entity.Property(e => e.valorunitario).HasColumnType("numeric(30,6)");

                entity.HasOne(d => d.producto)
                    .WithMany(p => p.ventadetalle)
                    .HasForeignKey(d => d.productoid)
                    .HasConstraintName("fk_producto_ventadetalle");

                entity.HasOne(d => d.venta)
                    .WithMany(p => p.ventadetalle)
                    .HasForeignKey(d => d.ventaid)
                    .HasConstraintName("fk_venta_ventadetalle");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
