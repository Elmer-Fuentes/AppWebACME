using System;
using System.Collections.Generic;
using AppWebACME.Models;
using Microsoft.EntityFrameworkCore;

namespace AppWebACME.Data;

public partial class ACMEContext : DbContext
{
    public ACMEContext(DbContextOptions<ACMEContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Articulo> Articulos { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<Requisicion> Requisicions { get; set; }

    public virtual DbSet<RequisicionAnotacion> RequisicionAnotacions { get; set; }

    public virtual DbSet<RequisicionDetalle> RequisicionDetalles { get; set; }

    public virtual DbSet<TipoEmpresa> TipoEmpresas { get; set; }

    public virtual DbSet<UnidadMedidum> UnidadMedida { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Articulo>(entity =>
        {
            entity.HasKey(e => e.Idarticulo).HasName("PK__Articulo__48472EAF95E6CA13");

            entity.ToTable("Articulo");

            entity.Property(e => e.Idarticulo).HasColumnName("IDArticulo");
            entity.Property(e => e.Articulo1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Articulo");
            entity.Property(e => e.IdunidadMedida).HasColumnName("IDUnidadMedida");
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.StockActual).HasColumnType("decimal(18, 4)");

            entity.HasOne(d => d.IdunidadMedidaNavigation).WithMany(p => p.Articulos)
                .HasForeignKey(d => d.IdunidadMedida)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Articulo__Activo__5DCAEF64");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.Idempresa);

            entity.ToTable("Empresa");

            entity.Property(e => e.Idempresa).HasColumnName("IDEmpresa");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Empresa1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Empresa");
            entity.Property(e => e.IdtipoEmpresa).HasColumnName("IDTipoEmpresa");
            entity.Property(e => e.Presupuesto).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Ruc)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("RUC");

            entity.HasOne(d => d.IdtipoEmpresaNavigation).WithMany(p => p.Empresas)
                .HasForeignKey(d => d.IdtipoEmpresa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Empresa_TipoEmpresa");
        });

        modelBuilder.Entity<Requisicion>(entity =>
        {
            entity.HasKey(e => e.Idrequisicion);

            entity.ToTable("Requisicion");

            entity.Property(e => e.Idrequisicion)
                .ValueGeneratedNever()
                .HasColumnName("IDRequisicion");
            entity.Property(e => e.Idempresa).HasColumnName("IDEmpresa");
            entity.Property(e => e.NroRequiscion)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.IdempresaNavigation).WithMany(p => p.Requisicions)
                .HasForeignKey(d => d.Idempresa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Requisicion_Empresa");
        });

        modelBuilder.Entity<RequisicionAnotacion>(entity =>
        {
            entity.HasKey(e => e.IdrequisicionAnotacion).HasName("PK__Requisic__CC8487E211D6BD94");

            entity.ToTable("RequisicionAnotacion");

            entity.Property(e => e.IdrequisicionAnotacion).HasColumnName("IDRequisicionAnotacion");
            entity.Property(e => e.Anotacion)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Idrequisicion).HasColumnName("IDRequisicion");

            entity.HasOne(d => d.IdrequisicionNavigation).WithMany(p => p.RequisicionAnotacions)
                .HasForeignKey(d => d.Idrequisicion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RequisicionAnotacion_Requisicion");
        });

        modelBuilder.Entity<RequisicionDetalle>(entity =>
        {
            entity.HasKey(e => e.IdrequisicionDetalle).HasName("PK__Requisic__C7D6815F99A4B781");

            entity.ToTable("RequisicionDetalle");

            entity.Property(e => e.IdrequisicionDetalle).HasColumnName("IDRequisicionDetalle");
            entity.Property(e => e.Cantidad).HasColumnType("decimal(10, 4)");
            entity.Property(e => e.Idarticulo).HasColumnName("IDArticulo");
            entity.Property(e => e.Idrequisicion).HasColumnName("IDRequisicion");

            entity.HasOne(d => d.IdarticuloNavigation).WithMany(p => p.RequisicionDetalles)
                .HasForeignKey(d => d.Idarticulo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Requisici__IDArt__68487DD7");

            entity.HasOne(d => d.IdrequisicionNavigation).WithMany(p => p.RequisicionDetalles)
                .HasForeignKey(d => d.Idrequisicion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Requisici__Activ__6754599E");
        });

        modelBuilder.Entity<TipoEmpresa>(entity =>
        {
            entity.HasKey(e => e.IdtipoEmpresa);

            entity.ToTable("TipoEmpresa");

            entity.Property(e => e.IdtipoEmpresa).HasColumnName("IDTipoEmpresa");
            entity.Property(e => e.Descripción)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Sigla)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TipoEmpresa1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TipoEmpresa");
        });

        modelBuilder.Entity<UnidadMedidum>(entity =>
        {
            entity.HasKey(e => e.IdunidadMedida).HasName("PK__UnidadMe__1DB90804D105408A");

            entity.Property(e => e.IdunidadMedida).HasColumnName("IDUnidadMedida");
            entity.Property(e => e.Sigla)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UnidadMedida)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
