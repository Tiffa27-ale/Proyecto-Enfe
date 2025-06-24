﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Enfe.Models;

public partial class EnfermeriaContext : DbContext
{
    public EnfermeriaContext()
    {
    }

    public EnfermeriaContext(DbContextOptions<EnfermeriaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EnfCita> EnfCitas { get; set; }

    public virtual DbSet<EnfHorario> EnfHorarios { get; set; }

    public virtual DbSet<EnfPersona> EnfPersonas { get; set; }

   // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
      //  => optionsBuilder.UseSqlServer("server=localhost\\SQLEXPRESS; database=enfermeria; User Id=sa;Password=Infomaniacos2025!; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EnfCita>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__enf_cita__3213E83F944AF4A7");

            entity.ToTable("enf_citas", tb => tb.HasTrigger("trg_enf_citas_update"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Creada")
                .HasColumnName("estado");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_modificacion");
            entity.Property(e => e.HoraLlegada).HasColumnName("hora_llegada");
            entity.Property(e => e.HoraSalida).HasColumnName("hora_salida");
            entity.Property(e => e.IdHorario).HasColumnName("id_horario");
            entity.Property(e => e.IdPersona).HasColumnName("id_persona");
            entity.Property(e => e.IdProfeLlegada).HasColumnName("id_profe_llegada");
            entity.Property(e => e.IdProfeSalida).HasColumnName("id_profe_salida");
            entity.Property(e => e.MensajeLlegada)
                .IsUnicode(false)
                .HasColumnName("mensaje_llegada");
            entity.Property(e => e.MensajeSalida)
                .IsUnicode(false)
                .HasColumnName("mensaje_salida");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usuario_creacion");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usuario_modificacion");

            entity.HasOne(d => d.IdHorarioNavigation).WithMany(p => p.EnfCita)
                .HasForeignKey(d => d.IdHorario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cita_horario");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.EnfCitaIdPersonaNavigations)
                .HasForeignKey(d => d.IdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cita_persona");

            entity.HasOne(d => d.IdProfeLlegadaNavigation).WithMany(p => p.EnfCitaIdProfeLlegadaNavigations)
                .HasForeignKey(d => d.IdProfeLlegada)
                .HasConstraintName("fk_profe_llegada");

            entity.HasOne(d => d.IdProfeSalidaNavigation).WithMany(p => p.EnfCitaIdProfeSalidaNavigations)
                .HasForeignKey(d => d.IdProfeSalida)
                .HasConstraintName("fk_profe_salida");
        });

        modelBuilder.Entity<EnfHorario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__enf_hora__3213E83F0D7BC31D");

            entity.ToTable("enf_horarios", tb => tb.HasTrigger("trg_enf_horarios_update"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_modificacion");
            entity.Property(e => e.Hora).HasColumnName("hora");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usuario_creacion");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usuario_modificacion");
        });

        modelBuilder.Entity<EnfPersona>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__enf_pers__3213E83F5103709C");

            entity.ToTable("enf_personas");

            entity.HasIndex(e => e.Cedula, "UQ__enf_pers__415B7BE5B8CB8889").IsUnique();

            entity.HasIndex(e => e.Usuario, "UQ__enf_pers__9AFF8FC604B13F16").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__enf_pers__AB6E616468B116E7").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cedula)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cedula");
            entity.Property(e => e.Departamento)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("departamento");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Seccion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("seccion");
            entity.Property(e => e.Sexo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sexo");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tipo");
            entity.Property(e => e.Usuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
