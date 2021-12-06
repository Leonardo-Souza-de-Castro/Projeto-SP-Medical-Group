using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Senai_SpMedical_webApi.Domains;

#nullable disable

namespace Senai_SpMedical_webApi.Contexts
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
        public virtual DbSet<Consulta> Consulta { get; set; }
        public virtual DbSet<Especialidade> Especialidades { get; set; }
        public virtual DbSet<Medico> Medicos { get; set; }
        public virtual DbSet<Paciente> Pacientes { get; set; }
        public virtual DbSet<StatusConsulta> StatusConsulta { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Data Source=NOTE0113D3\\SQLEXPRESS; Initial Catalog=SP_Medical_Group; user id=sa; pwd=Senai@132;");
                //optionsBuilder.UseSqlServer("Data Source=DESKTOP-R3SNJAL\\SQLEXPRESS; Initial Catalog=SP_Medical_Group; user id=sa; pwd=senai@132;");
                //optionsBuilder.UseSqlServer("Server = tcp:medical - group.database.windows.net,1433; Initial Catalog = SP_Medical_Group; Persist Security Info = False; User ID = leonardo; Password =guilherme/85; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");
                //optionsBuilder.UseSqlServer("Data Source=DESKTOP-R3SNJAL\\SQLEXPRESS; Initial Catalog=SP_Medical_Group; user id=sa; pwd=senai@132;");
                //optionsBuilder.UseSqlServer("Data Source=NOTE0113F1\\SQLEXPRESS; Initial Catalog=SP_Medical_Group; user id=sa; pwd=Senai@132;");
                optionsBuilder.UseSqlServer("Data Source=NOTE0113F1\\SQLEXPRESS; initial catalog=SP_Medical_Group; user Id=sa; pwd=Senai@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Clinica>(entity =>
            {
                entity.HasKey(e => e.IdClinica)
                    .HasName("PK__Clinica__FCCE236DB00BD39D");

                entity.ToTable("Clinica");

                entity.HasIndex(e => e.Cnpj, "UQ__Clinica__A299CC928F88D765")
                    .IsUnique();

                entity.HasIndex(e => e.RazaoSocial, "UQ__Clinica__B0E5930E6632E4F0")
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

            modelBuilder.Entity<Consulta>(entity =>
            {
                entity.HasKey(e => e.IdConsulta)
                    .HasName("PK__Consulta__C6582588ED22A39D");

                entity.Property(e => e.IdConsulta).HasColumnName("Id_Consulta");

                entity.Property(e => e.DataConsulta)
                    .HasColumnType("date")
                    .HasColumnName("Data_Consulta");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.IdMedico).HasColumnName("Id_Medico");

                entity.Property(e => e.IdProntuario).HasColumnName("Id_Prontuario");

                entity.Property(e => e.IdStatus).HasColumnName("Id_Status");

                entity.HasOne(d => d.IdMedicoNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdMedico)
                    .HasConstraintName("FK__Consulta__Id_Med__37A5467C");

                entity.HasOne(d => d.IdProntuarioNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdProntuario)
                    .HasConstraintName("FK__Consulta__Id_Pro__36B12243");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdStatus)
                    .HasConstraintName("FK__Consulta__Id_Sta__38996AB5");
            });

            modelBuilder.Entity<Especialidade>(entity =>
            {
                entity.HasKey(e => e.IdEspecialidade)
                    .HasName("PK__Especial__C4CBC02B4F71B795");

                entity.ToTable("Especialidade");

                entity.HasIndex(e => e.NomeEspecialidade, "UQ__Especial__9B68DE6F77F5E79E")
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
                    .HasName("PK__Medico__7BA5D810A83B7F43");

                entity.ToTable("Medico");

                entity.HasIndex(e => e.Crm, "UQ__Medico__C1FF83F76D02DB65")
                    .IsUnique();

                entity.Property(e => e.IdMedico).HasColumnName("Id_Medico");

                entity.Property(e => e.Crm)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.IdClinica).HasColumnName("Id_Clinica");

                entity.Property(e => e.IdEspecialidade).HasColumnName("Id_Especialidade");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClinicaNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdClinica)
                    .HasConstraintName("FK__Medico__Id_Clini__33D4B598");

                entity.HasOne(d => d.IdEspecialidadeNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdEspecialidade)
                    .HasConstraintName("FK__Medico__Id_Espec__32E0915F");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => e.IdProntuario)
                    .HasName("PK__Paciente__E436CD06ED355694");

                entity.HasIndex(e => e.Cpf, "UQ__Paciente__C1FF93092B14BA2B")
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
            });

            modelBuilder.Entity<StatusConsulta>(entity =>
            {
                entity.HasKey(e => e.IdStatus)
                    .HasName("PK__Status_C__E39037C605626849");

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
                    .HasName("PK__Tipo_Usu__064163927CC9EA20");

                entity.ToTable("Tipo_Usuario");

                entity.Property(e => e.IdTipo).HasColumnName("Id_Tipo");

                entity.Property(e => e.NomeTipo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Nome_Tipo");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__63C76BE23DDF80DB");

                entity.ToTable("Usuario");

                entity.HasIndex(e => e.Email, "UQ__Usuario__A9D105348CEF1687")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.IdTipo).HasColumnName("Id_Tipo");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipo)
                    .HasConstraintName("FK__Usuario__Id_Tipo__3C69FB99");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
