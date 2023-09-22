using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Graficos.Models;

public partial class VentasContext : DbContext
{
    public VentasContext()
    {
    }

    public VentasContext(DbContextOptions<VentasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DetalleVentum> DetalleVenta { get; set; }

    public virtual DbSet<Ventum> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LDI-14;DataBase=Ventas;Integrated Security=true;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DetalleVentum>(entity =>
        {
            entity.HasKey(e => e.IddetalleVenta).HasName("PK__DetalleV__DA9AFB7990D48AAE");

            entity.Property(e => e.IddetalleVenta).HasColumnName("IDDetalleVenta");
            entity.Property(e => e.Idventa).HasColumnName("IDVenta");
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdventaNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.Idventa)
                .HasConstraintName("FK__DetalleVe__IDVen__3A81B327");
        });

        modelBuilder.Entity<Ventum>(entity =>
        {
            entity.HasKey(e => e.Idventa).HasName("PK__Venta__27134B82B8C03C91");

            entity.Property(e => e.Idventa)
                .ValueGeneratedNever()
                .HasColumnName("IDVenta");
            entity.Property(e => e.DocumentoCliente)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ImpuestoTotal).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.NombreCliente)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NumeroVenta)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SubTotal)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
