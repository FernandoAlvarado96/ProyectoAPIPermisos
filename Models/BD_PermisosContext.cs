using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebAPI_Permisos.Models
{
    public partial class BD_PermisosContext : DbContext
    {
        public BD_PermisosContext()
        {
        }

        public BD_PermisosContext(DbContextOptions<BD_PermisosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Permiso> Permisos { get; set; }
        public virtual DbSet<TipoPermiso> TipoPermisos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=localhost;Database=BD_Permisos;Integrated Security=True;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Permiso>(entity =>
            {
                entity.ToTable("Permiso");

                entity.Property(e => e.ApellidosEmpleado)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.FechaPermiso).HasColumnType("datetime");

                entity.Property(e => e.NombreEmpleado)
                    .IsRequired()
                    .HasColumnType("text");

                entity.HasOne(d => d.TipoPermisoNavigation)
                    .WithMany(p => p.Permisos)
                    .HasForeignKey(d => d.TipoPermiso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Permiso__TipoPer__4BAC3F29");
            });

            modelBuilder.Entity<TipoPermiso>(entity =>
            {
                entity.ToTable("TipoPermiso");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnType("text");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
