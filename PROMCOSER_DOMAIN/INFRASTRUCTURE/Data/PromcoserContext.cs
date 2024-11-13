using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PROMCOSER_DOMAIN.CORE.Entities;

namespace PROMCOSER_DOMAIN.INFRASTRUCTURE.Data;

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
        => optionsBuilder.UseSqlServer("Server=LAPTOP-7N747763;Database=PROMCOSER;Integrated Security=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__cliente__677F38F549D8FB2C");

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
                .HasMaxLength(10)
                .HasColumnName("dni");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(255)
                .HasColumnName("razon_social");
            entity.Property(e => e.Ruc)
                .HasMaxLength(50)
                .HasColumnName("ruc");
            entity.Property(e => e.Telefono)
                .HasMaxLength(10)
                .HasColumnName("telefono");
            entity.Property(e => e.TipoCliente)
                .HasMaxLength(1)
                .HasColumnName("tipo_cliente");
        });

        modelBuilder.Entity<DetalleParteDiario>(entity =>
        {
            entity.HasKey(e => e.IdDetalleParteDiario).HasName("PK__detalle___F8BD27F8EE90C7EF");

            entity.ToTable("detalle_parte_diario");

            entity.Property(e => e.IdDetalleParteDiario).HasColumnName("id_detalle_parte_diario");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
            entity.Property(e => e.Horas).HasColumnName("horas");
            entity.Property(e => e.IdParteDiario).HasColumnName("id_parte_diario");
            entity.Property(e => e.TrabajoEfectuado)
                .HasMaxLength(255)
                .HasColumnName("trabajo_efectuado");

            entity.HasOne(d => d.IdParteDiarioNavigation).WithMany(p => p.DetalleParteDiario)
                .HasForeignKey(d => d.IdParteDiario)
                .HasConstraintName("FK_detalle_parte_diario_parte_diario");
        });

        modelBuilder.Entity<Maquinaria>(entity =>
        {
            entity.HasKey(e => e.IdMaquinaria).HasName("PK__maquinar__8B61DA9784592A7E");

            entity.ToTable("maquinaria");

            entity.Property(e => e.IdMaquinaria).HasColumnName("id_maquinaria");
            entity.Property(e => e.AnioCompra).HasColumnName("anio_compra");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.HorometroActual)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("horometro_actual");
            entity.Property(e => e.HorometroCompra)
                .HasColumnType("decimal(18, 2)")
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
            entity.HasKey(e => e.IdParteDiario).HasName("PK__parte_di__D1A7335472895C08");

            entity.ToTable("parte_diario");

            entity.Property(e => e.IdParteDiario).HasColumnName("id_parte_diario");
            entity.Property(e => e.Aceite)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("aceite");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.Firmas).HasColumnName("firmas");
            entity.Property(e => e.HorometroFinal)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("horometro_final");
            entity.Property(e => e.HorometroInicio)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("horometro_inicio");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdMaquinaria).HasColumnName("id_maquinaria");
            entity.Property(e => e.IdPersonal).HasColumnName("id_personal");
            entity.Property(e => e.LugarTrabajo)
                .HasMaxLength(255)
                .HasColumnName("lugar_trabajo");
            entity.Property(e => e.Petroleo)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("petroleo");
            entity.Property(e => e.ProximoMantenimiento)
                .HasColumnType("datetime")
                .HasColumnName("proximo_mantenimiento");
            entity.Property(e => e.Serie)
                .HasMaxLength(50)
                .HasColumnName("serie");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.ParteDiario)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK_parte_diario_cliente");

            entity.HasOne(d => d.IdMaquinariaNavigation).WithMany(p => p.ParteDiario)
                .HasForeignKey(d => d.IdMaquinaria)
                .HasConstraintName("FK_parte_diario_maquinaria");

            entity.HasOne(d => d.IdPersonalNavigation).WithMany(p => p.ParteDiario)
                .HasForeignKey(d => d.IdPersonal)
                .HasConstraintName("FK_parte_diario_personal");
        });

        modelBuilder.Entity<Personal>(entity =>
        {
            entity.HasKey(e => e.IdPersonal).HasName("PK__personal__418FB80806CFF492");

            entity.ToTable("personal");

            entity.Property(e => e.IdPersonal).HasColumnName("id_personal");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .HasColumnName("apellido");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .HasColumnName("correo");
            entity.Property(e => e.Dni)
                .HasMaxLength(10)
                .HasColumnName("dni");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechNacimiento)
                .HasColumnType("datetime")
                .HasColumnName("fech_nacimiento");
            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.IdUbigeo).HasColumnName("id_ubigeo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
            entity.Property(e => e.Telefono)
                .HasMaxLength(10)
                .HasColumnName("telefono");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .HasColumnName("username");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Personal)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK_personal_rol");

            entity.HasOne(d => d.IdUbigeoNavigation).WithMany(p => p.Personal)
                .HasForeignKey(d => d.IdUbigeo)
                .HasConstraintName("FK_personal_ubigeo");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__rol__6ABCB5E00BB78F02");

            entity.ToTable("rol");

            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<Ubigeo>(entity =>
        {
            entity.HasKey(e => e.IdUbigeo).HasName("PK__ubigeo__F21B090CFC8A919D");

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
