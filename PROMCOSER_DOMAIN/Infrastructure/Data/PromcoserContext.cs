using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using PROMCOSER_DOMAIN.Core.Entities;

namespace PROMCOSER_DOMAIN.Infrastructure.Data;

public partial class PromcoserContext : DbContext
{
    public PromcoserContext()
    {
    }

    public PromcoserContext(DbContextOptions<PromcoserContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Cliente { get; set; }

    public virtual DbSet<DetalleParteDiario> DetalleParteDiario { get; set; }

    public virtual DbSet<Maquinaria> Maquinaria { get; set; }

    public virtual DbSet<ParteDiario> ParteDiario { get; set; }

    public virtual DbSet<Personal> Personal { get; set; }

    public virtual DbSet<Rol> Rol { get; set; }

    public virtual DbSet<Ubigeo> Ubigeo { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=PROMCOSER;user=root;password=123456789", ServerVersion.Parse("8.0.37-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PRIMARY");

            entity.ToTable("cliente");

            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .HasColumnName("apellido");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .HasColumnName("correo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .HasColumnName("direccion");
            entity.Property(e => e.Dni)
                .HasMaxLength(20)
                .HasColumnName("dni");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(255)
                .HasColumnName("razon_social");
            entity.Property(e => e.Ruc)
                .HasMaxLength(20)
                .HasColumnName("ruc");
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .HasColumnName("telefono");
            entity.Property(e => e.TipoCliente)
                .HasMaxLength(50)
                .HasColumnName("tipo_cliente");
        });

        modelBuilder.Entity<DetalleParteDiario>(entity =>
        {
            entity.HasKey(e => e.IdDetalleParteDiario).HasName("PRIMARY");

            entity.ToTable("detalle_parte_diario");

            entity.HasIndex(e => e.ParteDiarioId, "parte_diario_id");

            entity.Property(e => e.IdDetalleParteDiario).HasColumnName("id_detalle_parte_diario");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
            entity.Property(e => e.Horas).HasColumnName("horas");
            entity.Property(e => e.ParteDiarioId).HasColumnName("parte_diario_id");
            entity.Property(e => e.TrabajoEfectuado)
                .HasMaxLength(255)
                .HasColumnName("trabajo_efectuado");

            entity.HasOne(d => d.ParteDiario).WithMany(p => p.DetalleParteDiario)
                .HasForeignKey(d => d.ParteDiarioId)
                .HasConstraintName("detalle_parte_diario_ibfk_1");
        });

        modelBuilder.Entity<Maquinaria>(entity =>
        {
            entity.HasKey(e => e.IdMaquinaria).HasName("PRIMARY");

            entity.ToTable("maquinaria");

            entity.Property(e => e.IdMaquinaria).HasColumnName("id_maquinaria");
            entity.Property(e => e.AnioCompra).HasColumnName("anio_compra");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .HasColumnName("estado");
            entity.Property(e => e.HorometroActual)
                .HasColumnType("time")
                .HasColumnName("horometro_actual");
            entity.Property(e => e.HorometroCompra)
                .HasColumnType("time")
                .HasColumnName("horometro_compra");
            entity.Property(e => e.Marca)
                .HasMaxLength(100)
                .HasColumnName("marca");
            entity.Property(e => e.Modelo)
                .HasMaxLength(100)
                .HasColumnName("modelo");
            entity.Property(e => e.Placa)
                .HasMaxLength(50)
                .HasColumnName("placa");
        });

        modelBuilder.Entity<ParteDiario>(entity =>
        {
            entity.HasKey(e => e.IdParteDiario).HasName("PRIMARY");

            entity.ToTable("parte_diario");

            entity.HasIndex(e => e.ClienteId, "cliente_id");

            entity.HasIndex(e => e.MaquinariaId, "maquinaria_id");

            entity.HasIndex(e => e.PersonalId, "personal_id");

            entity.Property(e => e.IdParteDiario).HasColumnName("id_parte_diario");
            entity.Property(e => e.Aceite)
                .HasPrecision(10, 2)
                .HasColumnName("aceite");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Firmas)
                .HasMaxLength(255)
                .HasColumnName("firmas");
            entity.Property(e => e.HorometroFinal)
                .HasColumnType("time")
                .HasColumnName("horometro_final");
            entity.Property(e => e.HorometroInicio)
                .HasColumnType("time")
                .HasColumnName("horometro_inicio");
            entity.Property(e => e.LugarTrabajo)
                .HasMaxLength(255)
                .HasColumnName("lugar_trabajo");
            entity.Property(e => e.MaquinariaId).HasColumnName("maquinaria_id");
            entity.Property(e => e.PersonalId).HasColumnName("personal_id");
            entity.Property(e => e.Petroleo)
                .HasPrecision(10, 2)
                .HasColumnName("petroleo");
            entity.Property(e => e.ProximoMantenimiento).HasColumnName("proximo_mantenimiento");
            entity.Property(e => e.Serie)
                .HasMaxLength(50)
                .HasColumnName("serie");

            entity.HasOne(d => d.Cliente).WithMany(p => p.ParteDiario)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("parte_diario_ibfk_1");

            entity.HasOne(d => d.Maquinaria).WithMany(p => p.ParteDiario)
                .HasForeignKey(d => d.MaquinariaId)
                .HasConstraintName("parte_diario_ibfk_3");

            entity.HasOne(d => d.Personal).WithMany(p => p.ParteDiario)
                .HasForeignKey(d => d.PersonalId)
                .HasConstraintName("parte_diario_ibfk_2");
        });

        modelBuilder.Entity<Personal>(entity =>
        {
            entity.HasKey(e => e.IdPersonal).HasName("PRIMARY");

            entity.ToTable("personal");

            entity.HasIndex(e => e.RolId, "rol_id");

            entity.HasIndex(e => e.UbigeoId, "ubigeo_id");

            entity.Property(e => e.IdPersonal).HasColumnName("id_personal");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .HasColumnName("apellido");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .HasColumnName("correo");
            entity.Property(e => e.Dni)
                .HasMaxLength(20)
                .HasColumnName("dni");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .HasColumnName("estado");
            entity.Property(e => e.Fechnacimiento).HasColumnName("fechnacimiento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
            entity.Property(e => e.RolId).HasColumnName("rol_id");
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .HasColumnName("telefono");
            entity.Property(e => e.UbigeoId).HasColumnName("ubigeo_id");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .HasColumnName("username");

            entity.HasOne(d => d.Rol).WithMany(p => p.Personal)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("personal_ibfk_1");

            entity.HasOne(d => d.Ubigeo).WithMany(p => p.Personal)
                .HasForeignKey(d => d.UbigeoId)
                .HasConstraintName("personal_ibfk_2");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PRIMARY");

            entity.ToTable("rol");

            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<Ubigeo>(entity =>
        {
            entity.HasKey(e => e.IdUbigeo).HasName("PRIMARY");

            entity.ToTable("ubigeo");

            entity.Property(e => e.IdUbigeo).HasColumnName("id_ubigeo");
            entity.Property(e => e.Departamento)
                .HasMaxLength(100)
                .HasColumnName("departamento");
            entity.Property(e => e.Distrito)
                .HasMaxLength(100)
                .HasColumnName("distrito");
            entity.Property(e => e.Provincia)
                .HasMaxLength(100)
                .HasColumnName("provincia");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
