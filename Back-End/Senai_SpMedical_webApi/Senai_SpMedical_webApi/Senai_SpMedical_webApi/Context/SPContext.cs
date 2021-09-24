﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Senai_SpMedical_webApi.Domains;

#nullable disable

namespace Senai_SpMedical_webApi.Context
{
    public partial class SPContext : DbContext
    {
        public SPContext()
        {
        }

        public SPContext(DbContextOptions<SPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clinica> Clinicas { get; set; }
        public virtual DbSet<Consultum> Consulta { get; set; }
        public virtual DbSet<Especialidade> Especialidades { get; set; }
        public virtual DbSet<Medico> Medicos { get; set; }
        public virtual DbSet<Paciente> Pacientes { get; set; }
        public virtual DbSet<StatusConsultum> StatusConsulta { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-R3SNJAL\\SQLEXPRESS; Initial Catalog=SP_Medical_Group; user id=sa; pwd=senai@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Clinica>(entity =>
            {
                entity.HasKey(e => e.IdClinica)
                    .HasName("PK__Clinica__FCCE236D4599CBB1");

                entity.ToTable("Clinica");

                entity.HasIndex(e => e.Cnpj, "UQ__Clinica__A299CC92AC7840B1")
                    .IsUnique();

                entity.HasIndex(e => e.RazaoSocial, "UQ__Clinica__B0E5930EC7D337B6")
                    .IsUnique();

                entity.Property(e => e.IdClinica).HasColumnName("Id_Clinica");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.HoraAbertura).HasColumnName("Hora_Abertura");

                entity.Property(e => e.HoraFechamento).HasColumnName("Hora_Fechamento");

                entity.Property(e => e.NomeFantasia)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nome_Fantasia");

                entity.Property(e => e.RazaoSocial)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("Razao_Social");
            });

            modelBuilder.Entity<Consultum>(entity =>
            {
                entity.HasKey(e => e.IdConsulta)
                    .HasName("PK__Consulta__C6582588BF8AC308");

                entity.Property(e => e.IdConsulta).HasColumnName("Id_Consulta");

                entity.Property(e => e.DataConsulta)
                    .HasColumnType("date")
                    .HasColumnName("Data_Consulta");

                entity.Property(e => e.IdClinica).HasColumnName("Id_Clinica");

                entity.Property(e => e.IdMedico).HasColumnName("Id_Medico");

                entity.Property(e => e.IdProntuario).HasColumnName("Id_Prontuario");

                entity.Property(e => e.IdStatus).HasColumnName("Id_Status");

                entity.HasOne(d => d.IdClinicaNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdClinica)
                    .HasConstraintName("FK__Consulta__Id_Cli__3B75D760");

                entity.HasOne(d => d.IdMedicoNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdMedico)
                    .HasConstraintName("FK__Consulta__Id_Med__398D8EEE");

                entity.HasOne(d => d.IdProntuarioNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdProntuario)
                    .HasConstraintName("FK__Consulta__Id_Pro__38996AB5");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdStatus)
                    .HasConstraintName("FK__Consulta__Id_Sta__3A81B327");
            });

            modelBuilder.Entity<Especialidade>(entity =>
            {
                entity.HasKey(e => e.IdEspecialidade)
                    .HasName("PK__Especial__C4CBC02BA906FA7F");

                entity.ToTable("Especialidade");

                entity.HasIndex(e => e.NomeEspecialidade, "UQ__Especial__9B68DE6F6EA70082")
                    .IsUnique();

                entity.Property(e => e.IdEspecialidade).HasColumnName("Id_Especialidade");

                entity.Property(e => e.NomeEspecialidade)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Nome_Especialidade");
            });

            modelBuilder.Entity<Medico>(entity =>
            {
                entity.HasKey(e => e.IdMedico)
                    .HasName("PK__Medico__7BA5D8103C677F75");

                entity.ToTable("Medico");

                entity.HasIndex(e => e.Crm, "UQ__Medico__C1FF83F7D6E3E0EF")
                    .IsUnique();

                entity.Property(e => e.IdMedico).HasColumnName("Id_Medico");

                entity.Property(e => e.Crm)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IdClinica).HasColumnName("Id_Clinica");

                entity.Property(e => e.IdEspecialidade).HasColumnName("Id_Especialidade");

                entity.Property(e => e.IdTipo).HasColumnName("Id_Tipo");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClinicaNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdClinica)
                    .HasConstraintName("FK__Medico__Id_Clini__35BCFE0A");

                entity.HasOne(d => d.IdEspecialidadeNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdEspecialidade)
                    .HasConstraintName("FK__Medico__Id_Espec__33D4B598");

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdTipo)
                    .HasConstraintName("FK__Medico__Id_Tipo__34C8D9D1");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => e.IdProntuario)
                    .HasName("PK__Paciente__E436CD067E853A3E");

                entity.HasIndex(e => e.Cpf, "UQ__Paciente__C1FF930948E049DE")
                    .IsUnique();

                entity.Property(e => e.IdProntuario).HasColumnName("Id_Prontuario");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DataNascimento)
                    .HasColumnType("date")
                    .HasColumnName("Data_Nascimento");

                entity.Property(e => e.Endereco)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.IdTipo).HasColumnName("Id_Tipo");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Rg)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Telefone)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Pacientes)
                    .HasForeignKey(d => d.IdTipo)
                    .HasConstraintName("FK__Pacientes__Id_Ti__300424B4");
            });

            modelBuilder.Entity<StatusConsultum>(entity =>
            {
                entity.HasKey(e => e.IdStatus)
                    .HasName("PK__Status_C__E39037C632A6C5A3");

                entity.ToTable("Status_Consulta");

                entity.Property(e => e.IdStatus).HasColumnName("Id_Status");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipo)
                    .HasName("PK__Tipo_Usu__06416392EC3BC982");

                entity.ToTable("Tipo_Usuario");

                entity.Property(e => e.IdTipo).HasColumnName("Id_Tipo");

                entity.Property(e => e.NomeTipo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Nome_Tipo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}